using System;
using System.Collections.Generic;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Messaging;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls.MuhasebeArama
{

    public partial class ucCariHesapArama : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public bool personel, muvekkil;
        //aykut hızlandırma 25.01.2013
        //public List<RCariHesapDetayliEntity> sonuc;

        public DataTable sonuc;
        private readonly string _type;
        private int? BorcAlacak;
        private int? Burol;
        private int? Cari;
        private int? HareketAltKate;
        private int? HareketAnaKate;
        private string KullanBelgeNo;

        private int? OdemeTip;

        private DateTime? OnayTrh;

        private string RefNo;

        private DateTime? Trh;

        public ucCariHesapArama(string Type)
        {
            InitializeComponent();
            _type = Type;
            if (Type == "müvekkil")
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        public event EventHandler<AramaYapildiCariHesap> AramaCariHesapMuvekkil;

        public event EventHandler<AramaYapildiCariHesap> AramaCariHesapPersonel;

        public event EventHandler<TemizlendiCariHesap> TemizleCariHesap;

        private void btnSorgula_Click(object sender, EventArgs e)
        {

            int? onayDurum = null;

            if (rgOnayDurum.SelectedIndex == 0)
            {
                onayDurum = 5; // 1 , 2 ve 3 için
            }

            else if (rgOnayDurum.SelectedIndex == 1)
            {
                onayDurum = 4;
            }

            else if (rgOnayDurum.SelectedIndex == 2)
            {
                onayDurum = 0;
            }

            else if (rgOnayDurum.SelectedIndex == 3)
            {
                onayDurum = null;
            }

            GetCariHesapDetayRequest request = new GetCariHesapDetayRequest();
            request.Cari = Cari;
            request.BorcAlacak = BorcAlacak;
            request.AnaKategori = HareketAnaKate;
            request.AltKategori = HareketAltKate;
            request.Buro = Burol;
            request.OdemeTip = OdemeTip;
            request.OnayTarihi = OnayTrh;
            request.Tarih = Trh;
            request.KullaniciBelgeNo = KullanBelgeNo;
            request.ReferansNo = RefNo;

            if (_type == "müvekkil")
            {
                sonuc = AvukatPro.Services.Implementations.CariService.GetMuvekkilCariHesapDetayByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
            }
            else
            {
                request.OnayDurum = onayDurum;
                sonuc = AvukatPro.Services.Implementations.CariService.GetPersonelCariHesapDetayByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
            }

            if (AramaCariHesapMuvekkil != null)
                AramaCariHesapMuvekkil(this, new AramaYapildiCariHesap(sonuc));
            if (AramaCariHesapPersonel != null)
                AramaCariHesapPersonel(this, new AramaYapildiCariHesap(sonuc));
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle();
            if (TemizleCariHesap != null)
                TemizleCariHesap(this, new TemizlendiCariHesap(null));
            rgZamanDilimi.SelectedIndex = 6;
        }

        private void dtOnayT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtOnayT.EditValue != null)
                OnayTrh = (DateTime?)dtOnayT.EditValue;
            else
                OnayTrh = null;
        }

        private void dtTarih_EditValueChanged(object sender, EventArgs e)
        {
            if (dtTarih.EditValue != null)
                Trh = (DateTime?)dtTarih.EditValue;
            else
                Trh = null;
        }

        private void FormlariTemizle()
        {
            try
            {
                lueCari.EditValue = null;
                lueHareketAnaKat.EditValue = null;
                lueBorcAlacak.EditValue = null;
                lueHareketAltKat.EditValue = null;
                lueBuro.EditValue = null;
                lueOdemeTipi.EditValue = null;
                dtTarih.EditValue = null;
                dtOnayT.EditValue = null;
                txtKullaniciBelgeNo.Text = string.Empty;
                txtRefNo.Text = string.Empty;
            }
            catch 
            {
            }
        }

        private void InitsDoldur()
        {
            lueBorcAlacak.Properties.NullText = "Seç";
            lueBuro.Properties.NullText = "Seç";
            lueCari.Properties.NullText = "Seç";
            lueHareketAnaKat.Properties.NullText = "Seç";
            lueOdemeTipi.Properties.NullText = "Seç";
            lueBorcAlacak.Enter += BelgeUtil.Inits.BorcAlacakGetir_Enter;
            lueBuro.Enter += BelgeUtil.Inits.KullaniciSubeleriGetir_Enter;
            if (personel)
                DevExpressService.CariDoldur(lueCari, AvukatProLib.Extras.CariStatu.Personel);
            if (muvekkil)
                DevExpressService.CariDoldur(lueCari, AvukatProLib.Extras.CariStatu.Müvekkil);
            DevExpressService.AnaKategoriDoldur(lueHareketAnaKat);
            lueOdemeTipi.Enter += BelgeUtil.Inits.OdemeTipiGetir_Enter;
        }

        private void lueBorcAlacak_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBorcAlacak.EditValue != null)
                BorcAlacak = (int?)lueBorcAlacak.EditValue;
            else
                BorcAlacak = null;
        }

        private void lueBuro_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBuro.EditValue != null)
                Burol = (int?)lueBuro.EditValue;
            else
                Burol = null;
        }

        private void lueCari_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCari.EditValue != null)
                Cari = (int?)lueCari.EditValue;
            else
                Cari = null;
        }

        private void lueHareketAltKat_EditValueChanged(object sender, EventArgs e)
        {
            if (lueHareketAltKat.EditValue != null)
                HareketAltKate = (int?)lueHareketAltKat.EditValue;
            else
                HareketAltKate = null;
        }

        private void lueHareketAnaKat_EditValueChanged(object sender, EventArgs e)
        {
            if (lueHareketAnaKat.EditValue != null)
            {
                BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueHareketAltKat.Properties,
                                                                              (int)lueHareketAnaKat.EditValue);
                HareketAnaKate = (int?)lueHareketAnaKat.EditValue;
            }
            else
                HareketAnaKate = null;
        }

        private void lueOdemeTipi_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOdemeTipi.EditValue != null)
                OdemeTip = (int?)lueOdemeTipi.EditValue;
            else
                OdemeTip = null;
        }

        private void txtKullaniciBelgeNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKullaniciBelgeNo.Text))
                KullanBelgeNo = txtKullaniciBelgeNo.Text;
            else
                KullanBelgeNo = null;
        }

        private void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRefNo.Text))
                RefNo = txtRefNo.Text;
            else
                RefNo = null;
        }

        private void ucCariHesapArama_Load(object sender, EventArgs e)
        {
            InitsDoldur();
            if (personel)
                lctrlCariAd.Text = "Personel";
            if (muvekkil)
                lctrlCariAd.Text = "Müvekkil";

            lueHareketAltKat.Properties.NullText = "Önce Ana Kategori Seçiniz.";
        }
    }


    public class AramaYapildiCariHesap : EventArgs
    {
        //aykut hızlandırma 25.01.2013
        //public AramaYapildiCariHesap(List<RCariHesapDetayliEntity> mFoy)
        //{
        //    Sonuc = mFoy;
        //}

        //public List<RCariHesapDetayliEntity> Sonuc { get; set; }
        public AramaYapildiCariHesap(DataTable mFoy)
        {
            Sonuc = mFoy;
        }

        public DataTable Sonuc { get; set; }
    }

    public class TemizlendiCariHesap : EventArgs
    {
        //aykut hızlandırma 25.01.2013
        //public TemizlendiCariHesap(List<RCariHesapDetayliEntity> mFoy)
        //{
        //    SonucT = mFoy;
        //}

        //public List<RCariHesapDetayliEntity> SonucT { get; set; }
        public TemizlendiCariHesap(DataTable mFoy)
        {
            SonucT = mFoy;
        }

        public DataTable SonucT { get; set; }
    }
}