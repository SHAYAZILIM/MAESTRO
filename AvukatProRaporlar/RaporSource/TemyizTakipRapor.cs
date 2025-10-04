using System.Collections.Generic;
using AvukatProRaporlar.Raport.Util.Inits;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPivotGrid;

namespace AvukatProRaporlar.RaporSource
{
    internal class TemyizTakipRapor
    {
        #region

        //#region Settings

        //public string MenuName
        //{
        //    get { return "Menu Name"; }
        //}

        //public string Title
        //{
        //    get { return "Title"; }
        //}

        //public bool EnablePivot
        //{
        //    get { return false; }
        //}

        //public bool EnableChart
        //{
        //    get { return false; }
        //}

        //public bool EnableGrid
        //{
        //    get { return false; }
        //}

        //public bool EnablePrintList
        //{
        //    get { return false; }
        //}

        //public bool EnableSaveList
        //{
        //    get { return false; }
        //}

        //public bool EnablePrintPivot
        //{
        //    get { return false; }
        //}

        //public bool EnableSavePivot
        //{
        //    get { return false; }
        //}

        //public bool EnablePrintChart
        //{
        //    get { return false; }
        //}

        //public bool EnableSaveChart
        //{
        //    get { return false; }
        //}

        //#endregion

        //private Dictionary<string, string> GetCaptionDictinory()
        //{
        //    Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

        //    #region
        //    dicFieldCaption.Add("TERDITLI_MI", "Terditli");
        //    dicFieldCaption.Add("DAVA_NEDEN_TIP", "Dava Neden Tipi");
        //    dicFieldCaption.Add("DAVA_ADI", "DAva Adı");
        //    dicFieldCaption.Add("DIGER_DAVA_NEDEN", "Diğer Dava Neden");
        //    dicFieldCaption.Add("DAVA_NEDEN_MAHKEME", "Mahkeme");
        //    dicFieldCaption.Add("OLAY_SUC_TARIHI", "Olay Suç T");
        //    dicFieldCaption.Add("DUZENLEME_TARIHI", "Düzenleme T");
        //    dicFieldCaption.Add("TEBELLUG_TARIHI", "Tebelluğ T");
        //    dicFieldCaption.Add("FAIZ_TALEP_TARIHI", "Faiz Tlp. T");
        //    dicFieldCaption.Add("FAIZ_KARAR_TARIHI", "Faiz Krr. T");
        //    dicFieldCaption.Add("TEDBIR_TARIHI", "Tedbir T");
        //    dicFieldCaption.Add("TEDBIR_KALDIRILMA_TARIHI", "Tedbir Kaldırılma T");
        //    dicFieldCaption.Add("TEDBIR_TALEP_TARIHI", "Tedbir Tlp. T");
        //    dicFieldCaption.Add("DOVIZ_ISLEM_TIPI", "Birim");
        //    dicFieldCaption.Add("SABIT_FAIZ_UYGULA", "Sbt Faiz Uygula");
        //    dicFieldCaption.Add("DO_FAIZ_TIP", "D.Ö. Faiz Tipi");
        //    dicFieldCaption.Add("DO_FAIZ_ORANI", "D.Ö Faiz Oranı");
        //    dicFieldCaption.Add("DN_FAIZ_TIP", "D.N Faiz Tipi");
        //    dicFieldCaption.Add("DAVA_NEDEN_FAIZ_ORANI", "D.N Faiz Oranı");
        //    dicFieldCaption.Add("DAVA_N_TUTAR", "D.N Tutar");
        //    dicFieldCaption.Add("DAVA_EDILEN_TUTAR", "D. Edilen Tutar");
        //    dicFieldCaption.Add("ISLAH_EDILMIS", "Islah Edilmiş");
        //    dicFieldCaption.Add("ISLAH_TARIHI", "Islah T");
        //    dicFieldCaption.Add("ISLAH_EDILEN_TUTAR", "Islah Edilen Tutar");
        //    dicFieldCaption.Add("PROTESTO_GIDERI", "Protesto Gideri");
        //    dicFieldCaption.Add("IHTAR_GIDERI", "İhtar Gideri");
        //    dicFieldCaption.Add("DAVA_N_DIGER_GIDER", "D.N. Diğer Gider");
        //    dicFieldCaption.Add("DAVA_NEDEN_SURE_GUN", "D.N. S. Gün");
        //    dicFieldCaption.Add("DAVA_NEDEN_SURE_AY", "D.N. S. Ay");
        //    dicFieldCaption.Add("DAVA_NEDEN_SURE_YIL", "D.N. S. Yıl");
        //    dicFieldCaption.Add("DAVA_NEDEN_REFERANS_NO1", "D.N. Ref No1");
        //    dicFieldCaption.Add("DAVA_NEDEN_REFERANS_NO2", "D.N. Ref No2");
        //    dicFieldCaption.Add("VERGI_DONEMI", "Vergi Dönemi");
        //    dicFieldCaption.Add("FAIZ_YOK", "Faiz Yok");
        //    dicFieldCaption.Add("SIFAT", "Sıfat");
        //    dicFieldCaption.Add("TARAF_ADI", "Taraf");
        //    dicFieldCaption.Add("KESINLESME_TARIHI", "Kesinleşme T");
        //    dicFieldCaption.Add("SULH_TARIHI", "Sulh T");
        //    dicFieldCaption.Add("KABUL_TARIHI", "Kabul T");
        //    dicFieldCaption.Add("ATIYE_BIRAKMA_TARIHI", "Atiye Bırakma T");
        //    dicFieldCaption.Add("VAZGECME_TARIHI", "Vazgeçme T");
        //    dicFieldCaption.Add("IKRAR_TARIHI", "İkrar T");
        //    dicFieldCaption.Add("GERI_ALMA_TARIHI", "Geri Alma T");
        //    dicFieldCaption.Add("ASLI_MUDEHALE_TARIHI", "Aslı Müdahale T");
        //    dicFieldCaption.Add("FERI_MUDEHALE_TARIHI", "Feri Müdahale T");
        //    dicFieldCaption.Add("YETKIYE_ITIRAZ_TARIHI", "Yetkiye İtiraz T");
        //    dicFieldCaption.Add("GOREVE_ITIRAZ_TARIHI", "Göreve İtiraz T");
        //    dicFieldCaption.Add("TAKIGAT_TARIHI", "Takigat T");
        //    dicFieldCaption.Add("ESAS_BEYAN_TARIHI", "Esas Beyan T");
        //    dicFieldCaption.Add("EK_SAVUNMA_TARIHI", "Ek Savunma T");
        //    dicFieldCaption.Add("MUDAHALE_TARIHI", "Müdahale T");
        //    dicFieldCaption.Add("SON_SAVUNMA_TARIHI", "Son Savunma T");
        //    dicFieldCaption.Add("SAVUNMA_TARIHI", "Savunma T");
        //    dicFieldCaption.Add("MUTALAA_TARIHI", "Mutalaa T");
        //    dicFieldCaption.Add("IDDIANAME_OKUNMA_TARIHI", "İddıaname Okunma T");
        //    dicFieldCaption.Add("ZAMAN_ASIMI_TARIHI", "Zaman Aşımı T");
        //    dicFieldCaption.Add("OGRENME_TARIHI", "Öğrenme T");
        //    dicFieldCaption.Add("SORUMLU_OLUNAN_MIKTAR", "Sorumlu Olunan Miktar");
        //    dicFieldCaption.Add("SURE_TUTUM_TARIHI", "Süre Tutum T");
        //    dicFieldCaption.Add("DURUSMA_TALEP_TARIHI", "Duruşma Talep T");
        //    dicFieldCaption.Add("KESIF_TALEP_TARIHI", "Keşif Talep T");
        //    dicFieldCaption.Add("GERI_BASVURMA_TARIHI", "Geri Başvurma T");
        //    dicFieldCaption.Add("YURUTME_DURDURMA_TALEP_TARIHI", "Yürütme Durdurma Talep T");
        //    dicFieldCaption.Add("YURUTME_DURDURMA_TARIHI", "Yürütme Durdurma T");
        //    dicFieldCaption.Add("YURUTME_DURDURMA_KALDIRILMA_TARIHI", "Yürütme Durdurma Kaldırma T");
        //    dicFieldCaption.Add("IHBAR_TARIHI", "İhbar T");
        //    dicFieldCaption.Add("TARAF", "Taraf");
        //    dicFieldCaption.Add("IHTAR_TARIHI", "Ihtar T");
        //    dicFieldCaption.Add("IHTAR_TEBLIG_TARIHI", "Ihtar Tebliğ T");
        //    dicFieldCaption.Add("IHTAR_TEMERRUT_TARIHI", "Ihtar Temerrut T");
        //    dicFieldCaption.Add("ZAMANASIMI_IDDIA_TARIHI", "Zaman Aşımı İddia T");
        //    dicFieldCaption.Add("IHBAR_TEBLIG_TARIHI", "İhbar Tebliğ T");
        //    dicFieldCaption.Add("MAHKEMEDE_UZLASMA_TARIHI", "Mahkemede Uzlaşma T");
        //    dicFieldCaption.Add("HUKUM_TARIHI", "Hüküm T");
        //    dicFieldCaption.Add("KARAR_NO", "Karar No");
        //    dicFieldCaption.Add("HUKUM", "Hüküm");
        //    dicFieldCaption.Add("HUKUM_TIP", "Hüküm Tipi");
        //    dicFieldCaption.Add("HUKUM_GEREKCE", "Hüküm Gerekçe");
        //    dicFieldCaption.Add("HUKUM_DEGER", "Hüküm Değer");
        //    dicFieldCaption.Add("MUSADERE_DEGER", "Müsadere Değer");
        //    dicFieldCaption.Add("MAHKUMIYET_YIL", "Mahkumiyet Yıl");
        //    dicFieldCaption.Add("MAHKUMIYET_AY", "Mahkumiyet Ay");
        //    dicFieldCaption.Add("MAHKUMIYET_GUN", "Mahkumiyet Gün");
        //    dicFieldCaption.Add("CEZA_ERTELENDI", "Ceza Ertelendi");
        //    dicFieldCaption.Add("PARAYA_CEVRILDI", "Paraya Çevrildi");
        //    dicFieldCaption.Add("PARAYA_CEVRILEN_MIKTAR", "Paraya Çevrilen Miktar");
        //    dicFieldCaption.Add("MESLEK_ICRA_MEN_TIP", "Meslek Men Tipi");
        //    dicFieldCaption.Add("MESLEK_ICRA_MEN_SURE", "Meslek Men Süre");
        //    dicFieldCaption.Add("EHLIYET_GERI_ALINMA_MEN_TIP", "Ehliyet Geri Alınma Men Tipi");
        //    dicFieldCaption.Add("EHLIYET_GERI_ALINMA_MEN_SURE", "Ehliyet Geri Alınma Men Süre");
        //    dicFieldCaption.Add("KAMU_HIZMET_YASAK_TIP", "Kamu Hizmet Yasak Tipi");
        //    dicFieldCaption.Add("KAMU_HIZMET_YASAK_SURE", "Kamu Hizmet Yasak Süre");
        //    dicFieldCaption.Add("HUKUM_TARAF", "Hüküm Taraf");
        //    dicFieldCaption.Add("INFAZ_TARIHI", "İnfaz T");
        //    dicFieldCaption.Add("HUKUM_KESINLESME_TARIHI", "Hüküm Kesinleşme T");
        //    dicFieldCaption.Add("SORUMLULUK_MIKTARI", "Sorumluluk Miktarı");
        //    dicFieldCaption.Add("HUKUM_TEBLIG_TEFHIM_TARIHI", "Hüküm Tebliğ Tefhim T");
        //    dicFieldCaption.Add("TEMYIZ_TIP", "Temyiz Tipi");
        //    dicFieldCaption.Add("YUKSEK_MAHKEME_GONDERIM_TARIHI", "Yüksek Mahkeme Gönderim T");
        //    dicFieldCaption.Add("TEMYIZ_MAHKEME", "Temyiz Mahkeme");
        //    dicFieldCaption.Add("TEMYIZ_MAHKEME_GOREV", "Görev");
        //    dicFieldCaption.Add("TEMYIZ_MAHKEME_NO", " No");
        //    dicFieldCaption.Add("TEMYIZ_ESAS_NO", "T. Esas No");
        //    dicFieldCaption.Add("TEMYIZ_KARAR_TARIHI", "T. Karar T");
        //    dicFieldCaption.Add("TEMYIZ_KARAR_NO", "T. Karar No");
        //    dicFieldCaption.Add("KARAR_TIP", "Karar Tipi");
        //    dicFieldCaption.Add("TEMYIZ_GEREKCE", "T. Gerekçe");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_TEMYIZ_TARIHI", "T. Taraf T. T");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_CARI", "Temyiz Taraf");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_USUL_NEDENLERI", "T. Taraf Usul Nedenleri");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_YASAL_NEDENLER", "T. Taraf Yasal Nedenler");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_ACIKLAMA", "T. Taraf Açıklama");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI", "T. Taraf Tedbir İstem T");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_TEDBIR_TARIHI", "T. Taraf Tedbir T");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_TEDBIR_ACIKLAMASI", "T. Taraf Tedbir Açıklaması");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI", "T. Taraf Tedbirin Kaldırılma T");
        //    dicFieldCaption.Add("TEMYIZ_TEBLIG_TARIHI", "T. Tebliğ T");
        //    dicFieldCaption.Add("TEFHIM_TARIHI", "Tefhim T");
        //    dicFieldCaption.Add("TEMYIZ_TARAF_SURE_TUTUM_TARIHI", "Temyiz Taraf Süre Tutum T");
        //    dicFieldCaption.Add("DAVA_FOY_NO", "Dava Foy No");
        //    dicFieldCaption.Add("DAVA_ADLI_BIRIM_ADLIYE", "Dava Mahkeme");
        //    dicFieldCaption.Add("DAVA_ADLI_BIRIM_GOREV", "Dava Görev");
        //    dicFieldCaption.Add("DAVA_ADLI_BIRIM_NO", "Dava Birim No");
        //    dicFieldCaption.Add("DAVA_ESAS_NO", "Dava Esas No");
        //    dicFieldCaption.Add("DAVA_TAKIP_T", "Dava Takip T");
        //    dicFieldCaption.Add("DAVA_REFERANS_NO2", "Dava RefNo2");
        //    dicFieldCaption.Add("DAVA_REFERANS_NO3", "Dava RefNo3");
        //    dicFieldCaption.Add("DAVA_REFERANS_NO", "Dava RefNo1");
        //    dicFieldCaption.Add("DAVA_OZEL_KOD1", "D.Özel Kod1");
        //    dicFieldCaption.Add("DAVA_OZEL_KOD2", "D.Özel Kod2");
        //    dicFieldCaption.Add("DAVA_OZEL_KOD3", "D.Özel Kod3");
        //    dicFieldCaption.Add("DAVA_OZEL_KOD4", "D.Özel Kod4");
        //    dicFieldCaption.Add("DAVA_ASAMA", "D. Aşama");
        //    dicFieldCaption.Add("DAVA_TALEP", "D. Talep");
        //    dicFieldCaption.Add("DAVA_TARAF_KODU", "T.K");
        //    dicFieldCaption.Add("DAVA_TARAF_CARI", "Taraf");
        //    dicFieldCaption.Add("DAVA_TARAF_SIFAT", "Sıfat");
        //    dicFieldCaption.Add("SORUMLY_AVUKAT", "Sorumlu Avukat");
        //    #endregion
        //    return dicFieldCaption;
        //}

        //private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        //{
        //    //RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

        //    //Inits.DovizTipGetir(rlueDoviz);
        //    RepositoryItemDateEdit rDateTrh = new RepositoryItemDateEdit();

        //    Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

        //    #region Add item

        //    sozluk.Add("DovizId", InitsEx.DovizTipGetir);

        //    sozluk.Add("ZAMANASIMI_IDDIA_TARIHI", rDateTrh);
        //    #endregion

        //    return sozluk;
        //}

        //public PivotGridField[] GetPivotFields()
        //{
        //    #region Field & Properties
        //    PivotGridField fieldTERDITLI_MI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTERDITLI_MI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTERDITLI_MI.AreaIndex = 0;
        //    fieldTERDITLI_MI.FieldName = "TERDITLI_MI";
        //    fieldTERDITLI_MI.Name = "fieldTERDITLI_MI";
        //    fieldTERDITLI_MI.Visible = false;

        //    PivotGridField fieldDAVA_NEDEN_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_NEDEN_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_NEDEN_TIP.AreaIndex = 1;
        //    fieldDAVA_NEDEN_TIP.FieldName = "DAVA_NEDEN_TIP";
        //    fieldDAVA_NEDEN_TIP.Name = "fieldDAVA_NEDEN_TIP";
        //    fieldDAVA_NEDEN_TIP.Visible = false;

        //    PivotGridField fieldDAVA_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_ADI.AreaIndex = 2;
        //    fieldDAVA_ADI.FieldName = "DAVA_ADI";
        //    fieldDAVA_ADI.Name = "fieldDAVA_ADI";
        //    fieldDAVA_ADI.Visible = false;

        //    PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDIGER_DAVA_NEDEN.AreaIndex = 3;
        //    fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
        //    fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
        //    fieldDIGER_DAVA_NEDEN.Visible = false;

        //    PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldADLIYE.AreaIndex = 4;
        //    fieldADLIYE.FieldName = "ADLIYE";
        //    fieldADLIYE.Name = "fieldADLIYE";
        //    fieldADLIYE.Visible = false;

        //    PivotGridField fieldOLAY_SUC_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldOLAY_SUC_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldOLAY_SUC_TARIHI.AreaIndex = 5;
        //    fieldOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
        //    fieldOLAY_SUC_TARIHI.Name = "fieldOLAY_SUC_TARIHI";
        //    fieldOLAY_SUC_TARIHI.Visible = false;

        //    PivotGridField fieldDUZENLEME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDUZENLEME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDUZENLEME_TARIHI.AreaIndex = 6;
        //    fieldDUZENLEME_TARIHI.FieldName = "DUZENLEME_TARIHI";
        //    fieldDUZENLEME_TARIHI.Name = "fieldDUZENLEME_TARIHI";
        //    fieldDUZENLEME_TARIHI.Visible = false;

        //    PivotGridField fieldTEBELLUG_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEBELLUG_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEBELLUG_TARIHI.AreaIndex = 7;
        //    fieldTEBELLUG_TARIHI.FieldName = "TEBELLUG_TARIHI";
        //    fieldTEBELLUG_TARIHI.Name = "fieldTEBELLUG_TARIHI";
        //    fieldTEBELLUG_TARIHI.Visible = false;

        //    PivotGridField fieldFAIZ_TALEP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldFAIZ_TALEP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldFAIZ_TALEP_TARIHI.AreaIndex = 8;
        //    fieldFAIZ_TALEP_TARIHI.FieldName = "FAIZ_TALEP_TARIHI";
        //    fieldFAIZ_TALEP_TARIHI.Name = "fieldFAIZ_TALEP_TARIHI";
        //    fieldFAIZ_TALEP_TARIHI.Visible = false;

        //    PivotGridField fieldFAIZ_KARAR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldFAIZ_KARAR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldFAIZ_KARAR_TARIHI.AreaIndex = 9;
        //    fieldFAIZ_KARAR_TARIHI.FieldName = "FAIZ_KARAR_TARIHI";
        //    fieldFAIZ_KARAR_TARIHI.Name = "fieldFAIZ_KARAR_TARIHI";
        //    fieldFAIZ_KARAR_TARIHI.Visible = false;

        //    PivotGridField fieldTEDBIR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEDBIR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEDBIR_TARIHI.AreaIndex = 10;
        //    fieldTEDBIR_TARIHI.FieldName = "TEDBIR_TARIHI";
        //    fieldTEDBIR_TARIHI.Name = "fieldTEDBIR_TARIHI";
        //    fieldTEDBIR_TARIHI.Visible = false;

        //    PivotGridField fieldTEDBIR_KALDIRILMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEDBIR_KALDIRILMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEDBIR_KALDIRILMA_TARIHI.AreaIndex = 11;
        //    fieldTEDBIR_KALDIRILMA_TARIHI.FieldName = "TEDBIR_KALDIRILMA_TARIHI";
        //    fieldTEDBIR_KALDIRILMA_TARIHI.Name = "fieldTEDBIR_KALDIRILMA_TARIHI";
        //    fieldTEDBIR_KALDIRILMA_TARIHI.Visible = false;

        //    PivotGridField fieldTEDBIR_TALEP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEDBIR_TALEP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEDBIR_TALEP_TARIHI.AreaIndex = 12;
        //    fieldTEDBIR_TALEP_TARIHI.FieldName = "TEDBIR_TALEP_TARIHI";
        //    fieldTEDBIR_TALEP_TARIHI.Name = "fieldTEDBIR_TALEP_TARIHI";
        //    fieldTEDBIR_TALEP_TARIHI.Visible = false;

        //    PivotGridField fieldDOVIZ_ISLEM_TIPI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDOVIZ_ISLEM_TIPI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDOVIZ_ISLEM_TIPI.AreaIndex = 13;
        //    fieldDOVIZ_ISLEM_TIPI.FieldName = "DOVIZ_ISLEM_TIPI";
        //    fieldDOVIZ_ISLEM_TIPI.Name = "fieldDOVIZ_ISLEM_TIPI";
        //    fieldDOVIZ_ISLEM_TIPI.Visible = false;

        //    PivotGridField fieldSABIT_FAIZ_UYGULA = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSABIT_FAIZ_UYGULA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSABIT_FAIZ_UYGULA.AreaIndex = 14;
        //    fieldSABIT_FAIZ_UYGULA.FieldName = "SABIT_FAIZ_UYGULA";
        //    fieldSABIT_FAIZ_UYGULA.Name = "fieldSABIT_FAIZ_UYGULA";
        //    fieldSABIT_FAIZ_UYGULA.Visible = false;

        //    PivotGridField fieldFAIZ_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldFAIZ_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldFAIZ_TIP.AreaIndex = 15;
        //    fieldFAIZ_TIP.FieldName = "FAIZ_TIP";
        //    fieldFAIZ_TIP.Name = "fieldFAIZ_TIP";
        //    fieldFAIZ_TIP.Visible = false;

        //    PivotGridField fieldDO_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDO_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDO_FAIZ_ORANI.AreaIndex = 16;
        //    fieldDO_FAIZ_ORANI.FieldName = "DO_FAIZ_ORANI";
        //    fieldDO_FAIZ_ORANI.Name = "fieldDO_FAIZ_ORANI";
        //    fieldDO_FAIZ_ORANI.Visible = false;

        //    PivotGridField fieldFaizTip = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldFaizTip.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldFaizTip.AreaIndex = 17;
        //    fieldFaizTip.FieldName = "FaizTip";
        //    fieldFaizTip.Name = "fieldFaizTip";
        //    fieldFaizTip.Visible = false;

        //    PivotGridField fieldDAVA_NEDEN_FAIZ_ORANI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_NEDEN_FAIZ_ORANI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_NEDEN_FAIZ_ORANI.AreaIndex = 18;
        //    fieldDAVA_NEDEN_FAIZ_ORANI.FieldName = "DAVA_NEDEN_FAIZ_ORANI";
        //    fieldDAVA_NEDEN_FAIZ_ORANI.Name = "fieldDAVA_NEDEN_FAIZ_ORANI";
        //    fieldDAVA_NEDEN_FAIZ_ORANI.Visible = false;

        //    PivotGridField fieldDAVA_N_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_N_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_N_TUTAR.AreaIndex = 19;
        //    fieldDAVA_N_TUTAR.FieldName = "DAVA_N_TUTAR";
        //    fieldDAVA_N_TUTAR.Name = "fieldDAVA_N_TUTAR";
        //    fieldDAVA_N_TUTAR.Visible = false;

        //    PivotGridField fieldTUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTUTAR_DOVIZ_ID.AreaIndex = 20;
        //    fieldTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
        //    fieldTUTAR_DOVIZ_ID.Name = "fieldTUTAR_DOVIZ_ID";
        //    fieldTUTAR_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldDAVA_EDILEN_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_EDILEN_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_EDILEN_TUTAR.AreaIndex = 21;
        //    fieldDAVA_EDILEN_TUTAR.FieldName = "DAVA_EDILEN_TUTAR";
        //    fieldDAVA_EDILEN_TUTAR.Name = "fieldDAVA_EDILEN_TUTAR";
        //    fieldDAVA_EDILEN_TUTAR.Visible = false;

        //    PivotGridField fieldDAVA_EDILEN_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.AreaIndex = 22;
        //    fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.FieldName = "DAVA_EDILEN_TUTAR_DOVIZ_ID";
        //    fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.Name = "fieldDAVA_EDILEN_TUTAR_DOVIZ_ID";
        //    fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldISLAH_EDILMIS = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldISLAH_EDILMIS.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldISLAH_EDILMIS.AreaIndex = 23;
        //    fieldISLAH_EDILMIS.FieldName = "ISLAH_EDILMIS";
        //    fieldISLAH_EDILMIS.Name = "fieldISLAH_EDILMIS";
        //    fieldISLAH_EDILMIS.Visible = false;

        //    PivotGridField fieldISLAH_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldISLAH_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldISLAH_TARIHI.AreaIndex = 24;
        //    fieldISLAH_TARIHI.FieldName = "ISLAH_TARIHI";
        //    fieldISLAH_TARIHI.Name = "fieldISLAH_TARIHI";
        //    fieldISLAH_TARIHI.Visible = false;

        //    PivotGridField fieldISLAH_EDILEN_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldISLAH_EDILEN_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldISLAH_EDILEN_TUTAR.AreaIndex = 25;
        //    fieldISLAH_EDILEN_TUTAR.FieldName = "ISLAH_EDILEN_TUTAR";
        //    fieldISLAH_EDILEN_TUTAR.Name = "fieldISLAH_EDILEN_TUTAR";
        //    fieldISLAH_EDILEN_TUTAR.Visible = false;

        //    PivotGridField fieldISLAH_EDILEN_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldISLAH_EDILEN_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldISLAH_EDILEN_TUTAR_DOVIZ_ID.AreaIndex = 26;
        //    fieldISLAH_EDILEN_TUTAR_DOVIZ_ID.FieldName = "ISLAH_EDILEN_TUTAR_DOVIZ_ID";
        //    fieldISLAH_EDILEN_TUTAR_DOVIZ_ID.Name = "fieldISLAH_EDILEN_TUTAR_DOVIZ_ID";
        //    fieldISLAH_EDILEN_TUTAR_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldPROTESTO_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldPROTESTO_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldPROTESTO_GIDERI.AreaIndex = 27;
        //    fieldPROTESTO_GIDERI.FieldName = "PROTESTO_GIDERI";
        //    fieldPROTESTO_GIDERI.Name = "fieldPROTESTO_GIDERI";
        //    fieldPROTESTO_GIDERI.Visible = false;

        //    PivotGridField fieldPROTESTO_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldPROTESTO_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldPROTESTO_GIDERI_DOVIZ_ID.AreaIndex = 28;
        //    fieldPROTESTO_GIDERI_DOVIZ_ID.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
        //    fieldPROTESTO_GIDERI_DOVIZ_ID.Name = "fieldPROTESTO_GIDERI_DOVIZ_ID";
        //    fieldPROTESTO_GIDERI_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldIHTAR_GIDERI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldIHTAR_GIDERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldIHTAR_GIDERI.AreaIndex = 29;
        //    fieldIHTAR_GIDERI.FieldName = "IHTAR_GIDERI";
        //    fieldIHTAR_GIDERI.Name = "fieldIHTAR_GIDERI";
        //    fieldIHTAR_GIDERI.Visible = false;

        //    PivotGridField fieldIHTAR_GIDERI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldIHTAR_GIDERI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldIHTAR_GIDERI_DOVIZ_ID.AreaIndex = 30;
        //    fieldIHTAR_GIDERI_DOVIZ_ID.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
        //    fieldIHTAR_GIDERI_DOVIZ_ID.Name = "fieldIHTAR_GIDERI_DOVIZ_ID";
        //    fieldIHTAR_GIDERI_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldDAVA_N_DIGER_GIDER = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_N_DIGER_GIDER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_N_DIGER_GIDER.AreaIndex = 31;
        //    fieldDAVA_N_DIGER_GIDER.FieldName = "DAVA_N_DIGER_GIDER";
        //    fieldDAVA_N_DIGER_GIDER.Name = "fieldDAVA_N_DIGER_GIDER";
        //    fieldDAVA_N_DIGER_GIDER.Visible = false;

