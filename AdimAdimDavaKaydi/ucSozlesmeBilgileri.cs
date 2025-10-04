using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Model.EntityClasses;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;

namespace AdimAdimDavaKaydi
{
    public partial class ucSozlesmeBilgileri : AvpXUserControl
    {
        public bool Formdanmi;
        public int SozlesmeDegerBrm;
        public decimal SozlesmeDegeri;
        private TList<AV001_TDI_BIL_SOZLESME> _MyDataSource;
        private DateTime BasTarih;
        private DateTime BitTarih;
        private VList<per_TDI_KOD_SOZLESME_ALT_TIP> cloneAltTip;
        private VList<per_TDI_KOD_SOZLESME_TIP> cloneTip;

        //    Menkul_Kira_Sozlesmesi = 1,
        //    Gayrimenkul_Kira_Sozlesmesi = 2,
        //    Hasilat_Kira_Sozlesmesi = 3,
        //    Kredi_Karti_Sozlesmesi = 4,
        //    Gayrimenkul_Ipotegi = 5,
        //    Gemi_Ipotegi = 6,
        //    Hava_Araci_Ipotegi = 7,
        //    Arac_Rehni = 8,
        //    Ticari_Isletme_Rehni = 9,
        //    Menkul_Mal_Rehni = 10,
        //    Menkul_Kiymet_Rehni = 11,
        //    Mevduat_Rehni = 12,
        //    Ticari_Senet_Rehni = 13,
        //    Genel_Kredi_Sozlesmesi = 14,
        //    Esas_Sozlesmesi__Komandit_Sirket_ = 65,
        //    Esas_Sozlesmesi__Limited_Sirket_ = 66,
        //    Eserin_Yayin_Hakkinin_Devri_Sozlesmesi = 67,
        //    Evlat_Edinme_Senedi_Sozlesmesi = 68,
        //    Faktoring_Hizmetleri_Sozlesmesi = 69,
        //    Finansal_Kiralama_Sozlesmesi = 70,
        //    Finansman_Sozlesmesi = 71,
        //    FOB_Satis_Sozlesmesi = 72,
        //    Franchise_Sozlesmesi = 73,
        //    Garanti_Sozlesmesi = 74,
        //    Gayrimenkul_Satis_Vaadi_Sozlesmesi = 75,
        //    Gelir_Paylasim_Sozlesmesi = 76,
        //    Genel_Cerrahi_Sozlesmesi = 77,
        //    Gizlilik_Sozlesmesi = 78,
        //    Gorsel_Urun_Kullanim_Sozlesmesi = 79,
        //    Gozetim_ve_Danismanlik_Hizmetleri_Sozlesmesi = 80,
        //    Grup_Hayat_Sigorta_Sozlesmesi = 81,
        //    Guvenlik_Hizmetleri_Sozlesmesi = 82,
        //    Hesap_Rehin_Sozlesmesi = 83,
        //    Hisse_Devir_Sozlesmesi = 84,
        //    Hisse_Opsiyon_Sozlesmesi = 85,
        //    Hisse_Rehni_Sozlesmesi = 86,
        //    Hisse_Satis_ve_Devir_Sozlesmesi = 87,
        //    Holding_Ana_Sozlesmesi = 88,
        //    Hukuki_Danismanlik_Sozlesmesi = 89,
        //    ISO_Danismanlik_Sozlesmesi = 90,
        //    Ibra_Sozlesmesi = 91,
        //    Icraci_Oyuncu_Sozlesmesi = 92,
        //    Icerik_Lisans_Sozlesmesi = 93,
        //    Ihracatlarda_Aracilik_Yapilmasina_Dair_Sozlesme = 94,
        //    Imalatci_Kodlandirma_Sozlesmesi = 95,
        //    Imtiyaz_Sozlesmesi = 96,
        //    Inhisari_Lisans_Sozlesmesi = 97,
        //    Internet_Abonman_Sozlesmesi = 98,
        //    Internet_Alisveris_Sitesi_Uye_Isyeri_Sozlesmesi = 99,
        //    Internet_Erisim_ve_Hizmet_Sozlesmesi = 100,
        //    Intifa_Hakki_Tesis_ve_Temlik_Sozlesmesi = 101,
        //    Irtifak_Hakki_Sozlesmesi = 102,
        //    Istisna__Yapim__Sozlesmesi = 103,
        //    Isbirligi_Sozlesmesi = 104,
        //    Istira_Sozlesmesi = 105,
        //    Isyeri_Hekimligi_Sozlesmesi = 106,
        //    Joint_Venture_Sozlesmesi = 107,
        //    Kaydi_Hayatla_Irat_Sozlesmesi = 108,
        //    Kayit_Mekanik_Lisans_Sozlesmesi = 109,
        //    Konsinye_Satis_Sozlesmesi = 110,
        //    Konsorsiyum_Sozlesmesi = 111,
        //    Konut_Tahsis_Sozlesmesi = 112,
        //    Kooperatif_Ana_Sozlesmesi = 113,
        //    Kosgeb_Destekleri_Protokolu = 114,
        //    Kredi_Karti_Uye_Isyeri_Programi_Sozlesmesi = 115,
        //    Kredi_Karti_Uyelik_Sozlesmesi = 116,
        //    Kredili_Menkul_Kiymet_Sozlesmesi = 117,
        //    Kullandirma_Sozlesmesi = 118,
        //    Kurumsal_Itibar_Arastirmasi_Sozlesmesi = 119,
        //    Link_Ekle_Kazan_Sozlesmesi = 120,
        //    Lisans_Sozlesmesi = 121,
        //    Mail_Order_Sozlesmesi = 122,
        //    Mal_Ayriligi_Sozlesmesi = 123,
        //    Mal_Ortakligi_Sozlesmesi = 124,
        //    Mal_Rejimi__Edinilmis_Mallara_Katilma__Sozlesmesi = 125,
        //    Mali_Haklarin_Devri_Sozlesmesi = 126,
        //    Malzeme_Devir_Sozlesmesi = 127,
        //    Marka_Devir_Sozlesmesi = 128,
        //    Marka_Lisans_Sozlesmesi = 129,
        //    Menajerlik_Sozlesmesi = 130,
        //    Mimarlik_Hizmetleri_Sozlesmesi = 131,
        //    Miras_Mukavelesi = 132,
        //    Miras_Payinin_Devri_Sozlesmesi = 133,
        //    Miras_Paylastirmasi_Sozlesmesi = 134,
        //    Mirastan_Feragat_Sozlesmesi = 135,
        //    Muhasebe_Hizmetleri_Sozlesmesi = 136,
        //    Mulkiyeti_Muhafaza_Kaydi_ile_Satis_Sozlesmesi = 137,
        //    Munhasir_Yetkili_Satici_Sozlesmesi = 138,
        //    Musterek_Hesap_Sozlesmesi = 139,
        //    Opsiyonlu_Satis_Sozlesmesi = 140,
        //    Ortak_Girisim_Beyannamesi = 141,
        //    Ortak_Yaratim_Lisans_Sozlesmesi = 142,
        //    Otomobil_Kiralama_Sozlesmesi = 143,
        //    Otoproduktor_Sozlesmesi = 144,
        //    Patent_Devir_Sozlesmesi = 145,
        //    Patent_Lisans_Sozlesmesi = 146,
        //    Produksiyon_Sozlesmesi = 147,
        //    Promosyonel_Isbirligi_Sozlesmesi = 148,
        //    Rekabet_Etmeme_Sozlesmesi = 149,
        //    Sanati_Icra_Sozlesmesi = 150,
        //    Satis_Sozlesmesi = 151,
        //    Sureli_Hizmet_Sozlesmesi = 152,
        //    Suresiz_Hizmet_Sozlesmesi = 153,
        //    Tanitim_Sozlesmesi = 154,
        //    Tasarim_Yatirim_ve_Insa_Sozlesmesi = 155,
        //    Tasima_Hizmetleri_Sozlesmesi = 156,
        //    Teknik_Servis_Hizmet_Sozlesmesi = 157,
        //    Telif_Ucreti_Sozlesmesi = 158,
        //    Test_Sozlesmesi = 159,
        //    Tibbi_Tetkik_ve_Tedavi_Sozlesmesi = 160,
        //    Transfer_Sozlesmesi = 161,
        //    Uzlasma_Sozlesmesi = 162,
        //    Urun_Satin_Alim_Sozlesmesi = 163,
        //    Vekalet_Ucret_Sozlesmesi = 164,
        //    Yapit_Yayim_Sozlesmesi = 165,
        //    Yonetmen_Sozlesmesi = 166,
        //    Abonelik_Sozlesmesi = 15,
        //    Abonman_Sozlesmesi = 16,
        //    Acentelik_Sozlesmesi = 17,
        //    Akreditif_Sozlesmesi = 18,
        //    Alan_Adi_Kullanici_Sozlesmesi = 19,
        //    Alim_Satim_Aracilik_Sozlesmesi = 20,
        //    Alt_Kiralama_Sozlesmesi = 21,
        //    Alt_Muteahhitlik_Sozlesmesi = 22,
        //    Alt_Tasima_Sozlesmesi = 23,
        //    Alt_Yayimcilik_Sozlesmesi = 24,
        //    Arac_Satis_Sozlesmesi = 25,
        //    Arastirma_Sozlesmesi = 26,
        //    Ardiye_Sozlesmesi = 27,
        //    Ariyet_Sozlesmesi = 28,
        //    Kat_Karsiligi_Insaat_Sozlesmesi = 29,
        //    Arsa_Tahsis_Sozlesmesi = 30,
        //    Av_Ort_Ana_Sozlesmesi = 31,
        //    Avukatlik_Sozlesmesi = 32,
        //    Bagimsiz_Ozel_Denetim_Sozlesmesi = 33,
        //    Bagislama_Sozlesmesi = 34,
        //    Banka_Teminat_Mektubu = 35,
        //    Bankacilik_Islemleri_Sozlesmesi = 36,
        //    Barkod_Hizmet_Sozlesmesi = 37,
        //    Barter__Takas__Sozlesmesi = 38,
        //    Basin_Danismanligi_ve_Menajerlik_Sozlesmesi = 39,
        //    Bayilik_Sozlesmesi = 40,
        //    Belirli_Sureli_Is_Sozlesmesi = 41,
        //    Bilet_Satis_Sozlesmesi = 42,
        //    Birlesme_Sozlesmesi = 43,
        //    Birlik_Kurma_Sozlesmesi = 44,
        //    Borcu_Ustlenme_Sozlesmesi = 45,
        //    Borc_Yapilandirma_Sozlesmesi = 46,
        //    Bolunme_Sozlesmesi = 47,
        //    Buluslar_ve_Patentler_Hakkinda_Is_Sozlesmesi = 48,
        //    Cari_Hesap_Sozlesmesi = 49,
        //    CFR_Satis_Sozlesmesi = 50,
        //    Ceviri_Yapit_Sozlesmesi = 51,
        //    Ciraklik_Sozlesmesi = 52,
        //    Dagitici_Sozlesmesi = 53,
        //    Danismanlik_Sozlesmesi = 54,
        //    Delil_Sozlesmesi = 55,
        //    Depolama_ve_Sevkiyat_Sozlesmesi = 56,
        //    Destek_Hizmetleri_Sozlesmesi = 57,
        //    Devir_ve_Satis_Sozlesmesi = 58,
        //    Devre_Mulk___Tatil_Sozlesmesi = 59,
        //    Distributorluk_Sozlesmesi = 60,
        //    Dizi_Sozlesmesi = 61,
        //    Doviz_Alim_Satim_Sozlesmesi = 62,
        //    Esas_Sozlesmesi__Anonim_Sirket_ = 63,
        //    Esas_Sozlesmesi__Kollektif_Sirket_ = 64,
        //}

