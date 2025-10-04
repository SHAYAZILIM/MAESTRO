using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmIlamMahkemesiTarafli : Util.BaseClasses.AvpXtraForm
    {
        public frmIlamMahkemesiTarafli()
        {
            InitializeComponent();
            InitializeEvents();
        }

        public TList<AV001_TI_BIL_ILAM_MAHKEMESI> İlamList = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();

        private AV001_TDIE_BIL_PROJE _MyProje;

        public event EventHandler<EventArgs> Kaydedildi;

        [Browsable(false)]
        public AV001_TDIE_BIL_PROJE MyProje
        {
            get { return _MyProje; }
            set
            {
                _MyProje = value;
                if (value != null)
                {
                    //Eğer klasör den geliniyor ise yeni bir collection oluşturuyoruz.
                    if (İlamList.Count == 0)
                    {
                        İlamList = new TList<AV001_TI_BIL_ILAM_MAHKEMESI>();
                        ucIlamMahkemesi1.MyDataSource = İlamList;
                        İlamList.AddingNew += İlamList_AddingNew;

                        ucIlamMahkemesi1.MyDataSource.AddNew();
                    }
                    else
                    {
                        ucIlamMahkemesi1.MyDataSource = İlamList;
                    }

                    if (ucIlamMahkemesi1.MyDataSource[0].AV001_TI_BIL_ILAM_MAHKEMESI_TARAFCollection.Count == 0)
                        DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepLoad(ucIlamMahkemesi1.MyDataSource[0],
                                                                                    false, DeepLoadType.IncludeChildren,
                                                                                    typeof(
                                                                                        TList
                                                                                        <
                                                                                        AV001_TI_BIL_ILAM_MAHKEMESI_TARAF
                                                                                        >),
                                                                                    typeof(
                                                                                        TList
                                                                                        <
                                                                                        AV001_TDIE_BIL_PROJE_ILAM_BILGILERI
                                                                                        >));
                    ucIlamTarafBilgileri1.MyDaTaSource =
                        ucIlamMahkemesi1.MyDataSource[0].AV001_TI_BIL_ILAM_MAHKEMESI_TARAFCollection;
                }
            }
        }

        public void ShowDialog(AV001_TDIE_BIL_PROJE proje)
        {
            this.MyProje = proje;
            this.Show();
        }

        private void frmIlamMahkemesiTarafli_Button_Kaydet_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                XtraMessageBox.Show
                    ("Kayıt Başaralı.");
                this.Close();
            }

            else
            {
                XtraMessageBox.Show
                    ("Kayıt Esnasında Hata Oluştu." + Environment.NewLine + "Dosya Kaydedilemedi.", "Kayıt",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeEvents()
        {
            this.EventlerKullanilacakMi = true;
            this.Button_Kaydet_Click += frmIlamMahkemesiTarafli_Button_Kaydet_Click;
        }

        private void İlamList_AddingNew(object sender, AddingNewEventArgs e)
        {
            AV001_TI_BIL_ILAM_MAHKEMESI entity = e.NewObject as AV001_TI_BIL_ILAM_MAHKEMESI;
            if (entity == null)
                entity = new AV001_TI_BIL_ILAM_MAHKEMESI();

            entity.KARAR_TARIHI = DateTime.Today;
            entity.KAYIT_TARIHI = DateTime.Today;
            entity.KLASOR_KODU = AvukatProLib.Kimlik.CurrentKlasorKodu;
            entity.KONTROL_KIM = "AVUKATPRO";
            entity.KONTROL_NE_ZAMAN = DateTime.Today;
            entity.KONTROL_VERSIYON = AvukatProLib.Kimlik.DefaultKontrolVersiyon;
            entity.STAMP = AvukatProLib.Kimlik.DefaultStamp;
            entity.SUBE_KOD_ID = AvukatProLib.Kimlik.SubeKodu;

            if (MyProje != null)
            {
                entity.AV001_TI_BIL_ILAM_MAHKEMESI_TARAFCollection.Clear();
                foreach (AV001_TDIE_BIL_PROJE_TARAF pTrf in MyProje.AV001_TDIE_BIL_PROJE_TARAFCollection)
                {
                    AV001_TI_BIL_ILAM_MAHKEMESI_TARAF acima =
                        entity.AV001_TI_BIL_ILAM_MAHKEMESI_TARAFCollection.AddNew();
                    acima.ILAM_TARAF_CARI_ID = pTrf.CARI_ID;

                    if (pTrf.CARI_IDSource != null && pTrf.CARI_IDSource.MUVEKKIL_MI)
                    {
                        acima.TARAF_SIFAT_ID = (int)AvukatProLib.Extras.TarafSifat.DAVACI;
                        acima.TARAF_KOD_ID = (int)AvukatProLib.Extras.TarafKodu.Muvekkil;
                    }

                    else
                    {
                        acima.TARAF_SIFAT_ID = (int)AvukatProLib.Extras.TarafSifat.DAVALI;
                        acima.TARAF_KOD_ID = (int)AvukatProLib.Extras.TarafKodu.KarsiTaraf;
                    }
                }
            }
            e.NewObject = entity;
        }

        private bool Save()
        {
            TransactionManager trans = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

            try
            {
                trans.BeginTransaction();

                DataRepository.AV001_TI_BIL_ILAM_MAHKEMESIProvider.DeepSave(trans, ucIlamMahkemesi1.MyDataSource,
                                                                            DeepSaveType.IncludeChildren,
                                                                            typeof(
                                                                                TList<AV001_TI_BIL_ILAM_MAHKEMESI_TARAF>
                                                                                ));
                foreach (AV001_TI_BIL_ILAM_MAHKEMESI iHaciz in ucIlamMahkemesi1.MyDataSource)
                {
                    if (
                        MyProje.AV001_TDIE_BIL_PROJE_ILAM_BILGILERICollection.Exists(
                            delegate(AV001_TDIE_BIL_PROJE_ILAM_BILGILERI kiymetliEvrak) { return kiymetliEvrak.ILAM_ID == iHaciz.ID; })) continue;

                    AV001_TDIE_BIL_PROJE_ILAM_BILGILERI pHaciz = new AV001_TDIE_BIL_PROJE_ILAM_BILGILERI();
                    pHaciz.PROJE_ID = MyProje.ID;
                    pHaciz.ILAM_ID = iHaciz.ID;
                    DataRepository.AV001_TDIE_BIL_PROJE_ILAM_BILGILERIProvider.Save(trans, pHaciz);
                }

                trans.Commit();
                if (this.Kaydedildi != null)
                    Kaydedildi(this, null);
            }
            catch (Exception ex)
            {
                if (trans.IsOpen)
                    trans.Rollback();

                BelgeUtil.ErrorHandler.Catch(this, ex);

                return false;
            }

            return true;
        }
    }
}