using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Collections.Generic;
using TXTextControl;

namespace AdimAdimDavaKaydi.Editor.Degiskenler.Util
{
    public class EditorDokuman
    {
        #region Ctor

        public EditorDokuman(IEntity foy)
        {
            //default değerler atandı
            CiktiSayisi = 1;
            Secildi = true;

            //içeride kontrollerle uğraşmamak için bu property default olarak
            //true geliyor eğer farklı bir durum olursa veya el ile 1 tane dahi eklenirse
            //kendiliğinden false olacaktır
            TumTaraflaraOlustur = true;
            TumSorumlularaOlustur = true;

            GecerliFoy = foy;

            if (this.Taraflar == null) this.Taraflar = new EditorDokumanTarafCollection();
            if (this.Sorumlular == null) this.Sorumlular = new EditorDokumanSorumluCollection();

            this.Taraflar.TarafEklendi += Taraflar_TarafEklendi;
            this.Sorumlular.SorumluAvukatEklendi += Sorumlular_SorumluAvukatEklendi;
        }

        #endregion Ctor

        #region Properies

        public string Ad { get; set; }

        public EditorDokumanTebligatBarkodCollection Barkodlar { get; set; }

        public int barkodTurID { get; set; }

        //     public AvukatProLib.Arama.VDIE_BIL_SABLON_RAPOR Sablon { get; set; }
        public int CiktiSayisi { get; set; }

        public byte[] Dokuman { get; set; }

        public string FoyNo
        {
            get
            {
                if (this.GecerliFoy is AV001_TI_BIL_FOY)
                    return (this.GecerliFoy as AV001_TI_BIL_FOY).FOY_NO;

                return string.Empty;
            }
        }

        /// <summary>
        /// Geçerli Belgeyi ilişkilendirip kaydetmek için
        /// </summary>
        public IEntity GecerliFoy { get; set; }

        public string SablonAdi
        {
            get
            {
                //if (Sablon != null)
                return Ad;
                //return string.Empty;
            }
        }

        public bool Secildi { get; set; }

        public EditorDokumanSorumluCollection Sorumlular { get; set; }

        /// <summary>
        /// İlişkilendirilecek Belgenin Tarafları için
        /// </summary>
        public EditorDokumanTarafCollection Taraflar { get; set; }

        public bool TumSorumlularaOlustur { get; set; }

        /// <summary>
        ///default true geliyor eğer manuel taraf eklenirse false e döner
        ///kendiliğinden false olacaktır
        /// </summary>
        public bool TumTaraflaraOlustur { get; set; }

        public string Tur { get; set; }

        public int TurID { get; set; }

        #endregion Properies

        #region Methots

        public AV001_TDIE_BIL_BELGE GetBelge(TextControl txControl)
        {
            AV001_TDIE_BIL_BELGE belge = new AV001_TDIE_BIL_BELGE();
            belge.STAMP = 0;

            //ToDo: belge kaydı oluşturulacak altına sorumlu ve tarafları ilişkilendirilip
            //geri döndürülecek,

            if (this.SablonAdi == this.Ad)
                belge.BELGE_ADI = this.Ad;
            else
                belge.BELGE_ADI = string.Format("{0}-{1}", this.SablonAdi, this.Ad);

            belge.ICERIK = this.Dokuman;
            belge.BELGE_REFERANS_NO = Guid.NewGuid().ToString().Substring(0, 7); // DateTime.Now.Ticks.ToString();
            belge.DOSYA_ADI = string.Format("{0}.tx", this.Ad);
            belge.DOKUMAN_UZANTI = "tx";
            belge.IsSelected = true;
            belge.BELGEYI_YAZAN_ID = AvukatProLib.Kimlik.Bilgi.CARI_ID;
            belge.YAZILMA_TARIHI = DateTime.Now.Date;

            SetBelgeGenelBilgiler(belge);
            SetNNCollection(belge);

            #region Taraflar

            if (this.TumTaraflaraOlustur)
                this.SetTumTaraflar();

            foreach (var trf in this.Taraflar)
            {
                AV001_TDIE_BIL_BELGE_TARAF yeniTaraf = belge.AV001_TDIE_BIL_BELGE_TARAFCollection.AddNew();

                yeniTaraf.CARI_ID = trf.CariId;
                yeniTaraf.SIFAT_ID = trf.TarafSifatId;
                yeniTaraf.IsSelected = true;
            }

            #endregion Taraflar

            #region Sorumlular

            if (this.TumSorumlularaOlustur)
                this.SetTumSorumlular();
            if (this.Sorumlular != null)
            {
                foreach (var srmlu in this.Sorumlular)
                {
                    var yeniSorumlu = belge.AV001_TDIE_BIL_BELGE_SORUMLUCollection.AddNew();
                    yeniSorumlu.SORUMLU_TIP = (int)AvukatProLib.Extras.SorumluTip.Sorumlu;
                    yeniSorumlu.CARI_ID = srmlu.SorumluCariId;
                    yeniSorumlu.IsSelected = true;
                }
            }

            #endregion Sorumlular

            return belge;
        }

