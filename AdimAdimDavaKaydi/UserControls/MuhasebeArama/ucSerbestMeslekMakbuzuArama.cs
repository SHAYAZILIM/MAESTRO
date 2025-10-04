using System;
using System.Collections.Generic;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Implementations;
using AvukatPro.Services.Messaging;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls.MuhasebeArama
{
    public partial class ucSerbestMeslekMakbuzuArama : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public DataTable sonuc;

        private int? Cari;

        private int? FaturaKapsamTip;

        private DateTime? FaturaT;

        private int? IcraID, DavaID, SorusturmaID, SozlesmeID;

        private AvukatProLib.Extras.Modul modul;

        private string RefNo;

        private string seriNo;

        public ucSerbestMeslekMakbuzuArama()
        {
            InitializeComponent();
            this.Load += ucSerbestMeslekMakbuzuArama_Load;
        }

        public event EventHandler<AramaYapildiFatura> AramaFatura;

        public event EventHandler<TemizlendiFatura> TemizleFatura;

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            List<int?> seciliIDler = new List<int?>();
            if (searchLookUpEdit1View.SelectedRowsCount > 0 && !string.IsNullOrEmpty(lueModul.Text))
            {
                for (int rowHandle = 0; rowHandle < searchLookUpEdit1View.RowCount; rowHandle++)
                {
                    if ((bool)searchLookUpEdit1View.GetRowCellValue(rowHandle, "IsSelected") == true)
                        seciliIDler.Add((int)searchLookUpEdit1View.GetRowCellValue(rowHandle, "Id"));
                }
            }

            AvukatProLib.Extras.Modul? modul = null;
            switch (lueModul.Text)
            {
                case "Icra":
                    modul = AvukatProLib.Extras.Modul.Icra;
                    break;

                case "Dava":
                    modul = AvukatProLib.Extras.Modul.Dava;
                    break;

                case "Sorusturma":
                    modul = AvukatProLib.Extras.Modul.Sorusturma;
                    break;

                case "Sozlesme":
                    modul = AvukatProLib.Extras.Modul.Sozlesme;
                    break;
            }

            GetFaturaByFiltreRequest request = new GetFaturaByFiltreRequest();
            request.Modul = modul;
            request.DosyaIds = seciliIDler;
            request.ReferansNo = RefNo;
            request.FaturaKapsamTipi = FaturaKapsamTip;
            request.SeriNo = seriNo;
            request.FaturaTarihi = FaturaT;
            request.CariId = Cari;
            sonuc = AvukatPro.Services.Implementations.DosyaService.GetAllFaturaByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());

            if (AramaFatura != null)
                AramaFatura(this, new AramaYapildiFatura(sonuc));
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle();
            if (TemizleFatura != null)
                TemizleFatura(this, new TemizlendiFatura(null));

            rgZamanDilimi.SelectedIndex = 6;
        }

        private void dtFaturaT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtFaturaT.EditValue != null)
                FaturaT = (DateTime?)dtFaturaT.EditValue;
            else
                FaturaT = null;
        }

        private void FormlariTemizle()
        {
            lueCari.EditValue = null;
            lueFaturaKapsamTip.EditValue = null;
            lueModul.EditValue = null;
            dtFaturaT.EditValue = null;
            txtRefNo.Text = string.Empty;
            txtSeriNo.Text = string.Empty;
        }

        private void InitsDoldur()
        {
            DevExpressService.CariDoldur(lueCari, null);
            lueFaturaKapsamTip.Enter += BelgeUtil.Inits.FaturaKapsamTipGetir_Enter;
            DevExpressService.ModulDoldur(lueModul, null);
        }

        private void lueCari_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCari.EditValue != null)
                Cari = (int?)lueCari.EditValue;
            else
                Cari = null;
        }

        private void lueDosya_EditValueChanged(object sender, EventArgs e)
        {
            if (modul == AvukatProLib.Extras.Modul.Icra)
                IcraID = (int?)lueDosya.EditValue;
            else
                IcraID = null;
            if (modul == AvukatProLib.Extras.Modul.Dava)
                DavaID = (int?)lueDosya.EditValue;
            else
                DavaID = null;
            if (modul == AvukatProLib.Extras.Modul.Sorusturma)
                SorusturmaID = (int?)lueDosya.EditValue;
            else
                SorusturmaID = null;
            if (modul == AvukatProLib.Extras.Modul.Sozlesme)
                SozlesmeID = (int?)lueDosya.EditValue;
            else
                SozlesmeID = null;
        }

        private void lueFaturaKapsamTip_EditValueChanged(object sender, EventArgs e)
        {
            if (lueFaturaKapsamTip.EditValue != null)
                FaturaKapsamTip = (int?)lueFaturaKapsamTip.EditValue;
            else
                FaturaKapsamTip = null;
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            if (lueModul.EditValue != null)
            {
                switch (lueModul.Text)
                {
                    case "Icra":
                        modul = AvukatProLib.Extras.Modul.Icra;
                        DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, true);
                        break;

                    case "Dava":
                        modul = AvukatProLib.Extras.Modul.Dava;
                        DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, true);
                        break;

                    case "Soruşturma":
                        modul = AvukatProLib.Extras.Modul.Sorusturma;
                        DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, true);
                        break;

                    case "Sözleşme":
                        modul = AvukatProLib.Extras.Modul.Sozlesme;
                        DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, true);
                        break;
                }
            }
        }

        private void txtRefNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRefNo.Text))
                RefNo = txtRefNo.Text;
            else
                RefNo = null;
        }

        private void txtSeriNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSeriNo.Text))
                seriNo = txtSeriNo.Text;
            else
                seriNo = null;
        }

        private void ucSerbestMeslekMakbuzuArama_Load(object sender, EventArgs e)
        {
            InitsDoldur();

            lueDosya.Properties.NullText = "Önce Modül Seçiniz.";
        }

        public class AramaYapildiFatura : EventArgs
        {
            public AramaYapildiFatura(DataTable mFoy)
            {
                Sonuc = mFoy;
            }

            public DataTable Sonuc { get; set; }
        }

        public class TemizlendiFatura : EventArgs
        {
            public TemizlendiFatura(DataTable mFoy)
            {
                SonucT = mFoy;
            }

            public DataTable SonucT { get; set; }
        }
    }
}