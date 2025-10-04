using System;
using System.Collections.Generic;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Messaging;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls.MuhasebeArama
{
    public partial class ucKasaMuhArama : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public DataTable sonuc;

        private int? AnaKat;

        private string BelgeNo;

        private int? BorcAlacak;

        private int? cari;

        private DateTime? kasaT;

        private int? OdemeTip;

        private string RefNo;

        public ucKasaMuhArama()
        {
            InitializeComponent();
            this.Load += ucKasaMuhArama_Load;
        }

        public event EventHandler<AramaYapildiKasa> AramaKasa;

        public event EventHandler<TemizlendiKasa> TemizleKasa;

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            GetKasaByFiltreRequest request = new GetKasaByFiltreRequest();
            request.HareketCariId = cari;
            request.BorcAlacakId = BorcAlacak;
            request.AnaKategori = AnaKat;
            request.ReferansNo = RefNo;
            request.BelgeNo = BelgeNo;
            request.Tarih = kasaT;
            request.OdemeTipId = OdemeTip;

            sonuc = AvukatPro.Services.Implementations.DosyaService.GetAllKasaByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());

            if (AramaKasa != null)
                AramaKasa(this, new AramaYapildiKasa(sonuc));
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            ControlTemizle();
            if (TemizleKasa != null)
                TemizleKasa(this, new TemizlendiKasa(null));
        }

        private void ControlTemizle()
        {
            lueCari.EditValue = null;
            lueBorcAlacak.EditValue = null;
            lueAnaKategori.EditValue = null;
            lueOdemeTip.EditValue = null;
            txtBelgeNo.Text = string.Empty;
            txtRefNo.Text = string.Empty;
        }

        private void dtKasaT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtKasaT.EditValue != null)
                kasaT = (DateTime?)dtKasaT.EditValue;
            else
                kasaT = null;
        }

        private void InitsDoldur()
        {
            DevExpressService.CariDoldur(lueCari, null);
            DevExpressService.AnaKategoriDoldur(lueAnaKategori);
            lueBorcAlacak.Enter += BelgeUtil.Inits.BorcAlacakGetir_Enter;
            lueOdemeTip.Enter += BelgeUtil.Inits.OdemeTipiGetir_Enter;
        }

        private void lueAnaKategori_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAnaKategori.EditValue != null)
                AnaKat = (int?)lueAnaKategori.EditValue;
            else
                AnaKat = null;
        }

        private void lueBorcAlacak_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBorcAlacak.EditValue != null)
                BorcAlacak = (int?)lueBorcAlacak.EditValue;
            else
                BorcAlacak = null;
        }

        private void lueCari_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCari.EditValue != null)
                cari = (int?)lueCari.EditValue;
            else
                cari = null;
        }

        private void lueOdemeTip_EditValueChanged(object sender, EventArgs e)
        {
            if (lueOdemeTip.EditValue != null)
                OdemeTip = (int?)lueOdemeTip.EditValue;
            else
                OdemeTip = null;
        }

        private void txtBelgeNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBelgeNo.Text))
                BelgeNo = txtBelgeNo.Text;
            else
                BelgeNo = null;
        }

        private void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRefNo.Text))
                RefNo = txtRefNo.Text;
            else
                RefNo = null;
        }

        private void ucKasaMuhArama_Load(object sender, EventArgs e)
        {
            InitsDoldur();
        }
    }

    public class AramaYapildiKasa : EventArgs
    {
        //aykut hızlandırma 28.01.2013
        //public AramaYapildiKasa(List<Av001TdiBilKasaEntity> mFoy)
        //{
        //    Sonuc = mFoy;
        //}

        //public List<Av001TdiBilKasaEntity> Sonuc { get; set; }

        public AramaYapildiKasa(DataTable mFoy)
        {
            Sonuc = mFoy;
        }

        public DataTable Sonuc { get; set; }
    }

    public class TemizlendiKasa : EventArgs
    {
        //aykut hızlandırma 28.01.2013
        //public TemizlendiKasa(List<Av001TdiBilKasaEntity> mFoy)
        //{
        //    SonucT = mFoy;
        //}

        //public List<Av001TdiBilKasaEntity> SonucT { get; set; }
        public TemizlendiKasa(DataTable mFoy)
        {
            SonucT = mFoy;
        }

        public DataTable SonucT { get; set; }
    }

}