        /// <summary>
        /// ilişkili Entity üzerinden mevcut sorumluların hepsini oluşturur
        /// </summary>
        public void SetTumSorumlular()
        {
            this.Sorumlular = EditorDokumanSorumluCollection.GetAllSorumluByEntity(this.GecerliFoy);
        }

        /// <summary>
        /// ilişkili Entity üzerinden mevcut tarafların hepsini oluşturur
        /// </summary>
        public void SetTumTaraflar()
        {
            this.Taraflar = EditorDokumanTarafCollection.GetAllTarafByEntity(this.GecerliFoy);
        }

        private void SetBelgeGenelBilgiler(AV001_TDIE_BIL_BELGE belge)
        {
            if (this.GecerliFoy is AV001_TI_BIL_FOY)
            {
                var foy = this.GecerliFoy as AV001_TI_BIL_FOY;

                belge.ESAS_NO = foy.ESAS_NO;
                belge.ADLI_BIRIM_ADLIYE_ID = foy.ADLI_BIRIM_ADLIYE_ID;
                belge.ADLI_BIRIM_GOREV_ID = foy.ADLI_BIRIM_GOREV_ID;
                belge.ADLI_BIRIM_NO_ID = foy.ADLI_BIRIM_NO_ID;
                belge.BELGE_TUR_ID = 2; // icra formu

                belge.ACIKLAMA = string.Format("{0} {1}. {2} {3}"
                                               , EditorDataAraclari.Icra.GetAdliyeAdi(foy.ADLI_BIRIM_ADLIYE_ID)
                                               , EditorDataAraclari.Icra.GetAdliBirimNo(foy.ADLI_BIRIM_NO_ID)
                                               , EditorDataAraclari.Icra.GetAdliBirimGorev(foy.ADLI_BIRIM_GOREV_ID)
                                               , this.SablonAdi
                    );
            }
            if (this.GecerliFoy is AV001_TD_BIL_FOY)
            {
                var foy = this.GecerliFoy as AV001_TD_BIL_FOY;

                belge.ESAS_NO = foy.ESAS_NO;
                belge.ADLI_BIRIM_ADLIYE_ID = foy.ADLI_BIRIM_ADLIYE_ID;
                belge.ADLI_BIRIM_GOREV_ID = foy.ADLI_BIRIM_GOREV_ID;
                belge.ADLI_BIRIM_NO_ID = foy.ADLI_BIRIM_NO_ID;
                belge.BELGE_TUR_ID = 1; // icra formu

                belge.ACIKLAMA = string.Format("{0} {1}. {2} {3}"
                                               , EditorDataAraclari.Icra.GetAdliyeAdi(foy.ADLI_BIRIM_ADLIYE_ID)
                                               , EditorDataAraclari.Icra.GetAdliBirimNo(foy.ADLI_BIRIM_NO_ID)
                                               , EditorDataAraclari.Icra.GetAdliBirimGorev(foy.ADLI_BIRIM_GOREV_ID)
                                               , this.SablonAdi
                    );
            }
            if (this.GecerliFoy is AV001_TD_BIL_HAZIRLIK)
            {
                var foy = this.GecerliFoy as AV001_TD_BIL_HAZIRLIK;

                belge.ESAS_NO = foy.HAZIRLIK_ESAS_NO;
                belge.ADLI_BIRIM_ADLIYE_ID = foy.ADLI_BIRIM_ADLIYE_ID;
                belge.ADLI_BIRIM_GOREV_ID = foy.ADLI_BIRIM_GOREV_ID;
                belge.ADLI_BIRIM_NO_ID = foy.ADLI_BIRIM_NO_ID;
                belge.BELGE_TUR_ID = 2; // icra formu

                belge.ACIKLAMA = string.Format("{0} {1}. {2} {3}"
                                               , EditorDataAraclari.Icra.GetAdliyeAdi(foy.ADLI_BIRIM_ADLIYE_ID)
                                               , EditorDataAraclari.Icra.GetAdliBirimNo(foy.ADLI_BIRIM_NO_ID)
                                               , EditorDataAraclari.Icra.GetAdliBirimGorev(foy.ADLI_BIRIM_GOREV_ID)
                                               , this.SablonAdi
                    );
            }
        }

