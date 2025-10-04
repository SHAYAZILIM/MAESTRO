using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Util.KullaniciAyar
{
    public partial class frmDavaAyar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmDavaAyar()
        {
            InitializeComponent();
            frmDavaAyar_Load(this, null);
        }

        private TList<AV001_TD_BIL_FOY> _myfoy;

        public TList<AV001_TD_BIL_FOY> MyFoy
        {
            get { return _myfoy; }
            set
            {
                if (value != null)
                    value.AddingNew += MyFoy_AddingNew;
                _myfoy = value;
                bndDavaFoy.DataSource = _myfoy;
            }
        }

        private List<TD_BIL_DAVA_KULLANICI_AYAR> myAyarlar;

        [Browsable(false)]
        public List<TD_BIL_DAVA_KULLANICI_AYAR> MyAyarlar
        {
            get { return myAyarlar; }
            set
            {
                if (value != null)
                    myAyarlar = value;
            }
        }

        public TList<AV001_TD_BIL_FOY_SORUMLU_AVUKAT> DavaSorumluAvukat { get; set; }

        public TList<AV001_TD_BIL_FOY_OZEL_KOD> DavaFoyOzelKod { get; set; }

        private TList<AV001_TD_BIL_FOY> tempDavaFoy = new TList<AV001_TD_BIL_FOY>();

        private void MyFoy_AddingNew(object sender, AddingNewEventArgs e)
        {
            //FOY ADDING NEW
            try
            {
                AV001_TD_BIL_FOY d = new AV001_TD_BIL_FOY();
                d.FOY_DURUM_ID = Convert.ToInt32(lkDosyadurum.EditValue);
                d.ADLI_BIRIM_GOREV_ID = Convert.ToInt32(lkMahkemeGorev.EditValue);
                d.ADLI_BIRIM_NO_ID = Convert.ToInt32(lueMahkemeNo.EditValue);
                d.FOY_NO = Convert.ToString(txteDosyaBaslangicSeri.EditValue);
                d.DAVA_OZEL_KOD1_ID = Convert.ToInt32(lueOzelKod1.EditValue);
                d.DAVA_OZEL_KOD2_ID = Convert.ToInt32(lueOzelKod2.EditValue);
                d.DAVA_OZEL_KOD3_ID = Convert.ToInt32(lueOzelKod3.EditValue);
                d.DAVA_OZEL_KOD4_ID = Convert.ToInt32(lueOzelKod4.EditValue);
                e.NewObject = d;
                tempDavaFoy.Add(d);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT> TarafSifat = new List<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT>();

        private void frmDavaAyar_Load(object sender, EventArgs e)
        {
            //LOAD
            LookUpDoldur();
            if (BelgeUtil.Inits._CariSifatGetir == null)
            {
                BelgeUtil.Inits._CariSifatGetir = BelgeUtil.Inits.context.per_TDIE_KOD_TARAF_SIFATs.ToList();
            }
            TarafSifat = BelgeUtil.Inits._CariSifatGetir;

            #region <MB-20091221>

            //Formun açýlýþýnda eðer genel bilgiler önce girilip, kaydedilmiþse, bu bilgilerin formda ilgili yerlere gelmesi saðlanýyor.
            TList<TD_BIL_DAVA_KULLANICI_AYAR> ayar =
                DataRepository.TD_BIL_DAVA_KULLANICI_AYARProvider.GetByKULLANICI_ID(AvukatProLib.Kimlik.Bilgi.ID);

            if (ayar != null && ayar.Count > 0)
            {
                davaGenelAyarim = ayar[0];
                rgKarsiTarafKod.SelectedIndex = davaGenelAyarim.KARSI_TARAF_TARAF_KODU.Value;
                rgTarafKodu.SelectedIndex = Convert.ToByte(davaGenelAyarim.SECILI_MUVEKKIL_TARAF_KODU);

                if (davaGenelAyarim.SORUMLU_1_AVUKAT_CARI_ID != null || davaGenelAyarim.SORUMLU_2_AVUKAT_CARI_ID != null)
                    cheSorumluAvukat.Checked = false;
                else
                    cheSorumluAvukat.Checked = true;
            }
            else
                davaGenelAyarim = new TD_BIL_DAVA_KULLANICI_AYAR();
            bndDavaGenelAyar.DataSource = davaGenelAyarim;

            #endregion

            if (rgTarafKodu.SelectedIndex != -1 && rgTarafKodu.SelectedIndex != null)
                SifatGetir((TarafKodu)rgTarafKodu.SelectedIndex);
            if (rgKarsiTarafKod.SelectedIndex != -1 && rgKarsiTarafKod.SelectedIndex != null)
                SifatGetir((TarafKodu)rgKarsiTarafKod.SelectedIndex);
        }

        public void LookUpDoldur()
        {
            BelgeUtil.Inits.FoyBirimGetir(lkBirim);
            BelgeUtil.Inits.perCariGetir(lkSeciliMuvekkil.Properties);
            BelgeUtil.Inits.perCariGetir(lkSeciliKarsiTaraf.Properties);
            BelgeUtil.Inits.perCariAvukatGetir(lkYoneticiAvuk.Properties);
            BelgeUtil.Inits.AdliBirimNoGetir(lueMahkemeNo);
            BelgeUtil.Inits.DosyaDurumGetir(lkDosyadurum);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(lkMahkemeAd);
            BelgeUtil.Inits.AdliBirimGorevGetir(lkMahkemeGorev);
            BelgeUtil.Inits.BankaGetir(lkBankaAd);
            BelgeUtil.Inits.KrediTipiGetir(lkKrediTipi);
            BelgeUtil.Inits.SegmentGetir(lueSegmentBolum);
            BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod1, 1, AvukatProLib.Extras.Modul.Dava);
            BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod2, 2, AvukatProLib.Extras.Modul.Dava);
            BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod3, 3, AvukatProLib.Extras.Modul.Dava);
            BelgeUtil.Inits.FoyOzelKodGetir(lueOzelKod4, 4, AvukatProLib.Extras.Modul.Dava);
            MyFoy = new TList<AV001_TD_BIL_FOY>();
        }

        private void cheSorumluAvukat_CheckedChanged(object sender, EventArgs e)
        {
            CheckState state = ((CheckEdit)sender).CheckState;

            switch (state)
            {
                case CheckState.Checked:
                    lkSorumluAvukat1.Enabled = false;
                    lkSorumluAvukat2.Enabled = false;
                    break;
                case CheckState.Indeterminate:
                    break;
                case CheckState.Unchecked:
                    lkSorumluAvukat1.Enabled = true;
                    lkSorumluAvukat2.Enabled = true;
                    BelgeUtil.Inits.CariAvukatGetir(lkSorumluAvukat1);
                    BelgeUtil.Inits.CariPersonelGetir(lkSorumluAvukat2);
                    break;
                default:
                    break;
            }
        }

        private void lkKrediTipi_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (e.Value != null)
            {
                BelgeUtil.Inits.KrediTipiGetirByKrediGrup(lkKrediTipi, Convert.ToInt32(e.Value));
            }
        }

        private TD_BIL_DAVA_KULLANICI_AYAR davaGenelAyarim = new TD_BIL_DAVA_KULLANICI_AYAR();

        private void sBtnKaydet_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(rgKarsiTarafKod.EditValue) == 3)
                davaGenelAyarim.KARSI_TARAF_TARAF_KODU = Convert.ToByte(TarafKodlari.K);
            else
                davaGenelAyarim.KARSI_TARAF_TARAF_KODU = Convert.ToByte(TarafKodlari.M);

            if (Convert.ToInt32(rgTarafKod.EditValue) == 1)
                davaGenelAyarim.SECILI_MUVEKKIL_TARAF_KODU = Convert.ToByte(TarafKodlari.M);
            else
                davaGenelAyarim.SECILI_MUVEKKIL_TARAF_KODU = Convert.ToByte(TarafKodlari.K);

            davaGenelAyarim.KULLANICI_ID = AvukatProLib.Kimlik.Bilgi.ID;

            try
            {
                DialogResult dr =
                    XtraMessageBox.Show(
                        "Ýlgili kayýtlarda yaptýðýnýz tüm deðiþiklikler kaydedilecektir" + Environment.NewLine +
                        "Onaylýyormusunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    TransactionManager tran = new TransactionManager(AvukatProLib.Kimlik.SirketBilgisi.ConStr);

                    #region Dava Genel Ayarlar Kaydet

                    try
                    {
                        tran.BeginTransaction();
                        DataRepository.TD_BIL_DAVA_KULLANICI_AYARProvider.Save(tran, davaGenelAyarim);
                        tran.Commit();
                        XtraMessageBox.Show("Dava Genel Ayarlarýn Kayýt Ýþlemi Tamamlanmýþtýr...");
                    }
                    catch (Exception ex)
                    {
                        if (tran.IsOpen)
                            tran.Rollback();
                        BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                        //XtraMessageBox.Show("Kayýt Sýrasýnda Bir Hata Oluþtu...");
                    }

                    #endregion Dava Genel Ayarlar Kaydet

                    #region neden

                    //if (leDavaNeden.EditValue != null)
                    //{
                    //    #region Dava Neden Secenek Ayar Kaydet
                    //    try
                    //    {
                    //        tran.BeginTransaction();
                    //        DataRepository.TD_BIL_DAVA_NEDEN_SECENEK_KULLANICI_AYARProvider.Save(tran, davaAlacakNedenAyarlar);
                    //        tran.Commit();
                    //        XtraMessageBox.Show("Dava Alacak Neden Seçenekleri Kayýt Ýþlemi Tamamlanmýþtýr...");

                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        if (tran.IsOpen)
                    //            tran.Rollback();
                    //        BelgeUtil.ErrorHandler.Catch(this, ex, false, BelgeUtil.Bilesen.Kayit);
                    //        //XtraMessageBox.Show("Kayýt Sýrasýnda Bir Hata Oluþtu...");
                    //    }
                    //    #endregion Dava Neden Secenek Ayar Kaydet
                    //}

                    #endregion
                }
                else
                {
                    XtraMessageBox.Show("Kayýt Ýþlemini Onaylamadýðýnýz için Ýþlem Tamamlanamadý ... ");
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex, true, BelgeUtil.Bilesen.Kayit);
            }
        }

        private void lkBankaAd_EditValueChanged(object sender, EventArgs e)
        {
            int bankaID = (int)lkBankaAd.EditValue;

            if (bankaID != null)
            {
                AvukatPro.Services.Implementations.DevExpressService.BankaSubeGetir(lkBankaSubead, bankaID);
                //BelgeUtil.Inits.BankaSubeGetir(lkBankaSubead, bankaID);
            }
        }

        private void lkBirim_EditValueChanged(object sender, EventArgs e)
        {
            int birimID = (int)lkBirim.EditValue;

            if (birimID != null)
            {
                BelgeUtil.Inits.FoyYeriGetirByFoyBirimId(lkDosyaYer, birimID);
                BelgeUtil.Inits.FoyOzelDurumGetirByFoyBirimId(lkFoyOzelDurum, birimID);
                BelgeUtil.Inits.KrediGrupGetirByFoyBirim(lkKredigroup, birimID);
                BelgeUtil.Inits.TahsilatdurumGetirByFoyBirim(lkTahsilatdurum, birimID);
            }
        }

        public enum TarafKodu
        {
            DavaEden = 0,
            DavaEdilen = 1
        }

        private void SifatGetir(TarafKodu t)
        {
            if (t == TarafKodu.DavaEden)
            {
                lkTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDEN");
                lkTarafSifati.Properties.ValueMember = "ID";
                lkTarafSifati.Properties.DisplayMember = "SIFAT";
            }
            else if (t == TarafKodu.DavaEdilen)
            {
                lkKarsiTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDÝLEN");
                lkKarsiTarafSifati.Properties.ValueMember = "ID";
                lkKarsiTarafSifati.Properties.DisplayMember = "SIFAT";
            }
        }

        private void rgTarafKod_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToInt32(e.NewValue) == 1)
                SifatGetir(TarafKodu.DavaEden);
            else
                SifatGetir(TarafKodu.DavaEdilen);
        }

        private void rgKarsiTarafKod_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (Convert.ToInt32(e.NewValue) == 3)
                SifatGetir(TarafKodu.DavaEdilen);
            else
                SifatGetir(TarafKodu.DavaEden);
        }

        private void rgTarafKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgTarafKod.SelectedIndex == 0)
            {
                rgKarsiTarafKod.SelectedIndex = 1;
                lkTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDEN");
                lkTarafSifati.Properties.ValueMember = "ID";
                lkTarafSifati.Properties.DisplayMember = "SIFAT";
                lkKarsiTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDÝLEN");
                lkKarsiTarafSifati.Properties.ValueMember = "ID";
                lkKarsiTarafSifati.Properties.DisplayMember = "SIFAT";
            }
            else if (rgTarafKod.SelectedIndex == 1)
            {
                rgKarsiTarafKod.SelectedIndex = 0;
                lkKarsiTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDEN");
                lkKarsiTarafSifati.Properties.ValueMember = "ID";
                lkKarsiTarafSifati.Properties.DisplayMember = "SIFAT";
                lkTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDÝLEN");
                lkTarafSifati.Properties.ValueMember = "ID";
                lkTarafSifati.Properties.DisplayMember = "SIFAT";
            }
        }

        private void rgKarsiTarafKod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rgKarsiTarafKod.SelectedIndex == 0)
            {
                rgTarafKod.SelectedIndex = 1;
                lkKarsiTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDEN");
                lkKarsiTarafSifati.Properties.ValueMember = "ID";
                lkKarsiTarafSifati.Properties.DisplayMember = "SIFAT";
                lkTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDÝLEN");
                lkTarafSifati.Properties.ValueMember = "ID";
                lkTarafSifati.Properties.DisplayMember = "SIFAT";
            }
            else if (rgKarsiTarafKod.SelectedIndex == 1)
            {
                rgTarafKod.SelectedIndex = 0;
                lkTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDEN");
                lkTarafSifati.Properties.ValueMember = "ID";
                lkTarafSifati.Properties.DisplayMember = "SIFAT";
                lkKarsiTarafSifati.Properties.DataSource = TarafSifat.FindAll(item => item.HANGI_TARAFI == "DAVA EDÝLEN");
                lkKarsiTarafSifati.Properties.ValueMember = "ID";
                lkKarsiTarafSifati.Properties.DisplayMember = "SIFAT";
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            bndDavaGenelAyar.Clear();

            try
            {
                DataRepository.TD_BIL_DAVA_KULLANICI_AYARProvider.Delete(davaGenelAyarim);
            }
            catch
            {
                ;
            }
        }
    }
}