        //    PivotGridField fieldDIGER_GIDER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDIGER_GIDER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDIGER_GIDER_DOVIZ_ID.AreaIndex = 32;
        //    fieldDIGER_GIDER_DOVIZ_ID.FieldName = "DIGER_GIDER_DOVIZ_ID";
        //    fieldDIGER_GIDER_DOVIZ_ID.Name = "fieldDIGER_GIDER_DOVIZ_ID";
        //    fieldDIGER_GIDER_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldDAVA_NEDEN_SURE_GUN = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_NEDEN_SURE_GUN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_NEDEN_SURE_GUN.AreaIndex = 33;
        //    fieldDAVA_NEDEN_SURE_GUN.FieldName = "DAVA_NEDEN_SURE_GUN";
        //    fieldDAVA_NEDEN_SURE_GUN.Name = "fieldDAVA_NEDEN_SURE_GUN";
        //    fieldDAVA_NEDEN_SURE_GUN.Visible = false;

        //    PivotGridField fieldDAVA_NEDEN_SURE_AY = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_NEDEN_SURE_AY.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_NEDEN_SURE_AY.AreaIndex = 34;
        //    fieldDAVA_NEDEN_SURE_AY.FieldName = "DAVA_NEDEN_SURE_AY";
        //    fieldDAVA_NEDEN_SURE_AY.Name = "fieldDAVA_NEDEN_SURE_AY";
        //    fieldDAVA_NEDEN_SURE_AY.Visible = false;

        //    PivotGridField fieldDAVA_NEDEN_SURE_YIL = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_NEDEN_SURE_YIL.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_NEDEN_SURE_YIL.AreaIndex = 35;
        //    fieldDAVA_NEDEN_SURE_YIL.FieldName = "DAVA_NEDEN_SURE_YIL";
        //    fieldDAVA_NEDEN_SURE_YIL.Name = "fieldDAVA_NEDEN_SURE_YIL";
        //    fieldDAVA_NEDEN_SURE_YIL.Visible = false;

        //    PivotGridField fieldDAVA_NEDEN_REFERANS_NO1 = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_NEDEN_REFERANS_NO1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_NEDEN_REFERANS_NO1.AreaIndex = 36;
        //    fieldDAVA_NEDEN_REFERANS_NO1.FieldName = "DAVA_NEDEN_REFERANS_NO1";
        //    fieldDAVA_NEDEN_REFERANS_NO1.Name = "fieldDAVA_NEDEN_REFERANS_NO1";
        //    fieldDAVA_NEDEN_REFERANS_NO1.Visible = false;

        //    PivotGridField fieldDAVA_NEDEN_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_NEDEN_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_NEDEN_REFERANS_NO2.AreaIndex = 37;
        //    fieldDAVA_NEDEN_REFERANS_NO2.FieldName = "DAVA_NEDEN_REFERANS_NO2";
        //    fieldDAVA_NEDEN_REFERANS_NO2.Name = "fieldDAVA_NEDEN_REFERANS_NO2";
        //    fieldDAVA_NEDEN_REFERANS_NO2.Visible = false;

        //    PivotGridField fieldVERGI_DONEMI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldVERGI_DONEMI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldVERGI_DONEMI.AreaIndex = 38;
        //    fieldVERGI_DONEMI.FieldName = "VERGI_DONEMI";
        //    fieldVERGI_DONEMI.Name = "fieldVERGI_DONEMI";
        //    fieldVERGI_DONEMI.Visible = false;

        //    PivotGridField fieldFAIZ_YOK = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldFAIZ_YOK.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldFAIZ_YOK.AreaIndex = 39;
        //    fieldFAIZ_YOK.FieldName = "FAIZ_YOK";
        //    fieldFAIZ_YOK.Name = "fieldFAIZ_YOK";
        //    fieldFAIZ_YOK.Visible = false;

        //    PivotGridField fieldSIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSIFAT.AreaIndex = 40;
        //    fieldSIFAT.FieldName = "SIFAT";
        //    fieldSIFAT.Name = "fieldSIFAT";
        //    fieldSIFAT.Visible = false;

        //    PivotGridField fieldTARAF_ADI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTARAF_ADI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTARAF_ADI.AreaIndex = 41;
        //    fieldTARAF_ADI.FieldName = "TARAF_ADI";
        //    fieldTARAF_ADI.Name = "fieldTARAF_ADI";
        //    fieldTARAF_ADI.Visible = false;

        //    PivotGridField fieldKESINLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldKESINLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldKESINLESME_TARIHI.AreaIndex = 42;
        //    fieldKESINLESME_TARIHI.FieldName = "KESINLESME_TARIHI";
        //    fieldKESINLESME_TARIHI.Name = "fieldKESINLESME_TARIHI";
        //    fieldKESINLESME_TARIHI.Visible = false;

        //    PivotGridField fieldSULH_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSULH_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSULH_TARIHI.AreaIndex = 43;
        //    fieldSULH_TARIHI.FieldName = "SULH_TARIHI";
        //    fieldSULH_TARIHI.Name = "fieldSULH_TARIHI";
        //    fieldSULH_TARIHI.Visible = false;

        //    PivotGridField fieldKABUL_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldKABUL_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldKABUL_TARIHI.AreaIndex = 44;
        //    fieldKABUL_TARIHI.FieldName = "KABUL_TARIHI";
        //    fieldKABUL_TARIHI.Name = "fieldKABUL_TARIHI";
        //    fieldKABUL_TARIHI.Visible = false;

        //    PivotGridField fieldATIYE_BIRAKMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldATIYE_BIRAKMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldATIYE_BIRAKMA_TARIHI.AreaIndex = 45;
        //    fieldATIYE_BIRAKMA_TARIHI.FieldName = "ATIYE_BIRAKMA_TARIHI";
        //    fieldATIYE_BIRAKMA_TARIHI.Name = "fieldATIYE_BIRAKMA_TARIHI";
        //    fieldATIYE_BIRAKMA_TARIHI.Visible = false;

        //    PivotGridField fieldVAZGECME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldVAZGECME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldVAZGECME_TARIHI.AreaIndex = 46;
        //    fieldVAZGECME_TARIHI.FieldName = "VAZGECME_TARIHI";
        //    fieldVAZGECME_TARIHI.Name = "fieldVAZGECME_TARIHI";
        //    fieldVAZGECME_TARIHI.Visible = false;

        //    PivotGridField fieldIKRAR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldIKRAR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldIKRAR_TARIHI.AreaIndex = 47;
        //    fieldIKRAR_TARIHI.FieldName = "IKRAR_TARIHI";
        //    fieldIKRAR_TARIHI.Name = "fieldIKRAR_TARIHI";
        //    fieldIKRAR_TARIHI.Visible = false;

        //    PivotGridField fieldGERI_ALMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldGERI_ALMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldGERI_ALMA_TARIHI.AreaIndex = 48;
        //    fieldGERI_ALMA_TARIHI.FieldName = "GERI_ALMA_TARIHI";
        //    fieldGERI_ALMA_TARIHI.Name = "fieldGERI_ALMA_TARIHI";
        //    fieldGERI_ALMA_TARIHI.Visible = false;

        //    PivotGridField fieldASLI_MUDEHALE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldASLI_MUDEHALE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldASLI_MUDEHALE_TARIHI.AreaIndex = 49;
        //    fieldASLI_MUDEHALE_TARIHI.FieldName = "ASLI_MUDEHALE_TARIHI";
        //    fieldASLI_MUDEHALE_TARIHI.Name = "fieldASLI_MUDEHALE_TARIHI";
        //    fieldASLI_MUDEHALE_TARIHI.Visible = false;

        //    PivotGridField fieldFERI_MUDEHALE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldFERI_MUDEHALE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldFERI_MUDEHALE_TARIHI.AreaIndex = 50;
        //    fieldFERI_MUDEHALE_TARIHI.FieldName = "FERI_MUDEHALE_TARIHI";
        //    fieldFERI_MUDEHALE_TARIHI.Name = "fieldFERI_MUDEHALE_TARIHI";
        //    fieldFERI_MUDEHALE_TARIHI.Visible = false;

        //    PivotGridField fieldYETKIYE_ITIRAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldYETKIYE_ITIRAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldYETKIYE_ITIRAZ_TARIHI.AreaIndex = 51;
        //    fieldYETKIYE_ITIRAZ_TARIHI.FieldName = "YETKIYE_ITIRAZ_TARIHI";
        //    fieldYETKIYE_ITIRAZ_TARIHI.Name = "fieldYETKIYE_ITIRAZ_TARIHI";
        //    fieldYETKIYE_ITIRAZ_TARIHI.Visible = false;

        //    PivotGridField fieldGOREVE_ITIRAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldGOREVE_ITIRAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldGOREVE_ITIRAZ_TARIHI.AreaIndex = 52;
        //    fieldGOREVE_ITIRAZ_TARIHI.FieldName = "GOREVE_ITIRAZ_TARIHI";
        //    fieldGOREVE_ITIRAZ_TARIHI.Name = "fieldGOREVE_ITIRAZ_TARIHI";
        //    fieldGOREVE_ITIRAZ_TARIHI.Visible = false;

        //    PivotGridField fieldTAKIGAT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTAKIGAT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTAKIGAT_TARIHI.AreaIndex = 53;
        //    fieldTAKIGAT_TARIHI.FieldName = "TAKIGAT_TARIHI";
        //    fieldTAKIGAT_TARIHI.Name = "fieldTAKIGAT_TARIHI";
        //    fieldTAKIGAT_TARIHI.Visible = false;

        //    PivotGridField fieldESAS_BEYAN_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldESAS_BEYAN_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldESAS_BEYAN_TARIHI.AreaIndex = 54;
        //    fieldESAS_BEYAN_TARIHI.FieldName = "ESAS_BEYAN_TARIHI";
        //    fieldESAS_BEYAN_TARIHI.Name = "fieldESAS_BEYAN_TARIHI";
        //    fieldESAS_BEYAN_TARIHI.Visible = false;

        //    PivotGridField fieldEK_SAVUNMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldEK_SAVUNMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldEK_SAVUNMA_TARIHI.AreaIndex = 55;
        //    fieldEK_SAVUNMA_TARIHI.FieldName = "EK_SAVUNMA_TARIHI";
        //    fieldEK_SAVUNMA_TARIHI.Name = "fieldEK_SAVUNMA_TARIHI";
        //    fieldEK_SAVUNMA_TARIHI.Visible = false;

        //    PivotGridField fieldMUDAHALE_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMUDAHALE_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMUDAHALE_TARIHI.AreaIndex = 56;
        //    fieldMUDAHALE_TARIHI.FieldName = "MUDAHALE_TARIHI";
        //    fieldMUDAHALE_TARIHI.Name = "fieldMUDAHALE_TARIHI";
        //    fieldMUDAHALE_TARIHI.Visible = false;

        //    PivotGridField fieldSON_SAVUNMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSON_SAVUNMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSON_SAVUNMA_TARIHI.AreaIndex = 57;
        //    fieldSON_SAVUNMA_TARIHI.FieldName = "SON_SAVUNMA_TARIHI";
        //    fieldSON_SAVUNMA_TARIHI.Name = "fieldSON_SAVUNMA_TARIHI";
        //    fieldSON_SAVUNMA_TARIHI.Visible = false;

        //    PivotGridField fieldSAVUNMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSAVUNMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSAVUNMA_TARIHI.AreaIndex = 58;
        //    fieldSAVUNMA_TARIHI.FieldName = "SAVUNMA_TARIHI";
        //    fieldSAVUNMA_TARIHI.Name = "fieldSAVUNMA_TARIHI";
        //    fieldSAVUNMA_TARIHI.Visible = false;

        //    PivotGridField fieldMUTALAA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMUTALAA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMUTALAA_TARIHI.AreaIndex = 59;
        //    fieldMUTALAA_TARIHI.FieldName = "MUTALAA_TARIHI";
        //    fieldMUTALAA_TARIHI.Name = "fieldMUTALAA_TARIHI";
        //    fieldMUTALAA_TARIHI.Visible = false;

        //    PivotGridField fieldIDDIANAME_OKUNMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldIDDIANAME_OKUNMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldIDDIANAME_OKUNMA_TARIHI.AreaIndex = 60;
        //    fieldIDDIANAME_OKUNMA_TARIHI.FieldName = "IDDIANAME_OKUNMA_TARIHI";
        //    fieldIDDIANAME_OKUNMA_TARIHI.Name = "fieldIDDIANAME_OKUNMA_TARIHI";
        //    fieldIDDIANAME_OKUNMA_TARIHI.Visible = false;

        //    PivotGridField fieldZAMAN_ASIMI_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldZAMAN_ASIMI_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldZAMAN_ASIMI_TARIHI.AreaIndex = 61;
        //    fieldZAMAN_ASIMI_TARIHI.FieldName = "ZAMAN_ASIMI_TARIHI";
        //    fieldZAMAN_ASIMI_TARIHI.Name = "fieldZAMAN_ASIMI_TARIHI";
        //    fieldZAMAN_ASIMI_TARIHI.Visible = false;

        //    PivotGridField fieldOGRENME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldOGRENME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldOGRENME_TARIHI.AreaIndex = 62;
        //    fieldOGRENME_TARIHI.FieldName = "OGRENME_TARIHI";
        //    fieldOGRENME_TARIHI.Name = "fieldOGRENME_TARIHI";
        //    fieldOGRENME_TARIHI.Visible = false;

        //    PivotGridField fieldSORUMLU_OLUNAN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSORUMLU_OLUNAN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSORUMLU_OLUNAN_MIKTAR.AreaIndex = 63;
        //    fieldSORUMLU_OLUNAN_MIKTAR.FieldName = "SORUMLU_OLUNAN_MIKTAR";
        //    fieldSORUMLU_OLUNAN_MIKTAR.Name = "fieldSORUMLU_OLUNAN_MIKTAR";
        //    fieldSORUMLU_OLUNAN_MIKTAR.Visible = false;

        //    PivotGridField fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.AreaIndex = 64;
        //    fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.FieldName = "SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
        //    fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Name = "fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
        //    fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldSURE_TUTUM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSURE_TUTUM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSURE_TUTUM_TARIHI.AreaIndex = 65;
        //    fieldSURE_TUTUM_TARIHI.FieldName = "SURE_TUTUM_TARIHI";
        //    fieldSURE_TUTUM_TARIHI.Name = "fieldSURE_TUTUM_TARIHI";
        //    fieldSURE_TUTUM_TARIHI.Visible = false;

        //    PivotGridField fieldDURUSMA_TALEP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDURUSMA_TALEP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDURUSMA_TALEP_TARIHI.AreaIndex = 66;
        //    fieldDURUSMA_TALEP_TARIHI.FieldName = "DURUSMA_TALEP_TARIHI";
        //    fieldDURUSMA_TALEP_TARIHI.Name = "fieldDURUSMA_TALEP_TARIHI";
        //    fieldDURUSMA_TALEP_TARIHI.Visible = false;

        //    PivotGridField fieldKESIF_TALEP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldKESIF_TALEP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldKESIF_TALEP_TARIHI.AreaIndex = 67;
        //    fieldKESIF_TALEP_TARIHI.FieldName = "KESIF_TALEP_TARIHI";
        //    fieldKESIF_TALEP_TARIHI.Name = "fieldKESIF_TALEP_TARIHI";
        //    fieldKESIF_TALEP_TARIHI.Visible = false;

        //    PivotGridField fieldGERI_BASVURMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldGERI_BASVURMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldGERI_BASVURMA_TARIHI.AreaIndex = 68;
        //    fieldGERI_BASVURMA_TARIHI.FieldName = "GERI_BASVURMA_TARIHI";
        //    fieldGERI_BASVURMA_TARIHI.Name = "fieldGERI_BASVURMA_TARIHI";
        //    fieldGERI_BASVURMA_TARIHI.Visible = false;

        //    PivotGridField fieldYURUTME_DURDURMA_TALEP_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldYURUTME_DURDURMA_TALEP_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldYURUTME_DURDURMA_TALEP_TARIHI.AreaIndex = 69;
        //    fieldYURUTME_DURDURMA_TALEP_TARIHI.FieldName = "YURUTME_DURDURMA_TALEP_TARIHI";
        //    fieldYURUTME_DURDURMA_TALEP_TARIHI.Name = "fieldYURUTME_DURDURMA_TALEP_TARIHI";
        //    fieldYURUTME_DURDURMA_TALEP_TARIHI.Visible = false;

        //    PivotGridField fieldYURUTME_DURDURMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldYURUTME_DURDURMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldYURUTME_DURDURMA_TARIHI.AreaIndex = 70;
        //    fieldYURUTME_DURDURMA_TARIHI.FieldName = "YURUTME_DURDURMA_TARIHI";
        //    fieldYURUTME_DURDURMA_TARIHI.Name = "fieldYURUTME_DURDURMA_TARIHI";
        //    fieldYURUTME_DURDURMA_TARIHI.Visible = false;

        //    PivotGridField fieldYURUTME_DURDURMA_KALDIRILMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldYURUTME_DURDURMA_KALDIRILMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldYURUTME_DURDURMA_KALDIRILMA_TARIHI.AreaIndex = 71;
        //    fieldYURUTME_DURDURMA_KALDIRILMA_TARIHI.FieldName = "YURUTME_DURDURMA_KALDIRILMA_TARIHI";
        //    fieldYURUTME_DURDURMA_KALDIRILMA_TARIHI.Name = "fieldYURUTME_DURDURMA_KALDIRILMA_TARIHI";
        //    fieldYURUTME_DURDURMA_KALDIRILMA_TARIHI.Visible = false;

        //    PivotGridField fieldIHBAR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldIHBAR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldIHBAR_TARIHI.AreaIndex = 72;
        //    fieldIHBAR_TARIHI.FieldName = "IHBAR_TARIHI";
        //    fieldIHBAR_TARIHI.Name = "fieldIHBAR_TARIHI";
        //    fieldIHBAR_TARIHI.Visible = false;

        //    PivotGridField fieldAD = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldAD.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldAD.AreaIndex = 73;
        //    fieldAD.FieldName = "AD";
        //    fieldAD.Name = "fieldAD";
        //    fieldAD.Visible = false;

        //    PivotGridField fieldIHTAR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldIHTAR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldIHTAR_TARIHI.AreaIndex = 74;
        //    fieldIHTAR_TARIHI.FieldName = "IHTAR_TARIHI";
        //    fieldIHTAR_TARIHI.Name = "fieldIHTAR_TARIHI";
        //    fieldIHTAR_TARIHI.Visible = false;

        //    PivotGridField fieldIHTAR_TEBLIG_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldIHTAR_TEBLIG_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldIHTAR_TEBLIG_TARIHI.AreaIndex = 75;
        //    fieldIHTAR_TEBLIG_TARIHI.FieldName = "IHTAR_TEBLIG_TARIHI";
        //    fieldIHTAR_TEBLIG_TARIHI.Name = "fieldIHTAR_TEBLIG_TARIHI";
        //    fieldIHTAR_TEBLIG_TARIHI.Visible = false;

        //    PivotGridField fieldIHTAR_TEMERRUT_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldIHTAR_TEMERRUT_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldIHTAR_TEMERRUT_TARIHI.AreaIndex = 76;
        //    fieldIHTAR_TEMERRUT_TARIHI.FieldName = "IHTAR_TEMERRUT_TARIHI";
        //    fieldIHTAR_TEMERRUT_TARIHI.Name = "fieldIHTAR_TEMERRUT_TARIHI";
        //    fieldIHTAR_TEMERRUT_TARIHI.Visible = false;

        //    PivotGridField fieldZAMANASIMI_IDDIA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldZAMANASIMI_IDDIA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldZAMANASIMI_IDDIA_TARIHI.AreaIndex = 77;
        //    fieldZAMANASIMI_IDDIA_TARIHI.FieldName = "ZAMANASIMI_IDDIA_TARIHI";
        //    fieldZAMANASIMI_IDDIA_TARIHI.Name = "fieldZAMANASIMI_IDDIA_TARIHI";
        //    fieldZAMANASIMI_IDDIA_TARIHI.Visible = false;

        //    PivotGridField fieldIHBAR_TEBLIG_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldIHBAR_TEBLIG_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldIHBAR_TEBLIG_TARIHI.AreaIndex = 78;
        //    fieldIHBAR_TEBLIG_TARIHI.FieldName = "IHBAR_TEBLIG_TARIHI";
        //    fieldIHBAR_TEBLIG_TARIHI.Name = "fieldIHBAR_TEBLIG_TARIHI";
        //    fieldIHBAR_TEBLIG_TARIHI.Visible = false;

        //    PivotGridField fieldMAHKEMEDE_UZLASMA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMAHKEMEDE_UZLASMA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMAHKEMEDE_UZLASMA_TARIHI.AreaIndex = 79;
        //    fieldMAHKEMEDE_UZLASMA_TARIHI.FieldName = "MAHKEMEDE_UZLASMA_TARIHI";
        //    fieldMAHKEMEDE_UZLASMA_TARIHI.Name = "fieldMAHKEMEDE_UZLASMA_TARIHI";
        //    fieldMAHKEMEDE_UZLASMA_TARIHI.Visible = false;

        //    PivotGridField fieldHUKUM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldHUKUM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldHUKUM_TARIHI.AreaIndex = 80;
        //    fieldHUKUM_TARIHI.FieldName = "HUKUM_TARIHI";
        //    fieldHUKUM_TARIHI.Name = "fieldHUKUM_TARIHI";
        //    fieldHUKUM_TARIHI.Visible = false;

        //    PivotGridField fieldKARAR_NO = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldKARAR_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldKARAR_NO.AreaIndex = 81;
        //    fieldKARAR_NO.FieldName = "KARAR_NO";
        //    fieldKARAR_NO.Name = "fieldKARAR_NO";
        //    fieldKARAR_NO.Visible = false;

        //    PivotGridField fieldHUKUM = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldHUKUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldHUKUM.AreaIndex = 82;
        //    fieldHUKUM.FieldName = "HUKUM";
        //    fieldHUKUM.Name = "fieldHUKUM";
        //    fieldHUKUM.Visible = false;

        //    PivotGridField fieldHUKUM_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldHUKUM_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldHUKUM_TIP.AreaIndex = 83;
        //    fieldHUKUM_TIP.FieldName = "HUKUM_TIP";
        //    fieldHUKUM_TIP.Name = "fieldHUKUM_TIP";
        //    fieldHUKUM_TIP.Visible = false;

        //    PivotGridField fieldHUKUM_GEREKCE = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldHUKUM_GEREKCE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldHUKUM_GEREKCE.AreaIndex = 84;
        //    fieldHUKUM_GEREKCE.FieldName = "HUKUM_GEREKCE";
        //    fieldHUKUM_GEREKCE.Name = "fieldHUKUM_GEREKCE";
        //    fieldHUKUM_GEREKCE.Visible = false;

        //    PivotGridField fieldHUKUM_DEGER = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldHUKUM_DEGER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldHUKUM_DEGER.AreaIndex = 85;
        //    fieldHUKUM_DEGER.FieldName = "HUKUM_DEGER";
        //    fieldHUKUM_DEGER.Name = "fieldHUKUM_DEGER";
        //    fieldHUKUM_DEGER.Visible = false;

        //    PivotGridField fieldHUKUM_DEGER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldHUKUM_DEGER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldHUKUM_DEGER_DOVIZ_ID.AreaIndex = 86;
        //    fieldHUKUM_DEGER_DOVIZ_ID.FieldName = "HUKUM_DEGER_DOVIZ_ID";
        //    fieldHUKUM_DEGER_DOVIZ_ID.Name = "fieldHUKUM_DEGER_DOVIZ_ID";
        //    fieldHUKUM_DEGER_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldMUSADERE_DEGER = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMUSADERE_DEGER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMUSADERE_DEGER.AreaIndex = 87;
        //    fieldMUSADERE_DEGER.FieldName = "MUSADERE_DEGER";
        //    fieldMUSADERE_DEGER.Name = "fieldMUSADERE_DEGER";
        //    fieldMUSADERE_DEGER.Visible = false;

        //    PivotGridField fieldMUSADERE_DEGER_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMUSADERE_DEGER_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMUSADERE_DEGER_DOVIZ_ID.AreaIndex = 88;
        //    fieldMUSADERE_DEGER_DOVIZ_ID.FieldName = "MUSADERE_DEGER_DOVIZ_ID";
        //    fieldMUSADERE_DEGER_DOVIZ_ID.Name = "fieldMUSADERE_DEGER_DOVIZ_ID";
        //    fieldMUSADERE_DEGER_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldMAHKUMIYET_YIL = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMAHKUMIYET_YIL.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMAHKUMIYET_YIL.AreaIndex = 89;
        //    fieldMAHKUMIYET_YIL.FieldName = "MAHKUMIYET_YIL";
        //    fieldMAHKUMIYET_YIL.Name = "fieldMAHKUMIYET_YIL";
        //    fieldMAHKUMIYET_YIL.Visible = false;

        //    PivotGridField fieldMAHKUMIYET_AY = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMAHKUMIYET_AY.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMAHKUMIYET_AY.AreaIndex = 90;
        //    fieldMAHKUMIYET_AY.FieldName = "MAHKUMIYET_AY";
        //    fieldMAHKUMIYET_AY.Name = "fieldMAHKUMIYET_AY";
        //    fieldMAHKUMIYET_AY.Visible = false;

        //    PivotGridField fieldMAHKUMIYET_GUN = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMAHKUMIYET_GUN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMAHKUMIYET_GUN.AreaIndex = 91;
        //    fieldMAHKUMIYET_GUN.FieldName = "MAHKUMIYET_GUN";
        //    fieldMAHKUMIYET_GUN.Name = "fieldMAHKUMIYET_GUN";
        //    fieldMAHKUMIYET_GUN.Visible = false;

        //    PivotGridField fieldCEZA_ERTELENDI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldCEZA_ERTELENDI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldCEZA_ERTELENDI.AreaIndex = 92;
        //    fieldCEZA_ERTELENDI.FieldName = "CEZA_ERTELENDI";
        //    fieldCEZA_ERTELENDI.Name = "fieldCEZA_ERTELENDI";
        //    fieldCEZA_ERTELENDI.Visible = false;

        //    PivotGridField fieldPARAYA_CEVRILDI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldPARAYA_CEVRILDI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldPARAYA_CEVRILDI.AreaIndex = 93;
        //    fieldPARAYA_CEVRILDI.FieldName = "PARAYA_CEVRILDI";
        //    fieldPARAYA_CEVRILDI.Name = "fieldPARAYA_CEVRILDI";
        //    fieldPARAYA_CEVRILDI.Visible = false;

        //    PivotGridField fieldPARAYA_CEVRILEN_MIKTAR = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldPARAYA_CEVRILEN_MIKTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldPARAYA_CEVRILEN_MIKTAR.AreaIndex = 94;
        //    fieldPARAYA_CEVRILEN_MIKTAR.FieldName = "PARAYA_CEVRILEN_MIKTAR";
        //    fieldPARAYA_CEVRILEN_MIKTAR.Name = "fieldPARAYA_CEVRILEN_MIKTAR";
        //    fieldPARAYA_CEVRILEN_MIKTAR.Visible = false;

        //    PivotGridField fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.AreaIndex = 95;
        //    fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.FieldName = "PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
        //    fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Name = "fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
        //    fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldMESLEK_ICRA_MEN_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMESLEK_ICRA_MEN_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMESLEK_ICRA_MEN_TIP.AreaIndex = 96;
        //    fieldMESLEK_ICRA_MEN_TIP.FieldName = "MESLEK_ICRA_MEN_TIP";
        //    fieldMESLEK_ICRA_MEN_TIP.Name = "fieldMESLEK_ICRA_MEN_TIP";
        //    fieldMESLEK_ICRA_MEN_TIP.Visible = false;

        //    PivotGridField fieldMESLEK_ICRA_MEN_SURE = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldMESLEK_ICRA_MEN_SURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldMESLEK_ICRA_MEN_SURE.AreaIndex = 97;
        //    fieldMESLEK_ICRA_MEN_SURE.FieldName = "MESLEK_ICRA_MEN_SURE";
        //    fieldMESLEK_ICRA_MEN_SURE.Name = "fieldMESLEK_ICRA_MEN_SURE";
        //    fieldMESLEK_ICRA_MEN_SURE.Visible = false;

