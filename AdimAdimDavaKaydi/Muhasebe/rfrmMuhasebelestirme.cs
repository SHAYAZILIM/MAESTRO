using System;
using System.Collections.Generic;
using System.ComponentModel;
using AvukatProLib.Hesap;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors.Controls;

namespace AdimAdimDavaKaydi.Muhasebe
{
    [Serializable, DataObject]
    [CLSCompliant(true)]
    public class HesapKalem
    {
        private TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> avanslar;
        private TList<AV001_TDI_BIL_CARI_HESAP_DETAY> hesaplar;
        private TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI mKategori;
        private int mKategoriId;
        private bool seciliMi;
        private decimal tahakkukTutar;
        private decimal toplamTutar;

        public TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> Avanslar
        {
            get { return avanslar; }
            set { avanslar = value; }
        }

        public TList<AV001_TDI_BIL_CARI_HESAP_DETAY> Hesaplar
        {
            get { return hesaplar; }
            set { hesaplar = value; }
        }

        public decimal KalanTutar
        {
            get { return toplamTutar - tahakkukTutar; }
        }

        public TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI MKategori
        {
            get { return mKategori; }
            set { mKategori = value; }
        }

        public int MKategoriId
        {
            get { return mKategoriId; }
            set { mKategoriId = value; }
        }

        public bool SeciliMi
        {
            get { return seciliMi; }
            set { seciliMi = value; }
        }

        public decimal TahakkukTutar
        {
            get { return tahakkukTutar; }
            set { tahakkukTutar = value; }
        }

        public decimal ToplamTutar
        {
            get { return toplamTutar; }
            set { toplamTutar = value; }
        }

