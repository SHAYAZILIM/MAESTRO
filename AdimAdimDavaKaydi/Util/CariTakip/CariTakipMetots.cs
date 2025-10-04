using System.Collections.Generic;
using System.Linq;
using AvukatProLib.Arama;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace AdimAdimDavaKaydi.Util.CariTakip
{
    public static class CariTakipMetots
    {
        #region DAVA

        public static int DavaDosyaSayisiGetByTarafAdi(int CariId)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predi = PredicateBuilder.True<AvukatProLib.Arama.AV001_TD_BIL_FOY>();
            var cari = db.AV001_TD_BIL_FOY_TARAFs.Where(vs => vs.CARI_ID == CariId);
            var Daval = cari.Select(I => I.DAVA_FOY_ID).ToList();
            predi = predi.And(vi => Daval.Contains(vi.ID));

            var sonuc = db.AV001_TD_BIL_FOYs.Where(predi).ToList();
            return sonuc.Count;
        }

        public static int DavaDosyaSayisiGetBySorumlu(int CariId)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predi = PredicateBuilder.True<AvukatProLib.Arama.AV001_TD_BIL_FOY>();
            var sorumlu = db.AV001_TD_BIL_FOY_SORUMLU_AVUKATs.Where(vs => vs.SORUMLU_AVUKAT_CARI_ID == CariId);
            var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
            predi = predi.And(vi => Davalar.Contains(vi.ID));
            var sonuc = db.AV001_TD_BIL_FOYs.Where(predi).ToList();
            return sonuc.Count;
        }
        
        public static List<AV001_TD_BIL_FOY> DavaDosyaDondurSrm(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TD_BIL_FOY>();

            var sorumlu = db.AV001_TD_BIL_FOY_SORUMLU_AVUKATs.Where(vs => vs.SORUMLU_AVUKAT_CARI_ID == CariID);
            var Davalar = sorumlu.Select(I => I.DAVA_FOY_ID).ToList();
            predicate = predicate.And(vi => Davalar.Contains(vi.ID));

            return db.AV001_TD_BIL_FOYs.Where(predicate).ToList();
        }

        public static List<AV001_TD_BIL_FOY> DavaDosyaDondurTrf(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TD_BIL_FOY>();

            var cari = db.AV001_TD_BIL_FOY_TARAFs.Where(vs => vs.CARI_ID == CariID);
            var Daval = cari.Select(I => I.DAVA_FOY_ID).ToList();
            predicate = predicate.And(vi => Daval.Contains(vi.ID));

            return db.AV001_TD_BIL_FOYs.Where(predicate).ToList();
        }

        #endregion

        #region ICRA

        public static int IcraDosyaSayisiTaraf(int CariId)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predi = PredicateBuilder.True<AvukatProLib.Arama.AV001_TI_BIL_FOY>();
            var cari = db.AV001_TI_BIL_FOY_TARAFs.Where(vs => vs.CARI_ID == CariId);
            var Daval = cari.Select(I => I.ICRA_FOY_ID).ToList();
            predi = predi.And(vi => Daval.Contains(vi.ID));
            var sonuc = db.AV001_TI_BIL_FOYs.Where(predi).ToList();
            return sonuc.Count;
        }

        public static int IcraDosyaSayisiSorumlu(int CariId)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predi = PredicateBuilder.True<AvukatProLib.Arama.AV001_TI_BIL_FOY>();
            var cari = db.AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(vs => vs.SORUMLU_AVUKAT_CARI_ID == CariId);
            var Daval = cari.Select(I => I.ICRA_FOY_ID).ToList();
            predi = predi.And(vi => Daval.Contains(vi.ID));
            var sonuc = db.AV001_TI_BIL_FOYs.Where(predi).ToList();
            return sonuc.Count;
        }

        public static List<AV001_TI_BIL_FOY> IcraDosyaDoldur(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TI_BIL_FOY>();
            var sorumlu = db.AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(vs => vs.SORUMLU_AVUKAT_CARI_ID == CariID);
            var Davalar = sorumlu.Select(I => I.ICRA_FOY_ID).ToList();
            if (Davalar.Count > 0)
                predicate = predicate.And(vi => Davalar.Contains(vi.ID));

            var cari = db.AV001_TI_BIL_FOY_TARAFs.Where(vs => vs.CARI_ID == CariID);
            var Daval = cari.Select(I => I.ICRA_FOY_ID).ToList();
            if (Daval.Count > 0)
                predicate = predicate.And(vi => Daval.Contains(vi.ID));

            return db.AV001_TI_BIL_FOYs.Where(predicate).ToList();
        }

        public static List<AV001_TDIE_BIL_BELGE> BelgeDosyaDoldur(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TDIE_BIL_BELGE>();
            var taraf = db.AV001_TDIE_BIL_BELGE_TARAFs.Where(vs => vs.CARI_ID == CariID);
            var Davalar = taraf.Select(I => I.BELGE_ID).ToList();
            int count = Davalar.Count;
            if (Davalar.Count > 0)
                predicate = predicate.And(vi => Davalar.Contains(vi.ID));
            else
                predicate = PredicateBuilder.False<AV001_TDIE_BIL_BELGE>();

            return db.AV001_TDIE_BIL_BELGEs.Where(predicate).ToList();
        }

        public static List<AV001_TI_BIL_FOY> IcraDosyaDoldurTrf(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TI_BIL_FOY>();
            var cari = db.AV001_TI_BIL_FOY_TARAFs.Where(vs => vs.CARI_ID == CariID);
            var Daval = cari.Select(I => I.ICRA_FOY_ID).ToList();
            predicate = predicate.And(vi => Daval.Contains(vi.ID));

            return db.AV001_TI_BIL_FOYs.Where(predicate).ToList();
        }

        public static List<AV001_TI_BIL_FOY> IcraDosyaDoldurSrm(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TI_BIL_FOY>();
            var sorumlu = db.AV001_TI_BIL_FOY_SORUMLU_AVUKATs.Where(vs => vs.SORUMLU_AVUKAT_CARI_ID == CariID);
            var Davalar = sorumlu.Select(I => I.ICRA_FOY_ID).ToList();
            predicate = predicate.And(vi => Davalar.Contains(vi.ID));

            return db.AV001_TI_BIL_FOYs.Where(predicate).ToList();
        }

        #endregion

        #region SORUSTURMA

        public static int SorusturmaDosyaSayisiTaraf(int CariId)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predi = PredicateBuilder.True<AvukatProLib.Arama.AV001_TD_BIL_HAZIRLIK>();
            var cari = db.AV001_TD_BIL_HAZIRLIK_TARAFs.Where(vs => vs.CARI_ID == CariId);
            var Daval = cari.Select(I => I.HAZIRLIK_ID).ToList();
            predi = predi.And(vi => Daval.Contains(vi.ID));
            var sonuc = db.AV001_TD_BIL_HAZIRLIKs.Where(predi).ToList();
            return sonuc.Count;
        }

        public static int SorusturmaDosyaSayisiSorumlu(int CariId)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predi = PredicateBuilder.True<AvukatProLib.Arama.AV001_TD_BIL_HAZIRLIK>();
            var cari = db.AV001_TD_BIL_HAZIRLIK_SORUMLUs.Where(vs => vs.CARI_ID == CariId);
            var Daval = cari.Select(I => I.HAZIRLIK_ID).ToList();
            predi = predi.And(vi => Daval.Contains(vi.ID));
            var sonuc = db.AV001_TD_BIL_HAZIRLIKs.Where(predi).ToList();
            return sonuc.Count;
        }

        public static List<AV001_TD_BIL_HAZIRLIK> SorusturmaDosyaDoldurTrf(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TD_BIL_HAZIRLIK>();
            var cari = db.AV001_TD_BIL_HAZIRLIK_TARAFs.Where(vs => vs.CARI_ID == CariID);
            var Daval = cari.Select(I => I.HAZIRLIK_ID).ToList();
            predicate = predicate.And(vi => Daval.Contains(vi.ID));

            return db.AV001_TD_BIL_HAZIRLIKs.Where(predicate).ToList();
        }

        public static List<AV001_TD_BIL_HAZIRLIK> SorusturmaDosyaDoldurSrm(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TD_BIL_HAZIRLIK>();
            var sorumlu = db.AV001_TD_BIL_HAZIRLIK_SORUMLUs.Where(vs => vs.CARI_ID == CariID);
            var Davalar = sorumlu.Select(I => I.HAZIRLIK_ID).ToList();
            predicate = predicate.And(vi => Davalar.Contains(vi.ID));

            return db.AV001_TD_BIL_HAZIRLIKs.Where(predicate).ToList();
        }

        #endregion

        #region SOZLESME

        public static int SozlesmeDosyaSayisiTaraf(int CariId)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predi = PredicateBuilder.True<AvukatProLib.Arama.AV001_TDI_BIL_SOZLESME>();
            var cari = db.AV001_TDI_BIL_SOZLESME_TARAFs.Where(vs => vs.CARI_ID == CariId);
            var Daval = cari.Select(I => I.SOZLESME_ID).ToList();
            predi = predi.And(vi => Daval.Contains(vi.ID));
            var sonuc = db.AV001_TDI_BIL_SOZLESMEs.Where(predi).ToList();
            return sonuc.Count;
        }

        public static int SozlesmeDosyaSayisiSorumlu(int CariId)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predi = PredicateBuilder.True<AvukatProLib.Arama.AV001_TDI_BIL_SOZLESME>();
            var cari = db.AV001_TDI_BIL_SOZLESME_SORUMLUs.Where(vs => vs.SORUMLU_CARI_ID == CariId);
            var Daval = cari.Select(I => I.SOZLESME_ID).ToList();
            predi = predi.And(vi => Daval.Contains(vi.ID));
            var sonuc = db.AV001_TDI_BIL_SOZLESMEs.Where(predi).ToList();
            return sonuc.Count;
        }

        public static List<AV001_TDI_BIL_SOZLESME> SozlesmeDosyaDoldurTrf(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TDI_BIL_SOZLESME>();
            var cari = db.AV001_TDI_BIL_SOZLESME_TARAFs.Where(vs => vs.CARI_ID == CariID);
            var Daval = cari.Select(I => I.SOZLESME_ID).ToList();
            predicate = predicate.And(vi => Daval.Contains(vi.ID));

            return db.AV001_TDI_BIL_SOZLESMEs.Where(predicate).ToList();
        }

        public static List<AV001_TDI_BIL_SOZLESME> SozlesmeDosyaDoldurSrm(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TDI_BIL_SOZLESME>();
            var sorumlu = db.AV001_TDI_BIL_SOZLESME_SORUMLUs.Where(vs => vs.SORUMLU_CARI_ID == CariID);
            var Davalar = sorumlu.Select(I => I.SOZLESME_ID).ToList();
            predicate = predicate.And(vi => Davalar.Contains(vi.ID));

            return db.AV001_TDI_BIL_SOZLESMEs.Where(predicate).ToList();
        }

        #endregion

        #region SorusturmaGird

        private static Dictionary<string, string> GetCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Caption Edit

            dicFieldCaption.Add("TAKIP_EDEN_CARI", "Müvekkil");
            dicFieldCaption.Add("TAKIP_EDILEN", "Karşı Taraf");
            dicFieldCaption.Add("TAKIP_EDEN_TARAF_SIFAT", "Müvekkil Sıfat");
            dicFieldCaption.Add("TAKIP_EDILEN_TARAF_SIFAT", "Karşı Taraf Sıfat");
            dicFieldCaption.Add("TAKIP_EDEN_TARAF_KODU", "Müvekkil T.K");
            dicFieldCaption.Add("TAKIP_EDILEN_TARAF_KODU", "Karşı Taraf T.K");
            dicFieldCaption.Add("IZLEYEN_AVUKAT", "İzleyen");
            dicFieldCaption.Add("SORUMLU_SAVCI1", "Sorumlu Savcı");
            dicFieldCaption.Add("SORUMLU_SAVCI2", "Sorumlu Savcı2");
            dicFieldCaption.Add("KONTROL_KIM", "Kullanıcı");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("REFERANS_NO3", "Ref No3");
            dicFieldCaption.Add("REFERANS_NO2", "Ref No2");
            dicFieldCaption.Add("HAZIRLIK_ESAS_NO", "Esas No");
            dicFieldCaption.Add("HAZIRLIK_TARIH", "Soruşturma T.");
            dicFieldCaption.Add("SIKAYET_TARIHI", "Şikayet T.");
            dicFieldCaption.Add("HAZIRLIK_NO", "Dosya No");
            dicFieldCaption.Add("SORUMLU_AVUKAT", "Sorumlu");
            dicFieldCaption.Add("SIKAYET_KONU", "Şikayet Neden");
            dicFieldCaption.Add("HAZIRLIK_DURUM", "Durum");
            dicFieldCaption.Add("ADLI_BIRIM_ADLIYE", "Mahkeme");
            dicFieldCaption.Add("ADLI_BIRIM_GOREV", "Görev");
            dicFieldCaption.Add("ADLI_BIRIM_NO", "No");
            dicFieldCaption.Add("OZEL_KOD1", "Özel Kod1");
            dicFieldCaption.Add("OZEL_KOD2", "Özel Kod2");
            dicFieldCaption.Add("OZEL_KOD3", "Özel Kod3");
            dicFieldCaption.Add("OZEL_KOD4", "Özel Kod4");
            dicFieldCaption.Add("REFERANS_NO", "Ref No");

            #endregion

            return dicFieldCaption;
        }

        private static Dictionary<string, string> GetSozlesmeCaptionDictinory()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Caption Edit

            dicFieldCaption.Add("TAKIP_EDEN_TARAF_KODU", "Takip Eden T.K");
            dicFieldCaption.Add("TAKIP_EDEN_TARAF_SIFAT_ID", "Takip Eden Sıfat");
            dicFieldCaption.Add("TAKIP_EDILEN_TARAF_KODU", "Takip Edilen T.K");
            dicFieldCaption.Add("TAKIP_EDILEN_TARAF_SIFAT_ID", "Takip Edilen Sıfa");
            dicFieldCaption.Add("SOZLESME_NO", "Dosya No");
            dicFieldCaption.Add("TIP_ID", "Tip");
            dicFieldCaption.Add("TUR", "Tur");
            dicFieldCaption.Add("SOZLESME_ADI", "Adı");
            dicFieldCaption.Add("ACIKLAMA", "Açıklama");
            dicFieldCaption.Add("ALT_TIP", "Alt Tip");
            dicFieldCaption.Add("TIP", "Tip");
            dicFieldCaption.Add("OZEL_KOD1", "Özel Kod");
            dicFieldCaption.Add("OZEL_KOD2", "Özel Kod2");
            dicFieldCaption.Add("OZEL_KOD3", "Özel Kod3");
            dicFieldCaption.Add("OZEL_KOD4", "Özel Kod4");
            dicFieldCaption.Add("ADLIYE", "Noter");
            dicFieldCaption.Add("GOREV", "Grv");
            dicFieldCaption.Add("NO", "No");
            dicFieldCaption.Add("SUBE_KOD_ID", "Büro");
            dicFieldCaption.Add("KONTROL_KIM_ID", "Kullanıcı");
            dicFieldCaption.Add("TAKIP_EDEN", "Müvekkil");
            dicFieldCaption.Add("TAKIP_EDILEN", "Karşı Taraf");
            dicFieldCaption.Add("IZLEYEN", "İzleyen");
            dicFieldCaption.Add("SORUMLU", "Sorumlu");

            #endregion

            return dicFieldCaption;
        }

        private static Dictionary<string, RepositoryItem> GetRepositorySozlesmeItemDictinory()
        {
            RepositoryItemLookUpEdit rlueSubeKod = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueKontrolKim = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rluesifat = new RepositoryItemLookUpEdit();
            BelgeUtil.Inits.SubeKodGetir(rlueSubeKod);
            BelgeUtil.Inits.KontrolKimGetir(rlueKontrolKim);
            BelgeUtil.Inits.TarafSifatGetir(rluesifat);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("SUBE_KOD_ID", rlueSubeKod);
            sozluk.Add("KONTROL_KIM_ID", rlueKontrolKim);
            sozluk.Add("TAKIP_EDEN_TARAF_SIFAT_ID", rluesifat);
            sozluk.Add("TAKIP_EDILEN_TARAF_SIFAT_ID", rluesifat);

            #endregion

            return sozluk;
        }

        private static Dictionary<string, RepositoryItem> GetRepositoryItemSorusturmDictinory()
        {
            RepositoryItemLookUpEdit rlueTK = new RepositoryItemLookUpEdit();

            //Inits.DovizTipGetir(rlueDoviz);

            BelgeUtil.Inits.TarafKoduGetir(rlueTK);
            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            //sozluk.Add("DovizId", rlueDoviz);

            sozluk.Add("TAKIP_EDEN_TARAF_KODU", rlueTK);
            sozluk.Add("TAKIP_EDILEN_TARAF_KODU", rlueTK);
            //sozluk.Add("TAKIP_EDILEN_CARI_ID", Item);
            //sozluk.Add("IZLEYEN_AVUKAT_CARI_ID", Item);

            #endregion

            return sozluk;
        }

        public static GridColumn[] GetSorumluEvrakGird()
        {
            #region Field & Properties

            GridColumn colTAKIP_EDEN_CARI = new GridColumn();
            colTAKIP_EDEN_CARI.VisibleIndex = 4;
            colTAKIP_EDEN_CARI.FieldName = "TAKIP_EDEN_CARI";
            colTAKIP_EDEN_CARI.Name = "colTAKIP_EDEN_CARI";
            colTAKIP_EDEN_CARI.OptionsColumn.AllowEdit = false;
            colTAKIP_EDEN_CARI.OptionsColumn.ReadOnly = true;
            colTAKIP_EDEN_CARI.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 7;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.OptionsColumn.AllowEdit = false;
            colTAKIP_EDILEN.OptionsColumn.ReadOnly = true;
            colTAKIP_EDILEN.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_SIFAT = new GridColumn();
            colTAKIP_EDEN_TARAF_SIFAT.VisibleIndex = 3;
            colTAKIP_EDEN_TARAF_SIFAT.FieldName = "TAKIP_EDEN_TARAF_SIFAT";
            colTAKIP_EDEN_TARAF_SIFAT.Name = "colTAKIP_EDEN_TARAF_SIFAT";
            colTAKIP_EDEN_TARAF_SIFAT.OptionsColumn.AllowEdit = false;
            colTAKIP_EDEN_TARAF_SIFAT.OptionsColumn.ReadOnly = true;
            colTAKIP_EDEN_TARAF_SIFAT.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_SIFAT = new GridColumn();
            colTAKIP_EDILEN_TARAF_SIFAT.VisibleIndex = 6;
            colTAKIP_EDILEN_TARAF_SIFAT.FieldName = "TAKIP_EDILEN_TARAF_SIFAT";
            colTAKIP_EDILEN_TARAF_SIFAT.Name = "colTAKIP_EDILEN_TARAF_SIFAT";
            colTAKIP_EDILEN_TARAF_SIFAT.OptionsColumn.AllowEdit = false;
            colTAKIP_EDILEN_TARAF_SIFAT.OptionsColumn.ReadOnly = true;
            colTAKIP_EDILEN_TARAF_SIFAT.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDEN_TARAF_KODU.VisibleIndex = 2;
            colTAKIP_EDEN_TARAF_KODU.FieldName = "TAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.Name = "colTAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.OptionsColumn.AllowEdit = false;
            colTAKIP_EDEN_TARAF_KODU.OptionsColumn.ReadOnly = true;
            colTAKIP_EDEN_TARAF_KODU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDILEN_TARAF_KODU.VisibleIndex = 5;
            colTAKIP_EDILEN_TARAF_KODU.FieldName = "TAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.Name = "colTAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.OptionsColumn.AllowEdit = false;
            colTAKIP_EDILEN_TARAF_KODU.OptionsColumn.ReadOnly = true;
            colTAKIP_EDILEN_TARAF_KODU.Visible = true;

            GridColumn colIZLEYEN_AVUKAT = new GridColumn();
            colIZLEYEN_AVUKAT.VisibleIndex = 9;
            colIZLEYEN_AVUKAT.FieldName = "IZLEYEN_AVUKAT";
            colIZLEYEN_AVUKAT.Name = "colIZLEYEN_AVUKAT";
            colIZLEYEN_AVUKAT.OptionsColumn.AllowEdit = false;
            colIZLEYEN_AVUKAT.OptionsColumn.ReadOnly = true;
            colIZLEYEN_AVUKAT.Visible = true;

            GridColumn colSORUMLU_SAVCI1 = new GridColumn();
            colSORUMLU_SAVCI1.VisibleIndex = 10;
            colSORUMLU_SAVCI1.FieldName = "SORUMLU_SAVCI1";
            colSORUMLU_SAVCI1.Name = "colSORUMLU_SAVCI1";
            colSORUMLU_SAVCI1.OptionsColumn.AllowEdit = false;
            colSORUMLU_SAVCI1.OptionsColumn.ReadOnly = true;
            colSORUMLU_SAVCI1.Visible = true;

            GridColumn colSORUMLU_SAVCI2 = new GridColumn();
            colSORUMLU_SAVCI2.VisibleIndex = 11;
            colSORUMLU_SAVCI2.FieldName = "SORUMLU_SAVCI2";
            colSORUMLU_SAVCI2.Name = "colSORUMLU_SAVCI2";
            colSORUMLU_SAVCI2.OptionsColumn.AllowEdit = false;
            colSORUMLU_SAVCI2.OptionsColumn.ReadOnly = true;
            colSORUMLU_SAVCI2.Visible = true;

            GridColumn colKONTROL_KIM = new GridColumn();
            colKONTROL_KIM.VisibleIndex = 12;
            colKONTROL_KIM.FieldName = "KONTROL_KIM";
            colKONTROL_KIM.Name = "colKONTROL_KIM";
            colKONTROL_KIM.OptionsColumn.AllowEdit = false;
            colKONTROL_KIM.OptionsColumn.ReadOnly = true;
            colKONTROL_KIM.Visible = true;

            GridColumn colKAYIT_TARIHI = new GridColumn();
            colKAYIT_TARIHI.VisibleIndex = 10;
            colKAYIT_TARIHI.FieldName = "KAYIT_TARIHI";
            colKAYIT_TARIHI.Name = "colKAYIT_TARIHI";
            colKAYIT_TARIHI.OptionsColumn.AllowEdit = false;
            colKAYIT_TARIHI.OptionsColumn.ReadOnly = true;
            colKAYIT_TARIHI.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 13;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.OptionsColumn.AllowEdit = false;
            colACIKLAMA.OptionsColumn.ReadOnly = true;
            colACIKLAMA.Visible = true;

            GridColumn colREFERANS_NO3 = new GridColumn();
            colREFERANS_NO3.VisibleIndex = 16;
            colREFERANS_NO3.FieldName = "REFERANS_NO3";
            colREFERANS_NO3.Name = "colREFERANS_NO3";
            colREFERANS_NO3.OptionsColumn.AllowEdit = false;
            colREFERANS_NO3.OptionsColumn.ReadOnly = true;
            colREFERANS_NO3.Visible = true;

            GridColumn colREFERANS_NO2 = new GridColumn();
            colREFERANS_NO2.VisibleIndex = 15;
            colREFERANS_NO2.FieldName = "REFERANS_NO2";
            colREFERANS_NO2.Name = "colREFERANS_NO2";
            colREFERANS_NO2.OptionsColumn.AllowEdit = false;
            colREFERANS_NO2.OptionsColumn.ReadOnly = true;
            colREFERANS_NO2.Visible = true;

            GridColumn colHAZIRLIK_ESAS_NO = new GridColumn();
            colHAZIRLIK_ESAS_NO.VisibleIndex = 17;
            colHAZIRLIK_ESAS_NO.FieldName = "HAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.Name = "colHAZIRLIK_ESAS_NO";
            colHAZIRLIK_ESAS_NO.OptionsColumn.AllowEdit = false;
            colHAZIRLIK_ESAS_NO.OptionsColumn.ReadOnly = true;
            colHAZIRLIK_ESAS_NO.Visible = true;

            GridColumn colHAZIRLIK_TARIH = new GridColumn();
            colHAZIRLIK_TARIH.VisibleIndex = 18;
            colHAZIRLIK_TARIH.FieldName = "HAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.Name = "colHAZIRLIK_TARIH";
            colHAZIRLIK_TARIH.OptionsColumn.AllowEdit = false;
            colHAZIRLIK_TARIH.OptionsColumn.ReadOnly = true;
            colHAZIRLIK_TARIH.Visible = true;

            GridColumn colSIKAYET_TARIHI = new GridColumn();
            colSIKAYET_TARIHI.VisibleIndex = 19;
            colSIKAYET_TARIHI.FieldName = "SIKAYET_TARIHI";
            colSIKAYET_TARIHI.Name = "colSIKAYET_TARIHI";
            colSIKAYET_TARIHI.OptionsColumn.AllowEdit = false;
            colSIKAYET_TARIHI.OptionsColumn.ReadOnly = true;
            colSIKAYET_TARIHI.Visible = true;

            GridColumn colHAZIRLIK_NO = new GridColumn();
            colHAZIRLIK_NO.VisibleIndex = 0;
            colHAZIRLIK_NO.FieldName = "HAZIRLIK_NO";
            colHAZIRLIK_NO.Name = "colHAZIRLIK_NO";
            colHAZIRLIK_NO.OptionsColumn.AllowEdit = false;
            colHAZIRLIK_NO.OptionsColumn.ReadOnly = true;
            colHAZIRLIK_NO.Visible = true;

            GridColumn colSORUMLU_AVUKAT_CARI_ID = new GridColumn();
            colSORUMLU_AVUKAT_CARI_ID.VisibleIndex = 8;
            colSORUMLU_AVUKAT_CARI_ID.FieldName = "SORUMLU_AVUKAT_CARI_ID";
            colSORUMLU_AVUKAT_CARI_ID.Name = "colSORUMLU_AVUKAT_CARI_ID";
            colSORUMLU_AVUKAT_CARI_ID.OptionsColumn.AllowEdit = false;
            colSORUMLU_AVUKAT_CARI_ID.OptionsColumn.ReadOnly = true;
            colSORUMLU_AVUKAT_CARI_ID.Visible = true;

            GridColumn colSORUMLU_AVUKAT = new GridColumn();
            colSORUMLU_AVUKAT.VisibleIndex = 19;
            colSORUMLU_AVUKAT.FieldName = "SORUMLU_AVUKAT";
            colSORUMLU_AVUKAT.Name = "colSORUMLU_AVUKAT";
            colSORUMLU_AVUKAT.OptionsColumn.AllowEdit = false;
            colSORUMLU_AVUKAT.OptionsColumn.ReadOnly = true;
            colSORUMLU_AVUKAT.Visible = true;

            GridColumn colSIKAYET_KONU = new GridColumn();
            colSIKAYET_KONU.VisibleIndex = 20;
            colSIKAYET_KONU.FieldName = "SIKAYET_KONU";
            colSIKAYET_KONU.Name = "colSIKAYET_KONU";
            colSIKAYET_KONU.OptionsColumn.AllowEdit = false;
            colSIKAYET_KONU.OptionsColumn.ReadOnly = true;
            colSIKAYET_KONU.Visible = true;

            GridColumn colHAZIRLIK_DURUM = new GridColumn();
            colHAZIRLIK_DURUM.VisibleIndex = 1;
            colHAZIRLIK_DURUM.FieldName = "HAZIRLIK_DURUM";
            colHAZIRLIK_DURUM.Name = "colHAZIRLIK_DURUM";
            colHAZIRLIK_DURUM.OptionsColumn.AllowEdit = false;
            colHAZIRLIK_DURUM.OptionsColumn.ReadOnly = true;
            colHAZIRLIK_DURUM.Visible = true;

            GridColumn colADLI_BIRIM_ADLIYE = new GridColumn();
            colADLI_BIRIM_ADLIYE.VisibleIndex = 21;
            colADLI_BIRIM_ADLIYE.FieldName = "ADLI_BIRIM_ADLIYE";
            colADLI_BIRIM_ADLIYE.Name = "colADLI_BIRIM_ADLIYE";
            colADLI_BIRIM_ADLIYE.OptionsColumn.AllowEdit = false;
            colADLI_BIRIM_ADLIYE.OptionsColumn.ReadOnly = true;
            colADLI_BIRIM_ADLIYE.Visible = true;

            GridColumn colADLI_BIRIM_GOREV = new GridColumn();
            colADLI_BIRIM_GOREV.VisibleIndex = 22;
            colADLI_BIRIM_GOREV.FieldName = "ADLI_BIRIM_GOREV";
            colADLI_BIRIM_GOREV.Name = "colADLI_BIRIM_GOREV";
            colADLI_BIRIM_GOREV.OptionsColumn.AllowEdit = false;
            colADLI_BIRIM_GOREV.OptionsColumn.ReadOnly = true;
            colADLI_BIRIM_GOREV.Visible = true;

            GridColumn colADLI_BIRIM_NO = new GridColumn();
            colADLI_BIRIM_NO.VisibleIndex = 23;
            colADLI_BIRIM_NO.FieldName = "ADLI_BIRIM_NO";
            colADLI_BIRIM_NO.Name = "colADLI_BIRIM_NO";
            colADLI_BIRIM_NO.OptionsColumn.AllowEdit = false;
            colADLI_BIRIM_NO.OptionsColumn.ReadOnly = true;
            colADLI_BIRIM_NO.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 24;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.OptionsColumn.AllowEdit = false;
            colOZEL_KOD1.OptionsColumn.ReadOnly = true;
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 25;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.OptionsColumn.AllowEdit = false;
            colOZEL_KOD2.OptionsColumn.ReadOnly = true;
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 26;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.OptionsColumn.AllowEdit = false;
            colOZEL_KOD3.OptionsColumn.ReadOnly = true;
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 27;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.OptionsColumn.AllowEdit = false;
            colOZEL_KOD4.OptionsColumn.ReadOnly = true;
            colOZEL_KOD4.Visible = true;

            GridColumn colREFERANS_NO = new GridColumn();
            colREFERANS_NO.VisibleIndex = 28;
            colREFERANS_NO.FieldName = "REFERANS_NO";
            colREFERANS_NO.Name = "colREFERANS_NO";
            colREFERANS_NO.OptionsColumn.AllowEdit = false;
            colREFERANS_NO.OptionsColumn.ReadOnly = true;
            colREFERANS_NO.Visible = true;

            #endregion

            #region []

            GridColumn[] dizi = new[]
                                    {
                                        colHAZIRLIK_NO,
                                        colHAZIRLIK_DURUM,
                                        colTAKIP_EDEN_TARAF_KODU,
                                        colTAKIP_EDEN_TARAF_SIFAT,
                                        colTAKIP_EDEN_CARI,
                                        colTAKIP_EDILEN_TARAF_KODU,
                                        colTAKIP_EDILEN_TARAF_SIFAT,
                                        colTAKIP_EDILEN,
                                        colSORUMLU_AVUKAT,
                                        colIZLEYEN_AVUKAT,
                                        colSORUMLU_SAVCI1,
                                        colSORUMLU_SAVCI2,
                                        colKONTROL_KIM,
                                        colACIKLAMA,
                                        colREFERANS_NO,
                                        colREFERANS_NO2,
                                        colREFERANS_NO3,
                                        colHAZIRLIK_ESAS_NO,
                                        colHAZIRLIK_TARIH,
                                        colSIKAYET_TARIHI,
                                        colSIKAYET_KONU,
                                        colADLI_BIRIM_ADLIYE,
                                        colADLI_BIRIM_GOREV,
                                        colADLI_BIRIM_NO,
                                        colOZEL_KOD1,
                                        colOZEL_KOD2,
                                        colOZEL_KOD3,
                                        colOZEL_KOD4,
                                    };

            #endregion

            #region Column Caption

            Dictionary<string, string> captionlar = GetCaptionDictinory();
            Dictionary<string, RepositoryItem> editler = GetRepositoryItemSorusturmDictinory();

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

            #endregion

            return dizi;
        }

        #endregion

        #region SozlesmeGird

        public static GridColumn[] GetSozlesmeGird()
        {
            #region Field & Properties

            GridColumn colTAKIP_EDEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDEN_TARAF_KODU.VisibleIndex = 4;
            colTAKIP_EDEN_TARAF_KODU.FieldName = "TAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.Name = "colTAKIP_EDEN_TARAF_KODU";
            colTAKIP_EDEN_TARAF_KODU.OptionsColumn.AllowEdit = false;
            colTAKIP_EDEN_TARAF_KODU.OptionsColumn.ReadOnly = true;
            colTAKIP_EDEN_TARAF_KODU.Visible = true;

            GridColumn colTAKIP_EDEN_TARAF_SIFAT_ID = new GridColumn();
            colTAKIP_EDEN_TARAF_SIFAT_ID.VisibleIndex = 3;
            colTAKIP_EDEN_TARAF_SIFAT_ID.FieldName = "TAKIP_EDEN_TARAF_SIFAT_ID";
            colTAKIP_EDEN_TARAF_SIFAT_ID.Name = "colTAKIP_EDEN_TARAF_SIFAT_ID";
            colTAKIP_EDEN_TARAF_SIFAT_ID.OptionsColumn.AllowEdit = false;
            colTAKIP_EDEN_TARAF_SIFAT_ID.OptionsColumn.ReadOnly = true;
            colTAKIP_EDEN_TARAF_SIFAT_ID.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_KODU = new GridColumn();
            colTAKIP_EDILEN_TARAF_KODU.VisibleIndex = 7;
            colTAKIP_EDILEN_TARAF_KODU.FieldName = "TAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.Name = "colTAKIP_EDILEN_TARAF_KODU";
            colTAKIP_EDILEN_TARAF_KODU.OptionsColumn.AllowEdit = false;
            colTAKIP_EDILEN_TARAF_KODU.OptionsColumn.ReadOnly = true;
            colTAKIP_EDILEN_TARAF_KODU.Visible = true;

            GridColumn colTAKIP_EDILEN_TARAF_SIFAT_ID = new GridColumn();
            colTAKIP_EDILEN_TARAF_SIFAT_ID.VisibleIndex = 6;
            colTAKIP_EDILEN_TARAF_SIFAT_ID.FieldName = "TAKIP_EDILEN_TARAF_SIFAT_ID";
            colTAKIP_EDILEN_TARAF_SIFAT_ID.Name = "colTAKIP_EDILEN_TARAF_SIFAT_ID";
            colTAKIP_EDILEN_TARAF_SIFAT_ID.OptionsColumn.AllowEdit = false;
            colTAKIP_EDILEN_TARAF_SIFAT_ID.OptionsColumn.ReadOnly = true;
            colTAKIP_EDILEN_TARAF_SIFAT_ID.Visible = true;

            GridColumn colSOZLESME_NO = new GridColumn();
            colSOZLESME_NO.VisibleIndex = 0;
            colSOZLESME_NO.FieldName = "SOZLESME_NO";
            colSOZLESME_NO.Name = "colSOZLESME_NO";
            colSOZLESME_NO.OptionsColumn.AllowEdit = false;
            colSOZLESME_NO.OptionsColumn.ReadOnly = true;
            colSOZLESME_NO.Visible = true;

            GridColumn colTUR = new GridColumn();
            colTUR.VisibleIndex = 8;
            colTUR.FieldName = "TUR";
            colTUR.Name = "colTUR";
            colTUR.OptionsColumn.AllowEdit = false;
            colTUR.OptionsColumn.ReadOnly = true;
            colTUR.Visible = true;

            GridColumn colSOZLESME_ADI = new GridColumn();
            colSOZLESME_ADI.VisibleIndex = 2;
            colSOZLESME_ADI.FieldName = "SOZLESME_ADI";
            colSOZLESME_ADI.Name = "colSOZLESME_ADI";
            colSOZLESME_ADI.OptionsColumn.AllowEdit = false;
            colSOZLESME_ADI.OptionsColumn.ReadOnly = true;
            colSOZLESME_ADI.Visible = true;

            GridColumn colACIKLAMA = new GridColumn();
            colACIKLAMA.VisibleIndex = 21;
            colACIKLAMA.FieldName = "ACIKLAMA";
            colACIKLAMA.Name = "colACIKLAMA";
            colACIKLAMA.OptionsColumn.AllowEdit = false;
            colACIKLAMA.OptionsColumn.ReadOnly = true;
            colACIKLAMA.Visible = true;

            GridColumn colALT_TIP = new GridColumn();
            colALT_TIP.VisibleIndex = 15;
            colALT_TIP.FieldName = "ALT_TIP";
            colALT_TIP.Name = "colALT_TIP";
            colALT_TIP.OptionsColumn.AllowEdit = false;
            colALT_TIP.OptionsColumn.ReadOnly = true;
            colALT_TIP.Visible = true;

            GridColumn colTIP = new GridColumn();
            colTIP.VisibleIndex = 14;
            colTIP.FieldName = "TIP";
            colTIP.Name = "colTIP";
            colTIP.OptionsColumn.AllowEdit = false;
            colTIP.OptionsColumn.ReadOnly = true;
            colTIP.Visible = true;

            GridColumn colOZEL_KOD1 = new GridColumn();
            colOZEL_KOD1.VisibleIndex = 17;
            colOZEL_KOD1.FieldName = "OZEL_KOD1";
            colOZEL_KOD1.Name = "colOZEL_KOD1";
            colOZEL_KOD1.OptionsColumn.AllowEdit = false;
            colOZEL_KOD1.OptionsColumn.ReadOnly = true;
            colOZEL_KOD1.Visible = true;

            GridColumn colOZEL_KOD2 = new GridColumn();
            colOZEL_KOD2.VisibleIndex = 18;
            colOZEL_KOD2.FieldName = "OZEL_KOD2";
            colOZEL_KOD2.Name = "colOZEL_KOD2";
            colOZEL_KOD2.OptionsColumn.AllowEdit = false;
            colOZEL_KOD2.OptionsColumn.ReadOnly = true;
            colOZEL_KOD2.Visible = true;

            GridColumn colOZEL_KOD3 = new GridColumn();
            colOZEL_KOD3.VisibleIndex = 19;
            colOZEL_KOD3.FieldName = "OZEL_KOD3";
            colOZEL_KOD3.Name = "colOZEL_KOD3";
            colOZEL_KOD3.OptionsColumn.AllowEdit = false;
            colOZEL_KOD3.OptionsColumn.ReadOnly = true;
            colOZEL_KOD3.Visible = true;

            GridColumn colOZEL_KOD4 = new GridColumn();
            colOZEL_KOD4.VisibleIndex = 20;
            colOZEL_KOD4.FieldName = "OZEL_KOD4";
            colOZEL_KOD4.Name = "colOZEL_KOD4";
            colOZEL_KOD4.OptionsColumn.AllowEdit = false;
            colOZEL_KOD4.OptionsColumn.ReadOnly = true;
            colOZEL_KOD4.Visible = true;

            GridColumn colADLIYE = new GridColumn();
            colADLIYE.VisibleIndex = 11;
            colADLIYE.FieldName = "ADLIYE";
            colADLIYE.Name = "colADLIYE";
            colADLIYE.OptionsColumn.AllowEdit = false;
            colADLIYE.OptionsColumn.ReadOnly = true;
            colADLIYE.Visible = true;

            GridColumn colGOREV = new GridColumn();
            colGOREV.VisibleIndex = 12;
            colGOREV.FieldName = "GOREV";
            colGOREV.Name = "colGOREV";
            colGOREV.OptionsColumn.AllowEdit = false;
            colGOREV.OptionsColumn.ReadOnly = true;
            colGOREV.Visible = true;

            GridColumn colNO = new GridColumn();
            colNO.VisibleIndex = 13;
            colNO.FieldName = "NO";
            colNO.Name = "colNO";
            colNO.OptionsColumn.AllowEdit = false;
            colNO.OptionsColumn.ReadOnly = true;
            colNO.Visible = true;

            GridColumn colSUBE_KOD_ID = new GridColumn();
            colSUBE_KOD_ID.VisibleIndex = 22;
            colSUBE_KOD_ID.FieldName = "SUBE_KOD_ID";
            colSUBE_KOD_ID.Name = "colSUBE_KOD_ID";
            colSUBE_KOD_ID.OptionsColumn.AllowEdit = false;
            colSUBE_KOD_ID.OptionsColumn.ReadOnly = true;
            colSUBE_KOD_ID.Visible = true;

            GridColumn colKONTROL_KIM_ID = new GridColumn();
            colKONTROL_KIM_ID.VisibleIndex = 23;
            colKONTROL_KIM_ID.FieldName = "KONTROL_KIM_ID";
            colKONTROL_KIM_ID.Name = "colKONTROL_KIM_ID";
            colKONTROL_KIM_ID.OptionsColumn.AllowEdit = false;
            colKONTROL_KIM_ID.OptionsColumn.ReadOnly = true;
            colKONTROL_KIM_ID.Visible = true;

            GridColumn colTAKIP_EDEN = new GridColumn();
            colTAKIP_EDEN.VisibleIndex = 5;
            colTAKIP_EDEN.FieldName = "TAKIP_EDEN";
            colTAKIP_EDEN.Name = "colTAKIP_EDEN";
            colTAKIP_EDEN.OptionsColumn.AllowEdit = false;
            colTAKIP_EDEN.OptionsColumn.ReadOnly = true;
            colTAKIP_EDEN.Visible = true;

            GridColumn colTAKIP_EDILEN = new GridColumn();
            colTAKIP_EDILEN.VisibleIndex = 8;
            colTAKIP_EDILEN.FieldName = "TAKIP_EDILEN";
            colTAKIP_EDILEN.Name = "colTAKIP_EDILEN";
            colTAKIP_EDILEN.OptionsColumn.AllowEdit = false;
            colTAKIP_EDILEN.OptionsColumn.ReadOnly = true;
            colTAKIP_EDILEN.Visible = true;

            GridColumn colIZLEYEN = new GridColumn();
            colIZLEYEN.VisibleIndex = 10;
            colIZLEYEN.FieldName = "IZLEYEN";
            colIZLEYEN.Name = "colIZLEYEN";
            colIZLEYEN.OptionsColumn.AllowEdit = false;
            colIZLEYEN.OptionsColumn.ReadOnly = true;
            colIZLEYEN.Visible = true;

            GridColumn colSORUMLU = new GridColumn();
            colSORUMLU.VisibleIndex = 9;
            colSORUMLU.FieldName = "SORUMLU";
            colSORUMLU.Name = "colSORUMLU";
            colSORUMLU.OptionsColumn.AllowEdit = false;
            colSORUMLU.OptionsColumn.ReadOnly = true;
            colSORUMLU.Visible = true;

            #endregion

            GridColumn[] dizi = new[]
                                    {
                                        colTAKIP_EDEN_TARAF_KODU,
                                        colTAKIP_EDEN_TARAF_SIFAT_ID,
                                        colTAKIP_EDILEN_TARAF_KODU,
                                        colTAKIP_EDILEN_TARAF_SIFAT_ID,
                                        colSOZLESME_NO,
                                        colTUR,
                                        colSOZLESME_ADI,
                                        colACIKLAMA,
                                        colALT_TIP,
                                        colTIP,
                                        colOZEL_KOD1,
                                        colOZEL_KOD2,
                                        colOZEL_KOD3,
                                        colOZEL_KOD4,
                                        colADLIYE,
                                        colGOREV,
                                        colNO,
                                        colSUBE_KOD_ID,
                                        colKONTROL_KIM_ID,
                                        colTAKIP_EDEN,
                                        colTAKIP_EDILEN,
                                        colIZLEYEN,
                                        colSORUMLU,
                                    };

            #region Column Caption

            Dictionary<string, string> captionlar = GetSozlesmeCaptionDictinory();
            Dictionary<string, RepositoryItem> editler = GetRepositorySozlesmeItemDictinory();

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

            #endregion

            return dizi;
        }

        #endregion

        //BV

        #region Evrak / Tebligat Grid

        public static GridColumn[] GetEvrakGrid()
        {
            #region Field & Properties

            GridColumn colTEBLIGAT_ESAS_NO = new GridColumn();
            colTEBLIGAT_ESAS_NO.VisibleIndex = 4;
            colTEBLIGAT_ESAS_NO.FieldName = "TEBLIGAT_ESAS_NO";// "Esas No"
            colTEBLIGAT_ESAS_NO.Name = "colTEBLIGAT_ESAS_NO";
            colTEBLIGAT_ESAS_NO.Visible = true;
            colTEBLIGAT_ESAS_NO.OptionsColumn.AllowEdit = false;
            colTEBLIGAT_ESAS_NO.OptionsColumn.ReadOnly = true;
            colTEBLIGAT_ESAS_NO.Caption = "Esas No";

            GridColumn colMUHATAP = new GridColumn();
            colMUHATAP.VisibleIndex = 3;
            colMUHATAP.FieldName = "MUHATAP";
            colMUHATAP.Name = "colMUHATAP";
            colMUHATAP.Visible = true;
            colMUHATAP.OptionsColumn.AllowEdit = false;
            colMUHATAP.OptionsColumn.ReadOnly = true;
            colMUHATAP.Caption = "Muhatap";

            GridColumn colTEBLIG_TARIH = new GridColumn();
            colTEBLIG_TARIH.VisibleIndex = 7;
            colTEBLIG_TARIH.FieldName = "TEBLIG_TARIH";
            colTEBLIG_TARIH.Name = "colTEBLIG_TARIH";
            colTEBLIG_TARIH.Visible = true;
            colTEBLIG_TARIH.OptionsColumn.AllowEdit = false;
            colTEBLIG_TARIH.OptionsColumn.ReadOnly = true;
            colTEBLIG_TARIH.Caption = "Tebliğ T.";

            GridColumn colBILA_TEBLIG_MI = new GridColumn();
            colBILA_TEBLIG_MI.VisibleIndex = 6;
            colBILA_TEBLIG_MI.FieldName = "BILA_TEBLIG_MI";
            colBILA_TEBLIG_MI.Name = "colBILA_TEBLIG_MI";
            colBILA_TEBLIG_MI.Visible = true;
            colBILA_TEBLIG_MI.OptionsColumn.AllowEdit = false;
            colBILA_TEBLIG_MI.OptionsColumn.ReadOnly = true;
            colBILA_TEBLIG_MI.Caption = "B";

            GridColumn colZABITA_ARASTIRMASI_ISTENDI_MI = new GridColumn();
            colZABITA_ARASTIRMASI_ISTENDI_MI.VisibleIndex = 0;
            colZABITA_ARASTIRMASI_ISTENDI_MI.FieldName = "ZABITA_ARASTIRMASI_ISTENDI_MI";
            colZABITA_ARASTIRMASI_ISTENDI_MI.Name = "colZABITA_ARASTIRMASI_ISTENDI_MI";
            colZABITA_ARASTIRMASI_ISTENDI_MI.Visible = true;
            colZABITA_ARASTIRMASI_ISTENDI_MI.OptionsColumn.AllowEdit = false;
            colZABITA_ARASTIRMASI_ISTENDI_MI.OptionsColumn.ReadOnly = true;
            colZABITA_ARASTIRMASI_ISTENDI_MI.Caption = "Z";

            GridColumn colZABITA_ARASTIRMASI_OLUMSUZ_MU = new GridColumn();
            colZABITA_ARASTIRMASI_OLUMSUZ_MU.VisibleIndex = 8;
            colZABITA_ARASTIRMASI_OLUMSUZ_MU.FieldName = "ZABITA_ARASTIRMASI_OLUMSUZ_MU";
            colZABITA_ARASTIRMASI_OLUMSUZ_MU.Name = "colZABITA_ARASTIRMASI_OLUMSUZ_MU";
            colZABITA_ARASTIRMASI_OLUMSUZ_MU.Visible = true;
            colZABITA_ARASTIRMASI_OLUMSUZ_MU.OptionsColumn.AllowEdit = false;
            colZABITA_ARASTIRMASI_OLUMSUZ_MU.OptionsColumn.ReadOnly = true;
            colZABITA_ARASTIRMASI_OLUMSUZ_MU.Caption = "O";

            GridColumn colPTT_BARKOD_NO = new GridColumn();
            colPTT_BARKOD_NO.VisibleIndex = 2;
            colPTT_BARKOD_NO.FieldName = "PTT_BARKOD_NO";
            colPTT_BARKOD_NO.Name = "colPTT_BARKOD_NO";
            colPTT_BARKOD_NO.Visible = true;
            colPTT_BARKOD_NO.OptionsColumn.AllowEdit = false;
            colPTT_BARKOD_NO.OptionsColumn.ReadOnly = true;
            colPTT_BARKOD_NO.Caption = "Barkod No";

            GridColumn colBAGLANTI = new GridColumn();
            colBAGLANTI.VisibleIndex = 21;
            colBAGLANTI.FieldName = "BAGLANTI";
            colBAGLANTI.Name = "colBAGLANTI";
            colBAGLANTI.Visible = true;
            colBAGLANTI.OptionsColumn.AllowEdit = false;
            colBAGLANTI.OptionsColumn.ReadOnly = true;
            colBAGLANTI.Caption = "Bağlantı";

            GridColumn colTEBLIGAT_SEKLI = new GridColumn();
            colTEBLIGAT_SEKLI.VisibleIndex = 15;
            colTEBLIGAT_SEKLI.FieldName = "TEBLIGAT_SEKLI";
            colTEBLIGAT_SEKLI.Name = "colTEBLIGAT_SEKLI";
            colTEBLIGAT_SEKLI.Visible = true;
            colTEBLIGAT_SEKLI.OptionsColumn.AllowEdit = false;
            colTEBLIGAT_SEKLI.OptionsColumn.ReadOnly = true;
            colTEBLIGAT_SEKLI.Caption = "Tebligat Şekli";

            GridColumn colTEBLIGAT_ADLI_BIRIM_ADLIYE = new GridColumn();
            colTEBLIGAT_ADLI_BIRIM_ADLIYE.VisibleIndex = 14;
            colTEBLIGAT_ADLI_BIRIM_ADLIYE.FieldName = "TEBLIGAT_ADLI_BIRIM_ADLIYE";
            colTEBLIGAT_ADLI_BIRIM_ADLIYE.Name = "colTEBLIGAT_ADLI_BIRIM_ADLIYE";
            colTEBLIGAT_ADLI_BIRIM_ADLIYE.Visible = true;
            colTEBLIGAT_ADLI_BIRIM_ADLIYE.OptionsColumn.AllowEdit = false;
            colTEBLIGAT_ADLI_BIRIM_ADLIYE.OptionsColumn.ReadOnly = true;
            colTEBLIGAT_ADLI_BIRIM_ADLIYE.Caption = "Adliye";

            GridColumn colTEBLIGAT_ADLI_BIRIM_GOREV = new GridColumn();
            colTEBLIGAT_ADLI_BIRIM_GOREV.VisibleIndex = 17;
            colTEBLIGAT_ADLI_BIRIM_GOREV.FieldName = "TEBLIGAT_ADLI_BIRIM_GOREV";
            colTEBLIGAT_ADLI_BIRIM_GOREV.Name = "colTEBLIGAT_ADLI_BIRIM_GOREV";
            colTEBLIGAT_ADLI_BIRIM_GOREV.Visible = true;
            colTEBLIGAT_ADLI_BIRIM_GOREV.OptionsColumn.AllowEdit = false;
            colTEBLIGAT_ADLI_BIRIM_GOREV.OptionsColumn.ReadOnly = true;
            colTEBLIGAT_ADLI_BIRIM_GOREV.Caption = "Grv";

            GridColumn colTEBLIGAT_ADLI_BIRIM_NO = new GridColumn();
            colTEBLIGAT_ADLI_BIRIM_NO.VisibleIndex = 18;
            colTEBLIGAT_ADLI_BIRIM_NO.FieldName = "TEBLIGAT_ADLI_BIRIM_NO";
            colTEBLIGAT_ADLI_BIRIM_NO.Name = "colTEBLIGAT_ADLI_BIRIM_NO";
            colTEBLIGAT_ADLI_BIRIM_NO.Visible = true;
            colTEBLIGAT_ADLI_BIRIM_NO.OptionsColumn.AllowEdit = false;
            colTEBLIGAT_ADLI_BIRIM_NO.OptionsColumn.ReadOnly = true;
            colTEBLIGAT_ADLI_BIRIM_NO.Caption = "No";

            GridColumn colTEBLIGAT_KONU = new GridColumn();
            colTEBLIGAT_KONU.VisibleIndex = 19;
            colTEBLIGAT_KONU.FieldName = "TEBLIGAT_KONU";
            colTEBLIGAT_KONU.Name = "colTEBLIGAT_KONU";
            colTEBLIGAT_KONU.Visible = true;
            colTEBLIGAT_KONU.OptionsColumn.AllowEdit = false;
            colTEBLIGAT_KONU.OptionsColumn.ReadOnly = true;
            colTEBLIGAT_KONU.Caption = "Konu";

            GridColumn colDosya_No = new GridColumn();
            colDosya_No.VisibleIndex = 20;
            colDosya_No.FieldName = "Dosya_No";
            colDosya_No.Name = "colDosya_No";
            colDosya_No.Visible = true;
            colDosya_No.OptionsColumn.AllowEdit = false;
            colDosya_No.OptionsColumn.ReadOnly = true;
            colDosya_No.Caption = "Dosya No";

            GridColumn colIliskiEkle = new GridColumn();
            colIliskiEkle.VisibleIndex = 11;
            colIliskiEkle.FieldName = "colIliskiEkle";
            colIliskiEkle.Name = "colIliskiEkle";
            colIliskiEkle.Visible = true;
            colIliskiEkle.OptionsColumn.AllowEdit = false;
            colIliskiEkle.OptionsColumn.ReadOnly = true;
            colIliskiEkle.Caption = "İlişki Ekle";

            #endregion

            GridColumn[] dizi = new[]
                                    {
                                        colTEBLIGAT_ESAS_NO,
                                        colMUHATAP,
                                        colTEBLIG_TARIH,
                                        colBILA_TEBLIG_MI,
                                        colZABITA_ARASTIRMASI_ISTENDI_MI,
                                        colPTT_BARKOD_NO,
                                        colBAGLANTI,
                                        colTEBLIGAT_SEKLI,
                                        colTEBLIGAT_ADLI_BIRIM_ADLIYE,
                                        colTEBLIGAT_ADLI_BIRIM_GOREV,
                                        colTEBLIGAT_ADLI_BIRIM_NO,
                                        colTEBLIGAT_KONU,
                                        colDosya_No,
                                        colIliskiEkle,
                                    };

            #region Column Caption

            Dictionary<string, string> captionlar = GetEvrakCaptionDictionary();
            //Dictionary<string, RepositoryItem> editler = GetRepositoryEvrakItemDictionary();

            //for (int i = 0; i < dizi.Length; i++)
            //{
            //    string caption = string.Empty;
            //    if (captionlar.ContainsKey(dizi[i].FieldName))
            //        caption = captionlar[dizi[i].FieldName];
            //    if (caption.Length > 0)
            //        dizi[i].Caption = caption;
            //    else if (dizi[i].FieldName.ToLower().Contains("doviz_id"))
            //        dizi[i].Caption = "Brm";

            //    if (dizi[i].FieldName.Contains("_DOVIZ_ID"))
            //    {
            //        dizi[i].ColumnEdit = editler["DovizId"];
            //    }
            //    else if (editler.ContainsKey(dizi[i].FieldName))
            //        dizi[i].ColumnEdit = editler[dizi[i].FieldName];
            //}

            #endregion

            return dizi;
        }

        //BV
        public static List<AV001_TDI_BIL_TEBLIGAT> EvrakDosyaDoldur(int CariID)
        {
            AvpDataContext db = new AvpDataContext(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            var predicate = PredicateBuilder.True<AV001_TDI_BIL_TEBLIGAT>();
            var muhatap = db.AV001_TDI_BIL_TEBLIGAT_MUHATAPs.Where(vs => vs.MUHATAP_CARI_ID == CariID);
            var Davalar = muhatap.Select(I => I.TEBLIGAT_ID).ToList();

            int count = Davalar.Count;
            if (count > 0)
                predicate = predicate.And(vi => Davalar.Contains(vi.ID));
            else
                predicate = PredicateBuilder.False<AV001_TDI_BIL_TEBLIGAT>();

            return db.AV001_TDI_BIL_TEBLIGATs.Where(predicate).ToList();
        }

        //BV

        #endregion Evrak / Tebligat Grid

        private static Dictionary<string, string> GetEvrakCaptionDictionary()
        {
            Dictionary<string, string> dicFieldCaption = new Dictionary<string, string>();

            #region Caption Edit

            dicFieldCaption.Add("TEBLIGAT_ESAS_NO", "Esas No");
            dicFieldCaption.Add("MUHATAP", "Muhatap");
            dicFieldCaption.Add("TEBLIG_TARIH", "Tebliğ T.");
            dicFieldCaption.Add("BILA_TEBLIG_MI", "B");
            dicFieldCaption.Add("ZABITA_ARASTIRMASI_ISTENDI_MI", "Z");
            dicFieldCaption.Add("ZABITA_ARASTIRMASI_OLUMSUZ_MU", "O");
            dicFieldCaption.Add("PTT_BARKOD_NO", "Barkod No");
            dicFieldCaption.Add("BAGLANTI", "Bağlantı");
            dicFieldCaption.Add("TEBLIGAT_SEKLI", "Tebligat Şekli");
            dicFieldCaption.Add("TEBLIGAT_ADLI_BIRIM_ADLIYE", "Adliye");
            dicFieldCaption.Add("TEBLIGAT_ADLI_BIRIM_GOREV", "Grv");
            dicFieldCaption.Add("TEBLIGAT_ADLI_BIRIM_NO", "No");
            dicFieldCaption.Add("TEBLIGAT_KONU", "Konu");
            dicFieldCaption.Add("Dosya_No", "Dosya No");
            dicFieldCaption.Add("OZEL_KOD4", "Özel Kod4");
            dicFieldCaption.Add("Iliski_Ekle", "İlişki Ekle");

            #endregion

            return dicFieldCaption;
        }

        //BV

        #region Belge Grid

        static RepositoryItemImageComboBox rLueBelgeDosyaUzanti = new RepositoryItemImageComboBox();
        static RepositoryItemLookUpEdit rLueSubeKod = new RepositoryItemLookUpEdit();
        static RepositoryItemLookUpEdit rLueKontrolKim = new RepositoryItemLookUpEdit();
                
        private static Dictionary<string, RepositoryItem> GetRepositoryBelgeItemDictionary()
        {
            RepositoryItemLookUpEdit rlueSubeKod = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rlueKontrolKim = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit rluesifat = new RepositoryItemLookUpEdit();
            BelgeUtil.Inits.SubeKodGetir(rlueSubeKod);
            BelgeUtil.Inits.KontrolKimGetir(rlueKontrolKim);

            Dictionary<string, RepositoryItem> sozluk = new Dictionary<string, RepositoryItem>();

            #region Add item

            sozluk.Add("SUBE_KOD_ID", rlueSubeKod);
            sozluk.Add("KONTROL_KIM_ID", rlueKontrolKim);

            #endregion

            return sozluk;
        }

        //BV

        #endregion Belge Grid
    }
}