        //    PivotGridField fieldEHLIYET_GERI_ALINMA_MEN_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldEHLIYET_GERI_ALINMA_MEN_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldEHLIYET_GERI_ALINMA_MEN_TIP.AreaIndex = 98;
        //    fieldEHLIYET_GERI_ALINMA_MEN_TIP.FieldName = "EHLIYET_GERI_ALINMA_MEN_TIP";
        //    fieldEHLIYET_GERI_ALINMA_MEN_TIP.Name = "fieldEHLIYET_GERI_ALINMA_MEN_TIP";
        //    fieldEHLIYET_GERI_ALINMA_MEN_TIP.Visible = false;

        //    PivotGridField fieldEHLIYET_GERI_ALINMA_MEN_SURE = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldEHLIYET_GERI_ALINMA_MEN_SURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldEHLIYET_GERI_ALINMA_MEN_SURE.AreaIndex = 99;
        //    fieldEHLIYET_GERI_ALINMA_MEN_SURE.FieldName = "EHLIYET_GERI_ALINMA_MEN_SURE";
        //    fieldEHLIYET_GERI_ALINMA_MEN_SURE.Name = "fieldEHLIYET_GERI_ALINMA_MEN_SURE";
        //    fieldEHLIYET_GERI_ALINMA_MEN_SURE.Visible = false;

        //    PivotGridField fieldKAMU_HIZMET_YASAK_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldKAMU_HIZMET_YASAK_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldKAMU_HIZMET_YASAK_TIP.AreaIndex = 100;
        //    fieldKAMU_HIZMET_YASAK_TIP.FieldName = "KAMU_HIZMET_YASAK_TIP";
        //    fieldKAMU_HIZMET_YASAK_TIP.Name = "fieldKAMU_HIZMET_YASAK_TIP";
        //    fieldKAMU_HIZMET_YASAK_TIP.Visible = false;

        //    PivotGridField fieldKAMU_HIZMET_YASAK_SURE = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldKAMU_HIZMET_YASAK_SURE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldKAMU_HIZMET_YASAK_SURE.AreaIndex = 101;
        //    fieldKAMU_HIZMET_YASAK_SURE.FieldName = "KAMU_HIZMET_YASAK_SURE";
        //    fieldKAMU_HIZMET_YASAK_SURE.Name = "fieldKAMU_HIZMET_YASAK_SURE";
        //    fieldKAMU_HIZMET_YASAK_SURE.Visible = false;

        //    PivotGridField fieldHUKUM_TARAF_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldHUKUM_TARAF_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldHUKUM_TARAF_CARI.AreaIndex = 102;
        //    fieldHUKUM_TARAF_CARI.FieldName = "HUKUM_TARAF_CARI";
        //    fieldHUKUM_TARAF_CARI.Name = "fieldHUKUM_TARAF_CARI";
        //    fieldHUKUM_TARAF_CARI.Visible = false;

        //    PivotGridField fieldINFAZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldINFAZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldINFAZ_TARIHI.AreaIndex = 103;
        //    fieldINFAZ_TARIHI.FieldName = "INFAZ_TARIHI";
        //    fieldINFAZ_TARIHI.Name = "fieldINFAZ_TARIHI";
        //    fieldINFAZ_TARIHI.Visible = false;

        //    PivotGridField fieldHUKUM_KESINLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldHUKUM_KESINLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldHUKUM_KESINLESME_TARIHI.AreaIndex = 104;
        //    fieldHUKUM_KESINLESME_TARIHI.FieldName = "HUKUM_KESINLESME_TARIHI";
        //    fieldHUKUM_KESINLESME_TARIHI.Name = "fieldHUKUM_KESINLESME_TARIHI";
        //    fieldHUKUM_KESINLESME_TARIHI.Visible = false;

        //    PivotGridField fieldSORUMLULUK_MIKTARI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSORUMLULUK_MIKTARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSORUMLULUK_MIKTARI.AreaIndex = 105;
        //    fieldSORUMLULUK_MIKTARI.FieldName = "SORUMLULUK_MIKTARI";
        //    fieldSORUMLULUK_MIKTARI.Name = "fieldSORUMLULUK_MIKTARI";
        //    fieldSORUMLULUK_MIKTARI.Visible = false;

        //    PivotGridField fieldSORUMLULUK_MIKTARI_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSORUMLULUK_MIKTARI_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSORUMLULUK_MIKTARI_DOVIZ_ID.AreaIndex = 106;
        //    fieldSORUMLULUK_MIKTARI_DOVIZ_ID.FieldName = "SORUMLULUK_MIKTARI_DOVIZ_ID";
        //    fieldSORUMLULUK_MIKTARI_DOVIZ_ID.Name = "fieldSORUMLULUK_MIKTARI_DOVIZ_ID";
        //    fieldSORUMLULUK_MIKTARI_DOVIZ_ID.Visible = false;

        //    PivotGridField fieldHUKUM_TEBLIG_TEFHIM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldHUKUM_TEBLIG_TEFHIM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldHUKUM_TEBLIG_TEFHIM_TARIHI.AreaIndex = 107;
        //    fieldHUKUM_TEBLIG_TEFHIM_TARIHI.FieldName = "HUKUM_TEBLIG_TEFHIM_TARIHI";
        //    fieldHUKUM_TEBLIG_TEFHIM_TARIHI.Name = "fieldHUKUM_TEBLIG_TEFHIM_TARIHI";
        //    fieldHUKUM_TEBLIG_TEFHIM_TARIHI.Visible = false;

        //    PivotGridField fieldTEMYIZ_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TIP.AreaIndex = 108;
        //    fieldTEMYIZ_TIP.FieldName = "TEMYIZ_TIP";
        //    fieldTEMYIZ_TIP.Name = "fieldTEMYIZ_TIP";
        //    fieldTEMYIZ_TIP.Visible = false;

        //    PivotGridField fieldYUKSEK_MAHKEME_GONDERIM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.AreaIndex = 109;
        //    fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.FieldName = "YUKSEK_MAHKEME_GONDERIM_TARIHI";
        //    fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.Name = "fieldYUKSEK_MAHKEME_GONDERIM_TARIHI";
        //    fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.Visible = false;

        //    PivotGridField fieldTEMYIZ_ADLI_BIRIM_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_ADLI_BIRIM_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_ADLI_BIRIM_ADLIYE.AreaIndex = 110;
        //    fieldTEMYIZ_ADLI_BIRIM_ADLIYE.FieldName = "TEMYIZ_ADLI_BIRIM_ADLIYE";
        //    fieldTEMYIZ_ADLI_BIRIM_ADLIYE.Name = "fieldTEMYIZ_ADLI_BIRIM_ADLIYE";
        //    fieldTEMYIZ_ADLI_BIRIM_ADLIYE.Visible = false;

        //    PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldGOREV.AreaIndex = 111;
        //    fieldGOREV.FieldName = "GOREV";
        //    fieldGOREV.Name = "fieldGOREV";
        //    fieldGOREV.Visible = false;

        //    PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldNO.AreaIndex = 112;
        //    fieldNO.FieldName = "NO";
        //    fieldNO.Name = "fieldNO";
        //    fieldNO.Visible = false;

        //    PivotGridField fieldTEMYIZ_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_ESAS_NO.AreaIndex = 113;
        //    fieldTEMYIZ_ESAS_NO.FieldName = "TEMYIZ_ESAS_NO";
        //    fieldTEMYIZ_ESAS_NO.Name = "fieldTEMYIZ_ESAS_NO";
        //    fieldTEMYIZ_ESAS_NO.Visible = false;

        //    PivotGridField fieldTEMYIZ_KARAR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_KARAR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_KARAR_TARIHI.AreaIndex = 114;
        //    fieldTEMYIZ_KARAR_TARIHI.FieldName = "TEMYIZ_KARAR_TARIHI";
        //    fieldTEMYIZ_KARAR_TARIHI.Name = "fieldTEMYIZ_KARAR_TARIHI";
        //    fieldTEMYIZ_KARAR_TARIHI.Visible = false;

        //    PivotGridField fieldTEMYIZ_KARAR_NO = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_KARAR_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_KARAR_NO.AreaIndex = 115;
        //    fieldTEMYIZ_KARAR_NO.FieldName = "TEMYIZ_KARAR_NO";
        //    fieldTEMYIZ_KARAR_NO.Name = "fieldTEMYIZ_KARAR_NO";
        //    fieldTEMYIZ_KARAR_NO.Visible = false;

        //    PivotGridField fieldKARAR_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldKARAR_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldKARAR_TIP.AreaIndex = 116;
        //    fieldKARAR_TIP.FieldName = "KARAR_TIP";
        //    fieldKARAR_TIP.Name = "fieldKARAR_TIP";
        //    fieldKARAR_TIP.Visible = false;

        //    PivotGridField fieldTEMYIZ_GEREKCE = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_GEREKCE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_GEREKCE.AreaIndex = 117;
        //    fieldTEMYIZ_GEREKCE.FieldName = "TEMYIZ_GEREKCE";
        //    fieldTEMYIZ_GEREKCE.Name = "fieldTEMYIZ_GEREKCE";
        //    fieldTEMYIZ_GEREKCE.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_TEMYIZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_TEMYIZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_TEMYIZ_TARIHI.AreaIndex = 118;
        //    fieldTEMYIZ_TARAF_TEMYIZ_TARIHI.FieldName = "TEMYIZ_TARAF_TEMYIZ_TARIHI";
        //    fieldTEMYIZ_TARAF_TEMYIZ_TARIHI.Name = "fieldTEMYIZ_TARAF_TEMYIZ_TARIHI";
        //    fieldTEMYIZ_TARAF_TEMYIZ_TARIHI.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_CARI.AreaIndex = 119;
        //    fieldTEMYIZ_TARAF_CARI.FieldName = "TEMYIZ_TARAF_CARI";
        //    fieldTEMYIZ_TARAF_CARI.Name = "fieldTEMYIZ_TARAF_CARI";
        //    fieldTEMYIZ_TARAF_CARI.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_USUL_NEDENLERI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_USUL_NEDENLERI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_USUL_NEDENLERI.AreaIndex = 120;
        //    fieldTEMYIZ_TARAF_USUL_NEDENLERI.FieldName = "TEMYIZ_TARAF_USUL_NEDENLERI";
        //    fieldTEMYIZ_TARAF_USUL_NEDENLERI.Name = "fieldTEMYIZ_TARAF_USUL_NEDENLERI";
        //    fieldTEMYIZ_TARAF_USUL_NEDENLERI.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_YASAL_NEDENLER = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_YASAL_NEDENLER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_YASAL_NEDENLER.AreaIndex = 121;
        //    fieldTEMYIZ_TARAF_YASAL_NEDENLER.FieldName = "TEMYIZ_TARAF_YASAL_NEDENLER";
        //    fieldTEMYIZ_TARAF_YASAL_NEDENLER.Name = "fieldTEMYIZ_TARAF_YASAL_NEDENLER";
        //    fieldTEMYIZ_TARAF_YASAL_NEDENLER.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_ACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_ACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_ACIKLAMA.AreaIndex = 122;
        //    fieldTEMYIZ_TARAF_ACIKLAMA.FieldName = "TEMYIZ_TARAF_ACIKLAMA";
        //    fieldTEMYIZ_TARAF_ACIKLAMA.Name = "fieldTEMYIZ_TARAF_ACIKLAMA";
        //    fieldTEMYIZ_TARAF_ACIKLAMA.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI.AreaIndex = 123;
        //    fieldTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI.FieldName = "TEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI";
        //    fieldTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI.Name = "fieldTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI";
        //    fieldTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_TEDBIR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_TEDBIR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_TEDBIR_TARIHI.AreaIndex = 124;
        //    fieldTEMYIZ_TARAF_TEDBIR_TARIHI.FieldName = "TEMYIZ_TARAF_TEDBIR_TARIHI";
        //    fieldTEMYIZ_TARAF_TEDBIR_TARIHI.Name = "fieldTEMYIZ_TARAF_TEDBIR_TARIHI";
        //    fieldTEMYIZ_TARAF_TEDBIR_TARIHI.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_TEDBIR_ACIKLAMASI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_TEDBIR_ACIKLAMASI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_TEDBIR_ACIKLAMASI.AreaIndex = 125;
        //    fieldTEMYIZ_TARAF_TEDBIR_ACIKLAMASI.FieldName = "TEMYIZ_TARAF_TEDBIR_ACIKLAMASI";
        //    fieldTEMYIZ_TARAF_TEDBIR_ACIKLAMASI.Name = "fieldTEMYIZ_TARAF_TEDBIR_ACIKLAMASI";
        //    fieldTEMYIZ_TARAF_TEDBIR_ACIKLAMASI.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI.AreaIndex = 126;
        //    fieldTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI.FieldName = "TEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI";
        //    fieldTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI.Name = "fieldTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI";
        //    fieldTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI.Visible = false;

        //    PivotGridField fieldTEMYIZ_TEBLIG_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TEBLIG_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TEBLIG_TARIHI.AreaIndex = 127;
        //    fieldTEMYIZ_TEBLIG_TARIHI.FieldName = "TEMYIZ_TEBLIG_TARIHI";
        //    fieldTEMYIZ_TEBLIG_TARIHI.Name = "fieldTEMYIZ_TEBLIG_TARIHI";
        //    fieldTEMYIZ_TEBLIG_TARIHI.Visible = false;

        //    PivotGridField fieldTEFHIM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEFHIM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEFHIM_TARIHI.AreaIndex = 128;
        //    fieldTEFHIM_TARIHI.FieldName = "TEFHIM_TARIHI";
        //    fieldTEFHIM_TARIHI.Name = "fieldTEFHIM_TARIHI";
        //    fieldTEFHIM_TARIHI.Visible = false;

        //    PivotGridField fieldTEMYIZ_TARAF_SURE_TUTUM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldTEMYIZ_TARAF_SURE_TUTUM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldTEMYIZ_TARAF_SURE_TUTUM_TARIHI.AreaIndex = 129;
        //    fieldTEMYIZ_TARAF_SURE_TUTUM_TARIHI.FieldName = "TEMYIZ_TARAF_SURE_TUTUM_TARIHI";
        //    fieldTEMYIZ_TARAF_SURE_TUTUM_TARIHI.Name = "fieldTEMYIZ_TARAF_SURE_TUTUM_TARIHI";
        //    fieldTEMYIZ_TARAF_SURE_TUTUM_TARIHI.Visible = false;

        //    PivotGridField fieldDAVA_FOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_FOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_FOY_NO.AreaIndex = 130;
        //    fieldDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
        //    fieldDAVA_FOY_NO.Name = "fieldDAVA_FOY_NO";
        //    fieldDAVA_FOY_NO.Visible = false;

        //    PivotGridField fieldDAVA_ADLI_BIRIM_ADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_ADLI_BIRIM_ADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_ADLI_BIRIM_ADLIYE.AreaIndex = 131;
        //    fieldDAVA_ADLI_BIRIM_ADLIYE.FieldName = "DAVA_ADLI_BIRIM_ADLIYE";
        //    fieldDAVA_ADLI_BIRIM_ADLIYE.Name = "fieldDAVA_ADLI_BIRIM_ADLIYE";
        //    fieldDAVA_ADLI_BIRIM_ADLIYE.Visible = false;

        //    PivotGridField fieldDAVA_ADLI_BIRIM_GOREV = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_ADLI_BIRIM_GOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_ADLI_BIRIM_GOREV.AreaIndex = 132;
        //    fieldDAVA_ADLI_BIRIM_GOREV.FieldName = "DAVA_ADLI_BIRIM_GOREV";
        //    fieldDAVA_ADLI_BIRIM_GOREV.Name = "fieldDAVA_ADLI_BIRIM_GOREV";
        //    fieldDAVA_ADLI_BIRIM_GOREV.Visible = false;

        //    PivotGridField fieldDAVA_ADLI_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_ADLI_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_ADLI_BIRIM_NO.AreaIndex = 133;
        //    fieldDAVA_ADLI_BIRIM_NO.FieldName = "DAVA_ADLI_BIRIM_NO";
        //    fieldDAVA_ADLI_BIRIM_NO.Name = "fieldDAVA_ADLI_BIRIM_NO";
        //    fieldDAVA_ADLI_BIRIM_NO.Visible = false;

        //    PivotGridField fieldDAVA_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_ESAS_NO.AreaIndex = 134;
        //    fieldDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
        //    fieldDAVA_ESAS_NO.Name = "fieldDAVA_ESAS_NO";
        //    fieldDAVA_ESAS_NO.Visible = false;

        //    PivotGridField fieldDAVA_TAKIP_T = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_TAKIP_T.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_TAKIP_T.AreaIndex = 135;
        //    fieldDAVA_TAKIP_T.FieldName = "DAVA_TAKIP_T";
        //    fieldDAVA_TAKIP_T.Name = "fieldDAVA_TAKIP_T";
        //    fieldDAVA_TAKIP_T.Visible = false;

        //    PivotGridField fieldDAVA_REFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_REFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_REFERANS_NO2.AreaIndex = 136;
        //    fieldDAVA_REFERANS_NO2.FieldName = "DAVA_REFERANS_NO2";
        //    fieldDAVA_REFERANS_NO2.Name = "fieldDAVA_REFERANS_NO2";
        //    fieldDAVA_REFERANS_NO2.Visible = false;

        //    PivotGridField fieldDAVA_REFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_REFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_REFERANS_NO3.AreaIndex = 137;
        //    fieldDAVA_REFERANS_NO3.FieldName = "DAVA_REFERANS_NO3";
        //    fieldDAVA_REFERANS_NO3.Name = "fieldDAVA_REFERANS_NO3";
        //    fieldDAVA_REFERANS_NO3.Visible = false;

        //    PivotGridField fieldDAVA_REFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_REFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_REFERANS_NO.AreaIndex = 138;
        //    fieldDAVA_REFERANS_NO.FieldName = "DAVA_REFERANS_NO";
        //    fieldDAVA_REFERANS_NO.Name = "fieldDAVA_REFERANS_NO";
        //    fieldDAVA_REFERANS_NO.Visible = false;

        //    PivotGridField fieldDAVA_OZEL_KOD1 = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_OZEL_KOD1.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_OZEL_KOD1.AreaIndex = 139;
        //    fieldDAVA_OZEL_KOD1.FieldName = "DAVA_OZEL_KOD1";
        //    fieldDAVA_OZEL_KOD1.Name = "fieldDAVA_OZEL_KOD1";
        //    fieldDAVA_OZEL_KOD1.Visible = false;

        //    PivotGridField fieldDAVA_OZEL_KOD2 = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_OZEL_KOD2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_OZEL_KOD2.AreaIndex = 140;
        //    fieldDAVA_OZEL_KOD2.FieldName = "DAVA_OZEL_KOD2";
        //    fieldDAVA_OZEL_KOD2.Name = "fieldDAVA_OZEL_KOD2";
        //    fieldDAVA_OZEL_KOD2.Visible = false;

        //    PivotGridField fieldDAVA_OZEL_KOD3 = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_OZEL_KOD3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_OZEL_KOD3.AreaIndex = 141;
        //    fieldDAVA_OZEL_KOD3.FieldName = "DAVA_OZEL_KOD3";
        //    fieldDAVA_OZEL_KOD3.Name = "fieldDAVA_OZEL_KOD3";
        //    fieldDAVA_OZEL_KOD3.Visible = false;

        //    PivotGridField fieldDAVA_OZEL_KOD4 = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_OZEL_KOD4.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_OZEL_KOD4.AreaIndex = 142;
        //    fieldDAVA_OZEL_KOD4.FieldName = "DAVA_OZEL_KOD4";
        //    fieldDAVA_OZEL_KOD4.Name = "fieldDAVA_OZEL_KOD4";
        //    fieldDAVA_OZEL_KOD4.Visible = false;

        //    PivotGridField fieldDAVA_ASAMA = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_ASAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_ASAMA.AreaIndex = 143;
        //    fieldDAVA_ASAMA.FieldName = "DAVA_ASAMA";
        //    fieldDAVA_ASAMA.Name = "fieldDAVA_ASAMA";
        //    fieldDAVA_ASAMA.Visible = false;

        //    PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_TALEP.AreaIndex = 144;
        //    fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
        //    fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
        //    fieldDAVA_TALEP.Visible = false;

        //    PivotGridField fieldDAVA_TARAF_KODU = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_TARAF_KODU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_TARAF_KODU.AreaIndex = 145;
        //    fieldDAVA_TARAF_KODU.FieldName = "DAVA_TARAF_KODU";
        //    fieldDAVA_TARAF_KODU.Name = "fieldDAVA_TARAF_KODU";
        //    fieldDAVA_TARAF_KODU.Visible = false;

        //    PivotGridField fieldDAVA_TARAF_CARI = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_TARAF_CARI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_TARAF_CARI.AreaIndex = 146;
        //    fieldDAVA_TARAF_CARI.FieldName = "DAVA_TARAF_CARI";
        //    fieldDAVA_TARAF_CARI.Name = "fieldDAVA_TARAF_CARI";
        //    fieldDAVA_TARAF_CARI.Visible = false;

        //    PivotGridField fieldDAVA_TARAF_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldDAVA_TARAF_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldDAVA_TARAF_SIFAT.AreaIndex = 147;
        //    fieldDAVA_TARAF_SIFAT.FieldName = "DAVA_TARAF_SIFAT";
        //    fieldDAVA_TARAF_SIFAT.Name = "fieldDAVA_TARAF_SIFAT";
        //    fieldDAVA_TARAF_SIFAT.Visible = false;

        //    PivotGridField fieldSORUMLY_AVUKAT = new DevExpress.XtraPivotGrid.PivotGridField();
        //    fieldSORUMLY_AVUKAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
        //    fieldSORUMLY_AVUKAT.AreaIndex = 148;
        //    fieldSORUMLY_AVUKAT.FieldName = "SORUMLY_AVUKAT";
        //    fieldSORUMLY_AVUKAT.Name = "fieldSORUMLY_AVUKAT";
        //    fieldSORUMLY_AVUKAT.Visible = false;

        //    #endregion

        //    #region []
        //    PivotGridField[] dizi = new PivotGridField[]
        //{
        //    fieldTERDITLI_MI,
        //    fieldDAVA_NEDEN_TIP,
        //    fieldDAVA_ADI,
        //    fieldDIGER_DAVA_NEDEN,
        //    fieldADLIYE,
        //    fieldOLAY_SUC_TARIHI,
        //    fieldDUZENLEME_TARIHI,
        //    fieldTEBELLUG_TARIHI,
        //    fieldFAIZ_TALEP_TARIHI,
        //    fieldFAIZ_KARAR_TARIHI,
        //    fieldTEDBIR_TARIHI,
        //    fieldTEDBIR_KALDIRILMA_TARIHI,
        //    fieldTEDBIR_TALEP_TARIHI,
        //    fieldDOVIZ_ISLEM_TIPI,
        //    fieldSABIT_FAIZ_UYGULA,
        //    fieldFAIZ_TIP,
        //    fieldDO_FAIZ_ORANI,
        //    fieldFaizTip,
        //    fieldDAVA_NEDEN_FAIZ_ORANI,
        //    fieldDAVA_N_TUTAR,
        //    fieldTUTAR_DOVIZ_ID,
        //    fieldDAVA_EDILEN_TUTAR,
        //    fieldDAVA_EDILEN_TUTAR_DOVIZ_ID,
        //    fieldISLAH_EDILMIS,
        //    fieldISLAH_TARIHI,
        //    fieldISLAH_EDILEN_TUTAR,
        //    fieldISLAH_EDILEN_TUTAR_DOVIZ_ID,
        //    fieldPROTESTO_GIDERI,
        //    fieldPROTESTO_GIDERI_DOVIZ_ID,
        //    fieldIHTAR_GIDERI,
        //    fieldIHTAR_GIDERI_DOVIZ_ID,
        //    fieldDAVA_N_DIGER_GIDER,
        //    fieldDIGER_GIDER_DOVIZ_ID,
        //    fieldDAVA_NEDEN_SURE_GUN,
        //    fieldDAVA_NEDEN_SURE_AY,
        //    fieldDAVA_NEDEN_SURE_YIL,
        //    fieldDAVA_NEDEN_REFERANS_NO1,
        //    fieldDAVA_NEDEN_REFERANS_NO2,
        //    fieldVERGI_DONEMI,
        //    fieldFAIZ_YOK,
        //    fieldSIFAT,
        //    fieldTARAF_ADI,
        //    fieldKESINLESME_TARIHI,
        //    fieldSULH_TARIHI,
        //    fieldKABUL_TARIHI,
        //    fieldATIYE_BIRAKMA_TARIHI,
        //    fieldVAZGECME_TARIHI,
        //    fieldIKRAR_TARIHI,
        //    fieldGERI_ALMA_TARIHI,
        //    fieldASLI_MUDEHALE_TARIHI,
        //    fieldFERI_MUDEHALE_TARIHI,
        //    fieldYETKIYE_ITIRAZ_TARIHI,
        //    fieldGOREVE_ITIRAZ_TARIHI,
        //    fieldTAKIGAT_TARIHI,
        //    fieldESAS_BEYAN_TARIHI,
        //    fieldEK_SAVUNMA_TARIHI,
        //    fieldMUDAHALE_TARIHI,
        //    fieldSON_SAVUNMA_TARIHI,
        //    fieldSAVUNMA_TARIHI,
        //    fieldMUTALAA_TARIHI,
        //    fieldIDDIANAME_OKUNMA_TARIHI,
        //    fieldZAMAN_ASIMI_TARIHI,
        //    fieldOGRENME_TARIHI,
        //    fieldSORUMLU_OLUNAN_MIKTAR,
        //    fieldSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID,
        //    fieldSURE_TUTUM_TARIHI,
        //    fieldDURUSMA_TALEP_TARIHI,
        //    fieldKESIF_TALEP_TARIHI,
        //    fieldGERI_BASVURMA_TARIHI,
        //    fieldYURUTME_DURDURMA_TALEP_TARIHI,
        //    fieldYURUTME_DURDURMA_TARIHI,
        //    fieldYURUTME_DURDURMA_KALDIRILMA_TARIHI,
        //    fieldIHBAR_TARIHI,
        //    fieldAD,
        //    fieldIHTAR_TARIHI,
        //    fieldIHTAR_TEBLIG_TARIHI,
        //    fieldIHTAR_TEMERRUT_TARIHI,
        //    fieldZAMANASIMI_IDDIA_TARIHI,
        //    fieldIHBAR_TEBLIG_TARIHI,
        //    fieldMAHKEMEDE_UZLASMA_TARIHI,
        //    fieldHUKUM_TARIHI,
        //    fieldKARAR_NO,
        //    fieldHUKUM,
        //    fieldHUKUM_TIP,
        //    fieldHUKUM_GEREKCE,
        //    fieldHUKUM_DEGER,
        //    fieldHUKUM_DEGER_DOVIZ_ID,
        //    fieldMUSADERE_DEGER,
        //    fieldMUSADERE_DEGER_DOVIZ_ID,
        //    fieldMAHKUMIYET_YIL,
        //    fieldMAHKUMIYET_AY,
        //    fieldMAHKUMIYET_GUN,
        //    fieldCEZA_ERTELENDI,
        //    fieldPARAYA_CEVRILDI,
        //    fieldPARAYA_CEVRILEN_MIKTAR,
        //    fieldPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID,
        //    fieldMESLEK_ICRA_MEN_TIP,
        //    fieldMESLEK_ICRA_MEN_SURE,
        //    fieldEHLIYET_GERI_ALINMA_MEN_TIP,
        //    fieldEHLIYET_GERI_ALINMA_MEN_SURE,
        //    fieldKAMU_HIZMET_YASAK_TIP,
        //    fieldKAMU_HIZMET_YASAK_SURE,
        //    fieldHUKUM_TARAF_CARI,
        //    fieldINFAZ_TARIHI,
        //    fieldHUKUM_KESINLESME_TARIHI,
        //    fieldSORUMLULUK_MIKTARI,
        //    fieldSORUMLULUK_MIKTARI_DOVIZ_ID,
        //    fieldHUKUM_TEBLIG_TEFHIM_TARIHI,
        //    fieldTEMYIZ_TIP,
        //    fieldYUKSEK_MAHKEME_GONDERIM_TARIHI,
        //    fieldTEMYIZ_ADLI_BIRIM_ADLIYE,
        //    fieldGOREV,
        //    fieldNO,
        //    fieldTEMYIZ_ESAS_NO,
        //    fieldTEMYIZ_KARAR_TARIHI,
        //    fieldTEMYIZ_KARAR_NO,
        //    fieldKARAR_TIP,
        //    fieldTEMYIZ_GEREKCE,
        //    fieldTEMYIZ_TARAF_TEMYIZ_TARIHI,
        //    fieldTEMYIZ_TARAF_CARI,
        //    fieldTEMYIZ_TARAF_USUL_NEDENLERI,
        //    fieldTEMYIZ_TARAF_YASAL_NEDENLER,
        //    fieldTEMYIZ_TARAF_ACIKLAMA,
        //    fieldTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI,
        //    fieldTEMYIZ_TARAF_TEDBIR_TARIHI,
        //    fieldTEMYIZ_TARAF_TEDBIR_ACIKLAMASI,
        //    fieldTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI,
        //    fieldTEMYIZ_TEBLIG_TARIHI,
        //    fieldTEFHIM_TARIHI,
        //    fieldTEMYIZ_TARAF_SURE_TUTUM_TARIHI,
        //    fieldDAVA_FOY_NO,
        //    fieldDAVA_ADLI_BIRIM_ADLIYE,
        //    fieldDAVA_ADLI_BIRIM_GOREV,
        //    fieldDAVA_ADLI_BIRIM_NO,
        //    fieldDAVA_ESAS_NO,
        //    fieldDAVA_TAKIP_T,
        //    fieldDAVA_REFERANS_NO2,
        //    fieldDAVA_REFERANS_NO3,
        //    fieldDAVA_REFERANS_NO,
        //    fieldDAVA_OZEL_KOD1,
        //    fieldDAVA_OZEL_KOD2,
        //    fieldDAVA_OZEL_KOD3,
        //    fieldDAVA_OZEL_KOD4,
        //    fieldDAVA_ASAMA,
        //    fieldDAVA_TALEP,
        //    fieldDAVA_TARAF_KODU,
        //    fieldDAVA_TARAF_CARI,
        //    fieldDAVA_TARAF_SIFAT,
        //    fieldSORUMLY_AVUKAT,
        //    };
        //    #endregion

