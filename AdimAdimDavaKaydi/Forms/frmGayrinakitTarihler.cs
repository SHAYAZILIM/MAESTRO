using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public enum TarihTip
    {
        Tazmin,
        Iade,
        Depo,
        DepoOdeme
    }

    public partial class frmGayrinakitTarihler : Form
    {
        //Gayrinakit Alacaklarda Tazmin, iade, depo işlemleri yapıldığında gayrinakit üzerinde bu kırılımların görülebilmesi gerek. Aynı gayrimenkulde birden fazla tazmin, iade, depo yapılmış olabileceğinden bu işlem ayrı bir tablo aracılığı ile yapıldı. Tazmin, iade, depo miktarları gayrinakit tutarı üzerinden düşülüyor ve işleme konan tutar alanına yazılıyor. MB

        public frmGayrinakitTarihler()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmGayrinakitTarihler_Load);
        }

        #region Properties

        public int AlacakNedenID { get; set; }

        public int MyProjeID { get; set; }

        public AV001_TI_BIL_BORCLU_ODEME Odeme { get; set; }

        public TarihTip TarihTipi { get; set; }

        #endregion Properties

        #region Methods

        public void Show(int alacakNedenID, int projeID, TarihTip tarihTip)
        {
            this.MyProjeID = projeID;
            this.TarihTipi = tarihTip;
            this.AlacakNedenID = alacakNedenID;
            this.Show();
        }

        public void Show(AV001_TI_BIL_BORCLU_ODEME odeme, int projeID, int alacakNedenID, TarihTip tarihTip)
        {
            this.Odeme = odeme;

            //if (alacakNedenID == 0)
            //    this.Show(odeme.ALACAK_NEDEN_ID.Value, tarihTip);
            //else
            this.Show(alacakNedenID, projeID, tarihTip);
        }

        private void BindLookUps()
        {
            BelgeUtil.Inits.ParaBicimiAyarla(spTutar);
            BelgeUtil.Inits.ParaBicimiAyarla(spOdemeTutar);
            BelgeUtil.Inits.ParaBicimiAyarla(spGayriBakiye);
            BelgeUtil.Inits.ParaBicimiAyarla(spGayriTutar);
            BelgeUtil.Inits.DovizTipGetir(lueTutarDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueOdemeTutarDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueGayriBakiyeDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueGayriTutarDoviz);
        }

        private void SetGayrinakitBilgileri()
        {
            var alacakTakipli = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLIProvider.GetByKAYNAK_ALACAK_NEDEN_ID(AlacakNedenID).FirstOrDefault();
            if (alacakTakipli != null)
            {
                var alacak = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(alacakTakipli.ALACAK_NEDEN_ID);
                if (alacak != null)
                {
                    //AlacakNedenID = alacak.ID;
                    txtGayrinakit.EditValue = alacak.DIGER_ALACAK_NEDENI;
                    spGayriTutar.EditValue = alacak.TUTARI;
                    lueGayriTutarDoviz.EditValue = alacak.TUTAR_DOVIZ_ID;
                    spGayriBakiye.EditValue = alacak.ISLEME_KONAN_TUTAR;
                    lueGayriBakiyeDoviz.EditValue = alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                }
            }
            else
            {
                var gNakit = DataRepository.per_TAKIP_ALACAK_NEDENProvider.Get(string.Format("ID = {0}", AlacakNedenID), "ID").FirstOrDefault();
                txtGayrinakit.EditValue = gNakit.DIGER_ALACAK_NEDENI;
                spGayriTutar.EditValue = gNakit.TUTARI;
                lueGayriTutarDoviz.EditValue = gNakit.TUTAR_DOVIZ_ID;
                spGayriBakiye.EditValue = gNakit.ISLEME_KONAN_TUTAR;
                lueGayriBakiyeDoviz.EditValue = gNakit.ISLEME_KONAN_TUTAR_DOVIZ_ID;
            }
            dtTarih.EditValue = DateTime.Today.Date;
            spTutar.EditValue = spGayriBakiye.EditValue;
            lueTutarDoviz.EditValue = lueGayriBakiyeDoviz.EditValue;
        }

        private void SetItemsFromXML(TarihTip tarihTip)
        {
            if (tarihTip == null) return;

            switch (tarihTip)
            {
                case TarihTip.Tazmin:
                    lcTarih.RestoreLayoutFromXml(Application.StartupPath + "\\GayrinakitTarihleri\\Tazmin.xml");
                    this.Text = "Tazmin Bilgileri";
                    break;

                case TarihTip.Iade:
                    lcTarih.RestoreLayoutFromXml(Application.StartupPath + "\\GayrinakitTarihleri\\Iade.xml");
                    this.Text = "İade Bilgileri";
                    break;

                case TarihTip.Depo:
                    var alacak = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(AlacakNedenID);
                    var test = BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.Where(vi => vi.ALACAK_NEDEN_ID == AlacakNedenID && vi.TAZMIN_TARIHI.HasValue).ToList();

                    if (test.Sum(vi => vi.TAZMIN_TUTARI.Value) >= alacak.TUTARI)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Depo edilecek gayrinakit kalmadı, hepsi nakde dönüştü.\r\nNakde ödeme giriniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();
                        return;
                    }

                    lcTarih.RestoreLayoutFromXml(Application.StartupPath + "\\GayrinakitTarihleri\\Depo.xml");
                    BelgeUtil.Inits.perCariGetir(lueSahis);
                    this.Text = "Depo Bilgileri";
                    break;

                case TarihTip.DepoOdeme:
                    lcTarih.RestoreLayoutFromXml(Application.StartupPath + "\\GayrinakitTarihleri\\DepoOdeme.xml");
                    BelgeUtil.Inits.perCariGetir(lueSahis);
                    BelgeUtil.Inits.perCariGetir(lueOdemeYapan);
                    this.Text = "Depo / Tazmin Bilgileri";
                    break;

                default:
                    break;
            }
        }

        #endregion Methods

        #region Events

        private void frmGayrinakitTarihler_Load(object sender, EventArgs e)
        {
            BindLookUps();
            SetItemsFromXML(TarihTipi);
            SetGayrinakitBilgileri();
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            AvukatProLib.Arama.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAY gayriDetay = new AvukatProLib.Arama.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAY();
            gayriDetay.ALACAK_NEDEN_ID = AlacakNedenID;

            var alacak = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(AlacakNedenID);
            var kontrol = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByPROJE_IDFromAV001_TDIE_BIL_PROJE_ALACAK_NEDEN_TAKIPLI(MyProjeID);
            if (kontrol != null && kontrol.Count > 0)
            {
                foreach (var item in kontrol)
                {
                    if (!AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item)) continue;
                    if (item.REFERANS_ALACAK_NEDEN_ID.HasValue)
                    {
                        AV001_TI_BIL_ALACAK_NEDEN neden = new AV001_TI_BIL_ALACAK_NEDEN();
                        if (item.REFERANS_ALACAK_NEDEN_ID == alacak.ID)
                            alacak.ISLEME_KONAN_TUTAR = item.ISLEME_KONAN_TUTAR;

                        //var neden = kontrol.FindAll(vi => vi.REFERANS_ALACAK_NEDEN_ID == alacak.ID).FirstOrDefault();
                        //if (neden != null) alacak.ISLEME_KONAN_TUTAR = neden.ISLEME_KONAN_TUTAR;
                    }
                    else
                    {
                        AV001_TDIE_BIL_PROJE_ALACAK_NEDEN takipsizAlacak = DataRepository.AV001_TDIE_BIL_PROJE_ALACAK_NEDENProvider.GetByPROJE_ID(MyProjeID).Find(vi => vi.ALACAK_NEDEN_ID == AlacakNedenID);

                        var aNedenTakipsiz = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.GetByID(takipsizAlacak.ALACAK_NEDEN_ID);
                        if (aNedenTakipsiz.DIGER_ALACAK_NEDENI == item.DIGER_ALACAK_NEDENI && aNedenTakipsiz.TUTARI == item.TUTARI)
                            alacak.ISLEME_KONAN_TUTAR = item.ISLEME_KONAN_TUTAR;
                    }
                }
            }

            #region Alanlar Kontrol

            switch (TarihTipi)
            {
                case TarihTip.Tazmin:
                    gayriDetay.TAZMIN_TARIHI = (DateTime)dtTarih.EditValue;
                    gayriDetay.TAZMIN_TUTARI = (decimal)spTutar.EditValue;
                    gayriDetay.TAZMIN_TUTARI_DOVIZ_ID = (int)lueTutarDoviz.EditValue;
                    alacak.ISLEME_KONAN_TUTAR -= gayriDetay.TAZMIN_TUTARI.Value;
                    break;

                case TarihTip.Iade:
                    gayriDetay.IADE_TARIHI = (DateTime)dtTarih.EditValue;
                    gayriDetay.IADE_TUTARI = (decimal)spTutar.EditValue;
                    gayriDetay.IADE_TUTARI_DOVIZ_ID = (int)lueTutarDoviz.EditValue;
                    alacak.ISLEME_KONAN_TUTAR -= gayriDetay.IADE_TUTARI.Value;
                    break;

                case TarihTip.Depo:
                case TarihTip.DepoOdeme:
                    gayriDetay.DEPO_TARIHI = (DateTime)dtTarih.EditValue;
                    gayriDetay.DEPO_TUTARI = (decimal)spTutar.EditValue;
                    gayriDetay.DEPO_TUTARI_DOVIZ_ID = (int)lueTutarDoviz.EditValue;
                    gayriDetay.DEPO_EDEN = (int)lueSahis.EditValue;
                    alacak.ISLEME_KONAN_TUTAR -= gayriDetay.DEPO_TUTARI.Value;
                    break;

                default:
                    break;
            }

            #endregion Alanlar Kontrol

            BelgeUtil.Inits.context.AV001_TI_BIL_ALACAK_NEDEN_GAYRINAKIT_DETAYs.InsertOnSubmit(gayriDetay);

            try
            {
                BelgeUtil.Inits.context.SubmitChanges();

                if (TarihTipi == TarihTip.DepoOdeme)
                {
                    Odeme.ODEME_MIKTAR = (decimal)spOdemeTutar.EditValue;
                    Odeme.ODEME_MIKTAR_DOVIZ_ID = (int)lueOdemeTutarDoviz.EditValue;

                    DataRepository.AV001_TI_BIL_BORCLU_ODEMEProvider.DeepSave(Odeme, DeepSaveType.IncludeChildren, typeof(TList<AV001_TDIE_BIL_PROJE_ICRA_BORCLU_ODEME>));
                }

                TList<AV001_TI_BIL_ALACAK_NEDEN> alacakList = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
                if (alacakList.Find(vi => vi.ID == alacak.ID) == null) alacakList.Add(alacak);

                var list = DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.Find("REFERANS_ALACAK_NEDEN_ID = " + alacak.ID.ToString());
                foreach (var item in list)
                {
                    item.ISLEME_KONAN_TUTAR = alacak.ISLEME_KONAN_TUTAR;
                    item.ISLEME_KONAN_TUTAR_DOVIZ_ID = alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                    if (alacakList.Find(vi => vi.ID == item.ID) == null) alacakList.Add(item);
                }
                if (list.Count == 0)
                {
                    foreach (var item in kontrol)
                    {
                        if (!AvukatProLib.Hesap.HesapAraclari.Icra.AlacakNedenDepoAlacagiMi(item) || item.REFERANS_ALACAK_NEDEN_ID.HasValue) continue;
                        if (alacak.DIGER_ALACAK_NEDENI == item.DIGER_ALACAK_NEDENI && alacak.TUTARI == item.TUTARI)
                        {
                            item.ISLEME_KONAN_TUTAR = alacak.ISLEME_KONAN_TUTAR;
                            item.ISLEME_KONAN_TUTAR_DOVIZ_ID = alacak.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                            if (alacakList.Find(vi => vi.ID == item.ID) == null) alacakList.Add(item);
                        }
                    }
                }

                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.Save(alacakList);

                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydedildi.", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
                DevExpress.XtraEditors.XtraMessageBox.Show("Kaydedilemedi.", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        #endregion Events
    }
}