        private AV001_TI_BIL_FOY myIcraFoy;
        private TList<AV001_TI_BIL_FOY_TARAF> myIcraTaraf;
        private int SaltTipi;
        private int Sanatip;
        private AV001_TDI_BIL_SOZLESME sTemp = new AV001_TDI_BIL_SOZLESME();
        private FormTipleri tip;

        public ucSozlesmeBilgileri()
        {
            InitializeComponent();
        }

        [Category("SozlesmeBilgileri")]
        public event IndexChangedEventHandler FocusedSozlesmeChanged;

        [Category("SozlesmeBilgileri")]
        public event ValidateRecordEventHandler SozlesmeValidateRecord;

        [Browsable(false)]
        public AV001_TDI_BIL_SOZLESME CurrSozlesme
        {
            get
            {
                if (MyDataSource != null && vgSozlesmeBilgileri.FocusedRecord > -1 && MyDataSource.Count > 0)

                    return MyDataSource[vgSozlesmeBilgileri.FocusedRecord];
                else
                    return null;
            }
        }

        [Browsable(false)]
        public TList<AV001_TDI_BIL_SOZLESME> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;

                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return myIcraFoy; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myIcraFoy = value;
                    tip = (FormTipleri)myIcraFoy.FORM_TIP_ID;
                }
            }
        }

        [Browsable(false)]
        public TList<AV001_TI_BIL_FOY_TARAF> MyIcraTaraf
        {
            get { return myIcraTaraf; }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    myIcraTaraf = value;
                }
            }
        }

        public void AlacakNedenKonusunaGoreSekillen(object param1)
        {
        }

        public void BindData()
        {
            if (MyDataSource != null && !this.DesignMode)
            {
                MyDataSource.AddingNew += MyDataSource_AddingNew;
                if (MyDataSource != null && MyDataSource.Count > 0)
                {
                    foreach (var item in MyDataSource)
                    {
                        item.ColumnChanged += ucSozlesmeBilgileri_ColumnChanged;
                    }
                }
                bndSozlesmeBilgileri.DataSource = MyDataSource;
                if (Formdanmi)
                    dataNavigatorExtended1.Visible = false;
            }
        }

        public void dataNavigatorExtended1_OnCevirClick(object sender, EventArgs e)
        {
            if (vgSozlesmeBilgileri.Visible)
            {
                vgSozlesmeBilgileri.DataSource = null;
                vgSozlesmeBilgileri.Visible = false;
                gridControl1.Visible = true;
                gridControl1.BringToFront();
                gridControl1.DataSource = MyDataSource;
            }
            else
            {
                gridControl1.DataSource = null;
                vgSozlesmeBilgileri.Visible = true;
                vgSozlesmeBilgileri.BringToFront();
                gridControl1.Visible = false;
                vgSozlesmeBilgileri.DataSource = MyDataSource;
            }
        }

        public void SozlesmeAltipineGoreSekiilen(int s)
        {
            //12

            SaltTipi = s;
            switch (s)
            {
                case 10:
                    catRowSozlesmeBilgileri.Visible = false;
                    catRowTahliye.Visible = false;
                    catRowOnayMakamý.Visible = true;
                    catRowKrediBilgileri.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    FekT.Visible = false;
                    rowTIP_ID.Visible = false;
                    rowSekli.Visible = false;
                    rowTICARI_ISLETME_ADI.Visible = true;
                    rowTICARI_ISLETME_UNVANI.Visible = true;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = true;
                    Bedeli_Kur.PropertiesCollection[0].Caption = "Rehin/Ýpotek Limiti";
                    SozlesmeDurumID.Visible = false;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = false;
                    DurumAciklama.Visible = true;
                    YediEminCariID.Visible = true;
                    break;

                case 12:
                    catRowSozlesmeBilgileri.Visible = false;
                    catRowTahliye.Visible = false;
                    catRowOnayMakamý.Visible = true;
                    catRowKrediBilgileri.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    FekT.Visible = false;
                    rowTIP_ID.Visible = false;
                    rowSekli.Visible = false;
                    rowTICARI_ISLETME_ADI.Visible = true;
                    rowTICARI_ISLETME_UNVANI.Visible = true;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = true;
                    Bedeli_Kur.PropertiesCollection[0].Caption = "Rehin/Ýpotek Limiti";
                    SozlesmeDurumID.Visible = false;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = false;
                    DurumAciklama.Visible = true;
                    YediEminCariID.Visible = true;
                    mRowBankaSube.Visible = true;
                    break;

                case 9:
                case 13:
                    catRowTahliye.Visible = false;
                    catRowKrediBilgileri.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    FekT.Visible = false;
                    rowTIP_ID.Visible = false;
                    rowSekli.Visible = false;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = false;
                    SözlesmeAdi.Visible = false;
                    Bedeli_Kur.PropertiesCollection[0].Caption = "Rehin/Ýpotek Limiti";
                    SureGunAyYil.Visible = false;

                    //ImzaT_Sekli.Visible = false;
                    OdemeTurGun.Visible = false;
                    SozlesmeDurumID.Visible = false;
                    DurumAciklama.Visible = true;
                    break;

                case 5:
                case 7:
                case 6:
                    catRowSozlesmeBilgileri.Visible = false;
                    catRowTahliye.Visible = false;
                    catRowOnayMakamý.Visible = false;
                    catRowKrediBilgileri.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    FekT.Visible = false;

                    //rowTIP_ID.Visible = false;
                    rowSekli.Visible = false;
                    rowTICARI_ISLETME_ADI.Visible = true;
                    rowTICARI_ISLETME_UNVANI.Visible = true;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = true;
                    Bedeli_Kur.PropertiesCollection[0].Caption = "Rehin/Ýpotek Limiti";
                    SozlesmeDurumID.Visible = false;
                    DurumAciklama.Visible = true;
                    break;

                case 1:
                case 2:
                case 3:
                    rowSekli.Visible = false;
                    rowTIP_ID.Visible = false;
                    SozlesmeDurumID.Visible = false;
                    SözlesmeAdi.Visible = false;
                    rowTICARI_ISLETME_ADI.Visible = false;
                    rowTICARI_ISLETME_UNVANI.Visible = false;
                    RehinCinsAnaTur.Visible = false;
                    FekT.Visible = false;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = false;
                    catRowSicilBilgileri.Visible = false;
                    catRowKrediBilgileri.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    DurumAciklama.Visible = true;
                    catRowOnayMakamý.Expanded = false;

                    break;

                case 14:
                case 167:
                case 168:
                case 169:
                case 170:
                case 171:

                    catRowSozlesmeBilgileri.ChildRows.Add(Bedeli_Kur);
                    catRowDigerBilgiler.Visible = false;
                    editorRow1.Visible = false;
                    break;

                case 8:
                    if (catRowSicilBilgileri.ChildRows.GetRowByFieldName("BEDELI") != Bedeli_Kur)
                        catRowSicilBilgileri.ChildRows.Add(Bedeli_Kur);
                    catRowSozlesmeBilgileri.Visible = false;
                    catRowIpotek.Visible = false;
                    editorRow1.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    break;

                case 172:
                    if (catRowSicilBilgileri.ChildRows.GetRowByFieldName("BEDELI") != Bedeli_Kur)
                        catRowSozlesmeBilgileri.ChildRows.Add(Bedeli_Kur);
                    catRowIpotek.Visible = false;
                    catRowOnayMakamý.Visible = false;
                    catRowSicilBilgileri.Visible = false;
                    editorRow1.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    catRowSozlesmeBilgileri.ChildRows.Add(Aciklama);
                    rowTICARI_ISLETME_ADI.Visible = false;
                    rowTICARI_ISLETME_UNVANI.Visible = false;
                    // ImzaT_Sekli.Visible = false;
                    SureGunAyYil.Visible = false;
                    break;

                case 177:
                case 178:
                    if (catRowSicilBilgileri.ChildRows.GetRowByFieldName("BEDELI") != Bedeli_Kur)
                        catRowSozlesmeBilgileri.ChildRows.Add(Bedeli_Kur);
                    catRowDigerBilgiler.Visible = false;
                    editorRow1.Visible = false;
                    break;

                case 173:
                    catRowSozlesmeBilgileri.ChildRows.Add(Bedeli_Kur);
                    catRowIpotek.Visible = false;
                    catRowSicilBilgileri.Visible = false;
                    editorRow1.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    catRowSozlesmeBilgileri.ChildRows.Add(Aciklama);
                    rowTICARI_ISLETME_ADI.Visible = false;
                    rowTICARI_ISLETME_UNVANI.Visible = false;
                    // ImzaT_Sekli.Visible = false;
                    SureGunAyYil.Visible = false;
                    break;

                case 174:
                    if (catRowSicilBilgileri.ChildRows.GetRowByFieldName("BEDELI") != Bedeli_Kur)
                        catRowSozlesmeBilgileri.ChildRows.Add(Bedeli_Kur);
                    catRowOnayMakamý.Visible = false;
                    catRowIpotek.Visible = false;
                    catRowSicilBilgileri.Visible = false;
                    editorRow1.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    catRowSozlesmeBilgileri.ChildRows.Add(Aciklama);
                    rowTICARI_ISLETME_ADI.Visible = false;
                    rowTICARI_ISLETME_UNVANI.Visible = false;
                    //ImzaT_Sekli.Visible = false;
                    SureGunAyYil.Visible = false;
                    break;

                case 175:
                case 86:
                    if (catRowSicilBilgileri.ChildRows.GetRowByFieldName("BEDELI") != Bedeli_Kur)
                        catRowSozlesmeBilgileri.ChildRows.Add(Bedeli_Kur);
                    catRowOnayMakamý.Visible = false;
                    catRowIpotek.Visible = false;
                    catRowSicilBilgileri.Visible = false;
                    editorRow1.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    catRowSozlesmeBilgileri.ChildRows.Add(Aciklama);
                    rowTICARI_ISLETME_ADI.Visible = false;
                    rowTICARI_ISLETME_UNVANI.Visible = false;
                    //ImzaT_Sekli.Visible = false;
                    SureGunAyYil.Visible = false;
                    break;
                default:

                    break;
            }

            ImzaT_Sekli.Visible = true;
            rowBaslangicT.Visible = true;
        }

        public void SozlesmeRefresh()
        {
            vgSozlesmeBilgileri.Refresh();
        }

        public void SozlesmeYapilandir(SozlesmeAnaTip s)
        {
            switch (s)
            {
                case SozlesmeAnaTip.Genel_Sozleme:
                    HepsiniGoster();
                    foreach (BaseRow row in vgSozlesmeBilgileri.Rows)
                    {
                        if (row is CategoryRow)
                        {
                            if (row.Tag.ToString() == "Sicil" || row.Tag.ToString() == "Kredi" ||
                                row.Tag.ToString() == "Tahliye" || row.Tag.ToString() == "TicariIslemler")
                                row.Visible = false;
                            foreach (BaseRow item in catRowIpotek.ChildRows)
                            {
                                if (item.Name != Bedeli_Kur.Name)
                                    item.Visible = false;
                                catRowIpotek.Properties.Caption = "Bedeli";
                            }
                        }
                    }

                    //sozlesmetipi = 4;
                    break;

                case SozlesmeAnaTip.Hakem_Sozlemesi:
                    HepsiniGoster();
                    foreach (BaseRow row in vgSozlesmeBilgileri.Rows)
                    {
                        if (row is CategoryRow)
                        {
                            if (row.Tag.ToString() == "Ýpotek" || row.Tag.ToString() == "Sicil" ||
                                row.Tag.ToString() == "Kredi" || row.Tag.ToString() == "Tahliye" ||
                                row.Tag.ToString() == "TicariIslemler")
                                row.Visible = false;
                        }
                    }

                    //sozlesmetipi = 10007;
                    break;

                case SozlesmeAnaTip.Marka_Patent_Sozlemesi:
                    HepsiniGoster();
                    foreach (BaseRow row in vgSozlesmeBilgileri.Rows)
                    {
                        if (row is CategoryRow)
                        {
                            if (row.Tag.ToString() == "Sicil" || row.Tag.ToString() == "Kredi" ||
                                row.Tag.ToString() == "Tahliye" || row.Tag.ToString() == "TicariIslemler")
                                row.Visible = false;
                            foreach (BaseRow item in catRowIpotek.ChildRows)
                            {
                                if (item.Name != Bedeli_Kur.Name)
                                    item.Visible = false;
                                catRowIpotek.Properties.Caption = "Bedeli";
                            }
                        }
                    }

                    //sozlesmetipi = 10008;
                    break;

                case SozlesmeAnaTip.Kira_Sozlemesi:
                    HepsiniGoster();
                    foreach (BaseRow row in vgSozlesmeBilgileri.Rows)
                    {
                        if (row is CategoryRow)
                        {
                            if (row.Tag.ToString() == "Ýpotek" || row.Tag.ToString() == "Kredi" ||
                                row.Tag.ToString() == "TicariIslemler")
                                row.Visible = false;
                        }
                    }

                    //sozlesmetipi = 1;
                    break;

                case SozlesmeAnaTip.Kredi_Sozlemesi:
                    HepsiniGoster();
                    foreach (BaseRow row in vgSozlesmeBilgileri.Rows)
                    {
                        if (row is CategoryRow)
                        {
                            if (row.Tag.ToString() == "Ýpotek" || row.Tag.ToString() == "Sicil" ||
                                row.Tag.ToString() == "Onay" || row.Tag.ToString() == "Tahliye" ||
                                row.Tag.ToString() == "TicariIslemler")
                                row.Visible = false;
                        }
                    }

                    //sozlesmetipi = 2;
                    break;

                case SozlesmeAnaTip.Resmi_Senet:
                    HepsiniGoster();
                    foreach (BaseRow row in vgSozlesmeBilgileri.Rows)
                    {
                        if (row is CategoryRow)
                        {
                            if (row.Tag.ToString() == "Kredi" || row.Tag.ToString() == "Tahliye")
                                row.Visible = false;
                            catRowIpotek.Properties.Caption = "Ýpotek Rehin Bilgileri";
                            foreach (BaseRow item in catRowIpotek.ChildRows)
                            {
                                if (item.Name == HarcIstisna_Belge.Name || item.Name == BorcIkramiyemiHaviMi.Name)
                                    item.Visible = false;
                                else
                                    item.Visible = true;
                            }
                        }
                    }

                    //sozlesmetipi = 3;
                    break;
                default:
                    break;
            }
            if (Kimlikci.Kimlik.SirketBilgisi.KurumsalMod == 1501)
            {
                rowTIP_ID.Visible = false;
                SözlesmeAdi.Visible = false;
                if (Bedeli_Kur.Visible == false)
                {
                    Bedeli_Kur.Visible = true;
                    catRowSozlesmeBilgileri.ChildRows.Add(Bedeli_Kur);
                }

                if (s == SozlesmeAnaTip.Kredi_Sozlemesi)
                {
                    catRowKrediBilgileri.Visible = true;
                }
                else
                {
                    catRowKrediBilgileri.Visible = false;
                }
                ImzaT_Sekli.Visible = true;
                SureGunAyYil.Visible = false;

                //
                catRowDigerBilgiler.Visible = false;
            }
        }

        public void ucSozlesmeBilgileri_ColumnChanged(object sender, AV001_TDI_BIL_SOZLESMEEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME soz = sender as AV001_TDI_BIL_SOZLESME;
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.TIP_ID)
            {
                SozlesmeYapilandir((SozlesmeAnaTip)soz.TIP_ID);

                if (soz.TIP_ID == (int)SozlesmeAnaTip.Kira_Sozlemesi)
                {
                    vgSozlesmeBilgileri.Rows["ImzaT_Sekli"].Appearance.BackColor =
                        System.Drawing.Color.FromArgb(((((255)))), ((((128)))), ((((0)))));
                    vgSozlesmeBilgileri.Rows["ImzaT_Sekli"].Properties.ImageIndex = 0;

                    vgSozlesmeBilgileri.Rows["TahliyeAdresi"].Appearance.BackColor =
                        System.Drawing.Color.FromArgb(((((255)))), ((((128)))), ((((0)))));
                    vgSozlesmeBilgileri.Rows["TahliyeAdresi"].Properties.ImageIndex = 0;

                    vgSozlesmeBilgileri.Rows["Bedeli_Kur"].Appearance.BackColor =
                        System.Drawing.Color.FromArgb(((((255)))), ((((128)))), ((((0)))));
                    vgSozlesmeBilgileri.Rows["Bedeli_Kur"].Properties.ImageIndex = 0;
                }
                else
                {
                    vgSozlesmeBilgileri.Rows["ImzaT_Sekli"].Appearance.BackColor = System.Drawing.Color.White;
                    vgSozlesmeBilgileri.Rows["ImzaT_Sekli"].Properties.ImageIndex = -1;

                    vgSozlesmeBilgileri.Rows["TahliyeAdresi"].Appearance.BackColor = System.Drawing.Color.White;
                    vgSozlesmeBilgileri.Rows["TahliyeAdresi"].Properties.ImageIndex = -1;

                    vgSozlesmeBilgileri.Rows["Bedeli_Kur"].Appearance.BackColor = System.Drawing.Color.White;
                    vgSozlesmeBilgileri.Rows["Bedeli_Kur"].Properties.ImageIndex = -1;
                }
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.BITIS_TARIHI)
            {
                if (e.Value != null)
                {
                    BitTarih = (DateTime)e.Value;
                    int gun = 0;
                    int ay = 0;
                    int yil = 0;
                    DateTime time = DateTime.MinValue;
                    if (BasTarih == time)
                        BasTarih = DateTime.Now;
                    gun = BitTarih.Day - BasTarih.Day;
                    soz.SURE_GUN = (short)gun;
                    ay = BitTarih.Month - BasTarih.Month;
                    soz.SURE_AY = (short)ay;
                    yil = BitTarih.Year - BasTarih.Year;
                    soz.SURE_YIL = (short)yil;
                }
                else
                {
                    soz.SURE_GUN = 0;
                    soz.SURE_AY = 0;
                    soz.SURE_YIL = 0;
                }
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.BASLANGIC_TARIHI)
            {
                BasTarih = (DateTime)e.Value;
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.ALT_TIP_ID)
            {
                //if (MyIcraFoy != null)
                //{
                SozlesmeAltipineGoreSekiilen((int)e.Value);

                //}
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.IMZA_TARIHI)
            {
                soz.SICIL_TARIHI = BelgeUtil.Inits.ToDateTime(e.Value);
                soz.BASLANGIC_TARIHI = BelgeUtil.Inits.ToDateTime(e.Value);
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.BEDELI)
            {
                SozlesmeDegeri = (decimal)e.Value;
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.BEDELI_DOVIZ_ID)
            {
                SozlesmeDegerBrm = (int)e.Value;
            }
            if (e.Column == AV001_TDI_BIL_SOZLESMEColumn.REHIN_CINS_ANA_TURU)
            {
                if ((int)e.Value == 1)
                {
                    Bedeli_Kur.Enabled = false;
                    soz.REHIN_CINS_ANA_TURU = 1;
                }
                if ((int)e.Value == 0)
                {
                    Bedeli_Kur.Enabled = true;
                    soz.REHIN_CINS_ANA_TURU = 0;
                }
            }
        }

        private void dataNavigatorExtended1_OnListedenGetirClick(object sender,
                                                                 AdimAdimDavaKaydi.Util.ListedenGetirEventArgs e)
        {
            frmEkleSozlesme frm = new frmEkleSozlesme();

            if (myIcraFoy != null)
            {
                frm.myIcra = MyIcraFoy;
                frm.myIcraTrf = MyIcraTaraf;
                frm.AltTip = SaltTipi;
                frm.Anatip = Sanatip;
            }
            frm.alreadyAddedList = null;

            //frm.MdiParent = null;
            frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
            frm.Show();
            DialogResult dr = frm.KayitBasarili;

            if (dr == DialogResult.OK)
            {
                foreach (AV001_TDI_BIL_SOZLESME szl in frm.selectedList)
                {
                    if (MyDataSource.Find("ID", szl.ID) == null)
                    {
                        DataRepository.AV001_TDI_BIL_SOZLESMEProvider.DeepLoad(MyDataSource, false,
                                                                               DeepLoadType.IncludeChildren,
                                                                               typeof(TList<NN_SOZLESME_GAYRIMENKUL>));
                        MyDataSource.Add(szl);
                    }
                }
            }
        }

        private void ForumTipineGoreSozlesmeYapilenadir(FormTipleri t, AV001_TDI_BIL_SOZLESME s)
        {
            rowBAGIMSIZ_MI.Properties.ReadOnly = false;

            switch (t)
            {
                case FormTipleri.Form50:
                case FormTipleri.Form201:
                    catRowSozlesmeBilgileri.Visible = false;
                    catRowTahliye.Visible = false;
                    catRowOnayMakamý.Visible = true;
                    catRowKrediBilgileri.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    s.TIP_ID = (int)SozlesmeAnaTip.Resmi_Senet;
                    rowBaslangicT.Visible = true;
                    //s.TIP_ID = (int)SozlesmeAnaTip.ResmiSenet;
                    Sanatip = (int)SozlesmeAnaTip.Resmi_Senet;
                    gridColumn8.Caption = "Tanzim T.";
                    FekT.Visible = false;
                    rowTIP_ID.Visible = false;
                    rowSekli.Visible = false;
                    rowTICARI_ISLETME_ADI.Visible = true;
                    rowTICARI_ISLETME_UNVANI.Visible = true;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = true;
                    s.MUSTEREKMI_MUSTAKILMI = true;
                    Bedeli_Kur.PropertiesCollection[0].Caption = "Rehin/Ýpotek Limiti";
                    SozlesmeDurumID.Visible = false;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = false;
                    DurumAciklama.Visible = true;
                    YediEminCariID.Visible = true;
                    break;

                case FormTipleri.Form151:
                case FormTipleri.Form152:
                    catRowSozlesmeBilgileri.Visible = false;
                    catRowTahliye.Visible = false;
                    catRowOnayMakamý.Visible = false;
                    catRowKrediBilgileri.Visible = false;
                    catRowDigerBilgiler.Visible = false;
                    s.TIP_ID = (int)SozlesmeAnaTip.Resmi_Senet;

                    // s.TIP_ID = (int)SozlesmeAnaTip.ResmiSenet;
                    Sanatip = (int)SozlesmeAnaTip.Resmi_Senet;
                    gridColumn8.Caption = "Tanzim T.";
                    FekT.Visible = false;
                    rowTIP_ID.Visible = false;
                    rowSekli.Visible = false;
                    rowTICARI_ISLETME_ADI.Visible = true;
                    rowTICARI_ISLETME_UNVANI.Visible = true;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = true;
                    s.MUSTEREKMI_MUSTAKILMI = true;
                    Bedeli_Kur.PropertiesCollection[0].Caption = "Rehin/Ýpotek Limiti";
                    SozlesmeDurumID.Visible = false;
                    DurumAciklama.Visible = true;
                    break;

                case FormTipleri.Form49:
                case FormTipleri.Form51:
                    rowTICARI_ISLETME_ADI.Visible = false;
                    rowTICARI_ISLETME_UNVANI.Visible = false;
                    rowMUSTEREKMI_MUSTAKILMI.Visible = false;
                    if (MyIcraFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count > 0)
                    {
                        switch ((AlacakNeden)MyIcraFoy.AV001_TI_BIL_ALACAK_NEDENCollection[0].ALACAK_NEDEN_KOD_ID)
                        {
                            case AlacakNeden.Kira_43:
                            case AlacakNeden.Kira:
                            case AlacakNeden.Kira_5:
                            case AlacakNeden.KiraFarký_45:
                            case AlacakNeden.KiraFarký_46:
                            case AlacakNeden.KiraFarký_6:
                                s.TIP_ID = (int)SozlesmeAnaTip.Kira_Sozlemesi;

                                //s.TIP_ID = (int)SozlesmeTipi.Kira_Sozlemesi;
                                Sanatip = (int)SozlesmeAnaTip.Kira_Sozlemesi;
                                Bedeli_Kur.PropertiesCollection[0].Caption = "1Yýllýk Kira Bedeli";
                                break;

                            case AlacakNeden.BankaKrediKarti:
                            case AlacakNeden.BankaKrediKarti_9:
                            case AlacakNeden.BankaKrediAlacagi:
                            case AlacakNeden.BankaKrediAlacagi_10:
                                s.TIP_ID = (int)SozlesmeAnaTip.Kredi_Sozlemesi;

                                //s.TIP_ID = (int)SozlesmeTipi.Kredi_Sozlemesi;
                                Sanatip = (int)SozlesmeAnaTip.Kredi_Sozlemesi;

                                break;

                            case AlacakNeden.MenkulRehni_14:
                            case AlacakNeden.MenkulRehni_53:
                            case AlacakNeden.Ipotek_32:
                            case AlacakNeden.Ipotek_52:
                                s.TIP_ID = (int)SozlesmeAnaTip.Resmi_Senet;

                                //s.TIP_ID = (int)SozlesmeTipi.Teminat_Sozlemesi;
                                Sanatip = (int)SozlesmeAnaTip.Resmi_Senet;
                                break;

                            case AlacakNeden.ROTATIF_KREDI_151:
                            case AlacakNeden.ROTATIF_KREDI_152:
                            case AlacakNeden.ROTATIF_KREDI_201:
                            case AlacakNeden.ROTATIF_KREDI_50:
                            case AlacakNeden.ROTATIF_KREDI:
                                s.TIP_ID = (int)SozlesmeAnaTip.Resmi_Senet;
                                Sanatip = (int)SozlesmeAnaTip.Resmi_Senet;
                                break;
                            default:
                                break;
                        }
                    }
                    rLueSozlesmeTipi.ReadOnly = false;
                    break;
                default:

                    //rLueSozlesmeTipi.ReadOnly = false;
                    break;
            }
        }

        private void gridControl1_ButtonCevirClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (extendedGridControl1.Visible)
            {
                extendedGridControl1.Visible = false;
                gridControl1.Visible = true;
                gridControl1.BringToFront();
            }
            else
            {
                extendedGridControl1.Visible = true;
                gridControl1.Visible = false;
                extendedGridControl1.BringToFront();
            }
        }

        private void HepsiniGoster()
        {
            foreach (BaseRow row in vgSozlesmeBilgileri.Rows)
            {
                if (row is CategoryRow)
                {
                    row.Visible = true;
                }
            }
        }

        //Avukatprolib.extras 'a tasýndý.//[ZK]
        //[ZK]
        ///// <summary>
        ///// TDI_KOD_SOZLESME_ALT_TIP tablosundan oluþturulmuþtur.
        ///// </summary>
        //public enum SozlesmeAltTip
        //{
        //    //Menkul_Kira_Sozlesmesi = 1,
        //    //Gayrimenkul_Kira_Sozlesmesi = 2,
        //    //HasilatKiraSözlesmesi = 3,
        //    //Kredi_Karti_Sozlesmesi = 4,
        //    //Gayrimenkul_Ipotegi = 5,
        //    //Gemi_Ipotegi = 6,
        //    //Hava_Araci_Ipotegi = 7,
        //    //Arac_Rehni = 8,
        //    //Ticari_Isletme_Rehni = 9,
        //    //Menkul_Mal_Rehni = 10,
        //    //MenkulKiymetRehni = 11,
        //    //Mevduat_Rehni = 12,
        //    //Ticari_Senet_Rehni = 13,
        //    //Genel_Kredi_Sozlesmesi = 14,
        //    //UlusalHakemSözlesmesi = 10002,
        //    //UluslarArasýHakemSözlesmesi = 10003,
        //    //MarkaSozlesmesi = 10004,
        //    //PatentSozlesmesi = 10005,
        private void lookUpExtender1_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            //if (e.SenderLookUp != null)
            //    if (e.SenderLookUp.Properties.Tag == "OzelKod" && e.IsTypedValue)
            //    {
            //        try
            //        {
            //            TDI_KOD_SOZLESME_OZEL ozel = new TDI_KOD_SOZLESME_OZEL();
            //            ozel.SOZLESME_OZEL = e.TypedValue;
            //            DataRepository.TDI_KOD_SOZLESME_OZELProvider.Save(ozel);
            //            ((TList<TDI_KOD_SOZLESME_OZEL>)e.SenderLookUp.Properties.DataSource).Add(ozel);
            //            XtraMessageBox.Show("Özel Kod Baþarýyla Eklenmiþtir.");
            //        }
            //        catch (Exception ex)
            //        {
            //            BelgeUtil.ErrorHandler.Catch(this, ex);
            //        }
            //    }

            //Mehmet Emin AYDOGDU
            //Mehmet Begin
            if (e.SenderLookUp != null)
                if (e.SenderLookUp.Properties.Name.Contains("OzelKod"))
                {
                    try
                    {
                        byte alanNo = 0;
                        switch (e.SenderLookUp.Properties.Name)
                        {
                            case "rLueOzelKod1":
                                alanNo = 1;
                                break;

                            case "rLueOzelKod2":
                                alanNo = 2;
                                break;

                            case "rLueOzelKod3":
                                alanNo = 3;
                                break;

                            case "rLueOzelKod4":
                                alanNo = 4;
                                break;

                            default:
                                break;
                        }
                        frmFoyOzelKodEkle frm = new frmFoyOzelKodEkle();

                        frm.sozlesmeden = true;
                        DialogResult dr = frm.ShowDialog(alanNo, e.SenderLookUp.Text);

                        if (dr == DialogResult.OK)
                        {
                            Av001TdiKodFoyOzelEntity ozel = frm.MyOzelKod;
                            if (ozel != null)
                                ((List<Av001TdiKodFoyOzelEntity>)e.SenderLookUp.Properties.DataSource).Add(ozel);
                        }
                    }
                    catch (Exception ex)
                    {
                        BelgeUtil.ErrorHandler.Catch(this, ex);
                    }
                }

            //Mehmet End
        }

        private void lookUpExtender2_OnClickOrProcessNewValue(object sender, LookUpExtenderEventArgs e)
        {
            if (e.SenderLookUp.Properties.Name.Contains("rLueSozlesmeAltTip") && e.IsTypedValue)
            {
                try
                {
                    if (!String.IsNullOrEmpty(e.TypedValue))
                    {
                        AV001_TDI_BIL_SOZLESME soz =
                            vgSozlesmeBilgileri.GetRecordObject(vgSozlesmeBilgileri.FocusedRecord) as
                            AV001_TDI_BIL_SOZLESME;

                        //if (soz != null && soz.TIP_ID.HasValue && (soz.TIP_ID == (int)SozlesmeAnaTip.Genel_Sozleme || soz.TIP_ID == (int)SozlesmeAnaTip.HakemSozlesmesi || soz.TIP_ID == (int)SozlesmeAnaTip.MarkaPatentSozlesmesi))
                        //{
                        TDI_KOD_SOZLESME_ALT_TIP AltTip = new TDI_KOD_SOZLESME_ALT_TIP();
                        AltTip.ALT_TIP = e.TypedValue;
                        AltTip.ANA_TIP_ID = soz.TIP_ID.Value;
                        DataRepository.TDI_KOD_SOZLESME_ALT_TIPProvider.Save(AltTip);
                        BelgeUtil.Inits.SozlesmeAltTipiHepsiGetirRefresh();

                        //VList<per_TDI_KOD_SOZLESME_ALT_TIP> altTipler = ((VList<per_TDI_KOD_SOZLESME_ALT_TIP>)e.SenderLookUp.Properties.DataSource);
                        //string filtre = altTipler.Filter;
                        //altTipler.Filter = string.Empty;
                        //altTipler.Add(AltTip);
                        //altTipler.Filter = filtre;
                        BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(e.SenderLookUp.Properties);
                        e.SenderLookUp.Refresh();
                        XtraMessageBox.Show("Alt Tip Baþarýyla Eklenmiþtir.");
                    }

                    //else
                    //{
                    //    XtraMessageBox.Show("Sadece sozlesme tipi genel , hakem ve marka patent sözleþmesine yeni alt tip ekleyebilirsiniz Lütfen doðru tipi Seçtiðinizden emin olunuz ...");
                    //}
                }

                //}
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        private void MyDataSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TDI_BIL_SOZLESME sozlesme = e.NewObject as AV001_TDI_BIL_SOZLESME;
            if (sozlesme == null)
                sozlesme = new AV001_TDI_BIL_SOZLESME();
            AV001_TDI_BIL_SOZLESME addnew = sozlesme;
            addnew.KAYIT_TARIHI = DateTime.Now;
            addnew.KONTROL_NE_ZAMAN = DateTime.Now;
            addnew.KONTROL_KIM = "AVUKATPRO";
            addnew.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            addnew.REHIN_CINS_ANA_TURU = 0;
            addnew.STAMP = 1;
            addnew.TUR = (int)SozlesmeTur.Yazýlý;
            addnew.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            string strSozlesmeNo = "S" + "-" + DateTime.Today.Year + "~" +
                                   System.Guid.NewGuid().ToString("N").Substring(0, 5).ToUpper();
            addnew.IMZA_TARIHI = DateTime.Today;
            addnew.KAYIT_TARIHI = DateTime.Today;
            addnew.MUACCELIYET_VAR_MI = false;
            addnew.NOTER_TARIHI = DateTime.Today;
            addnew.SOZLESME_NO = strSozlesmeNo;
            addnew.SOZLESME_DURUM_ID = (int)SozlesmeDurum.Faal; // 10001;
            if (tip != null)
                ForumTipineGoreSozlesmeYapilenadir(tip, addnew);

            addnew.ColumnChanged += ucSozlesmeBilgileri_ColumnChanged;
            e.NewObject = addnew;

            //e.NewObject = sozlesme;
        }

        private void ucSozlesmeBilgileri_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                IsLoaded = true;
                if (Formdanmi)
                    dataNavigatorExtended1.Visible = false;
                vgSozlesmeBilgileri.DataSource = bndSozlesmeBilgileri;
                dataNavigatorExtended1.DataSource = bndSozlesmeBilgileri;

                gridControl1.DataSource = bndSozlesmeBilgileri;
                extendedGridControl1.DataSource = bndSozlesmeBilgileri;

                //
                compVGridRecordCopy1.MyVGridControl = vgSozlesmeBilgileri;

                gridControl1.ButtonCevirClick += gridControl1_ButtonCevirClick;
                extendedGridControl1.ButtonCevirClick += gridControl1_ButtonCevirClick;

                BelgeUtil.Inits.DovizTipGetir(rLueKur);
                BelgeUtil.Inits.KrediTipiGetir(repositoryItemLookUpEdit10);
                BelgeUtil.Inits.AdliBirimGorevGetirSadeceN(rLueGorev);
                BelgeUtil.Inits.AdliBirimAdliyeGetir(rLueAdliBirimAdliye);
                BelgeUtil.Inits.AdliBirimNoGetir(rLueAdliBirimNo);
                BelgeUtil.Inits.SozlesmeAltTipiHepsiGetir(rLueSozlesmeAltTip);
                BelgeUtil.Inits.SozlesmeDurumGetir(rLueSozlesmeDurum);
                BelgeUtil.Inits.SozlesmeTipiGetir(rLueSozlesmeTipi);
                BelgeUtil.Inits.SicilTipGetir(rLueSicilTipi);
                BelgeUtil.Inits.llceGetirIlle(rLueSicilIl);
                BelgeUtil.Inits.IlceGetirTumu(rLueIlce);
                BelgeUtil.Inits.BankaKartTipiGetir(rLueKartTipi);
                BelgeUtil.Inits.RehinDurumGetir(rLueRehinDurum);
                BelgeUtil.Inits.RehinCinsGetir(rLueRehinCinsi);
                BelgeUtil.Inits.SozlesmeSekliGetir(rLueSozlesmeTur);
                BelgeUtil.Inits.OdemeTipiGetir(rLueOdemePeriyodu);
                BelgeUtil.Inits.HarcIstisnaGetir(rLueHarcIstisna);
                BelgeUtil.Inits.RehinHarcIstisnaBelge(rLueHarcIstisnaBelge);
                BelgeUtil.Inits.perCariGetir(rLueYeddiEminCari);
                BelgeUtil.Inits.DovizTipGetir(rLueBedelliDoviz);
                rDateSozlesme.NullText = DateTime.Now.ToShortDateString();
                BelgeUtil.Inits.ParaBicimiAyarla(rspBedel);

                //  OzelKodDoldur(new RepositoryItemLookUpEdit[] { rLueOzelKod1, rLueOzelKod2, rLueOzelKod3, rLueOzelKod4 });
                BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod1, 1, AvukatProLib.Extras.Modul.Sozlesme);
                BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod2, 2, AvukatProLib.Extras.Modul.Sozlesme);
                BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod3, 3, AvukatProLib.Extras.Modul.Sozlesme);
                BelgeUtil.Inits.FoyOzelKodGetir(rLueOzelKod4, 4, AvukatProLib.Extras.Modul.Sozlesme);
                vgSozlesmeBilgileri.BringToFront();
                BindData();

                #region Ozellestirme

                if (OzelKod1_2.PropertiesCollection["OZEL_KOD1_ID"] != null)
                    OzelKod1_2.PropertiesCollection["OZEL_KOD1_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
                if (OzelKod1_2.PropertiesCollection["OZEL_KOD2_ID"] != null)
                    OzelKod1_2.PropertiesCollection["OZEL_KOD2_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
                if (OzelKod3_4.PropertiesCollection["OZEL_KOD3_ID"] != null)
                    OzelKod3_4.PropertiesCollection["OZEL_KOD3_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
                if (OzelKod3_4.PropertiesCollection["OZEL_KOD4_ID"] != null)
                    OzelKod3_4.PropertiesCollection["OZEL_KOD4_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;

                if (gridView1.Columns["OZEL_KOD1_ID"] != null)
                    gridView1.Columns["OZEL_KOD1_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
                if (gridView1.Columns["OZEL_KOD2_ID"] != null)
                    gridView1.Columns["OZEL_KOD2_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
                if (gridView1.Columns["OZEL_KOD3_ID"] != null)
                    gridView1.Columns["OZEL_KOD3_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
                if (gridView1.Columns["OZEL_KOD4_ID"] != null)
                    gridView1.Columns["OZEL_KOD4_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;

                if (layoutView1.Columns["OZEL_KOD1_ID"] != null)
                    layoutView1.Columns["OZEL_KOD1_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod1;
                if (layoutView1.Columns["OZEL_KOD2_ID"] != null)
                    layoutView1.Columns["OZEL_KOD2_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod2;
                if (layoutView1.Columns["OZEL_KOD3_ID"] != null)
                    layoutView1.Columns["OZEL_KOD3_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod3;
                if (layoutView1.Columns["OZEL_KOD4_ID"] != null)
                    layoutView1.Columns["OZEL_KOD4_ID"].Caption = Kimlikci.Kimlik.SozlesmeOzelKod.OzelKod4;

                #endregion Ozellestirme
            }
        }

        private void vgSozlesmeBilgileri_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            if (e.NewIndex >= 0 && MyDataSource != null && MyDataSource.Count > 0)
            {
                MyDataSource[e.NewIndex].ColumnChanged += ucSozlesmeBilgileri_ColumnChanged;
            }

            if (FocusedSozlesmeChanged != null)
            {
                FocusedSozlesmeChanged(sender, e);
            }
        }

        private void vgSozlesmeBilgileri_HiddenEditor(object sender, EventArgs e)
        {
            if (cloneAltTip != null)
            {
                cloneAltTip.Dispose();
                cloneAltTip = null;
            }
            if (cloneTip != null)
            {
                cloneTip.Dispose();
                cloneTip = null;
            }
        }

        private void vgSozlesmeBilgileri_ShownEditor(object sender, EventArgs e)
        {
            VGridControl gonderen = sender as VGridControl;
            if (gonderen.FocusedRow.Tag != null && gonderen.FocusedRow.Tag.ToString().Contains("TIP") &&
                gonderen.ActiveEditor is LookUpEdit)
            {
                LookUpEdit edit = (LookUpEdit)gonderen.ActiveEditor;
                AV001_TDI_BIL_SOZLESME sozlesme =
                    gonderen.GetRecordObject(gonderen.FocusedRecord) as AV001_TDI_BIL_SOZLESME;

                if (edit.Properties.Tag == "ALTTIP")
                {
                    VList<per_TDI_KOD_SOZLESME_ALT_TIP> atip =
                        edit.Properties.DataSource as VList<per_TDI_KOD_SOZLESME_ALT_TIP>;
                    cloneAltTip = new VList<per_TDI_KOD_SOZLESME_ALT_TIP>(atip);

                    cloneAltTip.Filter = string.Empty;
                    cloneAltTip.ApplyFilter();
                    if (MyIcraFoy != null)
                    {
                        switch (gonderen.FocusedRow.Tag.ToString())
                        {
                            case "ALTTIP":
                                if (sozlesme.TIP_ID.HasValue)
                                {
                                    cloneAltTip.Filter = "ANA_TIP_ID = " + sozlesme.TIP_ID.Value;

                                    VList<per_TDI_KOD_SOZLESME_ALT_TIP> silinecek =
                                        new VList<per_TDI_KOD_SOZLESME_ALT_TIP>();
                                    switch (tip)
                                    {
                                        case FormTipleri.Form50:
                                        case FormTipleri.Form201:
                                            if (sozlesme.TIP_ID == (int)SozlesmeAnaTip.Resmi_Senet)
                                            {
                                                gridColumn8.Caption = "Tanzim T.";
                                                foreach (per_TDI_KOD_SOZLESME_ALT_TIP var in cloneAltTip)
                                                {
                                                    if (var.ALT_TIP.Contains("Gayrimenkul Ýpoteði"))
                                                    {
                                                        silinecek.Add(var);
                                                    }
                                                    if (var.ALT_TIP.Contains("Gemi Ýpoteði"))
                                                    {
                                                        silinecek.Add(var);
                                                    }
                                                    if (var.ALT_TIP.Contains("Hava Aracý Ýpoteði"))
                                                    {
                                                        silinecek.Add(var);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                silinecek.Clear();
                                            }

                                            break;

                                        case FormTipleri.Form151:
                                        case FormTipleri.Form152:
                                            if (sozlesme.TIP_ID == (int)SozlesmeAnaTip.Resmi_Senet)
                                            {
                                                foreach (per_TDI_KOD_SOZLESME_ALT_TIP var in cloneAltTip)
                                                {
                                                    if (!var.ALT_TIP.Contains("Gayrimenkul Ýpoteði") &&
                                                        !var.ALT_TIP.Contains("Gemi Ýpoteði") &&
                                                        !var.ALT_TIP.Contains("Hava Aracý Ýpoteði"))
                                                    {
                                                        silinecek.Add(var);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                silinecek.Clear();
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    if (silinecek.Count != 0)
                                    {
                                        foreach (per_TDI_KOD_SOZLESME_ALT_TIP alttip in silinecek)
                                        {
                                            if (cloneAltTip.Contains(alttip))
                                            {
                                                cloneAltTip.Remove(alttip);
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        switch (gonderen.FocusedRow.Tag.ToString())
                        {
                            case "ALTTIP":
                                if (sozlesme.TIP_ID.HasValue)
                                {
                                    cloneAltTip.Filter = "ANA_TIP_ID = " + sozlesme.TIP_ID.Value;
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    edit.Properties.DataSource = cloneAltTip;
                }
            }
        }

        private void vgSozlesmeBilgileri_ValidateRecord(object sender, ValidateRecordEventArgs e)
        {
            if (SozlesmeValidateRecord != null)
            {
                SozlesmeValidateRecord(sender, e);
            }
        }
    }
}