        //    #region Field Caption

        //    Dictionary<string, string> captionlar = GetCaptionDictinory();
        //    Dictionary<string, RepositoryItem> editler = GetRepositoryItemDictinory();

        //    for (int i = 0; i < dizi.Length; i++)
        //    {
        //        string caption = string.Empty;
        //        if (captionlar.ContainsKey(dizi[i].FieldName))
        //            caption = captionlar[dizi[i].FieldName];
        //        if (caption.Length > 0)
        //            dizi[i].Caption = caption;
        //        else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
        //            dizi[i].Caption = "Brm";

        //        if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
        //        {
        //            dizi[i].FieldEdit = editler["DovizId"];
        //        }
        //        else if (editler.ContainsKey(dizi[i].FieldName))
        //            dizi[i].FieldEdit = editler[dizi[i].FieldName];
        //    }
        //    #endregion

        //    return dizi;

        //}

        //public GridColumn[] GetGridColumns(string RaporName)
        //{
        //    #region Field & Properties
        //    GridColumn colTERDITLI_MI = new GridColumn();
        //    colTERDITLI_MI.VisibleIndex = 0;
        //    colTERDITLI_MI.FieldName = "TERDITLI_MI";
        //    colTERDITLI_MI.Name = "colTERDITLI_MI";
        //    colTERDITLI_MI.Visible = true;

        //    GridColumn colDAVA_NEDEN_TIP = new GridColumn();
        //    colDAVA_NEDEN_TIP.VisibleIndex = 1;
        //    colDAVA_NEDEN_TIP.FieldName = "DAVA_NEDEN_TIP";
        //    colDAVA_NEDEN_TIP.Name = "colDAVA_NEDEN_TIP";
        //    colDAVA_NEDEN_TIP.Visible = true;

        //    GridColumn colDAVA_ADI = new GridColumn();
        //    colDAVA_ADI.VisibleIndex = 2;
        //    colDAVA_ADI.FieldName = "DAVA_ADI";
        //    colDAVA_ADI.Name = "colDAVA_ADI";
        //    colDAVA_ADI.Visible = true;

        //    GridColumn colDIGER_DAVA_NEDEN = new GridColumn();
        //    colDIGER_DAVA_NEDEN.VisibleIndex = 3;
        //    colDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
        //    colDIGER_DAVA_NEDEN.Name = "colDIGER_DAVA_NEDEN";
        //    colDIGER_DAVA_NEDEN.Visible = true;

        //    GridColumn colDAVA_NEDEN_MAHKEME = new GridColumn();
        //    colDAVA_NEDEN_MAHKEME.VisibleIndex = 4;
        //    colDAVA_NEDEN_MAHKEME.FieldName = "DAVA_NEDEN_MAHKEME";
        //    colDAVA_NEDEN_MAHKEME.Name = "colDAVA_NEDEN_MAHKEME";
        //    colDAVA_NEDEN_MAHKEME.Visible = true;

        //    GridColumn colOLAY_SUC_TARIHI = new GridColumn();
        //    colOLAY_SUC_TARIHI.VisibleIndex = 5;
        //    colOLAY_SUC_TARIHI.FieldName = "OLAY_SUC_TARIHI";
        //    colOLAY_SUC_TARIHI.Name = "colOLAY_SUC_TARIHI";
        //    colOLAY_SUC_TARIHI.Visible = true;

        //    GridColumn colDUZENLEME_TARIHI = new GridColumn();
        //    colDUZENLEME_TARIHI.VisibleIndex = 6;
        //    colDUZENLEME_TARIHI.FieldName = "DUZENLEME_TARIHI";
        //    colDUZENLEME_TARIHI.Name = "colDUZENLEME_TARIHI";
        //    colDUZENLEME_TARIHI.Visible = true;

        //    GridColumn colTEBELLUG_TARIHI = new GridColumn();
        //    colTEBELLUG_TARIHI.VisibleIndex = 7;
        //    colTEBELLUG_TARIHI.FieldName = "TEBELLUG_TARIHI";
        //    colTEBELLUG_TARIHI.Name = "colTEBELLUG_TARIHI";
        //    colTEBELLUG_TARIHI.Visible = true;

        //    GridColumn colFAIZ_TALEP_TARIHI = new GridColumn();
        //    colFAIZ_TALEP_TARIHI.VisibleIndex = 8;
        //    colFAIZ_TALEP_TARIHI.FieldName = "FAIZ_TALEP_TARIHI";
        //    colFAIZ_TALEP_TARIHI.Name = "colFAIZ_TALEP_TARIHI";
        //    colFAIZ_TALEP_TARIHI.Visible = true;

        //    GridColumn colFAIZ_KARAR_TARIHI = new GridColumn();
        //    colFAIZ_KARAR_TARIHI.VisibleIndex = 9;
        //    colFAIZ_KARAR_TARIHI.FieldName = "FAIZ_KARAR_TARIHI";
        //    colFAIZ_KARAR_TARIHI.Name = "colFAIZ_KARAR_TARIHI";
        //    colFAIZ_KARAR_TARIHI.Visible = true;

        //    GridColumn colTEDBIR_TARIHI = new GridColumn();
        //    colTEDBIR_TARIHI.VisibleIndex = 10;
        //    colTEDBIR_TARIHI.FieldName = "TEDBIR_TARIHI";
        //    colTEDBIR_TARIHI.Name = "colTEDBIR_TARIHI";
        //    colTEDBIR_TARIHI.Visible = true;

        //    GridColumn colTEDBIR_KALDIRILMA_TARIHI = new GridColumn();
        //    colTEDBIR_KALDIRILMA_TARIHI.VisibleIndex = 11;
        //    colTEDBIR_KALDIRILMA_TARIHI.FieldName = "TEDBIR_KALDIRILMA_TARIHI";
        //    colTEDBIR_KALDIRILMA_TARIHI.Name = "colTEDBIR_KALDIRILMA_TARIHI";
        //    colTEDBIR_KALDIRILMA_TARIHI.Visible = true;

        //    GridColumn colTEDBIR_TALEP_TARIHI = new GridColumn();
        //    colTEDBIR_TALEP_TARIHI.VisibleIndex = 12;
        //    colTEDBIR_TALEP_TARIHI.FieldName = "TEDBIR_TALEP_TARIHI";
        //    colTEDBIR_TALEP_TARIHI.Name = "colTEDBIR_TALEP_TARIHI";
        //    colTEDBIR_TALEP_TARIHI.Visible = true;

        //    GridColumn colDOVIZ_ISLEM_TIPI = new GridColumn();
        //    colDOVIZ_ISLEM_TIPI.VisibleIndex = 13;
        //    colDOVIZ_ISLEM_TIPI.FieldName = "DOVIZ_ISLEM_TIPI";
        //    colDOVIZ_ISLEM_TIPI.Name = "colDOVIZ_ISLEM_TIPI";
        //    colDOVIZ_ISLEM_TIPI.Visible = true;

        //    GridColumn colSABIT_FAIZ_UYGULA = new GridColumn();
        //    colSABIT_FAIZ_UYGULA.VisibleIndex = 14;
        //    colSABIT_FAIZ_UYGULA.FieldName = "SABIT_FAIZ_UYGULA";
        //    colSABIT_FAIZ_UYGULA.Name = "colSABIT_FAIZ_UYGULA";
        //    colSABIT_FAIZ_UYGULA.Visible = true;

        //    GridColumn colDO_FAIZ_TIP = new GridColumn();
        //    colDO_FAIZ_TIP.VisibleIndex = 15;
        //    colDO_FAIZ_TIP.FieldName = "DO_FAIZ_TIP";
        //    colDO_FAIZ_TIP.Name = "colDO_FAIZ_TIP";
        //    colDO_FAIZ_TIP.Visible = true;

        //    GridColumn colDO_FAIZ_ORANI = new GridColumn();
        //    colDO_FAIZ_ORANI.VisibleIndex = 16;
        //    colDO_FAIZ_ORANI.FieldName = "DO_FAIZ_ORANI";
        //    colDO_FAIZ_ORANI.Name = "colDO_FAIZ_ORANI";
        //    colDO_FAIZ_ORANI.Visible = true;

        //    GridColumn colDN_FAIZ_TIP = new GridColumn();
        //    colDN_FAIZ_TIP.VisibleIndex = 17;
        //    colDN_FAIZ_TIP.FieldName = "DN_FAIZ_TIP";
        //    colDN_FAIZ_TIP.Name = "colDN_FAIZ_TIP";
        //    colDN_FAIZ_TIP.Visible = true;

        //    GridColumn colDAVA_NEDEN_FAIZ_ORANI = new GridColumn();
        //    colDAVA_NEDEN_FAIZ_ORANI.VisibleIndex = 18;
        //    colDAVA_NEDEN_FAIZ_ORANI.FieldName = "DAVA_NEDEN_FAIZ_ORANI";
        //    colDAVA_NEDEN_FAIZ_ORANI.Name = "colDAVA_NEDEN_FAIZ_ORANI";
        //    colDAVA_NEDEN_FAIZ_ORANI.Visible = true;

        //    GridColumn colDAVA_N_TUTAR = new GridColumn();
        //    colDAVA_N_TUTAR.VisibleIndex = 19;
        //    colDAVA_N_TUTAR.FieldName = "DAVA_N_TUTAR";
        //    colDAVA_N_TUTAR.Name = "colDAVA_N_TUTAR";
        //    colDAVA_N_TUTAR.Visible = true;

        //    GridColumn colTUTAR_DOVIZ_ID = new GridColumn();
        //    colTUTAR_DOVIZ_ID.VisibleIndex = 20;
        //    colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
        //    colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
        //    colTUTAR_DOVIZ_ID.Visible = true;

        //    GridColumn colDAVA_EDILEN_TUTAR = new GridColumn();
        //    colDAVA_EDILEN_TUTAR.VisibleIndex = 21;
        //    colDAVA_EDILEN_TUTAR.FieldName = "DAVA_EDILEN_TUTAR";
        //    colDAVA_EDILEN_TUTAR.Name = "colDAVA_EDILEN_TUTAR";
        //    colDAVA_EDILEN_TUTAR.Visible = true;

        //    GridColumn colDAVA_EDILEN_TUTAR_DOVIZ_ID = new GridColumn();
        //    colDAVA_EDILEN_TUTAR_DOVIZ_ID.VisibleIndex = 22;
        //    colDAVA_EDILEN_TUTAR_DOVIZ_ID.FieldName = "DAVA_EDILEN_TUTAR_DOVIZ_ID";
        //    colDAVA_EDILEN_TUTAR_DOVIZ_ID.Name = "colDAVA_EDILEN_TUTAR_DOVIZ_ID";
        //    colDAVA_EDILEN_TUTAR_DOVIZ_ID.Visible = true;

        //    GridColumn colISLAH_EDILMIS = new GridColumn();
        //    colISLAH_EDILMIS.VisibleIndex = 23;
        //    colISLAH_EDILMIS.FieldName = "ISLAH_EDILMIS";
        //    colISLAH_EDILMIS.Name = "colISLAH_EDILMIS";
        //    colISLAH_EDILMIS.Visible = true;

        //    GridColumn colISLAH_TARIHI = new GridColumn();
        //    colISLAH_TARIHI.VisibleIndex = 24;
        //    colISLAH_TARIHI.FieldName = "ISLAH_TARIHI";
        //    colISLAH_TARIHI.Name = "colISLAH_TARIHI";
        //    colISLAH_TARIHI.Visible = true;

        //    GridColumn colISLAH_EDILEN_TUTAR = new GridColumn();
        //    colISLAH_EDILEN_TUTAR.VisibleIndex = 25;
        //    colISLAH_EDILEN_TUTAR.FieldName = "ISLAH_EDILEN_TUTAR";
        //    colISLAH_EDILEN_TUTAR.Name = "colISLAH_EDILEN_TUTAR";
        //    colISLAH_EDILEN_TUTAR.Visible = true;

        //    GridColumn colISLAH_EDILEN_TUTAR_DOVIZ_ID = new GridColumn();
        //    colISLAH_EDILEN_TUTAR_DOVIZ_ID.VisibleIndex = 26;
        //    colISLAH_EDILEN_TUTAR_DOVIZ_ID.FieldName = "ISLAH_EDILEN_TUTAR_DOVIZ_ID";
        //    colISLAH_EDILEN_TUTAR_DOVIZ_ID.Name = "colISLAH_EDILEN_TUTAR_DOVIZ_ID";
        //    colISLAH_EDILEN_TUTAR_DOVIZ_ID.Visible = true;

        //    GridColumn colPROTESTO_GIDERI = new GridColumn();
        //    colPROTESTO_GIDERI.VisibleIndex = 27;
        //    colPROTESTO_GIDERI.FieldName = "PROTESTO_GIDERI";
        //    colPROTESTO_GIDERI.Name = "colPROTESTO_GIDERI";
        //    colPROTESTO_GIDERI.Visible = true;

        //    GridColumn colPROTESTO_GIDERI_DOVIZ_ID = new GridColumn();
        //    colPROTESTO_GIDERI_DOVIZ_ID.VisibleIndex = 28;
        //    colPROTESTO_GIDERI_DOVIZ_ID.FieldName = "PROTESTO_GIDERI_DOVIZ_ID";
        //    colPROTESTO_GIDERI_DOVIZ_ID.Name = "colPROTESTO_GIDERI_DOVIZ_ID";
        //    colPROTESTO_GIDERI_DOVIZ_ID.Visible = true;

        //    GridColumn colIHTAR_GIDERI = new GridColumn();
        //    colIHTAR_GIDERI.VisibleIndex = 29;
        //    colIHTAR_GIDERI.FieldName = "IHTAR_GIDERI";
        //    colIHTAR_GIDERI.Name = "colIHTAR_GIDERI";
        //    colIHTAR_GIDERI.Visible = true;

        //    GridColumn colIHTAR_GIDERI_DOVIZ_ID = new GridColumn();
        //    colIHTAR_GIDERI_DOVIZ_ID.VisibleIndex = 30;
        //    colIHTAR_GIDERI_DOVIZ_ID.FieldName = "IHTAR_GIDERI_DOVIZ_ID";
        //    colIHTAR_GIDERI_DOVIZ_ID.Name = "colIHTAR_GIDERI_DOVIZ_ID";
        //    colIHTAR_GIDERI_DOVIZ_ID.Visible = true;

        //    GridColumn colDAVA_N_DIGER_GIDER = new GridColumn();
        //    colDAVA_N_DIGER_GIDER.VisibleIndex = 31;
        //    colDAVA_N_DIGER_GIDER.FieldName = "DAVA_N_DIGER_GIDER";
        //    colDAVA_N_DIGER_GIDER.Name = "colDAVA_N_DIGER_GIDER";
        //    colDAVA_N_DIGER_GIDER.Visible = true;

        //    GridColumn colDIGER_GIDER_DOVIZ_ID = new GridColumn();
        //    colDIGER_GIDER_DOVIZ_ID.VisibleIndex = 32;
        //    colDIGER_GIDER_DOVIZ_ID.FieldName = "DIGER_GIDER_DOVIZ_ID";
        //    colDIGER_GIDER_DOVIZ_ID.Name = "colDIGER_GIDER_DOVIZ_ID";
        //    colDIGER_GIDER_DOVIZ_ID.Visible = true;

        //    GridColumn colDAVA_NEDEN_SURE_GUN = new GridColumn();
        //    colDAVA_NEDEN_SURE_GUN.VisibleIndex = 33;
        //    colDAVA_NEDEN_SURE_GUN.FieldName = "DAVA_NEDEN_SURE_GUN";
        //    colDAVA_NEDEN_SURE_GUN.Name = "colDAVA_NEDEN_SURE_GUN";
        //    colDAVA_NEDEN_SURE_GUN.Visible = true;

        //    GridColumn colDAVA_NEDEN_SURE_AY = new GridColumn();
        //    colDAVA_NEDEN_SURE_AY.VisibleIndex = 34;
        //    colDAVA_NEDEN_SURE_AY.FieldName = "DAVA_NEDEN_SURE_AY";
        //    colDAVA_NEDEN_SURE_AY.Name = "colDAVA_NEDEN_SURE_AY";
        //    colDAVA_NEDEN_SURE_AY.Visible = true;

        //    GridColumn colDAVA_NEDEN_SURE_YIL = new GridColumn();
        //    colDAVA_NEDEN_SURE_YIL.VisibleIndex = 35;
        //    colDAVA_NEDEN_SURE_YIL.FieldName = "DAVA_NEDEN_SURE_YIL";
        //    colDAVA_NEDEN_SURE_YIL.Name = "colDAVA_NEDEN_SURE_YIL";
        //    colDAVA_NEDEN_SURE_YIL.Visible = true;

        //    GridColumn colDAVA_NEDEN_REFERANS_NO1 = new GridColumn();
        //    colDAVA_NEDEN_REFERANS_NO1.VisibleIndex = 36;
        //    colDAVA_NEDEN_REFERANS_NO1.FieldName = "DAVA_NEDEN_REFERANS_NO1";
        //    colDAVA_NEDEN_REFERANS_NO1.Name = "colDAVA_NEDEN_REFERANS_NO1";
        //    colDAVA_NEDEN_REFERANS_NO1.Visible = true;

        //    GridColumn colDAVA_NEDEN_REFERANS_NO2 = new GridColumn();
        //    colDAVA_NEDEN_REFERANS_NO2.VisibleIndex = 37;
        //    colDAVA_NEDEN_REFERANS_NO2.FieldName = "DAVA_NEDEN_REFERANS_NO2";
        //    colDAVA_NEDEN_REFERANS_NO2.Name = "colDAVA_NEDEN_REFERANS_NO2";
        //    colDAVA_NEDEN_REFERANS_NO2.Visible = true;

        //    GridColumn colVERGI_DONEMI = new GridColumn();
        //    colVERGI_DONEMI.VisibleIndex = 38;
        //    colVERGI_DONEMI.FieldName = "VERGI_DONEMI";
        //    colVERGI_DONEMI.Name = "colVERGI_DONEMI";
        //    colVERGI_DONEMI.Visible = true;

        //    GridColumn colFAIZ_YOK = new GridColumn();
        //    colFAIZ_YOK.VisibleIndex = 39;
        //    colFAIZ_YOK.FieldName = "FAIZ_YOK";
        //    colFAIZ_YOK.Name = "colFAIZ_YOK";
        //    colFAIZ_YOK.Visible = true;

        //    GridColumn colSIFAT = new GridColumn();
        //    colSIFAT.VisibleIndex = 40;
        //    colSIFAT.FieldName = "SIFAT";
        //    colSIFAT.Name = "colSIFAT";
        //    colSIFAT.Visible = true;

        //    GridColumn colTARAF_ADI = new GridColumn();
        //    colTARAF_ADI.VisibleIndex = 41;
        //    colTARAF_ADI.FieldName = "TARAF_ADI";
        //    colTARAF_ADI.Name = "colTARAF_ADI";
        //    colTARAF_ADI.Visible = true;

        //    GridColumn colKESINLESME_TARIHI = new GridColumn();
        //    colKESINLESME_TARIHI.VisibleIndex = 42;
        //    colKESINLESME_TARIHI.FieldName = "KESINLESME_TARIHI";
        //    colKESINLESME_TARIHI.Name = "colKESINLESME_TARIHI";
        //    colKESINLESME_TARIHI.Visible = true;

        //    GridColumn colSULH_TARIHI = new GridColumn();
        //    colSULH_TARIHI.VisibleIndex = 43;
        //    colSULH_TARIHI.FieldName = "SULH_TARIHI";
        //    colSULH_TARIHI.Name = "colSULH_TARIHI";
        //    colSULH_TARIHI.Visible = true;

        //    GridColumn colKABUL_TARIHI = new GridColumn();
        //    colKABUL_TARIHI.VisibleIndex = 44;
        //    colKABUL_TARIHI.FieldName = "KABUL_TARIHI";
        //    colKABUL_TARIHI.Name = "colKABUL_TARIHI";
        //    colKABUL_TARIHI.Visible = true;

        //    GridColumn colATIYE_BIRAKMA_TARIHI = new GridColumn();
        //    colATIYE_BIRAKMA_TARIHI.VisibleIndex = 45;
        //    colATIYE_BIRAKMA_TARIHI.FieldName = "ATIYE_BIRAKMA_TARIHI";
        //    colATIYE_BIRAKMA_TARIHI.Name = "colATIYE_BIRAKMA_TARIHI";
        //    colATIYE_BIRAKMA_TARIHI.Visible = true;

        //    GridColumn colVAZGECME_TARIHI = new GridColumn();
        //    colVAZGECME_TARIHI.VisibleIndex = 46;
        //    colVAZGECME_TARIHI.FieldName = "VAZGECME_TARIHI";
        //    colVAZGECME_TARIHI.Name = "colVAZGECME_TARIHI";
        //    colVAZGECME_TARIHI.Visible = true;

        //    GridColumn colIKRAR_TARIHI = new GridColumn();
        //    colIKRAR_TARIHI.VisibleIndex = 47;
        //    colIKRAR_TARIHI.FieldName = "IKRAR_TARIHI";
        //    colIKRAR_TARIHI.Name = "colIKRAR_TARIHI";
        //    colIKRAR_TARIHI.Visible = true;

        //    GridColumn colGERI_ALMA_TARIHI = new GridColumn();
        //    colGERI_ALMA_TARIHI.VisibleIndex = 48;
        //    colGERI_ALMA_TARIHI.FieldName = "GERI_ALMA_TARIHI";
        //    colGERI_ALMA_TARIHI.Name = "colGERI_ALMA_TARIHI";
        //    colGERI_ALMA_TARIHI.Visible = true;

        //    GridColumn colASLI_MUDEHALE_TARIHI = new GridColumn();
        //    colASLI_MUDEHALE_TARIHI.VisibleIndex = 49;
        //    colASLI_MUDEHALE_TARIHI.FieldName = "ASLI_MUDEHALE_TARIHI";
        //    colASLI_MUDEHALE_TARIHI.Name = "colASLI_MUDEHALE_TARIHI";
        //    colASLI_MUDEHALE_TARIHI.Visible = true;

        //    GridColumn colFERI_MUDEHALE_TARIHI = new GridColumn();
        //    colFERI_MUDEHALE_TARIHI.VisibleIndex = 50;
        //    colFERI_MUDEHALE_TARIHI.FieldName = "FERI_MUDEHALE_TARIHI";
        //    colFERI_MUDEHALE_TARIHI.Name = "colFERI_MUDEHALE_TARIHI";
        //    colFERI_MUDEHALE_TARIHI.Visible = true;

        //    GridColumn colYETKIYE_ITIRAZ_TARIHI = new GridColumn();
        //    colYETKIYE_ITIRAZ_TARIHI.VisibleIndex = 51;
        //    colYETKIYE_ITIRAZ_TARIHI.FieldName = "YETKIYE_ITIRAZ_TARIHI";
        //    colYETKIYE_ITIRAZ_TARIHI.Name = "colYETKIYE_ITIRAZ_TARIHI";
        //    colYETKIYE_ITIRAZ_TARIHI.Visible = true;

        //    GridColumn colGOREVE_ITIRAZ_TARIHI = new GridColumn();
        //    colGOREVE_ITIRAZ_TARIHI.VisibleIndex = 52;
        //    colGOREVE_ITIRAZ_TARIHI.FieldName = "GOREVE_ITIRAZ_TARIHI";
        //    colGOREVE_ITIRAZ_TARIHI.Name = "colGOREVE_ITIRAZ_TARIHI";
        //    colGOREVE_ITIRAZ_TARIHI.Visible = true;

        //    GridColumn colTAKIGAT_TARIHI = new GridColumn();
        //    colTAKIGAT_TARIHI.VisibleIndex = 53;
        //    colTAKIGAT_TARIHI.FieldName = "TAKIGAT_TARIHI";
        //    colTAKIGAT_TARIHI.Name = "colTAKIGAT_TARIHI";
        //    colTAKIGAT_TARIHI.Visible = true;

        //    GridColumn colESAS_BEYAN_TARIHI = new GridColumn();
        //    colESAS_BEYAN_TARIHI.VisibleIndex = 54;
        //    colESAS_BEYAN_TARIHI.FieldName = "ESAS_BEYAN_TARIHI";
        //    colESAS_BEYAN_TARIHI.Name = "colESAS_BEYAN_TARIHI";
        //    colESAS_BEYAN_TARIHI.Visible = true;

        //    GridColumn colEK_SAVUNMA_TARIHI = new GridColumn();
        //    colEK_SAVUNMA_TARIHI.VisibleIndex = 55;
        //    colEK_SAVUNMA_TARIHI.FieldName = "EK_SAVUNMA_TARIHI";
        //    colEK_SAVUNMA_TARIHI.Name = "colEK_SAVUNMA_TARIHI";
        //    colEK_SAVUNMA_TARIHI.Visible = true;

        //    GridColumn colMUDAHALE_TARIHI = new GridColumn();
        //    colMUDAHALE_TARIHI.VisibleIndex = 56;
        //    colMUDAHALE_TARIHI.FieldName = "MUDAHALE_TARIHI";
        //    colMUDAHALE_TARIHI.Name = "colMUDAHALE_TARIHI";
        //    colMUDAHALE_TARIHI.Visible = true;

        //    GridColumn colSON_SAVUNMA_TARIHI = new GridColumn();
        //    colSON_SAVUNMA_TARIHI.VisibleIndex = 57;
        //    colSON_SAVUNMA_TARIHI.FieldName = "SON_SAVUNMA_TARIHI";
        //    colSON_SAVUNMA_TARIHI.Name = "colSON_SAVUNMA_TARIHI";
        //    colSON_SAVUNMA_TARIHI.Visible = true;

        //    GridColumn colSAVUNMA_TARIHI = new GridColumn();
        //    colSAVUNMA_TARIHI.VisibleIndex = 58;
        //    colSAVUNMA_TARIHI.FieldName = "SAVUNMA_TARIHI";
        //    colSAVUNMA_TARIHI.Name = "colSAVUNMA_TARIHI";
        //    colSAVUNMA_TARIHI.Visible = true;