        private void SetNNCollection(AV001_TDIE_BIL_BELGE belge)
        {
            if (this.GecerliFoy is AV001_TI_BIL_FOY)
            {
                var nnKayit = belge.NN_BELGE_ICRACollection.AddNew();
                nnKayit.ICRA_FOY_ID = ((AV001_TI_BIL_FOY)this.GecerliFoy).ID;
            }
        }

        #endregion Methots

        #region Class

        public class EditorDokumanSorumlu
        {
            public EditorDokumanSorumlu(int sorumluAvukatCariId)
            {
                this.SorumluCariId = sorumluAvukatCariId;
            }

            public int SorumluCariId { get; set; }
        }

        public class EditorDokumanSorumluCollection : List<EditorDokumanSorumlu>
        {
            public event EventHandler<EventArgs> SorumluAvukatEklendi;

            public static EditorDokumanSorumluCollection GetAllSorumluByEntity(AV001_TI_BIL_FOY foy)
            {
                EditorDokumanSorumluCollection coll = new EditorDokumanSorumluCollection();

                var icraFoyu = foy;

                if (icraFoyu.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icraFoyu, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_SORUMLU_AVUKAT>));
                }

                foreach (var sorumlu in icraFoyu.AV001_TI_BIL_FOY_SORUMLU_AVUKATCollection)
                {
                    if (sorumlu.SORUMLU_AVUKAT_CARI_ID.HasValue)
                        coll.Add(sorumlu.SORUMLU_AVUKAT_CARI_ID.Value);
                }

                return coll;
            }

            public static EditorDokumanSorumluCollection GetAllSorumluByEntity(IEntity foy)
            {
                if (foy is AV001_TI_BIL_FOY)
                    return EditorDokumanSorumluCollection.GetAllSorumluByEntity(foy as AV001_TI_BIL_FOY);

                return null;
            }

