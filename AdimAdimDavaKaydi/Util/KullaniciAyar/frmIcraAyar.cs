using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace AdimAdimDavaKaydi.Util.KullaniciAyar
{
    public partial class frmIcraAyar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmIcraAyar()
        {
            InitializeComponent();
            frmIcraAyar_Load(this, null);
            this.sBtnOku.Click += simpleButton2_Click;
            lueBirim.EditValueChanged += lueBirim_EditValueChanged;
            lueKrediGrubu.EditValueChanged += lueKrediGrubu_EditValueChanged;
        }

        private void lueKrediGrubu_EditValueChanged(object sender, EventArgs e)
        {
            int krediGrupID = BelgeUtil.Inits.ToInt32(lueKrediGrubu.EditValue);
            BelgeUtil.Inits.KrediTipiGetirByKrediGrup(lueKrediTipi, krediGrupID);
        }

        private void lueBirim_EditValueChanged(object sender, EventArgs e)
        {
            int FoyBirimID = BelgeUtil.Inits.ToInt32(lueBirim.EditValue);
            BelgeUtil.Inits.KrediGrubuGetirByFoyBirimID(lueKrediGrubu, FoyBirimID);
            BelgeUtil.Inits.FoyYeriGetirByFoyBirimID(lueDosyaYeri, FoyBirimID);
        }

        public TList<AV001_TI_BIL_FOY_OZEL_KOD> OzelKodlar
        {
            get { return (TList<AV001_TI_BIL_FOY_OZEL_KOD>)bndFoyOzelKod.DataSource; }
            set { bndFoyOzelKod.DataSource = value; }
        }

        private List<TI_BIL_ICRA_KULLANICI_AYAR> myAyarlar;

        [Browsable(false)]
        public List<TI_BIL_ICRA_KULLANICI_AYAR> MyAyarlar
        {
            get { return myAyarlar; }
            set
            {
                if (value != null)
                    myAyarlar = value;
            }
        }

        //TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR
        private List<TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR> myAlacakNedenAyarlar;

        [Browsable(false)]
        public List<TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR> MyAlacakNedenAyarlar
        {
            get { return myAlacakNedenAyarlar; }
            set
            {
                if (value != null)

                    myAlacakNedenAyarlar = value;
            }
        }

        private TList<AV001_TI_BIL_ALACAK_NEDEN> alacakNeden;

        public TList<AV001_TI_BIL_ALACAK_NEDEN> AlacakNeden
        {
            get { return alacakNeden; }
            set
            {
                alacakNeden = value;
                AlacakNeden.AddingNew += AlacakNeden_AddingNew;
            }
        }

        public TList<AV001_TDI_BIL_CARI> Cariler
        {
            get { return (TList<AV001_TDI_BIL_CARI>)bndCari.DataSource; }
            set { bndCari.DataSource = value; }
        }

        private void AlacakNeden_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                AV001_TI_BIL_ALACAK_NEDEN a = new AV001_TI_BIL_ALACAK_NEDEN();
                a.ALACAK_NEDEN_KOD_ID = (int)lueAlacakNeden.EditValue;
                a.TO_ALACAK_FAIZ_TIP_ID = (int)lueToFaizTip.EditValue;
                a.TO_UYGULANACAK_FAIZ_ORANI = Convert.ToDouble(txtToFaizOrani2.Text);
                a.ALACAK_FAIZ_TIP_ID = (int)lueTSFaizTip.EditValue;
                a.UYGULANACAK_FAIZ_ORANI = Convert.ToDouble(speTSFaizOran.Text);
                e.NewObject = a;

                foreach (AV001_TI_BIL_FOY var in tempFoy)
                {
                    if (var.AV001_TI_BIL_ALACAK_NEDENCollection.Count == 0)
                    {
                        var.AV001_TI_BIL_ALACAK_NEDENCollection.Add(a);
                    }
                }
            }
            catch
            {
            }
        }

        private TList<AV001_TI_BIL_FOY> tempFoy = new TList<AV001_TI_BIL_FOY>();

        public List<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT> TarafSifat { get; set; }

        private void BindLookUps()
        {
            if (DesignMode)
                return;
            BelgeUtil.Inits.DosyaDurumGetir(lueDosyaDurum);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lueAdliBirimAdliye);
            BelgeUtil.Inits.AdliBirimNoGetir(lueBirimNo);
            BelgeUtil.Inits.BankaGetir(lueBanka);
            BelgeUtil.Inits.FoyBirimGetir(lueBirim);
            BelgeUtil.Inits.TahsilatdurumGetir(lueTahsilatDurum);
            BelgeUtil.Inits.CariAvukatGetir(lueSorAvu1);
            BelgeUtil.Inits.CariAvukatGetir(lueSorAvu2);
            BelgeUtil.Inits.SegmentGetir(lueSEgmentBolum);
            BelgeUtil.Inits.TakipKonusuGetir(rLueFormKonusu);
            BelgeUtil.Inits.FormTipiGetir(rLueFormTipi);
            BelgeUtil.Inits.AlacakNedenKodGetir(rlueAlacakNedeni);
            BelgeUtil.Inits.FoyOzelDurumGetir(lueOzelDurum.Properties);
            BelgeUtil.Inits.FoyOzelKodGetir(lkOzelKod1, 1, Modul.Icra);
            BelgeUtil.Inits.FoyOzelKodGetir(lkOzelKod2, 2, Modul.Icra);
            BelgeUtil.Inits.FoyOzelKodGetir(lkOzelKod3, 3, Modul.Icra);
            BelgeUtil.Inits.FoyOzelKodGetir(lkOzelKod4, 4, Modul.Icra);
            BelgeUtil.Inits.FormTipiGetir(lueFormTipi.Properties);
            BelgeUtil.Inits.FormTipiGetir(lueSEciliFormTip.Properties);
            BelgeUtil.Inits.FormTipiGetir((RepositoryItemLookUpEdit)persistentRepository1.Items[0]);
            BelgeUtil.Inits.TakipKonusuGetir((RepositoryItemLookUpEdit)persistentRepository1.Items[1]);
            BelgeUtil.Inits.FaizTipiGetir(lueToFaizTip);
            BelgeUtil.Inits.FaizTipiGetir(lueTSFaizTip);
            BelgeUtil.Inits.FaizTipiGetir(rlueTOFaizTip);
            BelgeUtil.Inits.FaizTipiGetir(rlueTSFaizTip);
            BelgeUtil.Inits.FaizTipiGetir((RepositoryItemLookUpEdit)persistentRepository1.Items[3]);
        }

        bool YuklendiMi = false;
        private void frmIcraAyar_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
            BindLookUps();
            lueBirim.EditValue = null;
            if (BelgeUtil.Inits._per_CariGetir == null)
            {
                BelgeUtil.Inits._per_CariGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.OrderBy(item => item.AD).ToList();
            }
            bndCari.DataSource = BelgeUtil.Inits._per_CariGetir;
            OzelKodlar = new TList<AV001_TI_BIL_FOY_OZEL_KOD>();

            AlacakNeden = new TList<AV001_TI_BIL_ALACAK_NEDEN>();
            if (BelgeUtil.Inits._CariSifatGetir == null)
            {
                BelgeUtil.Inits._CariSifatGetir = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.ToList();
            }
            TarafSifat = BelgeUtil.Inits._CariSifatGetir;
            CariYapilandir();

            #region <MB-20091216>

            //Formun açýlýþýnda eðer genel bilgiler önce girilip, kaydedilmiþse, bu bilgilerin formda ilgili yerlere gelmesi saðlanýyor.
            TList<TI_BIL_ICRA_KULLANICI_AYAR> ayar =
                DataRepository.TI_BIL_ICRA_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID);
            if (ayar != null && ayar.Count > 0)
            {
                IcraKullaniciAyarim = ayar[0];
                rgTarafKodu.SelectedIndex = IcraKullaniciAyarim.SECILI_MUVEKKIL_TARAF_KODU == 1 ? 0 : 1;
                rgTarafKodKarsiTar.SelectedIndex = rgTarafKodu.SelectedIndex == 0 ? 1 : 0;
            }
            else
                IcraKullaniciAyarim = new TI_BIL_ICRA_KULLANICI_AYAR();
            bndIcraGenelAyar.DataSource = IcraKullaniciAyarim;

            #endregion

            #region <MB-20091215>

            //Formun açýlýþýnda eðer alacak neden bilgileri önce girilip, kaydedilmiþse, bu bilgilerin formda ilgili yerlere gelmesi saðlanýyor.

            TList<TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR> alacakNedenAyar =
                DataRepository.TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYARProvider.GetByKULLANICI_ID(
                    AvukatProLib.Kimlik.Bilgi.ID);
            if (alacakNedenAyar != null && alacakNedenAyar.Count > 0)
            {
                IcraAlacakNedenAyarim = alacakNedenAyar[0];
                bndAlacakNedenAyar.DataSource = IcraAlacakNedenAyarim;
            }
            else
            {
                IcraAlacakNedenAyarim = new TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR();
                bndAlacakNedenAyar.AddNew();
            }

            #endregion

            KullaniciTanimliAlacakNedenleri();

            SifatGetir((TarafKodu)rgTarafKodu.SelectedIndex);
            //SifatGetir((TarafKodu)rgTarafKodKarsiTar.SelectedIndex);

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@KULLANICI_ID", AvukatProLib.Kimlik.Bilgi.ID);
            try
            {
                txtIBANNo.Text = "";
                txtIBANNo.Text = cn.ExecuteScalar("select isnull(MUDURLUK_IBAN_NO,'') as IBAN from dbo.TI_BIL_ICRA_KULLANICI_AYAR where KULLANICI_ID=@KULLANICI_ID").ToString();
            }
            catch { ;}

            YuklendiMi = true;
        }

        public enum TarafKodu
        {
            TakipEden = 0,
            TakipEdilen = 1
        }

        private void SifatGetir(TarafKodu t)
        {
            if (t == TarafKodu.TakipEden)
            {
                lueTarafSifat.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "TAKÝP EDEN");
                lueTarafSifat.Properties.ValueMember = "ID";
                lueTarafSifat.Properties.DisplayMember = "SIFAT";

                lueKarsiTarafSifat.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "TAKÝP EDÝLEN");
                lueKarsiTarafSifat.Properties.ValueMember = "ID";
                lueKarsiTarafSifat.Properties.DisplayMember = "SIFAT";
            }
            else if (t == TarafKodu.TakipEdilen)
            {
                lueTarafSifat.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "TAKÝP EDÝLEN");
                lueTarafSifat.Properties.ValueMember = "ID";
                lueTarafSifat.Properties.DisplayMember = "SIFAT";

                lueKarsiTarafSifat.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "TAKÝP EDEN");
                lueKarsiTarafSifat.Properties.ValueMember = "ID";
                lueKarsiTarafSifat.Properties.DisplayMember = "SIFAT";                
            }
        }

        private void CariYapilandir()
        {
            //Yönetici Avukat
            lueYonAvukat.Properties.DataSource = BelgeUtil.Inits._per_CariGetir.FindAll(item => item.PERSONEL_MI && item.YETKILI_MI);
            lueYonAvukat.Properties.DisplayMember = "AD";
            lueYonAvukat.Properties.ValueMember = "ID";

            //Müvekkil
            lueMuvekkil.Properties.DataSource = BelgeUtil.Inits._per_CariGetir.FindAll(item => item.MUVEKKIL_MI);
            lueMuvekkil.Properties.DisplayMember = "AD";
            lueMuvekkil.Properties.ValueMember = "ID";

            //KARÞI TARAF
            lueKarsiTaraf.Properties.DataSource = BelgeUtil.Inits._per_CariGetir.FindAll(item => item.KARSI_TARAF_MI);
            lueKarsiTaraf.Properties.DisplayMember = "AD";
            lueKarsiTaraf.Properties.ValueMember = "ID";
        }

        private void checkSorumlu_CheckedChanged(object sender, EventArgs e)
        {
            CheckState state = ((CheckEdit)sender).CheckState;

            switch (state)
            {
                case CheckState.Checked:
                    lueSorAvu1.Enabled = false;
                    lueSorAvu2.Enabled = false;
                    break;
                case CheckState.Indeterminate:
                    break;
                case CheckState.Unchecked:
                    lueSorAvu1.Enabled = true;
                    lueSorAvu2.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            XtraMessageBox.Show("Bu form tipi daha önce eklenmiþtir.", "Ýcra Kullanýcý Ayarlarý", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private TList<TI_BIL_ICRA_KULLANICI_AYAR> okutmaIcraGenelAyar = new TList<TI_BIL_ICRA_KULLANICI_AYAR>();

        private TList<TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR> okutmaIcraAlacakNedenAyar =
            new TList<TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR>();

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            #region <TIO - 20092207 > DB den Kullanýcýya Göre Okutuyoruz.

            okutmaIcraAlacakNedenAyar =
                DataRepository.TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYARProvider.GetByKULLANICI_ID(
                    AvukatProLib.Kimlik.Bilgi.ID);
            okutmaIcraGenelAyar =
                DataRepository.TI_BIL_ICRA_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID);
            if (okutmaIcraGenelAyar != null)
            {
                foreach (var IcraGenelOkutma in okutmaIcraGenelAyar)
                {
                    lueBirimNo.EditValue = IcraGenelOkutma.ADLI_BIRIM_NO_ID;
                    lueAdliBirimAdliye.EditValue = IcraGenelOkutma.ADLIYE_ID;
                    lueBanka.EditValue = IcraGenelOkutma.BANKA_ID;
                    lueSube.EditValue = IcraGenelOkutma.BANKA_SUBE_ID;
                    lueDosyaDurum.EditValue = IcraGenelOkutma.DOSYA_DURUM_ID;
                    lueDosyaYeri.EditValue = IcraGenelOkutma.DOSYA_YERI_ID;
                    lueBirim.EditValue = IcraGenelOkutma.FOY_BIRIM_ID;
                    txtKlasorKodu1.EditValue = IcraGenelOkutma.KLASOR_KODU_1;
                    txtKlasorKodu2.EditValue = IcraGenelOkutma.KLASOR_KODU_2;
                    lueKrediGrubu.EditValue = IcraGenelOkutma.KREDI_GRUP_ID;
                    lueKrediTipi.EditValue = IcraGenelOkutma.KREDI_TIP_ID;
                    lueOzelDurum.EditValue = IcraGenelOkutma.OZEL_DURUM_ID;
                    lkOzelKod1.EditValue = IcraGenelOkutma.OZEL_KOD_1_ID;
                    lkOzelKod2.EditValue = IcraGenelOkutma.OZEL_KOD_2_ID;
                    lkOzelKod3.EditValue = IcraGenelOkutma.OZEL_KOD_3_ID;
                    lkOzelKod4.EditValue = IcraGenelOkutma.OZEL_KOD_4_ID;
                    lueSEciliFormTip.EditValue = IcraGenelOkutma.SECILI_FORM_TIPI_ID;
                    lueKarsiTaraf.EditValue = IcraGenelOkutma.SECILI_KARSI_TARAF_CARI_ID;
                    lueKarsiTarafSifat.EditValue = IcraGenelOkutma.SECILI_KARSI_TARAF_SIFAT_ID;
                    rgTarafKodKarsiTar.EditValue = IcraGenelOkutma.SECILI_KARSI_TARAF_TARAF_KODU;
                    lueMuvekkil.EditValue = IcraGenelOkutma.SECILI_MUVEKKIL_CARI_ID;
                    lueTarafSifat.EditValue = IcraGenelOkutma.SECILI_MUVEKKIL_SIFAT_ID;
                    rgTarafKodu.EditValue = IcraGenelOkutma.SECILI_MUVEKKIL_TARAF_KODU;
                    lueSEgmentBolum.EditValue = IcraGenelOkutma.SEGMENT_BOLUM_ID;
                    lueSorAvu1.EditValue = IcraGenelOkutma.SORUMLU_1_AVUKAT_CARI_ID;
                    lueSorAvu2.EditValue = IcraGenelOkutma.SORUMLU_2_AVUKAT_CARI_ID;
                    lueTahsilatDurum.EditValue = IcraGenelOkutma.TAHSILAT_DURUM_ID;
                    lueYonAvukat.EditValue = IcraGenelOkutma.YONETICI_AVUKAT_CARI_ID;
                }
            }
            else
            {
                XtraMessageBox.Show(AvukatProLib.Kimlik.KullaniciAdi +
                                    " Kullanýcýsýna ait Ýcra Genel Ayarlarý Bulunamadý...");
            }
            if (okutmaIcraAlacakNedenAyar != null)
            {
                foreach (var IcraAlacakNedenOkutma in okutmaIcraAlacakNedenAyar)
                {
                    lueAlacakNeden.EditValue = IcraAlacakNedenOkutma.ALACAK_NEDENI_ID;
                    lueFormKonu.EditValue = IcraAlacakNedenOkutma.FORM_KONUSU_ID;
                    lueFormTipi.EditValue = IcraAlacakNedenOkutma.FORM_TIPI_ID;
                    txtToFaizOrani2.EditValue = IcraAlacakNedenOkutma.TO_FAIZ_ORAN;
                    lueToFaizTip.EditValue = IcraAlacakNedenOkutma.TO_FAIZ_TIP_ID;
                    lueTSFaizTip.EditValue = IcraAlacakNedenOkutma.TS_FAIZ_TIP_ID;
                    speTSFaizOran.EditValue = IcraAlacakNedenOkutma.TS_FAIZ_TIP_ORAN;
                }
            }
            else
            {
                XtraMessageBox.Show(AvukatProLib.Kimlik.KullaniciAdi +
                                    " Kullanýcýsýna ait Ýcra Alacak Neden Ayarlarý Bulunamadý...");
            }

            #endregion </TIO - 20092207 > DB den Kullanýcýya Göre Okutuyoruz.
        }

        private void lueFormTipi_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            TI_KOD_FORM_TIP tip = DataRepository.TI_KOD_FORM_TIPProvider.GetByID((int)lue.EditValue);
            lueFormKonu.Properties.DataSource = DataRepository.per_TI_KOD_TAKIP_TALEPProvider.Get("FORM_TIPI = " + tip.FORM_ORNEK_NO, "ID");
            lueFormKonu.Properties.DisplayMember = "TALEP_ADI";
            lueFormKonu.Properties.ValueMember = "ID";
        }

        private void lueToFaizTip_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.ToString() != "9")
                {
                    txtToFaizOrani2.Enabled = false;
                    txtToFaizOrani2.Text = string.Empty;
                    lueTSFaizTip.EditValue = e.Value;
                    //lueTSFaizTip.Enabled = false;
                    speTSFaizOran.Enabled = false;
                    speTSFaizOran.Text = string.Empty;
                }
                else
                {
                    txtToFaizOrani2.Enabled = true;
                    lueTSFaizTip.EditValue = e.Value;
                    speTSFaizOran.Enabled = true;
                }
            }
        }

        private void lueTSFaizTip_CloseUp(object sender, CloseUpEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.ToString() != "9")
                {
                    speTSFaizOran.Enabled = false;
                }
                else
                {
                    speTSFaizOran.Enabled = true;
                }
            }
        }

        private TI_BIL_ICRA_KULLANICI_AYAR IcraKullaniciAyarim = new TI_BIL_ICRA_KULLANICI_AYAR();

        private TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR IcraAlacakNedenAyarim =
            new TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR();

        public bool alacakNedenVar;
        private TList<TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR> icraAlacakNedenAyarlarByKullanici;

        public void KullaniciTanimliAlacakNedenleri()
        {
            icraAlacakNedenAyarlarByKullanici =
                DataRepository.TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYARProvider.GetByKULLANICI_ID(
                    AvukatProLib.Kimlik.Bilgi.ID);
            if (icraAlacakNedenAyarlarByKullanici.Count > 0)
                bndAlacakNedenAyar.DataSource = icraAlacakNedenAyarlarByKullanici;
        }

        private void sBtnYazArka_Click(object sender, EventArgs e)
        {
            if (alacakNedenVar)
            {
                //ALACAK NEDENLERI ÝLE KAYIT
                try
                {
                    //DialogResult dr =
                    //    XtraMessageBox.Show(
                    //        "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                    //        "Onaylýyor musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (dr == DialogResult.Yes)
                    //{
                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                    if (lueAlacakNeden.EditValue != null)
                    {
                        #region Ýcra Alacak Neden Kaydet

                        bndAlacakNedenAyar.EndEdit();
                        try
                        {
                            tran.BeginTransaction();
                            foreach (var item in bndAlacakNedenAyar.List)
                            {
                                var ayar = item as TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR;

                                ayar.KAYIT_TARIHI = DateTime.Now;
                                ayar.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;

                                DataRepository.TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYARProvider.Save(tran, ayar);
                            }
                            tran.Commit();
                            XtraMessageBox.Show("Alacak Neden Ayarlarý Kayýt Ýþlemi Tamamlanmýþtýr.");
                            KullaniciTanimliAlacakNedenleri();
                        }
                        catch (Exception ex)
                        {
                            if (tran.IsOpen)
                                tran.Rollback();
                            BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                        }

                        #endregion Ýcra Alacak Neden Kaydet
                    }
                    //}
                    //else
                    //    XtraMessageBox.Show("Kayýt Ýþlemlerini Onaylamadýðýnýz için Ýþlem Tamamlanamadý ... ");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Ayarlarýn Kaydý Sýrasýnda Bir Hata Oluþtu!");
                    BelgeUtil.ErrorHandler.Catch(this, ex, true, BelgeUtil.Bilesen.Kayit);
                }
            }
            else
            {
                // ALACAK NEDENLERI YOK !!
                try
                {
                    DialogResult dr =
                        XtraMessageBox.Show(
                            "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                            "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                        try
                        {
                            tran.BeginTransaction();
                            DataRepository.TI_BIL_ICRA_KULLANICI_AYARProvider.Save(tran, IcraKullaniciAyarim);
                            tran.Commit();
                            XtraMessageBox.Show("Ýcra Genel Ayarlarý Kayýt Ýþlemi Tamamlanmýþtýr.");
                        }
                        catch (Exception ex)
                        {
                            if (tran.IsOpen)
                                tran.Rollback();
                            BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                        }
                    }
                    else
                        XtraMessageBox.Show("Kayýt Ýþlemlerini Onaylamadýðýnýz için Ýþlem Tamamlanamadý! ");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Ayarlarýn Kaydý Sýrasýnda Bir Hata Oluþtu...");
                    BelgeUtil.ErrorHandler.Catch(this, ex, true, BelgeUtil.Bilesen.Kayit);
                }
            }
        }

        private TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI> ayarlar =
            new TList<AV001_TDIE_BIL_SABLON_RAPOR_YAZDIRMA_AYARLARI>();


        private TList<TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSUL> Kosullar =
            new TList<TDIE_KOD_SABLON_RAPOR_YAZDIRMA_AYAR_KOSUL>();

        private void sBtnYaz_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(rgTarafKodKarsiTar.EditValue) == false)
                IcraKullaniciAyarim.SECILI_KARSI_TARAF_TARAF_KODU = Convert.ToByte(TarafKodlari.K);
            else
                IcraKullaniciAyarim.SECILI_KARSI_TARAF_TARAF_KODU = Convert.ToByte(TarafKodlari.M);

            if (Convert.ToBoolean(rgTarafKodu.EditValue))
                IcraKullaniciAyarim.SECILI_MUVEKKIL_TARAF_KODU = Convert.ToByte(TarafKodlari.M);
            else
                IcraKullaniciAyarim.SECILI_MUVEKKIL_TARAF_KODU = Convert.ToByte(TarafKodlari.K);

            IcraKullaniciAyarim.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;

            if (alacakNedenVar)
            {
                //ALACAK NEDENLERI ÝLE KAYIT
                try
                {
                    DialogResult dr =
                        XtraMessageBox.Show(
                            "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                            "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                        #region Ýcra Genel Ayar Kaydet

                        try
                        {
                            tran.BeginTransaction();
                            DataRepository.TI_BIL_ICRA_KULLANICI_AYARProvider.Save(tran, IcraKullaniciAyarim);
                            tran.Commit();
                            XtraMessageBox.Show("Ýcra Genel Ayarlarý Kayýt Ýþlemi Tamamlanmýþtýr...");
                        }
                        catch (Exception ex)
                        {
                            if (tran.IsOpen)
                                tran.Rollback();
                            BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                        }

                        #endregion Ýcra Genel Ayar Kaydet
                    }
                    else
                        XtraMessageBox.Show("Kayýt Ýþlemlerini Onaylamadýðýnýz için Ýþlem Tamamlanamadý ... ");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Ayarlarýn Kaydý Sýrasýnda Bir Hata Oluþtu...");
                    BelgeUtil.ErrorHandler.Catch(this, ex, true, BelgeUtil.Bilesen.Kayit);
                }
            }
            else
            {
                // ALACAK NEDENLERI YOK !!
                try
                {
                    DialogResult dr =
                        XtraMessageBox.Show(
                            "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                            "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);
                        try
                        {
                            tran.BeginTransaction();
                            DataRepository.TI_BIL_ICRA_KULLANICI_AYARProvider.Save(tran, IcraKullaniciAyarim);
                            tran.Commit();
                            XtraMessageBox.Show("Ýcra Genel Ayarlarý Kayýt Ýþlemi Tamamlanmýþtýr...");
                        }
                        catch (Exception ex)
                        {
                            if (tran.IsOpen)
                                tran.Rollback();
                            BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                        }
                    }
                    else
                        XtraMessageBox.Show("Kayýt Ýþlemlerini Onaylamadýðýnýz için Ýþlem Tamamlanamadý ... ");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Ayarlarýn Kaydý Sýrasýnda Bir Hata Oluþtu...");
                    BelgeUtil.ErrorHandler.Catch(this, ex, true, BelgeUtil.Bilesen.Kayit);
                }
            }

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = AvukatProLib.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@KULLANICI_ID", AvukatProLib.Kimlik.Bilgi.ID);
            cn.AddParams("@MUDURLUK_IBAN_NO", txtIBANNo.Text);
            cn.ExcuteQuery("update dbo.TI_BIL_ICRA_KULLANICI_AYAR set MUDURLUK_IBAN_NO=@MUDURLUK_IBAN_NO where KULLANICI_ID=@KULLANICI_ID").ToString();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (!DesignMode)
            {
                //TAB DEÐÝÞTÝ
                if (e.Page.Name == tabAlacakNedenSecenek.Name)
                {
                    if (lueFormTipi.EditValue != null)
                    {
                        alacakNedenVar = true;
                    }
                }
            }
        }

        private void lueBanka_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBanka.EditValue != null)
                AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(lueSube, (int)lueBanka.EditValue);
                //BelgeUtil.Inits.BankaSubeGetir(lueSube, (int)lueBanka.EditValue);
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
            {
                TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR seciliAlacakNedenim =
                    icraAlacakNedenAyarlarByKullanici[e.FocusedRowHandle];

                int toFaizTip = seciliAlacakNedenim.TO_FAIZ_TIP_ID ?? 0;
                int tsFaizTip = seciliAlacakNedenim.TS_FAIZ_TIP_ID ?? 0;

                if (toFaizTip != 9)
                {
                    txtToFaizOrani2.Text = string.Empty;
                    txtToFaizOrani2.Enabled = false;
                }
                else
                    txtToFaizOrani2.Enabled = true;
                if (tsFaizTip != 9)
                {
                    speTSFaizOran.Text = string.Empty;
                    speTSFaizOran.Enabled = false;
                }
                else
                    speTSFaizOran.Enabled = true;
            }
        }

        private void lueFormKonu_EditValueChanged(object sender, EventArgs e)
        {
            if (lueFormKonu.EditValue != null)
            {
                int takipTalebiKonuID = Convert.ToInt32(lueFormKonu.EditValue);
                //BelgeUtil.Inits.AlacakNedenKodGetirByTakipTalebi(lueAlacakNeden, takipTalebiKonuID);
                BelgeUtil.Inits.AlacakNedeniDoldur(new RepositoryItemLookUpEdit[] { lueAlacakNeden.Properties }, takipTalebiKonuID);
            }
        }

        private void lueToFaizTip_EditValueChanged(object sender, EventArgs e)
        {
            if (lueToFaizTip.EditValue == null)
                return;
            (bndAlacakNedenAyar.Current as TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR).TO_FAIZ_TIP_ID = (int)lueToFaizTip.EditValue;
            (bndAlacakNedenAyar.Current as TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR).TO_FAIZ_ORAN = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)lueToFaizTip.EditValue, 1, DateTime.Today);


        }

        private void lueTSFaizTip_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTSFaizTip.EditValue == null)
                return;
            (bndAlacakNedenAyar.Current as TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR).TS_FAIZ_TIP_ID = (int)lueTSFaizTip.EditValue;
            (bndAlacakNedenAyar.Current as TI_BIL_ICRA_ALACAK_NEDEN_KULLANICI_AYAR).TS_FAIZ_TIP_ORAN = AvukatProLib.Hesap.FaizHelper.FaizOraniGetir((int)lueTSFaizTip.EditValue, 1, DateTime.Today);

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (var control in groupBox1.Controls)
            {
                Temizle(control);
            }
            foreach (var control in groupBox2.Controls)
            {
                Temizle(control);
            }
            foreach (var control in groupBox3.Controls)
            {
                Temizle(control);
            }
            bndIcraGenelAyar.Clear();

            try
            {
                DataRepository.TI_BIL_ICRA_KULLANICI_AYARProvider.Delete(IcraKullaniciAyarim);
            }
            catch
            {
                ;
            }
        }

        private void Temizle(object control)
        {
            if (control is TextEdit)
                (control as TextEdit).EditValue = null;
            else if (control is LookUpEdit)
                (control as LookUpEdit).EditValue = null;
            else if (control is CheckEdit)
                (control as CheckEdit).Checked = false;
        }

        private void rgTarafKodKarsiTar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!YuklendiMi)
                return;

            if (rgTarafKodKarsiTar.SelectedIndex == 0)
            {
                rgTarafKodu.SelectedIndex = 1;
            }
            else if (rgTarafKodKarsiTar.SelectedIndex == 1)
            {
                rgTarafKodu.SelectedIndex = 0;
            }

            //SifatGetir((TarafKodu)rgTarafKodKarsiTar.SelectedIndex);
            SifatGetir((TarafKodu)rgTarafKodu.SelectedIndex);
        }

        private void rgTarafKodu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!YuklendiMi)
                return;

            if (rgTarafKodu.SelectedIndex == 0)
            {
                rgTarafKodKarsiTar.SelectedIndex = 1;
            }
            else if (rgTarafKodu.SelectedIndex == 1)
            {
                rgTarafKodKarsiTar.SelectedIndex = 0;
            }

            //SifatGetir((TarafKodu)rgTarafKodKarsiTar.SelectedIndex);
            SifatGetir((TarafKodu)rgTarafKodu.SelectedIndex);
        }

        private void sBtnOku_Click(object sender, EventArgs e)
        {

        }
    }
}