        //    GridColumn colMUTALAA_TARIHI = new GridColumn();
        //    colMUTALAA_TARIHI.VisibleIndex = 59;
        //    colMUTALAA_TARIHI.FieldName = "MUTALAA_TARIHI";
        //    colMUTALAA_TARIHI.Name = "colMUTALAA_TARIHI";
        //    colMUTALAA_TARIHI.Visible = true;

        //    GridColumn colIDDIANAME_OKUNMA_TARIHI = new GridColumn();
        //    colIDDIANAME_OKUNMA_TARIHI.VisibleIndex = 60;
        //    colIDDIANAME_OKUNMA_TARIHI.FieldName = "IDDIANAME_OKUNMA_TARIHI";
        //    colIDDIANAME_OKUNMA_TARIHI.Name = "colIDDIANAME_OKUNMA_TARIHI";
        //    colIDDIANAME_OKUNMA_TARIHI.Visible = true;

        //    GridColumn colZAMAN_ASIMI_TARIHI = new GridColumn();
        //    colZAMAN_ASIMI_TARIHI.VisibleIndex = 61;
        //    colZAMAN_ASIMI_TARIHI.FieldName = "ZAMAN_ASIMI_TARIHI";
        //    colZAMAN_ASIMI_TARIHI.Name = "colZAMAN_ASIMI_TARIHI";
        //    colZAMAN_ASIMI_TARIHI.Visible = true;

        //    GridColumn colOGRENME_TARIHI = new GridColumn();
        //    colOGRENME_TARIHI.VisibleIndex = 62;
        //    colOGRENME_TARIHI.FieldName = "OGRENME_TARIHI";
        //    colOGRENME_TARIHI.Name = "colOGRENME_TARIHI";
        //    colOGRENME_TARIHI.Visible = true;

        //    GridColumn colSORUMLU_OLUNAN_MIKTAR = new GridColumn();
        //    colSORUMLU_OLUNAN_MIKTAR.VisibleIndex = 63;
        //    colSORUMLU_OLUNAN_MIKTAR.FieldName = "SORUMLU_OLUNAN_MIKTAR";
        //    colSORUMLU_OLUNAN_MIKTAR.Name = "colSORUMLU_OLUNAN_MIKTAR";
        //    colSORUMLU_OLUNAN_MIKTAR.Visible = true;

        //    GridColumn colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = new GridColumn();
        //    colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.VisibleIndex = 64;
        //    colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.FieldName = "SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
        //    colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Name = "colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID";
        //    colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID.Visible = true;

        //    GridColumn colSURE_TUTUM_TARIHI = new GridColumn();
        //    colSURE_TUTUM_TARIHI.VisibleIndex = 65;
        //    colSURE_TUTUM_TARIHI.FieldName = "SURE_TUTUM_TARIHI";
        //    colSURE_TUTUM_TARIHI.Name = "colSURE_TUTUM_TARIHI";
        //    colSURE_TUTUM_TARIHI.Visible = true;

        //    GridColumn colDURUSMA_TALEP_TARIHI = new GridColumn();
        //    colDURUSMA_TALEP_TARIHI.VisibleIndex = 66;
        //    colDURUSMA_TALEP_TARIHI.FieldName = "DURUSMA_TALEP_TARIHI";
        //    colDURUSMA_TALEP_TARIHI.Name = "colDURUSMA_TALEP_TARIHI";
        //    colDURUSMA_TALEP_TARIHI.Visible = true;

        //    GridColumn colKESIF_TALEP_TARIHI = new GridColumn();
        //    colKESIF_TALEP_TARIHI.VisibleIndex = 67;
        //    colKESIF_TALEP_TARIHI.FieldName = "KESIF_TALEP_TARIHI";
        //    colKESIF_TALEP_TARIHI.Name = "colKESIF_TALEP_TARIHI";
        //    colKESIF_TALEP_TARIHI.Visible = true;

        //    GridColumn colGERI_BASVURMA_TARIHI = new GridColumn();
        //    colGERI_BASVURMA_TARIHI.VisibleIndex = 68;
        //    colGERI_BASVURMA_TARIHI.FieldName = "GERI_BASVURMA_TARIHI";
        //    colGERI_BASVURMA_TARIHI.Name = "colGERI_BASVURMA_TARIHI";
        //    colGERI_BASVURMA_TARIHI.Visible = true;

        //    GridColumn colYURUTME_DURDURMA_TALEP_TARIHI = new GridColumn();
        //    colYURUTME_DURDURMA_TALEP_TARIHI.VisibleIndex = 69;
        //    colYURUTME_DURDURMA_TALEP_TARIHI.FieldName = "YURUTME_DURDURMA_TALEP_TARIHI";
        //    colYURUTME_DURDURMA_TALEP_TARIHI.Name = "colYURUTME_DURDURMA_TALEP_TARIHI";
        //    colYURUTME_DURDURMA_TALEP_TARIHI.Visible = true;

        //    GridColumn colYURUTME_DURDURMA_TARIHI = new GridColumn();
        //    colYURUTME_DURDURMA_TARIHI.VisibleIndex = 70;
        //    colYURUTME_DURDURMA_TARIHI.FieldName = "YURUTME_DURDURMA_TARIHI";
        //    colYURUTME_DURDURMA_TARIHI.Name = "colYURUTME_DURDURMA_TARIHI";
        //    colYURUTME_DURDURMA_TARIHI.Visible = true;

        //    GridColumn colYURUTME_DURDURMA_KALDIRILMA_TARIHI = new GridColumn();
        //    colYURUTME_DURDURMA_KALDIRILMA_TARIHI.VisibleIndex = 71;
        //    colYURUTME_DURDURMA_KALDIRILMA_TARIHI.FieldName = "YURUTME_DURDURMA_KALDIRILMA_TARIHI";
        //    colYURUTME_DURDURMA_KALDIRILMA_TARIHI.Name = "colYURUTME_DURDURMA_KALDIRILMA_TARIHI";
        //    colYURUTME_DURDURMA_KALDIRILMA_TARIHI.Visible = true;

        //    GridColumn colIHBAR_TARIHI = new GridColumn();
        //    colIHBAR_TARIHI.VisibleIndex = 72;
        //    colIHBAR_TARIHI.FieldName = "IHBAR_TARIHI";
        //    colIHBAR_TARIHI.Name = "colIHBAR_TARIHI";
        //    colIHBAR_TARIHI.Visible = true;

        //    GridColumn colTARAF = new GridColumn();
        //    colTARAF.VisibleIndex = 73;
        //    colTARAF.FieldName = "TARAF";
        //    colTARAF.Name = "colTARAF";
        //    colTARAF.Visible = true;

        //    GridColumn colIHTAR_TARIHI = new GridColumn();
        //    colIHTAR_TARIHI.VisibleIndex = 74;
        //    colIHTAR_TARIHI.FieldName = "IHTAR_TARIHI";
        //    colIHTAR_TARIHI.Name = "colIHTAR_TARIHI";
        //    colIHTAR_TARIHI.Visible = true;

        //    GridColumn colIHTAR_TEBLIG_TARIHI = new GridColumn();
        //    colIHTAR_TEBLIG_TARIHI.VisibleIndex = 75;
        //    colIHTAR_TEBLIG_TARIHI.FieldName = "IHTAR_TEBLIG_TARIHI";
        //    colIHTAR_TEBLIG_TARIHI.Name = "colIHTAR_TEBLIG_TARIHI";
        //    colIHTAR_TEBLIG_TARIHI.Visible = true;

        //    GridColumn colIHTAR_TEMERRUT_TARIHI = new GridColumn();
        //    colIHTAR_TEMERRUT_TARIHI.VisibleIndex = 76;
        //    colIHTAR_TEMERRUT_TARIHI.FieldName = "IHTAR_TEMERRUT_TARIHI";
        //    colIHTAR_TEMERRUT_TARIHI.Name = "colIHTAR_TEMERRUT_TARIHI";
        //    colIHTAR_TEMERRUT_TARIHI.Visible = true;

        //    GridColumn colZAMANASIMI_IDDIA_TARIHI = new GridColumn();
        //    colZAMANASIMI_IDDIA_TARIHI.VisibleIndex = 77;
        //    colZAMANASIMI_IDDIA_TARIHI.FieldName = "ZAMANASIMI_IDDIA_TARIHI";
        //    colZAMANASIMI_IDDIA_TARIHI.Name = "colZAMANASIMI_IDDIA_TARIHI";
        //    colZAMANASIMI_IDDIA_TARIHI.Visible = true;

        //    GridColumn colIHBAR_TEBLIG_TARIHI = new GridColumn();
        //    colIHBAR_TEBLIG_TARIHI.VisibleIndex = 78;
        //    colIHBAR_TEBLIG_TARIHI.FieldName = "IHBAR_TEBLIG_TARIHI";
        //    colIHBAR_TEBLIG_TARIHI.Name = "colIHBAR_TEBLIG_TARIHI";
        //    colIHBAR_TEBLIG_TARIHI.Visible = true;

        //    GridColumn colMAHKEMEDE_UZLASMA_TARIHI = new GridColumn();
        //    colMAHKEMEDE_UZLASMA_TARIHI.VisibleIndex = 79;
        //    colMAHKEMEDE_UZLASMA_TARIHI.FieldName = "MAHKEMEDE_UZLASMA_TARIHI";
        //    colMAHKEMEDE_UZLASMA_TARIHI.Name = "colMAHKEMEDE_UZLASMA_TARIHI";
        //    colMAHKEMEDE_UZLASMA_TARIHI.Visible = true;

        //    GridColumn colHUKUM_TARIHI = new GridColumn();
        //    colHUKUM_TARIHI.VisibleIndex = 80;
        //    colHUKUM_TARIHI.FieldName = "HUKUM_TARIHI";
        //    colHUKUM_TARIHI.Name = "colHUKUM_TARIHI";
        //    colHUKUM_TARIHI.Visible = true;

        //    GridColumn colKARAR_NO = new GridColumn();
        //    colKARAR_NO.VisibleIndex = 81;
        //    colKARAR_NO.FieldName = "KARAR_NO";
        //    colKARAR_NO.Name = "colKARAR_NO";
        //    colKARAR_NO.Visible = true;

        //    GridColumn colHUKUM = new GridColumn();
        //    colHUKUM.VisibleIndex = 82;
        //    colHUKUM.FieldName = "HUKUM";
        //    colHUKUM.Name = "colHUKUM";
        //    colHUKUM.Visible = true;

        //    GridColumn colHUKUM_TIP = new GridColumn();
        //    colHUKUM_TIP.VisibleIndex = 83;
        //    colHUKUM_TIP.FieldName = "HUKUM_TIP";
        //    colHUKUM_TIP.Name = "colHUKUM_TIP";
        //    colHUKUM_TIP.Visible = true;

        //    GridColumn colHUKUM_GEREKCE = new GridColumn();
        //    colHUKUM_GEREKCE.VisibleIndex = 84;
        //    colHUKUM_GEREKCE.FieldName = "HUKUM_GEREKCE";
        //    colHUKUM_GEREKCE.Name = "colHUKUM_GEREKCE";
        //    colHUKUM_GEREKCE.Visible = true;

        //    GridColumn colHUKUM_DEGER = new GridColumn();
        //    colHUKUM_DEGER.VisibleIndex = 85;
        //    colHUKUM_DEGER.FieldName = "HUKUM_DEGER";
        //    colHUKUM_DEGER.Name = "colHUKUM_DEGER";
        //    colHUKUM_DEGER.Visible = true;

        //    GridColumn colHUKUM_DEGER_DOVIZ_ID = new GridColumn();
        //    colHUKUM_DEGER_DOVIZ_ID.VisibleIndex = 86;
        //    colHUKUM_DEGER_DOVIZ_ID.FieldName = "HUKUM_DEGER_DOVIZ_ID";
        //    colHUKUM_DEGER_DOVIZ_ID.Name = "colHUKUM_DEGER_DOVIZ_ID";
        //    colHUKUM_DEGER_DOVIZ_ID.Visible = true;

        //    GridColumn colMUSADERE_DEGER = new GridColumn();
        //    colMUSADERE_DEGER.VisibleIndex = 87;
        //    colMUSADERE_DEGER.FieldName = "MUSADERE_DEGER";
        //    colMUSADERE_DEGER.Name = "colMUSADERE_DEGER";
        //    colMUSADERE_DEGER.Visible = true;

        //    GridColumn colMUSADERE_DEGER_DOVIZ_ID = new GridColumn();
        //    colMUSADERE_DEGER_DOVIZ_ID.VisibleIndex = 88;
        //    colMUSADERE_DEGER_DOVIZ_ID.FieldName = "MUSADERE_DEGER_DOVIZ_ID";
        //    colMUSADERE_DEGER_DOVIZ_ID.Name = "colMUSADERE_DEGER_DOVIZ_ID";
        //    colMUSADERE_DEGER_DOVIZ_ID.Visible = true;

        //    GridColumn colMAHKUMIYET_YIL = new GridColumn();
        //    colMAHKUMIYET_YIL.VisibleIndex = 89;
        //    colMAHKUMIYET_YIL.FieldName = "MAHKUMIYET_YIL";
        //    colMAHKUMIYET_YIL.Name = "colMAHKUMIYET_YIL";
        //    colMAHKUMIYET_YIL.Visible = true;

        //    GridColumn colMAHKUMIYET_AY = new GridColumn();
        //    colMAHKUMIYET_AY.VisibleIndex = 90;
        //    colMAHKUMIYET_AY.FieldName = "MAHKUMIYET_AY";
        //    colMAHKUMIYET_AY.Name = "colMAHKUMIYET_AY";
        //    colMAHKUMIYET_AY.Visible = true;

        //    GridColumn colMAHKUMIYET_GUN = new GridColumn();
        //    colMAHKUMIYET_GUN.VisibleIndex = 91;
        //    colMAHKUMIYET_GUN.FieldName = "MAHKUMIYET_GUN";
        //    colMAHKUMIYET_GUN.Name = "colMAHKUMIYET_GUN";
        //    colMAHKUMIYET_GUN.Visible = true;

        //    GridColumn colCEZA_ERTELENDI = new GridColumn();
        //    colCEZA_ERTELENDI.VisibleIndex = 92;
        //    colCEZA_ERTELENDI.FieldName = "CEZA_ERTELENDI";
        //    colCEZA_ERTELENDI.Name = "colCEZA_ERTELENDI";
        //    colCEZA_ERTELENDI.Visible = true;

        //    GridColumn colPARAYA_CEVRILDI = new GridColumn();
        //    colPARAYA_CEVRILDI.VisibleIndex = 93;
        //    colPARAYA_CEVRILDI.FieldName = "PARAYA_CEVRILDI";
        //    colPARAYA_CEVRILDI.Name = "colPARAYA_CEVRILDI";
        //    colPARAYA_CEVRILDI.Visible = true;

        //    GridColumn colPARAYA_CEVRILEN_MIKTAR = new GridColumn();
        //    colPARAYA_CEVRILEN_MIKTAR.VisibleIndex = 94;
        //    colPARAYA_CEVRILEN_MIKTAR.FieldName = "PARAYA_CEVRILEN_MIKTAR";
        //    colPARAYA_CEVRILEN_MIKTAR.Name = "colPARAYA_CEVRILEN_MIKTAR";
        //    colPARAYA_CEVRILEN_MIKTAR.Visible = true;

        //    GridColumn colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID = new GridColumn();
        //    colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.VisibleIndex = 95;
        //    colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.FieldName = "PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
        //    colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Name = "colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
        //    colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Visible = true;

        //    GridColumn colMESLEK_ICRA_MEN_TIP = new GridColumn();
        //    colMESLEK_ICRA_MEN_TIP.VisibleIndex = 96;
        //    colMESLEK_ICRA_MEN_TIP.FieldName = "MESLEK_ICRA_MEN_TIP";
        //    colMESLEK_ICRA_MEN_TIP.Name = "colMESLEK_ICRA_MEN_TIP";
        //    colMESLEK_ICRA_MEN_TIP.Visible = true;

        //    GridColumn colMESLEK_ICRA_MEN_SURE = new GridColumn();
        //    colMESLEK_ICRA_MEN_SURE.VisibleIndex = 97;
        //    colMESLEK_ICRA_MEN_SURE.FieldName = "MESLEK_ICRA_MEN_SURE";
        //    colMESLEK_ICRA_MEN_SURE.Name = "colMESLEK_ICRA_MEN_SURE";
        //    colMESLEK_ICRA_MEN_SURE.Visible = true;

        //    GridColumn colEHLIYET_GERI_ALINMA_MEN_TIP = new GridColumn();
        //    colEHLIYET_GERI_ALINMA_MEN_TIP.VisibleIndex = 98;
        //    colEHLIYET_GERI_ALINMA_MEN_TIP.FieldName = "EHLIYET_GERI_ALINMA_MEN_TIP";
        //    colEHLIYET_GERI_ALINMA_MEN_TIP.Name = "colEHLIYET_GERI_ALINMA_MEN_TIP";
        //    colEHLIYET_GERI_ALINMA_MEN_TIP.Visible = true;

        //    GridColumn colEHLIYET_GERI_ALINMA_MEN_SURE = new GridColumn();
        //    colEHLIYET_GERI_ALINMA_MEN_SURE.VisibleIndex = 99;
        //    colEHLIYET_GERI_ALINMA_MEN_SURE.FieldName = "EHLIYET_GERI_ALINMA_MEN_SURE";
        //    colEHLIYET_GERI_ALINMA_MEN_SURE.Name = "colEHLIYET_GERI_ALINMA_MEN_SURE";
        //    colEHLIYET_GERI_ALINMA_MEN_SURE.Visible = true;

        //    GridColumn colKAMU_HIZMET_YASAK_TIP = new GridColumn();
        //    colKAMU_HIZMET_YASAK_TIP.VisibleIndex = 100;
        //    colKAMU_HIZMET_YASAK_TIP.FieldName = "KAMU_HIZMET_YASAK_TIP";
        //    colKAMU_HIZMET_YASAK_TIP.Name = "colKAMU_HIZMET_YASAK_TIP";
        //    colKAMU_HIZMET_YASAK_TIP.Visible = true;

        //    GridColumn colKAMU_HIZMET_YASAK_SURE = new GridColumn();
        //    colKAMU_HIZMET_YASAK_SURE.VisibleIndex = 101;
        //    colKAMU_HIZMET_YASAK_SURE.FieldName = "KAMU_HIZMET_YASAK_SURE";
        //    colKAMU_HIZMET_YASAK_SURE.Name = "colKAMU_HIZMET_YASAK_SURE";
        //    colKAMU_HIZMET_YASAK_SURE.Visible = true;

        //    GridColumn colHUKUM_TARAF = new GridColumn();
        //    colHUKUM_TARAF.VisibleIndex = 102;
        //    colHUKUM_TARAF.FieldName = "HUKUM_TARAF";
        //    colHUKUM_TARAF.Name = "colHUKUM_TARAF";
        //    colHUKUM_TARAF.Visible = true;

        //    GridColumn colINFAZ_TARIHI = new GridColumn();
        //    colINFAZ_TARIHI.VisibleIndex = 103;
        //    colINFAZ_TARIHI.FieldName = "INFAZ_TARIHI";
        //    colINFAZ_TARIHI.Name = "colINFAZ_TARIHI";
        //    colINFAZ_TARIHI.Visible = true;

        //    GridColumn colHUKUM_KESINLESME_TARIHI = new GridColumn();
        //    colHUKUM_KESINLESME_TARIHI.VisibleIndex = 104;
        //    colHUKUM_KESINLESME_TARIHI.FieldName = "HUKUM_KESINLESME_TARIHI";
        //    colHUKUM_KESINLESME_TARIHI.Name = "colHUKUM_KESINLESME_TARIHI";
        //    colHUKUM_KESINLESME_TARIHI.Visible = true;

        //    GridColumn colSORUMLULUK_MIKTARI = new GridColumn();
        //    colSORUMLULUK_MIKTARI.VisibleIndex = 105;
        //    colSORUMLULUK_MIKTARI.FieldName = "SORUMLULUK_MIKTARI";
        //    colSORUMLULUK_MIKTARI.Name = "colSORUMLULUK_MIKTARI";
        //    colSORUMLULUK_MIKTARI.Visible = true;

        //    GridColumn colSORUMLULUK_MIKTARI_DOVIZ_ID = new GridColumn();
        //    colSORUMLULUK_MIKTARI_DOVIZ_ID.VisibleIndex = 106;
        //    colSORUMLULUK_MIKTARI_DOVIZ_ID.FieldName = "SORUMLULUK_MIKTARI_DOVIZ_ID";
        //    colSORUMLULUK_MIKTARI_DOVIZ_ID.Name = "colSORUMLULUK_MIKTARI_DOVIZ_ID";
        //    colSORUMLULUK_MIKTARI_DOVIZ_ID.Visible = true;

        //    GridColumn colHUKUM_TEBLIG_TEFHIM_TARIHI = new GridColumn();
        //    colHUKUM_TEBLIG_TEFHIM_TARIHI.VisibleIndex = 107;
        //    colHUKUM_TEBLIG_TEFHIM_TARIHI.FieldName = "HUKUM_TEBLIG_TEFHIM_TARIHI";
        //    colHUKUM_TEBLIG_TEFHIM_TARIHI.Name = "colHUKUM_TEBLIG_TEFHIM_TARIHI";
        //    colHUKUM_TEBLIG_TEFHIM_TARIHI.Visible = true;

        //    GridColumn colTEMYIZ_TIP = new GridColumn();
        //    colTEMYIZ_TIP.VisibleIndex = 108;
        //    colTEMYIZ_TIP.FieldName = "TEMYIZ_TIP";
        //    colTEMYIZ_TIP.Name = "colTEMYIZ_TIP";
        //    colTEMYIZ_TIP.Visible = true;

        //    GridColumn colYUKSEK_MAHKEME_GONDERIM_TARIHI = new GridColumn();
        //    colYUKSEK_MAHKEME_GONDERIM_TARIHI.VisibleIndex = 109;
        //    colYUKSEK_MAHKEME_GONDERIM_TARIHI.FieldName = "YUKSEK_MAHKEME_GONDERIM_TARIHI";
        //    colYUKSEK_MAHKEME_GONDERIM_TARIHI.Name = "colYUKSEK_MAHKEME_GONDERIM_TARIHI";
        //    colYUKSEK_MAHKEME_GONDERIM_TARIHI.Visible = true;

        //    GridColumn colTEMYIZ_MAHKEME = new GridColumn();
        //    colTEMYIZ_MAHKEME.VisibleIndex = 110;
        //    colTEMYIZ_MAHKEME.FieldName = "TEMYIZ_MAHKEME";
        //    colTEMYIZ_MAHKEME.Name = "colTEMYIZ_MAHKEME";
        //    colTEMYIZ_MAHKEME.Visible = true;

        //    GridColumn colTEMYIZ_MAHKEME_GOREV = new GridColumn();
        //    colTEMYIZ_MAHKEME_GOREV.VisibleIndex = 111;
        //    colTEMYIZ_MAHKEME_GOREV.FieldName = "TEMYIZ_MAHKEME_GOREV";
        //    colTEMYIZ_MAHKEME_GOREV.Name = "colTEMYIZ_MAHKEME_GOREV";
        //    colTEMYIZ_MAHKEME_GOREV.Visible = true;

        //    GridColumn colTEMYIZ_MAHKEME_NO = new GridColumn();
        //    colTEMYIZ_MAHKEME_NO.VisibleIndex = 112;
        //    colTEMYIZ_MAHKEME_NO.FieldName = "TEMYIZ_MAHKEME_NO";
        //    colTEMYIZ_MAHKEME_NO.Name = "colTEMYIZ_MAHKEME_NO";
        //    colTEMYIZ_MAHKEME_NO.Visible = true;

        //    GridColumn colTEMYIZ_ESAS_NO = new GridColumn();
        //    colTEMYIZ_ESAS_NO.VisibleIndex = 113;
        //    colTEMYIZ_ESAS_NO.FieldName = "TEMYIZ_ESAS_NO";
        //    colTEMYIZ_ESAS_NO.Name = "colTEMYIZ_ESAS_NO";
        //    colTEMYIZ_ESAS_NO.Visible = true;

        //    GridColumn colTEMYIZ_KARAR_TARIHI = new GridColumn();
        //    colTEMYIZ_KARAR_TARIHI.VisibleIndex = 114;
        //    colTEMYIZ_KARAR_TARIHI.FieldName = "TEMYIZ_KARAR_TARIHI";
        //    colTEMYIZ_KARAR_TARIHI.Name = "colTEMYIZ_KARAR_TARIHI";
        //    colTEMYIZ_KARAR_TARIHI.Visible = true;

        //    GridColumn colTEMYIZ_KARAR_NO = new GridColumn();
        //    colTEMYIZ_KARAR_NO.VisibleIndex = 115;
        //    colTEMYIZ_KARAR_NO.FieldName = "TEMYIZ_KARAR_NO";
        //    colTEMYIZ_KARAR_NO.Name = "colTEMYIZ_KARAR_NO";
        //    colTEMYIZ_KARAR_NO.Visible = true;

        //    GridColumn colKARAR_TIP = new GridColumn();
        //    colKARAR_TIP.VisibleIndex = 116;
        //    colKARAR_TIP.FieldName = "KARAR_TIP";
        //    colKARAR_TIP.Name = "colKARAR_TIP";
        //    colKARAR_TIP.Visible = true;

        //    GridColumn colTEMYIZ_GEREKCE = new GridColumn();
        //    colTEMYIZ_GEREKCE.VisibleIndex = 117;
        //    colTEMYIZ_GEREKCE.FieldName = "TEMYIZ_GEREKCE";
        //    colTEMYIZ_GEREKCE.Name = "colTEMYIZ_GEREKCE";
        //    colTEMYIZ_GEREKCE.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_TEMYIZ_TARIHI = new GridColumn();
        //    colTEMYIZ_TARAF_TEMYIZ_TARIHI.VisibleIndex = 118;
        //    colTEMYIZ_TARAF_TEMYIZ_TARIHI.FieldName = "TEMYIZ_TARAF_TEMYIZ_TARIHI";
        //    colTEMYIZ_TARAF_TEMYIZ_TARIHI.Name = "colTEMYIZ_TARAF_TEMYIZ_TARIHI";
        //    colTEMYIZ_TARAF_TEMYIZ_TARIHI.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_CARI = new GridColumn();
        //    colTEMYIZ_TARAF_CARI.VisibleIndex = 119;
        //    colTEMYIZ_TARAF_CARI.FieldName = "TEMYIZ_TARAF_CARI";
        //    colTEMYIZ_TARAF_CARI.Name = "colTEMYIZ_TARAF_CARI";
        //    colTEMYIZ_TARAF_CARI.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_USUL_NEDENLERI = new GridColumn();
        //    colTEMYIZ_TARAF_USUL_NEDENLERI.VisibleIndex = 120;
        //    colTEMYIZ_TARAF_USUL_NEDENLERI.FieldName = "TEMYIZ_TARAF_USUL_NEDENLERI";
        //    colTEMYIZ_TARAF_USUL_NEDENLERI.Name = "colTEMYIZ_TARAF_USUL_NEDENLERI";
        //    colTEMYIZ_TARAF_USUL_NEDENLERI.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_YASAL_NEDENLER = new GridColumn();
        //    colTEMYIZ_TARAF_YASAL_NEDENLER.VisibleIndex = 121;
        //    colTEMYIZ_TARAF_YASAL_NEDENLER.FieldName = "TEMYIZ_TARAF_YASAL_NEDENLER";
        //    colTEMYIZ_TARAF_YASAL_NEDENLER.Name = "colTEMYIZ_TARAF_YASAL_NEDENLER";
        //    colTEMYIZ_TARAF_YASAL_NEDENLER.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_ACIKLAMA = new GridColumn();
        //    colTEMYIZ_TARAF_ACIKLAMA.VisibleIndex = 122;
        //    colTEMYIZ_TARAF_ACIKLAMA.FieldName = "TEMYIZ_TARAF_ACIKLAMA";
        //    colTEMYIZ_TARAF_ACIKLAMA.Name = "colTEMYIZ_TARAF_ACIKLAMA";
        //    colTEMYIZ_TARAF_ACIKLAMA.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI = new GridColumn();
        //    colTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI.VisibleIndex = 123;
        //    colTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI.FieldName = "TEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI";
        //    colTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI.Name = "colTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI";
        //    colTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_TEDBIR_TARIHI = new GridColumn();
        //    colTEMYIZ_TARAF_TEDBIR_TARIHI.VisibleIndex = 124;
        //    colTEMYIZ_TARAF_TEDBIR_TARIHI.FieldName = "TEMYIZ_TARAF_TEDBIR_TARIHI";
        //    colTEMYIZ_TARAF_TEDBIR_TARIHI.Name = "colTEMYIZ_TARAF_TEDBIR_TARIHI";
        //    colTEMYIZ_TARAF_TEDBIR_TARIHI.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_TEDBIR_ACIKLAMASI = new GridColumn();
        //    colTEMYIZ_TARAF_TEDBIR_ACIKLAMASI.VisibleIndex = 125;
        //    colTEMYIZ_TARAF_TEDBIR_ACIKLAMASI.FieldName = "TEMYIZ_TARAF_TEDBIR_ACIKLAMASI";
        //    colTEMYIZ_TARAF_TEDBIR_ACIKLAMASI.Name = "colTEMYIZ_TARAF_TEDBIR_ACIKLAMASI";
        //    colTEMYIZ_TARAF_TEDBIR_ACIKLAMASI.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI = new GridColumn();
        //    colTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI.VisibleIndex = 126;
        //    colTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI.FieldName = "TEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI";
        //    colTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI.Name = "colTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI";
        //    colTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI.Visible = true;

