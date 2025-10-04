using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Interfaces;
using AvukatProLib2.Data;
using DevExpress.XtraEditors;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucBelgeAramaGirisEkran : AvpXUserControl
    {
        #region Global Properties


        #endregion

        #region Global Fields

        public event EventHandler<EventArgs> Sorgula;
        public event EventHandler<EventArgs> Temizle;

        private AvukatProLib.Extras.Modul? _Modul;
        private int? _DosyaID;
        private string _BelgeAdi;
        private int? _TurID;
        private string _BelgeNo;
        private string _RefNo;
        private string _BarkodNo;
        private int? _DurumID;

        public bool HepsiniDoldur;

        #endregion

        public ucBelgeAramaGirisEkran()
        {
            this.Load += ucBelgeAramaGirisEkran_Load;
        }
        
        public DataTable AramaYap()
        {
            AvukatPro.Services.Messaging.GetBelgeByFiltreRequest request = new AvukatPro.Services.Messaging.GetBelgeByFiltreRequest()
            {
                BarkodNo = _BarkodNo,
                BelgeAdi = _BelgeAdi,
                BelgeNo = _BelgeNo,
                DosyaID = _DosyaID,
                DurumID = _DurumID,
                Modul = _Modul,
                RefNo = _RefNo,
                TurID = _TurID
            };

            if (DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetByID(AvukatProLib.Kimlik.SubeKodu).SUBE_ADI != "MERKEZ")
                request.KullaniciSubeID = AvukatProLib.Kimlik.SubeKodu;
            else
                request.KullaniciSubeID = null;

            return AvukatPro.Services.Implementations.DosyaService.GetAllBelgeByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
        }

        private void ucBelgeAramaGirisEkran_Load(object sender, EventArgs e)
        {
            InitializeComponent();

            //LOAD
            if (DesignMode)
                return;

            #region Bind LookUps

            lueBelgeTuru.Properties.NullText = "Seç";
            lueBelgeTuru.Enter += delegate { BelgeUtil.Inits.BelgeTurGetir(lueBelgeTuru); };
            AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(lueModul, null);
            BelgeUtil.Inits.FoyDurumGetir(lueDurum);

            lueDurum.EditValue = 2;

            #endregion
        }

        private void sBtnTemizle_Click(object sender, EventArgs e)
        {
            //FormlariTemizle(this.contr);
            if (Temizle != null)
                Temizle(this, new EventArgs());
            rgZamanDilimi.SelectedIndex = 6;
            lueDurum.EditValue = null;
        }

        private void sBtnSorgula_Click(object sender, EventArgs e)
        {
            if (Sorgula != null)
                Sorgula(this, new EventArgs());
        }

        private void txtBelgeAdi_TextChanged(object sender, EventArgs e)
        {
            _BelgeAdi = txtBelgeAdi.Text;
            if (txtBelgeAdi.Text == string.Empty)
                _BelgeAdi = null;
        }

        private void lueBelgeTuru_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBelgeTuru.EditValue != null)
                _TurID = (int?)lueBelgeTuru.EditValue;
            else
                _TurID = null;
        }

        private void txtBelgeNo_TextChanged(object sender, EventArgs e)
        {
            _BelgeNo = txtBelgeNo.Text;
            if (txtBelgeNo.Text == string.Empty)
                _BelgeNo = null;
        }

        private void txtBelgeReferansNo_TextChanged(object sender, EventArgs e)
        {
            _RefNo = txtReferansNo.Text;
            if (txtReferansNo.Text == string.Empty)
                _RefNo = null;
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lueModul.EditValue.ToString()))
            {
                _Modul = null;
                return;
            }

            lueDosya.Enabled = true;
            int modul = Convert.ToInt32(lueModul.EditValue);

            if (lueModul.Text == "Icra")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, false);

            else if (lueModul.Text == "Dava")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, false);

            else if (lueModul.Text == "Soruşturma")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, false);

            else if (lueModul.Text == "Sözleşme")
                AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, false);
        }

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lueModul.EditValue.ToString()))
            {
                _DosyaID = null;
                return;
            }
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            _BarkodNo = txtBarkodNo.Text;
            if (txtBarkodNo.Text == string.Empty)
                _BarkodNo = null;
        }

        private void lueDurum_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDurum.EditValue != null)
                _DurumID = (int?)lueDurum.EditValue;
            else
                _DurumID = null;
        }
    }
}