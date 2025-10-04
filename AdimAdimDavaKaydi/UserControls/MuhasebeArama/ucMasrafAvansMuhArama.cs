using System;
using System.Collections.Generic;
using AvukatPro.Model.EntityClasses;
using AvukatPro.Services.Messaging;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace AdimAdimDavaKaydi.UserControls.MuhasebeArama
{
    public partial class ucMasrafAvansMuhArama : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public DataTable masraf;
        public DataTable muhasebe;
        private string _tip;

        private int? AltKategori;

        private string BelgeNo;

        private int? BorcAlacak;

        private int? Cari;

        private int? MasrafAvansTip;

        private DateTime? MasrafT;

        private AvukatProLib.Extras.Modul? modul;

        private int? MuhAnaKat;

        private int? Muvekkil;

        private string ReferansNo;

        public ucMasrafAvansMuhArama(string tip)
        {
            _tip = tip;
            InitializeComponent();
        }

        public event EventHandler<AramaYapildi> Arama;

        public event EventHandler<AramaYapildiMuhasebe> AramaMuhasebe;

        public event EventHandler<Temizlendi> Temizle;

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

            if (_tip == "muhasebe")
            {
                GetMuhasebeBirlesikByFiltreRequest request = new GetMuhasebeBirlesikByFiltreRequest();
                request.AltKategori = AltKategori;
                request.AnaKategori = MuhAnaKat;
                request.BorcAlacak = BorcAlacak;
                request.DosyaIds = seciliIDler;
                request.MasrafAvansTip = MasrafAvansTip;
                request.MasrafTarihi = MasrafT;
                request.Modul = modul;
                request.MuvekkilID = Muvekkil;
                request.ReferansNo = ReferansNo;

                muhasebe = AvukatPro.Services.Implementations.MuhasebeService.GetMuhasebeBirlesikDetayliByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());
                if (AramaMuhasebe != null)
                    AramaMuhasebe(this, new AramaYapildiMuhasebe(muhasebe));
            }

            else if (_tip == "masraf")
            {
                //foreach (Control item in (((AdimAdimDavaKaydi.GirisEkran.rFrmMuhasebeGirisEkran)((DevExpress.XtraLayout.LayoutControl)this.GetContainerControl().ActiveControl).ParentForm)).Controls) { }

                GetMasrafAvansByFiltreRequest request = new GetMasrafAvansByFiltreRequest();
                request.AltKategori = AltKategori;
                request.AnaKategori = MuhAnaKat;
                request.BelgeNo = BelgeNo;
                request.BorcAlacak = BorcAlacak;
                request.CariID = Cari;
                request.MasrafAvansTip = MasrafAvansTip;
                request.MasrafTarihi = MasrafT;
                request.Modul = modul;
                request.Muvekkil = Muvekkil;
                request.ReferansNo = ReferansNo;
                request.DosyaIds = seciliIDler;

                masraf = AvukatPro.Services.Implementations.MasrafAvansService.GetAllMasrafByFiltre(request, rgZamanDilimi.Properties.Items[rgZamanDilimi.SelectedIndex].Value.ToString());

                if (Arama != null)
                    Arama(this, new AramaYapildi(masraf));
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            FormlariTemizle();
            if (Temizle != null)
                Temizle(this, new Temizlendi(null));
            rgZamanDilimi.SelectedIndex = 6;
        }

        //private void lueDosyaGetir_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (modul == AvukatProLib.Extras.Modul.Icra)
        //        IcraID = (int?)lueDosyaGetir.EditValue;
        //    else
        //        IcraID = null;
        //    if (modul == AvukatProLib.Extras.Modul.Dava)
        //        DavaID = (int?)lueDosyaGetir.EditValue;
        //    else
        //        DavaID = null;
        //    if (modul == AvukatProLib.Extras.Modul.Sorusturma)
        //        SorusturmaID = (int?)lueDosyaGetir.EditValue;
        //    else
        //        SorusturmaID = null;
        //    if (modul == AvukatProLib.Extras.Modul.Sozlesme)
        //        SozlesmeID = (int?)lueDosyaGetir.EditValue;
        //    else
        //        SozlesmeID = null;
        //}
        private void dtMasrafT_EditValueChanged(object sender, EventArgs e)
        {
            if (dtMasrafT.EditValue != null)
                MasrafT = (DateTime?)dtMasrafT.EditValue;
            else
                MasrafT = null;
        }

        private void FormlariTemizle()
        {
            try
            {
                lueCari.EditValue = null;
                lueMuvekkil.EditValue = null;
                lueBorcAlacak.EditValue = null;
                lueModul.EditValue = null;
                lueMasrafAvansTip.EditValue = null;
                lueMuhAnaKat.EditValue = null;
                lueDosya.EditValue = null;
                lueAltKategori.EditValue = null;
                txtBelgeNo.Text = string.Empty;
                txtReferansNo.Text = string.Empty;
                dtMasrafT.EditValue = null;
            }
            catch 
            {
            }
        }

        private void InitsDoldur()
        {
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueCari, AvukatProLib.Extras.CariStatu.Personel);
            AvukatPro.Services.Implementations.DevExpressService.CariDoldur(lueMuvekkil, AvukatProLib.Extras.CariStatu.Müvekkil);
            lueBorcAlacak.Enter += BelgeUtil.Inits.BorcAlacakGetir_Enter;
            AvukatPro.Services.Implementations.DevExpressService.ModulDoldur(lueModul, null);
            lueMasrafAvansTip.Enter += delegate { BelgeUtil.Inits.MasrafAvansTipGetir(lueMasrafAvansTip.Properties); };
            AvukatPro.Services.Implementations.DevExpressService.AnaKategoriDoldur(lueMuhAnaKat);
        }

        private void lueAltKategori_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAltKategori.EditValue != null)
                AltKategori = (int?)lueAltKategori.EditValue;
            else
                AltKategori = null;
        }

        private void lueBorcAlacak_EditValueChanged(object sender, EventArgs e)
        {
            if (lueBorcAlacak.EditValue != null)
                BorcAlacak = (int?)lueBorcAlacak.EditValue;
            else
                BorcAlacak = null;
        }

        private void LueCari_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCari.EditValue != null)
                Cari = (int?)lueCari.EditValue;
            else
                Cari = null;
        }

        private void lueMasrafAvansTip_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMasrafAvansTip.EditValue != null)
                MasrafAvansTip = Convert.ToInt32(lueMasrafAvansTip.EditValue);
            else
                MasrafAvansTip = null;
        }

        private void lueModul_EditValueChanged(object sender, EventArgs e)
        {
            //lueDosya.Properties.DataSource = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);

            //var obj = BelgeUtil.Inits.DosyaDoldur(lueModul.Text);
            //string FoyNo = "FOY_NO";
            //if (obj is VList<VTD_SORUSTURMA_DOSYALAR>)
            //    FoyNo = "HAZIRLIK_NO";
            //if (obj is VList<VTD_SOZLESME_DOSYALAR>)
            //    FoyNo = "SOZLESME_NO";
            //lueDosya.Properties.DisplayMember = FoyNo;
            //lueDosya.Properties.ValueMember = "ID";

            if (lueModul.EditValue != null)
            {
                switch (lueModul.Text)
                {
                    case "Icra":
                        modul = AvukatProLib.Extras.Modul.Icra;
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Icra, true);
                        break;

                    case "Dava":
                        modul = AvukatProLib.Extras.Modul.Dava;
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Dava, true);
                        break;

                    case "Sorusturma":
                        modul = AvukatProLib.Extras.Modul.Sorusturma;
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sorusturma, true);
                        break;

                    case "Sozlesme":
                        modul = AvukatProLib.Extras.Modul.Sozlesme;
                        AvukatPro.Services.Implementations.DevExpressService.DosyaDoldur(lueDosya, AvukatProLib.Extras.Modul.Sozlesme, true);
                        break;
                }
            }
        }

        private void lueMuhAnaKat_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMuhAnaKat.EditValue != null)
            {
                BelgeUtil.Inits.MuhasebeHareketAltKategoriByAnakategoriIdAlti(lueAltKategori.Properties,
                                                                              (int)lueMuhAnaKat.EditValue);
                MuhAnaKat = (int?)lueMuhAnaKat.EditValue;
            }
            else
                MuhAnaKat = null;
        }

        private void lueMuvekkil_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMuvekkil.EditValue != null)
                Muvekkil = (int?)lueMuvekkil.EditValue;
            else
                Muvekkil = null;
        }

        //private int? IcraID, DavaID, SorusturmaID, SozlesmeID;
        private void txtBelgeNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBelgeNo.Text))
                BelgeNo = txtBelgeNo.Text;
            else
                BelgeNo = null;
        }

        private void txtReferansNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReferansNo.Text))
                ReferansNo = txtReferansNo.Text;
            else
                ReferansNo = null;
        }

        private void ucMasrafAvansMuhArama_Load(object sender, EventArgs e)
        {
            lueDosya.Properties.NullText = "Önce Modül Seçiniz.";
            lueAltKategori.Properties.NullText = "Öce Ana Kategori Seçiniz.";
            InitsDoldur();
            if (_tip == "muhasebe")
            {
                lciSorumlu.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciBelgeNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
    }

    public class AramaYapildi : EventArgs
    {
        //public AramaYapildi(List<RMasrafAvansDetayli2Entity> mFoy)
        //{
        //    Sonuc = mFoy;
        //}

        //public List<RMasrafAvansDetayli2Entity> Sonuc { get; set; }
        //aykut hızlandırma 25.01.2013
        public AramaYapildi(DataTable mFoy)
        {
            Sonuc = mFoy;
        }

        public DataTable Sonuc { get; set; }
    }

    public class AramaYapildiMuhasebe : EventArgs
    {
        public AramaYapildiMuhasebe(DataTable mFoyMuhasebe)
        {
            SonucMuhasebe = mFoyMuhasebe;
        }

        public DataTable SonucMuhasebe { get; set; }
    }

    public class Temizlendi : EventArgs
    {
        public Temizlendi(DataTable mFoy)
        {
            SonucT = mFoy;
        }

        public DataTable SonucT { get; set; }
    }
}