        //    GridColumn colTEMYIZ_TEBLIG_TARIHI = new GridColumn();
        //    colTEMYIZ_TEBLIG_TARIHI.VisibleIndex = 127;
        //    colTEMYIZ_TEBLIG_TARIHI.FieldName = "TEMYIZ_TEBLIG_TARIHI";
        //    colTEMYIZ_TEBLIG_TARIHI.Name = "colTEMYIZ_TEBLIG_TARIHI";
        //    colTEMYIZ_TEBLIG_TARIHI.Visible = true;

        //    GridColumn colTEFHIM_TARIHI = new GridColumn();
        //    colTEFHIM_TARIHI.VisibleIndex = 128;
        //    colTEFHIM_TARIHI.FieldName = "TEFHIM_TARIHI";
        //    colTEFHIM_TARIHI.Name = "colTEFHIM_TARIHI";
        //    colTEFHIM_TARIHI.Visible = true;

        //    GridColumn colTEMYIZ_TARAF_SURE_TUTUM_TARIHI = new GridColumn();
        //    colTEMYIZ_TARAF_SURE_TUTUM_TARIHI.VisibleIndex = 129;
        //    colTEMYIZ_TARAF_SURE_TUTUM_TARIHI.FieldName = "TEMYIZ_TARAF_SURE_TUTUM_TARIHI";
        //    colTEMYIZ_TARAF_SURE_TUTUM_TARIHI.Name = "colTEMYIZ_TARAF_SURE_TUTUM_TARIHI";
        //    colTEMYIZ_TARAF_SURE_TUTUM_TARIHI.Visible = true;

        //    GridColumn colDAVA_FOY_NO = new GridColumn();
        //    colDAVA_FOY_NO.VisibleIndex = 130;
        //    colDAVA_FOY_NO.FieldName = "DAVA_FOY_NO";
        //    colDAVA_FOY_NO.Name = "colDAVA_FOY_NO";
        //    colDAVA_FOY_NO.Visible = true;

        //    GridColumn colDAVA_ADLI_BIRIM_ADLIYE = new GridColumn();
        //    colDAVA_ADLI_BIRIM_ADLIYE.VisibleIndex = 131;
        //    colDAVA_ADLI_BIRIM_ADLIYE.FieldName = "DAVA_ADLI_BIRIM_ADLIYE";
        //    colDAVA_ADLI_BIRIM_ADLIYE.Name = "colDAVA_ADLI_BIRIM_ADLIYE";
        //    colDAVA_ADLI_BIRIM_ADLIYE.Visible = true;

        //    GridColumn colDAVA_ADLI_BIRIM_GOREV = new GridColumn();
        //    colDAVA_ADLI_BIRIM_GOREV.VisibleIndex = 132;
        //    colDAVA_ADLI_BIRIM_GOREV.FieldName = "DAVA_ADLI_BIRIM_GOREV";
        //    colDAVA_ADLI_BIRIM_GOREV.Name = "colDAVA_ADLI_BIRIM_GOREV";
        //    colDAVA_ADLI_BIRIM_GOREV.Visible = true;

        //    GridColumn colDAVA_ADLI_BIRIM_NO = new GridColumn();
        //    colDAVA_ADLI_BIRIM_NO.VisibleIndex = 133;
        //    colDAVA_ADLI_BIRIM_NO.FieldName = "DAVA_ADLI_BIRIM_NO";
        //    colDAVA_ADLI_BIRIM_NO.Name = "colDAVA_ADLI_BIRIM_NO";
        //    colDAVA_ADLI_BIRIM_NO.Visible = true;

        //    GridColumn colDAVA_ESAS_NO = new GridColumn();
        //    colDAVA_ESAS_NO.VisibleIndex = 134;
        //    colDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
        //    colDAVA_ESAS_NO.Name = "colDAVA_ESAS_NO";
        //    colDAVA_ESAS_NO.Visible = true;

        //    GridColumn colDAVA_TAKIP_T = new GridColumn();
        //    colDAVA_TAKIP_T.VisibleIndex = 135;
        //    colDAVA_TAKIP_T.FieldName = "DAVA_TAKIP_T";
        //    colDAVA_TAKIP_T.Name = "colDAVA_TAKIP_T";
        //    colDAVA_TAKIP_T.Visible = true;

        //    GridColumn colDAVA_REFERANS_NO2 = new GridColumn();
        //    colDAVA_REFERANS_NO2.VisibleIndex = 136;
        //    colDAVA_REFERANS_NO2.FieldName = "DAVA_REFERANS_NO2";
        //    colDAVA_REFERANS_NO2.Name = "colDAVA_REFERANS_NO2";
        //    colDAVA_REFERANS_NO2.Visible = true;

        //    GridColumn colDAVA_REFERANS_NO3 = new GridColumn();
        //    colDAVA_REFERANS_NO3.VisibleIndex = 137;
        //    colDAVA_REFERANS_NO3.FieldName = "DAVA_REFERANS_NO3";
        //    colDAVA_REFERANS_NO3.Name = "colDAVA_REFERANS_NO3";
        //    colDAVA_REFERANS_NO3.Visible = true;

        //    GridColumn colDAVA_REFERANS_NO = new GridColumn();
        //    colDAVA_REFERANS_NO.VisibleIndex = 138;
        //    colDAVA_REFERANS_NO.FieldName = "DAVA_REFERANS_NO";
        //    colDAVA_REFERANS_NO.Name = "colDAVA_REFERANS_NO";
        //    colDAVA_REFERANS_NO.Visible = true;

        //    GridColumn colDAVA_OZEL_KOD1 = new GridColumn();
        //    colDAVA_OZEL_KOD1.VisibleIndex = 139;
        //    colDAVA_OZEL_KOD1.FieldName = "DAVA_OZEL_KOD1";
        //    colDAVA_OZEL_KOD1.Name = "colDAVA_OZEL_KOD1";
        //    colDAVA_OZEL_KOD1.Visible = true;

        //    GridColumn colDAVA_OZEL_KOD2 = new GridColumn();
        //    colDAVA_OZEL_KOD2.VisibleIndex = 140;
        //    colDAVA_OZEL_KOD2.FieldName = "DAVA_OZEL_KOD2";
        //    colDAVA_OZEL_KOD2.Name = "colDAVA_OZEL_KOD2";
        //    colDAVA_OZEL_KOD2.Visible = true;

        //    GridColumn colDAVA_OZEL_KOD3 = new GridColumn();
        //    colDAVA_OZEL_KOD3.VisibleIndex = 141;
        //    colDAVA_OZEL_KOD3.FieldName = "DAVA_OZEL_KOD3";
        //    colDAVA_OZEL_KOD3.Name = "colDAVA_OZEL_KOD3";
        //    colDAVA_OZEL_KOD3.Visible = true;

        //    GridColumn colDAVA_OZEL_KOD4 = new GridColumn();
        //    colDAVA_OZEL_KOD4.VisibleIndex = 142;
        //    colDAVA_OZEL_KOD4.FieldName = "DAVA_OZEL_KOD4";
        //    colDAVA_OZEL_KOD4.Name = "colDAVA_OZEL_KOD4";
        //    colDAVA_OZEL_KOD4.Visible = true;

        //    GridColumn colDAVA_ASAMA = new GridColumn();
        //    colDAVA_ASAMA.VisibleIndex = 143;
        //    colDAVA_ASAMA.FieldName = "DAVA_ASAMA";
        //    colDAVA_ASAMA.Name = "colDAVA_ASAMA";
        //    colDAVA_ASAMA.Visible = true;

        //    GridColumn colDAVA_TALEP = new GridColumn();
        //    colDAVA_TALEP.VisibleIndex = 144;
        //    colDAVA_TALEP.FieldName = "DAVA_TALEP";
        //    colDAVA_TALEP.Name = "colDAVA_TALEP";
        //    colDAVA_TALEP.Visible = true;

        //    GridColumn colDAVA_TARAF_KODU = new GridColumn();
        //    colDAVA_TARAF_KODU.VisibleIndex = 145;
        //    colDAVA_TARAF_KODU.FieldName = "DAVA_TARAF_KODU";
        //    colDAVA_TARAF_KODU.Name = "colDAVA_TARAF_KODU";
        //    colDAVA_TARAF_KODU.Visible = true;

        //    GridColumn colDAVA_TARAF_CARI = new GridColumn();
        //    colDAVA_TARAF_CARI.VisibleIndex = 146;
        //    colDAVA_TARAF_CARI.FieldName = "DAVA_TARAF_CARI";
        //    colDAVA_TARAF_CARI.Name = "colDAVA_TARAF_CARI";
        //    colDAVA_TARAF_CARI.Visible = true;

        //    GridColumn colDAVA_TARAF_SIFAT = new GridColumn();
        //    colDAVA_TARAF_SIFAT.VisibleIndex = 147;
        //    colDAVA_TARAF_SIFAT.FieldName = "DAVA_TARAF_SIFAT";
        //    colDAVA_TARAF_SIFAT.Name = "colDAVA_TARAF_SIFAT";
        //    colDAVA_TARAF_SIFAT.Visible = true;

        //    GridColumn colSORUMLY_AVUKAT = new GridColumn();
        //    colSORUMLY_AVUKAT.VisibleIndex = 148;
        //    colSORUMLY_AVUKAT.FieldName = "SORUMLY_AVUKAT";
        //    colSORUMLY_AVUKAT.Name = "colSORUMLY_AVUKAT";
        //    colSORUMLY_AVUKAT.Visible = true;

        //    #endregion

        //    GridColumn[] dizi = null;

        //    switch (RaporName)
        //    {
        //        case "Tüm Kararlı Dosyalar":
        //            dizi = TumKararliDosyalar();
        //            break;
        //        case "Leyhe Karara Çıkanlar":
        //            break;
        //        case "Aleyhe Karara Çıkanlar":
        //            break;
        //        case "Diğer Kararlar":
        //            break;
        //        case "Tüm Temyizli Dosyalar":
        //            dizi = TumTemyizliDosyalar();
        //            break;
        //        case "Leyhe Onananlar":
        //            break;
        //        case "Aleyhe Onananlar":
        //            break;
        //        case "Leyhe Bozulanlar":
        //            break;
        //        case "Aleyhe Bozulanlar":
        //            break;
        //        case "Düzeltilerek Aleyhe Onananlar":
        //            break;
        //        case "Düzeltilerek  Leyhe Onananlar":
        //            break;
        //    }
        //    if (dizi == null)
        //    {
        //        #region []
        //         dizi = new GridColumn[]
        //{
        //    colTERDITLI_MI,
        //    colDAVA_NEDEN_TIP,
        //    colDAVA_ADI,
        //    colDIGER_DAVA_NEDEN,
        //    colDAVA_NEDEN_MAHKEME,
        //    colOLAY_SUC_TARIHI,
        //    colDUZENLEME_TARIHI,
        //    colTEBELLUG_TARIHI,
        //    colFAIZ_TALEP_TARIHI,
        //    colFAIZ_KARAR_TARIHI,
        //    colTEDBIR_TARIHI,
        //    colTEDBIR_KALDIRILMA_TARIHI,
        //    colTEDBIR_TALEP_TARIHI,
        //    colDOVIZ_ISLEM_TIPI,
        //    colSABIT_FAIZ_UYGULA,
        //    colDO_FAIZ_TIP,
        //    colDO_FAIZ_ORANI,
        //    colDN_FAIZ_TIP,
        //    colDAVA_NEDEN_FAIZ_ORANI,
        //    colDAVA_N_TUTAR,
        //    colTUTAR_DOVIZ_ID,
        //    colDAVA_EDILEN_TUTAR,
        //    colDAVA_EDILEN_TUTAR_DOVIZ_ID,
        //    colISLAH_EDILMIS,
        //    colISLAH_TARIHI,
        //    colISLAH_EDILEN_TUTAR,
        //    colISLAH_EDILEN_TUTAR_DOVIZ_ID,
        //    colPROTESTO_GIDERI,
        //    colPROTESTO_GIDERI_DOVIZ_ID,
        //    colIHTAR_GIDERI,
        //    colIHTAR_GIDERI_DOVIZ_ID,
        //    colDAVA_N_DIGER_GIDER,
        //    colDIGER_GIDER_DOVIZ_ID,
        //    colDAVA_NEDEN_SURE_GUN,
        //    colDAVA_NEDEN_SURE_AY,
        //    colDAVA_NEDEN_SURE_YIL,
        //    colDAVA_NEDEN_REFERANS_NO1,
        //    colDAVA_NEDEN_REFERANS_NO2,
        //    colVERGI_DONEMI,
        //    colFAIZ_YOK,
        //    colSIFAT,
        //    colTARAF_ADI,
        //    colKESINLESME_TARIHI,
        //    colSULH_TARIHI,
        //    colKABUL_TARIHI,
        //    colATIYE_BIRAKMA_TARIHI,
        //    colVAZGECME_TARIHI,
        //    colIKRAR_TARIHI,
        //    colGERI_ALMA_TARIHI,
        //    colASLI_MUDEHALE_TARIHI,
        //    colFERI_MUDEHALE_TARIHI,
        //    colYETKIYE_ITIRAZ_TARIHI,
        //    colGOREVE_ITIRAZ_TARIHI,
        //    colTAKIGAT_TARIHI,
        //    colESAS_BEYAN_TARIHI,
        //    colEK_SAVUNMA_TARIHI,
        //    colMUDAHALE_TARIHI,
        //    colSON_SAVUNMA_TARIHI,
        //    colSAVUNMA_TARIHI,
        //    colMUTALAA_TARIHI,
        //    colIDDIANAME_OKUNMA_TARIHI,
        //    colZAMAN_ASIMI_TARIHI,
        //    colOGRENME_TARIHI,
        //    colSORUMLU_OLUNAN_MIKTAR,
        //    colSORUMLU_OLUNAN_MIKTAR_DOVIZ_ID,
        //    colSURE_TUTUM_TARIHI,
        //    colDURUSMA_TALEP_TARIHI,
        //    colKESIF_TALEP_TARIHI,
        //    colGERI_BASVURMA_TARIHI,
        //    colYURUTME_DURDURMA_TALEP_TARIHI,
        //    colYURUTME_DURDURMA_TARIHI,
        //    colYURUTME_DURDURMA_KALDIRILMA_TARIHI,
        //    colIHBAR_TARIHI,
        //    colTARAF,
        //    colIHTAR_TARIHI,
        //    colIHTAR_TEBLIG_TARIHI,
        //    colIHTAR_TEMERRUT_TARIHI,
        //    colZAMANASIMI_IDDIA_TARIHI,
        //    colIHBAR_TEBLIG_TARIHI,
        //    colMAHKEMEDE_UZLASMA_TARIHI,
        //    colHUKUM_TARIHI,
        //    colKARAR_NO,
        //    colHUKUM,
        //    colHUKUM_TIP,
        //    colHUKUM_GEREKCE,
        //    colHUKUM_DEGER,
        //    colHUKUM_DEGER_DOVIZ_ID,
        //    colMUSADERE_DEGER,
        //    colMUSADERE_DEGER_DOVIZ_ID,
        //    colMAHKUMIYET_YIL,
        //    colMAHKUMIYET_AY,
        //    colMAHKUMIYET_GUN,
        //    colCEZA_ERTELENDI,
        //    colPARAYA_CEVRILDI,
        //    colPARAYA_CEVRILEN_MIKTAR,
        //    colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID,
        //    colMESLEK_ICRA_MEN_TIP,
        //    colMESLEK_ICRA_MEN_SURE,
        //    colEHLIYET_GERI_ALINMA_MEN_TIP,
        //    colEHLIYET_GERI_ALINMA_MEN_SURE,
        //    colKAMU_HIZMET_YASAK_TIP,
        //    colKAMU_HIZMET_YASAK_SURE,
        //    colHUKUM_TARAF,
        //    colINFAZ_TARIHI,
        //    colHUKUM_KESINLESME_TARIHI,
        //    colSORUMLULUK_MIKTARI,
        //    colSORUMLULUK_MIKTARI_DOVIZ_ID,
        //    colHUKUM_TEBLIG_TEFHIM_TARIHI,
        //    colTEMYIZ_TIP,
        //    colYUKSEK_MAHKEME_GONDERIM_TARIHI,
        //    colTEMYIZ_MAHKEME,
        //    colTEMYIZ_MAHKEME_GOREV,
        //    colTEMYIZ_MAHKEME_NO,
        //    colTEMYIZ_ESAS_NO,
        //    colTEMYIZ_KARAR_TARIHI,
        //    colTEMYIZ_KARAR_NO,
        //    colKARAR_TIP,
        //    colTEMYIZ_GEREKCE,
        //    colTEMYIZ_TARAF_TEMYIZ_TARIHI,
        //    colTEMYIZ_TARAF_CARI,
        //    colTEMYIZ_TARAF_USUL_NEDENLERI,
        //    colTEMYIZ_TARAF_YASAL_NEDENLER,
        //    colTEMYIZ_TARAF_ACIKLAMA,
        //    colTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI,
        //    colTEMYIZ_TARAF_TEDBIR_TARIHI,
        //    colTEMYIZ_TARAF_TEDBIR_ACIKLAMASI,
        //    colTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI,
        //    colTEMYIZ_TEBLIG_TARIHI,
        //    colTEFHIM_TARIHI,
        //    colTEMYIZ_TARAF_SURE_TUTUM_TARIHI,
        //    colDAVA_FOY_NO,
        //    colDAVA_ADLI_BIRIM_ADLIYE,
        //    colDAVA_ADLI_BIRIM_GOREV,
        //    colDAVA_ADLI_BIRIM_NO,
        //    colDAVA_ESAS_NO,
        //    colDAVA_TAKIP_T,
        //    colDAVA_REFERANS_NO2,
        //    colDAVA_REFERANS_NO3,
        //    colDAVA_REFERANS_NO,
        //    colDAVA_OZEL_KOD1,
        //    colDAVA_OZEL_KOD2,
        //    colDAVA_OZEL_KOD3,
        //    colDAVA_OZEL_KOD4,
        //    colDAVA_ASAMA,
        //    colDAVA_TALEP,
        //    colDAVA_TARAF_KODU,
        //    colDAVA_TARAF_CARI,
        //    colDAVA_TARAF_SIFAT,
        //    colSORUMLY_AVUKAT,
        //    };
        //        #endregion
        //    }
        //    #region Column Caption

        //    Dictionary<string, string> captionlar = GetCaptionDictinory();
        //    Dictionary<string, RepositoryItem> editler = GetRepositoryItemDictinory();

        //    for (int i = 0; i < dizi.Length; i++)
        //    {
        //        string caption = string.Empty;
        //        if (captionlar.ContainsKey(dizi[i].FieldName))
        //            caption = captionlar[dizi[i].FieldName];
        //        if (caption.Length > 0)
        //            dizi[i].Caption = caption;
        //        else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
        //            dizi[i].Caption = "Brm";

        //        if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
        //        {
        //            dizi[i].ColumnEdit = editler["DovizId"];
        //        }
        //        else if (editler.ContainsKey(dizi[i].FieldName))
        //            dizi[i].ColumnEdit = editler[dizi[i].FieldName];
        //    }
        //    #endregion

        //    return dizi;
        //}

        //private GridColumn[] TumKararliDosyalar()
        //{
        //    #region Field & Properties

        //    GridColumn colHUKUM_TARAF = new GridColumn();
        //    colHUKUM_TARAF.VisibleIndex = 102;
        //    colHUKUM_TARAF.FieldName = "HUKUM_TARAF";
        //    colHUKUM_TARAF.Name = "colHUKUM_TARAF";
        //    colHUKUM_TARAF.Visible = true;

        //    GridColumn colINFAZ_TARIHI = new GridColumn();
        //    colINFAZ_TARIHI.VisibleIndex = 103;
        //    colINFAZ_TARIHI.FieldName = "INFAZ_TARIHI";
        //    colINFAZ_TARIHI.Name = "colINFAZ_TARIHI";
        //    colINFAZ_TARIHI.Visible = true;

        //    GridColumn colHUKUM_KESINLESME_TARIHI = new GridColumn();
        //    colHUKUM_KESINLESME_TARIHI.VisibleIndex = 104;
        //    colHUKUM_KESINLESME_TARIHI.FieldName = "HUKUM_KESINLESME_TARIHI";
        //    colHUKUM_KESINLESME_TARIHI.Name = "colHUKUM_KESINLESME_TARIHI";
        //    colHUKUM_KESINLESME_TARIHI.Visible = true;

        //    GridColumn colSORUMLULUK_MIKTARI = new GridColumn();
        //    colSORUMLULUK_MIKTARI.VisibleIndex = 105;
        //    colSORUMLULUK_MIKTARI.FieldName = "SORUMLULUK_MIKTARI";
        //    colSORUMLULUK_MIKTARI.Name = "colSORUMLULUK_MIKTARI";
        //    colSORUMLULUK_MIKTARI.Visible = true;

        //    GridColumn colSORUMLULUK_MIKTARI_DOVIZ_ID = new GridColumn();
        //    colSORUMLULUK_MIKTARI_DOVIZ_ID.VisibleIndex = 106;
        //    colSORUMLULUK_MIKTARI_DOVIZ_ID.FieldName = "SORUMLULUK_MIKTARI_DOVIZ_ID";
        //    colSORUMLULUK_MIKTARI_DOVIZ_ID.Name = "colSORUMLULUK_MIKTARI_DOVIZ_ID";
        //    colSORUMLULUK_MIKTARI_DOVIZ_ID.Visible = true;

        //    GridColumn colDAVA_ADLI_BIRIM_ADLIYE = new GridColumn();
        //    colDAVA_ADLI_BIRIM_ADLIYE.VisibleIndex = 131;
        //    colDAVA_ADLI_BIRIM_ADLIYE.FieldName = "DAVA_ADLI_BIRIM_ADLIYE";
        //    colDAVA_ADLI_BIRIM_ADLIYE.Name = "colDAVA_ADLI_BIRIM_ADLIYE";
        //    colDAVA_ADLI_BIRIM_ADLIYE.Visible = true;

        //    GridColumn colDAVA_ADLI_BIRIM_GOREV = new GridColumn();
        //    colDAVA_ADLI_BIRIM_GOREV.VisibleIndex = 132;
        //    colDAVA_ADLI_BIRIM_GOREV.FieldName = "DAVA_ADLI_BIRIM_GOREV";
        //    colDAVA_ADLI_BIRIM_GOREV.Name = "colDAVA_ADLI_BIRIM_GOREV";
        //    colDAVA_ADLI_BIRIM_GOREV.Visible = true;

        //    GridColumn colDAVA_ADLI_BIRIM_NO = new GridColumn();
        //    colDAVA_ADLI_BIRIM_NO.VisibleIndex = 133;
        //    colDAVA_ADLI_BIRIM_NO.FieldName = "DAVA_ADLI_BIRIM_NO";
        //    colDAVA_ADLI_BIRIM_NO.Name = "colDAVA_ADLI_BIRIM_NO";
        //    colDAVA_ADLI_BIRIM_NO.Visible = true;

        //    GridColumn colTEMYIZ_TEBLIG_TARIHI = new GridColumn();
        //    colTEMYIZ_TEBLIG_TARIHI.VisibleIndex = 130;
        //    colTEMYIZ_TEBLIG_TARIHI.FieldName = "TEMYIZ_TEBLIG_TARIHI";
        //    colTEMYIZ_TEBLIG_TARIHI.Name = "colTEMYIZ_TEBLIG_TARIHI";
        //    colTEMYIZ_TEBLIG_TARIHI.Visible = true;

        //    GridColumn colDAVA_ESAS_NO = new GridColumn();
        //    colDAVA_ESAS_NO.VisibleIndex = 134;
        //    colDAVA_ESAS_NO.FieldName = "DAVA_ESAS_NO";
        //    colDAVA_ESAS_NO.Name = "colDAVA_ESAS_NO";
        //    colDAVA_ESAS_NO.Visible = true;

        //    GridColumn colDAVA_TAKIP_T = new GridColumn();
        //    colDAVA_TAKIP_T.VisibleIndex = 135;
        //    colDAVA_TAKIP_T.FieldName = "DAVA_TAKIP_T";
        //    colDAVA_TAKIP_T.Name = "colDAVA_TAKIP_T";
        //    colDAVA_TAKIP_T.Visible = true;

        //    GridColumn colDAVA_TALEP = new GridColumn();
        //    colDAVA_TALEP.VisibleIndex = 144;
        //    colDAVA_TALEP.FieldName = "DAVA_TALEP";
        //    colDAVA_TALEP.Name = "colDAVA_TALEP";
        //    colDAVA_TALEP.Visible = true;

        //    GridColumn colDAVA_TARAF_KODU = new GridColumn();
        //    colDAVA_TARAF_KODU.VisibleIndex = 145;
        //    colDAVA_TARAF_KODU.FieldName = "DAVA_TARAF_KODU";
        //    colDAVA_TARAF_KODU.Name = "colDAVA_TARAF_KODU";
        //    colDAVA_TARAF_KODU.Visible = true;

        //    GridColumn colDAVA_TARAF_CARI = new GridColumn();
        //    colDAVA_TARAF_CARI.VisibleIndex = 146;
        //    colDAVA_TARAF_CARI.FieldName = "DAVA_TARAF_CARI";
        //    colDAVA_TARAF_CARI.Name = "colDAVA_TARAF_CARI";
        //    colDAVA_TARAF_CARI.Visible = true;

        //    GridColumn colDAVA_TARAF_SIFAT = new GridColumn();
        //    colDAVA_TARAF_SIFAT.VisibleIndex = 147;
        //    colDAVA_TARAF_SIFAT.FieldName = "DAVA_TARAF_SIFAT";
        //    colDAVA_TARAF_SIFAT.Name = "colDAVA_TARAF_SIFAT";
        //    colDAVA_TARAF_SIFAT.Visible = true;

        //    GridColumn colSORUMLY_AVUKAT = new GridColumn();
        //    colSORUMLY_AVUKAT.VisibleIndex = 148;
        //    colSORUMLY_AVUKAT.FieldName = "SORUMLY_AVUKAT";
        //    colSORUMLY_AVUKAT.Name = "colSORUMLY_AVUKAT";
        //    colSORUMLY_AVUKAT.Visible = true;

        //    GridColumn colHUKUM_TEBLIG_TEFHIM_TARIHI = new GridColumn();
        //    colHUKUM_TEBLIG_TEFHIM_TARIHI.VisibleIndex = 107;
        //    colHUKUM_TEBLIG_TEFHIM_TARIHI.FieldName = "HUKUM_TEBLIG_TEFHIM_TARIHI";
        //    colHUKUM_TEBLIG_TEFHIM_TARIHI.Name = "colHUKUM_TEBLIG_TEFHIM_TARIHI";
        //    colHUKUM_TEBLIG_TEFHIM_TARIHI.Visible = true;

        //    GridColumn colMAHKUMIYET_YIL = new GridColumn();
        //    colMAHKUMIYET_YIL.VisibleIndex = 89;
        //    colMAHKUMIYET_YIL.FieldName = "MAHKUMIYET_YIL";
        //    colMAHKUMIYET_YIL.Name = "colMAHKUMIYET_YIL";
        //    colMAHKUMIYET_YIL.Visible = true;

