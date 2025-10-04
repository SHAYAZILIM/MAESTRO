using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmAlacakNedenTarafEkleme : Form
    {
        public frmAlacakNedenTarafEkleme()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmAlacakNedenTarafEkleme_Load);
        }

        private AV001_TI_BIL_FOY _MyIcraFoy;

        public AV001_TI_BIL_FOY MyIcraFoy
        {
            get { return _MyIcraFoy; }
            set
            {
                _MyIcraFoy = value;

                TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF> aNedenTarafList = new TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>();

                if (_MyIcraFoy.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(_MyIcraFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepLoad(_MyIcraFoy.AV001_TI_BIL_ALACAK_NEDENCollection, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));

                foreach (var item in _MyIcraFoy.AV001_TI_BIL_ALACAK_NEDENCollection)
                {
                    AV001_TI_BIL_ALACAK_NEDEN_TARAF aNedenTaraf = item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection.AddNew();
                    aNedenTaraf.ICRA_ALACAK_NEDEN_ID = item.ID;
                    aNedenTaraf.TARAF_CARI_ID = TarafCariID;
                    aNedenTaraf.TARAF_SIFAT_ID = TarafSifatID;

                    if (TarafSifatID != 1)//Aşağıdaki değerler alacaklıda olmamalı.
                    {
                        aNedenTaraf.SORUMLU_OLUNAN_MIKTAR = item.ISLEME_KONAN_TUTAR;
                        aNedenTaraf.SORUMLU_OLUNAN_MIKTAR_DOVIZ_ID = item.ISLEME_KONAN_TUTAR_DOVIZ_ID;
                        aNedenTaraf.IHTAR_TARIHI = item.IHTAR_TARIHI;
                        aNedenTaraf.IHTAR_GIDERI = item.IHTAR_GIDERI;
                        aNedenTaraf.IHTAR_GIDERI_DOVIZ_ID = item.IHTAR_GIDERI_DOVIZ_ID;

                        AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ aNedenTarafFaiz = aNedenTaraf.AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZCollection.AddNew();
                        aNedenTarafFaiz.ALACAK_NEDEN_TARAF_ID = TarafCariID;
                        aNedenTarafFaiz.FAIZ_BASLANGIC_TARIHI = item.FAIZ_BASLANGIC_TARIHI;
                        aNedenTarafFaiz.FAIZ_BITIS_TARIHI = _MyIcraFoy.TAKIP_TARIHI;
                        aNedenTarafFaiz.FAIZ_ORANI = item.TO_UYGULANACAK_FAIZ_ORANI;
                        aNedenTarafFaiz.SABIT_FAIZ = item.SABIT_FAIZ_UYGULA;
                        aNedenTarafFaiz.KAYIT_TARIHI = DateTime.Now;
                        aNedenTarafFaiz.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
                        aNedenTarafFaiz.KONTROL_KIM = "AVUKATPRO";
                        aNedenTarafFaiz.KONTROL_NE_ZAMAN = DateTime.Now;
                        aNedenTarafFaiz.STAMP = AvukatProLib.Kimlik.DefaultStamp;
                    }
                    if (!aNedenTarafList.Contains(aNedenTaraf)) aNedenTarafList.Add(aNedenTaraf);
                }
                bndTaraflar.DataSource = aNedenTarafList;
            }
        }

        public int TarafCariID { get; set; }

        public int TarafSifatID { get; set; }

        public void Show(AV001_TI_BIL_FOY foy, int tarafCariID, int tarafSifatID)
        {
            this.TarafSifatID = tarafSifatID;
            this.TarafCariID = tarafCariID;
            this.MyIcraFoy = foy;
            this.Show();
        }

        private void BindLookUps()
        {
            BelgeUtil.Inits.AlacakNedenByFoy(_MyIcraFoy, glueAlacakNedeni.Properties);
            BelgeUtil.Inits.DovizTipGetir(lueSorumluOlunanMiktarDoviz);
            BelgeUtil.Inits.DovizTipGetir(lueIhtarGideriDoviz);
            BelgeUtil.Inits.ParaBicimiAyarla(spIhtarGideri);
            BelgeUtil.Inits.ParaBicimiAyarla(spSorumluOlunanMiktar);
            BelgeUtil.Inits.AlacakNedenKodGetir(rlueAacakNedeni);
        }

        private void frmAlacakNedenTarafEkleme_Load(object sender, EventArgs e)
        {
            BindLookUps();
        }

        private void sbtnTamamla_Click(object sender, EventArgs e)
        {
            TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
            try
            {
                tran.BeginTransaction();
                DataRepository.AV001_TI_BIL_FOYProvider.DeepSave(tran, _MyIcraFoy, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN>));
                DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.DeepSave(tran, _MyIcraFoy.AV001_TI_BIL_ALACAK_NEDENCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF>));
                _MyIcraFoy.AV001_TI_BIL_ALACAK_NEDENCollection.ForEach(item => DataRepository.AV001_TI_BIL_ALACAK_NEDEN_TARAFProvider.DeepSave(tran, item.AV001_TI_BIL_ALACAK_NEDEN_TARAFCollection, DeepSaveType.IncludeChildren, typeof(TList<AV001_TI_BIL_ALACAK_NEDEN_TARAF_FAIZ>)));

                tran.Commit();
                MessageBox.Show("Kayıt Başarılı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (tran.IsOpen)
                    tran.Rollback();
                BelgeUtil.ErrorHandler.Catch(this, ex);
                MessageBox.Show("Kayıt Başarısız.", "İPTAL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}