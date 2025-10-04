using AvukatProLib;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AvukatPro.Services.Implementations
{
    public static class DevExpressService //: BaseService, AvukatPro.Services.Interfaces.IDevExpressService
    {
        private static int aaa = 0;

        public static void AdliyeDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            AdliyeDoldur_Bind(rlue);
        }

        public static void AdliyeDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            AdliyeDoldur_Bind(lue);
        }

        public static void AdliyeGorevDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            AdliyeGorevDoldur_Bind(rlue);
        }

        public static void AdliyeGorevDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            AdliyeGorevDoldur_Bind(lue);
        }

        public static void AdliyeNoDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            AdliyeNoDoldur_Bind(rlue);
        }

        public static void AdliyeNoDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            AdliyeNoDoldur_Bind(lue);
        }

        public static void AlacakNedenDoldur(DevExpress.XtraEditors.SearchLookUpEdit slue, AvukatProLib.Extras.FormTipleri? formTipi, AvukatProLib.Extras.FormKonusu? formKonusu, bool? depoAlacagi)
        {
            AlacakNedenDoldur_Bind(slue, formTipi, formKonusu, depoAlacagi);
        }

        public static void AlacakNedenDoldur(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue, AvukatProLib.Extras.FormTipleri? formTipi, AvukatProLib.Extras.FormKonusu? formKonusu, bool? depoAlacagi)
        {
            AlacakNedenDoldur_Bind(rslue, formTipi, formKonusu, depoAlacagi);
        }

        public static void AltKategoriDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            AltKategoriDoldur_Bind(rlue, null, false);
        }

        public static void AltKategoriDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            AltKategoriDoldur_Bind(lue, null, false);
        }

        public static void AltKategoriDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue, int anaKategoriId)
        {
            AltKategoriDoldur_Bind(rlue, anaKategoriId, false);
        }

        public static void AltKategoriDoldur(DevExpress.XtraEditors.LookUpEdit lue, int anaKategoriId)
        {
            AltKategoriDoldur_Bind(lue, anaKategoriId, false);
        }

        public static void AltKategoriDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue, bool gorusmemi)
        {
            AltKategoriDoldur_Bind(rlue, null, true);
        }

        public static void AltKategoriDoldur(DevExpress.XtraEditors.LookUpEdit lue, bool gorusmemi)
        {
            AltKategoriDoldur_Bind(lue, null, true);
        }

        public static void AnaKategoriDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            AnaKategoriDoldur_Bind(rlue);
        }

        public static void AnaKategoriDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            AnaKategoriDoldur_Bind(lue);
        }

        public static void AracTipiDoldur(DevExpress.XtraEditors.ImageComboBoxEdit lue)
        {
            AracTipiDoldur_Bind(lue);
        }

        public static void AracTipiDoldur(DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox rlue)
        {
            AracTipiDoldur_Bind(rlue);
        }

        public static void AvukatDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue, bool IsActive)
        {
            AvukatDoldur_Bind(rlue, IsActive);
        }

        public static void AvukatDoldur(DevExpress.XtraEditors.LookUpEdit lue, bool IsActive)
        {
            AvukatDoldur_Bind(lue, IsActive);
        }

        public static void BankaSubeGetir(DevExpress.XtraEditors.SearchLookUpEdit slue, int? bankaID)
        {
            BankaSubeGetir_Bind(slue, bankaID);
        }

        public static void BankaSubeGetir(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue, int? bankaID)
        {
            BankaSubeGetir_Bind(rslue, bankaID);
        }

        public static void BelgeDoldur(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue)
        {
            BelgeDoldur_Bind(rslue);
        }

        public static void BelgeDoldur(DevExpress.XtraEditors.SearchLookUpEdit slue)
        {
            BelgeDoldur_Bind(slue);
        }

        public static void BelgeTuruDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            BelgeTuruDoldur_Bind(rlue);
        }

        public static void BelgeTuruDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            BelgeTuruDoldur_Bind(lue);
        }

        public static void BorcAlacakGetir(RepositoryItemLookUpEdit lue)
        {
            BorcAlacakGetir_(lue);
        }

        public static void BorcAlacakGetir(LookUpEdit lue)
        {
            BorcAlacakGetir_(lue.Properties);
        }

        public static void BorcAlacakGetir_(object sender)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                //if (_BorcAlacakGetir == null)
                //{
                //    _BorcAlacakGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MUHASEBE_BORC_ALACAKProvider.GetAll();
                //}

                //lue.DataSource = _BorcAlacakGetir;

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

                lue.DataSource = cn.GetDataTable("SELECT ID, BORC_ALACAK FROM dbo.per_TDI_KOD_MUHASEBE_BORC_ALACAK(nolock) ORDER BY BORC_ALACAK");
                lue.NullText = "Seç";
                lue.DisplayMember = "BORC_ALACAK";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("BORC_ALACAK", "Açıklama", 100));
            }
        }

        public static void CariDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue, AvukatProLib.Extras.CariStatu? tipi)
        {
            CariDoldur_Bind(rlue, false, tipi);
        }

        public static void CariDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            CariDoldur_Bind(rlue, false, null);
        }

        public static void CariDoldur(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rlue, AvukatProLib.Extras.CariStatu? tipi)
        {
            CariDoldur_Bind3(rlue, tipi);
        }

        public static void CariDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            CariDoldur_Bind(lue, false, null);
        }

        public static void CariDoldur(GridControl grid, AvukatProLib.Extras.CariStatu? tipi)
        {
            CariDoldur_Bind2(grid, tipi);
        }

        public static void CariDoldur(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue, AvukatProLib.Extras.CariStatu? tipi)
        {
            CariDoldur_Bind(rslue, true, tipi);
        }

        public static void CariDoldur(DevExpress.XtraEditors.SearchLookUpEdit slue, AvukatProLib.Extras.CariStatu? tipi)
        {
            CariDoldur_Bind(slue, true, tipi);
        }

        public static void CariDoldur(DevExpress.XtraEditors.LookUpEdit lue, string cnString)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = cnString;

            lue.Properties.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad FROM dbo.per_AV001_TDI_BIL_CARI(nolock) c ORDER BY c.AD");

            lue.Properties.DisplayMember = "Ad";
            lue.Properties.ValueMember = "Id";
            lue.Properties.NullText = SetNullText(lue);
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", 10, "Kod"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", 30, "Ad") });
        }

        public static void CariDoldur(DevExpress.XtraEditors.LookUpEdit lue, AvukatProLib.Extras.CariStatu? tipi)
        {
            CariDoldur_Bind(lue, false, tipi);
        }

        public static void CariPersonelKodGetir(LookUpEdit lue)
        {
            CariPersonelKodGetir_(lue.Properties);
        }

        public static void CariPersonelKodGetir(RepositoryItemLookUpEdit lue)
        {
            CariPersonelKodGetir_(lue);
        }

        /// <summary>
        /// Dava nedenlerini SearchLookUpEdit'e doldurur.
        /// </summary>
        /// <param name="rslue">Doldurulacak SearchLookUpEdit</param>
        /// <param name="bolumId">Eğer bir bölüme göre getirilecek ise o bölümün ıd parametresi,tümü getirilecekse null veriniz.</param>
        public static void DavaNedeniDoldur(DevExpress.XtraEditors.SearchLookUpEdit slue, int? bolumId, bool IsSikayetNeden)
        {
            DavaNedeniDoldur_Bind(slue, bolumId, IsSikayetNeden);
        }

        /// <summary>
        /// Dava nedenlerini RepositoryItemSearchLookUpEdit'e doldurur.
        /// </summary>
        /// <param name="rslue">Doldurulacak RepositoryItemSearchLookUpEdit</param>
        /// <param name="bolumId">Eğer bir bölüme göre getirilecek ise o bölümün ıd parametresi,tümü getirilecekse null veriniz.</param>
        public static void DavaNedeniDoldur(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue, int? bolumId, bool IsSikayetNeden)
        {
            DavaNedeniDoldur_Bind(rslue, bolumId, IsSikayetNeden);
        }

        public static void DosyaDoldur(DevExpress.XtraEditors.SearchLookUpEdit slue, AvukatProLib.Extras.Modul modul, bool canMultiSelect)
        {
            DosyaDoldur_Bind(slue, modul, canMultiSelect);
        }

        public static void DosyaDoldur(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue, AvukatProLib.Extras.Modul modul, bool canMultiSelect)
        {
            DosyaDoldur_Bind(rslue, modul, canMultiSelect);
        }

        public static void DosyaTaraflariniDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue, Messaging.GetDosyaTaraflariRequest request)
        {
            DosyaTaraflariniDoldur_Bind(rlue, request);
        }

        public static void DosyaTaraflariniDoldur(DevExpress.XtraEditors.LookUpEdit lue, Messaging.GetDosyaTaraflariRequest request)
        {
            DosyaTaraflariniDoldur_Bind(lue, request);
        }

        public static void DovizDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            DovizTipiDoldur_Bind(rlue);
        }

        public static void DovizDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            DovizTipiDoldur_Bind(lue);
        }

        public static void EvrakDoldur(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue)
        {
            EvrakDoldur_Bind(rslue);
        }

        public static void EvrakDoldur(DevExpress.XtraEditors.SearchLookUpEdit slue)
        {
            EvrakDoldur_Bind(slue);
        }

        public static void EvrakSonucDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            EvrakSonucDoldur_Bind(rlue);
        }

        public static void EvrakSonucDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            EvrakSonucDoldur_Bind(lue);
        }

        public static void FormTipiDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            FormTipiDoldur_Bind(rlue);
        }

        public static void FormTipiDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            FormTipiDoldur_Bind(lue);
        }

        public static void FoyDurumDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            FoyDurumDoldur_Bind(rlue);
        }

        public static void FoyDurumDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            FoyDurumDoldur_Bind(lue);
        }

        public static void FoyIadeNedenDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            FoyIadeNedenDoldur_Bind(rlue);
        }

        public static void FoyIadeNedenDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            FoyIadeNedenDoldur_Bind(lue);
        }

        public static void IlceDoldur(object sender, int IL_ID)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdiKodAdliBirimAdliye.ToList();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID, ILCE FROM dbo.TDI_KOD_ILCE WHERE IL_ID=" + IL_ID + " ORDER BY ILCE");

            lue.DisplayMember = "ILCE";
            lue.ValueMember = "ID";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ILCE", 20, "İlçe") });
        }

        public static void IlDoldur(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdiKodAdliBirimAdliye.ToList();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID, IL FROM dbo.TDI_KOD_IL ORDER BY IL");

            lue.DisplayMember = "IL";
            lue.ValueMember = "ID";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IL", 20, "İl") });
        }

        public static void TebligatDurumDoldur(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdiKodAdliBirimAdliye.ToList();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID, DURUM FROM dbo.TDI_KOD_TEBLIGAT_DURUM");

            lue.DisplayMember = "DURUM";
            lue.ValueMember = "ID";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DURUM", 20, "Durum") });
        }

        public static void KasaHesapBilgileriDoldur(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue)
        {
            HesapBilgileri_Bind(rslue, true);
        }

        public static void KasaHesapBilgileriDoldur(DevExpress.XtraEditors.SearchLookUpEdit slue)
        {
            HesapBilgileri_Bind(slue, true);
        }

        public static void KiymetliEvrakDoldur(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue)
        {
            KiymetliEvrakDoldur_Bind(rslue);
        }

        public static void KiymetliEvrakDoldur(DevExpress.XtraEditors.SearchLookUpEdit slue)
        {
            KiymetliEvrakDoldur_Bind(slue);
        }

        public static void MalcinsGetirTureGore(RepositoryItemLookUpEdit lue, int TurId)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            cn.AddParams("@TUR_ID", TurId);
            lue.DataSource = cn.GetDataTable("SELECT ID, CINS FROM dbo.TI_KOD_MAL_CINS(nolock) WHERE TUR_ID=@TUR_ID ORDER BY CINS");

            lue.NullText = "Seç";
            lue.DisplayMember = "CINS";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("CINS", "Mal Cinsi", 100));
        }

        public static void ModulDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue, AvukatProLib.Extras.Modul? modul)
        {
            ModulDoldur_Bind(rlue, modul);
        }

        public static void ModulDoldur(DevExpress.XtraEditors.LookUpEdit lue, AvukatProLib.Extras.Modul? modul)
        {
            ModulDoldur_Bind(lue, modul);
        }

        public static void MuhatapHesapBilgilerirDoldur(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslue)
        {
            HesapBilgileri_Bind(rslue, false);
        }

        public static void MuhatapHesapBilgilerirDoldur(DevExpress.XtraEditors.SearchLookUpEdit slue)
        {
            HesapBilgileri_Bind(slue, false);
        }

        public static void OdemeTipiGetir(RepositoryItemLookUpEdit lue)
        {
            OdemeTipiGetir_(lue);
        }

        public static void OdemeTipiGetir(LookUpEdit lue)
        {
            OdemeTipiGetir_(lue);
        }

        public static void OzelKodDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue, int alan, AvukatProLib.Extras.Modul modul)
        {
            OzelKodDoldur_Bind(rlue, alan, modul);
        }

        public static void OzelKodDoldur(DevExpress.XtraEditors.LookUpEdit lue, int alan, AvukatProLib.Extras.Modul modul)
        {
            OzelKodDoldur_Bind(lue, alan, modul);
        }

        public static void ProjeOzelKodDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            ProjeOzelKodDoldur_Bind(rlue);
        }

        public static void ProjeOzelKodDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            ProjeOzelKodDoldur_Bind(lue);
        }

        public static void SegmentDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            SegmentDoldur_Bind(rlue);
        }

        public static void SegmentDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            SegmentDoldur_Bind(lue);
        }

        public static void slue_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            DevExpress.XtraEditors.SearchLookUpEdit slue = (sender as DevExpress.XtraEditors.SearchLookUpEdit);
            for (int rowHandle = 0; rowHandle < slue.Properties.View.RowCount; rowHandle++)
            {
                if ((bool)slue.Properties.View.GetRowCellValue(rowHandle, "IsSelected") == true)
                { slue.Properties.NullText = "Seçildi"; return; }
            }
        }

        public static void TakipKonusuDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            TakipKonusuDoldur_Bind(rlue);
        }

        public static void TakipKonusuDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            TakipKonusuDoldur_Bind(lue);
        }

        public static void TakipYoluDoldur(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            //lue.DataSource = BaseService._db.PerTiKodTakipTalep.ToList();
            lue.DataSource = cn.GetDataTable("select ID,TAKIP_YOLU from dbo.TI_KOD_TAKIP_YOLU order by TAKIP_YOLU");
            lue.ValueMember = "ID";
            lue.DisplayMember = "TAKIP_YOLU";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TAKIP_YOLU", 30, "Takip Yolu"));
        }

        public static void TarafKoduDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            TarafKoduDoldur_Bind(rlue);
        }

        public static void TarafKoduDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            TarafKoduDoldur_Bind(lue);
        }

        public static void TarafSifatDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue, AvukatProLib.Extras.IcraTarafKodu tarafKodu)
        {
            TarafSifatDoldur_Bind(rlue, tarafKodu);
        }

        public static void TarafSifatDoldur(DevExpress.XtraEditors.LookUpEdit lue, AvukatProLib.Extras.IcraTarafKodu tarafKodu)
        {
            TarafSifatDoldur_Bind(lue, tarafKodu);
        }

        public static void TebligatSonucDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            TebligatSonucDoldur_Bind(rlue);
        }

        public static void TebligatSonucDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            TebligatSonucDoldur_Bind(lue);
        }

        public static void TemsilSekliDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            TemsilSekliDoldur_Bind(rlue);
        }

        public static void TemsilSekliDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            TemsilSekliDoldur_Bind(lue);
        }

        public static void VekaletSozlesmeDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            VekaletSozlesmeDoldur_Bind(rlue);
        }

        public static void VekaletSozlesmeDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            VekaletSozlesmeDoldur_Bind(lue);
        }

        public static void view_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < -1)
                return;

            DevExpress.XtraGrid.Views.Grid.GridView gv = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
            gv.SetRowCellValue(e.RowHandle, gv.Columns["IsSelected"], !((bool)gv.GetRowCellValue(e.RowHandle, "IsSelected")));
        }

        public static void View_RowClick2(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle < -1)
                return;
            aaa++;
            if (aaa == 1)
            {
                DevExpress.XtraGrid.Views.Grid.GridView gv = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
                gv.SetRowCellValue(e.RowHandle, gv.Columns["IsSelected"], !((bool)gv.GetRowCellValue(e.RowHandle, "IsSelected")));
            }
            else
                aaa = 0;
        }

        public static void VirmanTipiDoldur(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlue)
        {
            VirmanTipiDoldur_Bind(rlue);
        }

        public static void VirmanTipiDoldur(DevExpress.XtraEditors.LookUpEdit lue)
        {
            VirmanTipiDoldur_Bind(lue);
        }

        private static void AdliyeDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdiKodAdliBirimAdliye.ToList();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID AS Id, ADLIYE AS Adliye, IL as Il, ILCE as Ilce FROM dbo.per_TDI_KOD_ADLI_BIRIM_ADLIYE(nolock) order by ADLIYE");

            lue.DisplayMember = "Adliye";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Adliye", 20, "Adliye"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Il", 20, "İl"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ilce", 20, "İlce") });
        }

        private static void AdliyeGorevDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdiKodAdliBirimGorev.ToList();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("select ID as Id, GOREV as Gorev, ACIKLAMA as Aciklama from dbo.per_TDI_KOD_ADLI_BIRIM_GOREV(nolock) order by ACIKLAMA");

            lue.DisplayMember = "Gorev";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Gorev", 20, "Görev"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Aciklama", 20, "Açıklama") });
        }

        private static void AdliyeNoDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdiKodAdliBirimNo.ToList();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("select ID as Id, [NO] as [No] from dbo.per_TDI_KOD_ADLI_BIRIM_NO(nolock) order by ID");

            lue.DisplayMember = "No";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("No", "Adli Birim No", 100));
        }

        private static void AlacakNedenDoldur_Bind(object sender, AvukatProLib.Extras.FormTipleri? formTipi, AvukatProLib.Extras.FormKonusu? formKonusu, bool? depoAlacagi)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slue = (sender is DevExpress.XtraEditors.SearchLookUpEdit) ? (sender as DevExpress.XtraEditors.SearchLookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit;

            slue.View.Columns.Clear();
            slue.View.Columns.AddRange(AlacakNedenColumns());

            List<AvukatPro.Model.EntityClasses.PerTiKodAlacakNedenEntity> ds = BaseService._db.PerTiKodAlacakNeden.ToList();

            if (formTipi.HasValue)
                ds = ds.Where(x => x.FormTipId == (int)formTipi).ToList();
            if (formKonusu.HasValue)
                ds = ds.Where(x => x.TakipTalepKodId == (int)formKonusu).ToList();
            if (depoAlacagi.HasValue)
                ds = ds.Where(x => x.DepoAlacagi == depoAlacagi).ToList();

            slue.DataSource = ds;

            slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            slue.View.Name = "alacakNedeniView";
            slue.DisplayMember = "AlacakNedeni";
            slue.ValueMember = "Id";
            System.Drawing.Size size = new System.Drawing.Size(500, 200);
            slue.PopupFormSize = size;
            slue.NullText = SetNullText(sender);
            slue.View.OptionsBehavior.Editable = false;
        }

        private static void AltKategoriDoldur_Bind(object sender, int? anaKategoriId, bool gorusmemi)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            dynamic altKategoriler = null;
            if (anaKategoriId == null)
                altKategoriler = BaseService._db.PerTdiKodMuhasebeHareketAltKategori.ToList();
            else if (gorusmemi)
                altKategoriler = BaseService._db.PerTdiKodMuhasebeHareketAltKategori.Where(k => k.GorusmeMi == true).ToList();
            else
                altKategoriler = BaseService._db.PerTdiKodMuhasebeHareketAltKategori.Where(k => k.AnaKategoriId == anaKategoriId).ToList();

            //ABSqlConnection cn = new ABSqlConnection();
            //List<CompInfo> cmpNfoList = CompInfo.CompInfoListGetir(Application.StartupPath);
            //CompInfo cmpNfo = cmpNfoList[0];
            //cn.CnString = cmpNfo.ConStr;

            lue.DataSource = altKategoriler;
            lue.DisplayMember = "AltKategori";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AltKategori", "Kategori", 100));
            if (lue.Columns.Count > 1)
                lue.Columns.RemoveAt(1);
            lue.Buttons.Add(GetAddButton());
            lue.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
        }

        private static void AnaKategoriDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //List<AvukatPro.Model.EntityClasses.PerTdiKodMuhasebeHareketAnaKategoriEntity> anaKategoriler = BaseService._db.PerTdiKodMuhasebeHareketAnaKategori.ToList();
            //lue.DataSource = anaKategoriler;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID AS Id, ANA_KATEGORI AS AnaKategori FROM dbo.per_TDI_KOD_MUHASEBE_HAREKET_ANA_KATEGORI(nolock) ORDER BY ANA_KATEGORI");
            lue.DisplayMember = "AnaKategori";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AnaKategori", "Kategori", 100));
        }

        private static void AracTipiDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox lue = (sender is DevExpress.XtraEditors.ImageComboBoxEdit) ? (sender as DevExpress.XtraEditors.ImageComboBoxEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox;

            lue.NullText = SetNullText(sender);
            lue.AutoHeight = false;
            lue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            lue.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Gemi", 1, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Uçak", 2, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Araç", 3, 2)});
            System.Windows.Forms.ImageList il = new System.Windows.Forms.ImageList();

            il.TransparentColor = System.Drawing.Color.Transparent;
            il.Images.Add(AdimAdimDavaKaydi.Properties.Resources.gemi_40);
            il.Images.Add(AdimAdimDavaKaydi.Properties.Resources.ucak_40);
            il.Images.Add(AdimAdimDavaKaydi.Properties.Resources.araba_40);

            lue.SmallImages = il;
        }

        private static void AvukatDoldur_Bind(object sender, bool IsActive)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //if (IsActive)
            //    lue.DataSource = BaseService._db.PerAv001TdiBilCari.Where(a => a.AvukatMi && !a.FirmaMi && a.PersonelMi && BaseService._db.TdiBilKullaniciListesi.Count(k => k.CariId == a.Id && k.KullaniciAktif) > 0).Select(q => new { Id = q.Id, Kod = q.Kod, Ad = q.Ad }).ToList();
            //else
            //    lue.DataSource = BaseService._db.PerAv001TdiBilCari.Where(a => a.AvukatMi).Select(q => new { Id = q.Id, Kod = q.Kod, Ad = q.Ad }).ToList();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            if (IsActive)
                lue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad FROM dbo.per_AV001_TDI_BIL_CARI(nolock) c INNER JOIN dbo.TDI_BIL_KULLANICI_LISTESI(nolock) k ON k.CARI_ID=c.ID AND k.KULLANICI_AKTIF=1 WHERE c.AVUKAT_MI=1 AND c.FIRMA_MI=0 AND c.PERSONEL_MI=1 ORDER BY c.AD");
            else
                lue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad FROM dbo.per_AV001_TDI_BIL_CARI(nolock) c WHERE c.AVUKAT_MI=1 ORDER BY c.AD");

            lue.DisplayMember = "Ad";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", 10, "Kod"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", 30, "Ad") });
        }

        private static void BankaSubeGetir_Bind(object sender, int? bankaID)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slue = (sender is DevExpress.XtraEditors.SearchLookUpEdit) ? (sender as DevExpress.XtraEditors.SearchLookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit;

            slue.View.Columns.Clear();
            slue.View.Columns.AddRange(BankaSubeColumns());

            List<AvukatPro.Model.EntityClasses.VdiKodBankaSubeEntity> ds = BaseService._db.VdiKodBankaSube.ToList();

            if (bankaID.HasValue)
                ds = ds.Where(s => s.BankaId == bankaID).ToList();

            slue.DataSource = ds;

            slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            slue.View.Name = "subeView";
            slue.DisplayMember = "Sube";
            slue.ValueMember = "Id";
            slue.NullText = SetNullText(sender);
            slue.View.OptionsBehavior.Editable = false;
        }

        private static void BelgeDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slue = (sender is DevExpress.XtraEditors.SearchLookUpEdit) ? (sender as DevExpress.XtraEditors.SearchLookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit;

            slue.View.Columns.Clear();
            slue.View.Columns.AddRange(BelgeColumns());
            //slue.DataSource = BaseService._db.RBelgelerTarafli.ToList();

            slue.DataSource = null;
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            slue.DataSource = cn.GetDataTable("select ID as Id, convert(bit,0) as IsSelected, BELGE_TUR_ID AS BelgeTurId, BELGE_ADI as BelgeAdi, YAZILMA_TARIHI as YazilmaTarihi, BELGEYI_YAZAN_ID as BelgeyiYazanId, DOKUMAN_UZANTI as DokumanUzanti, BELGE_TARAF_ID as BelgeTarafId from dbo.R_BELGELER_TARAFLI(nolock)");

            slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            slue.View.Name = "belgeView";
            slue.DisplayMember = "BelgeAdi";
            slue.ValueMember = "Id";
            slue.NullText = SetNullText(sender);
            slue.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            slue.View.OptionsView.ShowGroupPanel = true;
            slue.View.OptionsBehavior.Editable = true;
            slue.View.OptionsSelection.MultiSelect = true;
            slue.View.OptionsView.ShowAutoFilterRow = true;
            slue.View.OptionsView.ShowGroupedColumns = true;
            slue.View.OptionsView.ShowGroupPanel = true;
            if (slue.Buttons.Count > 1)
                slue.Buttons.RemoveAt(1);
            slue.Buttons.Add(GetAddButton());
            slue.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            slue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
            //slue.View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(view_RowClick);
            slue.View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(View_RowClick2);
        }

        private static void BelgeTuruDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdieKodBelgeTur.ToList();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID AS Id, BELGE_TURU AS BelgeTuru FROM dbo.per_TDIE_KOD_BELGE_TUR(NOLOCK) ORDER BY BELGE_TURU");

            lue.DisplayMember = "BelgeTuru";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BelgeTuru", "Belge Türü", 40));
        }

        public static void CariDoldur_Bind(object sender, bool IsSearchLookUpEdit, AvukatProLib.Extras.CariStatu? tipi)
        {
            if (IsSearchLookUpEdit == false)
            {
                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

                //lue.DataSource = BaseService._db.PerAv001TdiBilCari.Select(q => new { Id = q.Id, Kod = q.Kod, Ad = q.Ad }).ToList();

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

                if (tipi == AvukatProLib.Extras.CariStatu.Personel)
                {
                    lue.DataSource = cn.GetDataTable("SELECT ID AS Id, AD AS Ad FROM dbo.per_CariKimlikIletisimBilgileri(nolock) WHERE PERSONEL_MI=1");

                    lue.DisplayMember = "Ad";
                    lue.ValueMember = "Id";
                    lue.NullText = SetNullText(sender);
                    lue.Columns.Clear();
                    lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", 30, "Ad") });
                }
                else if (tipi == AvukatProLib.Extras.CariStatu.Müvekkil)
                {
                    lue.DataSource = cn.GetDataTable("SELECT ID AS Id, AD AS Ad FROM dbo.per_CariKimlikIletisimBilgileri(nolock) WHERE MUVEKKIL_MI=1");

                    lue.DisplayMember = "Ad";
                    lue.ValueMember = "Id";
                    lue.NullText = SetNullText(sender);
                    lue.Columns.Clear();
                    lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", 30, "Ad") });
                }
                else
                {
                    lue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.VERGI_NO FROM dbo.per_AV001_TDI_BIL_CARI(nolock) c ORDER BY c.AD");

                    lue.DisplayMember = "Ad";
                    lue.ValueMember = "Id";
                    lue.NullText = SetNullText(sender);
                    lue.Columns.Clear();
                    lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", 10, "Kod"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", 30, "Ad"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VERGI_NO", 30, "Vergi/TC") });
                }
            }
            else
            {
                DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slue = (sender is DevExpress.XtraEditors.SearchLookUpEdit) ? (sender as DevExpress.XtraEditors.SearchLookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit;

                slue.View.Columns.Clear();
                slue.View.Columns.AddRange(CariColumns());

                //if (tipi == AvukatProLib.Extras.CariStatu.Personel)
                //    slue.DataSource = BaseService._db.PerCariKimlikIletisimBilgileri.Where(c => c.PersonelMi).ToList();
                //else if (tipi == AvukatProLib.Extras.CariStatu.Avukat)
                //    slue.DataSource = BaseService._db.PerCariKimlikIletisimBilgileri.Where(c => c.AvukatMi).ToList();
                //else if (tipi == AvukatProLib.Extras.CariStatu.Müvekkil)
                //    slue.DataSource = BaseService._db.PerCariKimlikIletisimBilgileri.Where(c => c.MuvekkilMi).ToList();
                //else
                //    slue.DataSource = BaseService._db.PerCariKimlikIletisimBilgileri.ToList();

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

                if (tipi == AvukatProLib.Extras.CariStatu.Personel)
                    slue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c LEFT JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID WHERE PERSONEL_MI=1 ORDER BY c.AD");
                else if (tipi == AvukatProLib.Extras.CariStatu.Avukat)
                    slue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c LEFT JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID WHERE AVUKAT_MI=1 ORDER BY c.AD");
                else if (tipi == AvukatProLib.Extras.CariStatu.Müvekkil)
                    slue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c LEFT JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID WHERE MUVEKKIL_MI=1 ORDER BY c.AD");
                else
                    slue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c LEFT JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID ORDER BY c.AD");

                slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                slue.View.Name = "cariView";
                slue.DisplayMember = "Ad";
                slue.ValueMember = "Id";
                slue.NullText = SetNullText(sender);
                slue.View.OptionsSelection.EnableAppearanceFocusedCell = false;
                slue.View.OptionsView.ShowGroupPanel = true;
                //slue.View.OptionsBehavior.Editable = true;
                //slue.View.OptionsSelection.MultiSelect = true;
                slue.View.OptionsView.ShowAutoFilterRow = true;
                slue.View.OptionsView.ShowGroupedColumns = true;
                slue.View.OptionsView.ShowGroupPanel = true;
                if (slue.Buttons.Count > 1)
                    slue.Buttons.RemoveAt(1);
                slue.Buttons.Add(GetAddButton());
                slue.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
                //slue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
                //slue.View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(view_RowClick);
            }
        }

        private static void CariDoldur_Bind2(GridControl grid, AvukatProLib.Extras.CariStatu? tipi)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            if (tipi == AvukatProLib.Extras.CariStatu.Personel)
                grid.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c INNER JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID WHERE PERSONEL_MI=1 ORDER BY c.AD");
            else if (tipi == AvukatProLib.Extras.CariStatu.Avukat)
                grid.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c INNER JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID WHERE AVUKAT_MI=1 ORDER BY c.AD");
            else if (tipi == AvukatProLib.Extras.CariStatu.Müvekkil)
                grid.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c INNER JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID WHERE MUVEKKIL_MI=1 ORDER BY c.AD");
            else
                grid.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c INNER JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID ORDER BY c.AD");
        }

        private static void CariDoldur_Bind3(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit slue, AvukatProLib.Extras.CariStatu? tipi)
        {
            slue.View.Columns.Clear();
            slue.View.Columns.AddRange(CariColumns());

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            if (tipi == AvukatProLib.Extras.CariStatu.Personel)
                slue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c LEFT JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID WHERE PERSONEL_MI=1 ORDER BY c.AD");
            else if (tipi == AvukatProLib.Extras.CariStatu.Avukat)
                slue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c LEFT JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID WHERE AVUKAT_MI=1 ORDER BY c.AD");
            else if (tipi == AvukatProLib.Extras.CariStatu.Müvekkil)
                slue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c LEFT JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID WHERE MUVEKKIL_MI=1 ORDER BY c.AD");
            else
                slue.DataSource = cn.GetDataTable("SELECT c.ID AS Id, c.KOD AS Kod, c.AD AS Ad, c.MUSTERI_NO AS MusteriNo, k.BABA_ADI AS BabaAdi, k.ANNE_KIZLIK_SOYADI AS AnneKizlikSoyadi, k.DOGUM_TARIHI AS DogumTarihi, c.ESKI_UNVANI_ADI AS EskiUnvaniAdi, c.VERGI_NO AS VergiNo, k.TC_KIMLIK_NO AS TcKimlikNo, c.TEL_1 AS Tel1, c.TEL_2 AS Tel2, c.CEP_TEL AS CepTel, c.EMAIL_1 AS Email1 FROM dbo.AV001_TDI_BIL_CARI(nolock) c LEFT JOIN dbo.AV001_TDI_BIL_CARI_KIMLIK(nolock) k ON k.CARI_ID = c.ID ORDER BY c.AD");

            slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            slue.View.Name = "cariView";
            slue.DisplayMember = "Ad";
            slue.ValueMember = "Id";
            slue.NullText = "Seç";
            slue.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            slue.View.OptionsView.ShowGroupPanel = true;
            //slue.View.OptionsBehavior.Editable = true;
            //slue.View.OptionsSelection.MultiSelect = true;
            slue.View.OptionsView.ShowAutoFilterRow = true;
            slue.View.OptionsView.ShowGroupedColumns = true;
            slue.View.OptionsView.ShowGroupPanel = true;
            if (slue.Buttons.Count > 1)
                slue.Buttons.RemoveAt(1);
            slue.Buttons.Add(GetAddButton());
            slue.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            //slue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
            //slue.View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(view_RowClick);
        }

        private static void CariPersonelKodGetir_(object sender)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                //if (_per_CariGetir != null && _per_CariGetir.Count > 0)
                //{
                //    _CariAvukatKodGetir_Enter = new VList<per_AV001_TDI_BIL_CARI>(_per_CariGetir.FindAll(item => item.FIRMA_MI == false && item.PERSONEL_MI == true));
                //}
                //else if (_CariPersonelKodGetir_Enter == null || _CariPersonelKodGetir_Enter.Count == 0)
                //{
                //    _CariPersonelKodGetir_Enter = DataRepository.per_AV001_TDI_BIL_CARIProvider.Get("FIRMA_MI = 'FALSE' AND PERSONEL_MI = 'TRUE'", "KOD");
                //}

                //lue.Columns.Clear();
                //lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod") });
                //lue.DataSource = _CariPersonelKodGetir_Enter;

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

                lue.DataSource = cn.GetDataTable("SELECT ID, KOD, AD FROM dbo.per_AV001_TDI_BIL_CARI(nolock) WHERE FIRMA_MI = 'FALSE' AND PERSONEL_MI = 'TRUE' ORDER BY AD");
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.NullText = "Seç";
            }
        }

        private static void DavaNedeniDoldur_Bind(object sender, int? bolumId, bool IsSikayetNeden)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slue = (sender is DevExpress.XtraEditors.SearchLookUpEdit) ? (sender as DevExpress.XtraEditors.SearchLookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit;

            slue.View.Columns.Clear();
            slue.View.Columns.AddRange(DavaNedenColumns());
            if (bolumId.HasValue)
                slue.DataSource = BaseService._db.PerTdiKodDavaAdi.Where(a => a.AdliBirimBolumId == bolumId).ToList();
            else if (IsSikayetNeden == true)
                slue.DataSource = BaseService._db.PerTdiKodDavaAdi.Where(a => a.AdliBirimBolumId == 1 || a.AdliBirimBolumId == 9 || a.AdliBirimBolumId == 11).ToList();
            else
                slue.DataSource = BaseService._db.PerTdiKodDavaAdi.ToList();
            slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            slue.View.Name = "davaAdiView";
            slue.DisplayMember = "DavaAdi";
            slue.ValueMember = "Id";
            System.Drawing.Size size = new System.Drawing.Size(800, 300);
            slue.PopupFormSize = size;
            slue.NullText = SetNullText(sender);
            slue.View.OptionsBehavior.Editable = false;
        }

        private static void DosyaDoldur_Bind(object sender, AvukatProLib.Extras.Modul modul, bool canMultiSelect)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slue = (sender is DevExpress.XtraEditors.SearchLookUpEdit) ? (sender as DevExpress.XtraEditors.SearchLookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit;

            slue.View.Columns.Clear();
            slue.View.Columns.AddRange(DosyaColumns(modul));

            //aykut hızlandırma 25.01.2013
            //slue.DataSource = GetAllDosyaByModul(modul);

            //ABSqlConnection cn = new ABSqlConnection();
            //cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            SqlConnection cn = new SqlConnection(Kimlikci.Kimlik.SirketBilgisi.ConStr);
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID AS Id,convert(bit,0) as IsSelected, Taraf_Adi as TarafAdi, Dosya_No as DosyaNo, Adliye, [No], Gorev, Esas_No as EsasNo, Takip_T as TakipT FROM dbo.R_BIRLESIK_TAKIPLER_MODUL_TEXT(nolock) WHERE MODUL=@Modul and ID is not null", cn);
            da.SelectCommand.Parameters.AddWithValue("@Modul", (int)modul);

            da.SelectCommand.CommandTimeout = 999999999;
            DataTable dt = new DataTable();
            da.Fill(dt);
            slue.DataSource = dt;

            slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            slue.View.Name = "dosyaView";
            slue.DisplayMember = "DosyaNo";
            slue.ValueMember = "Id";
            slue.NullText = SetNullText(sender);
            slue.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            slue.View.OptionsView.ShowGroupPanel = true;
            slue.View.OptionsBehavior.Editable = false;
            slue.View.OptionsView.ShowAutoFilterRow = true;
            slue.View.OptionsView.ShowGroupedColumns = true;
            slue.View.OptionsView.ShowGroupPanel = true;

            if (canMultiSelect)
            {
                slue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
                slue.View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(view_RowClick);
            }
            else
                slue.View.Columns.Remove(slue.View.Columns["IsSelected"]);
        }

        private static void DosyaTaraflariniDoldur_Bind(object sender, Messaging.GetDosyaTaraflariRequest request)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            object[] cariList = null;

            if (request.ModulId == (int)AvukatProLib.Extras.Modul.Icra)
            {
                cariList = (from t in BaseService._db.PerAv001TiBilFoyTaraf where t.IcraFoyId == request.FoyId && t.TarafKodu == (int)AvukatProLib.Extras.TarafKodu.Muvekkil select t).ToArray();
            }
            if (request.ModulId == (int)AvukatProLib.Extras.Modul.Dava)
            {
                cariList = (from t in BaseService._db.PerAv001TdBilFoyTaraf where t.DavaFoyId == request.FoyId && t.TarafKodu == (int)AvukatProLib.Extras.TarafKodu.Muvekkil select t).ToArray();
            }
            if (request.ModulId == (int)AvukatProLib.Extras.Modul.Sorusturma)
            {
                cariList = (from t in BaseService._db.PerAv001TdBilHazirlikTaraf where t.HazirlikId == request.FoyId && t.TarafKodu == (int)AvukatProLib.Extras.TarafKodu.Muvekkil select t).ToArray();
            }
            if (request.ModulId == (int)AvukatProLib.Extras.Modul.Sozlesme)
            {
                cariList = (from t in BaseService._db.PerAv001TdiBilSozlesmeTaraf where t.SozlesmeId == request.FoyId && t.TarafKodu == (int)AvukatProLib.Extras.TarafKodu.Muvekkil select t).ToArray();
            }

            if (cariList != null && cariList.Count() > 0)
            {
                lue.DataSource = cariList;
                lue.DisplayMember = "Ad";
                lue.ValueMember = "CariId";
                lue.NullText = SetNullText(sender);
                lue.Columns.Clear();
                lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                    {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", 10, "Kod"),
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", 30, "Ad")
                    });
            }
        }

        private static void DovizTipiDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdiKodDovizTip.ToList();
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            lue.DataSource = cn.GetDataTable("SELECT ID AS Id, DOVIZ_KODU AS DovizKodu FROM dbo.per_TDI_KOD_DOVIZ_TIP(nolock) ORDER BY DOVIZ_KODU");
            lue.DisplayMember = "DovizKodu";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Doviz Kodu", 10, "Birim"));
        }

        private static void EvrakDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slue = (sender is DevExpress.XtraEditors.SearchLookUpEdit) ? (sender as DevExpress.XtraEditors.SearchLookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit;

            slue.View.Columns.Clear();
            slue.View.Columns.AddRange(EvrakColumns());
            //slue.DataSource = BaseService._db.RBirlesikTakiplerTebligat.ToList();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            slue.DataSource = cn.GetDataTable("select a.ID as Id, convert(bit, 0) as IsSelected, DOSYA_NO as DosyaNo, Adliye, Gorev, [No], Esas_No as EsasNo, TEBLIGAT_REFERANS_NO AS ReferansNo, Durum, MUHATAP_CARI_ID as TarafAdi, '' as Sifat, a.ALT_TUR_ID as AltTurId from dbo.R_BIRLESIK_TAKIPLER_TEBLIGAT(nolock) a INNER JOIN dbo.AV001_TDI_BIL_TEBLIGAT(nolock) b ON b.ID=a.ID");

            slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            slue.View.Name = "evrakView";
            slue.DisplayMember = "DosyaNo";
            slue.ValueMember = "Id";
            slue.NullText = SetNullText(sender);
            slue.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            slue.View.OptionsView.ShowGroupPanel = true;
            slue.View.OptionsBehavior.Editable = true;
            slue.View.OptionsSelection.MultiSelect = true;
            slue.View.OptionsView.ShowAutoFilterRow = true;
            slue.View.OptionsView.ShowGroupedColumns = true;
            slue.View.OptionsView.ShowGroupPanel = true;
            if (slue.Buttons.Count > 1)
                slue.Buttons.RemoveAt(1);
            slue.Buttons.Add(GetAddButton());
            slue.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            slue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
            slue.View.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(view_RowClick);
        }

        private static void EvrakSonucDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            lue.DataSource = BaseService._db.PerTdiKodEvrakSonuc.ToList();
            lue.DisplayMember = "EvrakSonuc";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EvrakSonucu", 20, "Sonuç"));
        }

        private static void FormTipiDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            lue.DataSource = BaseService._db.PerTiKodFormTip.Where(f => f.FormOrnekNo != "48").ToList();
            lue.DisplayMember = "FormOrnekNo";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
            {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormOrnekNo",80,"No"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FormAdi",500,"Açıklama")
            });
        }

        private static void FoyDurumDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdiKodFoyDurum.ToList();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID AS Id, DURUM AS Durum FROM dbo.per_TDI_KOD_FOY_DURUM(nolock) ORDER BY DURUM");

            lue.DisplayMember = "Durum";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Durum", "Föy Durum", 40));
        }

        private static void FoyIadeNedenDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            lue.DataSource = BaseService._db.PerTdiKodFoyIadeNeden.ToList();
            lue.DisplayMember = "IadeNeden";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IadeNeden", "İade Nedeni", 100));
        }

        private static DevExpress.XtraEditors.Controls.EditorButton GetAddButton()
        {
            DevExpress.XtraEditors.Controls.EditorButton btn = new DevExpress.XtraEditors.Controls.EditorButton();
            //btn.Image = System.Drawing.Bitmap.FromFile(System.Windows.Forms.Application.StartupPath + "Resources/add-22x221.png");
            btn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Plus;
            btn.Tag = "ekle";
            btn.ToolTip = "yeni kayıt ekle";

            return btn;
        }

        private static void HesapBilgileri_Bind(object sender, bool kasami)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slue = (sender is DevExpress.XtraEditors.SearchLookUpEdit) ? (sender as DevExpress.XtraEditors.SearchLookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit;

            slue.View.Columns.Clear();
            slue.View.Columns.AddRange(HesapBilgileriColumns());

            //if (kasami)
            //    slue.DataSource = (from b in BaseService._db.Av001TdiBilCariBanka join c in BaseService._db.Av001TdiBilCari on b.CariId equals c.Id where c.PersonelMi == true select b).ToList();
            //else
            //    slue.DataSource = BaseService._db.Av001TdiBilCariBanka.ToList();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            if (kasami)
                slue.DataSource = cn.GetDataTable("SELECT ID AS Id, CARI_ID AS CariId, IBAN_NO AS IbanNo, BANKA_ID AS BankaId, SUBE_ID AS SubeId, DOVIZ_ID AS DovizId, HESAP_NO AS HesapNo, KART_NO AS KartNo, KART_TIP_ID AS KartTipId, SON_KULLANIM_TARIHI AS SonKullanimTarihi FROM dbo.AV001_TDI_BIL_CARI_BANKA(nolock) a WHERE CARI_ID IN(SELECT ID FROM dbo.AV001_TDI_BIL_CARI(nolock) WHERE PERSONEL_MI=1)");
            else
                slue.DataSource = cn.GetDataTable("SELECT ID AS Id, CARI_ID AS CariId, IBAN_NO AS IbanNo, BANKA_ID AS BankaId, SUBE_ID AS SubeId, DOVIZ_ID AS DovizId, HESAP_NO AS HesapNo, KART_NO AS KartNo, KART_TIP_ID AS KartTipId, SON_KULLANIM_TARIHI AS SonKullanimTarihi FROM dbo.AV001_TDI_BIL_CARI_BANKA(nolock) a");

            slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            slue.View.Name = "hesapBilgileriView";
            slue.DisplayMember = "IbanNo";
            slue.ValueMember = "Id";
            slue.NullText = SetNullText(sender);
            slue.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            slue.View.OptionsView.ShowGroupPanel = true;
            slue.View.OptionsBehavior.Editable = false;
            slue.View.OptionsView.ShowAutoFilterRow = true;
            slue.View.OptionsView.ShowGroupedColumns = true;
            slue.View.OptionsView.ShowGroupPanel = true;
            slue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
        }

        private static void KiymetliEvrakDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit slue = (sender is DevExpress.XtraEditors.SearchLookUpEdit) ? (sender as DevExpress.XtraEditors.SearchLookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit;

            slue.View.Columns.Clear();
            slue.View.Columns.AddRange(KiymetliEvrakColumns());
            slue.DataSource = BaseService._db.KiymetliEvrakTarafli.ToList();
            slue.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            slue.View.Name = "kiymetliEvrakView";
            slue.DisplayMember = "";
            slue.ValueMember = "Id";
            slue.NullText = SetNullText(sender);
            slue.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            slue.View.OptionsView.ShowGroupPanel = true;
            slue.View.OptionsBehavior.Editable = false;
            slue.View.OptionsView.ShowAutoFilterRow = true;
            slue.View.OptionsView.ShowGroupedColumns = true;
            slue.View.OptionsView.ShowGroupPanel = true;
            if (slue.Buttons.Count > 1)
                slue.Buttons.RemoveAt(1);
            slue.Buttons.Add(GetAddButton());
            slue.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(slue_Closed);
            slue.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
        }

        private static void ModulDoldur_Bind(object sender, AvukatProLib.Extras.Modul? modul)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //List<AvukatPro.Model.EntityClasses.PerTdieKodModulEntity> sonuc = null;
            //if (modul == null)
            //    sonuc = BaseService._db.PerTdieKodModul.ToList();

            ////aykut
            //List<AvukatPro.Model.EntityClasses.PerTdieKodModulEntity> sonuc2 = new List<Model.EntityClasses.PerTdieKodModulEntity>();

            //foreach (AvukatPro.Model.EntityClasses.PerTdieKodModulEntity item in sonuc)
            //{
            //    if (item.Id == 1 || item.Id == 2 || item.Id == 3 || item.Id == 5 || item.Id == 7)
            //        sonuc2.Add(item);
            //}

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            lue.DataSource = cn.GetDataTable("SELECT ID AS Id, AD AS Ad FROM dbo.per_TDIE_KOD_MODUL(nolock) where ID in (1,2,3,5,7)");
            lue.DisplayMember = "Ad";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Modül", 50));
        }

        private static void OdemeTipiGetir_(object sender)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            if (lue.DataSource == null)
            {
                //if (_OdemeTipiGetir == null)
                //    _OdemeTipiGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ODEME_TIPProvider.GetAll();
                //lue.DataSource = _OdemeTipiGetir;

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
                lue.DataSource = cn.GetDataTable("SELECT ID, ODEME_TIP FROM dbo.per_TDI_KOD_ODEME_TIP(nolock) ORDER BY ODEME_TIP");
                lue.ValueMember = "ID";
                lue.DisplayMember = "ODEME_TIP";
                lue.NullText = "Seç";

                LookUpColumnInfo ID = new LookUpColumnInfo("ID", 20);
                ID.Visible = false;

                LookUpColumnInfo ODEME_TIP = new LookUpColumnInfo("ODEME_TIP", 40, "Ödeme Tipi");
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { ID, ODEME_TIP });
            }
        }

        private static void OzelKodDoldur_Bind(object sender, int alan, AvukatProLib.Extras.Modul modul)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //List<AvukatPro.Model.EntityClasses.PerAv001TdiKodFoyOzelKodEntity> list = null;

            //switch (modul)
            //{
            //    case AvukatProLib.Extras.Modul.Icra:
            //        if (alan == 1)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Icra == true && k.Alan1 == true).ToList();
            //        else if (alan == 2)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Icra == true && k.Alan2 == true).ToList();
            //        else if (alan == 3)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Icra == true && k.Alan3 == true).ToList();
            //        else if (alan == 4)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Icra == true && k.Alan4 == true).ToList();
            //        break;
            //    case AvukatProLib.Extras.Modul.Dava:
            //        if (alan == 1)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Dava == true && k.Alan1 == true).ToList();
            //        else if (alan == 2)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Dava == true && k.Alan2 == true).ToList();
            //        else if (alan == 3)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Dava == true && k.Alan3 == true).ToList();
            //        else if (alan == 4)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Dava == true && k.Alan4 == true).ToList();
            //        break;
            //    case AvukatProLib.Extras.Modul.Sorusturma:
            //        if (alan == 1)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Hazirlik == true && k.Alan1 == true).ToList();
            //        else if (alan == 2)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Hazirlik == true && k.Alan2 == true).ToList();
            //        else if (alan == 3)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Hazirlik == true && k.Alan3 == true).ToList();
            //        else if (alan == 4)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Hazirlik == true && k.Alan4 == true).ToList();
            //        break;
            //    case AvukatProLib.Extras.Modul.Sozlesme:
            //        if (alan == 1)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Sozlesme == true && k.Alan1 == true).ToList();
            //        else if (alan == 2)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Sozlesme == true && k.Alan2 == true).ToList();
            //        else if (alan == 3)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Sozlesme == true && k.Alan3 == true).ToList();
            //        else if (alan == 4)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Sozlesme == true && k.Alan4 == true).ToList();
            //        break;
            //    case AvukatProLib.Extras.Modul.Tebligat:
            //        if (alan == 1)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Tebligat == true && k.Alan1 == true).ToList();
            //        else if (alan == 2)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Tebligat == true && k.Alan2 == true).ToList();
            //        else if (alan == 3)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Tebligat == true && k.Alan3 == true).ToList();
            //        else if (alan == 4)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Tebligat == true && k.Alan4 == true).ToList();
            //        break;
            //    case AvukatProLib.Extras.Modul.Gorusme:
            //        if (alan == 1)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Gorusme == true && k.Alan1 == true).ToList();
            //        else if (alan == 2)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Gorusme == true && k.Alan2 == true).ToList();
            //        else if (alan == 3)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Gorusme == true && k.Alan3 == true).ToList();
            //        else if (alan == 4)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Gorusme == true && k.Alan4 == true).ToList();
            //        break;
            //    case AvukatProLib.Extras.Modul.Ilam:
            //        if (alan == 1)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.IlamMahkemesi == true && k.Alan1 == true).ToList();
            //        else if (alan == 2)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.IlamMahkemesi == true && k.Alan2 == true).ToList();
            //        else if (alan == 3)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.IlamMahkemesi == true && k.Alan3 == true).ToList();
            //        else if (alan == 4)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.IlamMahkemesi == true && k.Alan4 == true).ToList();
            //        break;
            //    case AvukatProLib.Extras.Modul.Belge:

            //        if (alan == 1)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Belge == true && k.Alan1 == true).ToList();
            //        else if (alan == 2)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Belge == true && k.Alan2 == true).ToList();
            //        else if (alan == 3)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Belge == true && k.Alan3 == true).ToList();
            //        else if (alan == 4)
            //            list = BaseService._db.PerAv001TdiKodFoyOzelKod.Where(k => k.Belge == true && k.Alan4 == true).ToList();
            //        break;
            //    default:
            //        break;
            //}

            //if (list != null)
            //    lue.DataSource = list;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            switch (modul)
            {
                case AvukatProLib.Extras.Modul.Icra:
                    lue.DataSource = cn.GetDataTable("select ID as Id, KOD as Kod from dbo.per_AV001_TDI_KOD_FOY_OZEL_KOD(nolock) where ICRA=1 and ALAN" + alan + "=1 order by KOD");
                    break;

                case AvukatProLib.Extras.Modul.Dava:
                    lue.DataSource = cn.GetDataTable("select ID as Id, KOD as Kod from dbo.per_AV001_TDI_KOD_FOY_OZEL_KOD(nolock) where DAVA=1 and ALAN" + alan + "=1 order by KOD");
                    break;

                case AvukatProLib.Extras.Modul.Sorusturma:
                    lue.DataSource = cn.GetDataTable("select ID as Id, KOD as Kod from dbo.per_AV001_TDI_KOD_FOY_OZEL_KOD(nolock) where HAZIRLIK=1 and ALAN" + alan + "=1 order by KOD");
                    break;

                case AvukatProLib.Extras.Modul.Sozlesme:
                    lue.DataSource = cn.GetDataTable("select ID as Id, KOD as Kod from dbo.per_AV001_TDI_KOD_FOY_OZEL_KOD(nolock) where SOZLESME=1 and ALAN" + alan + "=1 order by KOD");
                    break;

                case AvukatProLib.Extras.Modul.Tebligat:
                    lue.DataSource = cn.GetDataTable("select ID as Id, KOD as Kod from dbo.per_AV001_TDI_KOD_FOY_OZEL_KOD(nolock) where TEBLIGAT=1 and ALAN" + alan + "=1 order by KOD");
                    break;

                case AvukatProLib.Extras.Modul.Gorusme:
                    lue.DataSource = cn.GetDataTable("select ID as Id, KOD as Kod from dbo.per_AV001_TDI_KOD_FOY_OZEL_KOD(nolock) where GORUSME=1 and ALAN" + alan + "=1 order by KOD");
                    break;

                case AvukatProLib.Extras.Modul.Ilam:
                    lue.DataSource = cn.GetDataTable("select ID as Id, KOD as Kod from dbo.per_AV001_TDI_KOD_FOY_OZEL_KOD(nolock) where ILAM_MAHKEMESI=1 and ALAN" + alan + "=1 order by KOD");
                    break;

                case AvukatProLib.Extras.Modul.Belge:
                    lue.DataSource = cn.GetDataTable("select ID as Id, KOD as Kod from dbo.per_AV001_TDI_KOD_FOY_OZEL_KOD(nolock) where BELGE=1 and ALAN" + alan + "=1 order by KOD");
                    break;

                case AvukatProLib.Extras.Modul.Klasor:
                    lue.DataSource = cn.GetDataTable("select ID as Id, KOD as Kod from dbo.per_AV001_TDI_KOD_FOY_OZEL_KOD(nolock) where PROJE=1 and ALAN" + alan + "=1 order by KOD");
                    break;

                default:
                    break;
            }

            lue.Columns.Clear();
            lue.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Kod", 20, "Kod") });
            lue.DisplayMember = "Kod";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            if (lue.Buttons.Count > 1)
                lue.Buttons.RemoveAt(1);
            lue.Buttons.Add(GetAddButton());
            lue.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
        }

        private static void ProjeOzelKodDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            lue.DataSource = BaseService._db.PerTdieKodProjeOzelKod.ToList();
            lue.DisplayMember = "OzelKod";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OzelKod", "Durum", 100));
        }

        private static void SegmentDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;
            //List<AvukatPro.Model.EntityClasses.PerTdiKodSegmentEntity> segments = BaseService._db.PerTdiKodSegment.ToList();

            //if (segments != null)
            //{
            //    lue.DataSource = segments;

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("select ID as Id, SEGMENT as Segment from dbo.per_TDI_KOD_SEGMENT");

            lue.DisplayMember = "Segment";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Segment", 200));
            if (lue.Buttons.Count > 1)
                lue.Buttons.RemoveAt(1);
            lue.Buttons.Add(GetAddButton());
            lue.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            //}
        }

        private static string SetNullText(object sender)
        {
            if (sender is DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
                return "BOŞ";
            else
                return "Seçiniz";
        }

        private static void TakipKonusuDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            lue.DataSource = BaseService._db.PerTiKodTakipTalep.ToList();
            lue.ValueMember = "Id";
            lue.DisplayMember = "TalepAdi";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TalepAdi", 30, "Takip Konusu"));
        }

        private static void TarafKoduDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.TdiKodTaraf.ToList();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID AS Id, KOD AS Kod, TIP AS Tip FROM dbo.TDI_KOD_TARAF(NOLOCK)");

            lue.DisplayMember = "Kod";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Tip", 30, "Taraf Kodu"));
        }

        private static void TarafSifatDoldur_Bind(object sender, AvukatProLib.Extras.IcraTarafKodu tarafKodu)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.TdieKodTarafSifat.Where(t => t.HangiTarafNo == (byte)tarafKodu).ToList();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID AS Id, SIFAT AS Sifat FROM dbo.TDIE_KOD_TARAF_SIFAT(nolock) WHERE HANGI_TARAF_NO=" + (byte)tarafKodu + " ORDER BY SIFAT");

            lue.DisplayMember = "Sifat";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Sifat", 100, "Taraf Sıfat"));
        }

        private static void TebligatSonucDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            lue.DataSource = BaseService._db.PerTdiKodTebligatSonuc.ToList();
            lue.DisplayMember = "TebligatSonuc";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TebligatSonuc", 20, "Sonuç"));
        }

        private static void TemsilSekliDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            //lue.DataSource = BaseService._db.PerTdiKodTemsilSekil.ToList();

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;
            lue.DataSource = cn.GetDataTable("SELECT ID AS Id, TEMSIL_SEKIL AS TemsilSekil FROM dbo.per_TDI_KOD_TEMSIL_SEKIL(nolock)");

            lue.DisplayMember = "TemsilSekil";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TemsilSekil", 10, "Temsil Şekli"));
        }

        private static void VekaletSozlesmeDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;

            lue.DataSource = BaseService._db.Av001TiBilVekaletSozlesme.ToList();
            lue.ValueMember = "Id";
            lue.DisplayMember = "SozlesmeKategori";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SozlesmeKategori", "Sözleşme", 30));
            if (lue.Buttons.Count > 1)
                lue.Buttons.RemoveAt(1);
            lue.Buttons.Add(GetAddButton());
            lue.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
        }

        private static void VirmanTipiDoldur_Bind(object sender)
        {
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lue = (sender is DevExpress.XtraEditors.LookUpEdit) ? (sender as DevExpress.XtraEditors.LookUpEdit).Properties : sender as DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit;
            List<AvukatPro.Model.EntityClasses.PerTdiKodMuhasebeHareketAltKategoriEntity> categories = BaseService._db.PerTdiKodMuhasebeHareketAltKategori.Where(c => c.Id == 4 || c.Id == 40 || c.Id == 316).ToList();

            lue.DataSource = categories;
            lue.DisplayMember = "AltKategori";
            lue.ValueMember = "Id";
            lue.NullText = SetNullText(sender);
            lue.Columns.Clear();
            lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AltKategori", 200));
        }

        #region Columns

        private static DevExpress.XtraGrid.Columns.GridColumn[] AlacakNedenColumns()
        {
            #region Columns

            DevExpress.XtraGrid.Columns.GridColumn colId = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colAlacakNedeni = new DevExpress.XtraGrid.Columns.GridColumn();

            #region Column Properties

            //
            //colId
            //
            colId.Caption = " ";
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            colId.Width = 25;
            colId.VisibleIndex = -1;
            colId.OptionsColumn.AllowEdit = false;
            //
            //colAlacakNedeni
            //
            colAlacakNedeni.Caption = "Alacak Nedeni";
            colAlacakNedeni.FieldName = "AlacakNedeni";
            colAlacakNedeni.Name = "colAlacakNedeni";
            colAlacakNedeni.Visible = true;
            colAlacakNedeni.Width = 300;
            colAlacakNedeni.VisibleIndex = 0;
            colAlacakNedeni.OptionsColumn.AllowEdit = false;

            #endregion Column Properties

            #endregion Columns

            DevExpress.XtraGrid.Columns.GridColumn[] kolonlar = new[]
            {
                colId,
                colAlacakNedeni,
            };

            return kolonlar;
        }

        private static DevExpress.XtraGrid.Columns.GridColumn[] BankaSubeColumns()
        {
            #region Columns

            DevExpress.XtraGrid.Columns.GridColumn colId = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colSubeAdi = new DevExpress.XtraGrid.Columns.GridColumn();

            #region Column Properties

            //
            //colId
            //
            colId.Caption = " ";
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            colId.Width = 25;
            colId.VisibleIndex = -1;
            colId.OptionsColumn.AllowEdit = false;
            //
            //colSubeAdi
            //
            colSubeAdi.Caption = "Şube";
            colSubeAdi.FieldName = "Sube";
            colSubeAdi.Name = "colSubeAdi";
            colSubeAdi.Visible = true;
            colSubeAdi.Width = 50;
            colSubeAdi.VisibleIndex = 0;
            colSubeAdi.OptionsColumn.AllowEdit = false;

            #endregion Column Properties

            #endregion Columns

            DevExpress.XtraGrid.Columns.GridColumn[] kolonlar = new[]
            {
                colId,
                colSubeAdi,
            };

            return kolonlar;
        }

        private static DevExpress.XtraGrid.Columns.GridColumn[] BelgeColumns()
        {
            #region RepositoryItems

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueBelgeTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            #region Binds

            BelgeUtil.Inits.BelgeTurGetir(rlueBelgeTur);
            BelgeUtil.Inits.perCariGetir(rlueCari);

            #endregion Binds

            #endregion RepositoryItems

            #region Columns

            DevExpress.XtraGrid.Columns.GridColumn colId = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colBelgeTur = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colBelgeAd = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colBelgeYazılmaT = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colBelgeYazan = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colBelgeUzantı = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colBelgeTaraf = new DevExpress.XtraGrid.Columns.GridColumn();

            #region Column Properties

            //
            //colId
            //
            colId.Caption = " ";
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            colId.Width = 25;
            colId.VisibleIndex = -1;
            colId.OptionsColumn.AllowEdit = false;
            //
            //colIsSelected
            //
            colIsSelected.Caption = "Seç";
            colIsSelected.FieldName = "IsSelected";
            colIsSelected.Name = "colIsSelected";
            colIsSelected.Visible = true;
            colIsSelected.Width = 20;
            colIsSelected.VisibleIndex = 0;
            colIsSelected.OptionsColumn.AllowEdit = true;
            //
            //colBelgeTur
            //
            colBelgeTur.Caption = "Belge Türü";
            colBelgeTur.ColumnEdit = rlueBelgeTur;
            colBelgeTur.FieldName = "BelgeTurId";
            colBelgeTur.Name = "colBelgeTur";
            colBelgeTur.Visible = true;
            colBelgeTur.VisibleIndex = 1;
            colBelgeTur.OptionsColumn.AllowEdit = false;
            //
            //colBelgeAd
            //
            colBelgeAd.Caption = "Belge Adı";
            colBelgeAd.FieldName = "BelgeAdi";
            colBelgeAd.Name = "colBelgeAd";
            colBelgeAd.Visible = true;
            colBelgeAd.VisibleIndex = 2;
            colBelgeAd.OptionsColumn.AllowEdit = false;
            //
            //colBelgeYazılmaT
            //
            colBelgeYazılmaT.Caption = "Yazılma T.";
            colBelgeYazılmaT.FieldName = "YazilmaTarihi";
            colBelgeYazılmaT.Name = "colBelgeYazılmaT";
            colBelgeYazılmaT.Visible = true;
            colBelgeYazılmaT.VisibleIndex = 3;
            colBelgeYazılmaT.OptionsColumn.AllowEdit = false;
            //
            //colBelgeYazan
            //
            colBelgeYazan.Caption = "Yazan";
            colBelgeYazan.ColumnEdit = rlueCari;
            colBelgeYazan.FieldName = "BelgeyiYazanId";
            colBelgeYazan.Name = "colBelgeYazan";
            colBelgeYazan.Visible = true;
            colBelgeYazan.VisibleIndex = 4;
            colBelgeYazan.OptionsColumn.AllowEdit = false;
            //
            //colBelgeUzantı
            //
            colBelgeUzantı.Caption = "Uzantı";
            colBelgeUzantı.FieldName = "DokumanUzanti";
            colBelgeUzantı.Name = "colBelgeUzantı";
            colBelgeUzantı.Visible = true;
            colBelgeUzantı.VisibleIndex = 5;
            colBelgeUzantı.OptionsColumn.AllowEdit = false;
            //
            //colBelgeTaraf
            //
            colBelgeTaraf.Caption = "Tarafı";
            colBelgeTaraf.ColumnEdit = rlueCari;
            colBelgeTaraf.FieldName = "BelgeTarafId";
            colBelgeTaraf.Name = "colBelgeTaraf";
            colBelgeTaraf.Visible = true;
            colBelgeTaraf.VisibleIndex = 6;
            colBelgeTaraf.OptionsColumn.AllowEdit = false;

            #endregion Column Properties

            #endregion Columns

            DevExpress.XtraGrid.Columns.GridColumn[] kolonlar = new[]
            {
                colId,
                colIsSelected,
                colBelgeTur,
                colBelgeAd,
                colBelgeYazılmaT,
                colBelgeYazan,
                colBelgeUzantı,
                colBelgeTaraf
            };

            return kolonlar;
        }

        private static DevExpress.XtraGrid.Columns.GridColumn[] CariColumns()
        {
            #region RepositoryItems

            //DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            //DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAltTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            #region Binds

            //BelgeUtil.Inits.perCariGetir(rlueCari);
            //BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            //BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
            //BelgeUtil.Inits.AdliBirimNoGetir(rlueNo);
            //BelgeUtil.Inits.TebligatAltTurGetir(rlueAltTur);

            #endregion Binds

            #endregion RepositoryItems

            #region Columns

            DevExpress.XtraGrid.Columns.GridColumn colId = new DevExpress.XtraGrid.Columns.GridColumn();
            //DevExpress.XtraGrid.Columns.GridColumn colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colMusteriNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colBabaAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colKizlikSoyadi = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDogumTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colEskiUnvani = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colVergiNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colTcKimlikNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colTel1 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colTel2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCep1 = new DevExpress.XtraGrid.Columns.GridColumn();
            //DevExpress.XtraGrid.Columns.GridColumn colCep2 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colEmail = new DevExpress.XtraGrid.Columns.GridColumn();

            #region Column Properties

            //
            //colId
            //
            colId.Caption = " ";
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            colId.Width = 25;
            colId.VisibleIndex = -1;
            colId.OptionsColumn.AllowEdit = false;
            //
            //colIsSelected
            //
            //colIsSelected.Caption = "Seç";
            //colIsSelected.FieldName = "IsSelected";
            //colIsSelected.Name = "colIsSelected";
            //colIsSelected.Visible = true;
            //colIsSelected.Width = 20;
            //colIsSelected.VisibleIndex = 0;
            //colIsSelected.OptionsColumn.AllowEdit = true;
            ////
            ////colKodu
            ////
            //colKodu.Caption = "Seç";
            //colKodu.FieldName = "IsSelected";
            //colKodu.Name = "colKodu";
            //colKodu.Visible = true;
            //colKodu.Width = 20;
            //colKodu.VisibleIndex = 0;
            //colKodu.OptionsColumn.AllowEdit = true;
            //
            //colAd
            //
            colAd.Caption = "Adı";
            colAd.FieldName = "Ad";
            colAd.Name = "colAd";
            colAd.Visible = true;
            colAd.Width = 250;
            colAd.VisibleIndex = 0;
            colAd.OptionsColumn.AllowEdit = false;
            //
            //colMusteriNo
            //
            colMusteriNo.Caption = "Müşteri No";
            colMusteriNo.FieldName = "MusteriNo";
            colMusteriNo.Name = "colMusteriNo";
            colMusteriNo.Visible = true;
            colMusteriNo.VisibleIndex = 1;
            colMusteriNo.OptionsColumn.AllowEdit = false;
            //
            //colBabaAdi
            //
            colBabaAdi.Caption = "Baba Adı";
            colBabaAdi.FieldName = "BabaAdi";
            colBabaAdi.Name = "colBabaAdi";
            colBabaAdi.Visible = true;
            colBabaAdi.VisibleIndex = 2;
            colBabaAdi.OptionsColumn.AllowEdit = false;
            //
            //colKizlikSoyadi
            //
            colKizlikSoyadi.Caption = "Kızlık Soyadı";
            colKizlikSoyadi.FieldName = "AnneKizlikSoyadi";
            colKizlikSoyadi.Name = "colKizlikSoyadi";
            colKizlikSoyadi.Visible = true;
            colKizlikSoyadi.VisibleIndex = 3;
            colKizlikSoyadi.OptionsColumn.AllowEdit = false;
            //
            //colDogumTarihi
            //
            colDogumTarihi.Caption = "Doğum Tarihi";
            colDogumTarihi.FieldName = "DogumTarihi";
            colDogumTarihi.Name = "colDogumTarihi";
            colDogumTarihi.Visible = true;
            colDogumTarihi.VisibleIndex = 4;
            colDogumTarihi.OptionsColumn.AllowEdit = false;
            //
            //colEskiUnvani
            //
            colEskiUnvani.Caption = "Eski Ünvanı";
            colEskiUnvani.FieldName = "EskiUnvan";
            colEskiUnvani.Name = "colEskiUnvani";
            colEskiUnvani.Visible = true;
            colEskiUnvani.VisibleIndex = 5;
            colEskiUnvani.OptionsColumn.AllowEdit = false;
            //
            //colVergiNo
            //
            colVergiNo.Caption = "Vergi No";
            colVergiNo.FieldName = "VergiNo";
            colVergiNo.Name = "colVergiNo";
            colVergiNo.Visible = true;
            colVergiNo.VisibleIndex = 6;
            colVergiNo.OptionsColumn.AllowEdit = false;
            //
            //colTcKimlikNo
            //
            colTcKimlikNo.Caption = "Tc Kimlik No";
            colTcKimlikNo.FieldName = "TcKimlikNo";
            colTcKimlikNo.Name = "colTcKimlikNo";
            colTcKimlikNo.Visible = true;
            colTcKimlikNo.VisibleIndex = 7;
            colTcKimlikNo.OptionsColumn.AllowEdit = false;
            //
            //colTel1
            //
            colTel1.Caption = "Tel 1";
            colTel1.FieldName = "Tel1";
            colTel1.Name = "colTel1";
            colTel1.Visible = true;
            colTel1.VisibleIndex = 8;
            colTel1.OptionsColumn.AllowEdit = false;
            //
            //colTel2
            //
            colTel2.Caption = "Tel 2";
            colTel2.FieldName = "Tel2";
            colTel2.Name = "colTel2";
            colTel2.Visible = true;
            colTel2.VisibleIndex = 9;
            colTel2.OptionsColumn.AllowEdit = false;
            //
            //colCep1
            //
            colCep1.Caption = "Cep Tel.";
            colCep1.FieldName = "CepTel";
            colCep1.Name = "colCep1";
            colCep1.Visible = true;
            colCep1.VisibleIndex = 10;
            colCep1.OptionsColumn.AllowEdit = false;
            ////
            ////colCep2
            ////
            //colCep2.Caption = "Cep 2";
            //colCep2.FieldName = "TarafAdi";
            //colCep2.Name = "colCep2";
            //colCep2.Visible = true;
            //colCep2.VisibleIndex = 10;
            //colCep2.OptionsColumn.AllowEdit = false;
            //
            //colEmail
            //
            colEmail.Caption = "Email";
            colEmail.FieldName = "Email1";
            colEmail.Name = "colEmail";
            colEmail.Visible = true;
            colEmail.VisibleIndex = 11;
            colEmail.OptionsColumn.AllowEdit = false;

            #endregion Column Properties

            #endregion Columns

            DevExpress.XtraGrid.Columns.GridColumn[] kolonlar = new[]
            {
                colId,
                //colIsSelected,
                colAd,
                colKodu,
                colMusteriNo,
                colBabaAdi,
                colKizlikSoyadi,
                colDogumTarihi,
                colEskiUnvani,
                colVergiNo,
                colTcKimlikNo,
                colTel1,
                colTel2,
                colCep1,
                colEmail
            };

            return kolonlar;
        }

        private static DevExpress.XtraGrid.Columns.GridColumn[] DavaNedenColumns()
        {
            #region Columns

            DevExpress.XtraGrid.Columns.GridColumn colId = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colAd = new DevExpress.XtraGrid.Columns.GridColumn();

            #region Column Properties

            //
            //colId
            //
            colId.Caption = " ";
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            colId.Width = 25;
            colId.VisibleIndex = -1;
            colId.OptionsColumn.AllowEdit = false;
            //
            //colAd
            //
            colAd.Caption = "Adı";
            colAd.FieldName = "DavaAdi";
            colAd.Name = "colAd";
            colAd.Visible = true;
            colAd.Width = 500;
            colAd.VisibleIndex = 0;
            colAd.OptionsColumn.AllowEdit = false;

            #endregion Column Properties

            #endregion Columns

            DevExpress.XtraGrid.Columns.GridColumn[] kolonlar = new[]
            {
                colId,
                colAd,
            };

            return kolonlar;
        }

        private static DevExpress.XtraGrid.Columns.GridColumn[] DosyaColumns(AvukatProLib.Extras.Modul modul)
        {
            #region RepositoryItems

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAltTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            #region Binds

            BelgeUtil.Inits.perCariGetir(rlueCari);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueNo);
            //BelgeUtil.Inits.tebligat
            BelgeUtil.Inits.TebligatAltTurGetir(rlueAltTur);

            #endregion Binds

            #endregion RepositoryItems

            #region Columns

            DevExpress.XtraGrid.Columns.GridColumn colDosyaId = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDosyaSec = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDosyaFoyNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDosyaAdliye = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDosyaNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDosyaGorev = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDosyaEsasNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDosyaTakipT = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colTakipEdilen = new DevExpress.XtraGrid.Columns.GridColumn();

            #region Column Properties

            //colDosyaId
            colDosyaId.Caption = "ID";
            colDosyaId.FieldName = "Id";
            colDosyaId.Name = "colDosyaId";
            colDosyaId.Visible = false;
            colDosyaId.Width = 30;
            colDosyaId.VisibleIndex = -1;
            colDosyaId.OptionsColumn.AllowEdit = false;

            //colDosyaSec
            colDosyaSec.Caption = "Seç";
            colDosyaSec.FieldName = "IsSelected";
            colDosyaSec.Name = "colDosyaSec";
            colDosyaSec.Visible = true;
            colDosyaSec.VisibleIndex = 0;
            colDosyaSec.OptionsColumn.AllowEdit = true;

            //colTakipEdilen
            colTakipEdilen.Caption = "Takip Edilen";
            colTakipEdilen.FieldName = "TarafAdi";
            colTakipEdilen.Name = "colTakipEdilen";
            colTakipEdilen.ColumnEdit = rlueCari;
            colTakipEdilen.Visible = true;
            colTakipEdilen.VisibleIndex = 1;
            colTakipEdilen.OptionsColumn.AllowEdit = false;

            //colDosyaFoyNo
            colDosyaFoyNo.Caption = "Dosya No";
            colDosyaFoyNo.FieldName = "DosyaNo";
            colDosyaFoyNo.Name = "colDosyaFoyNo";
            colDosyaFoyNo.Visible = true;
            colDosyaFoyNo.VisibleIndex = 2;
            colDosyaFoyNo.OptionsColumn.AllowEdit = false;

            //colDosyaAdliye
            colDosyaAdliye.Caption = "Adliye";
            colDosyaAdliye.FieldName = "Adliye";
            colDosyaAdliye.Name = "colDosyaAdliye";
            colDosyaAdliye.ColumnEdit = rlueAdliye;
            colDosyaAdliye.Visible = true;
            colDosyaAdliye.VisibleIndex = 3;
            colDosyaAdliye.OptionsColumn.AllowEdit = false;

            //colDosyaNo
            colDosyaNo.Caption = "No";
            colDosyaNo.FieldName = "No";
            colDosyaNo.Name = "colDosyaNo";
            colDosyaNo.ColumnEdit = rlueNo;
            colDosyaNo.Visible = true;
            colDosyaNo.VisibleIndex = 4;
            colDosyaNo.OptionsColumn.AllowEdit = false;

            //colDosyaGorev
            colDosyaGorev.Caption = "Görev";
            colDosyaGorev.FieldName = "Gorev";
            colDosyaGorev.Name = "colDosyaGorev";
            colDosyaGorev.ColumnEdit = rlueGorev;
            colDosyaGorev.Visible = true;
            colDosyaGorev.VisibleIndex = 5;
            colDosyaGorev.OptionsColumn.AllowEdit = false;

            //colDosyaEsasNo
            colDosyaEsasNo.Caption = "Esas No";
            colDosyaEsasNo.FieldName = "EsasNo";
            colDosyaEsasNo.Name = "colDosyaEsasNo";
            colDosyaEsasNo.Visible = true;
            colDosyaEsasNo.VisibleIndex = 6;
            colDosyaEsasNo.OptionsColumn.AllowEdit = false;

            //colDosyaTakipT
            colDosyaTakipT.Caption = "Takip T.";
            colDosyaTakipT.FieldName = "TakipT";
            colDosyaTakipT.Name = "colDosyaTakipT";
            colDosyaTakipT.Visible = true;
            colDosyaTakipT.VisibleIndex = 7;
            colDosyaTakipT.OptionsColumn.AllowEdit = false;

            #endregion Column Properties

            #endregion Columns

            DevExpress.XtraGrid.Columns.GridColumn[] kolonlar = new[]
            {
                colDosyaId,
                colDosyaSec,
                colTakipEdilen,
                colDosyaFoyNo,
                colDosyaAdliye,
                colDosyaNo,
                colDosyaGorev,
                colDosyaEsasNo,
                colDosyaTakipT
            };

            return kolonlar;
        }

        private static DevExpress.XtraGrid.Columns.GridColumn[] EvrakColumns()
        {
            #region RepositoryItems

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAdliye = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueGorev = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueNo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueDurum = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueAltTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            #region Binds

            BelgeUtil.Inits.perCariGetir(rlueCari);
            BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
            BelgeUtil.Inits.AdliBirimGorevGetir(rlueGorev);
            BelgeUtil.Inits.AdliBirimNoGetir(rlueNo);
            //BelgeUtil.Inits.tebligat
            BelgeUtil.Inits.TebligatAltTurGetir(rlueAltTur);

            #endregion Binds

            #endregion RepositoryItems

            #region Columns

            DevExpress.XtraGrid.Columns.GridColumn colId = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDosyaNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colAdliye = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colGorev = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colEsasNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colReferans1 = new DevExpress.XtraGrid.Columns.GridColumn();
            //DevExpress.XtraGrid.Columns.GridColumn colReferans2 = new DevExpress.XtraGrid.Columns.GridColumn();
            //DevExpress.XtraGrid.Columns.GridColumn colReferans3 = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colTarafAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colSifat = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colAltTurId = new DevExpress.XtraGrid.Columns.GridColumn();

            #region Column Properties

            //
            //colId
            //
            colId.Caption = " ";
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            colId.Width = 25;
            colId.VisibleIndex = -1;
            colId.OptionsColumn.AllowEdit = false;
            //
            //colIsSelected
            //
            colIsSelected.Caption = "Seç";
            colIsSelected.FieldName = "IsSelected";
            colIsSelected.Name = "colIsSelected";
            colIsSelected.Visible = true;
            colIsSelected.Width = 20;
            colIsSelected.VisibleIndex = 0;
            colIsSelected.OptionsColumn.AllowEdit = true;
            //
            //colDosyaNo
            //
            colDosyaNo.Caption = "Dosya No";
            colDosyaNo.FieldName = "DosyaNo";
            colDosyaNo.Name = "colDosyaNo";
            colDosyaNo.ColumnEdit = rlueCari;
            colDosyaNo.Visible = true;
            colDosyaNo.VisibleIndex = 1;
            colDosyaNo.OptionsColumn.AllowEdit = false;
            //
            //colAdliye
            //
            colAdliye.Caption = "Adliye";
            colAdliye.FieldName = "Adliye";
            colAdliye.Name = "colAdliye";
            colAdliye.ColumnEdit = rlueAdliye;
            colAdliye.Visible = true;
            colAdliye.VisibleIndex = 2;
            colAdliye.OptionsColumn.AllowEdit = false;
            //
            //colGorev
            //
            colGorev.Caption = "Görev";
            colGorev.FieldName = "Gorev";
            colGorev.Name = "colGorev";
            colGorev.ColumnEdit = rlueGorev;
            colGorev.Visible = true;
            colGorev.VisibleIndex = 3;
            colGorev.OptionsColumn.AllowEdit = false;
            //
            //colNo
            //
            colNo.Caption = "No";
            colNo.FieldName = "No";
            colNo.Name = "colNo";
            colNo.ColumnEdit = rlueNo;
            colNo.Visible = true;
            colNo.VisibleIndex = 4;
            colNo.OptionsColumn.AllowEdit = false;
            //
            //colEsasNo
            //
            colEsasNo.Caption = "Esas No";
            colEsasNo.FieldName = "EsasNo";
            colEsasNo.Name = "colEsasNo";
            colEsasNo.Visible = true;
            colEsasNo.VisibleIndex = 5;
            colEsasNo.OptionsColumn.AllowEdit = false;
            //
            //colReferans1
            //
            colReferans1.Caption = "Referans No";
            colReferans1.FieldName = "ReferansNo";
            colReferans1.Name = "colReferans1";
            colReferans1.Visible = true;
            colReferans1.VisibleIndex = 6;
            colReferans1.OptionsColumn.AllowEdit = false;
            ////
            ////colReferans2
            ////
            //colReferans2.Caption = "Referans 2";
            //colReferans2.FieldName = "Referans2";
            //colReferans2.Name = "colReferans2";
            //colReferans2.Visible = true;
            //colReferans2.VisibleIndex = 7;
            //colReferans2.OptionsColumn.AllowEdit = false;
            ////
            ////colReferans3
            ////
            //colReferans3.Caption = "Referans 3";
            //colReferans3.FieldName = "Referans3";
            //colReferans3.Name = "colReferans3";
            //colReferans3.Visible = true;
            //colReferans3.VisibleIndex = 8;
            //colReferans3.OptionsColumn.AllowEdit = false;
            //
            //colDurum
            //
            colDurum.Caption = "Durum";
            colDurum.FieldName = "Durum";
            colDurum.Name = "colDurum";
            colDurum.Visible = true;
            colDurum.VisibleIndex = 9;
            colDurum.OptionsColumn.AllowEdit = false;
            //
            //colTarafAdi
            //
            colTarafAdi.Caption = "Taraf Adı";
            colTarafAdi.FieldName = "TarafAdi";
            colTarafAdi.Name = "colTarafAdi";
            colTarafAdi.ColumnEdit = rlueCari;
            colTarafAdi.Visible = true;
            colTarafAdi.VisibleIndex = 10;
            colTarafAdi.OptionsColumn.AllowEdit = false;
            //
            //colSifat
            //
            colSifat.Caption = "Sıfat";
            colSifat.FieldName = "Sifat";
            colSifat.Name = "colSifat";
            colSifat.Visible = true;
            colSifat.VisibleIndex = 11;
            colSifat.OptionsColumn.AllowEdit = false;
            //
            //colAltTurId
            //
            colAltTurId.Caption = "Tür";
            colAltTurId.FieldName = "AltTurId";
            colAltTurId.Name = "colAltTurId";
            colAltTurId.ColumnEdit = rlueAltTur;
            colAltTurId.Visible = true;
            colAltTurId.VisibleIndex = 12;
            colAltTurId.OptionsColumn.AllowEdit = false;

            #endregion Column Properties

            #endregion Columns

            DevExpress.XtraGrid.Columns.GridColumn[] kolonlar = new[]
            {
                colId,
                colIsSelected,
                colDosyaNo,
                colAdliye,
                colGorev,
                colNo ,
                colEsasNo ,
                colReferans1 ,
                //colReferans2 ,
                //colReferans3 ,
                colDurum ,
                colTarafAdi ,
                colSifat ,
                colAltTurId
            };

            return kolonlar;
        }

        private static DevExpress.XtraGrid.Columns.GridColumn[] HesapBilgileriColumns()
        {
            #region RepositoryItems

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueBanka = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueSube = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueKartTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueHesapDovizTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            #region Binds

            BelgeUtil.Inits.perCariGetir(rlueCari);
            BelgeUtil.Inits.BankaGetir(rlueBanka);
            BelgeUtil.Inits.BankaSubeGetir(rlueSube);
            BelgeUtil.Inits.BankaKartTipiGetir(rlueKartTip);
            BelgeUtil.Inits.DovizTipGetir(rlueHesapDovizTip);

            #endregion Binds

            #endregion RepositoryItems

            #region Columns

            DevExpress.XtraGrid.Columns.GridColumn colId = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colAd = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colIBANNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colBanka = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colSube = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colHesapTur = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colHesapNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colKartNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colKartTipi = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colSKT = new DevExpress.XtraGrid.Columns.GridColumn();

            #region Column Properties

            //
            // colId
            //
            colId.Caption = "ID";
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            colId.VisibleIndex = -1;
            //
            // colAd
            //
            colAd.Caption = "Ad";
            colAd.ColumnEdit = rlueCari;
            colAd.FieldName = "CariId";
            colAd.Name = "colAd";
            colAd.Visible = true;
            colAd.VisibleIndex = 0;
            //
            // colIBANNo
            //
            colIBANNo.Caption = "IBAN No";
            colIBANNo.FieldName = "IbanNo";
            colIBANNo.Name = "colIBANNo";
            colIBANNo.Visible = true;
            colIBANNo.VisibleIndex = 1;
            //
            // colBanka
            //
            colBanka.Caption = "Banka";
            colBanka.ColumnEdit = rlueBanka;
            colBanka.FieldName = "BankaId";
            colBanka.Name = "colBanka";
            colBanka.Visible = true;
            colBanka.VisibleIndex = 2;
            //
            // colSube
            //
            colSube.Caption = "Şube";
            colSube.ColumnEdit = rlueSube;
            colSube.FieldName = "SubeId";
            colSube.Name = "colSube";
            colSube.Visible = true;
            colSube.VisibleIndex = 3;
            //
            // colHesapTur
            //
            colHesapTur.Caption = "Hesap Tür";
            colHesapTur.ColumnEdit = rlueHesapDovizTip;
            colHesapTur.FieldName = "DovizId";
            colHesapTur.Name = "colHesapTur";
            colHesapTur.Visible = true;
            colHesapTur.VisibleIndex = 4;
            //
            // colHesapNo
            //
            colHesapNo.Caption = "Hesap No";
            colHesapNo.FieldName = "HesapNo";
            colHesapNo.Name = "colHesapNo";
            colHesapNo.Visible = true;
            colHesapNo.VisibleIndex = 5;
            //
            // colKartNo
            //
            colKartNo.Caption = "Kart No";
            colKartNo.FieldName = "KART_NO";
            colKartNo.Name = "colKartNo";
            colKartNo.Visible = true;
            colKartNo.VisibleIndex = 6;
            //
            // colKartTipi
            //
            colKartTipi.Caption = "Kart Tipi";
            colKartTipi.ColumnEdit = rlueKartTip;
            colKartTipi.FieldName = "KartTipId";
            colKartTipi.Name = "colKartTipi";
            colKartTipi.Visible = true;
            colKartTipi.VisibleIndex = 7;
            //
            // colSKT
            //
            colSKT.Caption = "Kart SKT.";
            colSKT.FieldName = "SonKullanimTarihi";
            colSKT.Name = "colSKT";
            colSKT.Visible = true;
            colSKT.VisibleIndex = 8;

            #endregion Column Properties

            #endregion Columns

            DevExpress.XtraGrid.Columns.GridColumn[] kolonlar = new[]
            {
               colId,
               colAd,
               colIBANNo,
               colBanka,
               colSube,
               colHesapTur,
               colHesapNo,
               colKartNo,
               colKartTipi,
               colSKT
            };

            return kolonlar;
        }

        private static DevExpress.XtraGrid.Columns.GridColumn[] KiymetliEvrakColumns()
        {
            #region RepositoryItems

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCekEvrakTur = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCekDoviz = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCekBanka = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCekSube = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlueCekCariId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();

            #region Binds

            BelgeUtil.Inits.KiymetliEvrakTipiGetir(rlueCekEvrakTur);
            BelgeUtil.Inits.DovizTipGetir(rlueCekDoviz);
            BelgeUtil.Inits.BankaGetir(rlueCekBanka);
            BelgeUtil.Inits.BankaSubeGetir(rlueCekSube);
            BelgeUtil.Inits.perCariGetir(rlueCekCariId);

            #endregion Binds

            #endregion RepositoryItems

            #region Columns

            DevExpress.XtraGrid.Columns.GridColumn colCekEvrakTur = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCekVadeT = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCekTanzimT = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCekTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCekDovizId = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCekBanka = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCekSube = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCekNo = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCekKesideYeri = new DevExpress.XtraGrid.Columns.GridColumn();
            DevExpress.XtraGrid.Columns.GridColumn colCekTaraf = new DevExpress.XtraGrid.Columns.GridColumn();

            #region Column Properties

            //
            // colCekEvrakTur
            //
            colCekEvrakTur.Caption = "Türü";
            colCekEvrakTur.ColumnEdit = rlueCekEvrakTur;
            colCekEvrakTur.FieldName = "EvrakTurId";
            colCekEvrakTur.Name = "colCekEvrakTur";
            colCekEvrakTur.Visible = true;
            colCekEvrakTur.VisibleIndex = 0;
            //
            // colCekVadeT
            //
            colCekVadeT.Caption = "Vade T.";
            colCekVadeT.FieldName = "EvrakVadeTarihi";
            colCekVadeT.Name = "colCekVadeT";
            colCekVadeT.Visible = true;
            colCekVadeT.VisibleIndex = 1;
            //
            // colCekTanzimT
            //
            colCekTanzimT.Caption = "Tanzim T.";
            colCekTanzimT.FieldName = "EvrakTanzimTarihi";
            colCekTanzimT.Name = "colCekTanzimT";
            colCekTanzimT.Visible = true;
            colCekTanzimT.VisibleIndex = 2;
            //
            // colCekTutar
            //
            colCekTutar.Caption = "Tutar";
            colCekTutar.FieldName = "Tutar";
            colCekTutar.Name = "colCekTutar";
            colCekTutar.Visible = true;
            colCekTutar.VisibleIndex = 3;
            //
            // colCekDovizId
            //
            colCekDovizId.ColumnEdit = rlueCekDoviz;
            colCekDovizId.CustomizationCaption = "Tutar para birimi";
            colCekDovizId.FieldName = "TutarDovizId";
            colCekDovizId.Name = "colCekDovizId";
            colCekDovizId.Visible = true;
            colCekDovizId.VisibleIndex = 4;
            //
            // colCekBanka
            //
            colCekBanka.Caption = "Banka";
            colCekBanka.ColumnEdit = rlueCekBanka;
            colCekBanka.FieldName = "BankaId";
            colCekBanka.Name = "colCekBanka";
            colCekBanka.Visible = true;
            colCekBanka.VisibleIndex = 5;
            //
            // colCekSube
            //
            colCekSube.Caption = "Şube";
            colCekSube.ColumnEdit = rlueCekSube;
            colCekSube.FieldName = "SubeId";
            colCekSube.Name = "colCekSube";
            colCekSube.Visible = true;
            colCekSube.VisibleIndex = 6;
            //
            // colCekNo
            //
            colCekNo.Caption = "Çek No";
            colCekNo.FieldName = "CekNo";
            colCekNo.Name = "colCekNo";
            colCekNo.Visible = true;
            colCekNo.VisibleIndex = 7;
            //
            // colCekKesideYeri
            //
            colCekKesideYeri.Caption = "Keşide Yeri";
            colCekKesideYeri.FieldName = "KesideYeri";
            colCekKesideYeri.Name = "colCekKesideYeri";
            colCekKesideYeri.Visible = true;
            colCekKesideYeri.VisibleIndex = 8;
            //
            // colCekTaraf
            //
            colCekTaraf.Caption = "Tarafı";
            colCekTaraf.ColumnEdit = rlueCekCariId;
            colCekTaraf.FieldName = "TarafCariId";
            colCekTaraf.Name = "colCekTaraf";
            colCekTaraf.Visible = true;
            colCekTaraf.VisibleIndex = 9;

            #endregion Column Properties

            #endregion Columns

            DevExpress.XtraGrid.Columns.GridColumn[] kolonlar = new[]
            {
                colCekEvrakTur,
                colCekVadeT ,
                colCekTanzimT ,
                colCekTutar ,
                colCekDovizId ,
                colCekBanka ,
                colCekSube,
                colCekNo ,
                colCekKesideYeri ,
                colCekTaraf
            };

            return kolonlar;
        }

        #endregion Columns
    }
}