        //    GridColumn colMAHKUMIYET_AY = new GridColumn();
        //    colMAHKUMIYET_AY.VisibleIndex = 90;
        //    colMAHKUMIYET_AY.FieldName = "MAHKUMIYET_AY";
        //    colMAHKUMIYET_AY.Name = "colMAHKUMIYET_AY";
        //    colMAHKUMIYET_AY.Visible = true;

        //    GridColumn colMAHKUMIYET_GUN = new GridColumn();
        //    colMAHKUMIYET_GUN.VisibleIndex = 91;
        //    colMAHKUMIYET_GUN.FieldName = "MAHKUMIYET_GUN";
        //    colMAHKUMIYET_GUN.Name = "colMAHKUMIYET_GUN";
        //    colMAHKUMIYET_GUN.Visible = true;

        //    GridColumn colCEZA_ERTELENDI = new GridColumn();
        //    colCEZA_ERTELENDI.VisibleIndex = 92;
        //    colCEZA_ERTELENDI.FieldName = "CEZA_ERTELENDI";
        //    colCEZA_ERTELENDI.Name = "colCEZA_ERTELENDI";
        //    colCEZA_ERTELENDI.Visible = true;

        //    GridColumn colPARAYA_CEVRILDI = new GridColumn();
        //    colPARAYA_CEVRILDI.VisibleIndex = 93;
        //    colPARAYA_CEVRILDI.FieldName = "PARAYA_CEVRILDI";
        //    colPARAYA_CEVRILDI.Name = "colPARAYA_CEVRILDI";
        //    colPARAYA_CEVRILDI.Visible = true;

        //    GridColumn colPARAYA_CEVRILEN_MIKTAR = new GridColumn();
        //    colPARAYA_CEVRILEN_MIKTAR.VisibleIndex = 94;
        //    colPARAYA_CEVRILEN_MIKTAR.FieldName = "PARAYA_CEVRILEN_MIKTAR";
        //    colPARAYA_CEVRILEN_MIKTAR.Name = "colPARAYA_CEVRILEN_MIKTAR";
        //    colPARAYA_CEVRILEN_MIKTAR.Visible = true;

        //    GridColumn colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID = new GridColumn();
        //    colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.VisibleIndex = 95;
        //    colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.FieldName = "PARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
        //    colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Name = "colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID";
        //    colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID.Visible = true;

        //    GridColumn colHUKUM_TIP = new GridColumn();
        //    colHUKUM_TIP.VisibleIndex = 83;
        //    colHUKUM_TIP.FieldName = "HUKUM_TIP";
        //    colHUKUM_TIP.Name = "colHUKUM_TIP";
        //    colHUKUM_TIP.Visible = true;

        //    GridColumn colHUKUM_GEREKCE = new GridColumn();
        //    colHUKUM_GEREKCE.VisibleIndex = 84;
        //    colHUKUM_GEREKCE.FieldName = "HUKUM_GEREKCE";
        //    colHUKUM_GEREKCE.Name = "colHUKUM_GEREKCE";
        //    colHUKUM_GEREKCE.Visible = true;

        //    GridColumn colHUKUM_DEGER = new GridColumn();
        //    colHUKUM_DEGER.VisibleIndex = 85;
        //    colHUKUM_DEGER.FieldName = "HUKUM_DEGER";
        //    colHUKUM_DEGER.Name = "colHUKUM_DEGER";
        //    colHUKUM_DEGER.Visible = true;

        //    GridColumn colHUKUM_DEGER_DOVIZ_ID = new GridColumn();
        //    colHUKUM_DEGER_DOVIZ_ID.VisibleIndex = 86;
        //    colHUKUM_DEGER_DOVIZ_ID.FieldName = "HUKUM_DEGER_DOVIZ_ID";
        //    colHUKUM_DEGER_DOVIZ_ID.Name = "colHUKUM_DEGER_DOVIZ_ID";
        //    colHUKUM_DEGER_DOVIZ_ID.Visible = true;

        //    GridColumn colMUSADERE_DEGER = new GridColumn();
        //    colMUSADERE_DEGER.VisibleIndex = 87;
        //    colMUSADERE_DEGER.FieldName = "MUSADERE_DEGER";
        //    colMUSADERE_DEGER.Name = "colMUSADERE_DEGER";
        //    colMUSADERE_DEGER.Visible = true;

        //    GridColumn colMUSADERE_DEGER_DOVIZ_ID = new GridColumn();
        //    colMUSADERE_DEGER_DOVIZ_ID.VisibleIndex = 88;
        //    colMUSADERE_DEGER_DOVIZ_ID.FieldName = "MUSADERE_DEGER_DOVIZ_ID";
        //    colMUSADERE_DEGER_DOVIZ_ID.Name = "colMUSADERE_DEGER_DOVIZ_ID";
        //    colMUSADERE_DEGER_DOVIZ_ID.Visible = true;

        //    GridColumn colKARAR_NO = new GridColumn();
        //    colKARAR_NO.VisibleIndex = 81;
        //    colKARAR_NO.FieldName = "KARAR_NO";
        //    colKARAR_NO.Name = "colKARAR_NO";
        //    colKARAR_NO.Visible = true;

        //    GridColumn colHUKUM = new GridColumn();
        //    colHUKUM.VisibleIndex = 82;
        //    colHUKUM.FieldName = "HUKUM";
        //    colHUKUM.Name = "colHUKUM";
        //    colHUKUM.Visible = true;

        //    GridColumn colHUKUM_TARIHI = new GridColumn();
        //    colHUKUM_TARIHI.VisibleIndex = 80;
        //    colHUKUM_TARIHI.FieldName = "HUKUM_TARIHI";
        //    colHUKUM_TARIHI.Name = "colHUKUM_TARIHI";
        //    colHUKUM_TARIHI.Visible = true;

        //    GridColumn colSIFAT = new GridColumn();
        //    colSIFAT.VisibleIndex = 40;
        //    colSIFAT.FieldName = "SIFAT";
        //    colSIFAT.Name = "colSIFAT";
        //    colSIFAT.Visible = true;

        //    GridColumn colTARAF_ADI = new GridColumn();
        //    colTARAF_ADI.VisibleIndex = 41;
        //    colTARAF_ADI.FieldName = "TARAF_ADI";
        //    colTARAF_ADI.Name = "colTARAF_ADI";
        //    colTARAF_ADI.Visible = true;

        //    GridColumn colKESINLESME_TARIHI = new GridColumn();
        //    colKESINLESME_TARIHI.VisibleIndex = 42;
        //    colKESINLESME_TARIHI.FieldName = "KESINLESME_TARIHI";
        //    colKESINLESME_TARIHI.Name = "colKESINLESME_TARIHI";
        //    colKESINLESME_TARIHI.Visible = true;

        //    GridColumn colTEBELLUG_TARIHI = new GridColumn();
        //    colTEBELLUG_TARIHI.VisibleIndex = 7;
        //    colTEBELLUG_TARIHI.FieldName = "TEBELLUG_TARIHI";
        //    colTEBELLUG_TARIHI.Name = "colTEBELLUG_TARIHI";
        //    colTEBELLUG_TARIHI.Visible = true;

        //    GridColumn colDIGER_DAVA_NEDEN = new GridColumn();
        //    colDIGER_DAVA_NEDEN.VisibleIndex = 3;
        //    colDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
        //    colDIGER_DAVA_NEDEN.Name = "colDIGER_DAVA_NEDEN";
        //    colDIGER_DAVA_NEDEN.Visible = true;
        //    #endregion
        //    GridColumn[] dizi = new GridColumn[]
        //    {
        //        colDIGER_DAVA_NEDEN,
        //        colTEBELLUG_TARIHI,
        //        colSIFAT,
        //        colTARAF_ADI,
        //        colKESINLESME_TARIHI,
        //        colHUKUM_TARIHI,
        //        colKARAR_NO,
        //        colHUKUM,
        //        colHUKUM_TIP,
        //        colHUKUM_DEGER,
        //        colHUKUM_DEGER_DOVIZ_ID,
        //        colMUSADERE_DEGER,
        //        colMUSADERE_DEGER_DOVIZ_ID,
        //        colMAHKUMIYET_YIL,
        //        colMAHKUMIYET_AY,
        //        colMAHKUMIYET_GUN,
        //        colCEZA_ERTELENDI,
        //        colPARAYA_CEVRILDI,
        //        colPARAYA_CEVRILEN_MIKTAR,
        //        colPARAYA_CEVRILEN_MIKTAR_DOVIZ_ID,
        //        colHUKUM_TARAF,
        //        colINFAZ_TARIHI,
        //        colHUKUM_KESINLESME_TARIHI,
        //        colSORUMLULUK_MIKTARI,
        //        colSORUMLULUK_MIKTARI_DOVIZ_ID,
        //        colHUKUM_TEBLIG_TEFHIM_TARIHI,
        //        colTEMYIZ_TEBLIG_TARIHI,
        //        colDAVA_ADLI_BIRIM_ADLIYE,
        //        colDAVA_ADLI_BIRIM_GOREV,
        //        colDAVA_ADLI_BIRIM_NO,
        //        colDAVA_ESAS_NO,
        //        colDAVA_TAKIP_T,
        //        colDAVA_TALEP,
        //        colDAVA_TARAF_KODU,
        //        colDAVA_TARAF_CARI,
        //        colDAVA_TARAF_SIFAT,
        //        colSORUMLY_AVUKAT,
        //    };
        //    return dizi;

        //}

        //private GridColumn[] TumTemyizliDosyalar()
        //{
        //    GridColumn[] dizi = new GridColumn[]
        //    {
        //        colDIGER_DAVA_NEDEN,
        //        colFAIZ_KARAR_TARIHI,
        //        colDAVA_N_TUTAR,
        //        colTUTAR_DOVIZ_ID,
        //        colDAVA_EDILEN_TUTAR,
        //        colDAVA_EDILEN_TUTAR_DOVIZ_ID,
        //        colSIFAT,
        //        colTARAF_ADI,
        //        colKESINLESME_TARIHI,
        //        colTARAF,
        //        colKARAR_NO,
        //        colHUKUM_TARAF,
        //        colINFAZ_TARIHI,
        //        colHUKUM_KESINLESME_TARIHI,
        //        colHUKUM_TEBLIG_TEFHIM_TARIHI,
        //        colTEMYIZ_TIP,
        //        colYUKSEK_MAHKEME_GONDERIM_TARIHI,
        //        colTEMYIZ_MAHKEME,
        //        colTEMYIZ_MAHKEME_GOREV,
        //        colTEMYIZ_MAHKEME_NO,
        //        colTEMYIZ_ESAS_NO,
        //        colTEMYIZ_KARAR_TARIHI,
        //        colTEMYIZ_KARAR_NO,
        //        colKARAR_TIP,
        //        colTEMYIZ_GEREKCE,
        //        colTEMYIZ_TARAF_TEMYIZ_TARIHI,
        //        colTEMYIZ_TARAF_CARI,
        //        colTEMYIZ_TARAF_USUL_NEDENLERI,
        //        colTEMYIZ_TARAF_YASAL_NEDENLER,
        //        colTEMYIZ_TARAF_ACIKLAMA,
        //        colTEMYIZ_TARAF_TEDBIR_ISTEM_TARIHI,
        //        colTEMYIZ_TARAF_TEDBIR_TARIHI,
        //        colTEMYIZ_TARAF_TEDBIR_ACIKLAMASI,
        //        colTEMYIZ_TARAF_TEDBIRIN_KALDIRILMASI_TARIHI,
        //        colTEMYIZ_TEBLIG_TARIHI,
        //        colTEFHIM_TARIHI,
        //        colTEMYIZ_TARAF_SURE_TUTUM_TARIHI,
        //        colDAVA_FOY_NO,
        //        colDAVA_ADLI_BIRIM_ADLIYE,
        //        colDAVA_ADLI_BIRIM_GOREV,
        //        colDAVA_ADLI_BIRIM_NO,
        //        colDAVA_ESAS_NO,
        //        colDAVA_TAKIP_T,
        //        colDAVA_REFERANS_NO2,
        //        colDAVA_REFERANS_NO3,
        //        colDAVA_REFERANS_NO,
        //        colDAVA_TALEP,
        //        colDAVA_TARAF_KODU,
        //        colDAVA_TARAF_CARI,
        //        colDAVA_TARAF_SIFAT,
        //        colSORUMLY_AVUKAT,
        //    };
        //    return dizi;

        //}

        #endregion
        
        public GridColumn[] GetGridColumns()
        {
            #region Field & Properties

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 0;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 1;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.Visible = true;

            GridColumn colDAVACI = new GridColumn();
            colDAVACI.VisibleIndex = 2;
            colDAVACI.FieldName = "DAVACI";
            colDAVACI.Name = "colDAVACI";
            colDAVACI.Visible = true;

            GridColumn colDAVALI = new GridColumn();
            colDAVALI.VisibleIndex = 3;
            colDAVALI.FieldName = "DAVALI";
            colDAVALI.Name = "colDAVALI";
            colDAVALI.Visible = true;

            GridColumn colDAVA_EDEN_SIFAT = new GridColumn();
            colDAVA_EDEN_SIFAT.VisibleIndex = 4;
            colDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Name = "colDAVA_EDEN_SIFAT";
            colDAVA_EDEN_SIFAT.Visible = true;

            GridColumn colDAVA_EDILEN_SIFAT = new GridColumn();
            colDAVA_EDILEN_SIFAT.VisibleIndex = 5;
            colDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Name = "colDAVA_EDILEN_SIFAT";
            colDAVA_EDILEN_SIFAT.Visible = true;

            GridColumn colDAVA_TALEP = new GridColumn();
            colDAVA_TALEP.VisibleIndex = 6;
            colDAVA_TALEP.FieldName = "DAVA_TALEP";
            colDAVA_TALEP.Name = "colDAVA_TALEP";
            colDAVA_TALEP.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 7;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 8;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 9;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.Visible = true;

            GridColumn colDAVA_TARIHI = new GridColumn();
            colDAVA_TARIHI.VisibleIndex = 10;
            colDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            colDAVA_TARIHI.Name = "colDAVA_TARIHI";
            colDAVA_TARIHI.Visible = true;

            GridColumn colESAS_NO = new GridColumn();
            colESAS_NO.VisibleIndex = 11;
            colESAS_NO.FieldName = "ESAS_NO";
            colESAS_NO.Name = "colESAS_NO";
            colESAS_NO.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 12;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 13;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 14;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.Visible = true;

            GridColumn colFOY_NO = new GridColumn();
            colFOY_NO.VisibleIndex = 15;
            colFOY_NO.FieldName = "FOY_NO";
            colFOY_NO.Name = "colFOY_NO";
            colFOY_NO.Visible = true;

            GridColumn colDIGER_DAVA_NEDEN = new GridColumn();
            colDIGER_DAVA_NEDEN.VisibleIndex = 16;
            colDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            colDIGER_DAVA_NEDEN.Name = "colDIGER_DAVA_NEDEN";
            colDIGER_DAVA_NEDEN.Visible = true;

            GridColumn colFAIZ_KARAR_TARIHI = new GridColumn();
            colFAIZ_KARAR_TARIHI.VisibleIndex = 17;
            colFAIZ_KARAR_TARIHI.FieldName = "FAIZ_KARAR_TARIHI";
            colFAIZ_KARAR_TARIHI.Name = "colFAIZ_KARAR_TARIHI";
            colFAIZ_KARAR_TARIHI.Visible = true;

            GridColumn colTUTAR = new GridColumn();
            colTUTAR.VisibleIndex = 18;
            colTUTAR.FieldName = "TUTAR";
            colTUTAR.Name = "colTUTAR";
            colTUTAR.Visible = true;

            GridColumn colTUTAR_DOVIZ_ID = new GridColumn();
            colTUTAR_DOVIZ_ID.VisibleIndex = 19;
            colTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            colTUTAR_DOVIZ_ID.Name = "colTUTAR_DOVIZ_ID";
            colTUTAR_DOVIZ_ID.Visible = true;

            GridColumn colDAVA_EDILEN_TUTAR = new GridColumn();
            colDAVA_EDILEN_TUTAR.VisibleIndex = 20;
            colDAVA_EDILEN_TUTAR.FieldName = "DAVA_EDILEN_TUTAR";
            colDAVA_EDILEN_TUTAR.Name = "colDAVA_EDILEN_TUTAR";
            colDAVA_EDILEN_TUTAR.Visible = true;

            GridColumn colDAVA_EDILEN_TUTAR_DOVIZ_ID = new GridColumn();
            colDAVA_EDILEN_TUTAR_DOVIZ_ID.VisibleIndex = 21;
            colDAVA_EDILEN_TUTAR_DOVIZ_ID.FieldName = "DAVA_EDILEN_TUTAR_DOVIZ_ID";
            colDAVA_EDILEN_TUTAR_DOVIZ_ID.Name = "colDAVA_EDILEN_TUTAR_DOVIZ_ID";
            colDAVA_EDILEN_TUTAR_DOVIZ_ID.Visible = true;

            GridColumn colKARAR_NO = new GridColumn();
            colKARAR_NO.VisibleIndex = 22;
            colKARAR_NO.FieldName = "KARAR_NO";
            colKARAR_NO.Name = "colKARAR_NO";
            colKARAR_NO.Visible = true;

            GridColumn colKESINLESME_TARIHI = new GridColumn();
            colKESINLESME_TARIHI.VisibleIndex = 23;
            colKESINLESME_TARIHI.FieldName = "KESINLESME_TARIHI";
            colKESINLESME_TARIHI.Name = "colKESINLESME_TARIHI";
            colKESINLESME_TARIHI.Visible = true;

            GridColumn colHUKUM_TEBLIG_TEFHIM_TARIHI = new GridColumn();
            colHUKUM_TEBLIG_TEFHIM_TARIHI.VisibleIndex = 24;
            colHUKUM_TEBLIG_TEFHIM_TARIHI.FieldName = "HUKUM_TEBLIG_TEFHIM_TARIHI";
            colHUKUM_TEBLIG_TEFHIM_TARIHI.Name = "colHUKUM_TEBLIG_TEFHIM_TARIHI";
            colHUKUM_TEBLIG_TEFHIM_TARIHI.Visible = true;

            GridColumn colHUKUM_TARAF = new GridColumn();
            colHUKUM_TARAF.VisibleIndex = 25;
            colHUKUM_TARAF.FieldName = "HUKUM_TARAF";
            colHUKUM_TARAF.Name = "colHUKUM_TARAF";
            colHUKUM_TARAF.Visible = true;

            GridColumn colHUKUM_ANLAM = new GridColumn();
            colHUKUM_ANLAM.VisibleIndex = 26;
            colHUKUM_ANLAM.FieldName = "HUKUM_ANLAM";
            colHUKUM_ANLAM.Name = "colHUKUM_ANLAM";
            colHUKUM_ANLAM.Visible = true;

            GridColumn colSURE_TUTUM_TARIHI = new GridColumn();
            colSURE_TUTUM_TARIHI.VisibleIndex = 27;
            colSURE_TUTUM_TARIHI.FieldName = "SURE_TUTUM_TARIHI";
            colSURE_TUTUM_TARIHI.Name = "colSURE_TUTUM_TARIHI";
            colSURE_TUTUM_TARIHI.Visible = true;

            GridColumn colTEFHIM_TARIHI = new GridColumn();
            colTEFHIM_TARIHI.VisibleIndex = 28;
            colTEFHIM_TARIHI.FieldName = "TEFHIM_TARIHI";
            colTEFHIM_TARIHI.Name = "colTEFHIM_TARIHI";
            colTEFHIM_TARIHI.Visible = true;

            GridColumn colTEMYIZ_TEBLIG_TARIHI = new GridColumn();
            colTEMYIZ_TEBLIG_TARIHI.VisibleIndex = 29;
            colTEMYIZ_TEBLIG_TARIHI.FieldName = "TEMYIZ_TEBLIG_TARIHI";
            colTEMYIZ_TEBLIG_TARIHI.Name = "colTEMYIZ_TEBLIG_TARIHI";
            colTEMYIZ_TEBLIG_TARIHI.Visible = true;

            GridColumn colTEDBIRIN_KALDIRILMASI_TARIHI = new GridColumn();
            colTEDBIRIN_KALDIRILMASI_TARIHI.VisibleIndex = 30;
            colTEDBIRIN_KALDIRILMASI_TARIHI.FieldName = "TEDBIRIN_KALDIRILMASI_TARIHI";
            colTEDBIRIN_KALDIRILMASI_TARIHI.Name = "colTEDBIRIN_KALDIRILMASI_TARIHI";
            colTEDBIRIN_KALDIRILMASI_TARIHI.Visible = true;

            GridColumn colTEDBIR_TARIHI = new GridColumn();
            colTEDBIR_TARIHI.VisibleIndex = 31;
            colTEDBIR_TARIHI.FieldName = "TEDBIR_TARIHI";
            colTEDBIR_TARIHI.Name = "colTEDBIR_TARIHI";
            colTEDBIR_TARIHI.Visible = true;

            GridColumn colTEDBIR_ISTEM_TARIHI = new GridColumn();
            colTEDBIR_ISTEM_TARIHI.VisibleIndex = 32;
            colTEDBIR_ISTEM_TARIHI.FieldName = "TEDBIR_ISTEM_TARIHI";
            colTEDBIR_ISTEM_TARIHI.Name = "colTEDBIR_ISTEM_TARIHI";
            colTEDBIR_ISTEM_TARIHI.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 33;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.Visible = true;

            GridColumn colYASAL_NEDENLER = new GridColumn();
            colYASAL_NEDENLER.VisibleIndex = 34;
            colYASAL_NEDENLER.FieldName = "YASAL_NEDENLER";
            colYASAL_NEDENLER.Name = "colYASAL_NEDENLER";
            colYASAL_NEDENLER.Visible = true;

            GridColumn colUSUL_NEDENLER = new GridColumn();
            colUSUL_NEDENLER.VisibleIndex = 35;
            colUSUL_NEDENLER.FieldName = "USUL_NEDENLER";
            colUSUL_NEDENLER.Name = "colUSUL_NEDENLER";
            colUSUL_NEDENLER.Visible = true;

            GridColumn colTEMYIZ_TARIHI = new GridColumn();
            colTEMYIZ_TARIHI.VisibleIndex = 36;
            colTEMYIZ_TARIHI.FieldName = "TEMYIZ_TARIHI";
            colTEMYIZ_TARIHI.Name = "colTEMYIZ_TARIHI";
            colTEMYIZ_TARIHI.Visible = true;

            GridColumn colTEMYIZ_TARAF = new GridColumn();
            colTEMYIZ_TARAF.VisibleIndex = 37;
            colTEMYIZ_TARAF.FieldName = "TEMYIZ_TARAF";
            colTEMYIZ_TARAF.Name = "colTEMYIZ_TARAF";
            colTEMYIZ_TARAF.Visible = true;

            GridColumn colGEREKCE = new GridColumn();
            colGEREKCE.VisibleIndex = 38;
            colGEREKCE.FieldName = "GEREKCE";
            colGEREKCE.Name = "colGEREKCE";
            colGEREKCE.Visible = true;

            GridColumn colKARAR_TIP = new GridColumn();
            colKARAR_TIP.VisibleIndex = 39;
            colKARAR_TIP.FieldName = "KARAR_TIP";
            colKARAR_TIP.Name = "colKARAR_TIP";
            colKARAR_TIP.Visible = true;

            GridColumn colTEMYIZ_KARAR_NO = new GridColumn();
            colTEMYIZ_KARAR_NO.VisibleIndex = 40;
            colTEMYIZ_KARAR_NO.FieldName = "TEMYIZ_KARAR_NO";
            colTEMYIZ_KARAR_NO.Name = "colTEMYIZ_KARAR_NO";
            colTEMYIZ_KARAR_NO.Visible = true;

            GridColumn colKARAR_TARIHI = new GridColumn();
            colKARAR_TARIHI.VisibleIndex = 41;
            colKARAR_TARIHI.FieldName = "KARAR_TARIHI";
            colKARAR_TARIHI.Name = "colKARAR_TARIHI";
            colKARAR_TARIHI.Visible = true;

            GridColumn colTEMYIZ_ESAS_NO = new GridColumn();
            colTEMYIZ_ESAS_NO.VisibleIndex = 42;
            colTEMYIZ_ESAS_NO.FieldName = "TEMYIZ_ESAS_NO";
            colTEMYIZ_ESAS_NO.Name = "colTEMYIZ_ESAS_NO";
            colTEMYIZ_ESAS_NO.Visible = true;

            GridColumn colTEMYIZ_GOREV = new GridColumn();
            colTEMYIZ_GOREV.VisibleIndex = 43;
            colTEMYIZ_GOREV.FieldName = "TEMYIZ_GOREV";
            colTEMYIZ_GOREV.Name = "colTEMYIZ_GOREV";
            colTEMYIZ_GOREV.Visible = true;

            GridColumn colTEMYIZ_MAHKEME = new GridColumn();
            colTEMYIZ_MAHKEME.VisibleIndex = 44;
            colTEMYIZ_MAHKEME.FieldName = "TEMYIZ_MAHKEME";
            colTEMYIZ_MAHKEME.Name = "colTEMYIZ_MAHKEME";
            colTEMYIZ_MAHKEME.Visible = true;

            GridColumn colTEMYIZ_BIRIM_NO = new GridColumn();
            colTEMYIZ_BIRIM_NO.VisibleIndex = 45;
            colTEMYIZ_BIRIM_NO.FieldName = "TEMYIZ_BIRIM_NO";
            colTEMYIZ_BIRIM_NO.Name = "colTEMYIZ_BIRIM_NO";
            colTEMYIZ_BIRIM_NO.Visible = true;

            GridColumn colYUKSEK_MAHKEME_GONDERIM_TARIHI = new GridColumn();
            colYUKSEK_MAHKEME_GONDERIM_TARIHI.VisibleIndex = 46;
            colYUKSEK_MAHKEME_GONDERIM_TARIHI.FieldName = "YUKSEK_MAHKEME_GONDERIM_TARIHI";
            colYUKSEK_MAHKEME_GONDERIM_TARIHI.Name = "colYUKSEK_MAHKEME_GONDERIM_TARIHI";
            colYUKSEK_MAHKEME_GONDERIM_TARIHI.Visible = true;

            GridColumn colTEMYIZ_TIP = new GridColumn();
            colTEMYIZ_TIP.VisibleIndex = 47;
            colTEMYIZ_TIP.FieldName = "TEMYIZ_TIP";
            colTEMYIZ_TIP.Name = "colTEMYIZ_TIP";
            colTEMYIZ_TIP.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 48;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 49;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colDAVA_FOY_ID = new GridColumn();
            colDAVA_FOY_ID.VisibleIndex = 50;
            colDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
            colDAVA_FOY_ID.Name = "colDAVA_FOY_ID";
            colDAVA_FOY_ID.Visible = true;

            GridColumn colTEMYIZ_ID = new GridColumn();
            colTEMYIZ_ID.VisibleIndex = 51;
            colTEMYIZ_ID.FieldName = "TEMYIZ_ID";
            colTEMYIZ_ID.Name = "colTEMYIZ_ID";
            colTEMYIZ_ID.Visible = true;

            GridColumn colBOLUM = new GridColumn();
            colBOLUM.VisibleIndex = 52;
            colBOLUM.FieldName = "BOLUM";
            colBOLUM.Name = "colBOLUM";
            colBOLUM.Visible = true;

            #endregion

            #region []

            GridColumn[] dizi = new GridColumn[]
		{
			colSORUMLU,
			colIZLEYEN,
			colDAVACI,
			colDAVALI,
			colDAVA_EDEN_SIFAT,
			colDAVA_EDILEN_SIFAT,
			colDAVA_TALEP,
			colREFERANS_NO,
			colREFERANS_NO2,
			colREFERANS_NO3,
			colDAVA_TARIHI,
			colESAS_NO,
			colADLIYE,
			colNO,
			colGOREV,
			colFOY_NO,
			colDIGER_DAVA_NEDEN,
			colFAIZ_KARAR_TARIHI,
			colTUTAR,
			colTUTAR_DOVIZ_ID,
			colDAVA_EDILEN_TUTAR,
			colDAVA_EDILEN_TUTAR_DOVIZ_ID,
			colKARAR_NO,
			colKESINLESME_TARIHI,
			colHUKUM_TEBLIG_TEFHIM_TARIHI,
			colHUKUM_TARAF,
			colHUKUM_ANLAM,
			colSURE_TUTUM_TARIHI,
			colTEFHIM_TARIHI,
			colTEMYIZ_TEBLIG_TARIHI,
			colTEDBIRIN_KALDIRILMASI_TARIHI,
			colTEDBIR_TARIHI,
			colTEDBIR_ISTEM_TARIHI,
			colACIKLAMA,
			colYASAL_NEDENLER,
			colUSUL_NEDENLER,
			colTEMYIZ_TARIHI,
			colTEMYIZ_TARAF,
			colGEREKCE,
			colKARAR_TIP,
			colTEMYIZ_KARAR_NO,
			colKARAR_TARIHI,
			colTEMYIZ_ESAS_NO,
			colTEMYIZ_GOREV,
			colTEMYIZ_MAHKEME,
			colTEMYIZ_BIRIM_NO,
			colYUKSEK_MAHKEME_GONDERIM_TARIHI,
			colTEMYIZ_TIP,
			colSUBE_KOD_ID,
			colKONTROL_KIM_ID,
			colDAVA_FOY_ID,
			colTEMYIZ_ID,
			colBOLUM,
			};

            #endregion

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
                {
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].ColumnEdit = editler["DovizId"];
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTip = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }
                else if (editler.ContainsKey(dizi[i].FieldName))
                    dizi[i].ColumnEdit = editler[dizi[i].FieldName];
            }