        public void Hesapla()
        {
            toplamTutar = 0;
            tahakkukTutar = 0;
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY avansDetay in avanslar)
            {
                toplamTutar += DovizHelper.CevirYTL(avansDetay.GENEL_TOPLAM, avansDetay.BIRIM_FIYAT_DOVIZ_ID,
                                                    avansDetay.TARIH);
            }
            if (hesaplar != null)
                foreach (AV001_TDI_BIL_CARI_HESAP_DETAY hesapDetay in hesaplar)
                {
                    if (!hesapDetay.TARIH.HasValue)
                        hesapDetay.TARIH = DateTime.Today;
                    tahakkukTutar += DovizHelper.CevirYTL(hesapDetay.GENEL_TOPLAM, hesapDetay.BIRIM_FIYAT_DOVIZ_ID,
                                                          hesapDetay.TARIH.Value);
                }
        }
    }

    public partial class rfrmMuhasebelestirme : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        private List<HesapKalem> listMuhasebelesecekler;

        private TList<AV001_TI_BIL_FOY_TARAF> listMuvekkiller;

        private List<HesapKalem> myHesapKalems = new List<HesapKalem>();

        public rfrmMuhasebelestirme()
        {
            InitializeComponent();
        }

        public void inedi(AV001_TI_BIL_FOY mFoy)
        {
            myHesapKalems.Clear();
            TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY> detays = new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>();
            foreach (AV001_TDI_BIL_MASRAF_AVANS avans in mFoy.AV001_TDI_BIL_MASRAF_AVANSCollection)
            {
                detays.AddRange(avans.AV001_TDI_BIL_MASRAF_AVANS_DETAYCollection);
            }
            detays.Sort("HAREKET_ANA_KATEGORI_ID");
            Dictionary<int, TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>> dosyaMasrafAvans =
                new Dictionary<int, TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>>();
            Dictionary<int, TList<AV001_TDI_BIL_CARI_HESAP_DETAY>> dosyaHesaplari =
                new Dictionary<int, TList<AV001_TDI_BIL_CARI_HESAP_DETAY>>();
            foreach (AV001_TDI_BIL_MASRAF_AVANS_DETAY avansDetay in detays)
            {
                if (true) // Eðer haraket ana kategori bilgisi var ise
                {
                    if (dosyaMasrafAvans.ContainsKey(avansDetay.HAREKET_ANA_KATEGORI_ID))

                    //Eðer Daha önceden ana kategori eklenmiþ ise
                    {
                        // var olan ana kategori Tlistine ekliyoruz
                        dosyaMasrafAvans[avansDetay.HAREKET_ANA_KATEGORI_ID].Add(avansDetay);
                    }
                    else //Eðer daha önce ana kategori eklenmemiþ ise
                    {
                        //Ana kategoriyi dic. e ekliyoruz ve yeni bir masraf avans detay listesi oluþturuyoruz.
                        dosyaMasrafAvans.Add(avansDetay.HAREKET_ANA_KATEGORI_ID,
                                             new TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>());

                        //oluþturduðumuz masraf avans detay listesine detayýmýzý ekliyoruz
                        dosyaMasrafAvans[avansDetay.HAREKET_ANA_KATEGORI_ID].Add(avansDetay);
                    }
                }
            }
            foreach (AV001_TDI_BIL_CARI_HESAP_DETAY hesapDetay in mFoy.AV001_TDI_BIL_CARI_HESAP_DETAYCollection)
            {
                if (hesapDetay.HAREKET_ANA_KATEGORI_ID.HasValue) // Eðer haraket ana kategori bilgisi var ise
                {
                    if (dosyaHesaplari.ContainsKey(hesapDetay.HAREKET_ANA_KATEGORI_ID.Value))

                    //Eðer Daha önceden ana kategori eklenmiþ ise
                    {
                        // var olan ana kategori Tlistine ekliyoruz
                        dosyaHesaplari[hesapDetay.HAREKET_ANA_KATEGORI_ID.Value].Add(hesapDetay);
                    }
                    else //Eðer daha önce ana kategori eklenmemiþ ise
                    {
                        //Ana kategoriyi dic. e ekliyoruz ve yeni bir hesap detay listesi oluþturuyoruz.
                        dosyaHesaplari.Add(hesapDetay.HAREKET_ANA_KATEGORI_ID.Value,
                                           new TList<AV001_TDI_BIL_CARI_HESAP_DETAY>());

                        //oluþturduðumuz hesap detay listesine detayýmýzý ekliyoruz
                        dosyaHesaplari[hesapDetay.HAREKET_ANA_KATEGORI_ID.Value].Add(hesapDetay);
                    }
                }
            }

            foreach (KeyValuePair<int, TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>> avanta in dosyaMasrafAvans)
            {
                HesapKalem hKalem = new HesapKalem();
                hKalem.Avanslar = avanta.Value;
                hKalem.MKategoriId = avanta.Key;
                TList<AV001_TDI_BIL_CARI_HESAP_DETAY> hesaplar = null;
                bool eklenDimi = dosyaHesaplari.TryGetValue(avanta.Key, out hesaplar);
                hKalem.Hesaplar = hesaplar;
                hKalem.Hesapla();
                myHesapKalems.Add(hKalem);
            }
            xgDosyadakiKalemler.DataSource = myHesapKalems;
            xgDosyadakiKalemler.RefreshDataSource();
            xgMuhasebelesmemisKalemler.DataSource =
                listMuhasebelesecekler = myHesapKalems.FindAll(delegate(HesapKalem obj) { return obj.KalanTutar > 0; }
                                             );
            xgMuhasebelesmemisKalemler.RefreshDataSource();
            xgMuvekkiller.DataSource = listMuvekkiller =
                                       mFoy.AV001_TI_BIL_FOY_TARAFCollection.FindAll(
                                           AV001_TI_BIL_FOY_TARAFColumn.TARAF_KODU,
                                           (byte)AvukatProLib.Extras.TarafKodu.Muvekkil);
            xgMuvekkiller.RefreshDataSource();
        }

        private string CariAdGetir(int cariId)
        {
            TList<AV001_TDI_BIL_CARI> myCariler = rlkCari.DataSource as TList<AV001_TDI_BIL_CARI>;
            if (myCariler != null)
            {
                AV001_TDI_BIL_CARI cari = myCariler.Find(AV001_TDI_BIL_CARIColumn.ID, cariId);
                if (cari != null)
                    return cari.AD;
            }
            return String.Empty;
        }

        private void rfrmMuhasebelestirme_Load(object sender, EventArgs e)
        {
            BelgeUtil.Inits.MuhasebeHareketAltKategori(rlkMuhasebeAltKategori);
            BelgeUtil.Inits.HareketAnaKategoriGetir(rlkMuhasebeAnaKategori);
            lookUpEdit1.Properties.DataSource = BelgeUtil.Inits.IcraDosyalariGetir();
            lookUpEdit1.Properties.DisplayMember = "FOY_NO";
            lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("FOY_NO", 100, "Dosya No"));
            BelgeUtil.Inits.DovizTipGetir(rlkDoviz);
            BelgeUtil.Inits.BorcAlacakGetir(rlkBorcAlacak);
            BelgeUtil.Inits.OdemeTipiGetir(rlkOdemeTipi);
            BelgeUtil.Inits.CariHesapGetir(rlkCariHesapId);
            BelgeUtil.Inits.perCariGetir(rlkCari);
            BelgeUtil.Inits.TarafKoduGetir(rlkTarafKodu);
            BelgeUtil.Inits.CariSifatGetir(rlkTarafSifat);
            BelgeUtil.Inits.CariPersonelGetir(lkMasrafiYapan.Properties);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lookUpEdit1.EditValue != null && lookUpEdit1.EditValue is AvukatProLib.Arama.per_AV001_TI_BIL_FOY)
            {
                AV001_TI_BIL_FOY foy =
                    DataRepository.AV001_TI_BIL_FOYProvider.GetByID(
                        ((AvukatProLib.Arama.per_AV001_TI_BIL_FOY)lookUpEdit1.EditValue).ID);
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(foy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TDI_BIL_MASRAF_AVANS>),
                                                                 typeof(TList<AV001_TDI_BIL_CARI_HESAP_DETAY>),
                                                                 typeof(TList<AV001_TI_BIL_FOY_TARAF>));
                DataRepository.AV001_TDI_BIL_MASRAF_AVANSProvider.DeepLoad(foy.AV001_TDI_BIL_MASRAF_AVANSCollection,
                                                                           false, DeepLoadType.IncludeChildren,
                                                                           typeof(
                                                                               TList<AV001_TDI_BIL_MASRAF_AVANS_DETAY>));
                inedi(foy);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            TList<AV001_TI_BIL_FOY_TARAF> seciliMuvekkiller =
                listMuvekkiller.FindAll(delegate(AV001_TI_BIL_FOY_TARAF trf) { return trf.IsSelected; });
            List<HesapKalem> seciliKayitlar =
                listMuhasebelesecekler.FindAll(delegate(HesapKalem klm) { return klm.SeciliMi; });
            TList<AV001_TDI_BIL_CARI_HESAP_DETAY> olusanlar =
                xgHesapDagilimi.DataSource as TList<AV001_TDI_BIL_CARI_HESAP_DETAY>;
            if (olusanlar == null)
                olusanlar = new TList<AV001_TDI_BIL_CARI_HESAP_DETAY>();
            foreach (AV001_TI_BIL_FOY_TARAF mvk in seciliMuvekkiller)
            {
                foreach (HesapKalem kalem in seciliKayitlar)
                {
                    if (kalem.KalanTutar > 0)
                    {
                        decimal kalanTutar = kalem.KalanTutar / seciliMuvekkiller.Count;
                        AV001_TDI_BIL_CARI_HESAP_DETAY dty = olusanlar.AddNew();
                        dty.HAREKET_ANA_KATEGORI_ID = kalem.MKategoriId;
                        dty.INCELENDI = true;
                        dty.ADET = 1;
                        dty.GENEL_TOPLAM = (kalanTutar / kalem.Avanslar.Count);
                        kalanTutar -= dty.GENEL_TOPLAM;
                        dty.BIRIM_FIYAT_DOVIZ_ID = 1;
                        dty.ODEME_TIP_ID = 1;
                        dty.BORC_ALACAK_ID = 2; // kalem.MKategori.CARI_BORCU_MU? 2:1;
                        dty.BIRIM_FIYAT = dty.GENEL_TOPLAM / dty.ADET;
                        dty.ICRA_FOY_ID = (lookUpEdit1.EditValue as AvukatProLib.Arama.per_AV001_TI_BIL_FOY).ID;
                        TList<AV001_TDI_BIL_CARI_HESAP> cariHesaplar =
                            DataRepository.AV001_TDI_BIL_CARI_HESAPProvider.GetByMASRAF_AVANS_ID(
                                kalem.Avanslar[0].MASRAF_AVANS_ID);
                        AV001_TDI_BIL_CARI_HESAP hsp = cariHesaplar.Find(AV001_TDI_BIL_CARI_HESAPColumn.CARI_ID,
                                                                         mvk.CARI_ID.Value);
                        if (hsp != null)
                        {
                            dty.CARI_HESAP_ID = hsp.ID;
                        }
                        else if (mvk.CARI_ID.HasValue)
                        {
                            AV001_TDI_BIL_CARI_HESAP tmpHesap = new AV001_TDI_BIL_CARI_HESAP();
                            tmpHesap.CARI_ID = mvk.CARI_ID.Value;
                            tmpHesap.MASRAF_AVANS_ID = kalem.Avanslar[0].MASRAF_AVANS_ID;
                            tmpHesap.CARI_ADI = CariAdGetir(mvk.CARI_ID.Value);
                            DataRepository.AV001_TDI_BIL_CARI_HESAPProvider.Save(tmpHesap);
                            if (tmpHesap.ID > 0)
                            {
                                dty.CARI_HESAP_ID = tmpHesap.ID;
                                TList<AV001_TDI_BIL_CARI_HESAP> hesaplar =
                                    rlkCariHesapId.DataSource as TList<AV001_TDI_BIL_CARI_HESAP>;
                                if (hesaplar != null)
                                {
                                    hesaplar.Add(tmpHesap);
                                }
                            }
                        }

                        if (kalem.Hesaplar == null)
                            kalem.Hesaplar = new TList<AV001_TDI_BIL_CARI_HESAP_DETAY>();
                        kalem.Hesaplar.Add(dty);
                        kalem.Hesapla();
                    }
                }
            }
            xgHesapDagilimi.DataSource = olusanlar;
            xgDosyadakiKalemler.RefreshDataSource();
            xgHesapDagilimi.RefreshDataSource();
        }

        private void xgHesapDagilimi_EmbeddedNavigator_ButtonClick(object sender,
                                                                   DevExpress.XtraEditors.NavigatorButtonClickEventArgs
                                                                       e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv =
                    xgHesapDagilimi.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                AV001_TDI_BIL_CARI_HESAP_DETAY dt = gv.GetFocusedRow() as AV001_TDI_BIL_CARI_HESAP_DETAY;
                foreach (HesapKalem hKlm in myHesapKalems)
                {
                    if (hKlm.Hesaplar != null)
                    {
                        bool sonuc = hKlm.Hesaplar.Remove(dt);
                        if (sonuc)
                            hKlm.Hesapla();
                    }
                }
                List<HesapKalem> muhaseKa = xgMuhasebelesmemisKalemler.DataSource as List<HesapKalem>;
                foreach (HesapKalem hKlm in muhaseKa)
                {
                    if (hKlm.Hesaplar != null)
                    {
                        bool sonuc = hKlm.Hesaplar.Remove(dt);
                        if (sonuc)
                            hKlm.Hesapla();
                    }
                }
                xgHesapDagilimi.RefreshDataSource();
                xgMuhasebelesmemisKalemler.RefreshDataSource();
            }
        }
    }
}