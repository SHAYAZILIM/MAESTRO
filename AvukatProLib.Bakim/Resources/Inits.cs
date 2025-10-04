using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Data;

namespace AvukatProLib.Bakim.Resources
{
    public partial class Inits
    {
        public static void AdresTurGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADRES_TUR", 10, "Tür") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ADRES_TURProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ADRES_TUR.TDI_KOD_ADRES_TURGetir();
            lue.Properties.DisplayMember = "ADRES_TUR";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void AdresTurGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADRES_TUR", 10, "Tür") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ADRES_TURProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ADRES_TUR.TDI_KOD_ADRES_TURGetir();
            lue.DisplayMember = "ADRES_TUR";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void BaglantiTipiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("YetkiKullanmaTipi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.BaglantiTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.BaglantiTipi)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString());
            }
            lue.Properties.DataSource = dt;
            lue.Properties.DisplayMember = "ACIKLAMA";
            lue.Properties.NullText = "Seç";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Baðlantý Tipi"));
        }

        public static void BankaGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_BANKAProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_BANKA.TDI_KOD_BANKAGetir();
            lue.DisplayMember = "BANKA";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("BANKA", 40, "Banka"));
        }

        public static void BankaGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_BANKAProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_BANKA.TDI_KOD_BANKAGetir();
            lue.Properties.DisplayMember = "BANKA";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("BANKA", 40, "Banka"));
        }

        public static void BelgeTurGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_BELGE_TURProvider.GetAll();
            rlue.NullText = "Seç";
            rlue.DisplayMember = "BELGE_TURU";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("BELGE_TURU", "Belge Türü", 100));
        }

        public static void BelgeTurGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_BELGE_TURProvider.GetAll();
            lue.Properties.DisplayMember = "BELGE_TURU";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("BELGE_TURU", "Belge Türü", 40));
        }

        public static void CariAktifAdresGetir(LookUpEdit lue)
        {
            DataTable dt = new DataTable("AktifAdres");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.CariAktifAdres tipi in Enum.GetValues(typeof(AvukatProLib.Extras.CariAktifAdres)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.Properties.DataSource = dt;
            lue.Properties.DisplayMember = "ACIKLAMA";
            lue.Properties.NullText = "Seç";
            lue.Properties.ValueMember = "ID";

            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Aktif Adres"));
        }

        public static void CariAktifAdresGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("AktifAdres");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.CariAktifAdres tipi in Enum.GetValues(typeof(AvukatProLib.Extras.CariAktifAdres)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";

            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Aktif Adres"));
        }

        public static void CariGetir(RepositoryItemLookUpEdit lue)
        {
            BelgeUtil.Inits.CariGetir(lue);
            //lue.Columns.Clear();
            //lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad") });
            //TList<AV001_TDI_BIL_CARI> listem = DataRepository.AV001_TDI_BIL_CARIProvider.GetAll();
            //listem.Sort("AD ASC");
            //lue.DataSource = listem;
            //lue.DisplayMember = "AD";
            //lue.ValueMember = "ID";
            //lue.NullText = "Seç";
        }

        public static void CariTipiGetir(LookUpEdit lue)
        {
            DataTable dt = new DataTable("CariTipi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.CariTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.CariTipi)))
            {
                dt.Rows.Add(Convert.ToBoolean((int)tipi), tipi.ToString().Replace("_", " "));
            }
            lue.Properties.DataSource = dt;
            lue.Properties.DisplayMember = "ACIKLAMA";
            lue.Properties.NullText = "Seç";
            lue.Properties.ValueMember = "ID";

            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Þahýs Tipi"));
        }

        public static void CariTipiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("CariTipi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.CariTipi tipi in Enum.GetValues(typeof(AvukatProLib.Extras.CariTipi)))
            {
                dt.Rows.Add(Convert.ToBoolean((int)tipi), tipi.ToString().Replace("_", " "));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";

            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Þahýs Tipi"));
        }

        public static void CariUnvanGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("UNVAN", 10, "Ünvan") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_UNVANProvider.GetAll(); //AvukatProLib.Facade.TDI_KOD_UNVAN.TDI_KOD_UNVANGetir();
            lue.DisplayMember = "UNVAN";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void CariUnvanGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("UNVAN", 10, "Ünvan") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_UNVANProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_UNVAN.TDI_KOD_UNVANGetir();
            lue.Properties.DisplayMember = "UNVAN";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static string CariYeniKodGetir()
        {
            DataSet ds = DataRepository.AV001_TDI_BIL_CARIProvider.KodGetir(Degisken.SubeKodu);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return String.Empty;
        }

        /// <summary>
        /// TDI_KOD_CINSIYET
        /// </summary>
        /// <param name="rlue"></param>
        public static void CinsiyetGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_CINSIYETProvider.GetAll();

            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("CINSIYET", "Cinsiyet", 100));
            rlue.NullText = "Seç";
            rlue.DisplayMember = "CINSIYET";
            rlue.ValueMember = "ID";
        }

        public static void CinsiyetGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_CINSIYETProvider.GetAll();
            lue.Properties.DisplayMember = "CINSIYET";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("CINSIYET", "Cinsiyet", 40));
        }

        public static void ConnectionTipGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("YetkiKullanmaTipi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.ConnectionTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.ConnectionTip)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString());
            }
            lue.Properties.DataSource = dt;
            lue.Properties.DisplayMember = "ACIKLAMA";
            lue.Properties.NullText = "Seç";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Baðlantý Tipi"));
        }

        /// <summary>
        /// TDIE_KOD_DIL
        /// </summary>
        /// <param name="rlue"></param>
        public static void DilKodGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_DILProvider.GetAll();

            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("DIL", "Dil", 100));
            rlue.NullText = "Seç";
            rlue.DisplayMember = "DIL";
            rlue.ValueMember = "ID";
        }

        public static void DilKodGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_DILProvider.GetAll();
            lue.Properties.DisplayMember = "DIL";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("DIL", "Dil", 40));
        }

        public static void FirmaTurGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TUR", 10, "Tür") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_FIRMA_TURProvider.GetAll();// AvukatProLib.Facade.TDI_KOD_FIRMA_TUR.TDI_KOD_FIRMA_TURGetir();
            lue.Properties.DisplayMember = "TUR";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void FirmaTurGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TUR", 10, "Tür") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_FIRMA_TURProvider.GetAll(); //AvukatProLib.Facade.TDI_KOD_FIRMA_TUR.TDI_KOD_FIRMA_TURGetir();
            lue.DisplayMember = "TUR";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void FormAltTipi(LookUpEdit lue, int ustform)
        {
            lue.Properties.DataSource = DataRepository.CS_KOD_FORM_GRUPProvider.GetByUST_GRUP_ID(ustform);
            lue.Properties.DisplayMember = "GRUP_ADI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Grup Alt Tipi";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("GRUP_ADI", 60, "Grup Adý"));
        }

        public static void FormAltTipiTumu(LookUpEdit lue, int ustform)
        {
            lue.Properties.DataSource = DataRepository.CS_KOD_FORM_GRUPProvider.GetByUST_GRUP_ID(ustform);
            lue.Properties.DisplayMember = "GRUP_ADI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Grup Alt Tipi";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("GRUP_ADI", 60, "Grup Adý"));
        }

        public static void FormGrupGetir(LookUpEdit lue)
        {//Failed to convert parameter value from a String to a Int32.
            TList<CS_KOD_FORM_GRUP> grp = new TList<CS_KOD_FORM_GRUP>();
            foreach (CS_KOD_FORM_GRUP var in DataRepository.CS_KOD_FORM_GRUPProvider.GetAll())
            {
                if (!var.UST_GRUP_ID.HasValue)
                    grp.Add(var);
            }
            lue.Properties.DataSource = grp;
            lue.Properties.DisplayMember = "GRUP_ADI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Grup Adý";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("GRUP_ADI", 60, "Grup Adý"));
        }

        public static void GayriMenkulTarafSifatGetir(RepositoryItemLookUpEdit rLue)
        {
            rLue.DataSource = DataRepository.TI_KOD_GAYRIMENKUL_TARAF_SIFATProvider.GetAll();
            rLue.DisplayMember = "TARAF_SIFAT";
            rLue.ValueMember = "ID";
            rLue.NullText = "Seç";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf Sýfat", 100));
        }

        public static void GetAlacakNedenByFoy(AV001_TI_BIL_FOY foy, RepositoryItemGridLookUpEdit rGlue)
        {
            DataRepository.AV001_TI_BIL_ALACAK_NEDENProvider.
                DeepLoad(foy.AV001_TI_BIL_ALACAK_NEDENCollection, false,
                DeepLoadType.IncludeChildren, typeof(TI_KOD_ALACAK_NEDEN));

            rGlue.DataSource = foy.AV001_TI_BIL_ALACAK_NEDENCollection;
            rGlue.ValueMember = "ID";
            rGlue.DisplayMember = "ALACAK_NEDEN_KOD_IDSource";
            rGlue.NullText = "Alacak Nedeni.";
        }

        public static string GrupKýsaAdiGetir(int ID)
        {
            TDI_KOD_KULLANICI_GRUP kgrup = DataRepository.TDI_KOD_KULLANICI_GRUPProvider.GetByID(ID);
            return kgrup.KISA_ADI;
        }

        public static void IlceGetirIleGore(RepositoryItemLookUpEdit lue, int ilId)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "Ýlçe") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetByIL_ID(ilId);//AvukatProLib.Facade.TDI_KOD_ILCE.TDI_KOD_ILCEIlineGoreGetir(ilId);
            lue.DisplayMember = "ILCE";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void IlceGetirIleGore(LookUpEdit lue, int ilId)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "Ýlçe") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetByIL_ID(ilId);
            lue.Properties.DisplayMember = "ILCE";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void IlceGetirOzetli(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "Ýl"), new LookUpColumnInfo("ILCE", 20, "Ýlçe") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ILCE.IlceGetirOzetli();
            lue.Properties.DisplayMember = "Ozet";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void IlceGetirOzetli(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "Ýl"), new LookUpColumnInfo("ILCE", 20, "Ýlçe") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ILCE.IlceGetirOzetli();
            lue.DisplayMember = "Ozet";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void IlceGetirTumu(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "Ýlçe") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetAll();
            lue.Properties.DisplayMember = "ILCE";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void IlceGetirTumu(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "Ýlçe") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetAll();
            lue.DisplayMember = "ILCE";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void IletisimaltKategoriGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILETISIM_ALT_KATEGORIProvider.GetAll();
            lue.NullText = "Seç";
            lue.DisplayMember = "ALT_KATEGORI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Iletiþim Alt Kategori", 100));
        }

        public static void IletisimaltKategoriGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILETISIM_ALT_KATEGORIProvider.GetAll();
            lue.Properties.NullText = "Seç";
            lue.Properties.DisplayMember = "ALT_KATEGORI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Iletiþim Alt Kategori", 100));
        }

        /// <summary>
        /// TDI_KOD_ILETISIM_ANA_KATEGORI
        /// </summary>
        /// <param name="lue"></param>
        public static void IletisimAnaKategoriGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILETISIM_ANA_KATEGORIProvider.GetAll();
            lue.NullText = "Seç";
            lue.DisplayMember = "ANA_KATEGORI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ANA_KATEGORI", "Iletiþim Ana Kategori", 100));
        }

        /// <summary>
        /// TDI_KOD_ILETISIM_ANA_KATEGORI
        /// </summary>
        /// <param name="lue"></param
        public static void IletisimAnaKategoriGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILETISIM_ANA_KATEGORIProvider.GetAll();
            lue.Properties.NullText = "Seç";
            lue.Properties.DisplayMember = "ANA_KATEGORI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ANA_KATEGORI", "Iletiþim Ana Kategori", 100));
        }

        public static void IlGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "Ýl") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetAll(); //AvukatProLib.Facade.TDI_KOD_IL.UlkeyeGoreIlGetir(ulkeId);
            lue.Properties.DisplayMember = "IL";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void IlGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "Ýl") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_IL.UlkeyeGoreIlGetir(ulkeId);
            lue.DisplayMember = "IL";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void IlGetirUlkeyeGore(LookUpEdit lue, int ulkeId)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 10, "Ýl") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetByULKE_ID(ulkeId);
            lue.Properties.DisplayMember = "IL";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void IlGetirUlkeyeGore(RepositoryItemLookUpEdit lue, int ulkeId)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 10, "Ýl") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetByULKE_ID(ulkeId);
            lue.DisplayMember = "IL";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void IsSozlesmeGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SOZLESME_KATEGORI", 10, "Kategori"), new LookUpColumnInfo("SOZLESME_KATEGORI_ACIKLAMA", 30, "Açýklama") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_SOZLESMEProvider.GetAll();// AvukatProLib.Facade.AV001_TDI_BIL_IS_SOZLESME.AV001_TDI_BIL_IS_SOZLESMEGetir();
            lue.DisplayMember = "SOZLESME_KATEGORI_ACIKLAMA";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void IsSozlesmeGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SOZLESME_KATEGORI", 10, "Kategori"), new LookUpColumnInfo("SOZLESME_KATEGORI_ACIKLAMA", 30, "Açýklama") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_SOZLESMEProvider.GetAll();//AvukatProLib.Facade.AV001_TDI_BIL_IS_SOZLESME.AV001_TDI_BIL_IS_SOZLESMEGetir();
            lue.Properties.DisplayMember = "SOZLESME_KATEGORI_ACIKLAMA";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void ItirazSonucuGetir(RepositoryItemLookUpEdit rLue)
        {
            rLue.DataSource = DataRepository.TI_KOD_ITIRAZ_SONUCProvider.GetAll();
            rLue.DisplayMember = "ITIRAZ_SONUC";
            rLue.ValueMember = "ID";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("ITIRAZ_SONUC", 30, "Ýtiraz Sonucu"));
        }

        /// <summary>
        /// TDI_KOD_REHIN_HARC_ISTISNA_BELGE
        /// </summary>
        /// <param name="rlue"></param>
        ///<summary>
        /// TDI_KOD_KAN_GRUP
        /// </summary>
        /// <param name="rlue"></param>
        public static void KanGrupGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_KAN_GRUPProvider.GetAll();
            rlue.NullText = "Seç";
            rlue.DisplayMember = "KAN_GRUP";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("KAN_GRUP", "Kan Grup", 100));
        }

        public static void KanGrupGetir(LookUpEdit lue)
        {
            KanGrupGetir(lue.Properties);
        }

        /// <summary>
        /// TDI_KOD_KIMLIK
        /// </summary>
        /// <param name="rlue"></param>
        public static void KimlikTurGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_KIMLIKProvider.GetAll();

            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("KIMLIK", "Kimlik Tür", 100));
            rlue.NullText = "Seç";
            rlue.DisplayMember = "KIMLIK";
            rlue.ValueMember = "ID";
        }

        public static void KimlikTurGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_KIMLIKProvider.GetAll();
            lue.Properties.DisplayMember = "KIMLIK";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("KIMLIK", "Kimlik Tür", 40));
        }

        /// <summary>
        /// TDI_KOD_KIMLIK_VERILIS_NEDEN
        /// </summary>
        /// <param name="rlue"></param>
        public static void KimlikVerilisNedenGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_KIMLIK_VERILIS_NEDENProvider.GetAll();

            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("VERILIS_NEDEN", "Kimlik Veriliþ Neden", 100));
            rlue.NullText = "Seç";
            rlue.DisplayMember = "VERILIS_NEDEN";
            rlue.ValueMember = "ID";
        }

        public static void KimlikVerilisNedenGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_KIMLIK_VERILIS_NEDENProvider.GetAll();
            lue.Properties.DisplayMember = "VERILIS_NEDEN";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("VERILIS_NEDEN", "Kimlik Veriliþ Neden", 40));
        }

        public static void KullaniciGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetAll();
            lue.Properties.DisplayMember = "KULLANICI_ADI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("KULLANICI_ADI"));
        }

        public static void KullaniciGrupGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = DataRepository.TDI_KOD_KULLANICI_GRUPProvider.GetAll();
            lue.ValueMember = "ID";
            lue.DisplayMember = "KISA_ADI";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADI", 50, "Grup Adý"), new LookUpColumnInfo("KISA_ADI", 50, "Kýsa Adý") });
        }

        /// <summary>
        /// TDI_KOD_MEDENI_HAL
        /// </summary>
        /// <param name="rlue"></param>
        public static void MedeniHalGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_MEDENI_HALProvider.GetAll();

            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("MEDENI_HAL", "Medeni Hal", 100));
            rlue.NullText = "Seç";
            rlue.DisplayMember = "MEDENI_HAL";
            rlue.ValueMember = "ID";
        }

        public static void MedeniHalGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_MEDENI_HALProvider.GetAll();
            lue.Properties.DisplayMember = "MEDENI_HAL";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("MEDENI_HAL", "Medeni Hal", 40));
        }

        public static void MeslekGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("MESLEK", 10, "Meslek") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_MESLEKProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_MESLEK.TDI_KOD_MESLEKGetir();
            lue.Properties.DisplayMember = "MESLEK";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        public static void MeslekGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("MESLEK", 10, "Meslek") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_MESLEKProvider.GetAll(); //AvukatProLib.Facade.TDI_KOD_MESLEK.TDI_KOD_MESLEKGetir();
            lue.DisplayMember = "MESLEK";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        /// <summary>
        /// TDIE_KOD_MODUL
        /// </summary>
        /// <param name="rlue"></param>
        public static void ModulKodGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_MODULProvider.GetAll();
            rlue.NullText = "Seç";
            rlue.DisplayMember = "AD";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("AD", "Modül Ad", 100));
        }

        public static void ModulKodGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_MODULProvider.GetAll();
            lue.Properties.DisplayMember = "AD";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("AD", "Modül Ad", 40));
        }

        public static void OturumAcmaTipiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("OturumAcmaTipi");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            foreach (AvukatProLib.Extras.OturumAcmaModu tipi in Enum.GetValues(typeof(AvukatProLib.Extras.OturumAcmaModu)))
            {
                dt.Rows.Add((int)tipi, tipi.ToString().Replace('_', ' '));
            }
            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Seç";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Oturum Açma Tipi"));
        }

        public static void ParaBicimiAyarla(RepositoryItemSpinEdit rud)
        {
            rud.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.DisplayFormat.FormatString = "###,###,###,###,##0.00";
            rud.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.EditFormat.FormatString = "###,###,###,###,##0.00";
        }

        /// <summary>
        /// TDI_KOD_SEMT
        /// </summary>
        /// <param name="lue"></param>
        public static void SemtGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_SEMTProvider.GetAll();
            lue.NullText = "Seç";
            lue.DisplayMember = "SEMT";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("SEMT", "Semt", 100));
        }

        /// <summary>
        /// TDI_KOD_SEMT
        /// </summary>
        /// <param name="lue"></param
        public static void SemtGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_SEMTProvider.GetAll();
            lue.Properties.NullText = "Seç";
            lue.Properties.DisplayMember = "SEMT";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("SEMT", "Semt", 100));
        }

        public static void SicilTipGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_REHIN_SICIL_TIPProvider.GetAll();//
            lue.ValueMember = "ID";
            lue.DisplayMember = "SICIL_TIP";
            lue.NullText = "Sicil Tipi";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("SICIL_TIP", 20, "Sicil Tipi"));
        }

        public static void SicilTipGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_REHIN_SICIL_TIPProvider.GetAll();//
            lue.Properties.ValueMember = "ID";
            lue.Properties.DisplayMember = "SICIL_TIP";
            lue.Properties.NullText = "Sicil Tipi";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("SICIL_TIP", 20, "Sicil Tipi"));
        }

        public static void SubeGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = DataRepository.TDIE_BIL_KULLANICI_SUBELERIProvider.GetAll();
            lue.ValueMember = "ID";
            lue.DisplayMember = "SUBE_ADI";
            lue.NullText = "Seç";
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SUBE_KODU", 50, "Kod"), new LookUpColumnInfo("SUBE_ADI", 100, "Þube") });
        }

        public static void TarafSifatGetir(RepositoryItemLookUpEdit rlue, string pHangiTarafi, string pAdliBirimBolumKod)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByHANGI_TARAFI(pHangiTarafi).FindAll(
                delegate(TDIE_KOD_TARAF_SIFAT obj)
                {
                    if (obj.ADLI_BIRIM_BOLUM_KOD == "O" || obj.ADLI_BIRIM_BOLUM_KOD == pAdliBirimBolumKod)
                        return true;
                    else
                        return false;
                }
                    );
            rlue.NullText = "Seç";
            rlue.DisplayMember = "SIFAT";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf Sýfat", 100));
        }

        public static void UlkeGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ULKE", 10, "Ülke") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ULKEProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ULKE.TDI_KOD_ULKEGetir();
            lue.DisplayMember = "ULKE";
            lue.ValueMember = "ID";
            lue.NullText = "Seç";
        }

        public static void UlkeGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ULKE", 10, "Ülke") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ULKEProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ULKE.TDI_KOD_ULKEGetir();
            lue.Properties.DisplayMember = "ULKE";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Seç";
        }

        /// <summary>
        /// TDI_KOD_UYRUK
        /// </summary>
        /// <param name="rlue"></param>
        public static void UyrukGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_UYRUKProvider.GetAll();

            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("UYRUK", "Uyruk", 100));
            rlue.NullText = "Seç";
            rlue.DisplayMember = "UYRUK";
            rlue.ValueMember = "ID";
        }

        public static void UyrukGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_UYRUKProvider.GetAll();
            lue.Properties.DisplayMember = "UYRUK";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("UYRUK", "Uyruk", 40));
        }

        public static void YuzdeBicimiAyarla(RepositoryItemSpinEdit rud)
        {
            rud.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.DisplayFormat.FormatString = "\'%\'##0.##";
            rud.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            rud.EditFormat.FormatString = "\'%\'##0.##";
        }
    }
}