            #endregion

            return dizi;
        }

        public PivotGridField[] GetPivotFields()
        {
            #region Field & Properties

            PivotGridField fieldSORUMLU = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSORUMLU.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSORUMLU.AreaIndex = 0;
            fieldSORUMLU.FieldName = "SORUMLU";
            fieldSORUMLU.Name = "fieldSORUMLU";
            fieldSORUMLU.Visible = false;

            PivotGridField fieldIZLEYEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldIZLEYEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldIZLEYEN.AreaIndex = 1;
            fieldIZLEYEN.FieldName = "IZLEYEN";
            fieldIZLEYEN.Name = "fieldIZLEYEN";
            fieldIZLEYEN.Visible = false;

            PivotGridField fieldDAVACI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVACI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVACI.AreaIndex = 2;
            fieldDAVACI.FieldName = "DAVACI";
            fieldDAVACI.Name = "fieldDAVACI";
            fieldDAVACI.Visible = false;

            PivotGridField fieldDAVALI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVALI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVALI.AreaIndex = 3;
            fieldDAVALI.FieldName = "DAVALI";
            fieldDAVALI.Name = "fieldDAVALI";
            fieldDAVALI.Visible = false;

            PivotGridField fieldDAVA_EDEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDEN_SIFAT.AreaIndex = 4;
            fieldDAVA_EDEN_SIFAT.FieldName = "DAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Name = "fieldDAVA_EDEN_SIFAT";
            fieldDAVA_EDEN_SIFAT.Visible = false;

            PivotGridField fieldDAVA_EDILEN_SIFAT = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDILEN_SIFAT.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDILEN_SIFAT.AreaIndex = 5;
            fieldDAVA_EDILEN_SIFAT.FieldName = "DAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Name = "fieldDAVA_EDILEN_SIFAT";
            fieldDAVA_EDILEN_SIFAT.Visible = false;

            PivotGridField fieldDAVA_TALEP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TALEP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TALEP.AreaIndex = 6;
            fieldDAVA_TALEP.FieldName = "DAVA_TALEP";
            fieldDAVA_TALEP.Name = "fieldDAVA_TALEP";
            fieldDAVA_TALEP.Visible = false;

            PivotGridField fieldREFERANS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO.AreaIndex = 7;
            fieldREFERANS_NO.FieldName = "REFERANS_NO";
            fieldREFERANS_NO.Name = "fieldREFERANS_NO";
            fieldREFERANS_NO.Visible = false;

            PivotGridField fieldREFERANS_NO2 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO2.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO2.AreaIndex = 8;
            fieldREFERANS_NO2.FieldName = "REFERANS_NO2";
            fieldREFERANS_NO2.Name = "fieldREFERANS_NO2";
            fieldREFERANS_NO2.Visible = false;

            PivotGridField fieldREFERANS_NO3 = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldREFERANS_NO3.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldREFERANS_NO3.AreaIndex = 9;
            fieldREFERANS_NO3.FieldName = "REFERANS_NO3";
            fieldREFERANS_NO3.Name = "fieldREFERANS_NO3";
            fieldREFERANS_NO3.Visible = false;

            PivotGridField fieldDAVA_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_TARIHI.AreaIndex = 10;
            fieldDAVA_TARIHI.FieldName = "DAVA_TARIHI";
            fieldDAVA_TARIHI.Name = "fieldDAVA_TARIHI";
            fieldDAVA_TARIHI.Visible = false;

            PivotGridField fieldESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldESAS_NO.AreaIndex = 11;
            fieldESAS_NO.FieldName = "ESAS_NO";
            fieldESAS_NO.Name = "fieldESAS_NO";
            fieldESAS_NO.Visible = false;

            PivotGridField fieldADLIYE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldADLIYE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldADLIYE.AreaIndex = 12;
            fieldADLIYE.FieldName = "ADLIYE";
            fieldADLIYE.Name = "fieldADLIYE";
            fieldADLIYE.Visible = false;

            PivotGridField fieldNO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldNO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldNO.AreaIndex = 13;
            fieldNO.FieldName = "NO";
            fieldNO.Name = "fieldNO";
            fieldNO.Visible = false;

            PivotGridField fieldGOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGOREV.AreaIndex = 14;
            fieldGOREV.FieldName = "GOREV";
            fieldGOREV.Name = "fieldGOREV";
            fieldGOREV.Visible = false;

            PivotGridField fieldFOY_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFOY_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFOY_NO.AreaIndex = 15;
            fieldFOY_NO.FieldName = "FOY_NO";
            fieldFOY_NO.Name = "fieldFOY_NO";
            fieldFOY_NO.Visible = false;

            PivotGridField fieldDIGER_DAVA_NEDEN = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDIGER_DAVA_NEDEN.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDIGER_DAVA_NEDEN.AreaIndex = 16;
            fieldDIGER_DAVA_NEDEN.FieldName = "DIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Name = "fieldDIGER_DAVA_NEDEN";
            fieldDIGER_DAVA_NEDEN.Visible = false;

            PivotGridField fieldFAIZ_KARAR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldFAIZ_KARAR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldFAIZ_KARAR_TARIHI.AreaIndex = 17;
            fieldFAIZ_KARAR_TARIHI.FieldName = "FAIZ_KARAR_TARIHI";
            fieldFAIZ_KARAR_TARIHI.Name = "fieldFAIZ_KARAR_TARIHI";
            fieldFAIZ_KARAR_TARIHI.Visible = false;

            PivotGridField fieldTUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR.AreaIndex = 18;
            fieldTUTAR.FieldName = "TUTAR";
            fieldTUTAR.Name = "fieldTUTAR";
            fieldTUTAR.Visible = false;

            PivotGridField fieldTUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTUTAR_DOVIZ_ID.AreaIndex = 19;
            fieldTUTAR_DOVIZ_ID.FieldName = "TUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Name = "fieldTUTAR_DOVIZ_ID";
            fieldTUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldDAVA_EDILEN_TUTAR = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDILEN_TUTAR.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDILEN_TUTAR.AreaIndex = 20;
            fieldDAVA_EDILEN_TUTAR.FieldName = "DAVA_EDILEN_TUTAR";
            fieldDAVA_EDILEN_TUTAR.Name = "fieldDAVA_EDILEN_TUTAR";
            fieldDAVA_EDILEN_TUTAR.Visible = false;

            PivotGridField fieldDAVA_EDILEN_TUTAR_DOVIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.AreaIndex = 21;
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.FieldName = "DAVA_EDILEN_TUTAR_DOVIZ_ID";
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.Name = "fieldDAVA_EDILEN_TUTAR_DOVIZ_ID";
            fieldDAVA_EDILEN_TUTAR_DOVIZ_ID.Visible = false;

            PivotGridField fieldKARAR_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARAR_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARAR_NO.AreaIndex = 22;
            fieldKARAR_NO.FieldName = "KARAR_NO";
            fieldKARAR_NO.Name = "fieldKARAR_NO";
            fieldKARAR_NO.Visible = false;

            PivotGridField fieldKESINLESME_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKESINLESME_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKESINLESME_TARIHI.AreaIndex = 23;
            fieldKESINLESME_TARIHI.FieldName = "KESINLESME_TARIHI";
            fieldKESINLESME_TARIHI.Name = "fieldKESINLESME_TARIHI";
            fieldKESINLESME_TARIHI.Visible = false;

            PivotGridField fieldHUKUM_TEBLIG_TEFHIM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.AreaIndex = 24;
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.FieldName = "HUKUM_TEBLIG_TEFHIM_TARIHI";
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.Name = "fieldHUKUM_TEBLIG_TEFHIM_TARIHI";
            fieldHUKUM_TEBLIG_TEFHIM_TARIHI.Visible = false;

            PivotGridField fieldHUKUM_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldHUKUM_TARAF.AreaIndex = 25;
            fieldHUKUM_TARAF.FieldName = "HUKUM_TARAF";
            fieldHUKUM_TARAF.Name = "fieldHUKUM_TARAF";
            fieldHUKUM_TARAF.Visible = false;

            PivotGridField fieldHUKUM_ANLAM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldHUKUM_ANLAM.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            fieldHUKUM_ANLAM.AreaIndex = 26;
            fieldHUKUM_ANLAM.FieldName = "HUKUM_ANLAM";
            fieldHUKUM_ANLAM.Name = "fieldHUKUM_ANLAM";
            fieldHUKUM_ANLAM.Visible = true;

            PivotGridField fieldSURE_TUTUM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSURE_TUTUM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSURE_TUTUM_TARIHI.AreaIndex = 27;
            fieldSURE_TUTUM_TARIHI.FieldName = "SURE_TUTUM_TARIHI";
            fieldSURE_TUTUM_TARIHI.Name = "fieldSURE_TUTUM_TARIHI";
            fieldSURE_TUTUM_TARIHI.Visible = false;

            PivotGridField fieldTEFHIM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEFHIM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEFHIM_TARIHI.AreaIndex = 28;
            fieldTEFHIM_TARIHI.FieldName = "TEFHIM_TARIHI";
            fieldTEFHIM_TARIHI.Name = "fieldTEFHIM_TARIHI";
            fieldTEFHIM_TARIHI.Visible = false;

            PivotGridField fieldTEMYIZ_TEBLIG_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_TEBLIG_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_TEBLIG_TARIHI.AreaIndex = 29;
            fieldTEMYIZ_TEBLIG_TARIHI.FieldName = "TEMYIZ_TEBLIG_TARIHI";
            fieldTEMYIZ_TEBLIG_TARIHI.Name = "fieldTEMYIZ_TEBLIG_TARIHI";
            fieldTEMYIZ_TEBLIG_TARIHI.Visible = false;

            PivotGridField fieldTEDBIRIN_KALDIRILMASI_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEDBIRIN_KALDIRILMASI_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEDBIRIN_KALDIRILMASI_TARIHI.AreaIndex = 30;
            fieldTEDBIRIN_KALDIRILMASI_TARIHI.FieldName = "TEDBIRIN_KALDIRILMASI_TARIHI";
            fieldTEDBIRIN_KALDIRILMASI_TARIHI.Name = "fieldTEDBIRIN_KALDIRILMASI_TARIHI";
            fieldTEDBIRIN_KALDIRILMASI_TARIHI.Visible = false;

            PivotGridField fieldTEDBIR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEDBIR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEDBIR_TARIHI.AreaIndex = 31;
            fieldTEDBIR_TARIHI.FieldName = "TEDBIR_TARIHI";
            fieldTEDBIR_TARIHI.Name = "fieldTEDBIR_TARIHI";
            fieldTEDBIR_TARIHI.Visible = false;

            PivotGridField fieldTEDBIR_ISTEM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEDBIR_ISTEM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEDBIR_ISTEM_TARIHI.AreaIndex = 32;
            fieldTEDBIR_ISTEM_TARIHI.FieldName = "TEDBIR_ISTEM_TARIHI";
            fieldTEDBIR_ISTEM_TARIHI.Name = "fieldTEDBIR_ISTEM_TARIHI";
            fieldTEDBIR_ISTEM_TARIHI.Visible = false;

            PivotGridField fieldACIKLAMA = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldACIKLAMA.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldACIKLAMA.AreaIndex = 33;
            fieldACIKLAMA.FieldName = "ACIKLAMA";
            fieldACIKLAMA.Name = "fieldACIKLAMA";
            fieldACIKLAMA.Visible = false;

            PivotGridField fieldYASAL_NEDENLER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYASAL_NEDENLER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldYASAL_NEDENLER.AreaIndex = 34;
            fieldYASAL_NEDENLER.FieldName = "YASAL_NEDENLER";
            fieldYASAL_NEDENLER.Name = "fieldYASAL_NEDENLER";
            fieldYASAL_NEDENLER.Visible = false;

            PivotGridField fieldUSUL_NEDENLER = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldUSUL_NEDENLER.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldUSUL_NEDENLER.AreaIndex = 35;
            fieldUSUL_NEDENLER.FieldName = "USUL_NEDENLER";
            fieldUSUL_NEDENLER.Name = "fieldUSUL_NEDENLER";
            fieldUSUL_NEDENLER.Visible = false;

            PivotGridField fieldTEMYIZ_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_TARIHI.AreaIndex = 36;
            fieldTEMYIZ_TARIHI.FieldName = "TEMYIZ_TARIHI";
            fieldTEMYIZ_TARIHI.Name = "fieldTEMYIZ_TARIHI";
            fieldTEMYIZ_TARIHI.Visible = false;

            PivotGridField fieldTEMYIZ_TARAF = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_TARAF.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_TARAF.AreaIndex = 37;
            fieldTEMYIZ_TARAF.FieldName = "TEMYIZ_TARAF";
            fieldTEMYIZ_TARAF.Name = "fieldTEMYIZ_TARAF";
            fieldTEMYIZ_TARAF.Visible = false;

            PivotGridField fieldGEREKCE = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldGEREKCE.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldGEREKCE.AreaIndex = 38;
            fieldGEREKCE.FieldName = "GEREKCE";
            fieldGEREKCE.Name = "fieldGEREKCE";
            fieldGEREKCE.Visible = false;

            PivotGridField fieldKARAR_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARAR_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARAR_TIP.AreaIndex = 39;
            fieldKARAR_TIP.FieldName = "KARAR_TIP";
            fieldKARAR_TIP.Name = "fieldKARAR_TIP";
            fieldKARAR_TIP.Visible = false;

            PivotGridField fieldTEMYIZ_KARAR_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_KARAR_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_KARAR_NO.AreaIndex = 40;
            fieldTEMYIZ_KARAR_NO.FieldName = "TEMYIZ_KARAR_NO";
            fieldTEMYIZ_KARAR_NO.Name = "fieldTEMYIZ_KARAR_NO";
            fieldTEMYIZ_KARAR_NO.Visible = false;

            PivotGridField fieldKARAR_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKARAR_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKARAR_TARIHI.AreaIndex = 41;
            fieldKARAR_TARIHI.FieldName = "KARAR_TARIHI";
            fieldKARAR_TARIHI.Name = "fieldKARAR_TARIHI";
            fieldKARAR_TARIHI.Visible = false;

            PivotGridField fieldTEMYIZ_ESAS_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_ESAS_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_ESAS_NO.AreaIndex = 42;
            fieldTEMYIZ_ESAS_NO.FieldName = "TEMYIZ_ESAS_NO";
            fieldTEMYIZ_ESAS_NO.Name = "fieldTEMYIZ_ESAS_NO";
            fieldTEMYIZ_ESAS_NO.Visible = false;

            PivotGridField fieldTEMYIZ_GOREV = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_GOREV.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_GOREV.AreaIndex = 43;
            fieldTEMYIZ_GOREV.FieldName = "TEMYIZ_GOREV";
            fieldTEMYIZ_GOREV.Name = "fieldTEMYIZ_GOREV";
            fieldTEMYIZ_GOREV.Visible = false;

            PivotGridField fieldTEMYIZ_MAHKEME = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_MAHKEME.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_MAHKEME.AreaIndex = 44;
            fieldTEMYIZ_MAHKEME.FieldName = "TEMYIZ_MAHKEME";
            fieldTEMYIZ_MAHKEME.Name = "fieldTEMYIZ_MAHKEME";
            fieldTEMYIZ_MAHKEME.Visible = false;

            PivotGridField fieldTEMYIZ_BIRIM_NO = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_BIRIM_NO.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_BIRIM_NO.AreaIndex = 45;
            fieldTEMYIZ_BIRIM_NO.FieldName = "TEMYIZ_BIRIM_NO";
            fieldTEMYIZ_BIRIM_NO.Name = "fieldTEMYIZ_BIRIM_NO";
            fieldTEMYIZ_BIRIM_NO.Visible = false;

            PivotGridField fieldYUKSEK_MAHKEME_GONDERIM_TARIHI = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.AreaIndex = 46;
            fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.FieldName = "YUKSEK_MAHKEME_GONDERIM_TARIHI";
            fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.Name = "fieldYUKSEK_MAHKEME_GONDERIM_TARIHI";
            fieldYUKSEK_MAHKEME_GONDERIM_TARIHI.Visible = false;

            PivotGridField fieldTEMYIZ_TIP = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_TIP.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_TIP.AreaIndex = 47;
            fieldTEMYIZ_TIP.FieldName = "TEMYIZ_TIP";
            fieldTEMYIZ_TIP.Name = "fieldTEMYIZ_TIP";
            fieldTEMYIZ_TIP.Visible = false;

            PivotGridField fieldSUBE_KOD_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldSUBE_KOD_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldSUBE_KOD_ID.AreaIndex = 48;
            fieldSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            fieldSUBE_KOD_ID.Name = "fieldSUBE_KOD_ID";
            fieldSUBE_KOD_ID.Visible = false;

            PivotGridField fieldKONTROL_KIM_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldKONTROL_KIM_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldKONTROL_KIM_ID.AreaIndex = 49;
            fieldKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Name = "fieldKONTROL_KIM_ID";
            fieldKONTROL_KIM_ID.Visible = false;

            PivotGridField fieldDAVA_FOY_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldDAVA_FOY_ID.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            fieldDAVA_FOY_ID.Caption = "Dosya Sayısı";
            fieldDAVA_FOY_ID.AreaIndex = 50;
            fieldDAVA_FOY_ID.FieldName = "DAVA_FOY_ID";
            fieldDAVA_FOY_ID.Name = "fieldDAVA_FOY_ID";
            fieldDAVA_FOY_ID.Visible = true;

            PivotGridField fieldTEMYIZ_ID = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldTEMYIZ_ID.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldTEMYIZ_ID.AreaIndex = 51;
            fieldTEMYIZ_ID.FieldName = "TEMYIZ_ID";
            fieldTEMYIZ_ID.Name = "fieldTEMYIZ_ID";
            fieldTEMYIZ_ID.Visible = false;

            PivotGridField fieldBOLUM = new DevExpress.XtraPivotGrid.PivotGridField();
            fieldBOLUM.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
            fieldBOLUM.AreaIndex = 52;
            fieldBOLUM.FieldName = "BOLUM";
            fieldBOLUM.Name = "fieldBOLUM";
            fieldBOLUM.Visible = false;

            #endregion

            #region []

            PivotGridField[] dizi = new PivotGridField[]
		{
			fieldSORUMLU,
			fieldIZLEYEN,
			fieldDAVACI,
			fieldDAVALI,
			fieldDAVA_EDEN_SIFAT,
			fieldDAVA_EDILEN_SIFAT,
			fieldDAVA_TALEP,
			fieldREFERANS_NO,
			fieldREFERANS_NO2,
			fieldREFERANS_NO3,
			fieldDAVA_TARIHI,
			fieldESAS_NO,
			fieldADLIYE,
			fieldNO,
			fieldGOREV,
			fieldFOY_NO,
			fieldDIGER_DAVA_NEDEN,
			fieldFAIZ_KARAR_TARIHI,
			fieldTUTAR,
			fieldTUTAR_DOVIZ_ID,
			fieldDAVA_EDILEN_TUTAR,
			fieldDAVA_EDILEN_TUTAR_DOVIZ_ID,
			fieldKARAR_NO,
			fieldKESINLESME_TARIHI,
			fieldHUKUM_TEBLIG_TEFHIM_TARIHI,
			fieldHUKUM_TARAF,
			fieldHUKUM_ANLAM,
			fieldSURE_TUTUM_TARIHI,
			fieldTEFHIM_TARIHI,
			fieldTEMYIZ_TEBLIG_TARIHI,
			fieldTEDBIRIN_KALDIRILMASI_TARIHI,
			fieldTEDBIR_TARIHI,
			fieldTEDBIR_ISTEM_TARIHI,
			fieldACIKLAMA,
			fieldYASAL_NEDENLER,
			fieldUSUL_NEDENLER,
			fieldTEMYIZ_TARIHI,
			fieldTEMYIZ_TARAF,
			fieldGEREKCE,
			fieldKARAR_TIP,
			fieldTEMYIZ_KARAR_NO,
			fieldKARAR_TARIHI,
			fieldTEMYIZ_ESAS_NO,
			fieldTEMYIZ_GOREV,
			fieldTEMYIZ_MAHKEME,
			fieldTEMYIZ_BIRIM_NO,
			fieldYUKSEK_MAHKEME_GONDERIM_TARIHI,
			fieldTEMYIZ_TIP,
			fieldSUBE_KOD_ID,
			fieldKONTROL_KIM_ID,
			fieldDAVA_FOY_ID,
			fieldTEMYIZ_ID,
            fieldBOLUM,
			};

            #endregion

            #region Field Caption

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
                {
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTips.ValueText = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }

                if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
                {
                    dizi[i].FieldEdit = editler["DovizId"];
                    dizi[i].Caption = "Brm";
                    dizi[i].ToolTips.ValueText = dizi[i].FieldName.Replace('_', ' ').Replace("ID", " ").ToString();
                }
                else if (editler.ContainsKey(dizi[i].FieldName))
                    dizi[i].FieldEdit = editler[dizi[i].FieldName];
            }

            #endregion

            return dizi;
        }

        private Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Özelleştirme

            string RefNo, RefNo2, refNo3, OzelKod1, OzelKod2, OzelKod3, OzelKod4, DNRefNo, DNRefNo2;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans1))
                RefNo = "Ref No";
            else
                RefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans2))
                RefNo2 = "Ref No2";
            else
                RefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans3))
                refNo3 = "Ref No3";
            else
                refNo3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaReferans.Referans3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod1))
                OzelKod1 = "Özel Kod1";
            else
                OzelKod1 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod1;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod2))
                OzelKod2 = "Özel Kod2";
            else
                OzelKod2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod2;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod3))
                OzelKod3 = "Özel Kod3";
            else
                OzelKod3 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod3;

            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod4))
                OzelKod4 = "Özel Kod4";
            else
                OzelKod4 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaOzelKod.OzelKod4;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans1))
                DNRefNo = "Dava Neden Ref No1";
            else
                DNRefNo = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans1;
            if (string.IsNullOrEmpty(AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans2))
                DNRefNo2 = "Dava Neden Ref No2";
            else
                DNRefNo2 = AvukatProRaporlar.Raport.Util.Kimlikci.Kimlik.DavaDnReferans.Referans2;

            #endregion

            #region Caption Edit

            dicFieldCaption.Add("SORUMLU", "Sorumlu");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("DAVACI", "Davacı");
            dicFieldCaption.Add("DAVALI", "Davalı");
            dicFieldCaption.Add("DAVA_EDEN_SIFAT", "Davacı Sıfat");
            dicFieldCaption.Add("DAVA_EDILEN_SIFAT", "Davalı Sıfat");
            dicFieldCaption.Add("DAVA_TALEP", "Dava Talep");
            dicFieldCaption.Add("REFERANS_NO", RefNo);
            dicFieldCaption.Add("REFERANS_NO2", RefNo2);
            dicFieldCaption.Add("REFERANS_NO3", refNo3);
            dicFieldCaption.Add("DAVA_TARIHI", "Dava T.");
            dicFieldCaption.Add("ESAS_NO", "Esas No");
            dicFieldCaption.Add("ADLIYE", "Adliye");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("GOREV", "Görev");
            dicFieldCaption.Add("FOY_NO", "Dosya No");
            dicFieldCaption.Add("DIGER_DAVA_NEDEN", "Diğer Dava Neden");
            dicFieldCaption.Add("FAIZ_KARAR_TARIHI", "Faiz Karar T.");
            dicFieldCaption.Add("TUTAR", "Tutar");
            dicFieldCaption.Add("DAVA_EDILEN_TUTAR", "Dava Edilen Tutar");
            dicFieldCaption.Add("KARAR_NO", "Karar No");
            dicFieldCaption.Add("KESINLESME_TARIHI", "Kesinleşme T.");
            dicFieldCaption.Add("HUKUM_TEBLIG_TEFHIM_TARIHI", "Hukum Tebliğ Tefhim T.");
            dicFieldCaption.Add("HUKUM_TARAF", "Hüküm Taraf");
            dicFieldCaption.Add("HUKUM_ANLAM", "Hüküm Anlam");
            dicFieldCaption.Add("SURE_TUTUM_TARIHI", "Süre Tutum T.");
            dicFieldCaption.Add("TEFHIM_TARIHI", "Tefhim T.");
            dicFieldCaption.Add("TEMYIZ_TEBLIG_TARIHI", "Temyiz Tebliğ T.");
            dicFieldCaption.Add("TEDBIRIN_KALDIRILMASI_TARIHI", "Tedbirin Kaldırılması T.");
            dicFieldCaption.Add("TEDBIR_TARIHI", "Tedbir T.");
            dicFieldCaption.Add("TEDBIR_ISTEM_TARIHI", "Tedbir İstem T.");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("YASAL_NEDENLER", "Yasal Nedenler");
            dicFieldCaption.Add("USUL_NEDENLER", "Usul Nedenler");
            dicFieldCaption.Add("TEMYIZ_TARIHI", "Temyiz T.");
            dicFieldCaption.Add("TEMYIZ_TARAF", "Temyiz T.");
            dicFieldCaption.Add("GEREKCE", "Gerekçe");
            dicFieldCaption.Add("KARAR_TIP", "Karar Tip");
            dicFieldCaption.Add("TEMYIZ_KARAR_NO", "Temyiz Karar No");
            dicFieldCaption.Add("KARAR_TARIHI", "Karar T.");
            dicFieldCaption.Add("TEMYIZ_ESAS_NO", "Temyiz Esas No");
            dicFieldCaption.Add("TEMYIZ_GOREV", "Temyiz Grv");
            dicFieldCaption.Add("TEMYIZ_MAHKEME", "Temyiz Mahkeme");
            dicFieldCaption.Add("TEMYIZ_BIRIM_NO", "Temyiz Birim No");
            dicFieldCaption.Add("YUKSEK_MAHKEME_GONDERIM_TARIHI", "Yüksek Mahkeme Gönderim T.");
            dicFieldCaption.Add("TEMYIZ_TIP", "Temyiz Tip");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("DAVA_FOY_ID", "");
            dicFieldCaption.Add("TEMYIZ_ID", "Kayıt Sayısı");
            dicFieldCaption.Add("BOLUM", "Bölüm");

            #endregion

            return dicFieldCaption;
        }

        private Dictionary<string, RepositoryItem> GetRepositoryItemDictinory()
        {
            //RepositoryItemLookUpEdit rlueDoviz = new RepositoryItemLookUpEdit();

            //Inits.DovizTipGetir(rlueDoviz);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("DovizId", InitsEx.DovizTipGetir);
            sozluk.Add("SUBE_KOD_ID", InitsEx.SubeKod);
            sozluk.Add("KONTROL_KIM_ID", InitsEx.KontrolKim);
            sozluk.Add("TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("TUTAR_DOVIZ_ID", InitsEx.DovizTipGetir);
            sozluk.Add("DAVA_EDILEN_TUTAR", InitsEx.ParaBicimiAyarla);
            sozluk.Add("DAVA_EDILEN_TUTAR_DOVIZ_ID", InitsEx.DovizTipGetir);

            #endregion

            return sozluk;
        }
    }
}