            public EditorDokumanSorumlu Add(int sorumluAvukatCariId)
            {
                var sorumlu = new EditorDokumanSorumlu(sorumluAvukatCariId);
                this.Add(sorumlu);

                if (SorumluAvukatEklendi != null)
                    SorumluAvukatEklendi(sorumlu, new EventArgs());

                return sorumlu;
            }
        }

        public class EditorDokumanTaraf
        {
            public EditorDokumanTaraf(int cariId, int tarafSifatId)
            {
                this.CariId = cariId;
                this.TarafSifatId = tarafSifatId;
            }

            public int CariId { get; set; }

            public int TarafSifatId { get; set; }
        }

        public class EditorDokumanTarafCollection : List<EditorDokumanTaraf>
        {
            public event EventHandler<EventArgs> TarafEklendi;

            /// <summary>
            /// Verilen föy e göre taraf üretir
            ///
            /// </summary>
            /// <param name="foy"></param>
            public static EditorDokumanTarafCollection GetAllTarafByEntity(AV001_TI_BIL_FOY foy)
            {
                EditorDokumanTarafCollection coll = new EditorDokumanTarafCollection();

                var icraFoyu = foy;

                if (icraFoyu.AV001_TI_BIL_FOY_TARAFCollection.Count == 0)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(icraFoyu, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                }

                foreach (var taraf in icraFoyu.AV001_TI_BIL_FOY_TARAFCollection)
                {
                    coll.Add(taraf.CARI_ID.Value, taraf.TARAF_SIFAT_ID);
                }

                return coll;
            }

            public static EditorDokumanTarafCollection GetAllTarafByEntity(IEntity foy)
            {
                if (foy is AV001_TI_BIL_FOY)
                    return GetAllTarafByEntity((AV001_TI_BIL_FOY)foy);

                return new EditorDokumanTarafCollection();
            }

            public EditorDokumanTaraf Add(int cariId, int tarafSifatId)
            {
                var taraf = new EditorDokumanTaraf(cariId, tarafSifatId);
                this.Add(taraf);
                if (TarafEklendi != null)
                {
                    TarafEklendi(taraf, new EventArgs());
                }
                return taraf;
            }
        }

        #region tebligat barkod

        public class EditorDokumanTebligatBarkod
        {
            public EditorDokumanTebligatBarkod(string Barkod)
            {
                this.TebligatBarkod = Barkod;
            }

            public string TebligatBarkod { get; set; }
        }

        public class EditorDokumanTebligatBarkodCollection : List<EditorDokumanTebligatBarkod>
        {
            public event EventHandler<EventArgs> BarkodEklendi;

            public EditorDokumanTebligatBarkod Add(string _Barkod)
            {
                var barkod = new EditorDokumanTebligatBarkod(_Barkod);
                this.Add(barkod);
                if (BarkodEklendi != null)
                {
                    BarkodEklendi(barkod, new EventArgs());
                }
                return barkod;
            }
        }

        #endregion tebligat barkod

        #endregion Class

        #region Enums

        public enum GruplamaTipi
        {
            Standart,
            TarafBazindaTakipEdilenler,
            TarafBazindaTakipEdenler,
            TarafBazindaTumTaraflar, //
            TakipEdilenAvukatları, //
            IcraGayrimenkulTapuMudurlukleri,
            ICraGayrimenkulBelediyeleri,
            AracTrafikSubeleri,
            IcraGrupluNufusMudurlukleriTakipEdenTaraf,
            IcraGrupluNufusMudurlukleriTakipEdilenTaraf,
            IcraGrupluNufusMudurlukleriFoyTaraf,
            IcraGrupluNufusMudurlukleriIlceTakipEdenTaraf,
            IcraGrupluNufusMudurlukleriIlceTakipEdilenTaraf,
            IcraGrupluNufusMudurlukleriIlceFoyTaraf,
            IcraGrupluBankayaGoreCekler,
            IcraGrupluBankayaSubelerineGoreCekler,
            IcraGruplu89_1Borclusu,
            IcraGruplu89_2Borclusu,
            IcraGruplu89_3Borclusu,
            IcraHacizleri,
            IcraGrupluNakiteDonmusGayriNakitler
        }

        #endregion Enums

        #region Events

        private void Sorumlular_SorumluAvukatEklendi(object sender, EventArgs e)
        {
            if (this.TumSorumlularaOlustur) this.TumSorumlularaOlustur = false;
        }

        private void Taraflar_TarafEklendi(object sender, EventArgs e)
        {
            if (this.TumTaraflaraOlustur) this.TumTaraflaraOlustur = false;
        }

        #endregion Events
    }
}