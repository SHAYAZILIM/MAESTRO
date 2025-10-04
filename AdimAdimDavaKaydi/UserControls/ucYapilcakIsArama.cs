using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucYapilcakIsArama : DevExpress.XtraEditors.XtraUserControl
    {
        public ucYapilcakIsArama()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> Temizle;
        public event EventHandler<EventArgs> Sorgula;

        private void ucYapilcakIsArama_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            #region LookUps

            LookupDoldur();

            #endregion
        }

        private void LookupDoldur()
        {
            AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(lueModulId, null);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeDoldur(lkAdliye);
            AvukatPro.Services.Implementations.DevExpressService.AdliyeNoDoldur(lkAdliBirimNo);

            AvukatPro.Services.Implementations.DevExpressService.AdliyeGorevDoldur(lkAdliBirimGorev);

            lkIsOncelik.Properties.NullText = "Seç";
            lkIsOncelik.Enter += delegate { BelgeUtil.Inits.IsOncelikGetir(lkIsOncelik); };

            //lueProje.Properties.NullText = "Seç";
            //lueProje.Enter += delegate { BelgeUtil.Inits.ProjeAdGetir(lueProje.Properties); };

            lkIsKategori.Properties.NullText = "Seç";
            lkIsKategori.Enter +=
                delegate { BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lkIsKategori.Properties); };

            //AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueBirimFiyatDoviz);
            //AvukatPro.Services.Implementations.DevExpressService.DovizDoldur(lueToplamFiyatDoviz);

            //lueIsSurec.Properties.NullText = "Seç";
            //lueIsSurec.Enter += delegate { BelgeUtil.Inits.IsSurecGetir(lueIsSurec); };

            //lueSozlesme.Properties.NullText = "Seç";
            //lueSozlesme.Enter += delegate { BelgeUtil.Inits.IsSozlesmeGetir(lueSozlesme); };

            //lueSorumlu.Properties.NullText = "Seç";
            //lueSorumlu.Enter += delegate { BelgeUtil.Inits.SorumluAvukatGetir(lueSorumlu); };
            //AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueIstaraf, null);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueIsTarafCari, null);

            //lueKullanici.Properties.NullText = "Seç";
            //lueKullanici.Enter += delegate { BelgeUtil.Inits.KontrolKimGetir(lueKullanici.Properties); };

            //appEtiket.Properties.NullText = "Seç";
            //appEtiket.Enter += delegate { BelgeUtil.Inits.IsEtiketGetir(appEtiket); };

            lkSubeKod.Properties.NullText = "Seç";
            lkSubeKod.Enter += delegate { BelgeUtil.Inits.SubeKodGetir(lkSubeKod.Properties); };
        }

        public bool BenimIslerim = true;

        public bool HepsiniDoldur;

        //public TList<AV001_TDI_BIL_IS> Ara()
        //{
        //    DataSet dr = new DataSet();

        //    DialogResult drb =
        //        XtraMessageBox.Show(
        //            "Arama Kriteri Girmediniz \nBu Durumda Sorgulama Zaman Alabilir \nArama Yapmak Ýstediðinize Emin misiniz? ",
        //            "Emin misiniz ? ", MessageBoxButtons.YesNo);

        //    TList<AV001_TDI_BIL_IS> isList = DataRepository.AV001_TDI_BIL_ISProvider.GetByFiltre(Kategori, YapilacakIs,
        //                                                                                         Adliye, AdliBirimGorev,
        //                                                                                         AdliBirimNo, Modul,
        //                                                                                         Ajanda, Hatirlatma,
        //                                                                                         IsTip, IsDurum,
        //                                                                                         BitisZaman,
        //                                                                                         IsBaslangicTrh,
        //                                                                                         OngorulenBitisTrh,
        //                                                                                         OnGorBitisZmn, Yer,
        //                                                                                         Konu, IsAciklama, Statu,
        //                                                                                         Etiket, Oncelik, IsNo,
        //                                                                                         EsasNo, RefNo,
        //                                                                                         Kullanici, SubeKod,
        //                                                                                         IsTarafCari, IsTaraf,
        //                                                                                         null,
        //                                                                                         null, null,
        //                                                                                         null, null,
        //                                                                                         null, null,
        //                                                                                         null, null,
        //                                                                                         null,
        //                                                                                         null,
        //                                                                                         null, null);

        //    return isList;
        //}

        public DataTable aramaSonuclarim = new DataTable();

        public List<AvukatProLib.Arama.AV001_TDI_BIL_I> aramaSonuclarimView =
            new List<AvukatProLib.Arama.AV001_TDI_BIL_I>();

        private TList<AV001_TDI_BIL_IS> tempAranan = new TList<AV001_TDI_BIL_IS>();
        public bool ViewDegisti;
        public bool HizliErisimdenMi;

        public void AramaYap()
        {
            //ARAMA YAP

            //if (ProjeID != null || Sorumlu != null || IsSozlesme != null || MaddeKalem != null ||
            //    TmmBaslangicTrh != null || TmmBitisTrh != null || SurecAciklama != null || BirimFiyat != null ||
            //    ToplamFiyat != null || Muhasebeles != null || Sure != null || BirimFiyatBrm != null ||
            //    ToplamFiyatBrm != null)
            //{
            //    ViewDegisti = true;
            //}
            //else
            //    ViewDegisti = false;
            //if (!HizliErisimdenMi)
            //{
            if (rgIsSecimi.SelectedIndex == 0)
            {
                Kullanici = AvukatProLib.Kimlikci.Kimlik.Cari_ID;
            }
            else
                Kullanici = null;

            IsDurum = rgIsDurum.SelectedIndex;

            if (rgZamanDilimi.SelectedIndex == -1)
                rgZamanDilimi.SelectedIndex = 6;

            if (AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_IDSource.SUBE_ADI == "MERKEZ")
                aramaSonuclarim = AvukatProLib.Arama.R_IS_ARAMASorgu.GetByFiltreView(Kategori, YapilacakIs, Adliye, AdliBirimGorev, AdliBirimNo, Modul, Ajanda, Hatirlatma, IsTip, IsDurum, BitisZaman, IsBaslangicTrh, OngorulenBitisTrh, null, Yer, Konu, IsAciklama, Statu, Etiket, Oncelik, IsNo, EsasNo, RefNo, Kullanici, SubeKod, IsTarafCari, IsTaraf, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
            else
                aramaSonuclarim = AvukatProLib.Arama.R_IS_ARAMASorgu.GetByFiltreView(Kategori, YapilacakIs, Adliye, AdliBirimGorev, AdliBirimNo, Modul, Ajanda, Hatirlatma, IsTip, IsDurum, BitisZaman, IsBaslangicTrh, OngorulenBitisTrh, null, Yer, Konu, IsAciklama, Statu, Etiket, Oncelik, IsNo, EsasNo, RefNo, Kullanici, AvukatProLib.Kimlik.Bilgi.KULLANICI_SUBE_ID, IsTarafCari, IsTaraf, AvukatProLib.Kimlik.SirketBilgisi.ConStr, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            //FormlariTemizle(panelControl1.Controls);
            //FormlariTemizle(panelControl2.Controls);
            //FormlariTemizle(panelControl5.Controls);
            //lueBirimFiyatDoviz.EditValue = null;
            //lueToplamFiyatDoviz.EditValue = null;
            rgIsDurum.EditValue = null;
            aramaSonuclarim = null;
            if (Temizle != null)
                Temizle(this, new EventArgs());

            rgZamanDilimi.SelectedIndex = 6;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (Sorgula != null)
                Sorgula(this, new EventArgs());
        }


        private void rgIsSecimi_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        #region Arama Kireterleri

        private int? Modul;

        private void lueModulId_EditValueChanged(object sender, EventArgs e)
        {
            if (lueModulId.EditValue != null)
                Modul = Convert.ToInt32(lueModulId.EditValue);
            else
                Modul = null;
        }

        private int? Kategori;

        private void lkIsKategori_EditValueChanged(object sender, EventArgs e)
        {
            if (lkIsKategori.EditValue != null)
                Kategori = (int?)lkIsKategori.EditValue;
            else
                Kategori = null;
        }

        private int? Adliye;

        private void lkAdliye_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAdliye.EditValue != null)
                Adliye = (int?)lkAdliye.EditValue;
            else
                Adliye = null;
        }

        private int? AdliBirimNo;

        private void lkAdliBirimNo_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAdliBirimNo.EditValue != null)
                AdliBirimNo = (int?)lkAdliBirimNo.EditValue;
            else
                AdliBirimNo = null;
        }

        private int? AdliBirimGorev;

        private void lkAdliBirimGorev_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAdliBirimGorev.EditValue != null)
                AdliBirimGorev = (int?)lkAdliBirimGorev.EditValue;
            else
                AdliBirimGorev = null;
        }

        private string EsasNo;

        private void txeEsasNo_TextChanged(object sender, EventArgs e)
        {
            EsasNo = txeEsasNo.Text;
            if (txeEsasNo.Text == string.Empty)
                EsasNo = null;
        }

        private int? IsTip;

        //private void lueIsTip_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueIsTip.EditValue != null)
        //        IsTip = (int?)lueIsTip.EditValue;
        //    else
        //        IsTip = null;
        //}

        private DateTime? IsBaslangicTrh;

        private void deBaslangicTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (deBaslangicTarihi.EditValue != null)
            {
                if (deBaslangicTarihi.EditValue.ToString().Length > 0)
                    IsBaslangicTrh = (DateTime?)deBaslangicTarihi.EditValue;
                else
                    IsBaslangicTrh = null;
            }
        }

        private DateTime? OngorulenBitisTrh;

        private void deOngorulenBitisTarihi_EditValueChanged(object sender, EventArgs e)
        {
            if (deOngorulenBitisTarihi.EditValue != null)
            {
                if (deOngorulenBitisTarihi.EditValue.ToString().Length > 0)
                    OngorulenBitisTrh = (DateTime?)deOngorulenBitisTarihi.EditValue;
                else
                    OngorulenBitisTrh = null;
            }
        }

        private DateTime? BitisZaman;

        private void deBitisZaman_EditValueChanged(object sender, EventArgs e)
        {
            if (deBitisZaman.EditValue != null)
            {
                if (deBitisZaman.EditValue.ToString().Length > 0)
                    BitisZaman = (DateTime?)deBitisZaman.EditValue;
                else
                    BitisZaman = null;
            }
        }

        private string IsAciklama;

        private void mexAciklama_TextChanged(object sender, EventArgs e)
        {
            IsAciklama = mexAciklama.Text;
            if (mexAciklama.Text == string.Empty)
                IsAciklama = null;
        }

        private string YapilacakIs;

        private void mexYapilcakIs_TextChanged(object sender, EventArgs e)
        {
            YapilacakIs = mexYapilcakIs.Text;
            if (mexYapilcakIs.Text == string.Empty)
                YapilacakIs = null;
        }

        private int? Oncelik;

        private void lkIsOncelik_EditValueChanged(object sender, EventArgs e)
        {
            if (lkIsOncelik.EditValue != null)
                Oncelik = (int?)lkIsOncelik.EditValue;
            else
                Oncelik = null;
        }

        private int? SubeKod;

        private void lkSubeKod_EditValueChanged(object sender, EventArgs e)
        {
            if (lkSubeKod.EditValue != null)
                SubeKod = (int?)lkSubeKod.EditValue;
            else
                SubeKod = null;
        }

        private int? Statu;

        private void appStatu_EditValueChanged(object sender, EventArgs e)
        {
            if (appStatu.EditValue != null)
                Statu = (int?)appStatu.EditValue;
            else
                Statu = null;
        }

        private int? Etiket;

        //private void appEtiket_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (appEtiket.EditValue != null)
        //        Etiket = (int?)appEtiket.EditValue;
        //    else
        //        Etiket = null;
        //}

        private int IsDurum;

        //private void rgIsDurum_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (rgIsDurum.SelectedIndex == 0)
        //    {
        //        IsDurum = false;
        //    }
        //    else if (rgIsDurum.SelectedIndex == 1)
        //    {
        //        IsDurum = true;
        //    }
        //}

        private string Yer;

        private void txeYer_TextChanged(object sender, EventArgs e)
        {
            Yer = txeYer.Text;
            if (txeYer.Text == string.Empty)
                Yer = null;
        }

        private string Konu;

        private void txeKonu_TextChanged(object sender, EventArgs e)
        {
            Konu = txeKonu.Text;
            if (txeKonu.Text == string.Empty)
                Konu = null;
        }

        private string IsNo;

        //private void txeIsNo_TextChanged(object sender, EventArgs e)
        //{
        //    IsNo = txeIsNo.Text;
        //    if (txeIsNo.Text == string.Empty)
        //        IsNo = null;
        //}

        private int? Kullanici;

        //private void lueKullanici_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueKullanici.EditValue != null)
        //        Kullanici = (int?)lueKullanici.EditValue;
        //    else
        //        Kullanici = null;
        //}

        private string RefNo;

        private void txeReferansNo_TextChanged(object sender, EventArgs e)
        {
            RefNo = txeReferansNo.Text;
            if (txeReferansNo.Text == string.Empty)
                RefNo = null;
        }

        private bool? Ajanda;

        private bool? Hatirlatma;

        private int? IsTarafCari;

        private void lueIsTarafCari_EditValueChanged(object sender, EventArgs e)
        {
            if (lueIsTarafCari.EditValue != null)
                IsTarafCari = (int?)lueIsTarafCari.EditValue;
            else
                IsTarafCari = null;
        }

        private int? IsTaraf;

        //private void lueIstaraf_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueIstaraf.EditValue != null)
        //        IsTaraf = (int?)lueIstaraf.EditValue;
        //    else
        //        IsTaraf = null;
        //}

        //private int? Sorumlu;

        //private void lueSorumlu_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueSorumlu.EditValue != null)
        //        Sorumlu = (int?)lueSorumlu.EditValue;
        //    else
        //        Sorumlu = null;
        //}

        //private int? IsSozlesme;

        //private void lueSozlesme_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueSozlesme.EditValue != null)
        //        IsSozlesme = (int?)lueSozlesme.EditValue;
        //    else
        //        IsSozlesme = null;
        //}

        //private int? MaddeKalem;

        //private void lueMaddeKalem_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueMaddeKalem.EditValue != null)
        //        MaddeKalem = (int?)lueMaddeKalem.EditValue;
        //    else
        //        MaddeKalem = null;
        //}

        //private int? IsSurec;

        //private void lueIsSurec_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueIsSurec.EditValue != null)
        //        IsSurec = (int?)lueIsSurec.EditValue;
        //    else
        //        IsSurec = null;
        //}

        //private DateTime? TmmBaslangicTrh;

        //private void dtTmmBaþlangisT_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (dtTmmBaþlangisT.EditValue != null)
        //    {
        //        if (dtTmmBaþlangisT.EditValue.ToString().Length > 0)
        //            TmmBaslangicTrh = (DateTime?)dtTmmBaþlangisT.EditValue;
        //        else
        //            TmmBaslangicTrh = null;
        //    }
        //}

        //private DateTime? TmmBitisTrh;

        //private void dtBitisZamani_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (dtBitisZamani.EditValue.ToString().Length > 0)
        //        TmmBitisTrh = (DateTime?)dtBitisZamani.EditValue;
        //    else
        //        TmmBitisTrh = null;
        //}

        //private string SurecAciklama;

        //private void memSürecAciklama_TextChanged(object sender, EventArgs e)
        //{
        //    SurecAciklama = memSürecAciklama.Text;
        //    if (memSürecAciklama.Text == string.Empty)
        //        SurecAciklama = null;
        //}

        //private decimal? BirimFiyat;

        //private void spBirimFiyat_EditValueChanged(object sender, EventArgs e)
        //{
        //    BirimFiyat = (decimal?)spBirimFiyat.EditValue;
        //    if (BirimFiyat == 0)
        //        BirimFiyat = null;
        //}

        //private decimal? ToplamFiyat;

        //private void spToplamFiyat_EditValueChanged(object sender, EventArgs e)
        //{
        //    ToplamFiyat = (decimal?)spToplamFiyat.EditValue;
        //    if (ToplamFiyat == 0)
        //        ToplamFiyat = null;
        //}

        //private int? BirimFiyatBrm;

        //private void lueBirimFiyatDoviz_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueBirimFiyatDoviz.EditValue != null)
        //        BirimFiyatBrm = (int?)lueBirimFiyatDoviz.EditValue;
        //    else
        //        BirimFiyatBrm = null;
        //}

        //private int? ToplamFiyatBrm;

        //private void lueToplamFiyatDoviz_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (lueToplamFiyatDoviz.EditValue != null)
        //        ToplamFiyatBrm = (int?)lueToplamFiyatDoviz.EditValue;
        //    else
        //        ToplamFiyatBrm = null;
        //}

        //private bool? Muhasebeles;

        //private void chcMuheseblestirilmis_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chcMuheseblestirilmis.Checked)
        //    {
        //        chcMuheseblestirilmis.Text = "Muhasebelestirilsin";
        //        Muhasebeles = false;
        //    }
        //    else
        //    {
        //        chcMuheseblestirilmis.Text = "Muhasebelestirilmesin";
        //        Muhasebeles = true;
        //    }
        //}

        //private int? Sure;

        //private void spSure_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (spSure.EditValue != null)
        //    {
        //        if ((int)spSure.EditValue > 0)
        //            Sure = (int?)spSure.EditValue;
        //        else
        //            Sure = null;
        //    }
        //}


        #endregion

    }
}