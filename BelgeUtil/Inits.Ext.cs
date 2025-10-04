//using AvukatPro.Services.Implementations;
using AvukatProLib;
using AvukatProLib.Extras;
using AvukatProLib2.Data;

//using AvukatProLib.Hesap;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraVerticalGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace BelgeUtil
{
    public partial class Inits
    {
        public static VList<per_TD_KOD_ARA_KARAR_TIP> _AraKararKodTipGetir;
        public static List<AvukatProLib.Arama.VDI_KOD_BANKA_SUBE> _BankaSubeGetir;

        public static VList<per_TD_KOD_DAVA_TALEP> _DavaTalepGetir;

        public static VList<per_TD_KOD_MAHKEME_HUKUM> _HukumGetir;

        ///<summary>
        ///TDIE_KOD_PROJE_OZEL_KOD
        ///</summary>
        ///<param name="lue"></param>
        public static VList<per_TDIE_KOD_PROJE_OZEL_KOD> _ProjeOzelKodGetir;

        ///<summary>
        ///TDIE_KOD_PROJE_TIP
        ///</summary>
        ///<param name="lue"></param>
        public static VList<per_TDIE_KOD_PROJE_TIP> _ProjeTipGetir;

        ///<summary>
        ///TI_KOD_ALACAK_NEDEN
        ///</summary>
        ///<param name="lue"></param>

        //TDI_KOD_ARAC_TIP
        private static VList<per_TDI_KOD_ARAC_TIP> _AracTipGetir;

        ///<summary>
        /// TDI_KOD_BASIM_EVI
        /// </summary>
        /// <param name="rlue"></param>
        private static VList<per_TDI_KOD_BASIM_EVI> _BasimEviGetir;

        //
        /// <summary>
        /// AV001_TDIE_KOD_BELGE_DOLASIM_ISLEM
        /// </summary>
        /// <param name="lue"></param>
        private static VList<per_AV001_TDIE_KOD_BELGE_DOLASIM_ISLEM> _BelgeDolasimIslemGetir;

        /// <summary>
        /// AV001_TDI_BIL_CARI (ADLI_PERSONEL_MI=TRUE)
        /// </summary>
        /// <param name="lue"></param>
        private static VList<per_AV001_TDI_BIL_CARI> _CariAdliPersonelGetir;

        private static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> _CariMuvekkilGetir;

        private static VList<per_AV001_TDI_BIL_CARI> _CariPersonelGetir;

        private static VList<per_TD_KOD_DAVA_TALEP> _DavaTakipKonusuGetir;

        //TDI_KOD_FIRMA_BOLGE
        private static VList<per_TDI_KOD_FIRMA_BOLGE> _FirmaBolgeGetir;

        private static VList<per_AV001_TI_KOD_HESAP_TIP> _HesapTipiGetir;

        private static TList<AV001_TD_BIL_CELSE> _HukumCelseGetir = null;

        private static VList<per_TD_KOD_MAHKEME_HUKUM_TIP> _HukumTipGetir;

        ///<summary>
        /// TI_KOD_ITIRAZ_GIDERILME_YOLU
        /// </summary>
        /// <param name="rlue"></param>
        private static VList<per_TI_KOD_ITIRAZ_GIDERILME_YOLU> _ItirazGiderilmeYol;

        //TDI_KOD_KDV
        private static VList<per_TDI_KOD_KDV> _KdvKodGetir;

        private static TList<AV001_TDI_BIL_CARI> _KontrolKimCari = new TList<AV001_TDI_BIL_CARI>();

        /// <summary>
        /// TDI_BIL_KULLANICI_LISTESI
        /// </summary>
        /// <param name="lue">Kullanýcýlarý getiren metot</param>
        private static TList<TDI_BIL_KULLANICI_LISTESI> _KontrolKimGetir;

        private static TList<TDI_BIL_KULLANICI_LISTESI> _KontrolKimGetirCari;

        private static VList<per_TDI_KOD_FOY_IADE_NEDEN> _MahkemeIadeNedeniGetir;

        private static VList<per_TDIE_KOD_MESAJ_TIP> _MesajTipGetir;

        ///<summary>
        /// TDI_KOD_MEVZUAT
        /// </summary>
        /// <param name="rlue"></param>
        private static VList<per_TDI_KOD_MEVZUAT> _MevzuatGetirForKutuphane;

        //TI_KOD_HARC_NISPI
        private static TList<TI_KOD_HARC_NISPI> _NispiHarcGetir;

        ///<summary>
        ///TDIE_KOD_PROJE_DURUM
        ///</summary>
        ///<param name="lue"></param>
        private static VList<per_TDIE_KOD_PROJE_DURUM> _ProjeDurumGetir;

        private static VList<per_AV001_TDI_BIL_CARI> _SorumluAvukatGetir;

        /// <summary>
        /// TDIE_BIL_KULLANICI_SUBELERI
        /// </summary>
        /// <param name="lue">Þubeleri getiren metot</param>
        private static TList<TDIE_BIL_KULLANICI_SUBELERI> _SubeKodGetir;

        ///<summary>
        /// TDIE_KOD_TARAF_SIFAT
        /// </summary>
        /// <param name="rlue"></param>
        private static List<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT> _TarafSifatGetir;

        /// <summary>
        /// TDI_KOD_TEMINAT_MEKTUP_DURUM
        /// </summary>
        /// <param name="lue"></param>
        private static TList<TDI_KOD_TEMINAT_MEKTUP_DURUM> _TeminatMektupDurumGetir;

        //
        /// <summary>
        /// TDI_KOD_TEMINAT_MEKTUP_KONU
        /// </summary>
        /// <param name="lue"></param>
        private static VList<per_TDI_KOD_TEMINAT_MEKTUP_KONU> _TeminatMektupKonuGetir;

        //
        /// <summary>
        /// TDI_KOD_TEMINAT_MEKTUP_TARAF_TIP
        /// </summary>
        /// <param name="lue"></param>
        private static VList<per_TDI_KOD_TEMINAT_MEKTUP_TARAF_TIP> _TeminatMektupTarafTipGetir;

        //
        /// <summary>
        /// TI_KOD_TEMINAT_TIP
        /// </summary>
        /// <param name="lue"></param>
        private static VList<per_TI_KOD_TEMINAT_TIP> _TeminatTipGetir;

        ///<summary>
        /// TDI_KOD_YAZAR
        /// </summary>
        /// <param name="rlue"></param>
        private static VList<per_TDI_KOD_YAZAR> _YazarGetir;

        //TDI_KOD_YEVMIYE
        private static VList<per_TDI_KOD_YEVMIYE> _YevmiyeKodGetir;

        public static void AlacakNedenKodGetir(RepositoryItemLookUpEdit lue)
        {
            AlacakNedenKodGetir_Enter(lue, EventArgs.Empty);
        }

        /// <summary>
        /// TI_KOD_ALACAK_NEDEN
        /// </summary>
        /// <param name="lue"></param>
        /// <param name="takipsizAlacakMi"></param>
        public static void AlacakNedenKodGetir(RepositoryItemLookUpEdit lue, bool takipsizAlacakMi)
        {
            if (takipsizAlacakMi)
            {
                lue.DataSource = DataRepository.per_TI_KOD_ALACAK_NEDENProvider.GetDistinctByAlacakNeden();

                //AvukatProLib2.Data.Bases.per_TI_KOD_ALACAK_NEDENProviderBase.Fiil(DataRepository.Provider.ExecuteReader(CommandType.StoredProcedure, "_per_TI_KOD_ALACAK_NEDEN_GetDistinctByAlacakNeden"), new VList<per_TI_KOD_ALACAK_NEDEN>(), 0, 1000);
                lue.NullText = "Seç";
                lue.DisplayMember = "ALACAK_NEDENI";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Neden", 100));
            }
            else
            {
                AlacakNedenKodGetir(lue);
            }
        }

        /// <summary>
        /// Foy Dosyasý Uzerinde Bulunan AlacakNedenlerini Getirir.
        /// </summary>
        /// <param name="formTipi"></param>
        /// <param name="rlue"></param>
        public static void AlacakNedenKodGetir(FormTipleri formTipi, RepositoryItemLookUpEdit rlue, AV001_TI_BIL_FOY MyFoy)
        {
            List<per_TI_KOD_ALACAK_NEDEN> alacakNedenList = null;

            if (_TI_KOD_AlacakNedeniDoldur != null)
                alacakNedenList = _TI_KOD_AlacakNedeniDoldur == null ? DataRepository.per_TI_KOD_ALACAK_NEDENProvider.Get("FORM_TIP_ID = " + MyFoy.FORM_TIP_ID, "").ToList() : _TI_KOD_AlacakNedeniDoldur.Where(vi => vi.FORM_TIP_ID == MyFoy.FORM_TIP_ID).ToList();
            rlue.DataSource = alacakNedenList;
            rlue.NullText = "Seç";
            rlue.DisplayMember = "ALACAK_NEDENI";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Nedeni", 40));
        }

        public static void AracTipGetir(RepositoryItemLookUpEdit lue)
        {//çalýþýyor
            if (_AracTipGetir == null)
            {
                _AracTipGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_ARAC_TIPProvider.GetAll();
            }
            lue.DataSource = _AracTipGetir;
            lue.DisplayMember = "TIP";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TIP", 20, "Araç Tip"), });
        }

        public static void AraKararKodTipGetir(RepositoryItemLookUpEdit lue)
        {
            if (_AraKararKodTipGetir == null)
            {
                _AraKararKodTipGetir = DataRepository.per_TD_KOD_ARA_KARAR_TIPProvider.GetAll();
            }
            lue.DataSource = _AraKararKodTipGetir;
            lue.DisplayMember = "ARA_KARAR_TIP";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ARA_KARAR_TIP", 30, "Ara Karar Tipi"));
        }

        /// <summary>
        /// TD_KOD_ARA_KARAR_TIP
        /// </summary>
        /// <param name="lue"></param>
        ///
        public static void AraKararKodTipGetirRefresh()
        {
            _AraKararKodTipGetir = DataRepository.per_TD_KOD_ARA_KARAR_TIPProvider.GetAll();
        }

        public static void AraKararTipGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("AraKararTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.AraKararTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.AraKararTip)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ara Karar Tipi"));
        }

        public static void BankaSubeGetir(RepositoryItemLookUpEdit lue)
        {//çalýþýyor
            if (_BankaSubeGetir == null)
            {
                _BankaSubeGetir = context.VDI_KOD_BANKA_SUBEs.ToList();
            }
            lue.DataSource = _BankaSubeGetir;
            lue.DisplayMember = "SUBE";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SUBE", 20, "Sube"), new LookUpColumnInfo("BOLGE", 20, "Bölge"), });
        }

        public static void BasimEviGetir(RepositoryItemLookUpEdit rlue)
        {
            if (_BasimEviGetir == null)
            {
                _BasimEviGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_BASIM_EVIProvider.GetAll();
            }
            rlue.DataSource = _BasimEviGetir;
            rlue.NullText = "Seç";
            rlue.DisplayMember = "BASIM_EVI";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("BASIM_EVI", "Basým Evi", 100));
        }

        public static void BasimEviGetir(LookUpEdit lue)
        {
            BasimEviGetir(lue.Properties);
        }

        public static void BelgeDolasimIslemGetir(RepositoryItemLookUpEdit lue)
        {
            if (_BelgeDolasimIslemGetir == null)
            {
                _BelgeDolasimIslemGetir = AvukatProLib2.Data.DataRepository.per_AV001_TDIE_KOD_BELGE_DOLASIM_ISLEMProvider.GetAll();
            }
            lue.DataSource = _BelgeDolasimIslemGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "ISLEM";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ISLEM", "Belge Dolasim Ýþlem", 100));
        }

        public static void BicimKosuluGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("AraKararTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");

            foreach (DevExpress.XtraGrid.FormatConditionEnum tipi in Enum.GetValues(typeof(DevExpress.XtraGrid.FormatConditionEnum)))
            {
                switch (tipi)
                {
                    case FormatConditionEnum.None:
                        dt.Rows.Add(tipi, "Yok");
                        break;

                    case FormatConditionEnum.Equal:
                        dt.Rows.Add(tipi, "Eþit");
                        break;

                    case FormatConditionEnum.NotEqual:
                        dt.Rows.Add(tipi, "Eþit deðil");
                        break;

                    case FormatConditionEnum.Between:
                        dt.Rows.Add(tipi, "Arasýnda");
                        break;

                    case FormatConditionEnum.NotBetween:
                        dt.Rows.Add(tipi, "Arasýnda deðil");
                        break;

                    case FormatConditionEnum.Less:
                        dt.Rows.Add(tipi, "Küçüktür");
                        break;

                    case FormatConditionEnum.Greater:
                        dt.Rows.Add(tipi, "Büyüktür");
                        break;

                    case FormatConditionEnum.GreaterOrEqual:
                        dt.Rows.Add(tipi, "Büyük yada eþittir");
                        break;

                    case FormatConditionEnum.LessOrEqual:
                        dt.Rows.Add(tipi, "Küçük yada eþittir");

                        break;
                }
            }

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Geçiþ Yönü"));
        }

        public static void BirYilKacGGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("BirYilKacGun");
            dt.Columns.Add("GUN");

            dt.Rows.Add(360);
            dt.Rows.Add(365);

            lue.DataSource = dt;
            lue.DisplayMember = "GUN";
            lue.NullText = "Seç";
            lue.ValueMember = "GUN";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("GUN", 30, "Gün"));
        }

        public static void BirYilKacGGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            lue.Enter += new EventHandler(BirYilKacGGetir_Enter);
            BirYilKacGGetir_Enter(lue, new EventArgs());
        }

        public static void CariAdliPersonelGetir(RepositoryItemLookUpEdit lue)
        {
            if (lue.DataSource == null)
            {
                if (_CariAdliPersonelGetir == null || _CariAdliPersonelGetir.Count == 0)
                {
                    _CariAdliPersonelGetir = AvukatProLib2.Data.DataRepository.per_AV001_TDI_BIL_CARIProvider.Get("ADLI_PERSONEL_MI='True'", "AD DESC");
                }
                VList<per_AV001_TDI_BIL_CARI> listem = _CariAdliPersonelGetir;

                //Find("ADLI_PERSONEL_MI='True'");
                listem.Sort("AD ASC");
                lue.DataSource = listem;
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
            }
        }

        public static void CariAdliPersonelGetir(LookUpEdit lue)
        {
            CariAdliPersonelGetir(lue.Properties);
        }

        public static List<AvukatProLib.Arama.per_AV001_TDI_BIL_CARI> CariMuvekkilGetir()
        {
            if (_per_CariGetir != null)
            {
                _CariMuvekkilGetir = _per_CariGetir.Where(item => item.MUVEKKIL_MI).OrderByDescending(item => item.AD).ToList();
            }
            else
                _CariMuvekkilGetir = BelgeUtil.Inits.context.per_AV001_TDI_BIL_CARIs.Where(item => item.MUVEKKIL_MI).OrderByDescending(item => item.AD).ToList();
            return _CariMuvekkilGetir;
        }

        public static void CariMuvekkilGetir(LookUpEdit[] lues)
        {
            foreach (LookUpEdit lue in lues)
            {
                lue.Properties.DataSource = null;
                lue.Properties.DataSource = CariMuvekkilGetir();
                lue.Properties.ValueMember = "ID";
                lue.Properties.DisplayMember = "AD";
                LookUpColumnInfo Muvekkil = new LookUpColumnInfo("AD", 30, "Müvekkil");
                lue.Properties.NullText = "Seç";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { Muvekkil });
            }
        }

        public static void CariMuvekkilGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = null;
            rlue.DataSource = CariMuvekkilGetir();
            rlue.ValueMember = "ID";
            rlue.DisplayMember = "AD";
            rlue.NullText = "Seç";
            rlue.Columns.Clear();
            rlue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
        }

        public static void CariMuvekkilGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = null;
            lue.Properties.DataSource = CariMuvekkilGetir();
            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "AD";
            lue.Properties.NullText = "Seç";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
        }

        public static void CariPersonelGetir(RepositoryItemLookUpEdit lue)
        {
            if (lue.DataSource == null)
            {
                if (_CariPersonelGetir == null)
                {
                    _CariPersonelGetir = AvukatProLib2.Data.DataRepository.per_AV001_TDI_BIL_CARIProvider.Get("PERSONEL_MI='TRUE'", "AD DESC");
                }

                VList<per_AV001_TDI_BIL_CARI> listem = _CariPersonelGetir;

                //Find("PERSONEL_MI='True'");
                listem.Sort("AD ASC");
                lue.DataSource = listem;
                lue.NullText = "Seç";
                lue.DisplayMember = "AD";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
            }
        }

        public static void CariPersonelGetir(LookUpEdit lue)
        {
            CariPersonelGetir(lue.Properties);
        }

        /// <summary>
        /// AV001_TDI_BIL_CARI (PERSONEL_MI=TRUE)
        /// </summary>
        /// <param name="lue"></param>
        public static void CariPersonelGuncelle()
        {
            _CariPersonelGetir = AvukatProLib2.Data.DataRepository.per_AV001_TDI_BIL_CARIProvider.Get("PERSONEL_MI='TRUE'", "AD DESC");
        }

        ///<summary>
        ///
        ///</summary>
        ///<param name="lue"></param>
        ///<typeparam name="T"></typeparam>
        ///<returns></returns>
        public static TList<T> DataSo<T>(RepositoryItemLookUpEdit lue) where T : IEntity, new()
        {
            return (TList<T>)lue.DataSource;
        }

        public static VList<T> DataSov<T>(RepositoryItemLookUpEdit lue) where T : IEntity, new()
        {
            return (VList<T>)lue.DataSource;
        }

        /// <summary>
        /// Dava dosyasý üzerindeki dava eden taraflarý döndürür.
        /// </summary>
        /// <param name="MyFoy">AV001_TD_BIL_FOY</param>
        /// <returns>TList<AV001_TD_BIL_FOY_TARAF></returns>
        public static TList<AV001_TD_BIL_FOY_TARAF> DavaEdenTarafGetir(AV001_TD_BIL_FOY MyFoy)
        {
            TList<AV001_TD_BIL_FOY_TARAF> result = new TList<AV001_TD_BIL_FOY_TARAF>();

            foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (taraf.CARI_IDSource == null)
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(taraf, false,
                        DeepLoadType.IncludeChildren,
                        typeof(AV001_TDI_BIL_CARI),
                        typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));

                if (taraf.TARAF_KODU == (int)DavaTarafKodu.Davacý)
                    result.Add(taraf);
            }

            return result;
        }

        /// <summary>
        /// RepositoryItemLookUp Edit'e DavaEdenleri Doldurur.
        /// </summary>
        /// <param name="MyFoy">AV001_TD_BIL_FOY</param>
        /// <param name="rLue">RepositoryItemLookUpEdit</param>
        public static void DavaEdenTarafGetir(AV001_TD_BIL_FOY MyFoy, RepositoryItemLookUpEdit[] rLue)
        {
            TList<AV001_TDI_BIL_CARI> result = new TList<AV001_TDI_BIL_CARI>();

            foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (taraf.CARI_IDSource == null)
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(taraf, false,
                        DeepLoadType.IncludeChildren,
                        typeof(AV001_TDI_BIL_CARI),
                        typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));

                if (taraf.TARAF_KODU == (int)DavaTarafKodu.Davacý)
                    result.Add(taraf.CARI_IDSource);
            }

            foreach (RepositoryItemLookUpEdit c in rLue)
            {
                c.DataSource = result;
                c.DisplayMember = "AD";
                c.ValueMember = "ID";
                c.NullText = "Seç";
                c.Columns.Clear();
                c.Columns.AddRange(new LookUpColumnInfo[]
                {
                    new LookUpColumnInfo ("AD",30,"Taraf"),new LookUpColumnInfo ("KOD",10,"Kod")
                });
            }
        }

        /// <summary>
        /// RepositoryItemLookUp Edit'e DavaEdilenleri Doldurur.
        /// </summary>
        /// <param name="MyFoy">AV001_TD_BIL_FOY</param>
        /// <param name="rLue">RepositoryItemLookUpEdit</param>
        public static void DavaEdilenTarafGetir(AV001_TD_BIL_FOY MyFoy, RepositoryItemLookUpEdit[] rLue)
        {
            TList<AV001_TDI_BIL_CARI> result = new TList<AV001_TDI_BIL_CARI>();
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>));
            foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (taraf.CARI_IDSource == null)
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(taraf, false,
                        DeepLoadType.IncludeChildren,
                        typeof(AV001_TDI_BIL_CARI),
                        typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));

                if (taraf.TARAF_KODU == (int)DavaTarafKodu.Davalý)
                    result.Add(taraf.CARI_IDSource);
            }

            foreach (RepositoryItemLookUpEdit c in rLue)
            {
                c.DataSource = result;
                c.DisplayMember = "AD";
                c.ValueMember = "ID";
                c.NullText = "Seç";
                c.Columns.Clear();
                c.Columns.AddRange(new LookUpColumnInfo[]
                {
                    new LookUpColumnInfo ("AD",30,"Taraf"),new LookUpColumnInfo ("KOD",10,"Kod")
                });
            }
        }

        /// <summary>
        /// Dava dosyasý üzerindeki dava edilen taraflarý döndürür.
        /// </summary>
        /// <param name="MyFoy">AV001_TD_BIL_FOY</param>
        /// <returns>TList<AV001_TD_BIL_FOY_TARAF></returns>
        public static TList<AV001_TD_BIL_FOY_TARAF> DavaEdilenTarafGetir(AV001_TD_BIL_FOY MyFoy)
        {
            TList<AV001_TD_BIL_FOY_TARAF> result = new TList<AV001_TD_BIL_FOY_TARAF>();

            foreach (AV001_TD_BIL_FOY_TARAF taraf in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (taraf.CARI_IDSource == null)
                    DataRepository.AV001_TD_BIL_FOY_TARAFProvider.DeepLoad(taraf, false,
                        DeepLoadType.IncludeChildren,
                        typeof(AV001_TDI_BIL_CARI),
                        typeof(TList<AV001_TDI_BIL_CARI_KIMLIK>));

                if (taraf.TARAF_KODU == (int)DavaTarafKodu.Davalý)
                    result.Add(taraf);
            }

            return result;
        }

        /// <summary>
        /// Dava dosyasý üzerindeki dava nedenlerini doldurur.
        /// </summary>
        /// <param name="MyFoy">AV001_TD_BIL_FOY</param>
        /// <param name="glue">GridLookUpEdit</param>
        public static TList<AV001_TD_BIL_DAVA_NEDEN> DavaNedenGetir(AV001_TD_BIL_FOY MyFoy,
            RepositoryItemGridLookUpEdit glue)
        {
            try
            {
                if (glue != null)
                {
                    glue.BeginUpdate();
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false,
                        DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));
                    DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.DeepLoad(MyFoy.AV001_TD_BIL_DAVA_NEDENCollection, false,
                        DeepLoadType.IncludeChildren, typeof(TDI_KOD_DAVA_ADI));

                    glue.DataSource = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection;
                    glue.ValueMember = "ID";
                    glue.DisplayMember = "TDI_KOD_DAVA_ADI_IDSource";
                    glue.NullText = "Seç";

                    glue.EndUpdate();
                }
            }

            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Logger.Error("Hata", ex);
            }

            return MyFoy.AV001_TD_BIL_DAVA_NEDENCollection;
        }

        /// <summary>
        /// GridView üzerindeki DAVA_NEDEN_ID alanýna dosyadaki dava nedenlerini
        /// RepositortyItemGridLookUpEdit olarak basar.
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <param name="MyFoy">AV001_TD_BIL_FOY</param>
        public static void DavaNedenGetir(GridView gridView, AV001_TD_BIL_FOY MyFoy)
        {
            #region Controller Oluþturuluyor

            RepositoryItemGridLookUpEdit glk = new RepositoryItemGridLookUpEdit();
            RepositoryItemLookUpEdit lkDavaAdi = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit lkDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemSpinEdit tutar = new RepositoryItemSpinEdit();

            try
            {
                Inits.DavaAdiGetir(lkDavaAdi);
                Inits.DovizTipGetir(lkDoviz);
                Inits.ParaBicimiAyarla(tutar);

                glk.View.Columns.Clear();

                GridColumn col1 = new GridColumn();
                col1.FieldName = "DAVA_NEDEN_KOD_ID";
                col1.Caption = "Dava Nedeni";
                col1.ColumnEdit = lkDavaAdi;
                col1.Visible = true;
                col1.VisibleIndex = 0;
                glk.View.Columns.Add(col1);

                GridColumn col2 = new GridColumn();
                col2.FieldName = "DIGER_DAVA_NEDEN";
                col2.Caption = "Diðer Dava Nedeni";
                col2.Visible = true;
                col2.VisibleIndex = 1;
                glk.View.Columns.Add(col2);

                GridColumn col3 = new GridColumn();
                col3.FieldName = "DUZENLEME_TARIHI";
                col3.Caption = "Düzenlenme T";
                col3.Visible = true;
                col3.VisibleIndex = 2;
                glk.View.Columns.Add(col3);

                GridColumn col4 = new GridColumn();
                col4.FieldName = "TUTAR_DOVIZ_ID";
                col4.Caption = string.Empty;
                col4.ColumnEdit = lkDoviz;
                col4.Visible = true;
                col4.VisibleIndex = 3;
                glk.View.Columns.Add(col4);

                GridColumn col5 = new GridColumn();
                col5.FieldName = "TUTAR";
                col5.Caption = "Tutar";
                col5.ColumnEdit = tutar;
                col5.Visible = true;
                col5.VisibleIndex = 4;
                glk.View.Columns.Add(col5);

                gridView.Columns["DAVA_NEDEN_ID"].ColumnEdit = glk;
            }
            catch (Exception ex) {
                BelgeUtil.ErrorHandler.Catch(typeof(Inits), ex);
            }

            #endregion Controller Oluþturuluyor

            #region Dosyadan Dava Nedenleri Dolduruluyor

            try
            {
                glk.BeginUpdate();

                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.
                    DeepLoad(MyFoy.AV001_TD_BIL_DAVA_NEDENCollection, false,
                    DeepLoadType.IncludeChildren, typeof(TDI_KOD_DAVA_ADI));
                if (MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));
                glk.DataSource = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection;
                glk.ValueMember = "ID";
                glk.DisplayMember = "DAVA_NEDEN_KOD_IDSource";
                glk.NullText = "Seç";

                glk.EndUpdate();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(typeof(Inits), ex);
            }

            #endregion Dosyadan Dava Nedenleri Dolduruluyor
        }

        /// <summary>
        /// VGridControl üzerindeki DAVA_NEDEN_ID alanýna dosyadaki dava nedenlerini
        /// RepositortyItemGridLookUpEdit olarak basar.
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <param name="MyFoy">AV001_TD_BIL_FOY</param>
        public static void DavaNedenGetir(VGridControl vGridControl, AV001_TD_BIL_FOY MyFoy)
        {
            RepositoryItemGridLookUpEdit glk = new RepositoryItemGridLookUpEdit();
            RepositoryItemLookUpEdit lkDavaAdi = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit lkDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemSpinEdit tutar = new RepositoryItemSpinEdit();

            #region Controller Oluþturuluyor

            try
            {
                Inits.DavaAdiGetir(lkDavaAdi);
                Inits.DovizTipGetir(lkDoviz);
                Inits.ParaBicimiAyarla(tutar);

                glk.View.Columns.Clear();

                GridColumn col1 = new GridColumn();
                col1.FieldName = "DAVA_NEDEN_KOD_ID";
                col1.Caption = "Dava Nedeni";
                col1.ColumnEdit = lkDavaAdi;
                col1.Visible = true;
                col1.VisibleIndex = 0;
                glk.View.Columns.Add(col1);

                GridColumn col2 = new GridColumn();
                col2.FieldName = "DIGER_DAVA_NEDEN";
                col2.Caption = "Diðer Dava Nedeni";
                col2.Visible = true;
                col2.VisibleIndex = 1;
                glk.View.Columns.Add(col2);

                GridColumn col3 = new GridColumn();
                col3.FieldName = "DUZENLEME_TARIHI";
                col3.Caption = "Düzenlenme T";
                col3.Visible = true;
                col3.VisibleIndex = 2;
                glk.View.Columns.Add(col3);

                GridColumn col4 = new GridColumn();
                col4.FieldName = "TUTAR_DOVIZ_ID";
                col4.Caption = string.Empty;
                col4.ColumnEdit = lkDoviz;
                col4.Visible = true;
                col4.VisibleIndex = 3;
                glk.View.Columns.Add(col4);

                GridColumn col5 = new GridColumn();
                col5.FieldName = "TUTAR";
                col5.Caption = "Tutar";
                col5.ColumnEdit = tutar;
                col5.Visible = true;
                col5.VisibleIndex = 4;
                glk.View.Columns.Add(col5);

                vGridControl.GetRowByFieldName("DAVA_NEDEN_ID").Properties.RowEdit = glk;
            }
            catch (Exception ex) { BelgeUtil.ErrorHandler.Catch(typeof(Inits), ex); }

            #endregion Controller Oluþturuluyor

            #region Dosyadan Dava Nedenleri Dolduruluyor

            try
            {
                glk.BeginUpdate();
                if (MyFoy.AV001_TD_BIL_DAVA_NEDENCollection.Count == 0)
                    DataRepository.AV001_TD_BIL_FOYProvider.
                    DeepLoad(MyFoy, false,
                    DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_DAVA_NEDEN>));
                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.
                    DeepLoad(MyFoy.AV001_TD_BIL_DAVA_NEDENCollection, false,
                    DeepLoadType.IncludeChildren, typeof(TDI_KOD_DAVA_ADI));

                glk.DataSource = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection;
                glk.ValueMember = "ID";
                glk.DisplayMember = string.Empty;
                glk.NullText = "Seç";

                glk.EndUpdate();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(typeof(Inits), ex);
            }

            #endregion Dosyadan Dava Nedenleri Dolduruluyor
        }

        public static void DavaNedenGetir(LayoutView lw, AV001_TD_BIL_FOY MyFoy)
        {
            RepositoryItemGridLookUpEdit glk = new RepositoryItemGridLookUpEdit();
            RepositoryItemLookUpEdit lkDavaAdi = new RepositoryItemLookUpEdit();
            RepositoryItemLookUpEdit lkDoviz = new RepositoryItemLookUpEdit();
            RepositoryItemSpinEdit tutar = new RepositoryItemSpinEdit();

            #region Controller Oluþturuluyor

            try
            {
                Inits.DavaAdiGetir(lkDavaAdi);
                Inits.DovizTipGetir(lkDoviz);
                Inits.ParaBicimiAyarla(tutar);

                glk.View.Columns.Clear();

                GridColumn col1 = new GridColumn();
                col1.FieldName = "DAVA_NEDEN_KOD_ID";
                col1.Caption = "Dava Nedeni";
                col1.ColumnEdit = lkDavaAdi;
                col1.Visible = true;
                col1.VisibleIndex = 0;
                glk.View.Columns.Add(col1);

                GridColumn col2 = new GridColumn();
                col2.FieldName = "DIGER_DAVA_NEDEN";
                col2.Caption = "Diðer Dava Nedeni";
                col2.Visible = true;
                col2.VisibleIndex = 1;
                glk.View.Columns.Add(col2);

                GridColumn col3 = new GridColumn();
                col3.FieldName = "DUZENLEME_TARIHI";
                col3.Caption = "Düzenlenme T";
                col3.Visible = true;
                col3.VisibleIndex = 2;
                glk.View.Columns.Add(col3);

                GridColumn col4 = new GridColumn();
                col4.FieldName = "TUTAR_DOVIZ_ID";
                col4.Caption = string.Empty;
                col4.ColumnEdit = lkDoviz;
                col4.Visible = true;
                col4.VisibleIndex = 3;
                glk.View.Columns.Add(col4);

                GridColumn col5 = new GridColumn();
                col5.FieldName = "TUTAR";
                col5.Caption = "Tutar";
                col5.ColumnEdit = tutar;
                col5.Visible = true;
                col5.VisibleIndex = 4;
                glk.View.Columns.Add(col5);

                lw.Columns["DAVA_NEDEN_ID"].ColumnEdit = glk;
            }
            catch (Exception ex) { BelgeUtil.ErrorHandler.Catch(typeof(Inits), ex); }

            #endregion Controller Oluþturuluyor

            #region Dosyadan Dava Nedenleri Dolduruluyor

            try
            {
                glk.BeginUpdate();

                DataRepository.AV001_TD_BIL_DAVA_NEDENProvider.
                    DeepLoad(MyFoy.AV001_TD_BIL_DAVA_NEDENCollection, false,
                    DeepLoadType.IncludeChildren, typeof(TDI_KOD_DAVA_ADI));

                glk.DataSource = MyFoy.AV001_TD_BIL_DAVA_NEDENCollection;
                glk.ValueMember = "ID";
                glk.DisplayMember = "TDI_KOD_DAVA_ADI_IDSource";
                glk.NullText = "Seç";

                glk.EndUpdate();
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(typeof(Inits), ex);
            }

            #endregion Dosyadan Dava Nedenleri Dolduruluyor
        }

        public static void DavaTakipKonusuGetir(LookUpEdit[] lues)
        {
            if (_DavaTakipKonusuGetir == null)
            {
                _DavaTakipKonusuGetir = DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
            }
            VList<per_TD_KOD_DAVA_TALEP> listem = _DavaTakipKonusuGetir;
            foreach (LookUpEdit lue in lues)
            {
                lue.Properties.DataSource = null;
                lue.Properties.DataSource = listem;
                lue.Properties.ValueMember = "ID";
                lue.Properties.DisplayMember = "DAVA_TALEP";
                LookUpColumnInfo takipKonu = new LookUpColumnInfo("DAVA_TALEP", 30, "Dava Konusu");
                lue.Properties.NullText = "Seç";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { takipKonu });
            }
        }

        public static void DavaTalepGetir(LookUpEdit lue)
        {
            //lue.Properties.NullText = "Seç";
            //if (lue.Properties.DataSource == null)
            //{
            //    lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
            //    lue.Properties.DisplayMember = "DAVA_TALEP";
            //    lue.Properties.ValueMember = "ADLI_BIRIM_BOLUM_ID";

            // lue.Properties.Columns.Clear(); lue.Properties.Columns.Add(new
            // LookUpColumnInfo("DAVA_TALEP", "Talep", 40));
            //}
            if (_DavaTalepGetir == null)
            {
                _DavaTalepGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
            }
            lue.Properties.DataSource = _DavaTalepGetir;
            lue.Properties.NullText = "Seç";
            lue.Properties.DisplayMember = "DAVA_TALEP";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Talep", 40));
        }

        public static void DavaTalepGetir(RepositoryItemLookUpEdit lue)
        {
            DavaTalepGetir_Enter(lue, EventArgs.Empty);
        }

        public static void DavaTalepGetir_Enter(object sender, EventArgs e)
        {
            RepositoryItemLookUpEdit lue = (sender is LookUpEdit) ? (sender as LookUpEdit).Properties : sender as RepositoryItemLookUpEdit;
            //if (_DavaTalepGetir == null)
            //{
            //    _DavaTalepGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
            //}
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = Kimlikci.Kimlik.SirketBilgisi.ConStr;

            if (lue.DataSource == null)
            {
                lue.DataSource = cn.GetDataTable("SELECT ID, DAVA_TALEP FROM dbo.per_TD_KOD_DAVA_TALEP(nolock)");
                lue.DisplayMember = "DAVA_TALEP";
                lue.ValueMember = "ID";
                lue.Columns.Clear();
                lue.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Talep", 40));
            }
        }

        public static void DavaTalepGetirRefresh()
        {
            _DavaTalepGetir = AvukatProLib2.Data.DataRepository.per_TD_KOD_DAVA_TALEPProvider.GetAll();
        }

        public static TList<AV001_TDI_BIL_CARI> DavaTumTaraflar(AV001_TD_BIL_FOY MyFoy)
        {
            TList<AV001_TDI_BIL_CARI> result = new TList<AV001_TDI_BIL_CARI>();

            MyFoy.AV001_TD_BIL_FOY_TARAFCollection.ForEach(delegate(AV001_TD_BIL_FOY_TARAF taraf)
            {
                if (taraf.CARI_IDSource == null)
                    taraf.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.ID);

                result.Add(taraf.CARI_IDSource);
            });

            return result;
        }

        public static void DavaTumTaraflar(AV001_TD_BIL_FOY MyFoy, RepositoryItemLookUpEdit[] controls)
        {
            TList<AV001_TDI_BIL_CARI> result = new TList<AV001_TDI_BIL_CARI>();
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_FOY_TARAF>));

            MyFoy.AV001_TD_BIL_FOY_TARAFCollection.ForEach(delegate(AV001_TD_BIL_FOY_TARAF taraf)
            {
                if (taraf.CARI_IDSource == null)
                    taraf.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(taraf.CARI_ID.Value);

                result.Add(taraf.CARI_IDSource);
            });

            foreach (RepositoryItemLookUpEdit c in controls)
            {
                if (c != null)
                {
                    if (c.DataSource == null)
                    {
                        c.DataSource = result;
                        c.ValueMember = "ID";
                        c.DisplayMember = "AD";
                        c.NullText = "Seç";
                        c.Columns.Clear();
                        c.Columns.Add(new LookUpColumnInfo("KOD", 10, "Kod"));
                        c.Columns.Add(new LookUpColumnInfo("AD", 30, "Taraf"));
                    }
                }
            }
        }

        public static void FaizIsletimSecenekleriGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            if (lue.Properties.DataSource == null)
            {
                DataTable dt = new DataTable("Faiz Ýþletim Seçenekleri");
                dt.Columns.Add("ID");
                dt.Columns.Add("ACIKLAMA");
                dt.Rows.Add(0, "Faiz basit usulde hesaplansýn.");
                dt.Rows.Add(1, "3 Aylýk Standart devrelerde faiz anaparaya ilave edilsin.");
                dt.Rows.Add(2, "Temerrüt itibariyle 3 Aylýk devrelerde faiz anaparaya ilave edilsin.");
                dt.Rows.Add(3, "Temerrüt itibariyle yýllýk faiz anaparaya ilave edilsin.");
                dt.Rows.Add(4, "Yýl sonlarý itibariyle yýllýk faiz anaparaya ilave edilsin.");
                dt.Rows.Add(5, "Ay sonlarýnda aylýk faiz anaparaya ilave edilsin");
                dt.Rows.Add(6, "Temerrüt itibariyle aylýk faiz anaparaya ilave edilsin");

                lue.Properties.DataSource = dt;
                lue.Properties.DisplayMember = "ACIKLAMA";
                lue.SelectionStart = 0;

                lue.Properties.ValueMember = "ID";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ödeme Zamaný"));
            }
        }

        public static void FirmaBolgeGetir(RepositoryItemLookUpEdit lue)
        {
            if (_FirmaBolgeGetir == null)
            {
                _FirmaBolgeGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_FIRMA_BOLGEProvider.GetAll();
            }
            lue.DataSource = _FirmaBolgeGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "BOLGE";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("BOLGE", "Firma Bölge", 100));
        }

        public static void HAcizKaynakGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("HacizKaynak");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.HacizKaynak tipi in Enum.GetValues(typeof(AvukatProLib.Extras.HacizKaynak)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Haciz Kaynaðý"));
        }

        public static void HesapTipiGetir(RepositoryItemLookUpEdit lue)
        {
            if (_HesapTipiGetir == null)
            {
                _HesapTipiGetir = DataRepository.per_AV001_TI_KOD_HESAP_TIPProvider.GetAll(); // dt;
            }
            lue.DataSource = _HesapTipiGetir;
            lue.DisplayMember = "HESAP_TIP";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("HESAP_TIP", 30, "Hesap Tipi"));

            //lue.Columns.Add(new LookUpColumnInfo("ID", 30, "Hesap Tipi"));
        }

        public static void HesapTipiGetir(LookUpEdit lue)
        {
            lue.Properties.NullText = "Seç";
            lue.Enter += new EventHandler(HesapTipiGetir_Enter);
            HesapTipiGetir_Enter(lue, new EventArgs());
        }

        public static void HesapTipiGetirYenile()
        {
            _HesapTipiGetir = DataRepository.per_AV001_TI_KOD_HESAP_TIPProvider.GetAll(); // dt;
        }

        public static void HukumCelseGetir(VGridControl vGridControl, AV001_TD_BIL_FOY MyFoy)
        {
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_CELSE>));
            RepositoryItemGridLookUpEdit glk = new RepositoryItemGridLookUpEdit();
            RepositoryItemLookUpEdit lkSorumluAvukat = new RepositoryItemLookUpEdit();

            #region Controller

            try
            {
                Inits.SorumluAvukatGetir(lkSorumluAvukat);

                glk.View.Columns.Clear();

                GridColumn col1 = new GridColumn();
                col1.FieldName = "SORUMLU_AVUKAT_CARI1_ID";
                col1.Caption = "Sorumlu Avukat";
                col1.ColumnEdit = lkSorumluAvukat;
                col1.Visible = true;
                col1.VisibleIndex = 0;
                glk.View.Columns.Add(col1);

                GridColumn col2 = new GridColumn();
                col2.FieldName = "TARIH";
                col2.Caption = "Tarih";
                col2.Visible = true;
                col2.VisibleIndex = 1;
                glk.View.Columns.Add(col2);

                GridColumn col3 = new GridColumn();
                col3.FieldName = "SAAT";
                col3.Caption = "Saat";
                col3.Visible = true;
                col3.VisibleIndex = 2;
                glk.View.Columns.Add(col3);

                vGridControl.Rows.GetRowByFieldName("HUKUM_CELSE_ID").Properties.RowEdit = glk;
            }
            catch (Exception ex) { BelgeUtil.ErrorHandler.Catch(typeof(Inits), ex); }

            #endregion Controller

            #region HukumCelse Tiplerini Doldururuyor

            try
            {
                glk.BeginUpdate();
                DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad(MyFoy.AV001_TD_BIL_CELSECollection);

                glk.DataSource =
                    MyFoy.AV001_TD_BIL_CELSECollection.FindAll(AV001_TD_BIL_CELSEColumn.CELSE_MI, true);

                glk.ValueMember = "ID";
                glk.DisplayMember = "SORUMLU_AVUKAT_CARI1_IDSource";
                glk.NullText = "Seç";
            }
            catch (Exception ex) { BelgeUtil.ErrorHandler.Catch(typeof(Inits), ex); }

            #endregion HukumCelse Tiplerini Doldururuyor
        }

        /// <summary>
        /// VGridControl üzerindeki HUKUM_CELSE_ID alanýna Celse mi true olanlarý getirir
        /// RepositortyItemGridLookUpEdit olarak basar.
        /// </summary>
        /// <param name="lw">GridView</param>
        /// <param name="MyFoy">AV001_TD_BIL_FOY</param>
        public static void HukumCelseGetir(AV001_TD_BIL_FOY MyFoy, RepositoryItemGridLookUpEdit glk)
        {
            DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_CELSE>));
            DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad(MyFoy.AV001_TD_BIL_CELSECollection);

            glk.DataSource =
                MyFoy.AV001_TD_BIL_CELSECollection.FindAll(AV001_TD_BIL_CELSEColumn.CELSE_MI, true);

            glk.ValueMember = "ID";
            glk.DisplayMember = "SORUMLU_AVUKAT_CARI1_IDSource";
            glk.NullText = "Seç";
        }

        public static void HukumCelseGetir(RepositoryItemLookUpEdit lue, AV001_TD_BIL_FOY MyFoy)
        {
            if (_HukumCelseGetir == null)
            {
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren, typeof(TList<AV001_TD_BIL_CELSE>));
                DataRepository.AV001_TD_BIL_CELSEProvider.DeepLoad(MyFoy.AV001_TD_BIL_CELSECollection, false, DeepLoadType.IncludeChildren, typeof(AV001_TDI_BIL_CARI));
                _HukumCelseGetir = MyFoy.AV001_TD_BIL_CELSECollection.FindAll(AV001_TD_BIL_CELSEColumn.CELSE_MI, true);
            }
            lue.DataSource = _HukumCelseGetir;
            lue.DisplayMember = "SORUMLU_AVUKAT_CARI1_IDSource";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Add(new LookUpColumnInfo("SORUMLU_AVUKAT_CARI1_IDSource", 10, "Sorumlu Avukat"));
            lue.Columns.Add(new LookUpColumnInfo("TARIH", 30, "Tarih"));
        }

        public static void HukumGetir(RepositoryItemLookUpEdit rlue)
        {
            if (_HukumGetir == null)
            {
                _HukumGetir = DataRepository.per_TD_KOD_MAHKEME_HUKUMProvider.GetAll();
            }
            rlue.DataSource = _HukumGetir.OrderBy(vi => vi.HUKUM).ToList();
            rlue.ValueMember = "ID";
            rlue.DisplayMember = "HUKUM";
            rlue.NullText = "Seç";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("HUKUM", 30, "Hüküm"));
        }

        public static void HukumTipGetir(RepositoryItemLookUpEdit rlue)
        {
            if (_HukumTipGetir == null)
            {
                _HukumTipGetir = DataRepository.per_TD_KOD_MAHKEME_HUKUM_TIPProvider.GetAll();
            }

            //rlue.Columns.Clear();
            //rlue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo(
            rlue.DataSource = _HukumTipGetir;
            rlue.ValueMember = "ID";
            rlue.DisplayMember = "HUKUM_TIP";
            rlue.NullText = "Seç";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("HUKUM_TIP", 30, "Hüküm Tipi"));
        }

        public static void IcraPratikAramaGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.ICRA_PRATIK_ARAMAProvider.GetAll();
            lue.DisplayMember = "FOY_NO";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("FOY_NO", "Dosya No", 100));
            lue.Columns.Add(new LookUpColumnInfo("ESAS_NO", "ESAS NO", 100));
            lue.Columns.Add(new LookUpColumnInfo("ADLI_BIRIM_ADLIYE_ID", "Müdürlük", 100));
            lue.Columns.Add(new LookUpColumnInfo("ADLI_BIRIM_NO_ID", "No", 100));
            lue.Columns.Add(new LookUpColumnInfo("AL_NED_REF1", "AN Referans", 100));
        }

        public static void IliskiDetayHedefTipiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("HedefTipi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            dt.Rows.Add(1, "Ýcra");
            dt.Rows.Add(2, "Dava");
            dt.Rows.Add(3, "Soruþturma");
            dt.Rows.Add(4, "Rucu");
            dt.Rows.Add(5, "Sözleþme");

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Hedef Tipi"));
        }

        public static void ItirazGiderilmeYol(RepositoryItemLookUpEdit rlue)
        {
            if (_ItirazGiderilmeYol == null)
            {
                _ItirazGiderilmeYol = AvukatProLib2.Data.DataRepository.per_TI_KOD_ITIRAZ_GIDERILME_YOLUProvider.GetAll();
            }
            rlue.DataSource = _ItirazGiderilmeYol;
            rlue.NullText = "Seç";
            rlue.DisplayMember = "ITIRAZIN_GIDERILME_YOLU";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("ITIRAZIN_GIDERILME_YOLU", "Ýtirazýn Giderilme Yolu", 100));
        }

        public static void ItirazGiderilmeYol(LookUpEdit lue)
        {
            ItirazGiderilmeYol(lue.Properties);
        }

        /// <summary>
        /// TI_KOD_MAL_CINS kategoriye göre cins getirir
        /// </summary>
        /// <param name="lue"></param>
        public static void KategoriyeMalcinsGetir(RepositoryItemLookUpEdit lue, int kategoryID)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_CINSProvider.Get("KATEGORI_ID=" + kategoryID, "CINS DESC");

            //GetByKATEGORI_ID(kategoryID);
            lue.NullText = "Seç";
            lue.DisplayMember = "CINS";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("CINS", "Mal Cinsi", 100));
        }

        /// <summary>
        /// TI_KOD_MAL_TUR Kategoriye göre Tur getirir
        /// </summary>
        /// <param name="lue"></param>
        public static void KategoriyeMalTurGetir(RepositoryItemLookUpEdit lue, int kategoryID)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.per_TI_KOD_MAL_TURProvider.Get("KATEGORI_ID=" + kategoryID, "ORDERBY KOD");

            //GetByKATEGORI_ID(kategoryID);
            lue.NullText = "Seç";
            lue.DisplayMember = "TUR";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("TUR", "Mal Tür", 100));
        }

        public static void KdvKodGetir(RepositoryItemLookUpEdit lue)
        {
            if (_KdvKodGetir == null)
            {
                _KdvKodGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_KDVProvider.GetAll();
            }
            lue.DataSource = _KdvKodGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "AD";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("AD", "KDV Kod", 100));
        }

        public static void KontrolKimGetir(RepositoryItemLookUpEdit lue)
        {
            if (_KontrolKimGetir == null)
            {
                _KontrolKimGetir = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetAll();
            }
            lue.DataSource = _KontrolKimGetir;
            lue.DisplayMember = "KULLANICI_ADI";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("KULLANICI_ADI", 30, "Kontrol Kim"));
        }

        public static void KontrolKimGetirCari(RepositoryItemLookUpEdit lue)
        {
            if (_KontrolKimGetirCari == null)
            {
                _KontrolKimGetirCari = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetAll();

                foreach (var item in _KontrolKimGetirCari)
                {
                    if (item.CARI_ID.HasValue)
                        _KontrolKimCari.Add(DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(item.CARI_ID.Value));
                }
            }
            lue.DataSource = _KontrolKimCari;
            lue.DisplayMember = "AD";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("AD", 30, "Kontrol Kim"));
        }

        public static void MahkemeIadeNedeniGetir(RepositoryItemLookUpEdit rlue)
        {
            if (_MahkemeIadeNedeniGetir == null)
            {
                _MahkemeIadeNedeniGetir = DataRepository.per_TDI_KOD_FOY_IADE_NEDENProvider.GetAll();
            }
            rlue.DataSource = _MahkemeIadeNedeniGetir;
            rlue.DisplayMember = "IADE_NEDEN";
            rlue.ValueMember = "ID";
            rlue.NullText = "Seç";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("IADE_NEDEN", 30, "Ýade Nedeni"));
        }

        public static void MasrafAvansTipGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("MAvans");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.MasrafAvansTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.MasrafAvansTip)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Tipi"));
        }

        public static void MevzuatGetirForKutuphane(RepositoryItemLookUpEdit rlue)
        {
            if (_MevzuatGetirForKutuphane == null)
            {
                _MevzuatGetirForKutuphane = AvukatProLib2.Data.DataRepository.per_TDI_KOD_MEVZUATProvider.GetAll();
            }
            rlue.DataSource = _MevzuatGetirForKutuphane;
            rlue.NullText = "Seç";
            rlue.DisplayMember = "MEVZUAT";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("MEVZUAT", "Mevzuatlar", 100));
        }

        public static void MevzuatGetirForKutuphane(LookUpEdit lue)
        {
            MevzuatGetirForKutuphane(lue.Properties);
        }

        public static void ModulGetir(RepositoryItemLookUpEdit lue)
        {
            //DataTable dt = new DataTable("Modul");
            //dt.Columns.Add("ID");
            //dt.Columns.Add("ACIKLAMA");

            //foreach (AvukatProLib.Extras.Modul tipi in Enum.GetValues(typeof(AvukatProLib.Extras.Modul)))
            //{
            //    if (tipi == Modul.Icra || tipi == Modul.Dava || tipi == Modul.Sorusturma || tipi == Modul.Sozlesme || tipi == Modul.Genel)
            //        dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            //}

            //////List<AvukatPro.Model.EntityClasses.PerTdieKodModulEntity> sonuc = BaseService._db.PerTdieKodModul.ToList();

            ////////aykut
            //////List<AvukatPro.Model.EntityClasses.PerTdieKodModulEntity> sonuc2 = new List<AvukatPro.Model.EntityClasses.PerTdieKodModulEntity>();

            //////foreach (AvukatPro.Model.EntityClasses.PerTdieKodModulEntity item in sonuc)
            //////{
            //////    if (item.Id == 1 || item.Id == 2 || item.Id == 3 || item.Id == 5 || item.Id == 7)
            //////        sonuc2.Add(item);
            //////}

            //////lue.DataSource = sonuc2;
            //////lue.DisplayMember = "Ad";
            //////lue.ValueMember = "Id";
            //////lue.NullText = "Modül Seçiniz...";
            //////lue.Columns.Clear();
            //////lue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Ad", "Modül", 50));
        }

        public static void NispiHarcGetir(RepositoryItemLookUpEdit lue)
        {//çalýþýyor
            if (_NispiHarcGetir == null)
            {
                _NispiHarcGetir = AvukatProLib2.Data.DataRepository.TI_KOD_HARC_NISPIProvider.GetAll();
            }
            lue.DataSource = _NispiHarcGetir;
            lue.DisplayMember = "HARC_ADI";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("HARC_ADI", 20, "Harç Adý"), new LookUpColumnInfo("HARC_TIPI", 30, "Harç Tipi") });
        }

        public static void OdemeDagilimGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("OdemeDagilim");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            dt.Rows.Add(1, "Dosya");
            dt.Rows.Add(2, "Taraf");

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ödeme Daðýlým"));
        }

        public static void OdemeTakipSonrasimiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("Odeme Zamaný");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            dt.Rows.Add(1, "Takip Öncesi");
            dt.Rows.Add(0, "Takip Sonrasý");

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ödeme Zamaný"));
        }

        public static void ProjeDurumGetir(RepositoryItemLookUpEdit lue)
        {
            if (_ProjeDurumGetir == null)
            {
                _ProjeDurumGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_PROJE_DURUMProvider.GetAll();
            }
            lue.DataSource = _ProjeDurumGetir;
            lue.DisplayMember = "DURUM";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("DURUM", "Durum", 100));
        }

        public static void ProjeOzelKodGetir(RepositoryItemLookUpEdit lue)
        {
            if (_ProjeOzelKodGetir == null)
            {
                _ProjeOzelKodGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_PROJE_OZEL_KODProvider.GetAll();
            }
            lue.DataSource = _ProjeOzelKodGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "OZEL_KOD";
            lue.ValueMember = "ID";

            lue.Columns.Clear();

            lue.Columns.Add(new LookUpColumnInfo("OZEL_KOD", "Durum", 100));
        }

        public static void ProjeOzelKodGetirRefresh(RepositoryItemLookUpEdit lue)
        {
            _ProjeOzelKodGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_PROJE_OZEL_KODProvider.GetAll();
            lue.DataSource = _ProjeOzelKodGetir;
        }

        public static void ProjeTipGetir(RepositoryItemLookUpEdit lue)
        {
            if (_ProjeTipGetir == null)
            {
                _ProjeTipGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_PROJE_TIPProvider.GetAll();
            }
            lue.DataSource = _ProjeTipGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "TIP";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("TIP", "Proje Tipi", 100));
        }

        public static void RenkGecisYonuGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("AraKararTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");

            foreach (System.Drawing.Drawing2D.LinearGradientMode tipi in Enum.GetValues(typeof(System.Drawing.Drawing2D.LinearGradientMode)))
            {
                switch (tipi)
                {
                    case LinearGradientMode.Horizontal:
                        dt.Rows.Add(tipi, "Yatay");
                        break;

                    case LinearGradientMode.Vertical:
                        dt.Rows.Add(tipi, "Dikey");
                        break;

                    case LinearGradientMode.ForwardDiagonal:
                        dt.Rows.Add(tipi, "Ýleri Çapraz");
                        break;

                    case LinearGradientMode.BackwardDiagonal:
                        dt.Rows.Add(tipi, "Geri Çapraz");
                        break;
                }
            }

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Geçiþ Yönü"));
        }

        public static void RenkUygulamaTipiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("AraKararTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            dt.Rows.Add(true, "Tüm Satýra Uygula");
            dt.Rows.Add(false, "Sadece Hücreye Uygula");

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Uygulama Tipi"));
        }

        public static int SeciliTarafId(AV001_TD_BIL_FOY MyFoy)
        {
            foreach (AV001_TD_BIL_FOY_TARAF t in MyFoy.AV001_TD_BIL_FOY_TARAFCollection)
            {
                if (t.IsSelected)
                {
                    if (t.CARI_IDSource == null)
                        t.CARI_IDSource = DataRepository.AV001_TDI_BIL_CARIProvider.GetByID(t.ID);

                    return t.CARI_ID.Value;
                }
            }
            return 0;
        }

        public static TList<AV001_TDI_BIL_CARI> SikayetEdenTarafByFoy(AV001_TD_BIL_HAZIRLIK foy, RepositoryItemLookUpEdit[] controls)
        {
            TList<AV001_TDI_BIL_CARI> cariList = new TList<AV001_TDI_BIL_CARI>();

            foreach (AV001_TD_BIL_HAZIRLIK_TARAF taraf in foy.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
            {
                if (taraf.IsNew)
                {
                    if (taraf.TARAF_SIFAT_IDSource == null)
                        taraf.TARAF_SIFAT_IDSource =
                            DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(taraf.TARAF_SIFAT_ID.Value);
                }

                else if (taraf.CARI_IDSource == null)
                {
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren,
                        typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT));
                }

                if (taraf.TARAF_SIFAT_IDSource == null)
                    taraf.TARAF_SIFAT_IDSource = DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(taraf.TARAF_SIFAT_ID.Value);

                cariList.Add(taraf.CARI_IDSource);
            }

            foreach (RepositoryItemLookUpEdit rlue in controls)
            {
                rlue.DataSource = cariList;
                rlue.DisplayMember = "AD";
                rlue.ValueMember = "ID";
                rlue.NullText = "Seç";
                rlue.Columns.Clear();
                rlue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });
            }

            return cariList;
        }

        public static TList<AV001_TDI_BIL_CARI> SikayetEdilenTarafByFoy(AV001_TD_BIL_HAZIRLIK foy, RepositoryItemLookUpEdit[] controls)
        {
            TList<AV001_TDI_BIL_CARI> cariList = new TList<AV001_TDI_BIL_CARI>();

            foreach (AV001_TD_BIL_HAZIRLIK_TARAF taraf in foy.AV001_TD_BIL_HAZIRLIK_TARAFCollection)
            {
                if (taraf.IsNew)
                {
                    if (taraf.TARAF_SIFAT_IDSource == null)
                        taraf.TARAF_SIFAT_IDSource =
                            DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(taraf.TARAF_SIFAT_ID.Value);
                }

                else if (taraf.CARI_IDSource == null)
                {
                    DataRepository.AV001_TD_BIL_HAZIRLIK_TARAFProvider.DeepLoad(taraf, false, DeepLoadType.IncludeChildren,
                        typeof(AV001_TDI_BIL_CARI), typeof(TDIE_KOD_TARAF_SIFAT));
                }

                if (taraf.TARAF_SIFAT_IDSource == null)
                    taraf.TARAF_SIFAT_IDSource = DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(taraf.TARAF_SIFAT_ID.Value);

                cariList.Add(taraf.CARI_IDSource);
            }

            foreach (RepositoryItemLookUpEdit rlue in controls)
            {
                rlue.DataSource = cariList;
                rlue.DisplayMember = "AD";
                rlue.ValueMember = "ID";
                rlue.NullText = "Seç";
                rlue.Columns.Clear();
                rlue.Columns.AddRange(new LookUpColumnInfo[]
                    {
                        new LookUpColumnInfo("KOD", 10, "Kod"),
                        new LookUpColumnInfo("AD", 30, "Ad")
                    });
            }

            return cariList;
        }

        //

        public static void SorumluAvukatGetir(LookUpEdit[] lues)
        {
            if (_SorumluAvukatGetir == null)
            {
                _SorumluAvukatGetir = DataRepository.per_AV001_TDI_BIL_CARIProvider.Get("PERSONEL_MI='TRUE' AND FIRMA_MI='FALSE' ", "AD DESC");
            }

            VList<per_AV001_TDI_BIL_CARI> listem = _SorumluAvukatGetir;

            //Find(string.Format("PERSONEL_MI='{0}' AND FIRMA_MI='{1}'", "TRUE", "FALSE"));
            foreach (LookUpEdit lue in lues)
            {
                lue.Properties.DataSource = null;
                lue.Properties.DataSource = listem;
                lue.Properties.ValueMember = "ID";
                lue.Properties.DisplayMember = "AD";
                LookUpColumnInfo sorumluAvuk = new LookUpColumnInfo("AD", 30, "Sorumlu Avukatlar");
                lue.Properties.NullText = "Seç";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { sorumluAvuk });
            }
        }

        public static void SubeKodGetir(RepositoryItemLookUpEdit lue)
        {
            if (_SubeKodGetir == null)
            {
                _SubeKodGetir = DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetAll();
            }
            lue.DataSource = _SubeKodGetir;
            lue.DisplayMember = "SUBE_ADI";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("SUBE_ADI", 30, "Büro"));
        }

        public static void TakipVekaletKatsayiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("VekaletKatsayi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");

            dt.Rows.Add(0, "YOK");
            dt.Rows.Add(0.25, "1/4");
            dt.Rows.Add(0.50, "1/2");
            dt.Rows.Add(0.75, "3/4");
            dt.Rows.Add(1, "TAM");

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Vekalet Katsayýsý"));
        }

        public static TDIE_KOD_TARAF_SIFAT TarafSifatGetir(int? id)
        {
            TDIE_KOD_TARAF_SIFAT sifat = null;

            //per_TDIE_KOD_TARAF_SIFATQuery param = new per_TDIE_KOD_TARAF_SIFATQuery();
            //param.Clear();
            //param.Append(per_TDIE_KOD_TARAF_SIFATColumn.ID, Convert.ToString(id));

            if (!id.HasValue)
                return null;

            sifat = AvukatProLib2.Data.DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(id.Value);

            //Find(param.GetParameters());
            //Find("ID=" + id.Value, "SIFAT DESC");
            //GetByID(id.Value);
            return sifat;
        }

        public static TDIE_KOD_TARAF_SIFAT TarafSifatGetir(AV001_TD_BIL_FOY_TARAF trf)
        {
            if (trf.TARAF_SIFAT_IDSource == null)
            {
                trf.TARAF_SIFAT_IDSource = DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(trf.TARAF_SIFAT_ID.Value);
            }

            return trf.TARAF_SIFAT_IDSource;
        }

        public static void TarafSifatGetir(RepositoryItemLookUpEdit rlue)
        {
            if (_TarafSifatGetir == null)
            {
                if (_CariSifatGetir == null)
                {
                    if (CodeInfo<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT>.ListeVarmi(typeof(AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT)))
                        _CariSifatGetir = CodeInfo<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT>.ListeGetir(typeof(AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT)) as List<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT>;
                    else
                    {
                        _CariSifatGetir = context.per_TDIE_KOD_TARAF_SIFATs.ToList();
                        CodeInfo<AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT>.ListeKaydet(_CariSifatGetir, typeof(AvukatProLib.Arama.per_TDIE_KOD_TARAF_SIFAT));
                    }
                    _TarafSifatGetir = _CariSifatGetir;
                }
                else
                    _TarafSifatGetir = _CariSifatGetir;
            }
            if (rlue.DataSource == null)
            {
                rlue.DataSource = _TarafSifatGetir;
                rlue.NullText = "Seç";
                rlue.DisplayMember = "SIFAT";
                rlue.ValueMember = "ID";
                rlue.Columns.Clear();
                rlue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf Sýfat", 100));
            }
        }

        public static void TarafSifatGetir(LookUpEdit lue)
        {
            TarafSifatGetir(lue.Properties);
        }

        public static void TebligatHedefTipGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("TebligatHedefTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (TebligatHedefTip tipi in Enum.GetValues(typeof(TebligatHedefTip)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Hedef Tipi"));
        }

        public static void TebligatHedefTipGetir(LookUpEdit lue)
        {
            DataTable dt = new DataTable("TebligatHedefTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (TebligatHedefTip tipi in Enum.GetValues(typeof(TebligatHedefTip)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.Properties.DataSource = dt;
            lue.Properties.DisplayMember = "ACIKLAMA";
            lue.Properties.NullText = "Seç";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Hedef Tipi"));
        }

        public static void TeminatMektupDurumGetir(RepositoryItemLookUpEdit lue)
        {
            if (_TeminatMektupDurumGetir == null)
            {
                _TeminatMektupDurumGetir = AvukatProLib2.Data.DataRepository.TDI_KOD_TEMINAT_MEKTUP_DURUMProvider.GetAll();
            }
            lue.DataSource = _TeminatMektupDurumGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "TEMINAT_MEKTUP_DURUM";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("TEMINAT_MEKTUP_DURUM", "Teminat Mektup Durum", 100));
        }

        public static void TeminatMektupKonuGetir(RepositoryItemLookUpEdit lue)
        {
            if (_TeminatMektupKonuGetir == null)
            {
                _TeminatMektupKonuGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEMINAT_MEKTUP_KONUProvider.GetAll();
            }
            lue.DataSource = _TeminatMektupKonuGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "KONU";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("KONU", "Teminat Mektup Konu", 100));
        }

        public static void TeminatMektupTarafTipGetir(RepositoryItemLookUpEdit lue)
        {
            if (_TeminatMektupTarafTipGetir == null)
            {
                _TeminatMektupTarafTipGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_TEMINAT_MEKTUP_TARAF_TIPProvider.GetAll();
            }
            lue.DataSource = _TeminatMektupTarafTipGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "TARAF_TIP";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("TARAF_TIP", "Teminat Mektup Taraf Tipi", 100));
        }

        public static void TeminatTipGetir(RepositoryItemLookUpEdit lue)
        {
            if (_TeminatTipGetir == null)
            {
                _TeminatTipGetir = AvukatProLib2.Data.DataRepository.per_TI_KOD_TEMINAT_TIPProvider.GetAll();
            }
            lue.DataSource = _TeminatTipGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "TIP";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("TIP", "Teminat Tipleri", 100));
        }

        public static void YazarGetir(RepositoryItemLookUpEdit rlue)
        {
            if (_YazarGetir == null)
            {
                _YazarGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_YAZARProvider.GetAll();
            }
            rlue.DataSource = _YazarGetir;
            rlue.NullText = "Seç";
            rlue.DisplayMember = "YAZAR";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("YAZAR", "Yazar Adý", 100));
        }

        public static void YazarGetir(LookUpEdit lue)
        {
            YazarGetir(lue.Properties);
        }

        public static void YaziTipiDoldur(RepositoryItemLookUpEdit rlue)
        {
            DataTable dt = new DataTable("Fontlar");
            dt.Columns.Add("Font_Adi");
            dt.Columns.Add("Font_Boyutu");

            FontFamily[] families = FontFamily.Families;
            for (int i = 0; i < families.Length; i++)
            {
                dt.Rows.Add(families[i].Name, "12");
            }

            rlue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Font_Adi", 100, "Font Adý"));
            rlue.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Font_Boyutu", 20, "Font Boyutu"));
            rlue.DisplayMember = "Font_Adi";
            rlue.ValueMember = "Font_Adi";
            rlue.NullText = "Seç";
        }

        public static void YevmiyeKodGetir(RepositoryItemLookUpEdit lue)
        {
            if (_YevmiyeKodGetir == null)
            {
                _YevmiyeKodGetir = AvukatProLib2.Data.DataRepository.per_TDI_KOD_YEVMIYEProvider.GetAll();
            }
            lue.DataSource = _YevmiyeKodGetir;
            lue.NullText = "Seç";
            lue.DisplayMember = "TIP";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("TIP", "Yevmiye Kod", 100));
        }

        private static void BirYilKacGGetir_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                DataTable dt = new DataTable("BirYilKacGun");
                dt.Columns.Add("GUN");

                dt.Rows.Add(360);
                dt.Rows.Add(365);

                lue.Properties.DataSource = dt;
                lue.Properties.DisplayMember = "GUN";

                lue.Properties.ValueMember = "GUN";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("GUN", 30, "Gün"));
            }
        }

        private static void HesapTipiGetir_Enter(object sender, EventArgs e)
        {
            LookUpEdit lue = (LookUpEdit)sender;
            if (lue.Properties.DataSource == null)
            {
                lue.Properties.DataSource = DataRepository.per_AV001_TI_KOD_HESAP_TIPProvider.GetAll(); // dt;
                lue.Properties.DisplayMember = "HESAP_TIP";

                lue.Properties.ValueMember = "ID";
                lue.Properties.Columns.Clear();
                lue.Properties.Columns.Add(new LookUpColumnInfo("HESAP_TIP", 30, "Hesap Tipi"));

                //lue.Columns.Add(new LookUpColumnInfo("ID", 30, "Hesap Tipi"));
            }
        }

        #region < TIO - 20092906 >

        public static void MailMesajTipGetir(LookUpEdit lue)
        {
            if (_MesajTipGetir == null)
            {
                _MesajTipGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_MESAJ_TIPProvider.GetAll();
            }
            lue.Properties.DataSource = _MesajTipGetir;
            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "AD";
            lue.Properties.NullText = "Seç";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("AD", 20, "Ad"));
        }

        public static void MailMesajTipGetir(RepositoryItemLookUpEdit lue)
        {
            if (_MesajTipGetir == null)
            {
                _MesajTipGetir = AvukatProLib2.Data.DataRepository.per_TDIE_KOD_MESAJ_TIPProvider.GetAll();
            }
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("AD", 10, "Ad") });
            lue.DataSource = _MesajTipGetir;
            lue.DisplayMember = "AD";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        #endregion < TIO - 20092906 >

        #region < TIO - 20093006 >

        public static void SMSDurumGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TSMS_KOD_MESAJ_DURUMProvider.GetAll();//
            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "DURUM";
            lue.Properties.NullText = "Seç";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("DURUM", 20, "Durum"));
        }

        public static void SMSDurumGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("DURUM", 10, "Durum") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TSMS_KOD_MESAJ_DURUMProvider.GetAll();
            lue.DisplayMember = "DURUM";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        #endregion < TIO - 20093006 >

        ////TDI_KOD_TARIH_KATEGORI
        //public static void TarihKategoriGetir(RepositoryItemLookUpEdit lue)
        //{
        //    lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_TARIH_KATEGORIProvider.GetAll();
        //    lue.NullText = "Seç";
        //    lue.DisplayMember = "ACIKLAMA";
        //    lue.ValueMember = "ID";
        //    lue.Columns.Clear();
        //    lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", "Tarih Kodlarý", 100));

        //}
    }
}