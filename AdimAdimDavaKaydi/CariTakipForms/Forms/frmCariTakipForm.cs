using AdimAdimDavaKaydi.Belge.Forms;
using AdimAdimDavaKaydi.DavaTakip;
using AdimAdimDavaKaydi.Forms;
using AdimAdimDavaKaydi.Forms.LayForm;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Properties;
using AdimAdimDavaKaydi.Sorusturma.Forms;
using AdimAdimDavaKaydi.Sozlesme.Forms;
using AdimAdimDavaKaydi.Util.CariTakip;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.CariTakipForms.Forms
{
    //TODO: FİELDNAME lerini KOJNTROL ET HEPSİNİN --THSN-- UNUTMA **

    public partial class frmCariTakipForm : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmCariTakipForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public int cokCariSayisi;

        public bool degerlerHesaplansin;

        public bool tekCari;

        private AV001_TDI_BIL_CARI gelenCarim;

        //BV - BELGE ÖNİZLEME
        private frmLoading loading = new frmLoading();

        private PanelControl pnlControlIcraTaraflar = new PanelControl();

        private SimpleButton sBtnDavaSorumlusunaGore = new SimpleButton();

        private SimpleButton sBtnDavaTarafaGore = new SimpleButton();

        private SimpleButton sBtnIcraSorumlusunaGore = new SimpleButton();

        private SimpleButton sBtnIcraTarafaGore = new SimpleButton();

        private SimpleButton sBtnSorusturmaSorumlusunaGore = new SimpleButton();

        private SimpleButton sBtnSorusturmaTarafaGore = new SimpleButton();

        private SimpleButton sBtnSozlesmeSorumlusunaGore = new SimpleButton();

        private SimpleButton sBtnSozlesmeTarafaGore = new SimpleButton();

        private VList<R_BIRLESIK_TAKIPLER_BELGE_TEXT> sourceFoyBelge = new VList<R_BIRLESIK_TAKIPLER_BELGE_TEXT>();

        private VList<VI_BIL_BORCLU_ODEME_FOR_CARI_TAKIP> sourceFoyBorcluOdeme =
            new VList<VI_BIL_BORCLU_ODEME_FOR_CARI_TAKIP>();

        private VList<VDI_BIL_CARI_HESAP_FOR_CARI_TAKIP> sourceFoyCariHesap =
            new VList<VDI_BIL_CARI_HESAP_FOR_CARI_TAKIP>();

        private VList<R_BIRLESIK_TAKIPLER_DAVA_TEXT> sourceFoyDava = new VList<R_BIRLESIK_TAKIPLER_DAVA_TEXT>();

        private VList<VDI_BIL_FATURA_FOR_CARI_TAKIP> sourceFoyFatura = new VList<VDI_BIL_FATURA_FOR_CARI_TAKIP>();

        private VList<VDI_BIL_GORUSME_FOR_CARI_TAKIP> sourceFoyGorusme = new VList<VDI_BIL_GORUSME_FOR_CARI_TAKIP>();

        private VList<R_BIRLESIK_TAKIPLER_ICRA_TEXT> sourceFoyIcra = new VList<R_BIRLESIK_TAKIPLER_ICRA_TEXT>();

        private VList<VI_BIL_IHTIYATI_HACIZ_FOR_CARI_TAKIP> sourceFoyIhtiyatiHaciz =
            new VList<VI_BIL_IHTIYATI_HACIZ_FOR_CARI_TAKIP>();

        private VList<VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP> sourceFoyIhtiyatiTedbir =
            new VList<VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP>();

        private VList<VI_BIL_ITIRAZ_ALACAK_NEDEN_FOR_CARI_TAKIP> sourceFoyItirazAlacakNeden =
            new VList<VI_BIL_ITIRAZ_ALACAK_NEDEN_FOR_CARI_TAKIP>();

        private VList<KIYMETLI_EVRAK_TARAFLI> sourceFoyKiymetliEvrak = new VList<KIYMETLI_EVRAK_TARAFLI>();

        //private VList<R_BIRLESIK_TAKIPLER_TEBLIGAT_TEXT> sourceFoyTebligat =
        //    new VList<R_BIRLESIK_TAKIPLER_TEBLIGAT_TEXT>();
        private VList<VDIE_BIL_MESAJ_FOR_CARI_TAKIP> sourceFoyMail = new VList<VDIE_BIL_MESAJ_FOR_CARI_TAKIP>();

        private VList<R_MASRAF_AVANS_BIRLESIK_TARAF> sourceFoyMasrafAvans = new VList<R_MASRAF_AVANS_BIRLESIK_TARAF>();

        private VList<VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIP> sourceFoyOdemePlanı =
            new VList<VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIP>();

        private VList<VSMS_BIL_MESAJ_NUMARA_FOR_CARI_TAKIP> sourceFoySMS =
            new VList<VSMS_BIL_MESAJ_NUMARA_FOR_CARI_TAKIP>();

        private VList<R_SORUSTURMA_GENEL_ARAMA> sourceFoySorusturma = new VList<R_SORUSTURMA_GENEL_ARAMA>();

        private VList<R_SOZLESME_GENEL_ARAMA2> sourceFoySozlesme = new VList<R_SOZLESME_GENEL_ARAMA2>();

        private VList<VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIP> sourceFoyTaahhutMaster =
            new VList<VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIP>();

        private VList<VDI_BIL_TESPIT_FOR_CARI_TAKIP> sourceFoyTespit = new VList<VDI_BIL_TESPIT_FOR_CARI_TAKIP>();

        private VList<VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIP> sourceFoyTumMallar =
            new VList<VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIP>();

        private VList<VDI_BIL_IS_FOR_CARI_TAKIP> sourceFoyYapilcakIs = new VList<VDI_BIL_IS_FOR_CARI_TAKIP>();

        // < BV - 2 Haziran 2011 >
        private string tiklanan = "cari";

        [Browsable(false)]
        public TList<AV001_TDI_BIL_CARI> GelenCarilerim { get; set; }

        [Browsable(false)]
        public AV001_TDI_BIL_CARI GelenCarim
        {
            get { return gelenCarim; }
            set { gelenCarim = value; }
        }

        public static int ArastirilanMallarDosyaSayisiGetByTarafAdi(int CariId)
        {
            //TIPI ne göre süzülecek
            string SorguCumlesi =
                "select COUNT(ID)  from VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIP where CARI_ID = @CariId AND TIP=4";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int BelgeDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi = "select COUNT(ID)  from R_BELGELER_TARAFLI where BELGE_TARAF_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int BeyanEdilenMallarDosyaSayisiGetByTarafAdi(int CariId)
        {
            //TIPI ne göre süzülecek
            string SorguCumlesi =
                "select COUNT(ID)  from VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIP where CARI_ID = @CariId AND TIP=3";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int BorcluOdemeDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi =
                "select COUNT(ID)  from VI_BIL_BORCLU_ODEME_FOR_CARI_TAKIP where ODEYEN_CARI_ID = @CariId ";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int CariHesapDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi = "select COUNT(ID)  from VDI_BIL_CARI_HESAP_FOR_CARI_TAKIP where CARI_ID = @CariId ";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int FaturaDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi = "select COUNT(ID)  from VDI_BIL_FATURA_FOR_CARI_TAKIP where CARI_ID = @CariId ";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int GelenGidenTebligatDosyaSayisiGetByTarafAdi(int CariId)
        {
            //Taraf_Adi
            string SorguCumlesi = "select COUNT(ID)  from R_BIRLESIK_TAKIPLER_TEBLIGAT_TEXT where MUHATAP_CARI_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int GorusmeDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi =
                "select COUNT(ID)  from VDI_BIL_GORUSME_FOR_CARI_TAKIP where GORUSEN_CARI_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int HacizliMallarDosyaSayisiGetByTarafAdi(int CariId)
        {
            //TIPI ne göre süzülecek
            string SorguCumlesi =
                "select COUNT(ID)  from VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIP where CARI_ID = @CariId and TIP=1";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int IhtiyatiHacizDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi =
                "select COUNT(ID)  from VI_BIL_IHTIYATI_HACIZ_FOR_CARI_TAKIP where ICRA_CARI_TARAF_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int IhtiyatiTedbirDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi =
                "select COUNT(ID)  from VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP where ICRA_CARI_TARAF_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int ItirazlarDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi =
                "select COUNT(ID)  from VI_BIL_ITIRAZ_ALACAK_NEDEN_FOR_CARI_TAKIP where ITIRAZ_EDEN_TARAF_ID = @CariId ";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int KiymetliEvrakCekSenetPoliceDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi = "select COUNT(ID)  from KIYMETLI_EVRAK_TARAFLI where TARAF_CARI_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int MailDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi =
                "select COUNT(ID)  from VDIE_BIL_MESAJ_FOR_CARI_TAKIP where GONDEREN_CARI_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int MasrafAvansDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi = "select COUNT(CARI_ID)  from R_MASRAF_AVANS_BIRLESIK_TARAF where CARI_ID = @CariId ";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int OdemePlaniDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi =
                "select COUNT(ID)  from VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIP where TAAHHUT_EDEN_ID = @CariId AND RESMI_MI='false'";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int RehinliMallarDosyaSayisiGetByTarafAdi(int CariId)
        {
            //TIPI ne göre süzülecek
            string SorguCumlesi =
                "select COUNT(ID)  from VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIP where CARI_ID = @CariId and TIP=2";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int ResmiTaahhutlerDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi =
                "select COUNT(ID)  from VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIP where TAAHHUT_EDEN_ID = @CariId  AND RESMI_MI='true'";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int SmsDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi = "select COUNT(ID)  from VSMS_BIL_MESAJ_NUMARA_FOR_CARI_TAKIP where CARI_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }
        
        public static int TespitDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi =
                "select COUNT(ID)  from VDI_BIL_TESPIT_FOR_CARI_TAKIP where TESPIT_YAPILAN_TARAF_ID = @CariId ";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int TumMallarDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi = "select COUNT(ID)  from VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIP where CARI_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public static int YapilcakIsDosyaSayisiGetByTarafAdi(int CariId)
        {
            string SorguCumlesi = "select COUNT(ID)  from VDI_BIL_IS_FOR_CARI_TAKIP where CARI_ID = @CariId";
            SqlCommand com = new SqlCommand(SorguCumlesi);
            var param = com.Parameters.Add("@CariId", System.Data.SqlDbType.Int);
            param.Value = CariId;
            var soncu = (int)DataRepository.Provider.ExecuteScalar(com);
            return soncu;
        }

        public void BelgeLookUpDoldur()
        {
            BelgeUtil.Inits.SubeKodGetir(rLueSubeKod);
            BelgeUtil.Inits.KontrolKimGetir(rLueKontrolKim);

            //BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            //BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            //BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            //BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
            //BelgeUtil.Inits.perCariGetir(rLueTarafAd);
            //BelgeUtil.Inits.BankaGetir(rLueBanka);
            //BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube);
            //BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
            //BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
            //BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
            //BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            //BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            //BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
        }

        public void BorcluOdemeLookUpDoldur()
        {
            BelgeUtil.Inits.AlacakNEdenGetir(rLueOdAlacakNEden);
            BelgeUtil.Inits.perCariGetir(rLueOdeyenCariID);
            BelgeUtil.Inits.OdemeYeriGetir(rLueOdemeYerID);
            BelgeUtil.Inits.OdemeTipiGetir(rLueOdemeTip);
            BelgeUtil.Inits.DovizTipGetir(rLueOdDovizTip);
        }

        public void CariHesapLookUpDoldur()
        {
            BelgeUtil.Inits.perCariGetir(rLueCCariID);
            BelgeUtil.Inits.BorcAlacakGetir(rLueCBorcAlacak);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueCHareketAnaKategori);
            BelgeUtil.Inits.HareketAnaKategoriGetir(rLueCHareketAltKategori);
            BelgeUtil.Inits.DovizTipGetir(rLueCDovizID);
            BelgeUtil.Inits.SubeKodGetir(rLueSubeKoduBuroID);
        }

        public void GorusmeLookUpDoldur()
        {
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueIsKAtegori);
            BelgeUtil.Inits.perCariGetir(rLueGorusenCariID);
        }

        public void IcraLookUpDoldur()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
            BelgeUtil.Inits.FoyDurumGetir(rLueFoyDurum);
            BelgeUtil.Inits.perCariGetir(rLueTarafAd);
            BelgeUtil.Inits.BankaGetir(rLueBanka);
            BelgeUtil.Inits.BankaSubeGetir(rLueBankaSube);
            BelgeUtil.Inits.FoyBirimGetir(rLueFoyBirim);
            BelgeUtil.Inits.FoyYeriGetir(rLueFoyYeri);
            BelgeUtil.Inits.FoyOzelDurumGetir(rLueFoyOzelDurum);
            BelgeUtil.Inits.TahsilatdurumGetir(rLueTahsilatDurum);
            BelgeUtil.Inits.KrediGrubu(rLueKrediGrup);
            BelgeUtil.Inits.KrediTipiGetir(rLueKrediTip);
        }

        public void IhtiyatiTedbirLookUpDoldur()
        {
            BelgeUtil.Inits.perCariGetir(rLueIhtiyatiTedbirCariID);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueTedbirAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueTedbirAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueTedbirAdliBirimNo);
            BelgeUtil.Inits.TeminatTuruGetir(rLueTedbirTeminatTurID);
            BelgeUtil.Inits.DovizTipGetir(rLueTedbirDovizID);
        }

        public void ItirazAlacakNedenLookUpDoldur()
        {
            BelgeUtil.Inits.AlacakNedenKodGetir(rLueitirazAlacakNeden);
            BelgeUtil.Inits.perCariGetir(rLueitirazEdenTarafCariID);
            BelgeUtil.Inits.ItirazSebebiGetir(rLueItirazSebebID);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueItirazAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueItirazAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueItirazAdliBirimNo);
            BelgeUtil.Inits.DovizTipGetir(rLueItirazTutarDovizTip);
            BelgeUtil.Inits.ItirazGiderilmeYol(reLueItirazGiderilmeYolu);
            BelgeUtil.Inits.ItirazSonucuGetir(rLueItirazSonucID);
        }

        public void MailLookUpDoldur()
        {
            BelgeUtil.Inits.perCariGetir(rLueMesajGonderenCARI);
            BelgeUtil.Inits.MailMesajTipGetir(rLueMesajTip);
        }

        public void MasrafAvansLookUpDoldur()
        {
            BelgeUtil.Inits.perCariGetir(rLueMCariID);
            BelgeUtil.Inits.BorcAlacakGetir(rLueMBorcAlacakID);
            BelgeUtil.Inits.OdemeTipiGetir(rLueMOdemeTip);
            BelgeUtil.Inits.HareketAnaKategoriGetir(rLueMAnaKategori);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueMAltKategori);
            BelgeUtil.Inits.DovizTipGetir(rLueMDovizID);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueMAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueMAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueMAdliBirimNo);
            BelgeUtil.Inits.TarafSifatGetir(rLueMTarafSifatID);
        }

        public void PanelTemizle()
        {
            pnlControlIcraTaraflar.Controls.Clear();
        }

        public void Show(AV001_TDI_BIL_CARI gelenCari)
        {
            GelenCarim = gelenCari;
            tekCari = true;
            this.Show();
        }

        #region < TIO - 20092706 ICRA-DAVA-SORUŞTURMA-BELGE-KIYMETLİ EVRAK-SÖZLEŞME-TEBLİGAT GridColumn Oluşturma - epositoryLookUp >

        private GridColumn colACIKLAMA = new GridColumn();
        private GridColumn colAdliye = new GridColumn();
        private GridColumn colASAMA_ADI = new GridColumn();
        private GridColumn colBADLIYE = new GridColumn();
        private GridColumn colBanka_ID = new GridColumn();
        private GridColumn colBELGE_ADI = new GridColumn();
        private GridColumn colBELGE_NO = new GridColumn();

        //BV - BELGE
        private GridColumn colBELGE_REFERANS_NO = new GridColumn();

        private GridColumn colBELGE_TARAF = new GridColumn();
        private GridColumn colBELGE_TURU = new GridColumn();
        private GridColumn colBESAS_NO = new GridColumn();
        private GridColumn colBKAYIT_TARIHI = new GridColumn();
        private GridColumn colBNO = new GridColumn();
        private GridColumn colBSIFAT = new GridColumn();
        private GridColumn colDAVA_TAKIP_KONU = new GridColumn();
        private GridColumn colDOKUMAN_UZANTI = new GridColumn();
        private GridColumn colDOSYA_ADI = new GridColumn();
        private GridColumn colDosya_No = new GridColumn();
        private GridColumn colDurum = new GridColumn();
        private GridColumn colESAS_NO = new GridColumn();
        private GridColumn colFOY_BIRIM_ID = new GridColumn();
        private GridColumn colFOY_OZEL_DURUM_ID = new GridColumn();
        private GridColumn colFOY_YERI_ID = new GridColumn();
        private GridColumn colGorev = new GridColumn();
        private GridColumn colGOREV = new GridColumn();
        private GridColumn colIsSelected = new GridColumn();
        private GridColumn colIZLENSIN_MI = new GridColumn();
        private GridColumn colKILITLI_MI = new GridColumn();
        private GridColumn colKLASOR_1 = new GridColumn();
        private GridColumn colKLASOR_2 = new GridColumn();
        private GridColumn colKODU = new GridColumn();
        private GridColumn colKONTROL_KIM_ID = new GridColumn();
        private GridColumn colKREDI_GRUP_ID = new GridColumn();
        private GridColumn colKREDI_TIP_ID = new GridColumn();
        private GridColumn colNo = new GridColumn();
        private GridColumn colONEMLI_MI = new GridColumn();
        private GridColumn colOzel_Kod1 = new GridColumn();
        private GridColumn colOzel_Kod2 = new GridColumn();
        private GridColumn colOzel_Kod3 = new GridColumn();
        private GridColumn colOzel_Kod4 = new GridColumn();
        private GridColumn colReferans1 = new GridColumn();
        private GridColumn colReferans2 = new GridColumn();
        private GridColumn colReferans3 = new GridColumn();
        private GridColumn colSIFAT = new GridColumn();

        //RepositoryItemLookUpEdit rLueTarafSifat = new RepositoryItemLookUpEdit();
        private GridColumn colSorumlu_Adi = new GridColumn();

        private GridColumn colSube_ID = new GridColumn();
        private GridColumn colSUBE_KOD_ID = new GridColumn();
        private GridColumn colSUC_OLAY_VADE_TARIHI = new GridColumn();
        private GridColumn colTAHSILAT_DURUM_ID = new GridColumn();
        private GridColumn colTakip_Konusu = new GridColumn();
        private GridColumn colTakip_T = new GridColumn();
        private GridColumn colTaraf_Adi = new GridColumn();
        private GridColumn colTipi = new GridColumn();
        private GridColumn colYAZILMA_TARIHI = new GridColumn();
        private RepositoryItemDateEdit deTakipTarihi = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueAdliBirimAdliye = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueAdliBirimGorev = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueAdliBirimNo = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueBanka = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueBankaSube = new RepositoryItemLookUpEdit();
        private RepositoryItemImageComboBox rLueBelgeDosyaUzanti = new RepositoryItemImageComboBox();
        private RepositoryItemLookUpEdit rLueFoyBirim = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueFoyDurum = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueFoyOzelDurum = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueFoyYeri = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueKontrolKim = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueKrediGrup = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueKrediTip = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueSubeKod = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTahsilatDurum = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTarafAd = new RepositoryItemLookUpEdit();

        #region kıymetli evrak grid column

        #region Field & Properties

        private GridColumn colARKASI_YAZILDI_MI = new GridColumn();
        private GridColumn colBANKA_ID = new GridColumn();
        private GridColumn colBANKA_SUBE_KODU = new GridColumn();
        private GridColumn colCEK_NO = new GridColumn();
        private GridColumn colEVRAK_KAYIT_TARIHI = new GridColumn();
        private GridColumn colEVRAK_TANZIM_TARIHI = new GridColumn();
        private GridColumn colEVRAK_TUR_ID = new GridColumn();
        private GridColumn colEVRAK_VADE_TARIHI = new GridColumn();
        private GridColumn colHESAP_NO = new GridColumn();
        private GridColumn colISLEMLER_BASLADIMI = new GridColumn();
        private GridColumn colKARSILIK_TUTAR = new GridColumn();
        private GridColumn colKARSILIK_TUTAR_DOVIZ_ID = new GridColumn();
        private GridColumn colKESIDE_YERI = new GridColumn();
        private GridColumn colNE_SEKILDE_AHZOLUNDUGU = new GridColumn();
        private GridColumn colODEME_YERI = new GridColumn();
        private GridColumn colSERH_ACIKLAMASI = new GridColumn();
        private GridColumn colSIKAYET_EDILDI_MI = new GridColumn();
        private GridColumn colSORAN_ID = new GridColumn();
        private GridColumn colSORULDUGU_TARIH = new GridColumn();
        private GridColumn colSORULMA_SONUCU = new GridColumn();
        private GridColumn colSUBE_ID = new GridColumn();
        private GridColumn colTAKIBE_KONULDU_MU = new GridColumn();
        private GridColumn colTARAF_CARI_ID = new GridColumn();
        private GridColumn colTARAF_TIP_ID = new GridColumn();
        private GridColumn colTUTAR = new GridColumn();
        private GridColumn colTUTAR_DOVIZ_ID = new GridColumn();

        #endregion Field & Properties

        #endregion kıymetli evrak grid column

        #endregion < TIO - 20092706 ICRA-DAVA-SORUŞTURMA-BELGE-KIYMETLİ EVRAK-SÖZLEŞME-TEBLİGAT GridColumn Oluşturma - epositoryLookUp >

        #region < TIO - 20092906 GÖRÜŞME GridColumn Oluşturma - RepositoryItemLokkUplarını oluşturma >

        private GridColumn colBITIS_SAATI = new GridColumn();
        private GridColumn colBITIS_TARIH = new GridColumn();
        private GridColumn colGORUSEN_CARI_ID = new GridColumn();
        private GridColumn colGORUSEN_TEL = new GridColumn();
        private GridColumn colGORUSENIN_NOTU = new GridColumn();
        private GridColumn colGORUSME_SURE = new GridColumn();
        private GridColumn colGORUSME_YONU = new GridColumn();
        private GridColumn colGORUSULEN_CARI_ID = new GridColumn();
        private GridColumn colGORUSULEN_TARAF = new GridColumn();
        private GridColumn colGORUSULEN_TEL = new GridColumn();
        private GridColumn colIS_KATEGORI_ID = new GridColumn();
        private GridColumn colISIN_YAPILDIGI_CARI_ID = new GridColumn();
        private GridColumn colKAYIT_TARIHI = new GridColumn();
        private GridColumn colSAAT = new GridColumn();
        private GridColumn colTARIH = new GridColumn();
        private RepositoryItemDateEdit deTarih = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueGorusenCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueIsKAtegori = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seSaat = new RepositoryItemSpinEdit();

        #endregion < TIO - 20092906 GÖRÜŞME GridColumn Oluşturma - RepositoryItemLokkUplarını oluşturma >

        #region < TIO - 20092906 Mail GridColumn Oluşturma - Repository leri Oluşturma >

        private RepositoryItemCheckEdit chkOkundumu = new RepositoryItemCheckEdit();
        private GridColumn colBASARILI_MI = new GridColumn();
        private GridColumn colBCC = new GridColumn();
        private GridColumn colCC = new GridColumn();
        private GridColumn colDISARIDAN_MI = new GridColumn();
        private GridColumn colGELEN_MI = new GridColumn();
        private GridColumn colGIDEN_MI = new GridColumn();
        private GridColumn colGONDEREN_CARI_ID = new GridColumn();
        private GridColumn colGONDERILENLER = new GridColumn();
        private GridColumn colGONDERIM_ZAMANI = new GridColumn();
        private GridColumn colICERIK = new GridColumn();
        private GridColumn colKONU = new GridColumn();
        private GridColumn colMESAJ_TIP = new GridColumn();
        private GridColumn colOKUNDU_MU = new GridColumn();
        private GridColumn colONAYLANDI_MI = new GridColumn();
        private GridColumn colONEMSIZ_POSTA_MI = new GridColumn();
        private GridColumn colREFERANS_NO = new GridColumn();
        private GridColumn colSILINDI_MI = new GridColumn();
        private GridColumn colTASLAK_MI = new GridColumn();
        private GridColumn colYILDIZLI_MI = new GridColumn();
        private RepositoryItemDateEdit deKayitT = new RepositoryItemDateEdit();
        private GridColumn kolKAYIT_TARIHI = new GridColumn();
        private RepositoryItemLookUpEdit rLueMesajGonderenCARI = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMesajTip = new RepositoryItemLookUpEdit();

        #endregion < TIO - 20092906 Mail GridColumn Oluşturma - Repository leri Oluşturma >

        #region < TIO - 20093006 SMS GridColumn Oluşturma - RepositoryItem ları oluşturma

        private GridColumn colAKTIFLESME_TARIHI = new GridColumn();
        private GridColumn colCARI_ID = new GridColumn();
        private GridColumn colDURUM_ID = new GridColumn();
        private GridColumn colFIRMA_TABLO_KOD = new GridColumn();
        private GridColumn colGONDERIM_SAYISI = new GridColumn();
        private GridColumn colGSM_OP_RAPOR_DURUM = new GridColumn();
        private GridColumn colGSM_OP_RAPOR_TARIHI = new GridColumn();
        private GridColumn colGSM_XML_SATIR_NO = new GridColumn();
        private GridColumn colNUMARA = new GridColumn();
        private GridColumn colNUMARA_KAYNAK = new GridColumn();
        private GridColumn colPASIFLESME_TARIHI = new GridColumn();
        private GridColumn colSON_GONDERIM_ZAMANI = new GridColumn();
        private RepositoryItemDateEdit deGSMRaporT = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueSMSDurum = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seGonderimZaman = new RepositoryItemSpinEdit();

        #endregion < TIO - 20093006 SMS GridColumn Oluşturma - RepositoryItem ları oluşturma

        #region < TIO - 20093006 Yapılcak İş GridColumn oluşturma - RepositoryItem ları oluşturma >

        private GridColumn colBASLANGIC_TARIHI = new GridColumn();
        private GridColumn colBITIS_TARIHI = new GridColumn();
        private GridColumn colDURUM = new GridColumn();
        private GridColumn colIS_NO = new GridColumn();
        private GridColumn colISACIKLAMA = new GridColumn();
        private GridColumn colISADLI_BIRIM_ADLIYE_ID = new GridColumn();
        private GridColumn colISADLI_BIRIM_GOREV_ID = new GridColumn();
        private GridColumn colISADLI_BIRIM_NO_ID = new GridColumn();
        private GridColumn colISCariID = new GridColumn();
        private GridColumn colISESAS_NO = new GridColumn();
        private GridColumn colISKONU = new GridColumn();
        private GridColumn colISREFERANS_NO = new GridColumn();
        private GridColumn colKATEGORI_ID = new GridColumn();
        private GridColumn colKOSUL = new GridColumn();
        private GridColumn colONCELIK_ID = new GridColumn();
        private GridColumn colONGORULEN_BITIS_TARIHI = new GridColumn();
        private GridColumn colONGORULEN_BITIS_ZAMANI = new GridColumn();
        private GridColumn colTARAFLAR = new GridColumn();
        private GridColumn colYAPILACAK_IS = new GridColumn();
        private GridColumn colYER = new GridColumn();
        private RepositoryItemDateEdit deISBitTarih = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueISAdlibirimAdliye = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueISAdliBirimGorev = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueISADliBirimNo = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueISCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueIsKategoriID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueISOncelikID = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seISBitZaman = new RepositoryItemSpinEdit();

        #endregion < TIO - 20093006 Yapılcak İş GridColumn oluşturma - RepositoryItem ları oluşturma >

        #region < TIO - 20093006 Tüm Mallar(Borçlu Mal) GridColumn Oluşturma-RepositoryItem ları yapma>

        private RepositoryItemCheckEdit chkMalUcuncuSahistami = new RepositoryItemCheckEdit();
        private GridColumn colADLI_BIRIM_ADLIYE_ID = new GridColumn();
        private GridColumn colADLI_BIRIM_GOREV_ID = new GridColumn();
        private GridColumn colADLI_BIRIM_NO_ID = new GridColumn();
        private GridColumn colALACAKLI_RIZASI_VAR_MI = new GridColumn();
        private GridColumn colARAC_PLAKA_NO = new GridColumn();
        private GridColumn colEKSPERTIZ_DEGERI = new GridColumn();
        private GridColumn colEKSPERTIZ_DEGERI_DOVIZ_ID = new GridColumn();
        private GridColumn colHACIZ_ISLEM_DURUM_ID = new GridColumn();
        private GridColumn colHACIZLI_MAL_ACIKLAMASI = new GridColumn();
        private GridColumn colHACIZLI_MAL_ADEDI = new GridColumn();
        private GridColumn colHACIZLI_MAL_ADET_BIRIM_ID = new GridColumn();
        private GridColumn colHACIZLI_MAL_CINS_ID = new GridColumn();
        private GridColumn colHACIZLI_MAL_DEGERI = new GridColumn();
        private GridColumn colHACIZLI_MAL_DEGERI_DOVIZ_ID = new GridColumn();
        private GridColumn colHACIZLI_MAL_KATEGORI_ID = new GridColumn();
        private GridColumn colHACIZLI_MAL_MARKASI = new GridColumn();
        private GridColumn colHACIZLI_MAL_NEVI = new GridColumn();
        private GridColumn colHACIZLI_MAL_OZELLIKLERI = new GridColumn();
        private GridColumn colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID = new GridColumn();
        private GridColumn colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR = new GridColumn();
        private GridColumn colHACIZLI_MAL_TUR_ID = new GridColumn();
        private GridColumn colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI = new GridColumn();
        private GridColumn colISTIHKAK_IDDIASI_VAR_MI = new GridColumn();
        private GridColumn colMAL_ADRES = new GridColumn();
        private GridColumn colMAL_SIRA_NO = new GridColumn();
        private GridColumn colMalCARI_ID = new GridColumn();
        private GridColumn colMalESAS_NO = new GridColumn();
        private GridColumn colMALIN_ADRESI = new GridColumn();
        private GridColumn colMALTIP = new GridColumn();
        private GridColumn colPARAYA_CEVRILDI_MI = new GridColumn();
        private GridColumn colUCUNCU_SAHIS_CARI_ID = new GridColumn();
        private GridColumn colUCUNCU_SAHISTA_MI = new GridColumn();
        private GridColumn colYEDIEMIN_CARI_ID = new GridColumn();
        private RepositoryItemLookUpEdit rLueMalAdetBirimKod = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMalAdliBirimAdliye = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMalAdliBirimGorev = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMalAdliBirimNo = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMalCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMalCins = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMalDovizID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMalHacizIslemDurum = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMalKategori = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMalTur = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seMalDeger = new RepositoryItemSpinEdit();

        #endregion < TIO - 20093006 Tüm Mallar(Borçlu Mal) GridColumn Oluşturma-RepositoryItem ları yapma>

        #region < TIO - 20090107 İhtiyati Tedbir GridColumn Oluşturma - RepositoryItem >

        private GridColumn colICRA_CARI_TARAF_ID = new GridColumn();
        private GridColumn colTACIKLAMA = new GridColumn();
        private GridColumn colTADLI_BIRIM_ADLIYE_ID = new GridColumn();
        private GridColumn colTADLI_BIRIM_GOREV_ID = new GridColumn();
        private GridColumn colTADLI_BIRIM_NO_ID = new GridColumn();
        private GridColumn colTDAVA_TARIHI = new GridColumn();
        private GridColumn colTESAS_NO = new GridColumn();
        private GridColumn colTKARAR_NO = new GridColumn();
        private GridColumn colTKARAR_TARIHI = new GridColumn();
        private GridColumn colTMUVEKKILE_TESLIM_TARIHI = new GridColumn();
        private GridColumn colTTALEP_TARIHI = new GridColumn();
        private GridColumn colTTEMINAT_IADE_TARIHI = new GridColumn();
        private GridColumn colTTEMINAT_TUR_ID = new GridColumn();
        private GridColumn colTTEMINAT_TUTARI = new GridColumn();
        private GridColumn colTTEMINAT_TUTARI_DOVIZ_ID = new GridColumn();
        private GridColumn colTTESLIM_ALAN_CARI_ID = new GridColumn();
        private RepositoryItemDateEdit deTedbirDavaT = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueIhtiyatiTedbirCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTedbirAdliBirimAdliye = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTedbirAdliBirimGorev = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTedbirAdliBirimNo = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTedbirDovizID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTedbirTeminatTurID = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seTeminatTutar = new RepositoryItemSpinEdit();

        #endregion < TIO - 20090107 İhtiyati Tedbir GridColumn Oluşturma - RepositoryItem >

        //BV

        #region < BV - 07062011 Gelen - Giden Evrak GridColumn Oluşturma>

        private GridColumn colADLIYE = new GridColumn();
        private GridColumn colB = new GridColumn();
        private GridColumn colBAGLANTI = new GridColumn();
        private GridColumn colBARKOD_NO = new GridColumn();
        private GridColumn colDOSYA_NO = new GridColumn();
        private GridColumn colEVRESAS_NO = new GridColumn();
        private GridColumn colEVRKONU = new GridColumn();
        private GridColumn colGRV = new GridColumn();
        private GridColumn colILISKI_EKLE = new GridColumn();
        private GridColumn colMuhatap = new GridColumn();
        private GridColumn colNO = new GridColumn();
        private GridColumn colO = new GridColumn();
        private GridColumn colTEBLIGAT_SEKLI = new GridColumn();
        private GridColumn colTeblig_T = new GridColumn();
        private GridColumn colZ = new GridColumn();
        private RepositoryItemDateEdit deTebligTarihi = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueEvrakAdliye = new RepositoryItemLookUpEdit();

        #endregion < BV - 07062011 Gelen - Giden Evrak GridColumn Oluşturma>

        #region < TIO - 20090107 Taahhüt Bilgileri GridColumn Oluşturma -RepositoryItemEdit>

        private RepositoryItemCheckEdit chkDavasiVarmi = new RepositoryItemCheckEdit();
        private GridColumn colDAVASI_VAR_MI = new GridColumn();
        private GridColumn colGECERLI_MI = new GridColumn();
        private GridColumn colRESMI_MI = new GridColumn();
        private GridColumn colTAAHHUDU_KABUL_EDEN_ID = new GridColumn();
        private GridColumn colTAAHHUDU_KABUL_TARIHI = new GridColumn();
        private GridColumn colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI = new GridColumn();
        private GridColumn colTAAHHUT_EDEN_ID = new GridColumn();
        private GridColumn colTAAHHUT_IHLAL_TARIHI = new GridColumn();
        private GridColumn colTAAHHUT_SIRA_NO = new GridColumn();
        private GridColumn colTAAHHUT_TARIHI = new GridColumn();
        private GridColumn colTAAHHUT_TIP = new GridColumn();
        private RepositoryItemDateEdit deTahTarihi = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueTahEdenCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seTaahhutSiraNo = new RepositoryItemSpinEdit();

        #endregion < TIO - 20090107 Taahhüt Bilgileri GridColumn Oluşturma -RepositoryItemEdit>

        #region < TIO -20090207 Borçlu Ödeme Bilgileri GridColumn Olöuşturma-RepositoryItem>

        private RepositoryItemCheckEdit chkMaasHacizdenmi = new RepositoryItemCheckEdit();
        private GridColumn colALACAK_NEDEN_ID = new GridColumn();
        private GridColumn colBORCLU_ADINA_ODENEN_CARI_ID = new GridColumn();
        private GridColumn colBORCLU_ADINA_ODEYEN_CARI_ID = new GridColumn();
        private GridColumn colICRADAN_CEKILME_TARIHI = new GridColumn();
        private GridColumn colIHTIYATI_HACIZDE_MI = new GridColumn();
        private GridColumn colKIYMETLI_EVRAK_ODENDI_MI = new GridColumn();
        private GridColumn colKIYMETLI_EVRAK_VADE_TARIHI = new GridColumn();
        private GridColumn colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI = new GridColumn();
        private GridColumn colMAAS_HACZINDEN_MI = new GridColumn();
        private GridColumn colODEME_KIM_ADINA = new GridColumn();
        private GridColumn colODEME_MIKTAR = new GridColumn();
        private GridColumn colODEME_MIKTAR_DOVIZ_ID = new GridColumn();
        private GridColumn colODEME_TARIHI = new GridColumn();
        private GridColumn colODEME_TIP_ID = new GridColumn();
        private GridColumn colODEME_YER_ID = new GridColumn();
        private GridColumn colODENEN_CARI_ID = new GridColumn();
        private GridColumn colODEYEN_CARI_ID = new GridColumn();
        private GridColumn colTAAHHUTE_DAGILAN_TUTAR = new GridColumn();
        private GridColumn colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID = new GridColumn();
        private GridColumn colTAAHHUTE_DAGILMA_TARIHI = new GridColumn();
        private RepositoryItemDateEdit deOdemeTarihi = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueOdAlacakNEden = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueOdDovizTip = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueOdemeTip = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueOdemeYerID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueOdeyenCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seOdemeTutar = new RepositoryItemSpinEdit();

        #endregion < TIO -20090207 Borçlu Ödeme Bilgileri GridColumn Olöuşturma-RepositoryItem>

        #region < TIO - 20090207  İtiraz Alacak Neden GridColumn Oluşturma - RePositoryItem >

        private RepositoryItemCheckEdit chkBorcaItirazVar = new RepositoryItemCheckEdit();
        private GridColumn colANA_PARA_ITIRAZ_TUTARI = new GridColumn();
        private GridColumn colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID = new GridColumn();
        private GridColumn colBORCA_ITIRAZ_VARMI = new GridColumn();
        private GridColumn colDAVASI_ACILDI_MI = new GridColumn();
        private GridColumn colFAIZE_ITIRAZ_TUTARI = new GridColumn();
        private GridColumn colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID = new GridColumn();
        private GridColumn colGECIKMIS_ITIRAZ_MI = new GridColumn();
        private GridColumn colGOREVE_ITIRAZ_VARMI = new GridColumn();
        private GridColumn colHUKMEDILEN_TAZMINAT = new GridColumn();
        private GridColumn colHUKMEDILEN_TAZMINAT_DOVIZ_ID = new GridColumn();
        private GridColumn colICRA_ITIRAZ_SEBEP_ID = new GridColumn();
        private GridColumn colIMZAYA_ITIRAZ_VARMI = new GridColumn();
        private GridColumn colITALACAK_NEDEN_ID = new GridColumn();
        private GridColumn colITIRAZ_BEYAN_SEKLI = new GridColumn();
        private GridColumn colITIRAZ_EDEN_TARAF_ID = new GridColumn();
        private GridColumn colITIRAZ_ESAS_NO = new GridColumn();
        private GridColumn colITIRAZ_KALDIRILMA_IHTAR_TARIHI = new GridColumn();
        private GridColumn colITIRAZ_KAPSAMI = new GridColumn();
        private GridColumn colITIRAZ_SONUC_ID = new GridColumn();
        private GridColumn colITIRAZ_SONUCU_KESINLESME_TARIHI = new GridColumn();
        private GridColumn colITIRAZ_TARIHI = new GridColumn();
        private GridColumn colITIRAZ_TUTARI = new GridColumn();
        private GridColumn colITIRAZ_TUTARI_DOVIZ_ID = new GridColumn();
        private GridColumn colITIRAZDAN_VAZGECME_TARIHI = new GridColumn();
        private GridColumn colITIRAZIN_GIDERILME_YOL_ID = new GridColumn();
        private GridColumn colitADLI_BIRIM_ADLIYE_ID = new GridColumn();
        private GridColumn colitADLI_BIRIM_GOREV_ID = new GridColumn();
        private GridColumn colitADLI_BIRIM_NO_ID = new GridColumn();
        private GridColumn colKABUL_EDILEN_TUTAR = new GridColumn();
        private GridColumn colKABUL_EDILEN_TUTAR_DOVIZ_ID = new GridColumn();
        private GridColumn colSON_ITIRAZ_TARIHI = new GridColumn();
        private GridColumn colYETKIYE_ITIRAZ_VARMI = new GridColumn();
        private RepositoryItemDateEdit deItirazTarihi = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit reLueItirazGiderilmeYolu = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueItirazAdliBirimAdliye = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueItirazAdliBirimGorev = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueItirazAdliBirimNo = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueItirazSebebID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueItirazSonucID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueItirazTutarDovizTip = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueitirazAlacakNeden = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueitirazEdenTarafCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seItirazTutar = new RepositoryItemSpinEdit();

        #endregion < TIO - 20090207  İtiraz Alacak Neden GridColumn Oluşturma - RePositoryItem >

        #region < TIO - 2009042009 Tespit Bilgileri GridColumn Oluşturma - RepositoryItem >

        private GridColumn colTeACIKLAMA = new GridColumn();
        private GridColumn colTeADLI_BIRIM_ADLIYE_ID = new GridColumn();
        private GridColumn colTeADLI_BIRIM_GOREV_ID = new GridColumn();
        private GridColumn colTeADLI_BIRIM_NO_ID = new GridColumn();
        private GridColumn colTeBILIRKISI1_CARI_ID = new GridColumn();
        private GridColumn colTeBILIRKISI2_CARI_ID = new GridColumn();
        private GridColumn colTeESAS_NO = new GridColumn();
        private GridColumn colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1 = new GridColumn();
        private GridColumn colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2 = new GridColumn();
        private GridColumn colTeKARAR_NO = new GridColumn();
        private GridColumn colTeKARAR_TARIHI = new GridColumn();
        private GridColumn colTeRAPOR_DEGERI = new GridColumn();
        private GridColumn colTeRAPOR_DEGERI_DOVIZ_ID = new GridColumn();
        private GridColumn colTeTALEP_TARIHI = new GridColumn();
        private GridColumn colTeTESPIT_KONU_ID = new GridColumn();
        private GridColumn colteTESPIT_YAPILAN_TARAF_ID = new GridColumn();
        private RepositoryItemDateEdit deTesKararTarihi = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueTesAdliBirimAdliye = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTesAdliBirimGorev = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTesAdliBirimNo = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTesCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTesRaporDegerDovizID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueTesTespitKonuID = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seTesRaporDegeri = new RepositoryItemSpinEdit();

        #endregion < TIO - 2009042009 Tespit Bilgileri GridColumn Oluşturma - RepositoryItem >

        #region < TIO - 20090607 Cari Hesap Bilgileri GridColumn Oluşturma - RepositoryItem>

        private RepositoryItemCheckEdit chkcIncelendi = new RepositoryItemCheckEdit();

        private GridColumn colCACIKLAMA = new GridColumn();

        private GridColumn colCADET = new GridColumn();

        private GridColumn colCBIRIM_FIYAT = new GridColumn();

        private GridColumn colCBIRIM_FIYAT_DOVIZ_ID = new GridColumn();

        private GridColumn colCBORC_ALACAK_ID = new GridColumn();

        private GridColumn colCCARI_ID = new GridColumn();

        private GridColumn colCDAVA_FOY_NO = new GridColumn();

        private GridColumn colCDETAY_ACIKLAMA = new GridColumn();

        private GridColumn colCGENEL_TOPLAM = new GridColumn();

        private GridColumn colCHAREKET_ALT_KAREGORI_ID = new GridColumn();

        private GridColumn colCHAREKET_ANA_KATEGORI_ID = new GridColumn();

        private GridColumn colCHAZIRLIK_NO = new GridColumn();

        private GridColumn colCICRA_FOY_NO = new GridColumn();

        private GridColumn colCINCELENDI = new GridColumn();

        private GridColumn colCKULLANICI_BELGE_NO = new GridColumn();

        private GridColumn colCONAY_DURUM = new GridColumn();

        private GridColumn colCONAY_NO = new GridColumn();

        private GridColumn colCONAY_TARIHI = new GridColumn();

        private GridColumn colCREFERANS_NO = new GridColumn();

        private GridColumn colCRUCU_NO = new GridColumn();

        private GridColumn colCSUBE_KOD_ID = new GridColumn();

        private GridColumn colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP = new GridColumn();

        private RepositoryItemDateEdit decOnayTarihi = new RepositoryItemDateEdit();

        private RepositoryItemLookUpEdit rLueCBorcAlacak = new RepositoryItemLookUpEdit();

        private RepositoryItemLookUpEdit rLueCCariID = new RepositoryItemLookUpEdit();

        private RepositoryItemLookUpEdit rLueCDovizID = new RepositoryItemLookUpEdit();

        private RepositoryItemLookUpEdit rLueCHareketAltKategori = new RepositoryItemLookUpEdit();

        private RepositoryItemLookUpEdit rLueCHareketAnaKategori = new RepositoryItemLookUpEdit();

        //GridColumn colCMASRAF_AVANS_ID = new GridColumn();
        private RepositoryItemLookUpEdit rLueCMasrafAvans = new RepositoryItemLookUpEdit();

        private RepositoryItemLookUpEdit rLueSubeKoduBuroID = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seCAdet = new RepositoryItemSpinEdit();

        #endregion < TIO - 20090607 Cari Hesap Bilgileri GridColumn Oluşturma - RepositoryItem>

        #region < TIO - 20090607 Masraf Avans Bilgileri GridColumn Oluşturma - Repository >

        private RepositoryItemCheckEdit chkMKavDahil = new RepositoryItemCheckEdit();
        private GridColumn colMACIKLAMA = new GridColumn();
        private GridColumn colMADET = new GridColumn();
        private GridColumn colMADLI_BIRIM_ADLIYE_ID = new GridColumn();
        private GridColumn colMADLI_BIRIM_GOREV_ID = new GridColumn();
        private GridColumn colMADLI_BIRIM_NO_ID = new GridColumn();
        private GridColumn colMAVANS_REFERANS_NO = new GridColumn();
        private GridColumn colMBIRIM_FIYAT = new GridColumn();
        private GridColumn colMBIRIM_FIYAT_DOVIZ_ID = new GridColumn();
        private GridColumn colMBORC_ALACAK_ID = new GridColumn();
        private GridColumn colMBORCLU_CARI_ID = new GridColumn();
        private GridColumn colMCARI_ID = new GridColumn();
        private GridColumn colMDETAY_ACIKLAMA = new GridColumn();
        private GridColumn colMESAS_NO = new GridColumn();
        private GridColumn colMFOY_NO = new GridColumn();
        private GridColumn colMGENEL_TOPLAM = new GridColumn();
        private GridColumn colMHAREKET_ALT_KATEGORI_ID = new GridColumn();
        private GridColumn colMHAREKET_ANA_KATEGORI_ID = new GridColumn();
        private GridColumn colMINCELENDI = new GridColumn();
        private GridColumn colMKAYIT_TARIHI = new GridColumn();
        private GridColumn colMKDV_DAHIL = new GridColumn();
        private GridColumn colMKDV_ORAN = new GridColumn();
        private GridColumn colMKDV_TUTAR = new GridColumn();
        private GridColumn colMKULLANICI_BELGE_NO = new GridColumn();
        private GridColumn colMMASRAF_AVANS_TIP = new GridColumn();
        private GridColumn colMMUVEKKIL_CARI_ID = new GridColumn();
        private GridColumn colMODEME_TIP_ID = new GridColumn();
        private GridColumn colMONAY_DURUM = new GridColumn();
        private GridColumn colMONAY_NO = new GridColumn();
        private GridColumn colMONAY_TARIHI = new GridColumn();
        private GridColumn colMOZEL_KOD1 = new GridColumn();
        private GridColumn colMOZEL_KOD2 = new GridColumn();
        private GridColumn colMOZEL_KOD3 = new GridColumn();
        private GridColumn colMOZEL_KOD4 = new GridColumn();
        private GridColumn colMREFERANS_NO = new GridColumn();
        private GridColumn colMREFERANS_NO2 = new GridColumn();
        private GridColumn colMREFERANS_NO3 = new GridColumn();
        private GridColumn colMSSDF_ORAN = new GridColumn();
        private GridColumn colMSTOPAJ_ORAN = new GridColumn();
        private GridColumn colMSTOPAJ_SSDF_DAHIL = new GridColumn();
        private GridColumn colMSTOPAJ_SSDF_TUTAR = new GridColumn();
        private GridColumn colMTAKIP_T = new GridColumn();
        private GridColumn colMTARAF_CARI_ID = new GridColumn();
        private GridColumn colMTARAF_KODU = new GridColumn();
        private GridColumn colMTARAF_SIFAT_ID = new GridColumn();
        private GridColumn colMTARIH = new GridColumn();
        private GridColumn colMTipi = new GridColumn();
        private GridColumn colMTOPLAM_TUTAR = new GridColumn();
        private GridColumn colMTUM_MUVEKKILLERE_PAYLASTIR = new GridColumn();
        private RepositoryItemDateEdit deMKayitTarihi = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueMAdliBirimGorev = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMAdliBirimNo = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMAdliye = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMAltKategori = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMAnaKategori = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMBorcAlacakID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMDovizID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMOdemeTip = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMOzelKodlar = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueMTarafSifatID = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seMAdet = new RepositoryItemSpinEdit();

        #endregion < TIO - 20090607 Masraf Avans Bilgileri GridColumn Oluşturma - Repository >

        #region < TIO - 20090707 Fatura Bilgileri GridColumn Oluşturma - RepositoryItem >

        private GridColumn colFACIKLAMA = new GridColumn();
        private GridColumn colFALACAK_NEDEN_ID = new GridColumn();
        private GridColumn colFCARI_ID = new GridColumn();
        private GridColumn colFDAVA_FOY_NO = new GridColumn();
        private GridColumn colFDAVA_NEDEN_ID = new GridColumn();
        private GridColumn colFFATURA_HEDEF_TIP = new GridColumn();
        private GridColumn colFFATURA_KAPSAM_TIP = new GridColumn();
        private GridColumn colFFATURA_TARIH = new GridColumn();
        private GridColumn colFHAZIRLIK_NO = new GridColumn();
        private GridColumn colFICRA_FOY_NO = new GridColumn();
        private GridColumn colFKDV = new GridColumn();
        private GridColumn colFKDV_DOVIZ_ID = new GridColumn();
        private GridColumn colFMIKTAR = new GridColumn();
        private GridColumn colFMIKTAR_DOVIZ_ID = new GridColumn();
        private GridColumn colFREFERANS_NO = new GridColumn();
        private GridColumn colFSERI_NO = new GridColumn();
        private GridColumn colFSIKAYET_NEDEN_ID = new GridColumn();
        private GridColumn colFTOPLAM = new GridColumn();
        private GridColumn colFTOPLAM_DOVIZ_ID = new GridColumn();
        private RepositoryItemDateEdit deFFaturaTarihi = new RepositoryItemDateEdit();
        private RepositoryItemLookUpEdit rLueFAlacakNEden = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueFCariID = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueFDavaNeden = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueFDovizTip = new RepositoryItemLookUpEdit();
        private RepositoryItemLookUpEdit rLueFSikayetNEden = new RepositoryItemLookUpEdit();
        private RepositoryItemSpinEdit seFMiktar = new RepositoryItemSpinEdit();

        #endregion < TIO - 20090707 Fatura Bilgileri GridColumn Oluşturma - RepositoryItem >

        public void SMSLookUpDoldur()
        {
            BelgeUtil.Inits.perCariGetir(rLueCariID);
            BelgeUtil.Inits.SMSDurumGetir(rLueSMSDurum);
        }

        public void TaahhutMasterLookUpDoldur()
        {
            BelgeUtil.Inits.perCariGetir(rLueTahEdenCariID);
        }

        public void TespitLookUpDoldur()
        {
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueTesAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueTesAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueTesAdliBirimNo);
            BelgeUtil.Inits.TespitKonuGetir(rLueTesTespitKonuID);
            BelgeUtil.Inits.DovizTipGetir(rLueTesRaporDegerDovizID);
            BelgeUtil.Inits.perCariGetir(rLueTesCariID);
        }

        public void TumMallarLookUpDoldur()
        {
            BelgeUtil.Inits.MalKategoriGetir(rLueMalKategori);
            BelgeUtil.Inits.DovizTipGetir(rLueMalDovizID);
            BelgeUtil.Inits.perCariGetir(rLueMalCariID);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueMalAdliBirimNo);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueMalAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueMalAdliBirimAdliye);
            BelgeUtil.Inits.HacizIslemDurumGetir(rLueMalHacizIslemDurum);
            BelgeUtil.Inits.BirimKodGetir(rLueMalAdetBirimKod);
            BelgeUtil.Inits.MalTurGetir(rLueMalTur);
            BelgeUtil.Inits.MalcinsGetir(rLueMalCins);
        }

        public void YapilcakIsLookUpDoldur()
        {
            BelgeUtil.Inits.IsOncelikGetir(rLueISOncelikID);
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rLueIsKategoriID);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueISAdlibirimAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rLueISAdliBirimGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rLueISADliBirimNo);
            BelgeUtil.Inits.perCariGetir(rLueISCariID);
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            List<AvukatProLib.Arama.AV001_TDIE_BIL_BELGE> seciliKayitlar =
                new List<AvukatProLib.Arama.AV001_TDIE_BIL_BELGE>();

            foreach (
                AvukatProLib.Arama.AV001_TDIE_BIL_BELGE f in
                    (gridView1.DataSource as List<AvukatProLib.Arama.AV001_TDIE_BIL_BELGE>))
            {
                if (f.IsSelected)
                {
                    seciliKayitlar.Add(f);
                }
            }
            if (seciliKayitlar.Count > 0)
            {
                foreach (var item in seciliKayitlar)
                {
                    AvukatProLib.Arama.AV001_TDIE_BIL_BELGE belge = item;
                    if (belge != null && belge.ICERIK != null)
                    {
                        string bad = System.IO.Path.GetTempPath() + Guid.NewGuid() + "." + belge.DOKUMAN_UZANTI;
                        FileStream fs = new FileStream(bad, FileMode.Create);
                        fs.Write(belge.ICERIK.ToArray(), 0, belge.ICERIK.Length);
                        fs.Close();
                        fs.Dispose();
                        Tools.OpenProgram(bad);
                    }
                    else
                        MessageBox.Show("Belge İçeriği Bulunamadı", "Dikkat", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
            }
            else
            {
                object obj = gridView1.GetFocusedRow();

                AvukatProLib.Arama.AV001_TDIE_BIL_BELGE belge = obj as AvukatProLib.Arama.AV001_TDIE_BIL_BELGE;
                if (belge != null && belge.ICERIK != null)
                {
                    string bad = System.IO.Path.GetTempPath() + Guid.NewGuid() + "." + belge.DOKUMAN_UZANTI;
                    FileStream fs = new FileStream(bad, FileMode.Create);
                    fs.Write(belge.ICERIK.ToArray(), 0, belge.ICERIK.Length);
                    fs.Close();
                    fs.Dispose();
                    Tools.OpenProgram(bad);
                }
                else
                    MessageBox.Show("Belge İçeriği Bulunamadı", "Dikkat", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                degerlerHesaplansin = true;
                checkEdit1.Text = "Değerleri Hesaplama";
            }
            else
            {
                degerlerHesaplansin = false;
                checkEdit1.Text = "Değerleri Hesapla";
            }
        }

        private void DavaPanelGetir()
        {
            Size whIcraPanel = new Size();
            whIcraPanel.Height = 36;
            whIcraPanel.Width = 350;
            Point xyIcraPanel = new Point();
            xyIcraPanel.X = 320;
            xyIcraPanel.Y = 5;
            Size whIcraButton = new Size();
            whIcraButton.Width = 130;
            whIcraButton.Height = 22;
            Point xyIcraButton1 = new Point();
            xyIcraButton1.Y = 5;
            xyIcraButton1.X = 8;
            Point xyIcraButton2 = new Point();
            xyIcraButton2.Y = 5;
            xyIcraButton2.X = 200;
            sBtnDavaTarafaGore.Location = xyIcraButton1;
            sBtnDavaTarafaGore.Size = whIcraButton;
            sBtnDavaSorumlusunaGore.Location = xyIcraButton2;
            sBtnDavaSorumlusunaGore.Size = whIcraButton;
            pnlControlIcraTaraflar.Size = whIcraPanel;
            pnlControlIcraTaraflar.Location = xyIcraPanel;
            pnlControlIcraTaraflar.Controls.Clear();
            pnlControlIcraTaraflar.Controls.Add(sBtnDavaTarafaGore);
            pnlControlIcraTaraflar.Controls.Add(sBtnDavaSorumlusunaGore);
            pnlControlIcraTaraflar.Visible = true;
            sBtnDavaTarafaGore.Visible = true;
            sBtnDavaSorumlusunaGore.Visible = true;
            sBtnDavaSorumlusunaGore.Text = "Sorumlusu Olduğu Dos.";
            sBtnDavaTarafaGore.Text = "Taraf Olduğu Dos.";
            pnl_UstBilgiMenu.Controls.Add(pnlControlIcraTaraflar);
            sBtnDavaSorumlusunaGore.Click += sBtnDavaSorumlusunaGore_Click;
            sBtnDavaTarafaGore.Click += sBtnDavaTarafaGore_Click;
        }

        // < BV - 02 Haziran 2011 >
        //BV
        private void exGrdiOrtakAlan_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                switch (tiklanan)
                {
                    case "dava":
                        R_BIRLESIK_TAKIPLER_DAVA_TEXT takipDava = gridView1.GetFocusedRow() as R_BIRLESIK_TAKIPLER_DAVA_TEXT;
                        AV001_TD_BIL_FOY dava = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(takipDava.ID.Value);
                        TList<AV001_TD_BIL_FOY> seciliKayitlarDava = new TList<AV001_TD_BIL_FOY>();
                        seciliKayitlarDava.Add(dava);
                        frmDavaTakip frmdavaTakip = new frmDavaTakip();
                        frmdavaTakip.Show(seciliKayitlarDava);
                        break;

                    case "icra":
                        R_BIRLESIK_TAKIPLER_ICRA_TEXT takipIcra = gridView1.GetFocusedRow() as R_BIRLESIK_TAKIPLER_ICRA_TEXT;
                        AV001_TI_BIL_FOY icra = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(takipIcra.ID.Value);
                        TList<AV001_TI_BIL_FOY> seciliKayitlarIcra = new TList<AV001_TI_BIL_FOY>();
                        seciliKayitlarIcra.Add(icra);
                        _frmIcraTakip frmicraTakip = new _frmIcraTakip();
                        frmicraTakip.Show(seciliKayitlarIcra);
                        break;

                    case "odemebilgileri":
                        IcraTakipForms.rFrmTarafOdeme IcraOdemeKayit = new AdimAdimDavaKaydi.IcraTakipForms.rFrmTarafOdeme();
                        AvukatProLib2.Entities.VI_BIL_BORCLU_ODEME_FOR_CARI_TAKIP takipOdeme = gridView1.GetFocusedRow() as AvukatProLib2.Entities.VI_BIL_BORCLU_ODEME_FOR_CARI_TAKIP;
                        AV001_TI_BIL_BORCLU_ODEME odeme = DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.GetByID(takipOdeme.ID);
                        AV001_TI_BIL_FOY foy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(odeme.ICRA_FOY_ID.Value);
                        IcraOdemeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        IcraOdemeKayit.IsModul = true;
                        IcraOdemeKayit.MyGelisme = new AV001_TI_BIL_FOY_TARAF_GELISME();
                        IcraOdemeKayit.Show(odeme, foy);
                        break;

                    case "resmiTaahhut":
                        rFrmTaahhut TaahhutKaydi = new rFrmTaahhut();
                        VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIP taahhutTakip = gridView1.GetFocusedRow() as VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIP;
                        AV001_TI_BIL_BORCLU_TAAHHUT_MASTER taahhut = DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.GetByID(taahhutTakip.ID);
                        AV001_TI_BIL_BORCLU_TAAHHUT_CHILD childTaahhut = DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDProvider.GetByID(taahhut.ID);
                        AV001_TI_BIL_FOY taahhutFoy = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(taahhut.ICRA_FOY_ID.Value);
                        TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> seciliKayitlarTaahhut = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>();
                        TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD> childTaahhutList = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>();
                        seciliKayitlarTaahhut.Add(taahhut);
                        childTaahhutList.Add(childTaahhut);
                        TaahhutKaydi.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        TaahhutKaydi.TaahhutList = seciliKayitlarTaahhut;

                        //TaahhutKaydi.MyFoy = taahhutFoy;
                        TaahhutKaydi.TaahhutChild = childTaahhutList;

                        //TaahhutKaydi.TaahhutChild = taahhutFoy.AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection;
                        TaahhutKaydi.IsModul = true;
                        TaahhutKaydi.Show();
                        break;

                    case "gorusme":
                        rFrmGorusmeKayit GorusmeKayit = new rFrmGorusmeKayit();
                        VDI_BIL_GORUSME_FOR_CARI_TAKIP takipGorusme = gridView1.GetFocusedRow() as VDI_BIL_GORUSME_FOR_CARI_TAKIP;
                        AV001_TDI_BIL_GORUSME gorusme = DataRepository.AV001_TDI_BIL_GORUSMEProvider.GetByID(takipGorusme.ID);
                        AV001_TD_BIL_FOY foyg = null;
                        AV001_TI_BIL_FOY icraFoyg = null;
                        AV001_TD_BIL_HAZIRLIK hazirlikg = null;
                        if (gorusme.DAVA_FOY_ID != null)
                        {
                            foyg = DataRepository.AV001_TD_BIL_FOYProvider.GetByID(gorusme.DAVA_FOY_ID.Value);
                        }
                        if (gorusme.ICRA_FOY_ID != null)
                        {
                            icraFoyg = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(gorusme.ICRA_FOY_ID.Value);
                        }
                        if (gorusme.HAZIRLIK_ID != null)
                        {
                            hazirlikg = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(gorusme.HAZIRLIK_ID.Value);
                        }

                        if (foyg != null)
                        {
                            GorusmeKayit.MyFoy = foyg;
                        }
                        if (icraFoyg != null)
                        {
                            GorusmeKayit.MyIcraFoy = icraFoyg;
                        }
                        if (hazirlikg != null)
                        {
                            GorusmeKayit.MyHazirlik = hazirlikg;
                        }

                        GorusmeKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        GorusmeKayit.IsModul = true;
                        GorusmeKayit.Show();
                        break;

                    case "sorusturma":
                        R_SORUSTURMA_GENEL_ARAMA takipSorusturma = gridView1.GetFocusedRow() as R_SORUSTURMA_GENEL_ARAMA;
                        AV001_TD_BIL_HAZIRLIK sorusturma = DataRepository.AV001_TD_BIL_HAZIRLIKProvider.GetByID(takipSorusturma.ID);
                        TList<AV001_TD_BIL_HAZIRLIK> seciliKayitlarSorusturma = new TList<AV001_TD_BIL_HAZIRLIK>();
                        seciliKayitlarSorusturma.Add(sorusturma);
                        rFrmSorusturmaTakip frmSorusturmaTakip = new rFrmSorusturmaTakip();
                        frmSorusturmaTakip.Show(seciliKayitlarSorusturma);
                        break;

                    case "yapIs":
                        AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak frmisKayit = new AdimAdimDavaKaydi.Is.Forms.frmIsKayitUfak();
                        AvukatProLib2.Entities.VDI_BIL_IS_FOR_CARI_TAKIP isara = gridView1.GetFocusedRow() as AvukatProLib2.Entities.VDI_BIL_IS_FOR_CARI_TAKIP;
                        AV001_TDI_BIL_IS acilacakis = DataRepository.AV001_TDI_BIL_ISProvider.GetByID(isara.ID);
                        frmisKayit.Record = acilacakis;
                        frmisKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        frmisKayit.Show();
                        break;

                    case "sozlesme":

                        //BV SOZLESME -> ucSozlesmeArama'da da calismiyor ...
                        R_SOZLESME_GENEL_ARAMA2 takipSozlesme = gridView1.GetFocusedRow() as R_SOZLESME_GENEL_ARAMA2;
                        AV001_TDI_BIL_SOZLESME hazirlik = DataRepository.AV001_TDI_BIL_SOZLESMEProvider.GetByID(takipSozlesme.ID);
                        TList<AV001_TDI_BIL_SOZLESME> seciliKayitlarSozlesme = new TList<AV001_TDI_BIL_SOZLESME>();
                        seciliKayitlarSozlesme.Add(hazirlik);
                        frmSozlesmeTakip frmSozlesmeTakip = new frmSozlesmeTakip();
                        frmSozlesmeTakip.Show(seciliKayitlarSozlesme);
                        break;

                    case "ihtiyatitedbir":
                        frmDavaIcraIhtiyatiTedbir IhtiyadiTedbirKayit = new frmDavaIcraIhtiyatiTedbir();
                        VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP takipIhtTedbir = gridView1.GetFocusedRow() as VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP;
                        AV001_TDI_BIL_IHTIYATI_TEDBIR tedbir = DataRepository.AV001_TDI_BIL_IHTIYATI_TEDBIRProvider.GetByID(takipIhtTedbir.ID);
                        TList<AV001_TDI_BIL_IHTIYATI_TEDBIR> seciliIhtiyati = new TList<AV001_TDI_BIL_IHTIYATI_TEDBIR>();
                        seciliIhtiyati.Add(tedbir);
                        IhtiyadiTedbirKayit.MyDataSource = seciliIhtiyati;
                        IhtiyadiTedbirKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        IhtiyadiTedbirKayit.IsModul = true;
                        IhtiyadiTedbirKayit.Show();
                        break;

                    case "masrafAvans":
                        R_MASRAF_AVANS_BIRLESIK_TARAF avansTakip = gridView1.GetFocusedRow() as R_MASRAF_AVANS_BIRLESIK_TARAF;
                        //AV001_TDI_BIL_MASRAF_AVANS masrafAvans = DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.GetByID
                        IcraTakipForms.frmMasrafAvansKayitHizli masraf = new frmMasrafAvansKayitHizli();

                        //masraf.MyDataSource = masrafAvans;
                        masraf.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        masraf.AcilisYeri = MasrafFormuAcilisiYeri.TakipEkraniDisinda;
                        masraf.Show();
                        break;

                    case "ihtiyatihaciz":
                        frmIcraIhtiyatiHaciz IhtiyatiHacizKayit = new frmIcraIhtiyatiHaciz();
                        VI_BIL_IHTIYATI_HACIZ_FOR_CARI_TAKIP takipIhtHaciz = gridView1.GetFocusedRow() as VI_BIL_IHTIYATI_HACIZ_FOR_CARI_TAKIP;
                        AV001_TI_BIL_IHTIYATI_HACIZ haciz = DataRepository.AV001_TI_BIL_IHTIYATI_HACIZProvider.GetByID(takipIhtHaciz.ID);
                        AV001_TI_BIL_FOY foyHaciz = null;
                        if (haciz.ICRA_FOY_ID != null)
                        {
                            foyHaciz = DataRepository.AV001_TI_BIL_FOYProvider.GetByID(haciz.ICRA_FOY_ID.Value);
                        }
                        TList<AV001_TI_BIL_IHTIYATI_HACIZ> seciliHacizler = new TList<AV001_TI_BIL_IHTIYATI_HACIZ>();
                        seciliHacizler.Add(haciz);
                        IhtiyatiHacizKayit.MyDataSource = seciliHacizler;
                        IhtiyatiHacizKayit.MyFoy = foyHaciz;
                        IhtiyatiHacizKayit.StartPosition = FormStartPosition.WindowsDefaultLocation;
                        IhtiyatiHacizKayit.IsModul = true;
                        IhtiyatiHacizKayit.Show();
                        break;

                    case "evrak":
                        frmLayTabligatKayit tebligat = new AdimAdimDavaKaydi.Forms.LayForm.frmLayTabligatKayit();
                        tebligat.Duzenlememi = true;
                        if (gridView1.GetFocusedRow() != null)
                        {
                            //R_BIRLESIK_TAKIPLER_TEBLIGAT_TEXT currentTebligat = gridView1.GetFocusedRow() as R_BIRLESIK_TAKIPLER_TEBLIGAT_TEXT;

                            AvukatProLib.Arama.AV001_TDI_BIL_TEBLIGAT currentTebligat = gridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TDI_BIL_TEBLIGAT;

                            if (currentTebligat.DAVA_FOY_ID.HasValue)
                                tebligat.MyDavaFoyID = currentTebligat.DAVA_FOY_ID.Value;
                            else if (currentTebligat.ICRA_FOY_ID.HasValue)
                                tebligat.MyIcraFoyID = currentTebligat.ICRA_FOY_ID.Value;
                            else if (currentTebligat.HAZIRLIK_ID.HasValue)
                                tebligat.MyHazirlikFoyID = currentTebligat.HAZIRLIK_ID.Value;
                            else if (currentTebligat.SOZLESME_ID.HasValue)
                                tebligat.MySozlesmeFoyID = currentTebligat.SOZLESME_ID.Value;

                            tebligat.MyDataSource = DataRepository.AV001_TDI_BIL_TEBLIGATProvider.GetByID(currentTebligat.ID);
                            tebligat.Show();
                        }
                        break;

                    case "belge":
                        AvukatProLib.Arama.AV001_TDIE_BIL_BELGE belge = gridView1.GetFocusedRow() as AvukatProLib.Arama.AV001_TDIE_BIL_BELGE;

                        if (belge != null && belge.ID != 0)
                        {
                            AvukatProLib2.Entities.AV001_TDIE_BIL_BELGE selBel =
                                AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGEProvider.GetByID(belge.ID);
                            AvukatProLib2.Data.DataRepository.AV001_TDIE_BIL_BELGEProvider.DeepLoad(selBel, false, AvukatProLib2.Data.DeepLoadType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_BELGE_DOLASIM>));

                            if (gridView1.GetFocusedRow() == null)
                            {
                                return;
                            }

                            string file = selBel.DOSYA_ADI;
                            string[] exts = file.Split('.');

                            if (exts.Length <= 0)
                            {
                                return;
                            }

                            string ext = exts[exts.Length - 1].ToLower(new System.Globalization.CultureInfo("en-US"));
                            byte[] data = selBel.ICERIK;

                            if (file == string.Empty && data == null)
                            {
                                return;
                            }

                            if (data == null)
                            {
                                if (File.Exists(file))
                                {
                                    FileStream fss = new FileStream(file, FileMode.Open);

                                    byte[] veri = new byte[fss.Length];
                                    fss.Read(veri, 0, veri.Length);
                                    selBel.ICERIK = veri;
                                    data = selBel.ICERIK;
                                    fss.Close();
                                }
                            }

                            //ucBelgeAramaView1.panelControl3.Visible = true;
                            //ucBelgeAramaView1.BringToFront();

                            Loading();

                            //ucBelgeDolasim1.MyDataSource = selBel.AV001_TDIE_BIL_BELGE_DOLASIMCollection;
                            dockManager1.ForceInitialize();
                            dockPanelBelge.ControlContainer.Controls.Add(ucBelgeOnizleme1);
                            dockPanelBelge.ControlContainer.Controls[0].Dock = DockStyle.Fill;
                            dockPanelBelge.ControlContainer.Controls[0].Visible = true;

                            dockManager1.ForceInitialize();
                            dockPanelBelge.ControlContainer.Controls.Add(btnProgram);
                            dockPanelBelge.ControlContainer.Controls[1].Dock = DockStyle.Bottom;
                            dockPanelBelge.ControlContainer.Controls[1].Visible = true;

                            ucBelgeOnizleme1.ViewFile(data, selBel.ID, selBel.KONTROL_VERSIYON, ext);
                            loading.Close();

                            //dockPanel3.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                        }
                        break;

                    case "":
                        return;

                    default:
                        break;
                }
            }
        }

        private void frmCariTakipForm_Button_Yeni_Click(object sender, EventArgs e)
        {
            frmCariGenelGiris frmCariKaydet = new frmCariGenelGiris();
            frmCariKaydet.Show();
        }

        private void frmCariTakipForm_Load(object sender, EventArgs e)
        {
            this.Text = GelenCarim.AD + "  adı " + GelenCarim.KOD + "  kod numaralı  " + GelenCarim.MUSTERI_NO +
                        "  müşteri numaralı Şahısa ait rapor ekranı. ";

            #region İlk Açılışta İcra Föy Bilgileri doldurdum

            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetIcraGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            var sonuc = CariTakipMetots.IcraDosyaDoldur(GelenCarim.ID);
            sourceFoyIcra.Clear();
            foreach (var item in sonuc)
            {
                R_BIRLESIK_TAKIPLER_ICRA_TEXT text =
                    DataRepository.R_BIRLESIK_TAKIPLER_ICRA_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
                sourceFoyIcra.Add(text);
            }

            // sourceFoyIcra = DataRepository.R_BIRLESIK_TAKIPLER_ICRA_TEXTProvider.Get("Taraf_Adi=" + GelenCarim.ID, "Dosya_No DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyIcra;

            lblUstBolum.Text = "İcra Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.Icra_Islemleri_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyIcra.Count + " )";

            tiklanan = "icra";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            #endregion İlk Açılışta İcra Föy Bilgileri doldurdum

            #region < TIO - 20091007 navBarMenüde Cariye Göre gelen Bilgilerin Count larını gösterdik >

            navBarItem3.Caption += " Trf ( " + CariTakipMetots.IcraDosyaSayisiTaraf(gelenCarim.ID) + " ) " + " Srm ( " +
                                   CariTakipMetots.IcraDosyaSayisiSorumlu(gelenCarim.ID) + " ) ";
            navBarItem2.Caption += " Trf ( " + CariTakipMetots.DavaDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) " +
                                   " Srm ( " + CariTakipMetots.DavaDosyaSayisiGetBySorumlu(gelenCarim.ID) + " ) ";
            navBarItem4.Caption += " ( " + BelgeDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem1.Caption += " Trf ( " + CariTakipMetots.SorusturmaDosyaSayisiTaraf(gelenCarim.ID) + " ) " +
                                   " Srm ( " + CariTakipMetots.SorusturmaDosyaSayisiSorumlu(gelenCarim.ID) + " ) ";
            ;
            navBarItem5.Caption += " Trf ( " + CariTakipMetots.SozlesmeDosyaSayisiTaraf(gelenCarim.ID) + " ) " +
                                   " Srm ( " + CariTakipMetots.SozlesmeDosyaSayisiSorumlu(gelenCarim.ID) + " ) ";
            ;
            navBarItem6.Caption += " ( " + GelenGidenTebligatDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem9.Caption += " ( " + GorusmeDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem19.Caption += " ( " + KiymetliEvrakCekSenetPoliceDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem8.Caption += " ( " + MailDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem7.Caption += " ( " + SmsDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem32.Caption += " ( " + YapilcakIsDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem14.Caption += " ( " + TumMallarDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem18.Caption += " ( " + RehinliMallarDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem17.Caption += " ( " + HacizliMallarDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem16.Caption += " ( " + BeyanEdilenMallarDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem15.Caption += " ( " + ArastirilanMallarDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem21.Caption += " ( " + IhtiyatiTedbirDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem20.Caption += " ( " + IhtiyatiHacizDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem12.Caption += " ( " + ResmiTaahhutlerDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem11.Caption += " ( " + OdemePlaniDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem13.Caption += " ( " + BorcluOdemeDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem10.Caption += " ( " + ItirazlarDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem22.Caption += " ( " + TespitDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem25.Caption += " ( " + CariHesapDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem23.Caption += " ( " + MasrafAvansDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";
            navBarItem24.Caption += " ( " + FaturaDosyaSayisiGetByTarafAdi(gelenCarim.ID) + " ) ";

            #endregion < TIO - 20091007 navBarMenüde Cariye Göre gelen Bilgilerin Count larını gösterdik >
        }

        private Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Caption Edit

            dicFieldCaption.Add("EVRAK_TUR_ID", "Tür");
            dicFieldCaption.Add("EVRAK_KAYIT_TARIHI", "Kayıt T");
            dicFieldCaption.Add("EVRAK_VADE_TARIHI", "Vade T");
            dicFieldCaption.Add("EVRAK_TANZIM_TARIHI", "Tanzim T");
            dicFieldCaption.Add("TUTAR", "Tutar");
            dicFieldCaption.Add("NE_SEKILDE_AHZOLUNDUGU", "Ne Şekilde Ahzolundu");
            dicFieldCaption.Add("BANKA_ID", "Banka");
            dicFieldCaption.Add("SUBE_ID", "Şube");
            dicFieldCaption.Add("BANKA_SUBE_KODU", "Şube Kod");
            dicFieldCaption.Add("HESAP_NO", "Hesap No");
            dicFieldCaption.Add("CEK_NO", "Çek No");
            dicFieldCaption.Add("SORULDUGU_TARIH", "Sorulduğu T.");
            dicFieldCaption.Add("SORULMA_SONUCU", "Sorulma Sonucu");
            dicFieldCaption.Add("KARSILIK_TUTAR", "Karşılık Tutar");
            dicFieldCaption.Add("SORAN_ID", "Soran");
            dicFieldCaption.Add("ARKASI_YAZILDI_MI", "Arkası Yazıldı");
            dicFieldCaption.Add("SERH_ACIKLAMASI", "Serh Açıklama");
            dicFieldCaption.Add("SIKAYET_EDILDI_MI", "Şikayet Edildi Mi");
            dicFieldCaption.Add("KESIDE_YERI", "Keşide Yeri");
            dicFieldCaption.Add("ODEME_YERI", "Ödeme Yeri");
            dicFieldCaption.Add("ISLEMLER_BASLADIMI", "İşlemler Başladı");
            dicFieldCaption.Add("TARAF_CARI_ID", "Taraf");
            dicFieldCaption.Add("TARAF_TIP_ID", "Taraf Tip");
            dicFieldCaption.Add("TAKIBE_KONULDU_MU", "Takibe Konuldu");

            #endregion Caption Edit

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueEvrakTur = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueBanka = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueSube = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueCari = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueTarafTip = new RepositoryItemLookUpEdit();

            BelgeUtil.Inits.DovizTipGetir(rlueDoviz);
            BelgeUtil.Inits.KiymetliEvrakTipiGetir(rlueEvrakTur);
            BelgeUtil.Inits.perCariGetir(rlueCari);
            BelgeUtil.Inits.BankaGetir(rlueBanka);
            BelgeUtil.Inits.BankaSubeGetir(rlueSube);
            BelgeUtil.Inits.TarafSifatGetir(rlueTarafTip);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", rlueDoviz);

            sozluk.Add("EVRAK_TUR_ID", rlueEvrakTur);
            sozluk.Add("BANKA_ID", rlueBanka);
            sozluk.Add("SUBE_ID", rlueSube);
            sozluk.Add("SORAN_ID", rlueCari);
            sozluk.Add("TARAF_CARI_ID", rlueCari);
            sozluk.Add("TARAF_TIP_ID", rlueTarafTip);
            sozluk.Add("TUTAR_DOVIZ_ID", rlueDoviz);
            sozluk.Add("KARSILIK_TUTAR_DOVIZ_ID", rlueDoviz);

            #endregion Add item

            return sozluk;
        }

        private void IcraPanelGetir()
        {
            Size whIcraPanel = new Size();
            whIcraPanel.Height = 36;
            whIcraPanel.Width = 350;
            Point xyIcraPanel = new Point();
            xyIcraPanel.X = 320;
            xyIcraPanel.Y = 5;
            Size whIcraButton = new Size();
            whIcraButton.Width = 130;
            whIcraButton.Height = 22;
            Point xyIcraButton1 = new Point();
            xyIcraButton1.Y = 5;
            xyIcraButton1.X = 8;
            Point xyIcraButton2 = new Point();
            xyIcraButton2.Y = 5;
            xyIcraButton2.X = 200;
            sBtnIcraTarafaGore.Location = xyIcraButton1;
            sBtnIcraTarafaGore.Size = whIcraButton;
            sBtnIcraSorumlusunaGore.Location = xyIcraButton2;
            sBtnIcraSorumlusunaGore.Size = whIcraButton;
            pnlControlIcraTaraflar.Size = whIcraPanel;
            pnlControlIcraTaraflar.Location = xyIcraPanel;
            pnlControlIcraTaraflar.Controls.Clear();
            pnlControlIcraTaraflar.Controls.Add(sBtnIcraTarafaGore);
            pnlControlIcraTaraflar.Controls.Add(sBtnIcraSorumlusunaGore);
            pnlControlIcraTaraflar.Visible = true;
            sBtnIcraTarafaGore.Visible = true;
            sBtnIcraSorumlusunaGore.Visible = true;
            sBtnIcraSorumlusunaGore.Text = "Sorumlusu Olduğu Dos.";
            sBtnIcraTarafaGore.Text = "Taraf Olduğu Dos.";
            pnl_UstBilgiMenu.Controls.Add(pnlControlIcraTaraflar);
            sBtnIcraSorumlusunaGore.Click += sBtnIcraSorumlusunaGore_Click;
            sBtnIcraTarafaGore.Click += sBtnIcraTarafaGore_Click;
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;

            //this.Button_Excel_Click
            //this.Button_PDF_Click
            //this.Button_RTF_Click
            //this.Button_XML_Click
            this.Button_Yeni_Click += frmCariTakipForm_Button_Yeni_Click;
        }

        #region < TIO - 20092706 Grid Columları Oluşturuluyor >

        #region İcra Gridinin Colunları oluşturuldu

        private GridColumn[] GetIcraGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colDosya_No,
                                        this.colAdliye,
                                        this.colGorev,
                                        this.colNo,
                                        this.colESAS_NO,
                                        this.colTakip_T,
                                        this.colReferans1,
                                        this.colReferans2,
                                        this.colReferans3,
                                        this.colACIKLAMA,
                                        this.colDurum,
                                        this.colTaraf_Adi,
                                        this.colSIFAT,
                                        this.colSorumlu_Adi,
                                        this.colTipi,
                                        this.colOzel_Kod1,
                                        this.colOzel_Kod2,
                                        this.colOzel_Kod3,
                                        this.colOzel_Kod4,
                                        this.colBanka_ID,
                                        this.colSube_ID,
                                        this.colFOY_BIRIM_ID,
                                        this.colFOY_YERI_ID,
                                        this.colFOY_OZEL_DURUM_ID,
                                        this.colTAHSILAT_DURUM_ID,
                                        this.colKREDI_GRUP_ID,
                                        this.colKREDI_TIP_ID,
                                        this.colKLASOR_1,
                                        this.colKLASOR_2,
                                        this.colTakip_Konusu,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colDosya_No.Caption = "Föy No";
            this.colDosya_No.Visible = true;
            this.colDosya_No.VisibleIndex = 1;
            this.colDosya_No.OptionsColumn.AllowEdit = false;
            this.colDosya_No.OptionsColumn.ReadOnly = true;
            this.colDosya_No.Name = "colDosya_No";
            this.colDosya_No.FieldName = "Dosya_No";
            this.colACIKLAMA.Caption = "Açıklama";
            this.colACIKLAMA.Visible = true;
            this.colACIKLAMA.VisibleIndex = 2;
            this.colACIKLAMA.Name = "colACIKLAMA";
            this.colACIKLAMA.FieldName = "ACIKLAMA";
            this.colACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colAdliye.Caption = "Adliye";
            this.colAdliye.OptionsColumn.AllowEdit = false;
            this.colAdliye.OptionsColumn.ReadOnly = true;
            this.colAdliye.Name = "colAdliye";

            //
            this.colAdliye.Visible = true;
            this.colAdliye.VisibleIndex = 3;
            this.colAdliye.FieldName = "Adliye";
            this.colBanka_ID.Caption = "Banka";
            this.colBanka_ID.Name = "colBanka_ID";
            this.colBanka_ID.OptionsColumn.AllowEdit = false;
            this.colBanka_ID.OptionsColumn.ReadOnly = true;
            this.colBanka_ID.VisibleIndex = 4;
            this.colBanka_ID.Visible = true;
            this.colBanka_ID.FieldName = "BANKA_ID";
            this.colDurum.Caption = "Durum";
            this.colDurum.Visible = true;
            this.colDurum.VisibleIndex = 6;
            this.colDurum.OptionsColumn.AllowEdit = false;
            this.colDurum.OptionsColumn.ReadOnly = true;
            this.colDurum.Name = "colDurum";
            this.colDurum.FieldName = "Durum";
            this.colESAS_NO.Caption = "Esas";
            this.colESAS_NO.Visible = true;
            this.colESAS_NO.VisibleIndex = 7;
            this.colESAS_NO.OptionsColumn.AllowEdit = false;
            this.colESAS_NO.OptionsColumn.ReadOnly = true;
            this.colESAS_NO.Name = "colESAS_NO";
            this.colESAS_NO.FieldName = "ESAS_NO";
            this.colFOY_BIRIM_ID.Caption = "Birim";
            this.colFOY_BIRIM_ID.Visible = true;
            this.colFOY_BIRIM_ID.VisibleIndex = 8;
            this.colFOY_BIRIM_ID.Name = "colFOY_BIRIM_ID";
            this.colFOY_BIRIM_ID.OptionsColumn.AllowEdit = false;
            this.colFOY_BIRIM_ID.OptionsColumn.ReadOnly = true;
            this.colFOY_BIRIM_ID.FieldName = "FOY_BIRIM_ID";
            this.colFOY_OZEL_DURUM_ID.Caption = "Özel Durum";
            this.colFOY_OZEL_DURUM_ID.Visible = true;
            this.colFOY_OZEL_DURUM_ID.VisibleIndex = 9;
            this.colFOY_OZEL_DURUM_ID.OptionsColumn.AllowEdit = false;
            this.colFOY_OZEL_DURUM_ID.OptionsColumn.ReadOnly = true;
            this.colFOY_OZEL_DURUM_ID.Name = "colFOY_OZEL_DURUM_ID";
            this.colFOY_OZEL_DURUM_ID.FieldName = "FOY_OZEL_DURUM_ID";
            this.colFOY_YERI_ID.Caption = "Dosya Yeri";
            this.colFOY_YERI_ID.Name = "colFOY_YERI_ID";
            this.colFOY_YERI_ID.OptionsColumn.AllowEdit = false;
            this.colFOY_YERI_ID.OptionsColumn.ReadOnly = true;
            this.colFOY_YERI_ID.Visible = true;
            this.colFOY_YERI_ID.VisibleIndex = 10;
            this.colFOY_YERI_ID.FieldName = "FOY_YERI_ID";
            this.colGorev.Caption = "Görev";
            this.colGorev.Visible = true;
            this.colGorev.OptionsColumn.AllowEdit = false;
            this.colGorev.OptionsColumn.ReadOnly = true;
            this.colGorev.VisibleIndex = 11;
            this.colGorev.Name = "colGorev";
            this.colGorev.FieldName = "Gorev";
            this.colKLASOR_1.Caption = "Klasör 1";
            this.colKLASOR_1.Visible = true;
            this.colKLASOR_1.OptionsColumn.AllowEdit = false;
            this.colKLASOR_1.OptionsColumn.ReadOnly = true;
            this.colKLASOR_1.VisibleIndex = 12;
            this.colKLASOR_1.Name = "colKLASOR_1";
            this.colKLASOR_1.FieldName = "KLASOR_1";
            this.colKLASOR_2.Caption = "Klasör 2";
            this.colKLASOR_2.Visible = true;
            this.colKLASOR_2.OptionsColumn.AllowEdit = false;
            this.colKLASOR_2.OptionsColumn.ReadOnly = true;
            this.colKLASOR_2.VisibleIndex = 13;
            this.colKLASOR_2.Name = "colKLASOR_2";
            this.colKLASOR_2.FieldName = "KLASOR_2";
            this.colKREDI_GRUP_ID.Caption = "Kredi Grup";
            this.colKREDI_GRUP_ID.Visible = true;
            this.colKREDI_GRUP_ID.OptionsColumn.AllowEdit = false;
            this.colKREDI_GRUP_ID.OptionsColumn.ReadOnly = true;
            this.colKREDI_GRUP_ID.VisibleIndex = 14;
            this.colKREDI_GRUP_ID.Name = "colKREDI_GRUP_ID";
            this.colKREDI_GRUP_ID.FieldName = "KREDI_GRUP_ID";
            this.colKREDI_TIP_ID.Caption = "Kredi Tip";
            this.colKREDI_TIP_ID.Visible = true;
            this.colKREDI_TIP_ID.OptionsColumn.AllowEdit = false;
            this.colKREDI_TIP_ID.OptionsColumn.ReadOnly = true;
            this.colKREDI_TIP_ID.VisibleIndex = 15;
            this.colKREDI_TIP_ID.Name = "colKREDI_TIP_ID";
            this.colKREDI_TIP_ID.FieldName = "KREDI_TIP_ID";
            this.colNo.Caption = "No";
            this.colNo.Visible = true;
            this.colNo.OptionsColumn.AllowEdit = false;
            this.colNo.OptionsColumn.ReadOnly = true;
            this.colNo.VisibleIndex = 16;
            this.colNo.Name = "colNo";
            this.colNo.FieldName = "No";
            this.colOzel_Kod1.Caption = "Özel Kod 1";
            this.colOzel_Kod1.Visible = true;
            this.colOzel_Kod1.OptionsColumn.AllowEdit = false;
            this.colOzel_Kod1.OptionsColumn.ReadOnly = true;
            this.colOzel_Kod1.VisibleIndex = 17;
            this.colOzel_Kod1.Name = "colOzel_Kod1";
            this.colOzel_Kod1.FieldName = "Ozel_Kod1";
            this.colOzel_Kod2.Caption = "Özel Kod 2";
            this.colOzel_Kod2.Visible = true;
            this.colOzel_Kod2.OptionsColumn.AllowEdit = false;
            this.colOzel_Kod2.OptionsColumn.ReadOnly = true;
            this.colOzel_Kod2.VisibleIndex = 18;
            this.colOzel_Kod2.Name = "colOzel_Kod2";
            this.colOzel_Kod2.FieldName = "Ozel_Kod2";
            this.colOzel_Kod3.Caption = "Özel Kod 3";
            this.colOzel_Kod3.Visible = true;
            this.colOzel_Kod3.OptionsColumn.AllowEdit = false;
            this.colOzel_Kod3.OptionsColumn.ReadOnly = true;
            this.colOzel_Kod3.VisibleIndex = 19;
            this.colOzel_Kod3.Name = "colOzel_Kod3";
            this.colOzel_Kod3.FieldName = "Ozel_Kod3";
            this.colOzel_Kod4.Caption = "Özel Kod 4";
            this.colOzel_Kod4.Visible = true;
            this.colOzel_Kod4.OptionsColumn.AllowEdit = false;
            this.colOzel_Kod4.OptionsColumn.ReadOnly = true;
            this.colOzel_Kod4.VisibleIndex = 20;
            this.colOzel_Kod4.Name = "colOzel_Kod4";
            this.colOzel_Kod4.FieldName = "Ozel_Kod4";
            this.colReferans1.Caption = "Ref 1";
            this.colReferans1.Visible = true;
            this.colReferans1.OptionsColumn.AllowEdit = false;
            this.colReferans1.OptionsColumn.ReadOnly = true;
            this.colReferans1.VisibleIndex = 21;
            this.colReferans1.Name = "colReferans1";
            this.colReferans1.FieldName = "Referans1";
            this.colReferans2.Caption = "Ref 2";
            this.colReferans2.Visible = true;
            this.colReferans2.OptionsColumn.AllowEdit = false;
            this.colReferans2.OptionsColumn.ReadOnly = true;
            this.colReferans2.VisibleIndex = 22;
            this.colReferans2.Name = "colReferans2";
            this.colReferans2.FieldName = "Referans2";
            this.colReferans3.Caption = "Ref 3";
            this.colReferans3.Visible = true;
            this.colReferans3.OptionsColumn.AllowEdit = false;
            this.colReferans3.OptionsColumn.ReadOnly = true;
            this.colReferans3.VisibleIndex = 23;
            this.colReferans3.Name = "colReferans3";
            this.colReferans3.FieldName = "Referans3";
            this.colSIFAT.Caption = "Sıfat";
            this.colSIFAT.Visible = true;
            this.colSIFAT.OptionsColumn.AllowEdit = false;
            this.colSIFAT.OptionsColumn.ReadOnly = true;
            this.colSIFAT.VisibleIndex = 24;
            this.colSIFAT.Name = "colSIFAT";
            this.colSIFAT.FieldName = "SIFAT";
            this.colSorumlu_Adi.Caption = "Sorumlusu";
            this.colSorumlu_Adi.Visible = true;
            this.colSorumlu_Adi.OptionsColumn.AllowEdit = false;
            this.colSorumlu_Adi.OptionsColumn.ReadOnly = true;
            this.colSorumlu_Adi.VisibleIndex = 25;
            this.colSorumlu_Adi.Name = "colSorumlu_Adi";
            this.colSorumlu_Adi.FieldName = "Sorumlu_Adi";
            this.colSube_ID.Caption = "Şube";
            this.colSube_ID.Visible = true;
            this.colSube_ID.OptionsColumn.AllowEdit = false;
            this.colSube_ID.OptionsColumn.ReadOnly = true;
            this.colSube_ID.VisibleIndex = 26;
            this.colSube_ID.Name = "colSube_ID";
            this.colSube_ID.FieldName = "SUBE_ID";
            this.colTAHSILAT_DURUM_ID.Caption = "Tahsilat Durum";
            this.colTAHSILAT_DURUM_ID.Visible = true;
            this.colTAHSILAT_DURUM_ID.OptionsColumn.AllowEdit = false;
            this.colTAHSILAT_DURUM_ID.OptionsColumn.ReadOnly = true;
            this.colTAHSILAT_DURUM_ID.VisibleIndex = 27;
            this.colTAHSILAT_DURUM_ID.Name = "colTAHSILAT_DURUM_ID";
            this.colTAHSILAT_DURUM_ID.FieldName = "TAHSILAT_DURUM_ID";
            this.colTakip_Konusu.Caption = "Takip Konusu";
            this.colTakip_Konusu.Visible = true;
            this.colTakip_Konusu.OptionsColumn.AllowEdit = false;
            this.colTakip_Konusu.OptionsColumn.ReadOnly = true;
            this.colTakip_Konusu.VisibleIndex = 28;
            this.colTakip_Konusu.Name = "colTakip_Konusu";
            this.colTakip_Konusu.FieldName = "Takip_Konusu";
            this.colTakip_T.Caption = "Takip T";
            this.colTakip_T.Visible = true;
            this.colTakip_T.OptionsColumn.AllowEdit = false;
            this.colTakip_T.OptionsColumn.ReadOnly = true;
            this.colTakip_T.VisibleIndex = 29;
            this.colTakip_T.Name = "colTakip_T";
            this.colTakip_T.FieldName = "Takip_T";
            this.colTaraf_Adi.Caption = "Taraf";
            this.colTaraf_Adi.Visible = true;
            this.colTaraf_Adi.OptionsColumn.AllowEdit = false;
            this.colTaraf_Adi.OptionsColumn.ReadOnly = true;
            this.colTaraf_Adi.VisibleIndex = 30;
            this.colTaraf_Adi.Name = "colTaraf_Adi";
            this.colTaraf_Adi.FieldName = "Taraf_Adi";
            this.colTipi.Visible = true;
            this.colTipi.VisibleIndex = 31;
            this.colTipi.OptionsColumn.AllowEdit = false;
            this.colTipi.OptionsColumn.ReadOnly = true;
            this.colTipi.Name = "colTipi";
            this.colTipi.Caption = "Tipi";
            this.colTipi.FieldName = "Tipi";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            colAdliye.ColumnEdit = this.rLueAdliBirimAdliye;
            colGorev.ColumnEdit = this.rLueAdliBirimGorev;
            colNo.ColumnEdit = this.rLueAdliBirimNo;
            colTakip_T.ColumnEdit = this.deTakipTarihi;
            colDurum.ColumnEdit = this.rLueFoyDurum;
            colTaraf_Adi.ColumnEdit = this.rLueTarafAd;

            //colSIFAT.ColumnEdit = this.rLueTarafSifat; nvarChar
            colSorumlu_Adi.ColumnEdit = this.rLueTarafAd;
            colBanka_ID.ColumnEdit = this.rLueBanka;
            colSube_ID.ColumnEdit = this.rLueBankaSube;
            colFOY_BIRIM_ID.ColumnEdit = this.rLueFoyBirim;
            colFOY_YERI_ID.ColumnEdit = this.rLueFoyYeri;
            colFOY_OZEL_DURUM_ID.ColumnEdit = this.rLueFoyOzelDurum;
            colTAHSILAT_DURUM_ID.ColumnEdit = this.rLueTahsilatDurum;
            colKREDI_GRUP_ID.ColumnEdit = this.rLueKrediGrup;
            colKREDI_TIP_ID.ColumnEdit = this.rLueKrediTip;

            IcraLookUpDoldur();

            #endregion <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion İcra Gridinin Colunları oluşturuldu

        #region Belge Kolonlari oluşturuldu

        private GridColumn[] GetBelgeGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colBELGE_REFERANS_NO,
                                        this.colIsSelected,
                                        this.colBELGE_ADI,
                                        this.colBESAS_NO,
                                        this.colDOSYA_ADI,
                                        this.colYAZILMA_TARIHI,
                                        this.colDAVA_TAKIP_KONU,
                                        this.colSUC_OLAY_VADE_TARIHI,
                                        this.colDOKUMAN_UZANTI,
                                        this.colBELGE_NO,
                                        this.colBKAYIT_TARIHI,
                                        this.colKODU,
                                        this.colKILITLI_MI,
                                        this.colIZLENSIN_MI,
                                        this.colONEMLI_MI,
                                        this.colSUBE_KOD_ID,
                                        this.colKONTROL_KIM_ID,
                                        this.colBELGE_TURU,
                                        this.colBADLIYE,
                                        this.colGOREV,
                                        this.colBNO,
                                        this.colASAMA_ADI,
                                        this.colBSIFAT,
                                        this.colBELGE_TARAF                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colIsSelected.Caption = "Seç";
            this.colIsSelected.FieldName = "IsSelected";
            this.colIsSelected.OptionsColumn.AllowEdit = false;
            this.colIsSelected.OptionsColumn.ReadOnly = true;
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Visible = true;
            this.colIsSelected.VisibleIndex = 1;

            this.colBELGE_ADI.VisibleIndex = 2;
            this.colBELGE_ADI.FieldName = "BELGE_ADI";
            this.colBELGE_ADI.OptionsColumn.AllowEdit = false;
            this.colBELGE_ADI.OptionsColumn.ReadOnly = true;
            this.colBELGE_ADI.Name = "colBELGE_ADI";
            this.colBELGE_ADI.Visible = true;
            this.colBELGE_ADI.Caption = "Belge Adı";

            this.colBELGE_REFERANS_NO.VisibleIndex = 3;
            this.colBELGE_REFERANS_NO.FieldName = "BELGE_REFERANS_NO";
            this.colBELGE_REFERANS_NO.Name = "colBELGE_REFERANS_NO";
            this.colBELGE_REFERANS_NO.OptionsColumn.ReadOnly = true;
            this.colBELGE_REFERANS_NO.OptionsColumn.AllowEdit = false;
            this.colBELGE_REFERANS_NO.Visible = true;
            this.colBELGE_REFERANS_NO.Caption = "Belge Referans No";

            this.colBESAS_NO.VisibleIndex = 3;
            this.colBESAS_NO.FieldName = "ESAS_NO";
            this.colBESAS_NO.OptionsColumn.ReadOnly = true;
            this.colBESAS_NO.OptionsColumn.AllowEdit = false;
            this.colBESAS_NO.Name = "colBESAS_NO";
            this.colBESAS_NO.Visible = true;
            this.colBESAS_NO.Caption = "Esas No";

            this.colDOSYA_ADI.VisibleIndex = 4;
            this.colDOSYA_ADI.FieldName = "DOSYA_ADI";
            this.colDOSYA_ADI.Name = "colDOSYA_ADI";
            this.colDOSYA_ADI.OptionsColumn.AllowEdit = false;
            this.colDOSYA_ADI.OptionsColumn.ReadOnly = true;
            this.colDOSYA_ADI.Visible = true;
            this.colDOSYA_ADI.Caption = "Dosya Adresi";

            this.colYAZILMA_TARIHI.VisibleIndex = 5;
            this.colYAZILMA_TARIHI.FieldName = "YAZILMA_TARIHI";
            this.colYAZILMA_TARIHI.OptionsColumn.ReadOnly = true;
            this.colYAZILMA_TARIHI.OptionsColumn.AllowEdit = false;
            this.colYAZILMA_TARIHI.Name = "colYAZILMA_TARIHI";
            this.colYAZILMA_TARIHI.Visible = true;
            this.colYAZILMA_TARIHI.Caption = "Yazılma Tarihi";

            this.colDAVA_TAKIP_KONU.VisibleIndex = 6;
            this.colDAVA_TAKIP_KONU.FieldName = "DAVA_TAKIP_KONU";
            this.colDAVA_TAKIP_KONU.Name = "colDAVA_TAKIP_KONU";
            this.colDAVA_TAKIP_KONU.OptionsColumn.AllowEdit = false;
            this.colDAVA_TAKIP_KONU.OptionsColumn.ReadOnly = true;
            this.colDAVA_TAKIP_KONU.Visible = true;
            this.colDAVA_TAKIP_KONU.Caption = "Dava Konu";

            this.colSUC_OLAY_VADE_TARIHI.VisibleIndex = 7;
            this.colSUC_OLAY_VADE_TARIHI.FieldName = "SUC_OLAY_VADE_TARIHI";
            this.colSUC_OLAY_VADE_TARIHI.Name = "colSUC_OLAY_VADE_TARIHI";
            this.colSUC_OLAY_VADE_TARIHI.Visible = true;
            this.colSUC_OLAY_VADE_TARIHI.OptionsColumn.ReadOnly = true;
            this.colSUC_OLAY_VADE_TARIHI.OptionsColumn.AllowEdit = false;
            this.colSUC_OLAY_VADE_TARIHI.Caption = "Olay Vade T.";

            this.colDOKUMAN_UZANTI.VisibleIndex = 8;
            this.colDOKUMAN_UZANTI.ColumnEdit = rLueBelgeDosyaUzanti;
            this.colDOKUMAN_UZANTI.FieldName = "DOKUMAN_UZANTI";
            this.colDOKUMAN_UZANTI.OptionsColumn.ReadOnly = true;
            this.colDOKUMAN_UZANTI.OptionsColumn.AllowEdit = false;
            this.colDOKUMAN_UZANTI.Name = "colDOKUMAN_UZANTI";
            this.colDOKUMAN_UZANTI.Visible = true;
            this.colDOKUMAN_UZANTI.Caption = "Döküman Uzantı";

            this.colBELGE_NO.Caption = "Belge No";
            this.colBELGE_NO.FieldName = "BELGE_NO";
            this.colBELGE_NO.Name = "colBELGE_NO";
            this.colBELGE_NO.Visible = true;
            this.colBELGE_NO.OptionsColumn.AllowEdit = false;
            this.colBELGE_NO.OptionsColumn.ReadOnly = true;
            this.colBELGE_NO.VisibleIndex = 9;

            this.colBKAYIT_TARIHI.Caption = "Kayıt T.";
            this.colBKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            this.colBKAYIT_TARIHI.Name = "colBKAYIT_TARIHI";
            this.colBKAYIT_TARIHI.Visible = true;
            this.colBKAYIT_TARIHI.OptionsColumn.ReadOnly = true;
            this.colBKAYIT_TARIHI.OptionsColumn.AllowEdit = false;
            this.colBKAYIT_TARIHI.VisibleIndex = 10;

            this.colKODU.Caption = "T.K";
            this.colKODU.FieldName = "KODU";
            this.colKODU.Name = "colKODU";
            this.colKODU.Visible = true;
            this.colKODU.OptionsColumn.ReadOnly = true;
            this.colKODU.OptionsColumn.AllowEdit = false;
            this.colKODU.VisibleIndex = 11;

            this.colKILITLI_MI.Caption = "Kilitli";
            this.colKILITLI_MI.FieldName = "KILITLI_MI";
            this.colKILITLI_MI.Name = "colKILITLI_MI";
            this.colKILITLI_MI.Visible = true;
            this.colKILITLI_MI.OptionsColumn.ReadOnly = true;
            this.colKILITLI_MI.OptionsColumn.AllowEdit = false;
            this.colKILITLI_MI.VisibleIndex = 12;

            this.colIZLENSIN_MI.Caption = "İzlensin";
            this.colIZLENSIN_MI.FieldName = "IZLENSIN_MI";
            this.colIZLENSIN_MI.Name = "colIZLENSIN_MI";
            this.colIZLENSIN_MI.Visible = true;
            this.colIZLENSIN_MI.OptionsColumn.ReadOnly = true;
            this.colIZLENSIN_MI.OptionsColumn.AllowEdit = false;
            this.colIZLENSIN_MI.VisibleIndex = 13;

            this.colONEMLI_MI.Caption = "Önemli";
            this.colONEMLI_MI.FieldName = "ONEMLI_MI";
            this.colONEMLI_MI.Name = "colONEMLI_MI";
            this.colONEMLI_MI.Visible = true;
            this.colONEMLI_MI.OptionsColumn.ReadOnly = true;
            this.colONEMLI_MI.OptionsColumn.AllowEdit = false;
            this.colONEMLI_MI.VisibleIndex = 14;

            this.colSUBE_KOD_ID.Caption = "Büro";
            this.colSUBE_KOD_ID.ColumnEdit = rLueSubeKod;
            this.colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            this.colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            this.colSUBE_KOD_ID.OptionsColumn.ReadOnly = true;
            this.colSUBE_KOD_ID.OptionsColumn.AllowEdit = false;
            this.colSUBE_KOD_ID.Visible = true;
            this.colSUBE_KOD_ID.VisibleIndex = 15;

            this.colKONTROL_KIM_ID.Caption = "Kullanıcı";
            this.colKONTROL_KIM_ID.ColumnEdit = rLueKontrolKim;
            this.colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            this.colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            this.colKONTROL_KIM_ID.OptionsColumn.ReadOnly = true;
            this.colKONTROL_KIM_ID.OptionsColumn.AllowEdit = false;
            this.colKONTROL_KIM_ID.Visible = true;
            this.colKONTROL_KIM_ID.VisibleIndex = 16;

            this.colBELGE_TURU.Caption = "Belge Tür";
            this.colBELGE_TURU.FieldName = "BELGE_TURU";
            this.colBELGE_TURU.Name = "colBELGE_TURU";
            this.colBELGE_TURU.OptionsColumn.ReadOnly = true;
            this.colBELGE_TURU.OptionsColumn.AllowEdit = false;
            this.colBELGE_TURU.Visible = true;
            this.colBELGE_TURU.VisibleIndex = 17;

            this.colBADLIYE.Caption = "Adliye";
            this.colBADLIYE.FieldName = "ADLIYE";
            this.colBADLIYE.Name = "colBADLIYE";
            this.colBADLIYE.OptionsColumn.ReadOnly = true;
            this.colBADLIYE.OptionsColumn.AllowEdit = false;
            this.colBADLIYE.Visible = true;
            this.colBADLIYE.VisibleIndex = 18;

            this.colGOREV.Caption = "Görev";
            this.colGOREV.FieldName = "GOREV";
            this.colGOREV.Name = "colGOREV";
            this.colGOREV.OptionsColumn.ReadOnly = true;
            this.colGOREV.OptionsColumn.AllowEdit = false;
            this.colGOREV.Visible = true;
            this.colGOREV.VisibleIndex = 19;

            this.colBNO.Caption = "No";
            this.colBNO.FieldName = "NO";
            this.colBNO.Name = "colBNO";
            this.colBNO.OptionsColumn.ReadOnly = true;
            this.colBNO.OptionsColumn.AllowEdit = false;
            this.colBNO.Visible = true;
            this.colBNO.VisibleIndex = 20;

            this.colASAMA_ADI.Caption = "Aşama Adı";
            this.colASAMA_ADI.FieldName = "ASAMA_ADI";
            this.colASAMA_ADI.Name = "colASAMA_ADI";
            this.colASAMA_ADI.OptionsColumn.ReadOnly = true;
            this.colASAMA_ADI.OptionsColumn.AllowEdit = false;
            this.colASAMA_ADI.Visible = true;
            this.colASAMA_ADI.VisibleIndex = 21;

            this.colBSIFAT.Caption = "Sıfat";
            this.colBSIFAT.FieldName = "SIFAT";
            this.colBSIFAT.Name = "colBSIFAT";
            this.colBSIFAT.OptionsColumn.ReadOnly = true;
            this.colBSIFAT.OptionsColumn.AllowEdit = false;
            this.colBSIFAT.Visible = true;
            this.colBSIFAT.VisibleIndex = 22;

            this.colBELGE_TARAF.Caption = "Belge Taraf";
            this.colBELGE_TARAF.FieldName = "BELGE_TARAF";
            this.colBELGE_TARAF.Name = "colBELGE_TARAF";
            this.colBELGE_TARAF.OptionsColumn.ReadOnly = true;
            this.colBELGE_TARAF.OptionsColumn.AllowEdit = false;
            this.colBELGE_TARAF.Visible = true;
            this.colBELGE_TARAF.VisibleIndex = 23;

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            //colAdliye.ColumnEdit = this.rLueAdliBirimAdliye;

            //IcraLookUpDoldur();
            BelgeLookUpDoldur();

            #endregion <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Belge Kolonlari oluşturuldu

        //BV Deneme2

        #region KıymetliEvrak Gridinin Colunları oluşturuldu

        private GridColumn[] GetKıymetliEvrakGird()
        {
            #region []

            GridColumn[] dizi = new[]
                                    {
                                        colEVRAK_TUR_ID,
                                        colEVRAK_KAYIT_TARIHI,
                                        colEVRAK_VADE_TARIHI,
                                        colEVRAK_TANZIM_TARIHI,
                                        colTUTAR_DOVIZ_ID,
                                        colTUTAR,
                                        colNE_SEKILDE_AHZOLUNDUGU,
                                        colBANKA_ID,
                                        colSUBE_ID,
                                        colBANKA_SUBE_KODU,
                                        colHESAP_NO,
                                        colCEK_NO,
                                        colSORULDUGU_TARIH,
                                        colSORULMA_SONUCU,
                                        colKARSILIK_TUTAR_DOVIZ_ID,
                                        colKARSILIK_TUTAR,
                                        colSORAN_ID,
                                        colARKASI_YAZILDI_MI,
                                        colSERH_ACIKLAMASI,
                                        colSIKAYET_EDILDI_MI,
                                        colKESIDE_YERI,
                                        colODEME_YERI,
                                        colISLEMLER_BASLADIMI,
                                        colTARAF_CARI_ID,
                                        colTARAF_TIP_ID,
                                        colTAKIBE_KONULDU_MU,
                                    };

            #endregion []

            RepositoryItemCheckEdit check = new RepositoryItemCheckEdit();

            #region caption visible visibleIndex name  leri verildi coLumnların

            #region

            this.colEVRAK_TUR_ID.VisibleIndex = 0;
            this.colEVRAK_TUR_ID.FieldName = "EVRAK_TUR_ID";
            this.colEVRAK_TUR_ID.Name = "this.colEVRAK_TUR_ID";
            this.colEVRAK_TUR_ID.OptionsColumn.AllowEdit = false;
            this.colEVRAK_TUR_ID.OptionsColumn.ReadOnly = true;
            this.colEVRAK_TUR_ID.Visible = true;

            this.colEVRAK_KAYIT_TARIHI.VisibleIndex = 1;
            this.colEVRAK_KAYIT_TARIHI.FieldName = "EVRAK_KAYIT_TARIHI";
            this.colEVRAK_KAYIT_TARIHI.Name = "this.colEVRAK_KAYIT_TARIHI";
            this.colEVRAK_KAYIT_TARIHI.OptionsColumn.AllowEdit = false;
            this.colEVRAK_KAYIT_TARIHI.OptionsColumn.ReadOnly = true;
            this.colEVRAK_KAYIT_TARIHI.Visible = true;

            this.colEVRAK_VADE_TARIHI.VisibleIndex = 2;
            this.colEVRAK_VADE_TARIHI.FieldName = "EVRAK_VADE_TARIHI";
            this.colEVRAK_VADE_TARIHI.Name = "this.colEVRAK_VADE_TARIHI";
            this.colEVRAK_VADE_TARIHI.OptionsColumn.AllowEdit = false;
            this.colEVRAK_VADE_TARIHI.OptionsColumn.ReadOnly = true;
            this.colEVRAK_VADE_TARIHI.Visible = true;

            this.colEVRAK_TANZIM_TARIHI.VisibleIndex = 3;
            this.colEVRAK_TANZIM_TARIHI.FieldName = "EVRAK_TANZIM_TARIHI";
            this.colEVRAK_TANZIM_TARIHI.Name = "this.colEVRAK_TANZIM_TARIHI";
            this.colEVRAK_TANZIM_TARIHI.OptionsColumn.AllowEdit = false;
            this.colEVRAK_TANZIM_TARIHI.OptionsColumn.ReadOnly = true;
            this.colEVRAK_TANZIM_TARIHI.Visible = true;

            this.colTUTAR_DOVIZ_ID.VisibleIndex = 4;
            this.colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.Name = "this.colTUTAR_DOVIZ_ID";
            this.colTUTAR_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colTUTAR_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colTUTAR_DOVIZ_ID.Visible = true;

            this.colTUTAR.VisibleIndex = 5;
            this.colTUTAR.FieldName = "TUTAR";
            this.colTUTAR.Name = "colTUTAR";
            this.colTUTAR.OptionsColumn.AllowEdit = false;
            this.colTUTAR.OptionsColumn.ReadOnly = true;
            this.colTUTAR.Visible = true;

            this.colNE_SEKILDE_AHZOLUNDUGU.VisibleIndex = 6;
            this.colNE_SEKILDE_AHZOLUNDUGU.FieldName = "NE_SEKILDE_AHZOLUNDUGU";
            this.colNE_SEKILDE_AHZOLUNDUGU.Name = "this.colNE_SEKILDE_AHZOLUNDUGU";
            this.colNE_SEKILDE_AHZOLUNDUGU.OptionsColumn.AllowEdit = false;
            this.colNE_SEKILDE_AHZOLUNDUGU.OptionsColumn.ReadOnly = true;
            this.colNE_SEKILDE_AHZOLUNDUGU.Visible = true;

            // this.colNE_SEKILDE_AHZOLUNDUGU.ColumnEdit = check;

            this.colBANKA_ID.VisibleIndex = 7;
            this.colBANKA_ID.FieldName = "BANKA_ID";
            this.colBANKA_ID.Name = "this.colBANKA_ID";
            this.colBANKA_ID.OptionsColumn.AllowEdit = false;
            this.colBANKA_ID.OptionsColumn.ReadOnly = true;
            this.colBANKA_ID.Visible = true;

            this.colSUBE_ID.VisibleIndex = 8;
            this.colSUBE_ID.FieldName = "SUBE_ID";
            this.colSUBE_ID.Name = "this.colSUBE_ID";
            this.colSUBE_ID.OptionsColumn.AllowEdit = false;
            this.colSUBE_ID.OptionsColumn.ReadOnly = true;
            this.colSUBE_ID.Visible = true;

            this.colBANKA_SUBE_KODU.VisibleIndex = 9;
            this.colBANKA_SUBE_KODU.FieldName = "BANKA_SUBE_KODU";
            this.colBANKA_SUBE_KODU.Name = "this.colBANKA_SUBE_KODU";
            this.colBANKA_SUBE_KODU.OptionsColumn.AllowEdit = false;
            this.colBANKA_SUBE_KODU.OptionsColumn.ReadOnly = true;
            this.colBANKA_SUBE_KODU.Visible = true;

            this.colHESAP_NO.VisibleIndex = 10;
            this.colHESAP_NO.FieldName = "HESAP_NO";
            this.colHESAP_NO.Name = "this.colHESAP_NO";
            this.colHESAP_NO.OptionsColumn.AllowEdit = false;
            this.colHESAP_NO.OptionsColumn.ReadOnly = true;
            this.colHESAP_NO.Visible = true;

            this.colCEK_NO.VisibleIndex = 11;
            this.colCEK_NO.FieldName = "CEK_NO";
            this.colCEK_NO.Name = "this.colCEK_NO";
            this.colCEK_NO.OptionsColumn.AllowEdit = false;
            this.colCEK_NO.OptionsColumn.ReadOnly = true;
            this.colCEK_NO.Visible = true;

            this.colSORULDUGU_TARIH.VisibleIndex = 12;
            this.colSORULDUGU_TARIH.FieldName = "SORULDUGU_TARIH";
            this.colSORULDUGU_TARIH.Name = "this.colSORULDUGU_TARIH";
            this.colSORULDUGU_TARIH.OptionsColumn.AllowEdit = false;
            this.colSORULDUGU_TARIH.OptionsColumn.ReadOnly = true;
            this.colSORULDUGU_TARIH.Visible = true;

            this.colSORULMA_SONUCU.VisibleIndex = 13;
            this.colSORULMA_SONUCU.FieldName = "SORULMA_SONUCU";
            this.colSORULMA_SONUCU.Name = "this.colSORULMA_SONUCU";
            this.colSORULMA_SONUCU.Visible = true;
            this.colSORULMA_SONUCU.OptionsColumn.AllowEdit = false;
            this.colSORULMA_SONUCU.OptionsColumn.ReadOnly = true;
            this.colSORULMA_SONUCU.ColumnEdit = check;

            this.colKARSILIK_TUTAR_DOVIZ_ID.VisibleIndex = 14;
            this.colKARSILIK_TUTAR_DOVIZ_ID.FieldName = "KARSILIK_TUTAR_DOVIZ_ID";
            this.colKARSILIK_TUTAR_DOVIZ_ID.Name = "this.colKARSILIK_TUTAR_DOVIZ_ID";
            this.colKARSILIK_TUTAR_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colKARSILIK_TUTAR_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colKARSILIK_TUTAR_DOVIZ_ID.Visible = true;

            this.colKARSILIK_TUTAR.VisibleIndex = 15;
            this.colKARSILIK_TUTAR.FieldName = "KARSILIK_TUTAR";
            this.colKARSILIK_TUTAR.Name = "this.colKARSILIK_TUTAR";
            this.colKARSILIK_TUTAR.OptionsColumn.AllowEdit = false;
            this.colKARSILIK_TUTAR.OptionsColumn.ReadOnly = true;
            this.colKARSILIK_TUTAR.Visible = true;

            this.colSORAN_ID.VisibleIndex = 16;
            this.colSORAN_ID.FieldName = "SORAN_ID";
            this.colSORAN_ID.Name = "this.colSORAN_ID";
            this.colSORAN_ID.OptionsColumn.AllowEdit = false;
            this.colSORAN_ID.OptionsColumn.ReadOnly = true;
            this.colSORAN_ID.Visible = true;

            this.colARKASI_YAZILDI_MI.VisibleIndex = 17;
            this.colARKASI_YAZILDI_MI.FieldName = "ARKASI_YAZILDI_MI";
            this.colARKASI_YAZILDI_MI.Name = "this.colARKASI_YAZILDI_MI";
            this.colARKASI_YAZILDI_MI.OptionsColumn.AllowEdit = false;
            this.colARKASI_YAZILDI_MI.OptionsColumn.ReadOnly = true;
            this.colARKASI_YAZILDI_MI.Visible = true;

            this.colSERH_ACIKLAMASI.VisibleIndex = 18;
            this.colSERH_ACIKLAMASI.FieldName = "SERH_ACIKLAMASI";
            this.colSERH_ACIKLAMASI.Name = "this.colSERH_ACIKLAMASI";
            this.colSERH_ACIKLAMASI.OptionsColumn.AllowEdit = false;
            this.colSERH_ACIKLAMASI.OptionsColumn.ReadOnly = true;
            this.colSERH_ACIKLAMASI.Visible = true;

            this.colSIKAYET_EDILDI_MI.VisibleIndex = 19;
            this.colSIKAYET_EDILDI_MI.FieldName = "SIKAYET_EDILDI_MI";
            this.colSIKAYET_EDILDI_MI.Name = "this.colSIKAYET_EDILDI_MI";
            this.colSIKAYET_EDILDI_MI.OptionsColumn.AllowEdit = false;
            this.colSIKAYET_EDILDI_MI.OptionsColumn.ReadOnly = true;
            this.colSIKAYET_EDILDI_MI.Visible = true;

            this.colKESIDE_YERI.VisibleIndex = 20;
            this.colKESIDE_YERI.FieldName = "KESIDE_YERI";
            this.colKESIDE_YERI.Name = "this.colKESIDE_YERI";
            this.colKESIDE_YERI.OptionsColumn.AllowEdit = false;
            this.colKESIDE_YERI.OptionsColumn.ReadOnly = true;
            this.colKESIDE_YERI.Visible = true;

            this.colODEME_YERI.VisibleIndex = 21;
            this.colODEME_YERI.FieldName = "ODEME_YERI";
            this.colODEME_YERI.Name = "this.colODEME_YERI";
            this.colODEME_YERI.OptionsColumn.AllowEdit = false;
            this.colODEME_YERI.OptionsColumn.ReadOnly = true;
            this.colODEME_YERI.Visible = true;

            this.colISLEMLER_BASLADIMI.VisibleIndex = 22;
            this.colISLEMLER_BASLADIMI.FieldName = "ISLEMLER_BASLADIMI";
            this.colISLEMLER_BASLADIMI.Name = "this.colISLEMLER_BASLADIMI";
            this.colISLEMLER_BASLADIMI.OptionsColumn.AllowEdit = false;
            this.colISLEMLER_BASLADIMI.OptionsColumn.ReadOnly = true;
            this.colISLEMLER_BASLADIMI.Visible = true;

            this.colTARAF_CARI_ID.VisibleIndex = 23;
            this.colTARAF_CARI_ID.FieldName = "TARAF_CARI_ID";
            this.colTARAF_CARI_ID.Name = "this.colTARAF_CARI_ID";
            this.colTARAF_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colTARAF_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colTARAF_CARI_ID.Visible = true;

            this.colTARAF_TIP_ID.VisibleIndex = 24;
            this.colTARAF_TIP_ID.FieldName = "TARAF_TIP_ID";
            this.colTARAF_TIP_ID.Name = "this.colTARAF_TIP_ID";
            this.colTARAF_TIP_ID.OptionsColumn.AllowEdit = false;
            this.colTARAF_TIP_ID.OptionsColumn.ReadOnly = true;
            this.colTARAF_TIP_ID.Visible = true;

            this.colTAKIBE_KONULDU_MU.VisibleIndex = 25;
            this.colTAKIBE_KONULDU_MU.FieldName = "TAKIBE_KONULDU_MU";
            this.colTAKIBE_KONULDU_MU.Name = "this.colTAKIBE_KONULDU_MU";
            this.colTAKIBE_KONULDU_MU.OptionsColumn.AllowEdit = false;
            this.colTAKIBE_KONULDU_MU.OptionsColumn.ReadOnly = true;
            this.colTAKIBE_KONULDU_MU.Visible = true;

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region Column Caption

            Dictionary<string, string> captionlar = GetCaptionDictinory();
            Dictionary<string, RepositoryItem> editler = GetRepositoryItemDictinory();

            for (int i = 0; i < dizi.Length; i++)
            {
                string caption = string.Empty;
                if (captionlar.ContainsKey(dizi[i].FieldName))
                    caption = captionlar[dizi[i].FieldName];
                if (caption.Length > 0)
                    dizi[i].Caption = caption;
                else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
                    dizi[i].Caption = "Brm";

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].ColumnEdit = editler["DovizId"];
                }
                else if (editler.ContainsKey(dizi[i].FieldName))
                    dizi[i].ColumnEdit = editler[dizi[i].FieldName];
            }

            #endregion Column Caption

            #endregion KıymetliEvrak Gridinin Colunları oluşturuldu

            return dizi;
        }

        #endregion < TIO - 20092706 Grid Columları Oluşturuluyor >

        #region Dava Grid Columnlarının Oluşturulması

        //İcra GrdiColumları ile aynı Kullanılıyor

        #endregion Dava Grid Columnlarının Oluşturulması

        #region Belge Grid Columnlarının Oluşturulması

        //İcra GrdiColumları ile aynı Kullanılıyor

        #endregion Belge Grid Columnlarının Oluşturulması

        #region Soruşturma Grid Columnlarının Oluşturulması

        //İcra GrdiColumları ile aynı Kullanılıyor

        #endregion Soruşturma Grid Columnlarının Oluşturulması

        #region Görüşme Gridinin Columnları Oluşturılması

        private GridColumn[] GetGorusmeGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colTARIH,
                                        this.colSAAT,
                                        this.colIS_KATEGORI_ID,
                                        this.colGORUSME_YONU,
                                        this.colGORUSEN_CARI_ID,
                                        this.colGORUSEN_TEL,
                                        this.colGORUSULEN_TARAF,
                                        this.colGORUSULEN_CARI_ID,
                                        this.colGORUSULEN_TEL,
                                        this.colGORUSENIN_NOTU,
                                        this.colISIN_YAPILDIGI_CARI_ID,
                                        this.colGORUSME_SURE,
                                        this.colBITIS_TARIH,
                                        this.colBITIS_SAATI,
                                        this.colKAYIT_TARIHI,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colTARIH.Caption = "Tarih";
            this.colTARIH.Visible = true;
            this.colTARIH.OptionsColumn.AllowEdit = false;
            this.colTARIH.OptionsColumn.ReadOnly = true;
            this.colTARIH.VisibleIndex = 1;
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.FieldName = "TARIH";
            this.colSAAT.Caption = "Saat";
            this.colSAAT.Visible = true;
            this.colSAAT.OptionsColumn.AllowEdit = false;
            this.colSAAT.OptionsColumn.ReadOnly = true;
            this.colSAAT.VisibleIndex = 2;
            this.colSAAT.Name = "colSAAT";
            this.colIS_KATEGORI_ID.Caption = "İş Kategori";
            this.colIS_KATEGORI_ID.Visible = true;
            this.colIS_KATEGORI_ID.OptionsColumn.AllowEdit = false;
            this.colIS_KATEGORI_ID.OptionsColumn.ReadOnly = true;
            this.colIS_KATEGORI_ID.VisibleIndex = 3;
            this.colIS_KATEGORI_ID.Name = "colIS_KATEGORI_ID";
            this.colGORUSME_YONU.Caption = "Görüşme Yönü";
            this.colGORUSME_YONU.Visible = true;
            this.colGORUSME_YONU.OptionsColumn.AllowEdit = false;
            this.colGORUSME_YONU.OptionsColumn.ReadOnly = true;
            this.colGORUSME_YONU.VisibleIndex = 4;
            this.colGORUSEN_CARI_ID.Caption = "Görüşen";
            this.colGORUSEN_CARI_ID.Visible = true;
            this.colGORUSEN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colGORUSEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colGORUSEN_CARI_ID.VisibleIndex = 5;
            this.colGORUSEN_CARI_ID.Name = "colGORUSEN_CARI_ID";
            this.colGORUSEN_TEL.Caption = "Görüşen Tel";
            this.colGORUSEN_TEL.Visible = true;
            this.colGORUSEN_TEL.OptionsColumn.AllowEdit = false;
            this.colGORUSEN_TEL.OptionsColumn.ReadOnly = true;
            this.colGORUSEN_TEL.VisibleIndex = 6;
            this.colGORUSEN_TEL.Name = "colGORUSEN_TEL";
            this.colGORUSULEN_TARAF.Caption = "Görüşülen Taraf";
            this.colGORUSULEN_TARAF.Visible = true;
            this.colGORUSULEN_TARAF.OptionsColumn.AllowEdit = false;
            this.colGORUSULEN_TARAF.OptionsColumn.ReadOnly = true;
            this.colGORUSULEN_TARAF.VisibleIndex = 7;
            this.colGORUSULEN_TARAF.Name = "colGORUSULEN_TARAF";
            this.colGORUSULEN_CARI_ID.Caption = "Görüşülen";
            this.colGORUSULEN_CARI_ID.Visible = true;
            this.colGORUSULEN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colGORUSULEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colGORUSULEN_CARI_ID.VisibleIndex = 8;
            this.colGORUSULEN_CARI_ID.Name = "colGORUSULEN_CARI_ID";
            this.colGORUSULEN_TEL.Caption = "Görüşülen Tel";
            this.colGORUSULEN_TEL.Visible = true;
            this.colGORUSULEN_TEL.OptionsColumn.AllowEdit = false;
            this.colGORUSULEN_TEL.OptionsColumn.ReadOnly = true;
            this.colGORUSULEN_TEL.VisibleIndex = 9;
            this.colGORUSULEN_TEL.Name = "colGORUSULEN_TEL";
            this.colGORUSENIN_NOTU.Caption = "Görüşenin Notu";
            this.colGORUSENIN_NOTU.Visible = true;
            this.colGORUSENIN_NOTU.OptionsColumn.AllowEdit = false;
            this.colGORUSENIN_NOTU.OptionsColumn.ReadOnly = true;
            this.colGORUSENIN_NOTU.VisibleIndex = 10;
            this.colGORUSENIN_NOTU.Name = "colGORUSENIN_NOTU";
            this.colISIN_YAPILDIGI_CARI_ID.Caption = "İşin Yapıldığı";
            this.colISIN_YAPILDIGI_CARI_ID.Visible = true;
            this.colISIN_YAPILDIGI_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colISIN_YAPILDIGI_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colISIN_YAPILDIGI_CARI_ID.VisibleIndex = 11;
            this.colISIN_YAPILDIGI_CARI_ID.Name = "colISIN_YAPILDIGI_CARI_ID";
            this.colGORUSME_SURE.Caption = "Süre";
            this.colGORUSME_SURE.Visible = true;
            this.colGORUSME_SURE.OptionsColumn.AllowEdit = false;
            this.colGORUSME_SURE.OptionsColumn.ReadOnly = true;
            this.colGORUSME_SURE.VisibleIndex = 12;
            this.colGORUSME_SURE.Name = "colGORUSME_SURE";
            this.colBITIS_TARIH.Caption = "Bitiş T";
            this.colBITIS_TARIH.Visible = true;
            this.colBITIS_TARIH.OptionsColumn.AllowEdit = false;
            this.colBITIS_TARIH.OptionsColumn.ReadOnly = true;
            this.colBITIS_TARIH.VisibleIndex = 13;
            this.colBITIS_TARIH.Name = "colBITIS_TARIH";
            this.colBITIS_SAATI.Caption = "Bitiş Z";
            this.colBITIS_SAATI.Visible = true;
            this.colBITIS_SAATI.OptionsColumn.AllowEdit = false;
            this.colBITIS_SAATI.OptionsColumn.ReadOnly = true;
            this.colBITIS_SAATI.VisibleIndex = 14;
            this.colBITIS_SAATI.Name = "colBITIS_SAATI";
            this.colKAYIT_TARIHI.Caption = "Kayıt T";
            this.colKAYIT_TARIHI.Visible = true;
            this.colKAYIT_TARIHI.OptionsColumn.AllowEdit = false;
            this.colKAYIT_TARIHI.OptionsColumn.ReadOnly = true;
            this.colKAYIT_TARIHI.VisibleIndex = 15;
            this.colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            colTARIH.ColumnEdit = this.deTarih;
            colSAAT.ColumnEdit = this.seSaat;
            colIS_KATEGORI_ID.ColumnEdit = this.rLueIsKAtegori;
            colGORUSEN_CARI_ID.ColumnEdit = this.rLueGorusenCariID;
            colGORUSULEN_CARI_ID.ColumnEdit = this.rLueGorusenCariID;
            colISIN_YAPILDIGI_CARI_ID.ColumnEdit = this.rLueGorusenCariID;
            colBITIS_TARIH.ColumnEdit = this.deTarih;
            colBITIS_SAATI.ColumnEdit = this.seSaat;
            GorusmeLookUpDoldur();

            #endregion <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Görüşme Gridinin Columnları Oluşturılması

        #region Mail Grdinin Columnlarının Oluşturulması

        private GridColumn[] GetMailGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colMESAJ_TIP,
                                        this.colKONU,
                                        this.colGONDEREN_CARI_ID,
                                        this.colGONDERILENLER,
                                        this.colCC,
                                        this.colBCC,
                                        this.colICERIK,
                                        this.colGONDERIM_ZAMANI,
                                        this.colONEMSIZ_POSTA_MI,
                                        this.colOKUNDU_MU,
                                        this.colBASARILI_MI,
                                        this.colYILDIZLI_MI,
                                        this.colDISARIDAN_MI,
                                        this.colGELEN_MI,
                                        this.colGIDEN_MI,
                                        this.colSILINDI_MI,
                                        this.colONAYLANDI_MI,
                                        this.colTASLAK_MI,
                                        this.colREFERANS_NO,
                                        this.kolKAYIT_TARIHI,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colMESAJ_TIP.Caption = "Mesaj Tipi";
            this.colMESAJ_TIP.Visible = true;
            this.colMESAJ_TIP.OptionsColumn.AllowEdit = false;
            this.colMESAJ_TIP.OptionsColumn.ReadOnly = true;
            this.colMESAJ_TIP.VisibleIndex = 1;
            this.colMESAJ_TIP.Name = "colMESAJ_TIP";
            this.colMESAJ_TIP.FieldName = "MESAJ_TIP";
            this.colKONU.Caption = "Konu";
            this.colKONU.Visible = true;
            this.colKONU.OptionsColumn.AllowEdit = false;
            this.colKONU.OptionsColumn.ReadOnly = true;
            this.colKONU.VisibleIndex = 2;
            this.colKONU.Name = "colKONU";
            this.colGONDEREN_CARI_ID.Caption = "Gönderen";
            this.colGONDEREN_CARI_ID.Visible = true;
            this.colGONDEREN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colGONDEREN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colGONDEREN_CARI_ID.VisibleIndex = 3;
            this.colGONDEREN_CARI_ID.Name = "colGONDEREN_CARI_ID";
            this.colGONDERILENLER.Caption = "Gönderilenler";
            this.colGONDERILENLER.Visible = true;
            this.colGONDERILENLER.OptionsColumn.AllowEdit = false;
            this.colGONDERILENLER.OptionsColumn.ReadOnly = true;
            this.colGONDERILENLER.VisibleIndex = 4;
            this.colGONDERILENLER.Name = "colGONDERILENLER";
            this.colCC.Caption = "CC";
            this.colCC.Visible = true;
            this.colCC.OptionsColumn.AllowEdit = false;
            this.colCC.OptionsColumn.ReadOnly = true;
            this.colCC.VisibleIndex = 5;
            this.colCC.Name = "colCC";
            this.colBCC.Caption = "BCC";
            this.colBCC.Visible = true;
            this.colBCC.OptionsColumn.AllowEdit = false;
            this.colBCC.OptionsColumn.ReadOnly = true;
            this.colBCC.VisibleIndex = 6;
            this.colBCC.Name = "colBCC";
            this.colICERIK.Caption = "İçerik";
            this.colICERIK.Visible = true;
            this.colICERIK.OptionsColumn.AllowEdit = false;
            this.colICERIK.OptionsColumn.ReadOnly = true;
            this.colICERIK.VisibleIndex = 7;
            this.colICERIK.Name = "colICERIK";
            this.colGONDERIM_ZAMANI.Caption = "Gönderim Zamanı";
            this.colGONDERIM_ZAMANI.Visible = true;
            this.colGONDERIM_ZAMANI.OptionsColumn.AllowEdit = false;
            this.colGONDERIM_ZAMANI.OptionsColumn.ReadOnly = true;
            this.colGONDERIM_ZAMANI.VisibleIndex = 8;
            this.colGONDERIM_ZAMANI.Name = "colGONDERIM_ZAMANI";
            this.colONEMSIZ_POSTA_MI.Caption = "Önemsiz";
            this.colONEMSIZ_POSTA_MI.Visible = true;
            this.colONEMSIZ_POSTA_MI.OptionsColumn.AllowEdit = false;
            this.colONEMSIZ_POSTA_MI.OptionsColumn.ReadOnly = true;
            this.colONEMSIZ_POSTA_MI.VisibleIndex = 9;
            this.colONEMSIZ_POSTA_MI.Name = "colONEMSIZ_POSTA_MI";
            this.colOKUNDU_MU.Caption = "Okundu mu";
            this.colOKUNDU_MU.Visible = true;
            this.colOKUNDU_MU.OptionsColumn.AllowEdit = false;
            this.colOKUNDU_MU.OptionsColumn.ReadOnly = true;
            this.colOKUNDU_MU.VisibleIndex = 10;
            this.colOKUNDU_MU.Name = "colOKUNDU_MU";
            this.colBASARILI_MI.Caption = "Başarılı mı";
            this.colBASARILI_MI.Visible = true;
            this.colBASARILI_MI.OptionsColumn.AllowEdit = false;
            this.colBASARILI_MI.OptionsColumn.ReadOnly = true;
            this.colBASARILI_MI.VisibleIndex = 11;
            this.colBASARILI_MI.Name = "colBASARILI_MI";
            this.colYILDIZLI_MI.Caption = "Yıldızlı mı";
            this.colYILDIZLI_MI.Visible = true;
            this.colYILDIZLI_MI.OptionsColumn.AllowEdit = false;
            this.colYILDIZLI_MI.OptionsColumn.ReadOnly = true;
            this.colYILDIZLI_MI.VisibleIndex = 12;
            this.colYILDIZLI_MI.Name = "colYILDIZLI_MI";
            this.colDISARIDAN_MI.Caption = "Dışarıdan mı";
            this.colDISARIDAN_MI.Visible = true;
            this.colDISARIDAN_MI.OptionsColumn.AllowEdit = false;
            this.colDISARIDAN_MI.OptionsColumn.ReadOnly = true;
            this.colDISARIDAN_MI.VisibleIndex = 13;
            this.colDISARIDAN_MI.Name = "colDISARIDAN_MI";
            this.colGELEN_MI.Caption = "Gelen mi";
            this.colGELEN_MI.Visible = true;
            this.colGELEN_MI.OptionsColumn.AllowEdit = false;
            this.colGELEN_MI.OptionsColumn.ReadOnly = true;
            this.colGELEN_MI.VisibleIndex = 14;
            this.colGELEN_MI.Name = "colGELEN_MI";
            this.colGIDEN_MI.Caption = "Giden mi";
            this.colGIDEN_MI.Visible = true;
            this.colGIDEN_MI.OptionsColumn.AllowEdit = false;
            this.colGIDEN_MI.OptionsColumn.ReadOnly = true;
            this.colGIDEN_MI.VisibleIndex = 15;
            this.colGIDEN_MI.Name = "colGIDEN_MI";
            this.colSILINDI_MI.Caption = "Silindi mi";
            this.colSILINDI_MI.Visible = true;
            this.colSILINDI_MI.OptionsColumn.AllowEdit = false;
            this.colSILINDI_MI.OptionsColumn.ReadOnly = true;
            this.colSILINDI_MI.VisibleIndex = 16;
            this.colSILINDI_MI.Name = "colSILINDI_MI";
            this.colONAYLANDI_MI.Caption = "Onaylandı mı";
            this.colONAYLANDI_MI.Visible = true;
            this.colONAYLANDI_MI.OptionsColumn.AllowEdit = false;
            this.colONAYLANDI_MI.OptionsColumn.ReadOnly = true;
            this.colONAYLANDI_MI.VisibleIndex = 17;
            this.colONAYLANDI_MI.Name = "colONAYLANDI_MI";
            this.colTASLAK_MI.Caption = "Taslak mı";
            this.colTASLAK_MI.Visible = true;
            this.colTASLAK_MI.OptionsColumn.AllowEdit = false;
            this.colTASLAK_MI.OptionsColumn.ReadOnly = true;
            this.colTASLAK_MI.VisibleIndex = 18;
            this.colTASLAK_MI.Name = "colTASLAK_MI";
            this.colREFERANS_NO.Caption = "Ref. No";
            this.colREFERANS_NO.Visible = true;
            this.colREFERANS_NO.OptionsColumn.AllowEdit = false;
            this.colREFERANS_NO.OptionsColumn.ReadOnly = true;
            this.colREFERANS_NO.VisibleIndex = 19;
            this.colREFERANS_NO.Name = "colREFERANS_NO";
            this.kolKAYIT_TARIHI.Caption = "Kayıt T";
            this.kolKAYIT_TARIHI.Visible = true;
            this.kolKAYIT_TARIHI.OptionsColumn.AllowEdit = false;
            this.kolKAYIT_TARIHI.OptionsColumn.ReadOnly = true;
            this.kolKAYIT_TARIHI.VisibleIndex = 20;
            this.kolKAYIT_TARIHI.Name = "kolKAYIT_TARIHI";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            colMESAJ_TIP.ColumnEdit = this.rLueMesajTip;
            colGONDEREN_CARI_ID.ColumnEdit = this.rLueMesajGonderenCARI;
            colOKUNDU_MU.ColumnEdit = this.chkOkundumu;
            colONAYLANDI_MI.ColumnEdit = this.chkOkundumu;
            colONEMSIZ_POSTA_MI.ColumnEdit = this.chkOkundumu;
            colBASARILI_MI.ColumnEdit = this.chkOkundumu;
            colYILDIZLI_MI.ColumnEdit = this.chkOkundumu;
            colDISARIDAN_MI.ColumnEdit = this.chkOkundumu;
            colGELEN_MI.ColumnEdit = this.chkOkundumu;
            colGIDEN_MI.ColumnEdit = this.chkOkundumu;
            colSILINDI_MI.ColumnEdit = this.chkOkundumu;
            colONAYLANDI_MI.ColumnEdit = this.chkOkundumu;
            colTASLAK_MI.ColumnEdit = this.chkOkundumu;
            kolKAYIT_TARIHI.ColumnEdit = this.deKayitT;
            MailLookUpDoldur();

            #endregion <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Mail Grdinin Columnlarının Oluşturulması

        #region SMS Gridinin Columnlarının Oluşturulması

        private GridColumn[] GetSmsGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colNUMARA_KAYNAK,
                                        this.colFIRMA_TABLO_KOD,
                                        this.colCARI_ID,
                                        this.colNUMARA,
                                        this.colAKTIFLESME_TARIHI,
                                        this.colPASIFLESME_TARIHI,
                                        this.colSON_GONDERIM_ZAMANI,
                                        this.colGONDERIM_SAYISI,
                                        this.colDURUM_ID,
                                        this.colGSM_OP_RAPOR_TARIHI,
                                        this.colGSM_OP_RAPOR_DURUM,
                                        this.colGSM_XML_SATIR_NO,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colNUMARA_KAYNAK.Caption = "Num. Kaynak";
            this.colNUMARA_KAYNAK.Visible = true;
            this.colNUMARA_KAYNAK.OptionsColumn.AllowEdit = false;
            this.colNUMARA_KAYNAK.OptionsColumn.ReadOnly = true;
            this.colNUMARA_KAYNAK.VisibleIndex = 1;
            this.colNUMARA_KAYNAK.Name = "colNUMARA_KAYNAK";
            this.colNUMARA_KAYNAK.FieldName = "NUMARA_KAYNAK";
            this.colFIRMA_TABLO_KOD.Caption = "Tablo Kodu";
            this.colFIRMA_TABLO_KOD.Visible = true;
            this.colFIRMA_TABLO_KOD.OptionsColumn.AllowEdit = false;
            this.colFIRMA_TABLO_KOD.OptionsColumn.ReadOnly = true;
            this.colFIRMA_TABLO_KOD.VisibleIndex = 2;
            this.colFIRMA_TABLO_KOD.Name = "colFIRMA_TABLO_KOD";
            this.colFIRMA_TABLO_KOD.FieldName = "FIRMA_TABLO_KOD";
            this.colCARI_ID.Caption = "Cari";
            this.colCARI_ID.Visible = true;
            this.colCARI_ID.OptionsColumn.AllowEdit = false;
            this.colCARI_ID.OptionsColumn.ReadOnly = true;
            this.colCARI_ID.VisibleIndex = 3;
            this.colCARI_ID.Name = "colCARI_ID";
            this.colCARI_ID.FieldName = "CARI_ID";
            this.colNUMARA.Caption = "Numara";
            this.colNUMARA.Visible = true;
            this.colNUMARA.OptionsColumn.AllowEdit = false;
            this.colNUMARA.OptionsColumn.ReadOnly = true;
            this.colNUMARA.VisibleIndex = 4;
            this.colNUMARA.Name = "colNUMARA";
            this.colNUMARA.FieldName = "NUMARA";
            this.colAKTIFLESME_TARIHI.Caption = "Aktifleşme T";
            this.colAKTIFLESME_TARIHI.Visible = true;
            this.colAKTIFLESME_TARIHI.OptionsColumn.AllowEdit = false;
            this.colAKTIFLESME_TARIHI.OptionsColumn.ReadOnly = true;
            this.colAKTIFLESME_TARIHI.VisibleIndex = 5;
            this.colAKTIFLESME_TARIHI.Name = "colAKTIFLESME_TARIHI";
            this.colAKTIFLESME_TARIHI.FieldName = "AKTIFLESME_TARIHI";
            this.colPASIFLESME_TARIHI.Caption = "Pasifleştirme T";
            this.colPASIFLESME_TARIHI.Visible = true;
            this.colPASIFLESME_TARIHI.OptionsColumn.AllowEdit = false;
            this.colPASIFLESME_TARIHI.OptionsColumn.ReadOnly = true;
            this.colPASIFLESME_TARIHI.VisibleIndex = 6;
            this.colPASIFLESME_TARIHI.Name = "colPASIFLESME_TARIHI";
            this.colPASIFLESME_TARIHI.FieldName = "PASIFLESME_TARIHI";
            this.colSON_GONDERIM_ZAMANI.Caption = "Son Gönderim Z";
            this.colSON_GONDERIM_ZAMANI.Visible = true;
            this.colSON_GONDERIM_ZAMANI.OptionsColumn.AllowEdit = false;
            this.colSON_GONDERIM_ZAMANI.OptionsColumn.ReadOnly = true;
            this.colSON_GONDERIM_ZAMANI.VisibleIndex = 7;
            this.colSON_GONDERIM_ZAMANI.Name = "colSON_GONDERIM_ZAMANI";
            this.colSON_GONDERIM_ZAMANI.FieldName = "SON_GONDERIM_ZAMANI";
            this.colDURUM_ID.Caption = "Durum";
            this.colDURUM_ID.Visible = true;
            this.colDURUM_ID.OptionsColumn.AllowEdit = false;
            this.colDURUM_ID.OptionsColumn.ReadOnly = true;
            this.colDURUM_ID.VisibleIndex = 8;
            this.colDURUM_ID.Name = "colDURUM_ID";
            this.colDURUM_ID.FieldName = "DURUM_ID";
            this.colGSM_OP_RAPOR_TARIHI.Caption = "GSM Op. Rapor T";
            this.colGSM_OP_RAPOR_TARIHI.Visible = true;
            this.colGSM_OP_RAPOR_TARIHI.OptionsColumn.AllowEdit = false;
            this.colGSM_OP_RAPOR_TARIHI.OptionsColumn.ReadOnly = true;
            this.colGSM_OP_RAPOR_TARIHI.VisibleIndex = 9;
            this.colGSM_OP_RAPOR_TARIHI.Name = "colGSM_OP_RAPOR_TARIHI";
            this.colGSM_OP_RAPOR_TARIHI.FieldName = "GSM_OP_RAPOR_TARIHI";
            this.colGSM_OP_RAPOR_DURUM.Caption = "GSM Op. Durum";
            this.colGSM_OP_RAPOR_DURUM.Visible = true;
            this.colGSM_OP_RAPOR_DURUM.OptionsColumn.AllowEdit = false;
            this.colGSM_OP_RAPOR_DURUM.OptionsColumn.ReadOnly = true;
            this.colGSM_OP_RAPOR_DURUM.VisibleIndex = 10;
            this.colGSM_OP_RAPOR_DURUM.Name = "colGSM_OP_RAPOR_DURUM";
            this.colGSM_OP_RAPOR_DURUM.FieldName = "GSM_OP_RAPOR_DURUM";
            this.colGSM_XML_SATIR_NO.Caption = "XML Satır No";
            this.colGSM_XML_SATIR_NO.Visible = true;
            this.colGSM_XML_SATIR_NO.OptionsColumn.AllowEdit = false;
            this.colGSM_XML_SATIR_NO.OptionsColumn.ReadOnly = true;
            this.colGSM_XML_SATIR_NO.VisibleIndex = 11;
            this.colGSM_XML_SATIR_NO.Name = "colGSM_XML_SATIR_NO";
            this.colGSM_XML_SATIR_NO.FieldName = "GSM_XML_SATIR_NO";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            colCARI_ID.ColumnEdit = this.rLueCariID;
            colDURUM_ID.ColumnEdit = this.rLueSMSDurum;
            colAKTIFLESME_TARIHI.ColumnEdit = this.deGSMRaporT;
            colPASIFLESME_TARIHI.ColumnEdit = this.deGSMRaporT;
            colSON_GONDERIM_ZAMANI.ColumnEdit = this.seGonderimZaman;
            colGONDERIM_SAYISI.ColumnEdit = this.seGonderimZaman;
            colGSM_OP_RAPOR_TARIHI.ColumnEdit = this.deGSMRaporT;
            SMSLookUpDoldur();

            #endregion <TIO - 20092906 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion SMS Gridinin Columnlarının Oluşturulması

        #region Yapılcak İş Gridinin Columnlarının Oluşturulması

        private GridColumn[] GetYapilcakIsGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colKATEGORI_ID,
                                        this.colYAPILACAK_IS,
                                        this.colISADLI_BIRIM_ADLIYE_ID,
                                        this.colISADLI_BIRIM_GOREV_ID,
                                        this.colISADLI_BIRIM_NO_ID,
                                        this.colDURUM,
                                        this.colBITIS_TARIHI,
                                        this.colBASLANGIC_TARIHI,
                                        this.colONGORULEN_BITIS_TARIHI,
                                        this.colONGORULEN_BITIS_ZAMANI,
                                        this.colYER,
                                        this.colISKONU,
                                        this.colISACIKLAMA,
                                        this.colTARAFLAR,
                                        this.colIS_NO,
                                        this.colISESAS_NO,
                                        this.colISREFERANS_NO,
                                        this.colONCELIK_ID,
                                        this.colKOSUL,
                                        this.colISCariID,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colKATEGORI_ID.Caption = "İş Kat.";
            this.colKATEGORI_ID.Visible = true;
            this.colKATEGORI_ID.OptionsColumn.AllowEdit = false;
            this.colKATEGORI_ID.OptionsColumn.ReadOnly = true;
            this.colKATEGORI_ID.VisibleIndex = 1;
            this.colKATEGORI_ID.Name = "colKATEGORI_ID";
            this.colKATEGORI_ID.FieldName = "KATEGORI_ID";
            this.colYAPILACAK_IS.Caption = "Yapılcak İş";
            this.colYAPILACAK_IS.Visible = true;
            this.colYAPILACAK_IS.OptionsColumn.AllowEdit = false;
            this.colYAPILACAK_IS.OptionsColumn.ReadOnly = true;
            this.colYAPILACAK_IS.VisibleIndex = 2;
            this.colYAPILACAK_IS.Name = "colYAPILACAK_IS";
            this.colYAPILACAK_IS.FieldName = "YAPILACAK_IS";
            this.colISADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colISADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colISADLI_BIRIM_ADLIYE_ID.OptionsColumn.AllowEdit = false;
            this.colISADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colISADLI_BIRIM_ADLIYE_ID.VisibleIndex = 3;
            this.colISADLI_BIRIM_ADLIYE_ID.Name = "colISADLI_BIRIM_ADLIYE_ID";
            this.colISADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colISADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colISADLI_BIRIM_GOREV_ID.Visible = true;
            this.colISADLI_BIRIM_GOREV_ID.OptionsColumn.AllowEdit = false;
            this.colISADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colISADLI_BIRIM_GOREV_ID.VisibleIndex = 4;
            this.colISADLI_BIRIM_GOREV_ID.Name = "colISADLI_BIRIM_GOREV_ID";
            this.colISADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colISADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colISADLI_BIRIM_NO_ID.Visible = true;
            this.colISADLI_BIRIM_NO_ID.OptionsColumn.AllowEdit = false;
            this.colISADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colISADLI_BIRIM_NO_ID.VisibleIndex = 5;
            this.colISADLI_BIRIM_NO_ID.Name = "colISADLI_BIRIM_NO_ID";
            this.colISADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colDURUM.Caption = "Durum";
            this.colDURUM.Visible = true;
            this.colDURUM.OptionsColumn.AllowEdit = false;
            this.colDURUM.OptionsColumn.ReadOnly = true;
            this.colDURUM.VisibleIndex = 6;
            this.colDURUM.Name = "colDURUM";
            this.colDURUM.FieldName = "DURUM";
            this.colBITIS_TARIHI.Caption = "Bitiş T";
            this.colBITIS_TARIHI.Visible = true;
            this.colBITIS_TARIHI.OptionsColumn.AllowEdit = false;
            this.colBITIS_TARIHI.OptionsColumn.ReadOnly = true;
            this.colBITIS_TARIHI.VisibleIndex = 7;
            this.colBITIS_TARIHI.Name = "colBITIS_TARIHI";
            this.colBITIS_TARIHI.FieldName = "BITIS_TARIHI";
            this.colBASLANGIC_TARIHI.Caption = "Baş. T";
            this.colBASLANGIC_TARIHI.Visible = true;
            this.colBASLANGIC_TARIHI.OptionsColumn.AllowEdit = false;
            this.colBASLANGIC_TARIHI.OptionsColumn.ReadOnly = true;
            this.colBASLANGIC_TARIHI.VisibleIndex = 8;
            this.colBASLANGIC_TARIHI.Name = "colBASLANGIC_TARIHI";
            this.colBASLANGIC_TARIHI.FieldName = "BASLANGIC_TARIHI";
            this.colONGORULEN_BITIS_TARIHI.Caption = "Öngörülen Bit. T";
            this.colONGORULEN_BITIS_TARIHI.Visible = true;
            this.colONGORULEN_BITIS_TARIHI.OptionsColumn.AllowEdit = false;
            this.colONGORULEN_BITIS_TARIHI.OptionsColumn.ReadOnly = true;
            this.colONGORULEN_BITIS_TARIHI.VisibleIndex = 9;
            this.colONGORULEN_BITIS_TARIHI.Name = "colONGORULEN_BITIS_TARIHI";
            this.colONGORULEN_BITIS_TARIHI.FieldName = "ONGORULEN_BITIS_TARIHI";
            this.colONGORULEN_BITIS_ZAMANI.Caption = "Öngörülen Bit. Z";
            this.colONGORULEN_BITIS_ZAMANI.Visible = true;
            this.colONGORULEN_BITIS_ZAMANI.OptionsColumn.AllowEdit = false;
            this.colONGORULEN_BITIS_ZAMANI.OptionsColumn.ReadOnly = true;
            this.colONGORULEN_BITIS_ZAMANI.VisibleIndex = 10;
            this.colONGORULEN_BITIS_ZAMANI.Name = "colONGORULEN_BITIS_ZAMANI";
            this.colONGORULEN_BITIS_ZAMANI.FieldName = "ONGORULEN_BITIS_ZAMANI";
            this.colYER.Caption = "Yer";
            this.colYER.Visible = true;
            this.colYER.OptionsColumn.AllowEdit = false;
            this.colYER.OptionsColumn.ReadOnly = true;
            this.colYER.VisibleIndex = 11;
            this.colYER.Name = "colYER";
            this.colYER.FieldName = "YER";
            this.colISKONU.Caption = "Konu";
            this.colISKONU.Visible = true;
            this.colISKONU.OptionsColumn.AllowEdit = false;
            this.colISKONU.OptionsColumn.ReadOnly = true;
            this.colISKONU.VisibleIndex = 12;
            this.colISKONU.Name = "colISKONU";
            this.colISKONU.FieldName = "KONU";
            this.colISACIKLAMA.Caption = "Açıklama";
            this.colISACIKLAMA.Visible = true;
            this.colISACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colISACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colISACIKLAMA.VisibleIndex = 13;
            this.colISACIKLAMA.Name = "colISACIKLAMA";
            this.colISACIKLAMA.FieldName = "ACIKLAMA";
            this.colTARAFLAR.Caption = "Taraflar";
            this.colTARAFLAR.Visible = true;
            this.colTARAFLAR.OptionsColumn.AllowEdit = false;
            this.colTARAFLAR.OptionsColumn.ReadOnly = true;
            this.colTARAFLAR.VisibleIndex = 14;
            this.colTARAFLAR.Name = "colTARAFLAR";
            this.colTARAFLAR.FieldName = "TARAFLAR";
            this.colIS_NO.Caption = "İş No";
            this.colIS_NO.Visible = true;
            this.colIS_NO.OptionsColumn.AllowEdit = false;
            this.colIS_NO.OptionsColumn.ReadOnly = true;
            this.colIS_NO.VisibleIndex = 15;
            this.colIS_NO.Name = "colIS_NO";
            this.colIS_NO.FieldName = "IS_NO";
            this.colISESAS_NO.Caption = "Esas No";
            this.colISESAS_NO.Visible = true;
            this.colISESAS_NO.OptionsColumn.AllowEdit = false;
            this.colISESAS_NO.OptionsColumn.ReadOnly = true;
            this.colISESAS_NO.VisibleIndex = 16;
            this.colISESAS_NO.Name = "colISESAS_NO";
            this.colISESAS_NO.FieldName = "ESAS_NO";
            this.colISREFERANS_NO.Caption = "REf. No";
            this.colISREFERANS_NO.Visible = true;
            this.colISREFERANS_NO.OptionsColumn.AllowEdit = false;
            this.colISREFERANS_NO.OptionsColumn.ReadOnly = true;
            this.colISREFERANS_NO.VisibleIndex = 17;
            this.colISREFERANS_NO.Name = "colISREFERANS_NO";
            this.colISREFERANS_NO.FieldName = "REFERANS_NO";
            this.colONCELIK_ID.Caption = "Öncelik";
            this.colONCELIK_ID.Visible = true;
            this.colONCELIK_ID.OptionsColumn.AllowEdit = false;
            this.colONCELIK_ID.OptionsColumn.ReadOnly = true;
            this.colONCELIK_ID.VisibleIndex = 18;
            this.colONCELIK_ID.Name = "colONCELIK_ID";
            this.colONCELIK_ID.FieldName = "ONCELIK_ID";
            this.colKOSUL.Caption = "Koşul";
            this.colKOSUL.Visible = true;
            this.colKOSUL.OptionsColumn.AllowEdit = false;
            this.colKOSUL.OptionsColumn.ReadOnly = true;
            this.colKOSUL.VisibleIndex = 20;
            this.colKOSUL.Name = "colKOSUL";
            this.colKOSUL.FieldName = "KOSUL";
            this.colISCariID.Caption = "İşin Tarafı";
            this.colISCariID.Visible = true;
            this.colISCariID.OptionsColumn.AllowEdit = false;
            this.colISCariID.OptionsColumn.ReadOnly = true;
            this.colISCariID.VisibleIndex = 21;
            this.colISCariID.Name = "colISCariID";
            this.colISCariID.FieldName = "CARI_ID";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            colKATEGORI_ID.ColumnEdit = this.rLueIsKategoriID;
            colISADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueISAdlibirimAdliye;
            colISADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueISAdliBirimGorev;
            colISADLI_BIRIM_NO_ID.ColumnEdit = this.rLueISADliBirimNo;
            colBITIS_TARIHI.ColumnEdit = this.deISBitTarih;
            colBASLANGIC_TARIHI.ColumnEdit = this.deISBitTarih;
            colONGORULEN_BITIS_ZAMANI.ColumnEdit = this.seISBitZaman;
            colONCELIK_ID.ColumnEdit = this.rLueISOncelikID;
            colISCariID.ColumnEdit = this.rLueISCariID;

            YapilcakIsLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Yapılcak İş Gridinin Columnlarının Oluşturulması

        #region Tüm Mallar ( Borçlu Mal ) Gridinin Columlarının Oluşturulması

        private GridColumn[] GetBorcluMalGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colMAL_SIRA_NO,
                                        this.colHACIZLI_MAL_KATEGORI_ID,
                                        this.colHACIZLI_MAL_TUR_ID,
                                        this.colHACIZLI_MAL_CINS_ID,
                                        this.colHACIZLI_MAL_DEGERI,
                                        this.colHACIZLI_MAL_DEGERI_DOVIZ_ID,
                                        this.colHACIZLI_MAL_ADEDI,
                                        this.colHACIZLI_MAL_ADET_BIRIM_ID,
                                        this.colUCUNCU_SAHISTA_MI,
                                        this.colUCUNCU_SAHIS_CARI_ID,
                                        this.colMALIN_ADRESI,
                                        this.colMalCARI_ID,
                                        this.colMalESAS_NO,
                                        this.colADLI_BIRIM_NO_ID,
                                        this.colADLI_BIRIM_GOREV_ID,
                                        this.colADLI_BIRIM_ADLIYE_ID,
                                        this.colMAL_ADRES,
                                        this.colHACIZLI_MAL_ACIKLAMASI,
                                        this.colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR,
                                        this.colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID,
                                        this.colHACIZLI_MAL_NEVI,
                                        this.colHACIZLI_MAL_MARKASI,
                                        this.colHACIZLI_MAL_OZELLIKLERI,
                                        this.colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI,
                                        this.colHACIZ_ISLEM_DURUM_ID,
                                        this.colISTIHKAK_IDDIASI_VAR_MI,
                                        this.colPARAYA_CEVRILDI_MI,
                                        this.colYEDIEMIN_CARI_ID,
                                        this.colALACAKLI_RIZASI_VAR_MI,
                                        this.colARAC_PLAKA_NO,
                                        this.colMALTIP,
                                        this.colEKSPERTIZ_DEGERI,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colMAL_SIRA_NO.Caption = "Sıra No";
            this.colMAL_SIRA_NO.Visible = true;
            this.colMAL_SIRA_NO.OptionsColumn.AllowEdit = false;
            this.colMAL_SIRA_NO.OptionsColumn.ReadOnly = true;
            this.colMAL_SIRA_NO.VisibleIndex = 1;
            this.colMAL_SIRA_NO.Name = "colMAL_SIRA_NO";
            this.colMAL_SIRA_NO.FieldName = "MAL_SIRA_NO";
            this.colHACIZLI_MAL_KATEGORI_ID.Caption = "Mal Kat.";
            this.colHACIZLI_MAL_KATEGORI_ID.Visible = true;
            this.colHACIZLI_MAL_KATEGORI_ID.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_KATEGORI_ID.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_KATEGORI_ID.VisibleIndex = 2;
            this.colHACIZLI_MAL_KATEGORI_ID.Name = "colHACIZLI_MAL_KATEGORI_ID";
            this.colHACIZLI_MAL_KATEGORI_ID.FieldName = "HACIZLI_MAL_KATEGORI_ID";
            this.colHACIZLI_MAL_TUR_ID.Caption = "Mal Tür";
            this.colHACIZLI_MAL_TUR_ID.Visible = true;
            this.colHACIZLI_MAL_TUR_ID.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_TUR_ID.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_TUR_ID.VisibleIndex = 3;
            this.colHACIZLI_MAL_TUR_ID.Name = "colHACIZLI_MAL_TUR_ID";
            this.colHACIZLI_MAL_TUR_ID.FieldName = "HACIZLI_MAL_TUR_ID";
            this.colHACIZLI_MAL_CINS_ID.Caption = "Mal Cins";
            this.colHACIZLI_MAL_CINS_ID.Visible = true;
            this.colHACIZLI_MAL_CINS_ID.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_CINS_ID.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_CINS_ID.VisibleIndex = 4;
            this.colHACIZLI_MAL_CINS_ID.Name = "colHACIZLI_MAL_CINS_ID";
            this.colHACIZLI_MAL_CINS_ID.FieldName = "HACIZLI_MAL_CINS_ID";
            this.colHACIZLI_MAL_DEGERI.Caption = "Mal Değeri";
            this.colHACIZLI_MAL_DEGERI.Visible = true;
            this.colHACIZLI_MAL_DEGERI.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_DEGERI.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_DEGERI.VisibleIndex = 5;
            this.colHACIZLI_MAL_DEGERI.Name = "colHACIZLI_MAL_DEGERI";
            this.colHACIZLI_MAL_DEGERI.FieldName = "HACIZLI_MAL_DEGERI";
            this.colHACIZLI_MAL_DEGERI_DOVIZ_ID.Caption = "Mal Değeri BRM";
            this.colHACIZLI_MAL_DEGERI_DOVIZ_ID.Visible = true;
            this.colHACIZLI_MAL_DEGERI_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_DEGERI_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_DEGERI_DOVIZ_ID.VisibleIndex = 6;
            this.colHACIZLI_MAL_DEGERI_DOVIZ_ID.Name = "colHACIZLI_MAL_DEGERI_DOVIZ_ID";
            this.colHACIZLI_MAL_DEGERI_DOVIZ_ID.FieldName = "HACIZLI_MAL_DEGERI_DOVIZ_ID";
            this.colHACIZLI_MAL_ADEDI.Caption = "Adet";
            this.colHACIZLI_MAL_ADEDI.Visible = true;
            this.colHACIZLI_MAL_ADEDI.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_ADEDI.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_ADEDI.VisibleIndex = 7;
            this.colHACIZLI_MAL_ADEDI.Name = "colHACIZLI_MAL_ADEDI";
            this.colHACIZLI_MAL_ADEDI.FieldName = "HACIZLI_MAL_ADEDI";
            this.colHACIZLI_MAL_ADET_BIRIM_ID.Caption = "Birim Kod";
            this.colHACIZLI_MAL_ADET_BIRIM_ID.Visible = true;
            this.colHACIZLI_MAL_ADET_BIRIM_ID.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_ADET_BIRIM_ID.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_ADET_BIRIM_ID.VisibleIndex = 8;
            this.colHACIZLI_MAL_ADET_BIRIM_ID.Name = "colHACIZLI_MAL_ADET_BIRIM_ID";
            this.colHACIZLI_MAL_ADET_BIRIM_ID.FieldName = "HACIZLI_MAL_ADET_BIRIM_ID";
            this.colUCUNCU_SAHISTA_MI.Caption = "3. Şahıstamı";
            this.colUCUNCU_SAHISTA_MI.Visible = true;
            this.colUCUNCU_SAHISTA_MI.OptionsColumn.AllowEdit = false;
            this.colUCUNCU_SAHISTA_MI.OptionsColumn.ReadOnly = true;
            this.colUCUNCU_SAHISTA_MI.VisibleIndex = 9;
            this.colUCUNCU_SAHISTA_MI.Name = "colUCUNCU_SAHISTA_MI";
            this.colUCUNCU_SAHISTA_MI.FieldName = "UCUNCU_SAHISTA_MI";
            this.colUCUNCU_SAHIS_CARI_ID.Caption = "3. Şahıs";
            this.colUCUNCU_SAHIS_CARI_ID.Visible = true;
            this.colUCUNCU_SAHIS_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colUCUNCU_SAHIS_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colUCUNCU_SAHIS_CARI_ID.VisibleIndex = 10;
            this.colUCUNCU_SAHIS_CARI_ID.Name = "colUCUNCU_SAHIS_CARI_ID";
            this.colUCUNCU_SAHIS_CARI_ID.FieldName = "UCUNCU_SAHIS_CARI_ID";
            this.colMALIN_ADRESI.Caption = "Adresi";
            this.colMALIN_ADRESI.Visible = true;
            this.colMALIN_ADRESI.OptionsColumn.AllowEdit = false;
            this.colMALIN_ADRESI.OptionsColumn.ReadOnly = true;
            this.colMALIN_ADRESI.VisibleIndex = 11;
            this.colMALIN_ADRESI.Name = "colMALIN_ADRESI";
            this.colMALIN_ADRESI.FieldName = "MALIN_ADRESI";
            this.colMalCARI_ID.Caption = "Şahıs";
            this.colMalCARI_ID.Visible = true;
            this.colMalCARI_ID.OptionsColumn.AllowEdit = false;
            this.colMalCARI_ID.OptionsColumn.ReadOnly = true;
            this.colMalCARI_ID.VisibleIndex = 12;
            this.colMalCARI_ID.Name = "colMalCARI_ID";
            this.colMalCARI_ID.FieldName = "CARI_ID";
            this.colMalESAS_NO.Caption = "Esas No";
            this.colMalESAS_NO.Visible = true;
            this.colMalESAS_NO.OptionsColumn.AllowEdit = false;
            this.colMalESAS_NO.OptionsColumn.ReadOnly = true;
            this.colMalESAS_NO.VisibleIndex = 13;
            this.colMalESAS_NO.Name = "colMalESAS_NO";
            this.colMalESAS_NO.FieldName = "ESAS_NO";
            this.colADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colADLI_BIRIM_NO_ID.Visible = true;
            this.colADLI_BIRIM_NO_ID.OptionsColumn.AllowEdit = false;
            this.colADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colADLI_BIRIM_NO_ID.VisibleIndex = 14;
            this.colADLI_BIRIM_NO_ID.Name = "colADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colADLI_BIRIM_GOREV_ID.Visible = true;
            this.colADLI_BIRIM_GOREV_ID.OptionsColumn.AllowEdit = false;
            this.colADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colADLI_BIRIM_GOREV_ID.VisibleIndex = 15;
            this.colADLI_BIRIM_GOREV_ID.Name = "colADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colADLI_BIRIM_ADLIYE_ID.OptionsColumn.AllowEdit = false;
            this.colADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colADLI_BIRIM_ADLIYE_ID.VisibleIndex = 16;
            this.colADLI_BIRIM_ADLIYE_ID.Name = "colADLI_BIRIM_ADLIYE_ID";
            this.colADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colMAL_ADRES.Caption = "Adresi";
            this.colMAL_ADRES.Visible = true;
            this.colMAL_ADRES.OptionsColumn.AllowEdit = false;
            this.colMAL_ADRES.OptionsColumn.ReadOnly = true;
            this.colMAL_ADRES.VisibleIndex = 17;
            this.colMAL_ADRES.Name = "colMAL_ADRES";
            this.colMAL_ADRES.FieldName = "MAL_ADRES";
            this.colHACIZLI_MAL_ACIKLAMASI.Caption = "Mal Açıklama";
            this.colHACIZLI_MAL_ACIKLAMASI.Visible = true;
            this.colHACIZLI_MAL_ACIKLAMASI.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_ACIKLAMASI.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_ACIKLAMASI.VisibleIndex = 18;
            this.colHACIZLI_MAL_ACIKLAMASI.Name = "colHACIZLI_MAL_ACIKLAMASI";
            this.colHACIZLI_MAL_ACIKLAMASI.FieldName = "HACIZLI_MAL_ACIKLAMASI";
            this.colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Caption = "Satır Top. Mik.";
            this.colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Visible = true;
            this.colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.VisibleIndex = 19;
            this.colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.Name = "colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR";
            this.colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_MIKTAR";
            this.colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Caption = "Satır Top. Mik. BRM";
            this.colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Visible = true;
            this.colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.VisibleIndex = 20;
            this.colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.Name = "colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID";
            this.colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.FieldName = "HACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID";
            this.colHACIZLI_MAL_NEVI.Caption = "Nevi";
            this.colHACIZLI_MAL_NEVI.Visible = true;
            this.colHACIZLI_MAL_NEVI.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_NEVI.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_NEVI.VisibleIndex = 21;
            this.colHACIZLI_MAL_NEVI.Name = "colHACIZLI_MAL_NEVI";
            this.colHACIZLI_MAL_NEVI.FieldName = "HACIZLI_MAL_NEVI";
            this.colHACIZLI_MAL_MARKASI.Caption = "Markası";
            this.colHACIZLI_MAL_MARKASI.Visible = true;
            this.colHACIZLI_MAL_MARKASI.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_MARKASI.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_MARKASI.VisibleIndex = 22;
            this.colHACIZLI_MAL_MARKASI.Name = "colHACIZLI_MAL_MARKASI";
            this.colHACIZLI_MAL_MARKASI.FieldName = "HACIZLI_MAL_MARKASI";
            this.colHACIZLI_MAL_OZELLIKLERI.Caption = "Özellikleri";
            this.colHACIZLI_MAL_OZELLIKLERI.Visible = true;
            this.colHACIZLI_MAL_OZELLIKLERI.OptionsColumn.AllowEdit = false;
            this.colHACIZLI_MAL_OZELLIKLERI.OptionsColumn.ReadOnly = true;
            this.colHACIZLI_MAL_OZELLIKLERI.VisibleIndex = 23;
            this.colHACIZLI_MAL_OZELLIKLERI.Name = "colHACIZLI_MAL_OZELLIKLERI";
            this.colHACIZLI_MAL_OZELLIKLERI.FieldName = "HACIZLI_MAL_OZELLIKLERI";
            this.colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Caption = "Feragat Var mı";
            this.colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Visible = true;
            this.colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.OptionsColumn.AllowEdit = false;
            this.colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.OptionsColumn.ReadOnly = true;
            this.colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.VisibleIndex = 24;
            this.colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.Name = "colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI";
            this.colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.FieldName = "HACZEDILEMEZLIKTEN_FERAGAT_VAR_MI";
            this.colHACIZ_ISLEM_DURUM_ID.Caption = "İşlem Durum";
            this.colHACIZ_ISLEM_DURUM_ID.Visible = true;
            this.colHACIZ_ISLEM_DURUM_ID.OptionsColumn.AllowEdit = false;
            this.colHACIZ_ISLEM_DURUM_ID.OptionsColumn.ReadOnly = true;
            this.colHACIZ_ISLEM_DURUM_ID.VisibleIndex = 25;
            this.colHACIZ_ISLEM_DURUM_ID.Name = "colHACIZ_ISLEM_DURUM_ID";
            this.colHACIZ_ISLEM_DURUM_ID.FieldName = "HACIZ_ISLEM_DURUM_ID";
            this.colISTIHKAK_IDDIASI_VAR_MI.Caption = "İstihkak İddası Var mı";
            this.colISTIHKAK_IDDIASI_VAR_MI.Visible = true;
            this.colISTIHKAK_IDDIASI_VAR_MI.OptionsColumn.AllowEdit = false;
            this.colISTIHKAK_IDDIASI_VAR_MI.OptionsColumn.ReadOnly = true;
            this.colISTIHKAK_IDDIASI_VAR_MI.VisibleIndex = 26;
            this.colISTIHKAK_IDDIASI_VAR_MI.Name = "colISTIHKAK_IDDIASI_VAR_MI";
            this.colISTIHKAK_IDDIASI_VAR_MI.FieldName = "ISTIHKAK_IDDIASI_VAR_MI";
            this.colPARAYA_CEVRILDI_MI.Caption = "Paraya Çevrildi mi";
            this.colPARAYA_CEVRILDI_MI.Visible = true;
            this.colPARAYA_CEVRILDI_MI.OptionsColumn.AllowEdit = false;
            this.colPARAYA_CEVRILDI_MI.OptionsColumn.ReadOnly = true;
            this.colPARAYA_CEVRILDI_MI.VisibleIndex = 27;
            this.colPARAYA_CEVRILDI_MI.Name = "colPARAYA_CEVRILDI_MI";
            this.colPARAYA_CEVRILDI_MI.FieldName = "PARAYA_CEVRILDI_MI";
            this.colYEDIEMIN_CARI_ID.Caption = "Yeddiemin";
            this.colYEDIEMIN_CARI_ID.Visible = true;
            this.colYEDIEMIN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colYEDIEMIN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colYEDIEMIN_CARI_ID.VisibleIndex = 28;
            this.colYEDIEMIN_CARI_ID.Name = "colYEDIEMIN_CARI_ID";
            this.colYEDIEMIN_CARI_ID.FieldName = "YEDIEMIN_CARI_ID";
            this.colALACAKLI_RIZASI_VAR_MI.Caption = "Alacaklı Rızası Var mı";
            this.colALACAKLI_RIZASI_VAR_MI.Visible = true;
            this.colALACAKLI_RIZASI_VAR_MI.OptionsColumn.AllowEdit = false;
            this.colALACAKLI_RIZASI_VAR_MI.OptionsColumn.ReadOnly = true;
            this.colALACAKLI_RIZASI_VAR_MI.VisibleIndex = 29;
            this.colALACAKLI_RIZASI_VAR_MI.Name = "colALACAKLI_RIZASI_VAR_MI";
            this.colALACAKLI_RIZASI_VAR_MI.FieldName = "ALACAKLI_RIZASI_VAR_MI";
            this.colARAC_PLAKA_NO.Caption = "Plaka No";
            this.colARAC_PLAKA_NO.Visible = true;
            this.colARAC_PLAKA_NO.OptionsColumn.AllowEdit = false;
            this.colARAC_PLAKA_NO.OptionsColumn.ReadOnly = true;
            this.colARAC_PLAKA_NO.VisibleIndex = 30;
            this.colARAC_PLAKA_NO.Name = "colARAC_PLAKA_NO";
            this.colARAC_PLAKA_NO.FieldName = "ARAC_PLAKA_NO";
            this.colMALTIP.Caption = "Tipi";
            this.colMALTIP.Visible = true;
            this.colMALTIP.OptionsColumn.AllowEdit = false;
            this.colMALTIP.OptionsColumn.ReadOnly = true;
            this.colMALTIP.VisibleIndex = 31;
            this.colMALTIP.Name = "colMALTIP";
            this.colMALTIP.FieldName = "TIP";
            this.colEKSPERTIZ_DEGERI.Caption = "Ekspertiz Değeri";
            this.colEKSPERTIZ_DEGERI.Visible = true;
            this.colEKSPERTIZ_DEGERI.OptionsColumn.AllowEdit = false;
            this.colEKSPERTIZ_DEGERI.OptionsColumn.ReadOnly = true;
            this.colEKSPERTIZ_DEGERI.VisibleIndex = 32;
            this.colEKSPERTIZ_DEGERI.Name = "colEKSPERTIZ_DEGERI";
            this.colEKSPERTIZ_DEGERI.FieldName = "EKSPERTIZ_DEGERI";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            colHACIZLI_MAL_KATEGORI_ID.ColumnEdit = this.rLueMalKategori;
            colHACIZLI_MAL_TUR_ID.ColumnEdit = this.rLueMalTur;
            colHACIZLI_MAL_CINS_ID.ColumnEdit = this.rLueMalCins;
            colHACIZLI_MAL_DEGERI.ColumnEdit = this.seMalDeger;
            colHACIZLI_MAL_DEGERI_DOVIZ_ID.ColumnEdit = this.rLueMalDovizID;
            colHACIZLI_MAL_ADEDI.ColumnEdit = this.seMalDeger;
            colHACIZLI_MAL_ADET_BIRIM_ID.ColumnEdit = this.rLueMalAdetBirimKod;
            colUCUNCU_SAHISTA_MI.ColumnEdit = this.chkMalUcuncuSahistami;
            colUCUNCU_SAHIS_CARI_ID.ColumnEdit = this.rLueMalCariID;
            colMalCARI_ID.ColumnEdit = this.rLueMalCariID;
            colADLI_BIRIM_NO_ID.ColumnEdit = this.rLueMalAdliBirimNo;
            colADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueMalAdliBirimGorev;
            colADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueMalAdliBirimAdliye;
            colHACIZLI_MAL_SATIR_TOPLAM_MIKTAR.ColumnEdit = this.seMalDeger;
            colHACIZLI_MAL_SATIR_TOPLAM_DOVIZ_ID.ColumnEdit = this.rLueMalDovizID;
            colHACZEDILEMEZLIKTEN_FERAGAT_VAR_MI.ColumnEdit = this.chkMalUcuncuSahistami;
            colHACIZ_ISLEM_DURUM_ID.ColumnEdit = this.rLueMalHacizIslemDurum;
            colISTIHKAK_IDDIASI_VAR_MI.ColumnEdit = this.chkMalUcuncuSahistami;
            colPARAYA_CEVRILDI_MI.ColumnEdit = this.chkMalUcuncuSahistami;
            colALACAKLI_RIZASI_VAR_MI.ColumnEdit = this.chkMalUcuncuSahistami;
            colYEDIEMIN_CARI_ID.ColumnEdit = this.rLueMalCariID;
            colEKSPERTIZ_DEGERI.ColumnEdit = this.seMalDeger;

            TumMallarLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Tüm Mallar ( Borçlu Mal ) Gridinin Columlarının Oluşturulması

        #region İhtiyati Tedbir Grid Columnlarının Oluşturulması

        private GridColumn[] GetIhtiyatiTedbirGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colICRA_CARI_TARAF_ID,
                                        this.colTADLI_BIRIM_ADLIYE_ID,
                                        this.colTADLI_BIRIM_GOREV_ID,
                                        this.colTADLI_BIRIM_NO_ID,
                                        this.colTDAVA_TARIHI,
                                        this.colTESAS_NO,
                                        this.colTKARAR_NO,
                                        this.colTKARAR_TARIHI,
                                        this.colTTALEP_TARIHI,
                                        this.colTTEMINAT_TUR_ID,
                                        this.colTTEMINAT_TUTARI,
                                        this.colTTEMINAT_TUTARI_DOVIZ_ID,
                                        this.colTTESLIM_ALAN_CARI_ID,
                                        this.colTACIKLAMA,
                                        this.colTMUVEKKILE_TESLIM_TARIHI,
                                        this.colTTEMINAT_IADE_TARIHI,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colICRA_CARI_TARAF_ID.Caption = "İcra Taraf";
            this.colICRA_CARI_TARAF_ID.Visible = true;
            this.colICRA_CARI_TARAF_ID.OptionsColumn.AllowEdit = false;
            this.colICRA_CARI_TARAF_ID.OptionsColumn.ReadOnly = true;
            this.colICRA_CARI_TARAF_ID.VisibleIndex = 1;
            this.colICRA_CARI_TARAF_ID.Name = "colICRA_CARI_TARAF_ID";
            this.colICRA_CARI_TARAF_ID.FieldName = "ICRA_CARI_TARAF_ID";
            this.colTADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colTADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colTADLI_BIRIM_ADLIYE_ID.OptionsColumn.AllowEdit = false;
            this.colTADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colTADLI_BIRIM_ADLIYE_ID.VisibleIndex = 2;
            this.colTADLI_BIRIM_ADLIYE_ID.Name = "colTADLI_BIRIM_ADLIYE_ID";
            this.colTADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colTADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colTADLI_BIRIM_NO_ID.Visible = true;
            this.colTADLI_BIRIM_NO_ID.OptionsColumn.AllowEdit = false;
            this.colTADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colTADLI_BIRIM_NO_ID.VisibleIndex = 3;
            this.colTADLI_BIRIM_NO_ID.Name = "colTADLI_BIRIM_NO_ID";
            this.colTADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colTADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colTADLI_BIRIM_GOREV_ID.Visible = true;
            this.colTADLI_BIRIM_GOREV_ID.OptionsColumn.AllowEdit = false;
            this.colTADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colTADLI_BIRIM_GOREV_ID.VisibleIndex = 4;
            this.colTADLI_BIRIM_GOREV_ID.Name = "colTADLI_BIRIM_GOREV_ID";
            this.colTADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colTDAVA_TARIHI.Caption = "Dava T";
            this.colTDAVA_TARIHI.Visible = true;
            this.colTDAVA_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTDAVA_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTDAVA_TARIHI.VisibleIndex = 5;
            this.colTDAVA_TARIHI.Name = "colTDAVA_TARIHI";
            this.colTDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            this.colTESAS_NO.Caption = "Esas No";
            this.colTESAS_NO.Visible = true;
            this.colTESAS_NO.OptionsColumn.AllowEdit = false;
            this.colTESAS_NO.OptionsColumn.ReadOnly = true;
            this.colTESAS_NO.VisibleIndex = 6;
            this.colTESAS_NO.Name = "colTESAS_NO";
            this.colTESAS_NO.FieldName = "ESAS_NO";
            this.colTKARAR_NO.Caption = "Karar No";
            this.colTKARAR_NO.Visible = true;
            this.colTKARAR_NO.OptionsColumn.AllowEdit = false;
            this.colTKARAR_NO.OptionsColumn.ReadOnly = true;
            this.colTKARAR_NO.VisibleIndex = 7;
            this.colTKARAR_NO.Name = "colTKARAR_NO";
            this.colTKARAR_NO.FieldName = "KARAR_NO";
            this.colTKARAR_TARIHI.Caption = "Karar T";
            this.colTKARAR_TARIHI.Visible = true;
            this.colTKARAR_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTKARAR_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTKARAR_TARIHI.VisibleIndex = 8;
            this.colTKARAR_TARIHI.Name = "colTKARAR_TARIHI";
            this.colTKARAR_TARIHI.FieldName = "KARAR_TARIHI";
            this.colTTALEP_TARIHI.Caption = "Talep T";
            this.colTTALEP_TARIHI.Visible = true;
            this.colTTALEP_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTTALEP_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTTALEP_TARIHI.VisibleIndex = 9;
            this.colTTALEP_TARIHI.Name = "colTTALEP_TARIHI";
            this.colTTALEP_TARIHI.FieldName = "TALEP_TARIHI";
            this.colTTEMINAT_TUR_ID.Caption = "Teminat Tür";
            this.colTTEMINAT_TUR_ID.Visible = true;
            this.colTTEMINAT_TUR_ID.OptionsColumn.AllowEdit = false;
            this.colTTEMINAT_TUR_ID.OptionsColumn.ReadOnly = true;
            this.colTTEMINAT_TUR_ID.VisibleIndex = 10;
            this.colTTEMINAT_TUR_ID.Name = "colTTEMINAT_TUR_ID";
            this.colTTEMINAT_TUR_ID.FieldName = "TEMINAT_TUR_ID";
            this.colTTEMINAT_TUTARI.Caption = "Teminat Tutar";
            this.colTTEMINAT_TUTARI.Visible = true;
            this.colTTEMINAT_TUTARI.OptionsColumn.AllowEdit = false;
            this.colTTEMINAT_TUTARI.OptionsColumn.ReadOnly = true;
            this.colTTEMINAT_TUTARI.VisibleIndex = 11;
            this.colTTEMINAT_TUTARI.Name = "colTTEMINAT_TUTARI";
            this.colTTEMINAT_TUTARI.FieldName = "TEMINAT_TUTARI";
            this.colTTEMINAT_TUTARI_DOVIZ_ID.Caption = " ";
            this.colTTEMINAT_TUTARI_DOVIZ_ID.Visible = true;
            this.colTTEMINAT_TUTARI_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colTTEMINAT_TUTARI_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colTTEMINAT_TUTARI_DOVIZ_ID.VisibleIndex = 12;
            this.colTTEMINAT_TUTARI_DOVIZ_ID.Name = "colTTEMINAT_TUTARI_DOVIZ_ID";
            this.colTTEMINAT_TUTARI_DOVIZ_ID.FieldName = "TEMINAT_TUTARI_DOVIZ_ID";
            this.colTTESLIM_ALAN_CARI_ID.Caption = "Teslim Alan";
            this.colTTESLIM_ALAN_CARI_ID.Visible = true;
            this.colTTESLIM_ALAN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colTTESLIM_ALAN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colTTESLIM_ALAN_CARI_ID.VisibleIndex = 13;
            this.colTTESLIM_ALAN_CARI_ID.Name = "colTTESLIM_ALAN_CARI_ID";
            this.colTTESLIM_ALAN_CARI_ID.FieldName = "TESLIM_ALAN_CARI_ID";
            this.colTACIKLAMA.Caption = "Açıklama";
            this.colTACIKLAMA.Visible = true;
            this.colTACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colTACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colTACIKLAMA.VisibleIndex = 14;
            this.colTACIKLAMA.Name = "colTACIKLAMA";
            this.colTACIKLAMA.FieldName = "ACIKLAMA";
            this.colTMUVEKKILE_TESLIM_TARIHI.Caption = "M. Teslim T";
            this.colTMUVEKKILE_TESLIM_TARIHI.Visible = true;
            this.colTMUVEKKILE_TESLIM_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTMUVEKKILE_TESLIM_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTMUVEKKILE_TESLIM_TARIHI.VisibleIndex = 15;
            this.colTMUVEKKILE_TESLIM_TARIHI.Name = "colTMUVEKKILE_TESLIM_TARIHI";
            this.colTMUVEKKILE_TESLIM_TARIHI.FieldName = "MUVEKKILE_TESLIM_TARIHI";
            this.colTTEMINAT_IADE_TARIHI.Caption = "İade T";
            this.colTTEMINAT_IADE_TARIHI.Visible = true;
            this.colTTEMINAT_IADE_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTTEMINAT_IADE_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTTEMINAT_IADE_TARIHI.VisibleIndex = 16;
            this.colTTEMINAT_IADE_TARIHI.Name = "colTTEMINAT_IADE_TARIHI";
            this.colTTEMINAT_IADE_TARIHI.FieldName = "TEMINAT_IADE_TARIHI";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            colICRA_CARI_TARAF_ID.ColumnEdit = this.rLueIhtiyatiTedbirCariID;
            colTADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueTedbirAdliBirimAdliye;
            colTADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueTedbirAdliBirimGorev;
            colTADLI_BIRIM_NO_ID.ColumnEdit = this.rLueTedbirAdliBirimNo;
            colTDAVA_TARIHI.ColumnEdit = this.deTedbirDavaT;
            colTKARAR_TARIHI.ColumnEdit = this.deTedbirDavaT;
            colTTALEP_TARIHI.ColumnEdit = this.deTedbirDavaT;
            colTMUVEKKILE_TESLIM_TARIHI.ColumnEdit = this.deTedbirDavaT;
            colTTEMINAT_IADE_TARIHI.ColumnEdit = this.deTedbirDavaT;
            colTTEMINAT_TUR_ID.ColumnEdit = this.rLueTedbirTeminatTurID;
            colTTEMINAT_TUTARI_DOVIZ_ID.ColumnEdit = this.rLueTedbirDovizID;
            colTTESLIM_ALAN_CARI_ID.ColumnEdit = this.rLueIhtiyatiTedbirCariID;

            IhtiyatiTedbirLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion İhtiyati Tedbir Grid Columnlarının Oluşturulması

        #region İhtiyati Haciz Grid Columnlarının Oluşturulması

        private GridColumn[] GetIhtiyatiHacizGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colICRA_CARI_TARAF_ID,
                                        this.colTADLI_BIRIM_ADLIYE_ID,
                                        this.colTADLI_BIRIM_GOREV_ID,
                                        this.colTADLI_BIRIM_NO_ID,
                                        this.colTESAS_NO,
                                        this.colTKARAR_NO,
                                        this.colTKARAR_TARIHI,
                                        this.colTTEMINAT_TUR_ID,
                                        this.colTTEMINAT_TUTARI,
                                        this.colTTEMINAT_TUTARI_DOVIZ_ID,
                                        this.colTTESLIM_ALAN_CARI_ID,
                                        this.colTACIKLAMA,
                                        this.colTMUVEKKILE_TESLIM_TARIHI,
                                        this.colTTEMINAT_IADE_TARIHI,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colICRA_CARI_TARAF_ID.Caption = "İcra Taraf";
            this.colICRA_CARI_TARAF_ID.Visible = true;
            this.colICRA_CARI_TARAF_ID.OptionsColumn.AllowEdit = false;
            this.colICRA_CARI_TARAF_ID.OptionsColumn.ReadOnly = true;
            this.colICRA_CARI_TARAF_ID.VisibleIndex = 1;
            this.colICRA_CARI_TARAF_ID.Name = "colICRA_CARI_TARAF_ID";
            this.colICRA_CARI_TARAF_ID.FieldName = "ICRA_CARI_TARAF_ID";
            this.colTADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colTADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colTADLI_BIRIM_ADLIYE_ID.OptionsColumn.AllowEdit = false;
            this.colTADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colTADLI_BIRIM_ADLIYE_ID.VisibleIndex = 2;
            this.colTADLI_BIRIM_ADLIYE_ID.Name = "colTADLI_BIRIM_ADLIYE_ID";
            this.colTADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colTADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colTADLI_BIRIM_NO_ID.Visible = true;
            this.colTADLI_BIRIM_NO_ID.OptionsColumn.AllowEdit = false;
            this.colTADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colTADLI_BIRIM_NO_ID.VisibleIndex = 3;
            this.colTADLI_BIRIM_NO_ID.Name = "colTADLI_BIRIM_NO_ID";
            this.colTADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colTADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colTADLI_BIRIM_GOREV_ID.Visible = true;
            this.colTADLI_BIRIM_GOREV_ID.OptionsColumn.AllowEdit = false;
            this.colTADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colTADLI_BIRIM_GOREV_ID.VisibleIndex = 4;
            this.colTADLI_BIRIM_GOREV_ID.Name = "colTADLI_BIRIM_GOREV_ID";
            this.colTADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colTESAS_NO.Caption = "Esas No";
            this.colTESAS_NO.Visible = true;
            this.colTESAS_NO.OptionsColumn.AllowEdit = false;
            this.colTESAS_NO.OptionsColumn.ReadOnly = true;
            this.colTESAS_NO.VisibleIndex = 6;
            this.colTESAS_NO.Name = "colTESAS_NO";
            this.colTESAS_NO.FieldName = "ESAS_NO";
            this.colTKARAR_NO.Caption = "Karar No";
            this.colTKARAR_NO.Visible = true;
            this.colTKARAR_NO.OptionsColumn.AllowEdit = false;
            this.colTKARAR_NO.OptionsColumn.ReadOnly = true;
            this.colTKARAR_NO.VisibleIndex = 7;
            this.colTKARAR_NO.Name = "colTKARAR_NO";
            this.colTKARAR_NO.FieldName = "KARAR_NO";
            this.colTKARAR_TARIHI.Caption = "Karar T";
            this.colTKARAR_TARIHI.Visible = true;
            this.colTKARAR_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTKARAR_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTKARAR_TARIHI.VisibleIndex = 8;
            this.colTKARAR_TARIHI.Name = "colTKARAR_TARIHI";
            this.colTKARAR_TARIHI.FieldName = "KARAR_TARIHI";
            this.colTTEMINAT_TUR_ID.Caption = "Teminat Tür";
            this.colTTEMINAT_TUR_ID.Visible = true;
            this.colTTEMINAT_TUR_ID.OptionsColumn.AllowEdit = false;
            this.colTTEMINAT_TUR_ID.OptionsColumn.ReadOnly = true;
            this.colTTEMINAT_TUR_ID.VisibleIndex = 10;
            this.colTTEMINAT_TUR_ID.Name = "colTTEMINAT_TUR_ID";
            this.colTTEMINAT_TUR_ID.FieldName = "TEMINAT_TUR_ID";
            this.colTTEMINAT_TUTARI.Caption = "Teminat Tutar";
            this.colTTEMINAT_TUTARI.Visible = true;
            this.colTTEMINAT_TUTARI.OptionsColumn.AllowEdit = false;
            this.colTTEMINAT_TUTARI.OptionsColumn.ReadOnly = true;
            this.colTTEMINAT_TUTARI.VisibleIndex = 11;
            this.colTTEMINAT_TUTARI.Name = "colTTEMINAT_TUTARI";
            this.colTTEMINAT_TUTARI.FieldName = "TEMINAT_TUTARI";
            this.colTTEMINAT_TUTARI_DOVIZ_ID.Caption = " ";
            this.colTTEMINAT_TUTARI_DOVIZ_ID.Visible = true;
            this.colTTEMINAT_TUTARI_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colTTEMINAT_TUTARI_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colTTEMINAT_TUTARI_DOVIZ_ID.VisibleIndex = 12;
            this.colTTEMINAT_TUTARI_DOVIZ_ID.Name = "colTTEMINAT_TUTARI_DOVIZ_ID";
            this.colTTEMINAT_TUTARI_DOVIZ_ID.FieldName = "TEMINAT_TUTARI_DOVIZ_ID";
            this.colTTESLIM_ALAN_CARI_ID.Caption = "Teslim Alan";
            this.colTTESLIM_ALAN_CARI_ID.Visible = true;
            this.colTTESLIM_ALAN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colTTESLIM_ALAN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colTTESLIM_ALAN_CARI_ID.VisibleIndex = 13;
            this.colTTESLIM_ALAN_CARI_ID.Name = "colTTESLIM_ALAN_CARI_ID";
            this.colTTESLIM_ALAN_CARI_ID.FieldName = "TESLIM_ALAN_CARI_ID";
            this.colTACIKLAMA.Caption = "Açıklama";
            this.colTACIKLAMA.Visible = true;
            this.colTACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colTACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colTACIKLAMA.VisibleIndex = 14;
            this.colTACIKLAMA.Name = "colTACIKLAMA";
            this.colTACIKLAMA.FieldName = "ACIKLAMA";
            this.colTMUVEKKILE_TESLIM_TARIHI.Caption = "M. Teslim T";
            this.colTMUVEKKILE_TESLIM_TARIHI.Visible = true;
            this.colTMUVEKKILE_TESLIM_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTMUVEKKILE_TESLIM_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTMUVEKKILE_TESLIM_TARIHI.VisibleIndex = 15;
            this.colTMUVEKKILE_TESLIM_TARIHI.Name = "colTMUVEKKILE_TESLIM_TARIHI";
            this.colTMUVEKKILE_TESLIM_TARIHI.FieldName = "MUVEKKILE_TESLIM_TARIHI";
            this.colTTEMINAT_IADE_TARIHI.Caption = "İade T";
            this.colTTEMINAT_IADE_TARIHI.Visible = true;
            this.colTTEMINAT_IADE_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTTEMINAT_IADE_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTTEMINAT_IADE_TARIHI.VisibleIndex = 16;
            this.colTTEMINAT_IADE_TARIHI.Name = "colTTEMINAT_IADE_TARIHI";
            this.colTTEMINAT_IADE_TARIHI.FieldName = "TEMINAT_IADE_TARIHI";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            colICRA_CARI_TARAF_ID.ColumnEdit = this.rLueIhtiyatiTedbirCariID;
            colTADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueTedbirAdliBirimAdliye;
            colTADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueTedbirAdliBirimGorev;
            colTADLI_BIRIM_NO_ID.ColumnEdit = this.rLueTedbirAdliBirimNo;

            colTKARAR_TARIHI.ColumnEdit = this.deTedbirDavaT;

            colTMUVEKKILE_TESLIM_TARIHI.ColumnEdit = this.deTedbirDavaT;
            colTTEMINAT_IADE_TARIHI.ColumnEdit = this.deTedbirDavaT;
            colTTEMINAT_TUR_ID.ColumnEdit = this.rLueTedbirTeminatTurID;
            colTTEMINAT_TUTARI_DOVIZ_ID.ColumnEdit = this.rLueTedbirDovizID;
            colTTESLIM_ALAN_CARI_ID.ColumnEdit = this.rLueIhtiyatiTedbirCariID;

            //LokkUplar Aynı ..
            IhtiyatiTedbirLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion İhtiyati Haciz Grid Columnlarının Oluşturulması

        #region Taahhut Master GRid Columnlarının Oluşturulması

        private GridColumn[] GetTaahhutMasterGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colTAAHHUT_SIRA_NO,
                                        this.colTAAHHUT_TIP,
                                        this.colTAAHHUT_EDEN_ID,
                                        this.colTAAHHUT_TARIHI,
                                        this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI,
                                        this.colTAAHHUDU_KABUL_TARIHI,
                                        this.colDAVASI_VAR_MI,
                                        this.colRESMI_MI,
                                        this.colGECERLI_MI,
                                        this.colTAAHHUT_IHLAL_TARIHI,
                                        this.colTAAHHUDU_KABUL_EDEN_ID,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colTAAHHUT_SIRA_NO.Caption = "Sıra No";
            this.colTAAHHUT_SIRA_NO.Visible = true;
            this.colTAAHHUT_SIRA_NO.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_SIRA_NO.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_SIRA_NO.VisibleIndex = 1;
            this.colTAAHHUT_SIRA_NO.Name = "colTAAHHUT_SIRA_NO";
            this.colTAAHHUT_SIRA_NO.FieldName = "TAAHHUT_SIRA_NO";
            this.colTAAHHUT_TIP.Caption = "Tipi";
            this.colTAAHHUT_TIP.Visible = true;
            this.colTAAHHUT_TIP.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_TIP.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_TIP.VisibleIndex = 2;
            this.colTAAHHUT_TIP.Name = "colTAAHHUT_TIP";
            this.colTAAHHUT_TIP.FieldName = "TAAHHUT_TIP";
            this.colTAAHHUT_EDEN_ID.Caption = "Taahhut Eden";
            this.colTAAHHUT_EDEN_ID.Visible = true;
            this.colTAAHHUT_EDEN_ID.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_EDEN_ID.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_EDEN_ID.VisibleIndex = 3;
            this.colTAAHHUT_EDEN_ID.Name = "colTAAHHUT_EDEN_ID";
            this.colTAAHHUT_EDEN_ID.FieldName = "TAAHHUT_EDEN_ID";
            this.colTAAHHUT_TARIHI.Caption = "Tarihi";
            this.colTAAHHUT_TARIHI.Visible = true;
            this.colTAAHHUT_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_TARIHI.VisibleIndex = 4;
            this.colTAAHHUT_TARIHI.Name = "colTAAHHUT_TARIHI";
            this.colTAAHHUT_TARIHI.FieldName = "TAAHHUT_TARIHI";
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Caption = "Tebliğ T";
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Visible = true;
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.VisibleIndex = 5;
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.Name = "colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            this.colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.FieldName = "TAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI";
            this.colTAAHHUDU_KABUL_TARIHI.Caption = "Kabul T";
            this.colTAAHHUDU_KABUL_TARIHI.Visible = true;
            this.colTAAHHUDU_KABUL_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUDU_KABUL_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUDU_KABUL_TARIHI.VisibleIndex = 6;
            this.colTAAHHUDU_KABUL_TARIHI.Name = "colTAAHHUDU_KABUL_TARIHI";
            this.colTAAHHUDU_KABUL_TARIHI.FieldName = "TAAHHUDU_KABUL_TARIHI";
            this.colDAVASI_VAR_MI.Caption = "Davası Var mı";
            this.colDAVASI_VAR_MI.Visible = true;
            this.colDAVASI_VAR_MI.OptionsColumn.AllowEdit = false;
            this.colDAVASI_VAR_MI.OptionsColumn.ReadOnly = true;
            this.colDAVASI_VAR_MI.VisibleIndex = 7;
            this.colDAVASI_VAR_MI.Name = "colDAVASI_VAR_MI";
            this.colDAVASI_VAR_MI.FieldName = "DAVASI_VAR_MI";
            this.colRESMI_MI.Caption = "Resmi mi";
            this.colRESMI_MI.Visible = true;
            this.colRESMI_MI.OptionsColumn.AllowEdit = false;
            this.colRESMI_MI.OptionsColumn.ReadOnly = true;
            this.colRESMI_MI.VisibleIndex = 8;
            this.colRESMI_MI.Name = "colRESMI_MI";
            this.colRESMI_MI.FieldName = "RESMI_MI";
            this.colGECERLI_MI.Caption = "";
            this.colGECERLI_MI.Visible = true;
            this.colGECERLI_MI.OptionsColumn.AllowEdit = false;
            this.colGECERLI_MI.OptionsColumn.ReadOnly = true;
            this.colGECERLI_MI.VisibleIndex = 9;
            this.colGECERLI_MI.Name = "colGECERLI_MI";
            this.colGECERLI_MI.FieldName = "GECERLI_MI";
            this.colTAAHHUT_IHLAL_TARIHI.Caption = "İhlal T";
            this.colTAAHHUT_IHLAL_TARIHI.Visible = true;
            this.colTAAHHUT_IHLAL_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUT_IHLAL_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUT_IHLAL_TARIHI.VisibleIndex = 10;
            this.colTAAHHUT_IHLAL_TARIHI.Name = "colTAAHHUT_IHLAL_TARIHI";
            this.colTAAHHUT_IHLAL_TARIHI.FieldName = "TAAHHUT_IHLAL_TARIHI";
            this.colTAAHHUDU_KABUL_EDEN_ID.Caption = "Kabul Eden";
            this.colTAAHHUDU_KABUL_EDEN_ID.Visible = true;
            this.colTAAHHUDU_KABUL_EDEN_ID.OptionsColumn.AllowEdit = false;
            this.colTAAHHUDU_KABUL_EDEN_ID.OptionsColumn.ReadOnly = true;
            this.colTAAHHUDU_KABUL_EDEN_ID.VisibleIndex = 11;
            this.colTAAHHUDU_KABUL_EDEN_ID.Name = "colTAAHHUDU_KABUL_EDEN_ID";
            this.colTAAHHUDU_KABUL_EDEN_ID.FieldName = "TAAHHUDU_KABUL_EDEN_ID";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            colTAAHHUT_SIRA_NO.ColumnEdit = this.seTaahhutSiraNo;
            colTAAHHUT_EDEN_ID.ColumnEdit = this.rLueTahEdenCariID;
            colTAAHHUT_TARIHI.ColumnEdit = this.deTahTarihi;
            colTAAHHUDUN_KABUL_EDENE_TEBLIG_TARIHI.ColumnEdit = this.deTahTarihi;
            colTAAHHUDU_KABUL_TARIHI.ColumnEdit = this.deTahTarihi;
            colDAVASI_VAR_MI.ColumnEdit = this.chkDavasiVarmi;
            colRESMI_MI.ColumnEdit = this.chkDavasiVarmi;
            colGECERLI_MI.ColumnEdit = this.chkDavasiVarmi;
            colTAAHHUT_IHLAL_TARIHI.ColumnEdit = this.deTahTarihi;
            colTAAHHUDU_KABUL_EDEN_ID.ColumnEdit = this.rLueTahEdenCariID;
            TaahhutMasterLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Taahhut Master GRid Columnlarının Oluşturulması

        #region Ödemeler Grid Columnlarının Oluşturulması

        private GridColumn[] GetOdemelerGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colALACAK_NEDEN_ID,
                                        this.colODEYEN_CARI_ID,
                                        this.colODENEN_CARI_ID,
                                        this.colBORCLU_ADINA_ODEYEN_CARI_ID,
                                        this.colBORCLU_ADINA_ODENEN_CARI_ID,
                                        this.colODEME_YER_ID,
                                        this.colMAAS_HACZINDEN_MI,
                                        this.colIHTIYATI_HACIZDE_MI,
                                        this.colODEME_TARIHI,
                                        this.colICRADAN_CEKILME_TARIHI,
                                        this.colODEME_TIP_ID,
                                        this.colKIYMETLI_EVRAK_VADE_TARIHI,
                                        this.colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI,
                                        this.colKIYMETLI_EVRAK_ODENDI_MI,
                                        this.colODEME_MIKTAR,
                                        this.colODEME_MIKTAR_DOVIZ_ID,
                                        this.colODEME_KIM_ADINA,
                                        this.colTAAHHUTE_DAGILAN_TUTAR,
                                        this.colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID,
                                        this.colTAAHHUTE_DAGILMA_TARIHI,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colALACAK_NEDEN_ID.Caption = "Alacak Neden";
            this.colALACAK_NEDEN_ID.Visible = true;
            this.colALACAK_NEDEN_ID.OptionsColumn.AllowEdit = false;
            this.colALACAK_NEDEN_ID.OptionsColumn.ReadOnly = true;
            this.colALACAK_NEDEN_ID.VisibleIndex = 1;
            this.colALACAK_NEDEN_ID.Name = "colALACAK_NEDEN_ID";
            this.colALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            this.colODEYEN_CARI_ID.Caption = "Ödeyen";
            this.colODEYEN_CARI_ID.Visible = true;
            this.colODEYEN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colODEYEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colODEYEN_CARI_ID.VisibleIndex = 2;
            this.colODEYEN_CARI_ID.Name = "colODEYEN_CARI_ID";
            this.colODEYEN_CARI_ID.FieldName = "ODEYEN_CARI_ID";
            this.colODENEN_CARI_ID.Caption = "Ödenen";
            this.colODENEN_CARI_ID.Visible = true;
            this.colODENEN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colODENEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colODENEN_CARI_ID.VisibleIndex = 3;
            this.colODENEN_CARI_ID.Name = "colODENEN_CARI_ID";
            this.colODENEN_CARI_ID.FieldName = "ODENEN_CARI_ID";
            this.colBORCLU_ADINA_ODEYEN_CARI_ID.Caption = "Borçlu Adına Ödeyen";
            this.colBORCLU_ADINA_ODEYEN_CARI_ID.Visible = true;
            this.colBORCLU_ADINA_ODEYEN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colBORCLU_ADINA_ODEYEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colBORCLU_ADINA_ODEYEN_CARI_ID.VisibleIndex = 4;
            this.colBORCLU_ADINA_ODEYEN_CARI_ID.Name = "colBORCLU_ADINA_ODEYEN_CARI_ID";
            this.colBORCLU_ADINA_ODEYEN_CARI_ID.FieldName = "BORCLU_ADINA_ODEYEN_CARI_ID";
            this.colBORCLU_ADINA_ODENEN_CARI_ID.Caption = "Borçlu Adına Ödenen";
            this.colBORCLU_ADINA_ODENEN_CARI_ID.Visible = true;
            this.colBORCLU_ADINA_ODENEN_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colBORCLU_ADINA_ODENEN_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colBORCLU_ADINA_ODENEN_CARI_ID.VisibleIndex = 5;
            this.colBORCLU_ADINA_ODENEN_CARI_ID.Name = "colBORCLU_ADINA_ODENEN_CARI_ID";
            this.colBORCLU_ADINA_ODENEN_CARI_ID.FieldName = "BORCLU_ADINA_ODENEN_CARI_ID";
            this.colODEME_YER_ID.Caption = "Ödeme Yeri";
            this.colODEME_YER_ID.Visible = true;
            this.colODEME_YER_ID.OptionsColumn.AllowEdit = false;
            this.colODEME_YER_ID.OptionsColumn.ReadOnly = true;
            this.colODEME_YER_ID.VisibleIndex = 6;
            this.colODEME_YER_ID.Name = "colODEME_YER_ID";
            this.colODEME_YER_ID.FieldName = "ODEME_YER_ID";
            this.colMAAS_HACZINDEN_MI.Caption = "Maaş Hacizden mi";
            this.colMAAS_HACZINDEN_MI.Visible = true;
            this.colMAAS_HACZINDEN_MI.OptionsColumn.AllowEdit = false;
            this.colMAAS_HACZINDEN_MI.OptionsColumn.ReadOnly = true;
            this.colMAAS_HACZINDEN_MI.VisibleIndex = 7;
            this.colMAAS_HACZINDEN_MI.Name = "colMAAS_HACZINDEN_MI";
            this.colMAAS_HACZINDEN_MI.FieldName = "MAAS_HACZINDEN_MI";
            this.colIHTIYATI_HACIZDE_MI.Caption = "İhtiyati Hacizden mi";
            this.colIHTIYATI_HACIZDE_MI.Visible = true;
            this.colIHTIYATI_HACIZDE_MI.OptionsColumn.AllowEdit = false;
            this.colIHTIYATI_HACIZDE_MI.OptionsColumn.ReadOnly = true;
            this.colIHTIYATI_HACIZDE_MI.VisibleIndex = 8;
            this.colIHTIYATI_HACIZDE_MI.Name = "colIHTIYATI_HACIZDE_MI";
            this.colIHTIYATI_HACIZDE_MI.FieldName = "IHTIYATI_HACIZDE_MI";
            this.colODEME_TARIHI.Caption = "Ödeme T";
            this.colODEME_TARIHI.Visible = true;
            this.colODEME_TARIHI.OptionsColumn.AllowEdit = false;
            this.colODEME_TARIHI.OptionsColumn.ReadOnly = true;
            this.colODEME_TARIHI.VisibleIndex = 9;
            this.colODEME_TARIHI.Name = "colODEME_TARIHI";
            this.colODEME_TARIHI.FieldName = "ODEME_TARIHI";
            this.colICRADAN_CEKILME_TARIHI.Caption = "İcradan Çekilme T";
            this.colICRADAN_CEKILME_TARIHI.Visible = true;
            this.colICRADAN_CEKILME_TARIHI.OptionsColumn.AllowEdit = false;
            this.colICRADAN_CEKILME_TARIHI.OptionsColumn.ReadOnly = true;
            this.colICRADAN_CEKILME_TARIHI.VisibleIndex = 10;
            this.colICRADAN_CEKILME_TARIHI.Name = "colICRADAN_CEKILME_TARIHI";
            this.colICRADAN_CEKILME_TARIHI.FieldName = "ICRADAN_CEKILME_TARIHI";
            this.colODEME_TIP_ID.Caption = "Ödeme Tip";
            this.colODEME_TIP_ID.Visible = true;
            this.colODEME_TIP_ID.OptionsColumn.AllowEdit = false;
            this.colODEME_TIP_ID.OptionsColumn.ReadOnly = true;
            this.colODEME_TIP_ID.VisibleIndex = 11;
            this.colODEME_TIP_ID.Name = "colODEME_TIP_ID";
            this.colODEME_TIP_ID.FieldName = "ODEME_TIP_ID";
            this.colKIYMETLI_EVRAK_VADE_TARIHI.Caption = "K.Evrak Vade T";
            this.colKIYMETLI_EVRAK_VADE_TARIHI.Visible = true;
            this.colKIYMETLI_EVRAK_VADE_TARIHI.OptionsColumn.AllowEdit = false;
            this.colKIYMETLI_EVRAK_VADE_TARIHI.OptionsColumn.ReadOnly = true;
            this.colKIYMETLI_EVRAK_VADE_TARIHI.VisibleIndex = 12;
            this.colKIYMETLI_EVRAK_VADE_TARIHI.Name = "colKIYMETLI_EVRAK_VADE_TARIHI";
            this.colKIYMETLI_EVRAK_VADE_TARIHI.FieldName = "KIYMETLI_EVRAK_VADE_TARIHI";
            this.colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI.Caption = "K. Evrak Vadesinde Ödendimi";
            this.colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI.Visible = true;
            this.colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI.OptionsColumn.AllowEdit = false;
            this.colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI.OptionsColumn.ReadOnly = true;
            this.colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI.VisibleIndex = 13;
            this.colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI.Name = "colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI";
            this.colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI.FieldName = "KIYMETLI_EVRAK_VADESINDE_ODENDI_MI";
            this.colKIYMETLI_EVRAK_ODENDI_MI.Caption = "K. Evrak Ödendimi";
            this.colKIYMETLI_EVRAK_ODENDI_MI.Visible = true;
            this.colKIYMETLI_EVRAK_ODENDI_MI.OptionsColumn.AllowEdit = false;
            this.colKIYMETLI_EVRAK_ODENDI_MI.OptionsColumn.ReadOnly = true;
            this.colKIYMETLI_EVRAK_ODENDI_MI.VisibleIndex = 14;
            this.colKIYMETLI_EVRAK_ODENDI_MI.Name = "colKIYMETLI_EVRAK_ODENDI_MI";
            this.colKIYMETLI_EVRAK_ODENDI_MI.FieldName = "KIYMETLI_EVRAK_ODENDI_MI";
            this.colODEME_MIKTAR.Caption = "Ödeme Miktar";
            this.colODEME_MIKTAR.Visible = true;
            this.colODEME_MIKTAR.OptionsColumn.AllowEdit = false;
            this.colODEME_MIKTAR.OptionsColumn.ReadOnly = true;
            this.colODEME_MIKTAR.VisibleIndex = 15;
            this.colODEME_MIKTAR.Name = "colODEME_MIKTAR";
            this.colODEME_MIKTAR.FieldName = "ODEME_MIKTAR";
            this.colODEME_MIKTAR_DOVIZ_ID.Caption = " ";
            this.colODEME_MIKTAR_DOVIZ_ID.Visible = true;
            this.colODEME_MIKTAR_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colODEME_MIKTAR_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colODEME_MIKTAR_DOVIZ_ID.VisibleIndex = 16;
            this.colODEME_MIKTAR_DOVIZ_ID.Name = "colODEME_MIKTAR_DOVIZ_ID";
            this.colODEME_KIM_ADINA.Caption = "Ödeme Kim Adına";
            this.colODEME_KIM_ADINA.Visible = true;
            this.colODEME_KIM_ADINA.OptionsColumn.AllowEdit = false;
            this.colODEME_KIM_ADINA.OptionsColumn.ReadOnly = true;
            this.colODEME_KIM_ADINA.VisibleIndex = 17;
            this.colODEME_KIM_ADINA.Name = "colODEME_KIM_ADINA";
            this.colODEME_KIM_ADINA.FieldName = "ODEME_KIM_ADINA";
            this.colTAAHHUTE_DAGILAN_TUTAR.Caption = "Tah. Dağılan Tutar";
            this.colTAAHHUTE_DAGILAN_TUTAR.Visible = true;
            this.colTAAHHUTE_DAGILAN_TUTAR.OptionsColumn.AllowEdit = false;
            this.colTAAHHUTE_DAGILAN_TUTAR.OptionsColumn.ReadOnly = true;
            this.colTAAHHUTE_DAGILAN_TUTAR.VisibleIndex = 18;
            this.colTAAHHUTE_DAGILAN_TUTAR.Name = "colTAAHHUTE_DAGILAN_TUTAR";
            this.colTAAHHUTE_DAGILAN_TUTAR.FieldName = "TAAHHUTE_DAGILAN_TUTAR";
            this.colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID.Caption = " ";
            this.colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID.Visible = true;
            this.colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID.VisibleIndex = 19;
            this.colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID.Name = "colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID";
            this.colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID.FieldName = "TAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID";
            this.colTAAHHUTE_DAGILMA_TARIHI.Caption = "Tah. Dağılma T";
            this.colTAAHHUTE_DAGILMA_TARIHI.Visible = true;
            this.colTAAHHUTE_DAGILMA_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTAAHHUTE_DAGILMA_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTAAHHUTE_DAGILMA_TARIHI.VisibleIndex = 20;
            this.colTAAHHUTE_DAGILMA_TARIHI.Name = "colTAAHHUTE_DAGILMA_TARIHI";
            this.colTAAHHUTE_DAGILMA_TARIHI.FieldName = "TAAHHUTE_DAGILMA_TARIHI";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            colALACAK_NEDEN_ID.ColumnEdit = this.rLueOdAlacakNEden;
            colODEYEN_CARI_ID.ColumnEdit = this.rLueOdeyenCariID;
            colODENEN_CARI_ID.ColumnEdit = this.rLueOdeyenCariID;
            colBORCLU_ADINA_ODEYEN_CARI_ID.ColumnEdit = this.rLueOdeyenCariID;
            colBORCLU_ADINA_ODENEN_CARI_ID.ColumnEdit = this.rLueOdeyenCariID;
            colODEME_YER_ID.ColumnEdit = this.rLueOdemeYerID;
            colMAAS_HACZINDEN_MI.ColumnEdit = this.chkMaasHacizdenmi;
            colIHTIYATI_HACIZDE_MI.ColumnEdit = this.chkMaasHacizdenmi;
            colODEME_TARIHI.ColumnEdit = this.deOdemeTarihi;
            colICRADAN_CEKILME_TARIHI.ColumnEdit = this.deOdemeTarihi;
            colODEME_TIP_ID.ColumnEdit = this.rLueOdemeTip;
            colKIYMETLI_EVRAK_VADE_TARIHI.ColumnEdit = this.deOdemeTarihi;
            colKIYMETLI_EVRAK_VADESINDE_ODENDI_MI.ColumnEdit = this.chkMaasHacizdenmi;
            colKIYMETLI_EVRAK_ODENDI_MI.ColumnEdit = this.chkMaasHacizdenmi;
            colODEME_MIKTAR.ColumnEdit = this.seOdemeTutar;
            colODEME_MIKTAR_DOVIZ_ID.ColumnEdit = this.rLueOdDovizTip;
            colTAAHHUTE_DAGILAN_TUTAR.ColumnEdit = this.seOdemeTutar;
            colTAAHHUTE_DAGILAN_TUTAR_DOVIZ_ID.ColumnEdit = this.rLueOdDovizTip;
            colTAAHHUTE_DAGILMA_TARIHI.ColumnEdit = this.deOdemeTarihi;
            BorcluOdemeLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Ödemeler Grid Columnlarının Oluşturulması

        #region İtiraz Alacak Neden Bilgileri Grid Columnlarının Oluşturulmnası

        private GridColumn[] GetItirazAlacakNedenGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colITALACAK_NEDEN_ID,
                                        this.colITIRAZ_EDEN_TARAF_ID,
                                        this.colBORCA_ITIRAZ_VARMI,
                                        this.colIMZAYA_ITIRAZ_VARMI,
                                        this.colYETKIYE_ITIRAZ_VARMI,
                                        this.colGOREVE_ITIRAZ_VARMI,
                                        this.colICRA_ITIRAZ_SEBEP_ID,
                                        this.colITIRAZ_BEYAN_SEKLI,
                                        this.colITIRAZ_KAPSAMI,
                                        this.colitADLI_BIRIM_ADLIYE_ID,
                                        this.colitADLI_BIRIM_GOREV_ID,
                                        this.colitADLI_BIRIM_NO_ID,
                                        this.colITIRAZ_ESAS_NO,
                                        this.colITIRAZ_TARIHI,
                                        this.colITIRAZ_TUTARI,
                                        this.colITIRAZ_TUTARI_DOVIZ_ID,
                                        this.colFAIZE_ITIRAZ_TUTARI,
                                        this.colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID,
                                        this.colITIRAZIN_GIDERILME_YOL_ID,
                                        this.colITIRAZ_SONUC_ID,
                                        this.colITIRAZ_SONUCU_KESINLESME_TARIHI,
                                        this.colDAVASI_ACILDI_MI,
                                        this.colGECIKMIS_ITIRAZ_MI,
                                        this.colKABUL_EDILEN_TUTAR,
                                        this.colKABUL_EDILEN_TUTAR_DOVIZ_ID,
                                        this.colANA_PARA_ITIRAZ_TUTARI,
                                        this.colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID,
                                        this.colHUKMEDILEN_TAZMINAT,
                                        this.colHUKMEDILEN_TAZMINAT_DOVIZ_ID,
                                        this.colITIRAZDAN_VAZGECME_TARIHI,
                                        this.colITIRAZ_KALDIRILMA_IHTAR_TARIHI,
                                        this.colSON_ITIRAZ_TARIHI,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colITALACAK_NEDEN_ID.Caption = "Alacak Neden";
            this.colITALACAK_NEDEN_ID.Visible = true;
            this.colITALACAK_NEDEN_ID.OptionsColumn.AllowEdit = false;
            this.colITALACAK_NEDEN_ID.OptionsColumn.ReadOnly = true;
            this.colITALACAK_NEDEN_ID.VisibleIndex = 1;
            this.colITALACAK_NEDEN_ID.Name = "colITALACAK_NEDEN_ID";
            this.colITALACAK_NEDEN_ID.FieldName = "ALACAK_NEDEN_ID";
            this.colITIRAZ_EDEN_TARAF_ID.Caption = "İtiraz Eden";
            this.colITIRAZ_EDEN_TARAF_ID.Visible = true;
            this.colITIRAZ_EDEN_TARAF_ID.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_EDEN_TARAF_ID.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_EDEN_TARAF_ID.VisibleIndex = 2;
            this.colITIRAZ_EDEN_TARAF_ID.Name = "colITIRAZ_EDEN_TARAF_ID";
            this.colITIRAZ_EDEN_TARAF_ID.FieldName = "ITIRAZ_EDEN_TARAF_ID";
            this.colBORCA_ITIRAZ_VARMI.Caption = "Borca İtiraz";
            this.colBORCA_ITIRAZ_VARMI.Visible = true;
            this.colBORCA_ITIRAZ_VARMI.OptionsColumn.AllowEdit = false;
            this.colBORCA_ITIRAZ_VARMI.OptionsColumn.ReadOnly = true;
            this.colBORCA_ITIRAZ_VARMI.VisibleIndex = 3;
            this.colBORCA_ITIRAZ_VARMI.Name = "colBORCA_ITIRAZ_VARMI";
            this.colBORCA_ITIRAZ_VARMI.FieldName = "BORCA_ITIRAZ_VARMI";
            this.colYETKIYE_ITIRAZ_VARMI.Caption = "Yetkiye İtiraz";
            this.colYETKIYE_ITIRAZ_VARMI.Visible = true;
            this.colYETKIYE_ITIRAZ_VARMI.OptionsColumn.AllowEdit = false;
            this.colYETKIYE_ITIRAZ_VARMI.OptionsColumn.ReadOnly = true;
            this.colYETKIYE_ITIRAZ_VARMI.VisibleIndex = 4;
            this.colYETKIYE_ITIRAZ_VARMI.Name = "colYETKIYE_ITIRAZ_VARMI";
            this.colYETKIYE_ITIRAZ_VARMI.FieldName = "YETKIYE_ITIRAZ_VARMI";
            this.colGOREVE_ITIRAZ_VARMI.Caption = "Göreve İtiraz";
            this.colGOREVE_ITIRAZ_VARMI.Visible = true;
            this.colGOREVE_ITIRAZ_VARMI.OptionsColumn.AllowEdit = false;
            this.colGOREVE_ITIRAZ_VARMI.OptionsColumn.ReadOnly = true;
            this.colGOREVE_ITIRAZ_VARMI.VisibleIndex = 5;
            this.colGOREVE_ITIRAZ_VARMI.Name = "colGOREVE_ITIRAZ_VARMI";
            this.colGOREVE_ITIRAZ_VARMI.FieldName = "GOREVE_ITIRAZ_VARMI";
            this.colICRA_ITIRAZ_SEBEP_ID.Caption = "İtiraz Sebeb";
            this.colICRA_ITIRAZ_SEBEP_ID.Visible = true;
            this.colICRA_ITIRAZ_SEBEP_ID.OptionsColumn.AllowEdit = false;
            this.colICRA_ITIRAZ_SEBEP_ID.OptionsColumn.ReadOnly = true;
            this.colICRA_ITIRAZ_SEBEP_ID.VisibleIndex = 6;
            this.colICRA_ITIRAZ_SEBEP_ID.Name = "colICRA_ITIRAZ_SEBEP_ID";
            this.colICRA_ITIRAZ_SEBEP_ID.FieldName = "ICRA_ITIRAZ_SEBEP_ID";
            this.colITIRAZ_BEYAN_SEKLI.Caption = "İtiraz Beyen Şekli";
            this.colITIRAZ_BEYAN_SEKLI.Visible = true;
            this.colITIRAZ_BEYAN_SEKLI.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_BEYAN_SEKLI.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_BEYAN_SEKLI.VisibleIndex = 7;
            this.colITIRAZ_BEYAN_SEKLI.Name = "colITIRAZ_BEYAN_SEKLI";
            this.colITIRAZ_BEYAN_SEKLI.FieldName = "ITIRAZ_BEYAN_SEKLI";
            this.colITIRAZ_KAPSAMI.Caption = "İtiraz Kapsamı";
            this.colITIRAZ_KAPSAMI.Visible = true;
            this.colITIRAZ_KAPSAMI.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_KAPSAMI.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_KAPSAMI.VisibleIndex = 8;
            this.colITIRAZ_KAPSAMI.Name = "colITIRAZ_KAPSAMI";
            this.colITIRAZ_KAPSAMI.FieldName = "ITIRAZ_KAPSAMI";
            this.colitADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colitADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colitADLI_BIRIM_ADLIYE_ID.OptionsColumn.AllowEdit = false;
            this.colitADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colitADLI_BIRIM_ADLIYE_ID.VisibleIndex = 9;
            this.colitADLI_BIRIM_ADLIYE_ID.Name = "colitADLI_BIRIM_ADLIYE_ID";
            this.colitADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colitADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colitADLI_BIRIM_GOREV_ID.Visible = true;
            this.colitADLI_BIRIM_GOREV_ID.OptionsColumn.AllowEdit = false;
            this.colitADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colitADLI_BIRIM_GOREV_ID.VisibleIndex = 10;
            this.colitADLI_BIRIM_GOREV_ID.Name = "colitADLI_BIRIM_GOREV_ID";
            this.colitADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colitADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colitADLI_BIRIM_NO_ID.Visible = true;
            this.colitADLI_BIRIM_NO_ID.OptionsColumn.AllowEdit = false;
            this.colitADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colitADLI_BIRIM_NO_ID.VisibleIndex = 11;
            this.colitADLI_BIRIM_NO_ID.Name = "colitADLI_BIRIM_NO_ID";
            this.colitADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colITIRAZ_ESAS_NO.Caption = "Esas NO";
            this.colITIRAZ_ESAS_NO.Visible = true;
            this.colITIRAZ_ESAS_NO.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_ESAS_NO.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_ESAS_NO.VisibleIndex = 12;
            this.colITIRAZ_ESAS_NO.Name = "colITIRAZ_ESAS_NO";
            this.colITIRAZ_ESAS_NO.FieldName = "ITIRAZ_ESAS_NO";
            this.colITIRAZ_TARIHI.Caption = "İtiraz T";
            this.colITIRAZ_TARIHI.Visible = true;
            this.colITIRAZ_TARIHI.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_TARIHI.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_TARIHI.VisibleIndex = 13;
            this.colITIRAZ_TARIHI.Name = "ITIRAZ_TARIHI";
            this.colITIRAZ_TARIHI.FieldName = "ITIRAZ_TARIHI";
            this.colITIRAZ_TUTARI.Caption = "İtiraz Tutarı";
            this.colITIRAZ_TUTARI.Visible = true;
            this.colITIRAZ_TUTARI.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_TUTARI.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_TUTARI.VisibleIndex = 14;
            this.colITIRAZ_TUTARI.Name = "colITIRAZ_TUTARI";
            this.colITIRAZ_TUTARI.FieldName = "ITIRAZ_TUTARI";
            this.colITIRAZ_TUTARI_DOVIZ_ID.Caption = "  ";
            this.colITIRAZ_TUTARI_DOVIZ_ID.Visible = true;
            this.colITIRAZ_TUTARI_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_TUTARI_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_TUTARI_DOVIZ_ID.VisibleIndex = 15;
            this.colITIRAZ_TUTARI_DOVIZ_ID.Name = "colITIRAZ_TUTARI_DOVIZ_ID";
            this.colITIRAZ_TUTARI_DOVIZ_ID.FieldName = "ITIRAZ_TUTARI_DOVIZ_ID";
            this.colFAIZE_ITIRAZ_TUTARI.Caption = "Faize İtiraz Tutar";
            this.colFAIZE_ITIRAZ_TUTARI.Visible = true;
            this.colFAIZE_ITIRAZ_TUTARI.OptionsColumn.AllowEdit = false;
            this.colFAIZE_ITIRAZ_TUTARI.OptionsColumn.ReadOnly = true;
            this.colFAIZE_ITIRAZ_TUTARI.VisibleIndex = 16;
            this.colFAIZE_ITIRAZ_TUTARI.Name = "colFAIZE_ITIRAZ_TUTARI";
            this.colFAIZE_ITIRAZ_TUTARI.FieldName = "FAIZE_ITIRAZ_TUTARI";
            this.colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.Caption = "  ";
            this.colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.Visible = true;
            this.colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.VisibleIndex = 17;
            this.colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.Name = "colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID";
            this.colFAIZE_ITIRAZ_TUTARI_DOVIZ_ID.FieldName = "FAIZE_ITIRAZ_TUTARI_DOVIZ_ID";
            this.colITIRAZIN_GIDERILME_YOL_ID.Caption = "İtiraz Gderilme Yol";
            this.colITIRAZIN_GIDERILME_YOL_ID.Visible = true;
            this.colITIRAZIN_GIDERILME_YOL_ID.OptionsColumn.AllowEdit = false;
            this.colITIRAZIN_GIDERILME_YOL_ID.OptionsColumn.ReadOnly = true;
            this.colITIRAZIN_GIDERILME_YOL_ID.VisibleIndex = 18;
            this.colITIRAZIN_GIDERILME_YOL_ID.Name = "colITIRAZIN_GIDERILME_YOL_ID";
            this.colITIRAZIN_GIDERILME_YOL_ID.FieldName = "ITIRAZIN_GIDERILME_YOL_ID";
            this.colITIRAZ_SONUC_ID.Caption = "İtiraz Sonuç";
            this.colITIRAZ_SONUC_ID.Visible = true;
            this.colITIRAZ_SONUC_ID.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_SONUC_ID.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_SONUC_ID.VisibleIndex = 19;
            this.colITIRAZ_SONUC_ID.Name = "colITIRAZ_SONUC_ID";
            this.colITIRAZ_SONUC_ID.FieldName = "ITIRAZ_SONUC_ID";
            this.colITIRAZ_SONUCU_KESINLESME_TARIHI.Caption = "Kesinleşme T";
            this.colITIRAZ_SONUCU_KESINLESME_TARIHI.Visible = true;
            this.colITIRAZ_SONUCU_KESINLESME_TARIHI.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_SONUCU_KESINLESME_TARIHI.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_SONUCU_KESINLESME_TARIHI.VisibleIndex = 20;
            this.colITIRAZ_SONUCU_KESINLESME_TARIHI.Name = "colITIRAZ_SONUCU_KESINLESME_TARIHI";
            this.colITIRAZ_SONUCU_KESINLESME_TARIHI.FieldName = "ITIRAZ_SONUCU_KESINLESME_TARIHI";
            this.colDAVASI_ACILDI_MI.Caption = "Davası Açıldı";
            this.colDAVASI_ACILDI_MI.Visible = true;
            this.colDAVASI_ACILDI_MI.OptionsColumn.AllowEdit = false;
            this.colDAVASI_ACILDI_MI.OptionsColumn.ReadOnly = true;
            this.colDAVASI_ACILDI_MI.VisibleIndex = 21;
            this.colDAVASI_ACILDI_MI.Name = "colDAVASI_ACILDI_MI";
            this.colDAVASI_ACILDI_MI.FieldName = "DAVASI_ACILDI_MI";
            this.colGECIKMIS_ITIRAZ_MI.Caption = "Gecikmiş İtiraz";
            this.colGECIKMIS_ITIRAZ_MI.Visible = true;
            this.colGECIKMIS_ITIRAZ_MI.OptionsColumn.AllowEdit = false;
            this.colGECIKMIS_ITIRAZ_MI.OptionsColumn.ReadOnly = true;
            this.colGECIKMIS_ITIRAZ_MI.VisibleIndex = 22;
            this.colGECIKMIS_ITIRAZ_MI.Name = "colGECIKMIS_ITIRAZ_MI";
            this.colGECIKMIS_ITIRAZ_MI.FieldName = "GECIKMIS_ITIRAZ_MI";
            this.colKABUL_EDILEN_TUTAR.Caption = "Kabul Edilen Tutar";
            this.colKABUL_EDILEN_TUTAR.Visible = true;
            this.colKABUL_EDILEN_TUTAR.OptionsColumn.AllowEdit = false;
            this.colKABUL_EDILEN_TUTAR.OptionsColumn.ReadOnly = true;
            this.colKABUL_EDILEN_TUTAR.VisibleIndex = 23;
            this.colKABUL_EDILEN_TUTAR.Name = "colKABUL_EDILEN_TUTAR";
            this.colKABUL_EDILEN_TUTAR.FieldName = "KABUL_EDILEN_TUTAR";
            this.colKABUL_EDILEN_TUTAR_DOVIZ_ID.Caption = "  ";
            this.colKABUL_EDILEN_TUTAR_DOVIZ_ID.Visible = true;
            this.colKABUL_EDILEN_TUTAR_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colKABUL_EDILEN_TUTAR_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colKABUL_EDILEN_TUTAR_DOVIZ_ID.VisibleIndex = 24;
            this.colKABUL_EDILEN_TUTAR_DOVIZ_ID.Name = "colKABUL_EDILEN_TUTAR_DOVIZ_ID";
            this.colKABUL_EDILEN_TUTAR_DOVIZ_ID.FieldName = "KABUL_EDILEN_TUTAR_DOVIZ_ID";
            this.colANA_PARA_ITIRAZ_TUTARI.Caption = "Ana Paraya İtiraz Tutar";
            this.colANA_PARA_ITIRAZ_TUTARI.Visible = true;
            this.colANA_PARA_ITIRAZ_TUTARI.OptionsColumn.AllowEdit = false;
            this.colANA_PARA_ITIRAZ_TUTARI.OptionsColumn.ReadOnly = true;
            this.colANA_PARA_ITIRAZ_TUTARI.VisibleIndex = 25;
            this.colANA_PARA_ITIRAZ_TUTARI.Name = "colANA_PARA_ITIRAZ_TUTARI";
            this.colANA_PARA_ITIRAZ_TUTARI.FieldName = "ANA_PARA_ITIRAZ_TUTARI";
            this.colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.Caption = "  ";
            this.colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.Visible = true;
            this.colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.VisibleIndex = 26;
            this.colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.Name = "colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID";
            this.colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.FieldName = "ANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID";
            this.colHUKMEDILEN_TAZMINAT.Caption = "Hükmedilen Tazminat";
            this.colHUKMEDILEN_TAZMINAT.Visible = true;
            this.colHUKMEDILEN_TAZMINAT.OptionsColumn.AllowEdit = false;
            this.colHUKMEDILEN_TAZMINAT.OptionsColumn.ReadOnly = true;
            this.colHUKMEDILEN_TAZMINAT.VisibleIndex = 27;
            this.colHUKMEDILEN_TAZMINAT.Name = "colHUKMEDILEN_TAZMINAT";
            this.colHUKMEDILEN_TAZMINAT.FieldName = "HUKMEDILEN_TAZMINAT";
            this.colHUKMEDILEN_TAZMINAT_DOVIZ_ID.Caption = "  ";
            this.colHUKMEDILEN_TAZMINAT_DOVIZ_ID.Visible = true;
            this.colHUKMEDILEN_TAZMINAT_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colHUKMEDILEN_TAZMINAT_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colHUKMEDILEN_TAZMINAT_DOVIZ_ID.VisibleIndex = 28;
            this.colHUKMEDILEN_TAZMINAT_DOVIZ_ID.Name = "colHUKMEDILEN_TAZMINAT_DOVIZ_ID";
            this.colHUKMEDILEN_TAZMINAT_DOVIZ_ID.FieldName = "HUKMEDILEN_TAZMINAT_DOVIZ_ID";
            this.colITIRAZDAN_VAZGECME_TARIHI.Caption = "Vazgeçme T";
            this.colITIRAZDAN_VAZGECME_TARIHI.Visible = true;
            this.colITIRAZDAN_VAZGECME_TARIHI.OptionsColumn.AllowEdit = false;
            this.colITIRAZDAN_VAZGECME_TARIHI.OptionsColumn.ReadOnly = true;
            this.colITIRAZDAN_VAZGECME_TARIHI.VisibleIndex = 29;
            this.colITIRAZDAN_VAZGECME_TARIHI.Name = "colITIRAZDAN_VAZGECME_TARIHI";
            this.colITIRAZDAN_VAZGECME_TARIHI.FieldName = "ITIRAZDAN_VAZGECME_TARIHI";
            this.colITIRAZ_KALDIRILMA_IHTAR_TARIHI.Caption = "Kaldırılma İhtar T";
            this.colITIRAZ_KALDIRILMA_IHTAR_TARIHI.Visible = true;
            this.colITIRAZ_KALDIRILMA_IHTAR_TARIHI.OptionsColumn.AllowEdit = false;
            this.colITIRAZ_KALDIRILMA_IHTAR_TARIHI.OptionsColumn.ReadOnly = true;
            this.colITIRAZ_KALDIRILMA_IHTAR_TARIHI.VisibleIndex = 30;
            this.colITIRAZ_KALDIRILMA_IHTAR_TARIHI.Name = "colITIRAZ_KALDIRILMA_IHTAR_TARIHI";
            this.colITIRAZ_KALDIRILMA_IHTAR_TARIHI.FieldName = "ITIRAZ_KALDIRILMA_IHTAR_TARIHI";
            this.colSON_ITIRAZ_TARIHI.Caption = "Son İtiraz T";
            this.colSON_ITIRAZ_TARIHI.Visible = true;
            this.colSON_ITIRAZ_TARIHI.OptionsColumn.AllowEdit = false;
            this.colSON_ITIRAZ_TARIHI.OptionsColumn.ReadOnly = true;
            this.colSON_ITIRAZ_TARIHI.VisibleIndex = 31;
            this.colSON_ITIRAZ_TARIHI.Name = "colSON_ITIRAZ_TARIHI";
            this.colSON_ITIRAZ_TARIHI.FieldName = "SON_ITIRAZ_TARIHI";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            colITALACAK_NEDEN_ID.ColumnEdit = this.rLueitirazAlacakNeden;
            colITIRAZ_EDEN_TARAF_ID.ColumnEdit = this.rLueitirazEdenTarafCariID;
            colBORCA_ITIRAZ_VARMI.ColumnEdit = this.chkBorcaItirazVar;
            colIMZAYA_ITIRAZ_VARMI.ColumnEdit = this.chkBorcaItirazVar;
            colYETKIYE_ITIRAZ_VARMI.ColumnEdit = this.chkBorcaItirazVar;
            colGOREVE_ITIRAZ_VARMI.ColumnEdit = this.chkBorcaItirazVar;
            colICRA_ITIRAZ_SEBEP_ID.ColumnEdit = this.rLueItirazSebebID;
            colitADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueItirazAdliBirimAdliye;
            colitADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueItirazAdliBirimGorev;
            colitADLI_BIRIM_NO_ID.ColumnEdit = this.rLueItirazAdliBirimNo;
            colITIRAZ_TARIHI.ColumnEdit = this.deItirazTarihi;
            colITIRAZ_TUTARI.ColumnEdit = this.seItirazTutar;
            colITIRAZ_TUTARI_DOVIZ_ID.ColumnEdit = this.rLueItirazTutarDovizTip;
            colITIRAZIN_GIDERILME_YOL_ID.ColumnEdit = this.reLueItirazGiderilmeYolu;
            colITIRAZ_SONUC_ID.ColumnEdit = this.rLueItirazSonucID;
            colITIRAZ_SONUCU_KESINLESME_TARIHI.ColumnEdit = this.deItirazTarihi;
            colITIRAZDAN_VAZGECME_TARIHI.ColumnEdit = this.deItirazTarihi;
            colITIRAZ_KALDIRILMA_IHTAR_TARIHI.ColumnEdit = this.deItirazTarihi;
            colSON_ITIRAZ_TARIHI.ColumnEdit = this.deItirazTarihi;
            colDAVASI_ACILDI_MI.ColumnEdit = this.chkBorcaItirazVar;
            colGECIKMIS_ITIRAZ_MI.ColumnEdit = this.chkBorcaItirazVar;
            colKABUL_EDILEN_TUTAR.ColumnEdit = this.seItirazTutar;
            colANA_PARA_ITIRAZ_TUTARI.ColumnEdit = this.seItirazTutar;
            colHUKMEDILEN_TAZMINAT.ColumnEdit = this.seItirazTutar;
            colANA_PARA_ITIRAZ_TUTARI_DOVIZ_ID.ColumnEdit = this.rLueItirazTutarDovizTip;
            colHUKMEDILEN_TAZMINAT_DOVIZ_ID.ColumnEdit = this.rLueItirazTutarDovizTip;
            colKABUL_EDILEN_TUTAR_DOVIZ_ID.ColumnEdit = this.rLueItirazTutarDovizTip;
            ItirazAlacakNedenLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion İtiraz Alacak Neden Bilgileri Grid Columnlarının Oluşturulmnası

        #region Tespit Bilgileri Grid Columnlarının Oluşturulması

        private GridColumn[] GetTespitGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colTeADLI_BIRIM_ADLIYE_ID,
                                        this.colTeADLI_BIRIM_GOREV_ID,
                                        this.colTeADLI_BIRIM_NO_ID,
                                        this.colTeESAS_NO,
                                        this.colTeKARAR_NO,
                                        this.colTeKARAR_TARIHI,
                                        this.colTeTALEP_TARIHI,
                                        this.colTeTESPIT_KONU_ID,
                                        this.colTeRAPOR_DEGERI,
                                        this.colTeRAPOR_DEGERI_DOVIZ_ID,
                                        this.colTeBILIRKISI1_CARI_ID,
                                        this.colTeBILIRKISI2_CARI_ID,
                                        this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1,
                                        this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2,
                                        this.colTeACIKLAMA,
                                        this.colteTESPIT_YAPILAN_TARAF_ID,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colTeADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colTeADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colTeADLI_BIRIM_ADLIYE_ID.OptionsColumn.AllowEdit = false;
            this.colTeADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colTeADLI_BIRIM_ADLIYE_ID.VisibleIndex = 1;
            this.colTeADLI_BIRIM_ADLIYE_ID.Name = "colTeADLI_BIRIM_ADLIYE_ID";
            this.colTeADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colTeADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colTeADLI_BIRIM_NO_ID.Visible = true;
            this.colTeADLI_BIRIM_NO_ID.OptionsColumn.AllowEdit = false;
            this.colTeADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colTeADLI_BIRIM_NO_ID.VisibleIndex = 2;
            this.colTeADLI_BIRIM_NO_ID.Name = "colTeADLI_BIRIM_NO_ID";
            this.colTeADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colTeADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colTeADLI_BIRIM_GOREV_ID.Visible = true;
            this.colTeADLI_BIRIM_GOREV_ID.OptionsColumn.AllowEdit = false;
            this.colTeADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colTeADLI_BIRIM_GOREV_ID.VisibleIndex = 3;
            this.colTeADLI_BIRIM_GOREV_ID.Name = "colTeADLI_BIRIM_GOREV_ID";
            this.colTeADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colTeESAS_NO.Caption = "Esas No";
            this.colTeESAS_NO.Visible = true;
            this.colTeESAS_NO.OptionsColumn.AllowEdit = false;
            this.colTeESAS_NO.OptionsColumn.ReadOnly = true;
            this.colTeESAS_NO.VisibleIndex = 4;
            this.colTeESAS_NO.Name = "colTeESAS_NO";
            this.colTeESAS_NO.FieldName = "ESAS_NO";
            this.colTeKARAR_NO.Caption = "Karar No";
            this.colTeKARAR_NO.Visible = true;
            this.colTeKARAR_NO.OptionsColumn.AllowEdit = false;
            this.colTeKARAR_NO.OptionsColumn.ReadOnly = true;
            this.colTeKARAR_NO.VisibleIndex = 5;
            this.colTeKARAR_NO.Name = "colTeKARAR_NO";
            this.colTeKARAR_NO.FieldName = "KARAR_NO";
            this.colTeKARAR_TARIHI.Caption = "Karar T";
            this.colTeKARAR_TARIHI.Visible = true;
            this.colTeKARAR_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTeKARAR_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTeKARAR_TARIHI.VisibleIndex = 6;
            this.colTeKARAR_TARIHI.Name = "colTeKARAR_TARIHI";
            this.colTeKARAR_TARIHI.FieldName = "KARAR_TARIHI";
            this.colTeTALEP_TARIHI.Caption = "Talep T";
            this.colTeTALEP_TARIHI.Visible = true;
            this.colTeTALEP_TARIHI.OptionsColumn.AllowEdit = false;
            this.colTeTALEP_TARIHI.OptionsColumn.ReadOnly = true;
            this.colTeTALEP_TARIHI.VisibleIndex = 7;
            this.colTeTALEP_TARIHI.Name = "colTeTALEP_TARIHI";
            this.colTeTALEP_TARIHI.FieldName = "TALEP_TARIHI";
            this.colTeTESPIT_KONU_ID.Caption = "Tespit Konu";
            this.colTeTESPIT_KONU_ID.Visible = true;
            this.colTeTESPIT_KONU_ID.OptionsColumn.AllowEdit = false;
            this.colTeTESPIT_KONU_ID.OptionsColumn.ReadOnly = true;
            this.colTeTESPIT_KONU_ID.VisibleIndex = 8;
            this.colTeTESPIT_KONU_ID.Name = "colTeTESPIT_KONU_ID";
            this.colTeTESPIT_KONU_ID.FieldName = "TESPIT_KONU_ID";
            this.colTeRAPOR_DEGERI.Caption = "Rapor Değeri";
            this.colTeRAPOR_DEGERI.Visible = true;
            this.colTeRAPOR_DEGERI.OptionsColumn.AllowEdit = false;
            this.colTeRAPOR_DEGERI.OptionsColumn.ReadOnly = true;
            this.colTeRAPOR_DEGERI.VisibleIndex = 9;
            this.colTeRAPOR_DEGERI.Name = "colTeRAPOR_DEGERI";
            this.colTeRAPOR_DEGERI.FieldName = "RAPOR_DEGERI";
            this.colTeRAPOR_DEGERI_DOVIZ_ID.Caption = " ";
            this.colTeRAPOR_DEGERI_DOVIZ_ID.Visible = true;
            this.colTeRAPOR_DEGERI_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colTeRAPOR_DEGERI_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colTeRAPOR_DEGERI_DOVIZ_ID.VisibleIndex = 10;
            this.colTeRAPOR_DEGERI_DOVIZ_ID.Name = "colTeRAPOR_DEGERI_DOVIZ_ID";
            this.colTeRAPOR_DEGERI_DOVIZ_ID.FieldName = "RAPOR_DEGERI_DOVIZ_ID";
            this.colTeBILIRKISI1_CARI_ID.Caption = "Bilirkişi 1";
            this.colTeBILIRKISI1_CARI_ID.Visible = true;
            this.colTeBILIRKISI1_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colTeBILIRKISI1_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colTeBILIRKISI1_CARI_ID.VisibleIndex = 11;
            this.colTeBILIRKISI1_CARI_ID.Name = "colTeBILIRKISI1_CARI_ID";
            this.colTeBILIRKISI1_CARI_ID.FieldName = "BILIRKISI1_CARI_ID";
            this.colTeBILIRKISI2_CARI_ID.Caption = "Bilirkişi 2";
            this.colTeBILIRKISI2_CARI_ID.Visible = true;
            this.colTeBILIRKISI2_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colTeBILIRKISI2_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colTeBILIRKISI2_CARI_ID.VisibleIndex = 12;
            this.colTeBILIRKISI2_CARI_ID.Name = "colTeBILIRKISI2_CARI_ID";
            this.colTeBILIRKISI2_CARI_ID.FieldName = "BILIRKISI2_CARI_ID";
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1.Caption = "Bilirkişi Rapor T 1";
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1.Visible = true;
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1.OptionsColumn.AllowEdit = false;
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1.OptionsColumn.ReadOnly = true;
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1.VisibleIndex = 13;
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1.Name = "colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1";
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1.FieldName = "HACIZ_BILIRKISI_RAPOR_TARIHI_1";
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2.Caption = "Bilirkişi Rapor T 2";
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2.Visible = true;
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2.OptionsColumn.AllowEdit = false;
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2.OptionsColumn.ReadOnly = true;
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2.VisibleIndex = 14;
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2.Name = "colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2";
            this.colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2.FieldName = "HACIZ_BILIRKISI_RAPOR_TARIHI_2";
            this.colTeACIKLAMA.Caption = "Açıklama";
            this.colTeACIKLAMA.Visible = true;
            this.colTeACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colTeACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colTeACIKLAMA.VisibleIndex = 15;
            this.colTeACIKLAMA.Name = "colTeACIKLAMA";
            this.colTeACIKLAMA.FieldName = "ACIKLAMA";
            this.colteTESPIT_YAPILAN_TARAF_ID.Caption = "Tespit Yapılan";
            this.colteTESPIT_YAPILAN_TARAF_ID.Visible = true;
            this.colteTESPIT_YAPILAN_TARAF_ID.OptionsColumn.AllowEdit = false;
            this.colteTESPIT_YAPILAN_TARAF_ID.OptionsColumn.ReadOnly = true;
            this.colteTESPIT_YAPILAN_TARAF_ID.VisibleIndex = 16;
            this.colteTESPIT_YAPILAN_TARAF_ID.Name = "colteTESPIT_YAPILAN_TARAF_ID";
            this.colteTESPIT_YAPILAN_TARAF_ID.FieldName = "TESPIT_YAPILAN_TARAF_ID";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            colTeADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueTesAdliBirimAdliye;
            colTeADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueTesAdliBirimGorev;
            colTeADLI_BIRIM_NO_ID.ColumnEdit = this.rLueTesAdliBirimNo;
            colTeTESPIT_KONU_ID.ColumnEdit = this.rLueTesTespitKonuID;
            colTeRAPOR_DEGERI_DOVIZ_ID.ColumnEdit = this.rLueTesRaporDegerDovizID;
            colTeBILIRKISI1_CARI_ID.ColumnEdit = this.rLueTesCariID;
            colTeBILIRKISI2_CARI_ID.ColumnEdit = this.rLueTesCariID;
            colteTESPIT_YAPILAN_TARAF_ID.ColumnEdit = this.rLueTesCariID;
            colTeKARAR_TARIHI.ColumnEdit = this.deTesKararTarihi;
            colTeTALEP_TARIHI.ColumnEdit = this.deTesKararTarihi;
            colTeHACIZ_BILIRKISI_RAPOR_TARIHI_1.ColumnEdit = this.deTesKararTarihi;
            colTeHACIZ_BILIRKISI_RAPOR_TARIHI_2.ColumnEdit = this.deTesKararTarihi;
            colTeRAPOR_DEGERI.ColumnEdit = this.seTesRaporDegeri;
            TespitLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Tespit Bilgileri Grid Columnlarının Oluşturulması

        #region Cari Hesap ve Hesap Detay Bilgileri Grid Columlarının Oluşturulması

        private GridColumn[] GetCariHesapGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        //this.colCMASRAF_AVANS_ID ,
                                        this.colCCARI_ID,
                                        this.colCREFERANS_NO,
                                        this.colCBORC_ALACAK_ID,
                                        this.colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP,
                                        this.colCICRA_FOY_NO,
                                        this.colCDAVA_FOY_NO,
                                        this.colCHAZIRLIK_NO,
                                        this.colCRUCU_NO,
                                        this.colCKULLANICI_BELGE_NO,
                                        this.colCHAREKET_ANA_KATEGORI_ID,
                                        this.colCHAREKET_ALT_KAREGORI_ID,
                                        this.colCADET,
                                        this.colCBIRIM_FIYAT_DOVIZ_ID,
                                        this.colCBIRIM_FIYAT,
                                        this.colCGENEL_TOPLAM,
                                        this.colCDETAY_ACIKLAMA,
                                        this.colCINCELENDI,
                                        this.colCONAY_TARIHI,
                                        this.colCONAY_NO,
                                        this.colCONAY_DURUM,
                                        this.colCSUBE_KOD_ID,
                                        this.colCACIKLAMA,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            //this.colCMASRAF_AVANS_ID.Caption = "Masraf Avans";
            //this.colCMASRAF_AVANS_ID.Visible = true;
            //this.colCMASRAF_AVANS_ID.VisibleIndex = 2;
            //this.colCMASRAF_AVANS_ID.Name = "colCMASRAF_AVANS_ID";
            this.colCCARI_ID.Caption = "Şahıs";
            this.colCCARI_ID.Visible = true;
            this.colCCARI_ID.OptionsColumn.AllowEdit = false;
            this.colCCARI_ID.OptionsColumn.ReadOnly = true;
            this.colCCARI_ID.VisibleIndex = 1;
            this.colCCARI_ID.Name = "colCCARI_ID";
            this.colCCARI_ID.FieldName = "CARI_ID";
            this.colCREFERANS_NO.Caption = "Ref. No";
            this.colCREFERANS_NO.Visible = true;
            this.colCREFERANS_NO.OptionsColumn.AllowEdit = false;
            this.colCREFERANS_NO.OptionsColumn.ReadOnly = true;
            this.colCREFERANS_NO.VisibleIndex = 3;
            this.colCREFERANS_NO.Name = "colCREFERANS_NO";
            this.colCREFERANS_NO.FieldName = "REFERANS_NO";
            this.colCBORC_ALACAK_ID.Caption = "B / A";
            this.colCBORC_ALACAK_ID.Visible = true;
            this.colCBORC_ALACAK_ID.OptionsColumn.AllowEdit = false;
            this.colCBORC_ALACAK_ID.OptionsColumn.ReadOnly = true;
            this.colCBORC_ALACAK_ID.VisibleIndex = 4;
            this.colCBORC_ALACAK_ID.Name = "colCBORC_ALACAK_ID";
            this.colCBORC_ALACAK_ID.FieldName = "BORC_ALACAK_ID";
            this.colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP.Caption = "Hedef Tip";
            this.colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP.Visible = true;
            this.colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP.OptionsColumn.AllowEdit = false;
            this.colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP.OptionsColumn.ReadOnly = true;
            this.colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP.VisibleIndex = 5;
            this.colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP.Name = "colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP";
            this.colDOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP.FieldName = "DOSYA_MUH_AKTARILDICARI_HESAP_HEDEF_TIP";
            this.colCICRA_FOY_NO.Caption = "İcra Föy No";
            this.colCICRA_FOY_NO.Visible = true;
            this.colCICRA_FOY_NO.OptionsColumn.AllowEdit = false;
            this.colCICRA_FOY_NO.OptionsColumn.ReadOnly = true;
            this.colCICRA_FOY_NO.VisibleIndex = 6;
            this.colCICRA_FOY_NO.Name = "colCICRA_FOY_NO";
            this.colCICRA_FOY_NO.FieldName = "ICRA_FOY_NO";
            this.colCDAVA_FOY_NO.Caption = "Dava Föy No";
            this.colCDAVA_FOY_NO.Visible = true;
            this.colCDAVA_FOY_NO.OptionsColumn.AllowEdit = false;
            this.colCDAVA_FOY_NO.OptionsColumn.ReadOnly = true;
            this.colCDAVA_FOY_NO.VisibleIndex = 7;
            this.colCDAVA_FOY_NO.Name = "colCDAVA_FOY_NO";
            this.colCDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
            this.colCHAZIRLIK_NO.Caption = "Hazırlık No";
            this.colCHAZIRLIK_NO.Visible = true;
            this.colCHAZIRLIK_NO.OptionsColumn.AllowEdit = false;
            this.colCHAZIRLIK_NO.OptionsColumn.ReadOnly = true;
            this.colCHAZIRLIK_NO.VisibleIndex = 8;
            this.colCHAZIRLIK_NO.Name = "colCHAZIRLIK_NO";
            this.colCHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            this.colCRUCU_NO.Caption = "Rücu No";
            this.colCRUCU_NO.Visible = true;
            this.colCRUCU_NO.OptionsColumn.AllowEdit = false;
            this.colCRUCU_NO.OptionsColumn.ReadOnly = true;
            this.colCRUCU_NO.VisibleIndex = 9;
            this.colCRUCU_NO.Name = "colCRUCU_NO";
            this.colCRUCU_NO.FieldName = "RUCU_NO";
            this.colCKULLANICI_BELGE_NO.Caption = "Kullanıcı Belge No";
            this.colCKULLANICI_BELGE_NO.Visible = true;
            this.colCKULLANICI_BELGE_NO.OptionsColumn.AllowEdit = false;
            this.colCKULLANICI_BELGE_NO.OptionsColumn.ReadOnly = true;
            this.colCKULLANICI_BELGE_NO.VisibleIndex = 10;
            this.colCKULLANICI_BELGE_NO.Name = "colCKULLANICI_BELGE_NO";
            this.colCKULLANICI_BELGE_NO.FieldName = "KULLANICI_BELGE_NO";
            this.colCHAREKET_ANA_KATEGORI_ID.Caption = "Ana Kat.";
            this.colCHAREKET_ANA_KATEGORI_ID.Visible = true;
            this.colCHAREKET_ANA_KATEGORI_ID.OptionsColumn.AllowEdit = false;
            this.colCHAREKET_ANA_KATEGORI_ID.OptionsColumn.ReadOnly = true;
            this.colCHAREKET_ANA_KATEGORI_ID.VisibleIndex = 11;
            this.colCHAREKET_ANA_KATEGORI_ID.Name = "colCHAREKET_ANA_KATEGORI_ID";
            this.colCHAREKET_ANA_KATEGORI_ID.FieldName = "HAREKET_ANA_KATEGORI_ID";
            this.colCHAREKET_ALT_KAREGORI_ID.Caption = "Alt Kat.";
            this.colCHAREKET_ALT_KAREGORI_ID.Visible = true;
            this.colCHAREKET_ALT_KAREGORI_ID.OptionsColumn.AllowEdit = false;
            this.colCHAREKET_ALT_KAREGORI_ID.OptionsColumn.ReadOnly = true;
            this.colCHAREKET_ALT_KAREGORI_ID.VisibleIndex = 12;
            this.colCHAREKET_ALT_KAREGORI_ID.Name = "colCHAREKET_ALT_KAREGORI_ID";
            this.colCHAREKET_ALT_KAREGORI_ID.FieldName = "HAREKET_ALT_KAREGORI_ID";
            this.colCADET.Caption = "Adet";
            this.colCADET.Visible = true;
            this.colCADET.OptionsColumn.AllowEdit = false;
            this.colCADET.OptionsColumn.ReadOnly = true;
            this.colCADET.VisibleIndex = 13;
            this.colCADET.Name = "colCADET";
            this.colCADET.FieldName = "ADET";
            this.colCBIRIM_FIYAT.Caption = "Birim Fiyat";
            this.colCBIRIM_FIYAT.Visible = true;
            this.colCBIRIM_FIYAT.OptionsColumn.AllowEdit = false;
            this.colCBIRIM_FIYAT.OptionsColumn.ReadOnly = true;
            this.colCBIRIM_FIYAT.VisibleIndex = 14;
            this.colCBIRIM_FIYAT.Name = "colCBIRIM_FIYAT";
            this.colCBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            this.colCBIRIM_FIYAT_DOVIZ_ID.Caption = " ";
            this.colCBIRIM_FIYAT_DOVIZ_ID.Visible = true;
            this.colCBIRIM_FIYAT_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colCBIRIM_FIYAT_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colCBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 15;
            this.colCBIRIM_FIYAT_DOVIZ_ID.Name = "colCBIRIM_FIYAT_DOVIZ_ID";
            this.colCBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            this.colCGENEL_TOPLAM.Caption = "Genel Toplam";
            this.colCGENEL_TOPLAM.Visible = true;
            this.colCGENEL_TOPLAM.OptionsColumn.AllowEdit = false;
            this.colCGENEL_TOPLAM.OptionsColumn.ReadOnly = true;
            this.colCGENEL_TOPLAM.VisibleIndex = 16;
            this.colCGENEL_TOPLAM.Name = "colCGENEL_TOPLAM";
            this.colCGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            this.colCDETAY_ACIKLAMA.Caption = "Detay Açıklama";
            this.colCDETAY_ACIKLAMA.Visible = true;
            this.colCDETAY_ACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colCDETAY_ACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colCDETAY_ACIKLAMA.VisibleIndex = 17;
            this.colCDETAY_ACIKLAMA.Name = "colCDETAY_ACIKLAMA";
            this.colCDETAY_ACIKLAMA.FieldName = "DETAY_ACIKLAMA";
            this.colCINCELENDI.Caption = "İncelendi";
            this.colCINCELENDI.Visible = true;
            this.colCINCELENDI.OptionsColumn.AllowEdit = false;
            this.colCINCELENDI.OptionsColumn.ReadOnly = true;
            this.colCINCELENDI.VisibleIndex = 18;
            this.colCINCELENDI.Name = "colCINCELENDI";
            this.colCINCELENDI.FieldName = "INCELENDI";
            this.colCONAY_TARIHI.Caption = "Onay T";
            this.colCONAY_TARIHI.Visible = true;
            this.colCONAY_TARIHI.OptionsColumn.AllowEdit = false;
            this.colCONAY_TARIHI.OptionsColumn.ReadOnly = true;
            this.colCONAY_TARIHI.VisibleIndex = 19;
            this.colCONAY_TARIHI.Name = "colCONAY_TARIHI";
            this.colCONAY_TARIHI.FieldName = "ONAY_TARIHI";
            this.colCONAY_NO.Caption = "Onay No";
            this.colCONAY_NO.Visible = true;
            this.colCONAY_NO.OptionsColumn.AllowEdit = false;
            this.colCONAY_NO.OptionsColumn.ReadOnly = true;
            this.colCONAY_NO.VisibleIndex = 20;
            this.colCONAY_NO.Name = "colCONAY_NO";
            this.colCONAY_NO.FieldName = "ONAY_NO";
            this.colCONAY_DURUM.Caption = "Onay Durum";
            this.colCONAY_DURUM.Visible = true;
            this.colCONAY_DURUM.OptionsColumn.AllowEdit = false;
            this.colCONAY_DURUM.OptionsColumn.ReadOnly = true;
            this.colCONAY_DURUM.VisibleIndex = 21;
            this.colCONAY_DURUM.Name = "colCONAY_DURUM";
            this.colCONAY_DURUM.FieldName = "ONAY_DURUM";
            this.colCSUBE_KOD_ID.Caption = "Büro";
            this.colCSUBE_KOD_ID.Visible = true;
            this.colCSUBE_KOD_ID.OptionsColumn.AllowEdit = false;
            this.colCSUBE_KOD_ID.OptionsColumn.ReadOnly = true;
            this.colCSUBE_KOD_ID.VisibleIndex = 22;
            this.colCSUBE_KOD_ID.Name = "colCSUBE_KOD_ID";
            this.colCSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            this.colCACIKLAMA.Caption = "colCACIKLAMA";
            this.colCACIKLAMA.Visible = true;
            this.colCACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colCACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colCACIKLAMA.VisibleIndex = 23;
            this.colCACIKLAMA.Name = "colCACIKLAMA";
            this.colCACIKLAMA.FieldName = "ACIKLAMA";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            //colCMASRAF_AVANS_ID.ColumnEdit = this.rLueCMasrafAvans;
            colCCARI_ID.ColumnEdit = this.rLueCCariID;
            colCBORC_ALACAK_ID.ColumnEdit = this.rLueCBorcAlacak;
            colCHAREKET_ANA_KATEGORI_ID.ColumnEdit = this.rLueCHareketAnaKategori;
            colCHAREKET_ALT_KAREGORI_ID.ColumnEdit = this.rLueCHareketAltKategori;
            colCADET.ColumnEdit = this.seCAdet;
            colCBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = this.rLueCDovizID;
            colCBIRIM_FIYAT.ColumnEdit = this.seCAdet;
            colCGENEL_TOPLAM.ColumnEdit = this.seCAdet;
            colCINCELENDI.ColumnEdit = this.chkcIncelendi;
            colCONAY_TARIHI.ColumnEdit = this.decOnayTarihi;
            colCSUBE_KOD_ID.ColumnEdit = this.rLueSubeKoduBuroID;
            CariHesapLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Cari Hesap ve Hesap Detay Bilgileri Grid Columlarının Oluşturulması

        #region Masraf Avans Bilgileri Grid Columnlarının Oluşturulması

        private GridColumn[] GetMasrafAvansGrid()
        {
            GridColumn[] dizi = new[]
                                    {
                                        this.colMCARI_ID,
                                        this.colMAVANS_REFERANS_NO,
                                        this.colMMASRAF_AVANS_TIP,
                                        this.colMACIKLAMA,
                                        this.colMKAYIT_TARIHI,
                                        this.colMBORCLU_CARI_ID,
                                        this.colMTARIH,
                                        this.colMKULLANICI_BELGE_NO,
                                        this.colMBORC_ALACAK_ID,
                                        this.colMODEME_TIP_ID,
                                        this.colMHAREKET_ANA_KATEGORI_ID,
                                        this.colMHAREKET_ALT_KATEGORI_ID,
                                        this.colMADET,
                                        this.colMBIRIM_FIYAT,
                                        this.colMBIRIM_FIYAT_DOVIZ_ID,
                                        this.colMKDV_DAHIL,
                                        this.colMKDV_ORAN,
                                        this.colMKDV_TUTAR,
                                        this.colMSTOPAJ_SSDF_DAHIL,
                                        this.colMSTOPAJ_ORAN,
                                        this.colMSSDF_ORAN,
                                        this.colMSTOPAJ_SSDF_TUTAR,
                                        this.colMTOPLAM_TUTAR,
                                        this.colMGENEL_TOPLAM,
                                        this.colMTUM_MUVEKKILLERE_PAYLASTIR,
                                        this.colMMUVEKKIL_CARI_ID,
                                        this.colMINCELENDI,
                                        this.colMONAY_TARIHI,
                                        this.colMONAY_NO,
                                        this.colMONAY_DURUM,
                                        this.colMDETAY_ACIKLAMA,
                                        this.colMFOY_NO,
                                        this.colMADLI_BIRIM_ADLIYE_ID,
                                        this.colMADLI_BIRIM_GOREV_ID,
                                        this.colMADLI_BIRIM_NO_ID,
                                        this.colMESAS_NO,
                                        this.colMTAKIP_T,
                                        this.colMREFERANS_NO2,
                                        this.colMREFERANS_NO3,
                                        this.colMREFERANS_NO,
                                        this.colMOZEL_KOD1,
                                        this.colMOZEL_KOD2,
                                        this.colMOZEL_KOD3,
                                        this.colMOZEL_KOD4,
                                        this.colMTARAF_KODU,
                                        this.colMTARAF_CARI_ID,
                                        this.colMTARAF_SIFAT_ID,
                                        this.colMTipi,
                                    };

            #region caption visible visibleIndex name  leri verildi coLumnların

            this.colMCARI_ID.Caption = "Şahıs";
            this.colMCARI_ID.Visible = true;
            this.colMCARI_ID.OptionsColumn.AllowEdit = false;
            this.colMCARI_ID.OptionsColumn.ReadOnly = true;
            this.colMCARI_ID.VisibleIndex = 1;
            this.colMCARI_ID.Name = "colMCARI_ID";
            this.colMCARI_ID.FieldName = "CARI_ID";
            this.colMAVANS_REFERANS_NO.Caption = "M. A. Ref. No";
            this.colMAVANS_REFERANS_NO.Visible = true;
            this.colMAVANS_REFERANS_NO.OptionsColumn.AllowEdit = false;
            this.colMAVANS_REFERANS_NO.OptionsColumn.ReadOnly = true;
            this.colMAVANS_REFERANS_NO.VisibleIndex = 2;
            this.colMAVANS_REFERANS_NO.Name = "colMAVANS_REFERANS_NO";
            this.colMAVANS_REFERANS_NO.FieldName = "AVANS_REFERANS_NO";
            this.colMMASRAF_AVANS_TIP.Caption = "M. A. Tipi";
            this.colMMASRAF_AVANS_TIP.Visible = true;
            this.colMMASRAF_AVANS_TIP.OptionsColumn.AllowEdit = false;
            this.colMMASRAF_AVANS_TIP.OptionsColumn.ReadOnly = true;
            this.colMMASRAF_AVANS_TIP.VisibleIndex = 3;
            this.colMMASRAF_AVANS_TIP.Name = "colMMASRAF_AVANS_TIP";
            this.colMMASRAF_AVANS_TIP.FieldName = "MASRAF_AVANS_TIP";
            this.colMACIKLAMA.Caption = "Açıklama";
            this.colMACIKLAMA.Visible = true;
            this.colMACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colMACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colMACIKLAMA.VisibleIndex = 4;
            this.colMACIKLAMA.Name = "colMACIKLAMA";
            this.colMACIKLAMA.FieldName = "ACIKLAMA";
            this.colMKAYIT_TARIHI.Caption = "Kayıt T";
            this.colMKAYIT_TARIHI.Visible = true;
            this.colMKAYIT_TARIHI.OptionsColumn.AllowEdit = false;
            this.colMKAYIT_TARIHI.OptionsColumn.ReadOnly = true;
            this.colMKAYIT_TARIHI.VisibleIndex = 5;
            this.colMKAYIT_TARIHI.Name = "colMKAYIT_TARIHI";
            this.colMKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            this.colMBORCLU_CARI_ID.Caption = "Borçlu";
            this.colMBORCLU_CARI_ID.Visible = true;
            this.colMBORCLU_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colMBORCLU_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colMBORCLU_CARI_ID.VisibleIndex = 6;
            this.colMBORCLU_CARI_ID.Name = "colMBORCLU_CARI_ID";
            this.colMBORCLU_CARI_ID.FieldName = "BORCLU_CARI_ID";
            this.colMTARIH.Caption = "Tarih";
            this.colMTARIH.Visible = true;
            this.colMTARIH.OptionsColumn.AllowEdit = false;
            this.colMTARIH.OptionsColumn.ReadOnly = true;
            this.colMTARIH.VisibleIndex = 7;
            this.colMTARIH.Name = "colMTARIH";
            this.colMTARIH.FieldName = "TARIH";
            this.colMKULLANICI_BELGE_NO.Caption = "Kull. Belge No";
            this.colMKULLANICI_BELGE_NO.Visible = true;
            this.colMKULLANICI_BELGE_NO.OptionsColumn.AllowEdit = false;
            this.colMKULLANICI_BELGE_NO.OptionsColumn.ReadOnly = true;
            this.colMKULLANICI_BELGE_NO.VisibleIndex = 8;
            this.colMKULLANICI_BELGE_NO.Name = "colMKULLANICI_BELGE_NO";
            this.colMKULLANICI_BELGE_NO.FieldName = "KULLANICI_BELGE_NO";
            this.colMBORC_ALACAK_ID.Caption = "B/A";
            this.colMBORC_ALACAK_ID.Visible = true;
            this.colMBORC_ALACAK_ID.OptionsColumn.AllowEdit = false;
            this.colMBORC_ALACAK_ID.OptionsColumn.ReadOnly = true;
            this.colMBORC_ALACAK_ID.VisibleIndex = 9;
            this.colMBORC_ALACAK_ID.Name = "colMBORC_ALACAK_ID";
            this.colMBORC_ALACAK_ID.FieldName = "BORC_ALACAK_ID";
            this.colMODEME_TIP_ID.Caption = "Ödeme Tipi";
            this.colMODEME_TIP_ID.Visible = true;
            this.colMODEME_TIP_ID.OptionsColumn.AllowEdit = false;
            this.colMODEME_TIP_ID.OptionsColumn.ReadOnly = true;
            this.colMODEME_TIP_ID.VisibleIndex = 10;
            this.colMODEME_TIP_ID.Name = "colMODEME_TIP_ID";
            this.colMODEME_TIP_ID.FieldName = "ODEME_TIP_ID";
            this.colMHAREKET_ANA_KATEGORI_ID.Caption = "Ana Kat.";
            this.colMHAREKET_ANA_KATEGORI_ID.Visible = true;
            this.colMHAREKET_ANA_KATEGORI_ID.OptionsColumn.AllowEdit = false;
            this.colMHAREKET_ANA_KATEGORI_ID.OptionsColumn.ReadOnly = true;
            this.colMHAREKET_ANA_KATEGORI_ID.VisibleIndex = 11;
            this.colMHAREKET_ANA_KATEGORI_ID.Name = "colMHAREKET_ANA_KATEGORI_ID";
            this.colMHAREKET_ANA_KATEGORI_ID.FieldName = "HAREKET_ANA_KATEGORI_ID";
            this.colMHAREKET_ALT_KATEGORI_ID.Caption = "Alt Kat.";
            this.colMHAREKET_ALT_KATEGORI_ID.Visible = true;
            this.colMHAREKET_ALT_KATEGORI_ID.OptionsColumn.AllowEdit = false;
            this.colMHAREKET_ALT_KATEGORI_ID.OptionsColumn.ReadOnly = true;
            this.colMHAREKET_ALT_KATEGORI_ID.VisibleIndex = 12;
            this.colMHAREKET_ALT_KATEGORI_ID.Name = "colMHAREKET_ALT_KATEGORI_ID";
            this.colMHAREKET_ALT_KATEGORI_ID.FieldName = "HAREKET_ALT_KATEGORI_ID";
            this.colMADET.Caption = "Adet";
            this.colMADET.Visible = true;
            this.colMADET.OptionsColumn.AllowEdit = false;
            this.colMADET.OptionsColumn.ReadOnly = true;
            this.colMADET.VisibleIndex = 13;
            this.colMADET.Name = "colMADET ";
            this.colMADET.FieldName = "ADET";
            this.colMBIRIM_FIYAT.Caption = "Birim Fiyat";
            this.colMBIRIM_FIYAT.Visible = true;
            this.colMBIRIM_FIYAT.OptionsColumn.AllowEdit = false;
            this.colMBIRIM_FIYAT.OptionsColumn.ReadOnly = true;
            this.colMBIRIM_FIYAT.VisibleIndex = 14;
            this.colMBIRIM_FIYAT.Name = "colMBIRIM_FIYAT";
            this.colMBIRIM_FIYAT.FieldName = "BIRIM_FIYAT";
            this.colMBIRIM_FIYAT_DOVIZ_ID.Caption = " ";
            this.colMBIRIM_FIYAT_DOVIZ_ID.Visible = true;
            this.colMBIRIM_FIYAT_DOVIZ_ID.OptionsColumn.AllowEdit = false;
            this.colMBIRIM_FIYAT_DOVIZ_ID.OptionsColumn.ReadOnly = true;
            this.colMBIRIM_FIYAT_DOVIZ_ID.VisibleIndex = 15;
            this.colMBIRIM_FIYAT_DOVIZ_ID.Name = "colMBIRIM_FIYAT_DOVIZ_ID";
            this.colMBIRIM_FIYAT_DOVIZ_ID.FieldName = "BIRIM_FIYAT_DOVIZ_ID";
            this.colMKDV_DAHIL.Caption = "KDV Dahil";
            this.colMKDV_DAHIL.Visible = true;
            this.colMKDV_DAHIL.OptionsColumn.AllowEdit = false;
            this.colMKDV_DAHIL.OptionsColumn.ReadOnly = true;
            this.colMKDV_DAHIL.VisibleIndex = 16;
            this.colMKDV_DAHIL.Name = "colMKDV_DAHIL";
            this.colMKDV_DAHIL.FieldName = "KDV_DAHIL";
            this.colMKDV_ORAN.Caption = "KDV Oran";
            this.colMKDV_ORAN.Visible = true;
            this.colMKDV_ORAN.OptionsColumn.AllowEdit = false;
            this.colMKDV_ORAN.OptionsColumn.ReadOnly = true;
            this.colMKDV_ORAN.VisibleIndex = 17;
            this.colMKDV_ORAN.Name = "colMKDV_ORAN";
            this.colMKDV_ORAN.FieldName = "KDV_ORAN";
            this.colMKDV_TUTAR.Caption = "KDV Tutar";
            this.colMKDV_TUTAR.Visible = true;
            this.colMKDV_TUTAR.OptionsColumn.AllowEdit = false;
            this.colMKDV_TUTAR.OptionsColumn.ReadOnly = true;
            this.colMKDV_TUTAR.VisibleIndex = 18;
            this.colMKDV_TUTAR.Name = "colMKDV_TUTAR";
            this.colMKDV_TUTAR.FieldName = "KDV_TUTAR";
            this.colMSTOPAJ_SSDF_DAHIL.Caption = "STOPAJ SSDF Dahil";
            this.colMSTOPAJ_SSDF_DAHIL.Visible = true;
            this.colMSTOPAJ_SSDF_DAHIL.OptionsColumn.AllowEdit = false;
            this.colMSTOPAJ_SSDF_DAHIL.OptionsColumn.ReadOnly = true;
            this.colMSTOPAJ_SSDF_DAHIL.VisibleIndex = 19;
            this.colMSTOPAJ_SSDF_DAHIL.Name = "colMSTOPAJ_SSDF_DAHIL";
            this.colMSTOPAJ_SSDF_DAHIL.FieldName = "STOPAJ_SSDF_DAHIL";
            this.colMSTOPAJ_ORAN.Caption = "STOPAJ Oran";
            this.colMSTOPAJ_ORAN.Visible = true;
            this.colMSTOPAJ_ORAN.OptionsColumn.AllowEdit = false;
            this.colMSTOPAJ_ORAN.OptionsColumn.ReadOnly = true;
            this.colMSTOPAJ_ORAN.VisibleIndex = 20;
            this.colMSTOPAJ_ORAN.Name = "colMSTOPAJ_ORAN";
            this.colMSTOPAJ_ORAN.FieldName = "STOPAJ_ORAN";
            this.colMSSDF_ORAN.Caption = "SSDF Oran";
            this.colMSSDF_ORAN.Visible = true;
            this.colMSSDF_ORAN.OptionsColumn.AllowEdit = false;
            this.colMSSDF_ORAN.OptionsColumn.ReadOnly = true;
            this.colMSSDF_ORAN.VisibleIndex = 21;
            this.colMSSDF_ORAN.Name = "colMSSDF_ORAN";
            this.colMSSDF_ORAN.FieldName = "SSDF_ORAN";
            this.colMSTOPAJ_SSDF_TUTAR.Caption = "STOPAJ SSDF Tutar";
            this.colMSTOPAJ_SSDF_TUTAR.Visible = true;
            this.colMSTOPAJ_SSDF_TUTAR.OptionsColumn.AllowEdit = false;
            this.colMSTOPAJ_SSDF_TUTAR.OptionsColumn.ReadOnly = true;
            this.colMSTOPAJ_SSDF_TUTAR.VisibleIndex = 22;
            this.colMSTOPAJ_SSDF_TUTAR.Name = "colMSTOPAJ_SSDF_TUTAR";
            this.colMSTOPAJ_SSDF_TUTAR.FieldName = "STOPAJ_SSDF_TUTAR";
            this.colMTOPLAM_TUTAR.Caption = "Toplam Tutar";
            this.colMTOPLAM_TUTAR.Visible = true;
            this.colMTOPLAM_TUTAR.OptionsColumn.AllowEdit = false;
            this.colMTOPLAM_TUTAR.OptionsColumn.ReadOnly = true;
            this.colMTOPLAM_TUTAR.VisibleIndex = 23;
            this.colMTOPLAM_TUTAR.Name = "colMTOPLAM_TUTAR";
            this.colMTOPLAM_TUTAR.FieldName = "TOPLAM_TUTAR";
            this.colMGENEL_TOPLAM.Caption = "Genel Toplam";
            this.colMGENEL_TOPLAM.Visible = true;
            this.colMGENEL_TOPLAM.OptionsColumn.AllowEdit = false;
            this.colMGENEL_TOPLAM.OptionsColumn.ReadOnly = true;
            this.colMGENEL_TOPLAM.VisibleIndex = 24;
            this.colMGENEL_TOPLAM.Name = "colMGENEL_TOPLAM";
            this.colMGENEL_TOPLAM.FieldName = "GENEL_TOPLAM";
            this.colMTUM_MUVEKKILLERE_PAYLASTIR.Caption = "Müvekkillere Pay";
            this.colMTUM_MUVEKKILLERE_PAYLASTIR.Visible = true;
            this.colMTUM_MUVEKKILLERE_PAYLASTIR.OptionsColumn.AllowEdit = false;
            this.colMTUM_MUVEKKILLERE_PAYLASTIR.OptionsColumn.ReadOnly = true;
            this.colMTUM_MUVEKKILLERE_PAYLASTIR.VisibleIndex = 25;
            this.colMTUM_MUVEKKILLERE_PAYLASTIR.Name = "colMTUM_MUVEKKILLERE_PAYLASTIR";
            this.colMTUM_MUVEKKILLERE_PAYLASTIR.FieldName = "TUM_MUVEKKILLERE_PAYLASTIR";
            this.colMMUVEKKIL_CARI_ID.Caption = "Müvekkil";
            this.colMMUVEKKIL_CARI_ID.Visible = true;
            this.colMMUVEKKIL_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colMMUVEKKIL_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colMMUVEKKIL_CARI_ID.VisibleIndex = 26;
            this.colMMUVEKKIL_CARI_ID.Name = "colMMUVEKKIL_CARI_ID";
            this.colMMUVEKKIL_CARI_ID.FieldName = "MUVEKKIL_CARI_ID";
            this.colMINCELENDI.Caption = "İncelendi";
            this.colMINCELENDI.Visible = true;
            this.colMINCELENDI.OptionsColumn.AllowEdit = false;
            this.colMINCELENDI.OptionsColumn.ReadOnly = true;
            this.colMINCELENDI.VisibleIndex = 27;
            this.colMINCELENDI.Name = "colMINCELENDI";
            this.colMINCELENDI.FieldName = "INCELENDI";
            this.colMONAY_TARIHI.Caption = "Onay T";
            this.colMONAY_TARIHI.Visible = true;
            this.colMONAY_TARIHI.OptionsColumn.AllowEdit = false;
            this.colMONAY_TARIHI.OptionsColumn.ReadOnly = true;
            this.colMONAY_TARIHI.VisibleIndex = 28;
            this.colMONAY_TARIHI.Name = "colMONAY_TARIHI";
            this.colMONAY_TARIHI.FieldName = "ONAY_TARIHI";
            this.colMONAY_NO.Caption = "Onay No";
            this.colMONAY_NO.Visible = true;
            this.colMONAY_NO.OptionsColumn.AllowEdit = false;
            this.colMONAY_NO.OptionsColumn.ReadOnly = true;
            this.colMONAY_NO.VisibleIndex = 29;
            this.colMONAY_NO.Name = "colMONAY_NO";
            this.colMONAY_NO.FieldName = "ONAY_NO";
            this.colMONAY_DURUM.Caption = "Onay Durum";
            this.colMONAY_DURUM.Visible = true;
            this.colMONAY_DURUM.OptionsColumn.AllowEdit = false;
            this.colMONAY_DURUM.OptionsColumn.ReadOnly = true;
            this.colMONAY_DURUM.VisibleIndex = 30;
            this.colMONAY_DURUM.Name = "colMONAY_DURUM";
            this.colMONAY_DURUM.FieldName = "ONAY_DURUM";
            this.colMDETAY_ACIKLAMA.Caption = "Detay Açıklama";
            this.colMDETAY_ACIKLAMA.Visible = true;
            this.colMDETAY_ACIKLAMA.OptionsColumn.AllowEdit = false;
            this.colMDETAY_ACIKLAMA.OptionsColumn.ReadOnly = true;
            this.colMDETAY_ACIKLAMA.VisibleIndex = 31;
            this.colMDETAY_ACIKLAMA.Name = "colMDETAY_ACIKLAMA";
            this.colMDETAY_ACIKLAMA.FieldName = "DETAY_ACIKLAMA";
            this.colMFOY_NO.Caption = "Föy No";
            this.colMFOY_NO.Visible = true;
            this.colMFOY_NO.OptionsColumn.AllowEdit = false;
            this.colMFOY_NO.OptionsColumn.ReadOnly = true;
            this.colMFOY_NO.VisibleIndex = 32;
            this.colMFOY_NO.Name = "colMFOY_NO";
            this.colMFOY_NO.FieldName = "FOY_NO";
            this.colMADLI_BIRIM_ADLIYE_ID.Caption = "Adliye";
            this.colMADLI_BIRIM_ADLIYE_ID.Visible = true;
            this.colMADLI_BIRIM_ADLIYE_ID.OptionsColumn.AllowEdit = false;
            this.colMADLI_BIRIM_ADLIYE_ID.OptionsColumn.ReadOnly = true;
            this.colMADLI_BIRIM_ADLIYE_ID.VisibleIndex = 33;
            this.colMADLI_BIRIM_ADLIYE_ID.Name = "colMADLI_BIRIM_ADLIYE_ID";
            this.colMADLI_BIRIM_ADLIYE_ID.FieldName = "ADLI_BIRIM_ADLIYE_ID";
            this.colMADLI_BIRIM_GOREV_ID.Caption = "Görev";
            this.colMADLI_BIRIM_GOREV_ID.Visible = true;
            this.colMADLI_BIRIM_GOREV_ID.OptionsColumn.AllowEdit = false;
            this.colMADLI_BIRIM_GOREV_ID.OptionsColumn.ReadOnly = true;
            this.colMADLI_BIRIM_GOREV_ID.VisibleIndex = 35;
            this.colMADLI_BIRIM_GOREV_ID.Name = "colMADLI_BIRIM_GOREV_ID";
            this.colMADLI_BIRIM_GOREV_ID.FieldName = "ADLI_BIRIM_GOREV_ID";
            this.colMADLI_BIRIM_NO_ID.Caption = "Birim No";
            this.colMADLI_BIRIM_NO_ID.Visible = true;
            this.colMADLI_BIRIM_NO_ID.OptionsColumn.AllowEdit = false;
            this.colMADLI_BIRIM_NO_ID.OptionsColumn.ReadOnly = true;
            this.colMADLI_BIRIM_NO_ID.VisibleIndex = 34;
            this.colMADLI_BIRIM_NO_ID.Name = "colMADLI_BIRIM_NO_ID ";
            this.colMADLI_BIRIM_NO_ID.FieldName = "ADLI_BIRIM_NO_ID";
            this.colMESAS_NO.Caption = "Esas No";
            this.colMESAS_NO.Visible = true;
            this.colMESAS_NO.OptionsColumn.AllowEdit = false;
            this.colMESAS_NO.OptionsColumn.ReadOnly = true;
            this.colMESAS_NO.VisibleIndex = 36;
            this.colMESAS_NO.Name = "colMESAS_NO";
            this.colMESAS_NO.FieldName = "ESAS_NO";
            this.colMTAKIP_T.Caption = "Takip T";
            this.colMTAKIP_T.Visible = true;
            this.colMTAKIP_T.OptionsColumn.AllowEdit = false;
            this.colMTAKIP_T.OptionsColumn.ReadOnly = true;
            this.colMTAKIP_T.VisibleIndex = 37;
            this.colMTAKIP_T.Name = "colMTAKIP_T";
            this.colMTAKIP_T.FieldName = "TAKIP_T";
            this.colMREFERANS_NO2.Caption = "Ref. No 2";
            this.colMREFERANS_NO2.Visible = true;
            this.colMREFERANS_NO2.OptionsColumn.AllowEdit = false;
            this.colMREFERANS_NO2.OptionsColumn.ReadOnly = true;
            this.colMREFERANS_NO2.VisibleIndex = 38;
            this.colMREFERANS_NO2.Name = "colMREFERANS_NO2";
            this.colMREFERANS_NO2.FieldName = "REFERANS_NO2";
            this.colMREFERANS_NO3.Caption = "Ref. No 3";
            this.colMREFERANS_NO3.Visible = true;
            this.colMREFERANS_NO3.OptionsColumn.AllowEdit = false;
            this.colMREFERANS_NO3.OptionsColumn.ReadOnly = true;
            this.colMREFERANS_NO3.VisibleIndex = 39;
            this.colMREFERANS_NO3.Name = "colMREFERANS_NO3";
            this.colMREFERANS_NO3.FieldName = "REFERANS_NO3";
            this.colMREFERANS_NO.Caption = "Ref. No";
            this.colMREFERANS_NO.Visible = true;
            this.colMREFERANS_NO.OptionsColumn.AllowEdit = false;
            this.colMREFERANS_NO.OptionsColumn.ReadOnly = true;
            this.colMREFERANS_NO.VisibleIndex = 40;
            this.colMREFERANS_NO.Name = "colMREFERANS_NO";
            this.colMREFERANS_NO.FieldName = "REFERANS_NO";
            this.colMOZEL_KOD1.Caption = "Özel Kod 1";
            this.colMOZEL_KOD1.Visible = true;
            this.colMOZEL_KOD1.OptionsColumn.AllowEdit = false;
            this.colMOZEL_KOD1.OptionsColumn.ReadOnly = true;
            this.colMOZEL_KOD1.VisibleIndex = 41;
            this.colMOZEL_KOD1.Name = "colMOZEL_KOD1";
            this.colMOZEL_KOD1.FieldName = "OZEL_KOD1";
            this.colMOZEL_KOD2.Caption = "Özel Kod 2";
            this.colMOZEL_KOD2.Visible = true;
            this.colMOZEL_KOD2.OptionsColumn.AllowEdit = false;
            this.colMOZEL_KOD2.OptionsColumn.ReadOnly = true;
            this.colMOZEL_KOD2.VisibleIndex = 42;
            this.colMOZEL_KOD2.Name = "colMOZEL_KOD2";
            this.colMOZEL_KOD2.FieldName = "OZEL_KOD2";
            this.colMOZEL_KOD3.Caption = "Özel Kod 3";
            this.colMOZEL_KOD3.Visible = true;
            this.colMOZEL_KOD3.OptionsColumn.AllowEdit = false;
            this.colMOZEL_KOD3.OptionsColumn.ReadOnly = true;
            this.colMOZEL_KOD3.VisibleIndex = 43;
            this.colMOZEL_KOD3.Name = "colMOZEL_KOD3";
            this.colMOZEL_KOD3.FieldName = "OZEL_KOD3";
            this.colMOZEL_KOD4.Caption = "Özel Kod 4";
            this.colMOZEL_KOD4.Visible = true;
            this.colMOZEL_KOD4.OptionsColumn.AllowEdit = false;
            this.colMOZEL_KOD4.OptionsColumn.ReadOnly = true;
            this.colMOZEL_KOD4.VisibleIndex = 44;
            this.colMOZEL_KOD4.Name = "colMOZEL_KOD4";
            this.colMOZEL_KOD4.FieldName = "OZEL_KOD4";
            this.colMTARAF_KODU.Caption = "Taraf Kodu";
            this.colMTARAF_KODU.Visible = true;
            this.colMTARAF_KODU.OptionsColumn.AllowEdit = false;
            this.colMTARAF_KODU.OptionsColumn.ReadOnly = true;
            this.colMTARAF_KODU.VisibleIndex = 46;
            this.colMTARAF_KODU.Name = "colMTARAF_KODU";
            this.colMTARAF_KODU.FieldName = "TARAF_KODU";
            this.colMTARAF_CARI_ID.Caption = "Taraf";
            this.colMTARAF_CARI_ID.Visible = true;
            this.colMTARAF_CARI_ID.OptionsColumn.AllowEdit = false;
            this.colMTARAF_CARI_ID.OptionsColumn.ReadOnly = true;
            this.colMTARAF_CARI_ID.VisibleIndex = 47;
            this.colMTARAF_CARI_ID.Name = "colMTARAF_CARI_ID";
            this.colMTARAF_CARI_ID.FieldName = "TARAF_CARI_ID";
            this.colMTARAF_SIFAT_ID.Caption = "Taraf Sıfat";
            this.colMTARAF_SIFAT_ID.Visible = true;
            this.colMTARAF_SIFAT_ID.OptionsColumn.AllowEdit = false;
            this.colMTARAF_SIFAT_ID.OptionsColumn.ReadOnly = true;
            this.colMTARAF_SIFAT_ID.VisibleIndex = 48;
            this.colMTARAF_SIFAT_ID.Name = "colMTARAF_SIFAT_ID";
            this.colMTARAF_SIFAT_ID.FieldName = "TARAF_SIFAT_ID";
            this.colMTipi.Caption = "Tipi";
            this.colMTipi.Visible = true;
            this.colMTipi.OptionsColumn.AllowEdit = false;
            this.colMTipi.OptionsColumn.ReadOnly = true;
            this.colMTipi.VisibleIndex = 49;
            this.colMTipi.Name = "colMTipi";
            this.colMTipi.FieldName = "Tipi";

            #endregion caption visible visibleIndex name  leri verildi coLumnların

            #region <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            colMCARI_ID.ColumnEdit = this.rLueMCariID;
            colMKAYIT_TARIHI.ColumnEdit = this.deMKayitTarihi;
            colMBORCLU_CARI_ID.ColumnEdit = this.rLueMCariID;
            colMTARIH.ColumnEdit = this.deMKayitTarihi;
            colMBORC_ALACAK_ID.ColumnEdit = this.rLueMBorcAlacakID;
            colMODEME_TIP_ID.ColumnEdit = this.rLueMOdemeTip;
            colMHAREKET_ANA_KATEGORI_ID.ColumnEdit = this.rLueMAnaKategori;
            colMHAREKET_ALT_KATEGORI_ID.ColumnEdit = this.rLueMAltKategori;
            colMADET.ColumnEdit = this.seMAdet;
            colMBIRIM_FIYAT.ColumnEdit = this.seMAdet;
            colMBIRIM_FIYAT_DOVIZ_ID.ColumnEdit = this.rLueMDovizID;
            colMKDV_DAHIL.ColumnEdit = this.chkMKavDahil;
            colMKDV_ORAN.ColumnEdit = this.seMAdet;
            colMKDV_TUTAR.ColumnEdit = this.seMAdet;
            colMSTOPAJ_SSDF_DAHIL.ColumnEdit = this.chkMKavDahil;
            colMSTOPAJ_ORAN.ColumnEdit = this.seMAdet;
            colMSSDF_ORAN.ColumnEdit = this.seMAdet;
            colMSTOPAJ_SSDF_TUTAR.ColumnEdit = this.seMAdet;
            colMTOPLAM_TUTAR.ColumnEdit = this.seMAdet;
            colMGENEL_TOPLAM.ColumnEdit = this.seMAdet;
            colMTUM_MUVEKKILLERE_PAYLASTIR.ColumnEdit = this.chkMKavDahil;
            colMMUVEKKIL_CARI_ID.ColumnEdit = this.rLueMCariID;
            colMINCELENDI.ColumnEdit = this.chkMKavDahil;
            colMONAY_TARIHI.ColumnEdit = this.deMKayitTarihi;
            colMADLI_BIRIM_ADLIYE_ID.ColumnEdit = this.rLueMAdliye;
            colMADLI_BIRIM_GOREV_ID.ColumnEdit = this.rLueMAdliBirimGorev;
            colMADLI_BIRIM_NO_ID.ColumnEdit = this.rLueMAdliBirimNo;
            colMTAKIP_T.ColumnEdit = this.deMKayitTarihi;
            colMOZEL_KOD1.ColumnEdit = this.rLueMOzelKodlar;
            colMOZEL_KOD2.ColumnEdit = this.rLueMOzelKodlar;
            colMOZEL_KOD3.ColumnEdit = this.rLueMOzelKodlar;
            colMOZEL_KOD4.ColumnEdit = this.rLueMOzelKodlar;
            colMTARAF_CARI_ID.ColumnEdit = this.rLueMCariID;
            colMTARAF_SIFAT_ID.ColumnEdit = this.rLueMTarafSifatID;

            MasrafAvansLookUpDoldur();

            #endregion <TIO - 20093006 Initsler ColumnEditlere VEriliyor >

            return dizi;
        }

        #endregion Masraf Avans Bilgileri Grid Columnlarının Oluşturulması

        #endregion < /TIO - 20092706 Grid Columları Oluşturuluyor >

        #region <TIO - 20092906 Initsleri Dolduran Metodlar

        #endregion </TIO - 20092906 >

        #region < TIO - 20092906 Nesnelerimi oluşturdum >

        #endregion < /TIO - 20092906 Nesnelerimi oluşturdum >

        /// <summary>
        /// Cariye göre gelen Bilgilerin Countlarını alacak sorgular yazıldı .
        /// </summary>

        #region < TIO - 20091007 Menüde Count Gösterimi için Metodlar >

        #endregion < /TIO - 20091007 Menüde Count Gösterimi için Metodlar >

        private void Loading()
        {
            loading = new frmLoading();
            loading.TopMost = true;
            loading.ShowInTaskbar = false;
            loading.StartPosition = FormStartPosition.CenterScreen;
            loading.ShowIcon = false;
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Takipler SORUŞTURMA
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(CariTakipMetots.GetSorumluEvrakGird());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            var sonuc = CariTakipMetots.SorusturmaDosyaDoldurTrf(gelenCarim.ID);
            var sonuc2 = CariTakipMetots.SorusturmaDosyaDoldurSrm(gelenCarim.ID);
            sourceFoySorusturma.Clear();
            foreach (var item in sonuc)
            {
                R_SORUSTURMA_GENEL_ARAMA text =
                    DataRepository.R_SORUSTURMA_GENEL_ARAMAProvider.Get("ID = " + item.ID, "HAZIRLIK_NO DESC")[0];
                sourceFoySorusturma.Add(text);
            }
            foreach (var item in sonuc2)
            {
                R_SORUSTURMA_GENEL_ARAMA text =
                    DataRepository.R_SORUSTURMA_GENEL_ARAMAProvider.Get("ID = " + item.ID, "HAZIRLIK_NO DESC")[0];
                sourceFoySorusturma.Add(text);
            }

            // sourceFoySorusturma = DataRepository.R_BIRLESIK_TAKIPLER_SORUSTURMA_TEXTProvider.Get("Taraf_Adi=" + GelenCarim.ID, "Dosya_No DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoySorusturma;

            tiklanan = "sorusturma";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            lblUstBolum.Text = "Soruşturma Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.savcilik_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoySorusturma.Count + " )";
            SorusturmaPanelGetir();
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //GElişmeler İTİRAZLAR
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetItirazAlacakNedenGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyItirazAlacakNeden =
                DataRepository.VI_BIL_ITIRAZ_ALACAK_NEDEN_FOR_CARI_TAKIPProvider.Get(
                    "ITIRAZ_EDEN_TARAF_ID =" + GelenCarim.ID, "ITIRAZ_KAPSAMI DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyItirazAlacakNeden;
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";

            lblUstBolum.Text = "İtiraz Bilgileri";
            pcEUstBolumREsim.Image = Resources.itiraz12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyItirazAlacakNeden.Count + " )";
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Gelişmeler Ödeme Planı
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetTaahhutMasterGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            sourceFoyOdemePlanı =
                DataRepository.VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIPProvider.Get(
                    "TAAHHUT_EDEN_ID =" + GelenCarim.ID + "AND RESMI_MI='false'", "TAAHHUT_SIRA_NO DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyOdemePlanı;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Ödeme Planı Bilgileri";
            pcEUstBolumREsim.Image = Resources.taahhut_bilgileri_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyOdemePlanı.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Gelişmeler RESMİ TAAHHUTLER
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetTaahhutMasterGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyTaahhutMaster =
                DataRepository.VI_BIL_BORCLU_TAAHHUT_MASTER_FOR_CARI_TAKIPProvider.Get(
                    "TAAHHUT_EDEN_ID = " + GelenCarim.ID + "AND RESMI_MI='true'", "TAAHHUT_SIRA_NO  DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyTaahhutMaster;

            lblUstBolum.Text = "Resmi Taahhüt Bilgileri";
            pcEUstBolumREsim.Image = Resources.taahhut_bilgileri_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyTaahhutMaster.Count + " )";
            compGridDovizSummary1.Refresh();
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "resmiTaahhut";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // GElişmeler ÖDEME ( BORÇLU ÖDEME )
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetOdemelerGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyBorcluOdeme =
                DataRepository.VI_BIL_BORCLU_ODEME_FOR_CARI_TAKIPProvider.Get("ODEYEN_CARI_ID =" + GelenCarim.ID,
                                                                              "ODEME_KIM_ADINA DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyBorcluOdeme;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Ödeme Bilgileri";
            pcEUstBolumREsim.Image = Resources.odeme_16x161;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyBorcluOdeme.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "odemebilgileri";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Mal Bilgileri TÜM MALLAR
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetBorcluMalGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyTumMallar =
                DataRepository.VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIPProvider.Get("CARI_ID =" + GelenCarim.ID,
                                                                             "MALIN_ADRESI  DESC");

            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyTumMallar;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Mal Bilgileri";
            pcEUstBolumREsim.Image = Resources.tum_mallar_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyTumMallar.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Mal Bilgileri ARAŞTIRILAN MALLAR
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetBorcluMalGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            //TİP ine göre süzülcek

            sourceFoyTumMallar =
                DataRepository.VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIPProvider.Get(
                    "TIP=" + 4 + " AND CARI_ID =" + GelenCarim.ID, "MALIN_ADRESI  DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyTumMallar;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Araştırılan Mal Bilgileri";
            pcEUstBolumREsim.Image = Resources.tum_mallar_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyTumMallar.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Mal Bilgileri BEYAN EDİLEN MALLAR
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetBorcluMalGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            //TİP ine göre süzülcek

            sourceFoyTumMallar =
                DataRepository.VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIPProvider.Get(
                    "TIP=" + 3 + " AND CARI_ID =" + GelenCarim.ID, "MALIN_ADRESI  DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyTumMallar;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Beyan Edilen Mal Bilgileri";
            pcEUstBolumREsim.Image = Resources.tum_mallar_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyTumMallar.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Mal Bilgileri HACİZLİ MALLAR
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetBorcluMalGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            //TİP ine göre züzülecek

            sourceFoyTumMallar =
                DataRepository.VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIPProvider.Get(
                    "TIP=" + 1 + " AND CARI_ID =" + GelenCarim.ID, "MALIN_ADRESI  DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyTumMallar;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Hacizli Mal Bilgileri";
            pcEUstBolumREsim.Image = Resources.tum_mallar_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyTumMallar.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Mal Bilgileri REHİNLİ MALLAR
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetBorcluMalGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            //TIPI ne göre süzülecek

            sourceFoyTumMallar =
                DataRepository.VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIPProvider.Get(
                    "TIP=" + 2 + " AND CARI_ID =" + GelenCarim.ID, "MALIN_ADRESI  DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyTumMallar;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Rehinli Mal Bilgileri";
            pcEUstBolumREsim.Image = Resources.tum_mallar_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyTumMallar.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Kıymetli Evrak Çek Senek Poliçe
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetKıymetliEvrakGird());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyKiymetliEvrak = DataRepository.KIYMETLI_EVRAK_TARAFLIProvider.Get(
                "TARAF_CARI_ID=" + GelenCarim.ID, "HESAP_NO DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyKiymetliEvrak;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Kıymetli Evrak Bilgileri";
            pcEUstBolumREsim.Image = Resources.kiymetli_evrak_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyKiymetliEvrak.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            tiklanan = "";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Takipler DAVA
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetIcraGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            //var sonuc =CariTakipMetots.DavaDosyaDondur(gelenCarim.ID);
            var davaSrm = CariTakipMetots.DavaDosyaDondurSrm(gelenCarim.ID);
            var davaTrF = CariTakipMetots.DavaDosyaDondurTrf(gelenCarim.ID);
            sourceFoyDava.Clear();
            foreach (var item in davaSrm)
            {
                R_BIRLESIK_TAKIPLER_DAVA_TEXT text =
                    DataRepository.R_BIRLESIK_TAKIPLER_DAVA_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
                sourceFoyDava.Add(text);
            }
            foreach (var item in davaTrF)
            {
                R_BIRLESIK_TAKIPLER_DAVA_TEXT text =
                    DataRepository.R_BIRLESIK_TAKIPLER_DAVA_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
                sourceFoyDava.Add(text);
            }
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyDava;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Dava Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.durusma_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyDava.Count + " )";

            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;

            // dava icin
            tiklanan = "dava";
            DavaPanelGetir();
        }

        private void navBarItem20_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Değişik İşler IHTIYATI HACIZ
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetIhtiyatiHacizGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyIhtiyatiHaciz =
                DataRepository.VI_BIL_IHTIYATI_HACIZ_FOR_CARI_TAKIPProvider.Get("ICRA_CARI_TARAF_ID =" + GelenCarim.ID,
                                                                                "KARAR_NO  DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyIhtiyatiHaciz;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "İhtiyati Haciz Bilgileri";
            pcEUstBolumREsim.Image = Resources.ihtiyati_haciz_16x16;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyIhtiyatiHaciz.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "ihtiyatihaciz";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Değişik İŞler IHTIYATI TEDBIR
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetIhtiyatiTedbirGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            sourceFoyIhtiyatiTedbir.Clear();
            VList<VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIP> TakipList = BelgeUtil.Inits.VDI_BIL_IHTIYATI_TEDBIR_FOR_CARI_TAKIPGetir();
            foreach (var item in TakipList)
            {
                if (item.ICRA_CARI_TARAF_ID == GelenCarim.ID)
                    sourceFoyIhtiyatiTedbir.Add(item);
            }
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyIhtiyatiTedbir;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "İhtiyati Tedbir Bilgileri";
            pcEUstBolumREsim.Image = Resources.ihtiyati_tedbir1;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyIhtiyatiTedbir.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "ihtiyatitedbir";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Değişik İşler  TESPİT
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetTespitGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyTespit =
                DataRepository.VDI_BIL_TESPIT_FOR_CARI_TAKIPProvider.Get("TESPIT_YAPILAN_TARAF_ID =" + GelenCarim.ID,
                                                                         "ESAS_NO DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyTespit;
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";

            lblUstBolum.Text = "Tespit Bilgileri";
            pcEUstBolumREsim.Image = Resources.Bul_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyTespit.Count + " )";
            PanelTemizle();
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Muhasebe Bilgileri MASRAF AVANS
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetMasrafAvansGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyMasrafAvans = DataRepository.R_MASRAF_AVANS_BIRLESIK_TARAFProvider.Get(
                "CARI_ID =" + GelenCarim.ID, "KULLANICI_BELGE_NO DESC");
            compGridDovizSummary1.Refresh();
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyMasrafAvans;
            tiklanan = "masrafAvans";

            lblUstBolum.Text = "Masraf Avans Bilgileri";
            pcEUstBolumREsim.Image = Resources.muhasebe_16x16;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyMasrafAvans.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Muhaeebe Bİlgileri FATURA
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetMasrafAvansGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyFatura = DataRepository.VDI_BIL_FATURA_FOR_CARI_TAKIPProvider.Get("CARI_ID =" + GelenCarim.ID,
                                                                                       "REFERANS_NO DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyFatura;
            tiklanan = "";

            lblUstBolum.Text = "Fatura Bilgileri";
            pcEUstBolumREsim.Image = Resources.muhasebe_16x16;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyFatura.Count + " )";
            compGridDovizSummary1.Refresh();
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Muhasebe Bilgileri CARI HESAP
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetCariHesapGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyCariHesap =
                DataRepository.VDI_BIL_CARI_HESAP_FOR_CARI_TAKIPProvider.Get("CARI_ID =" + GelenCarim.ID,
                                                                             "KULLANICI_BELGE_NO DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyCariHesap;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Cari Hesap Bilgileri";
            pcEUstBolumREsim.Image = Resources.muhasebe_16x16;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyCariHesap.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Takipler İCRA
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetIcraGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            var sonuc = CariTakipMetots.IcraDosyaDoldurTrf(GelenCarim.ID);
            var sonuc2 = CariTakipMetots.IcraDosyaDoldurSrm(GelenCarim.ID);
            sourceFoyIcra.Clear();
            foreach (var item in sonuc)
            {
                R_BIRLESIK_TAKIPLER_ICRA_TEXT text =
                    DataRepository.R_BIRLESIK_TAKIPLER_ICRA_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
                sourceFoyIcra.Add(text);
            }
            foreach (var item in sonuc2)
            {
                R_BIRLESIK_TAKIPLER_ICRA_TEXT text =
                    DataRepository.R_BIRLESIK_TAKIPLER_ICRA_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
                sourceFoyIcra.Add(text);
            }

            // sourceFoyIcra = DataRepository.R_BIRLESIK_TAKIPLER_ICRA_TEXTProvider.Get("Taraf_Adi=" + GelenCarim.ID, "Dosya_No DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyIcra;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "İcra Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.Icra_Islemleri_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyIcra.Count + " )";

            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;

            #region < TIO - 20091607  Üst Bilgi Paneline İcra Taraflarına Göre ve Sorumlulularına göre sorgulamak için dinamik olarak Buton Eklendi >

            IcraPanelGetir();
            tiklanan = "icra";

            #endregion < /TIO - 20091607  Üst Bilgi Paneline İcra Taraflarına Göre ve Sorumlulularına göre sorgulamak için dinamik olarak Buton Eklendi >
        }

        private void navBarItem32_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Gelişmeler YAPILCAK İŞLER
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetYapilcakIsGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyYapilcakIs = DataRepository.VDI_BIL_IS_FOR_CARI_TAKIPProvider.Get("CARI_ID =" + GelenCarim.ID,
                                                                                       "KONU DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyYapilcakIs;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Yapılcak İş Bilgileri";
            pcEUstBolumREsim.Image = Resources.YapilcakIs_12x12;
            tiklanan = "yapIs";
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyYapilcakIs.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Dökümanlar BELGE
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetBelgeGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            var belgeler = CariTakipMetots.BelgeDosyaDoldur(GelenCarim.ID);

            //        sourceFoyBorcluOdeme =
            //DataRepository.VI_BIL_BORCLU_ODEME_FOR_CARI_TAKIPProvider.Get("ODEYEN_CARI_ID =" + GelenCarim.ID,
            //                                                              "ODEME_KIM_ADINA DESC");

            //var belgeler = DataRepository.AV001_TDIE_BIL_BELGE_TARAFProvider.Get("CARI_ID =" + GelenCarim.ID, "Belge_ESAS_NO DESC");

            //foreach (var item in belgeler)
            //{
            //    R_BIRLESIK_TAKIPLER_BELGE_TEXT text =
            //        DataRepository.R_BIRLESIK_TAKIPLER_BELGE_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
            //    sourceFoyBelge.Add(text);
            //}
            exGrdiOrtakAlan.DataSource = null;

            exGrdiOrtakAlan.DataSource = belgeler;

            //exGrdiOrtakAlan.DataSource = sourceFoyBelge;

            //sourceFoyTumMallar =
            //    DataRepository.VDI_BIL_BORCLU_MAL_FOR_CARI_TAKIPProvider.Get("CARI_ID =" + GelenCarim.ID,
            //                                                                 "MALIN_ADRESI  DESC");
            //sourceFoyBelge = DataRepository.VDIE_BIL_BELGEProvider.Get("CARI_ID

            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            tiklanan = "belge";
            lblUstBolum.Text = "Belge Bilgileri";
            pcEUstBolumREsim.Image = Resources.belgeler12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + belgeler.Count + " )";
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Dökümanlar SÖZLEŞMELER
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(CariTakipMetots.GetSozlesmeGird());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            sourceFoySozlesme.Clear();

            var davaSrm = CariTakipMetots.SozlesmeDosyaDoldurSrm(gelenCarim.ID);
            var davaTrF = CariTakipMetots.SozlesmeDosyaDoldurTrf(gelenCarim.ID);

            foreach (var item in davaSrm)
            {
                R_SOZLESME_GENEL_ARAMA2 text =
                    DataRepository.R_SOZLESME_GENEL_ARAMA2Provider.Get("ID=" + item.ID, "SOZLESME_NO DESC")[0];
                sourceFoySozlesme.Add(text);
            }
            foreach (var item in davaTrF)
            {
                R_SOZLESME_GENEL_ARAMA2 text =
                    DataRepository.R_SOZLESME_GENEL_ARAMA2Provider.Get("ID=" + item.ID, "SOZLESME_NO DESC")[0];
                sourceFoySozlesme.Add(text);
            }
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoySozlesme;
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            lblUstBolum.Text = "Sözleşme Bilgileri";
            pcEUstBolumREsim.Image = Resources.sozlesme_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoySozlesme.Count + " )";
            tiklanan = "sozlesme";

            SozlesmePanelGetir();
        }

        //BV
        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // Dökümanlar GELEN-GİDEN EVRAK TEBLİGAT
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(CariTakipMetots.GetEvrakGrid());
            gridView1.CollapseAllDetails();
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            //sourceFoyTebligat.Clear();

            var evraklar = CariTakipMetots.EvrakDosyaDoldur(GelenCarim.ID);
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = evraklar;

            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "evrak";
            lblUstBolum.Text = "Gelen-Giden Evrak Bilgileri";
            pcEUstBolumREsim.Image = Resources.tebligat_isleri_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + evraklar.Count + " )";
            return;

            //foreach (var item in evraklar)
            //{
            //    AvukatProLib.Arama.AV001_TDI_BIL_TEBLIGAT text = BelgeUtil.Inits.context.AV001_TDI_BIL_TEBLIGATs.Where(vi => vi.MUHATAP_CARI_ID == GelenCarim.ID);
            //    sourceFoyTebligat.Add(text);
            //}

            //sourceFoyTebligat =
            //    DataRepository.R_BIRLESIK_TAKIPLER_TEBLIGAT_TEXTProvider.Get("Taraf_Adi=" + GelenCarim.ID,
            //                                                                 "Dosya_No DESC");

            //exGrdiOrtakAlan.DataSource = null;
            //exGrdiOrtakAlan.DataSource = sourceFoyTebligat;

            //tiklanan = "evrak";
            //lblUstBolum.Text = "Gelen-Giden Evrak Bilgileri";
            //pcEUstBolumREsim.Image = Resources.tebligat_isleri_12x12;
            //pnl_UstBilgiMenu.Visible = true;
            //lblUstBolum.Text += " ( " + sourceFoyTebligat.Count + " )";
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            // İletişim SMS
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetSmsGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoySMS = DataRepository.VSMS_BIL_MESAJ_NUMARA_FOR_CARI_TAKIPProvider.Get("CARI_ID =" + GelenCarim.ID,
                                                                                           "NUMARA DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoySMS;

            lblUstBolum.Text = "İLetişim/SMS Bilgileri";
            pcEUstBolumREsim.Image = Resources.Mail_16x16;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoySMS.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            tiklanan = "";
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //İletrişim MAİL
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetMailGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            sourceFoyMail =
                DataRepository.VDIE_BIL_MESAJ_FOR_CARI_TAKIPProvider.Get("GONDEREN_CARI_ID =" + GelenCarim.ID,
                                                                         "KONU DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyMail;

            lblUstBolum.Text = "İletişim/Mail Bilgileri";
            pcEUstBolumREsim.Image = Resources.posta12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyMail.Count + " )";
            tiklanan = "";
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //İletişim GÖRÜŞME
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetGorusmeGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            sourceFoyGorusme =
                DataRepository.VDI_BIL_GORUSME_FOR_CARI_TAKIPProvider.Get("GORUSEN_CARI_ID=" + GelenCarim.ID,
                                                                          "TARIH DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyGorusme;

            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;

            lblUstBolum.Text = "Görüşme Bilgileri";
            pcEUstBolumREsim.Image = Resources.gorusmeler12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyGorusme.Count + " )";

            //ucGorusmeArama da cift tiklaninca form acilmiyor
            tiklanan = "gorusme";
        }

        private void sBtnDavaSorumlusunaGore_Click(object sender, EventArgs e)
        {
            //Takipler DAVA
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetIcraGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            //var sonuc =CariTakipMetots.DavaDosyaDondur(gelenCarim.ID);
            var davaSrm = CariTakipMetots.DavaDosyaDondurSrm(gelenCarim.ID);
            sourceFoyDava.Clear();
            foreach (var item in davaSrm)
            {
                R_BIRLESIK_TAKIPLER_DAVA_TEXT text =
                    DataRepository.R_BIRLESIK_TAKIPLER_DAVA_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
                sourceFoyDava.Add(text);
            }
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyDava;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Dava Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.durusma_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyDava.Count + " )";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void sBtnDavaTarafaGore_Click(object sender, EventArgs e)
        {
            //Takipler DAVA
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetIcraGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;

            //var sonuc =CariTakipMetots.DavaDosyaDondur(gelenCarim.ID);
            var davaSrm = CariTakipMetots.DavaDosyaDondurTrf(gelenCarim.ID);
            sourceFoyDava.Clear();
            foreach (var item in davaSrm)
            {
                R_BIRLESIK_TAKIPLER_DAVA_TEXT text =
                    DataRepository.R_BIRLESIK_TAKIPLER_DAVA_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
                sourceFoyDava.Add(text);
            }
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyDava;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "Dava Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.durusma_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyDava.Count + " )";

            if (degerlerHesaplansin)
                compGridDovizSummary1.AltToplamlarAktifMi = true;
            else
                compGridDovizSummary1.AltToplamlarAktifMi = false;
        }

        private void sBtnIcraSorumlusunaGore_Click(object sender, EventArgs e)
        {
            //SORUMLUSUNA GORE ICRA
            //gridView1.Columns.Clear();
            //gridView1.Columns.AddRange(GetIcraGrid());
            //gridView1.RefreshEditor(true);
            //gridView1.OptionsView.ColumnAutoWidth = false;
            var sonuc = CariTakipMetots.IcraDosyaDoldurSrm(GelenCarim.ID);
            sourceFoyIcra.Clear();
            foreach (var item in sonuc)
            {
                R_BIRLESIK_TAKIPLER_ICRA_TEXT text =
                    DataRepository.R_BIRLESIK_TAKIPLER_ICRA_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
                sourceFoyIcra.Add(text);
            }

            //sourceFoyIcra = DataRepository.R_BIRLESIK_TAKIPLER_ICRA_TEXTProvider.Get("Sorumlu_Adi=" + GelenCarim.ID, "Dosya_No DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyIcra;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "İcra Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.Icra_Islemleri_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyIcra.Count + " )";
            dockPanelBelge.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
        }

        private void sBtnIcraTarafaGore_Click(object sender, EventArgs e)
        {
            //TARAFINA GORE ICRA
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(GetIcraGrid());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            var sonuc = CariTakipMetots.IcraDosyaDoldurTrf(GelenCarim.ID);
            sourceFoyIcra.Clear();
            foreach (var item in sonuc)
            {
                R_BIRLESIK_TAKIPLER_ICRA_TEXT text =
                    DataRepository.R_BIRLESIK_TAKIPLER_ICRA_TEXTProvider.Get("ID=" + item.ID, "Dosya_No DESC")[0];
                sourceFoyIcra.Add(text);
            }

            // sourceFoyIcra = DataRepository.R_BIRLESIK_TAKIPLER_ICRA_TEXTProvider.Get("Taraf_Adi=" + GelenCarim.ID, "Dosya_No DESC");
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoyIcra;
            compGridDovizSummary1.Refresh();
            lblUstBolum.Text = "İcra Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.Icra_Islemleri_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoyIcra.Count + " )";
        }

        private void sBtnSorusturmaSorumlusunaGore_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(CariTakipMetots.GetSorumluEvrakGird());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            var sonuc = CariTakipMetots.SorusturmaDosyaDoldurSrm(gelenCarim.ID);
            sourceFoySorusturma.Clear();
            foreach (var item in sonuc)
            {
                R_SORUSTURMA_GENEL_ARAMA text =
                    DataRepository.R_SORUSTURMA_GENEL_ARAMAProvider.Get("ID = " + item.ID, "HAZIRLIK_NO DESC")[0];
                sourceFoySorusturma.Add(text);
            }
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoySorusturma;

            lblUstBolum.Text = "Soruşturma Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.savcilik_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoySorusturma.Count + " )";
        }

        private void sBtnSorusturmaTarafaGore_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(CariTakipMetots.GetSorumluEvrakGird());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            var sonuc = CariTakipMetots.SorusturmaDosyaDoldurTrf(gelenCarim.ID);
            sourceFoySorusturma.Clear();
            foreach (var item in sonuc)
            {
                R_SORUSTURMA_GENEL_ARAMA text =
                    DataRepository.R_SORUSTURMA_GENEL_ARAMAProvider.Get("ID = " + item.ID, "HAZIRLIK_NO DESC")[0];
                sourceFoySorusturma.Add(text);
            }
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoySorusturma;

            lblUstBolum.Text = "Soruşturma Dosya Bilgileri";
            pcEUstBolumREsim.Image = Resources.savcilik_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoySorusturma.Count + " )";
        }

        private void sBtnSozlesmeSorumlusunaGore_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(CariTakipMetots.GetSozlesmeGird());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            sourceFoySozlesme.Clear();

            var davaSrm = CariTakipMetots.SozlesmeDosyaDoldurSrm(gelenCarim.ID);
            foreach (var item in davaSrm)
            {
                R_SOZLESME_GENEL_ARAMA2 text =
                    DataRepository.R_SOZLESME_GENEL_ARAMA2Provider.Get("ID=" + item.ID, "SOZLESME_NO DESC")[0];
                sourceFoySozlesme.Add(text);
            }
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoySozlesme;

            lblUstBolum.Text = "Sözleşme Bilgileri";
            pcEUstBolumREsim.Image = Resources.sozlesme_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoySozlesme.Count + " )";
        }

        private void sBtnSozlesmeTarafaGore_Click(object sender, EventArgs e)
        {
            gridView1.Columns.Clear();
            gridView1.Columns.AddRange(CariTakipMetots.GetSozlesmeGird());
            gridView1.RefreshEditor(true);
            gridView1.OptionsView.ColumnAutoWidth = false;
            sourceFoySozlesme.Clear();

            var davaSrm = CariTakipMetots.SozlesmeDosyaDoldurTrf(gelenCarim.ID);
            foreach (var item in davaSrm)
            {
                R_SOZLESME_GENEL_ARAMA2 text =
                    DataRepository.R_SOZLESME_GENEL_ARAMA2Provider.Get("ID=" + item.ID, "SOZLESME_NO DESC")[0];
                sourceFoySozlesme.Add(text);
            }
            exGrdiOrtakAlan.DataSource = null;
            exGrdiOrtakAlan.DataSource = sourceFoySozlesme;

            lblUstBolum.Text = "Sözleşme Bilgileri";
            pcEUstBolumREsim.Image = Resources.sozlesme_12x12;
            pnl_UstBilgiMenu.Visible = true;
            lblUstBolum.Text += " ( " + sourceFoySozlesme.Count + " )";
        }

        private void SorusturmaPanelGetir()
        {
            Size whIcraPanel = new Size();
            whIcraPanel.Height = 36;
            whIcraPanel.Width = 350;
            Point xyIcraPanel = new Point();
            xyIcraPanel.X = 320;
            xyIcraPanel.Y = 5;
            Size whIcraButton = new Size();
            whIcraButton.Width = 130;
            whIcraButton.Height = 22;
            Point xyIcraButton1 = new Point();
            xyIcraButton1.Y = 5;
            xyIcraButton1.X = 8;
            Point xyIcraButton2 = new Point();
            xyIcraButton2.Y = 5;
            xyIcraButton2.X = 200;
            sBtnSorusturmaTarafaGore.Location = xyIcraButton1;
            sBtnSorusturmaTarafaGore.Size = whIcraButton;
            sBtnSorusturmaSorumlusunaGore.Location = xyIcraButton2;
            sBtnSorusturmaSorumlusunaGore.Size = whIcraButton;
            pnlControlIcraTaraflar.Size = whIcraPanel;
            pnlControlIcraTaraflar.Location = xyIcraPanel;
            pnlControlIcraTaraflar.Controls.Clear();
            pnlControlIcraTaraflar.Controls.Add(sBtnSorusturmaTarafaGore);
            pnlControlIcraTaraflar.Controls.Add(sBtnSorusturmaSorumlusunaGore);
            pnlControlIcraTaraflar.Visible = true;
            sBtnSorusturmaTarafaGore.Visible = true;
            sBtnSorusturmaSorumlusunaGore.Visible = true;
            sBtnSorusturmaSorumlusunaGore.Text = "Sorumlusu Olduğu Dos.";
            sBtnSorusturmaTarafaGore.Text = "Taraf Olduğu Dos.";
            pnl_UstBilgiMenu.Controls.Add(pnlControlIcraTaraflar);
            sBtnSorusturmaSorumlusunaGore.Click += sBtnSorusturmaSorumlusunaGore_Click;
            sBtnSorusturmaTarafaGore.Click += sBtnSorusturmaTarafaGore_Click;
        }

        private void SozlesmePanelGetir()
        {
            Size whIcraPanel = new Size();
            whIcraPanel.Height = 36;
            whIcraPanel.Width = 350;
            Point xyIcraPanel = new Point();
            xyIcraPanel.X = 320;
            xyIcraPanel.Y = 5;
            Size whIcraButton = new Size();
            whIcraButton.Width = 130;
            whIcraButton.Height = 22;
            Point xyIcraButton1 = new Point();
            xyIcraButton1.Y = 5;
            xyIcraButton1.X = 8;
            Point xyIcraButton2 = new Point();
            xyIcraButton2.Y = 5;
            xyIcraButton2.X = 200;
            sBtnSozlesmeTarafaGore.Location = xyIcraButton1;
            sBtnSozlesmeTarafaGore.Size = whIcraButton;
            sBtnSozlesmeSorumlusunaGore.Location = xyIcraButton2;
            sBtnSozlesmeSorumlusunaGore.Size = whIcraButton;
            pnlControlIcraTaraflar.Size = whIcraPanel;
            pnlControlIcraTaraflar.Location = xyIcraPanel;
            pnlControlIcraTaraflar.Controls.Clear();
            pnlControlIcraTaraflar.Controls.Add(sBtnSozlesmeTarafaGore);
            pnlControlIcraTaraflar.Controls.Add(sBtnSozlesmeSorumlusunaGore);
            pnlControlIcraTaraflar.Visible = true;
            sBtnSozlesmeTarafaGore.Visible = true;
            sBtnSozlesmeSorumlusunaGore.Visible = true;
            sBtnSozlesmeSorumlusunaGore.Text = "Sorumlusu Olduğu Dos.";
            sBtnSozlesmeTarafaGore.Text = "Taraf Olduğu Dos.";
            pnl_UstBilgiMenu.Controls.Add(pnlControlIcraTaraflar);
            sBtnSozlesmeSorumlusunaGore.Click += sBtnSozlesmeSorumlusunaGore_Click;
            sBtnSozlesmeTarafaGore.Click += sBtnSozlesmeTarafaGore_Click;
        }
    }
}