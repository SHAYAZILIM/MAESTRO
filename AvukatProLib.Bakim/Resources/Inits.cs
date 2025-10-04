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
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADRES_TUR", 10, "T�r") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ADRES_TURProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ADRES_TUR.TDI_KOD_ADRES_TURGetir();
            lue.Properties.DisplayMember = "ADRES_TUR";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
        }

        public static void AdresTurGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADRES_TUR", 10, "T�r") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ADRES_TURProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ADRES_TUR.TDI_KOD_ADRES_TURGetir();
            lue.DisplayMember = "ADRES_TUR";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
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
            lue.Properties.NullText = "Se�";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ba�lant� Tipi"));
        }

        public static void BankaGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_BANKAProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_BANKA.TDI_KOD_BANKAGetir();
            lue.DisplayMember = "BANKA";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("BANKA", 40, "Banka"));
        }

        public static void BankaGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_BANKAProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_BANKA.TDI_KOD_BANKAGetir();
            lue.Properties.DisplayMember = "BANKA";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("BANKA", 40, "Banka"));
        }

        public static void BelgeTurGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_BELGE_TURProvider.GetAll();
            rlue.NullText = "Se�";
            rlue.DisplayMember = "BELGE_TURU";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("BELGE_TURU", "Belge T�r�", 100));
        }

        public static void BelgeTurGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_BELGE_TURProvider.GetAll();
            lue.Properties.DisplayMember = "BELGE_TURU";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("BELGE_TURU", "Belge T�r�", 40));
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
            lue.Properties.NullText = "Se�";
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
            lue.NullText = "Se�";
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
            //lue.NullText = "Se�";
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
            lue.Properties.NullText = "Se�";
            lue.Properties.ValueMember = "ID";

            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "�ah�s Tipi"));
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
            lue.NullText = "Se�";
            lue.ValueMember = "ID";

            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "�ah�s Tipi"));
        }

        public static void CariUnvanGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("UNVAN", 10, "�nvan") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_UNVANProvider.GetAll(); //AvukatProLib.Facade.TDI_KOD_UNVAN.TDI_KOD_UNVANGetir();
            lue.DisplayMember = "UNVAN";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        public static void CariUnvanGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("UNVAN", 10, "�nvan") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_UNVANProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_UNVAN.TDI_KOD_UNVANGetir();
            lue.Properties.DisplayMember = "UNVAN";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
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
            rlue.NullText = "Se�";
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
            lue.Properties.NullText = "Se�";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ba�lant� Tipi"));
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
            rlue.NullText = "Se�";
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
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TUR", 10, "T�r") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_FIRMA_TURProvider.GetAll();// AvukatProLib.Facade.TDI_KOD_FIRMA_TUR.TDI_KOD_FIRMA_TURGetir();
            lue.Properties.DisplayMember = "TUR";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
        }

        public static void FirmaTurGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("TUR", 10, "T�r") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_FIRMA_TURProvider.GetAll(); //AvukatProLib.Facade.TDI_KOD_FIRMA_TUR.TDI_KOD_FIRMA_TURGetir();
            lue.DisplayMember = "TUR";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        public static void FormAltTipi(LookUpEdit lue, int ustform)
        {
            lue.Properties.DataSource = DataRepository.CS_KOD_FORM_GRUPProvider.GetByUST_GRUP_ID(ustform);
            lue.Properties.DisplayMember = "GRUP_ADI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Grup Alt Tipi";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("GRUP_ADI", 60, "Grup Ad�"));
        }

        public static void FormAltTipiTumu(LookUpEdit lue, int ustform)
        {
            lue.Properties.DataSource = DataRepository.CS_KOD_FORM_GRUPProvider.GetByUST_GRUP_ID(ustform);
            lue.Properties.DisplayMember = "GRUP_ADI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Grup Alt Tipi";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("GRUP_ADI", 60, "Grup Ad�"));
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
            lue.Properties.NullText = "Grup Ad�";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("GRUP_ADI", 60, "Grup Ad�"));
        }

        public static void GayriMenkulTarafSifatGetir(RepositoryItemLookUpEdit rLue)
        {
            rLue.DataSource = DataRepository.TI_KOD_GAYRIMENKUL_TARAF_SIFATProvider.GetAll();
            rLue.DisplayMember = "TARAF_SIFAT";
            rLue.ValueMember = "ID";
            rLue.NullText = "Se�";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf S�fat", 100));
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

        public static string GrupK�saAdiGetir(int ID)
        {
            TDI_KOD_KULLANICI_GRUP kgrup = DataRepository.TDI_KOD_KULLANICI_GRUPProvider.GetByID(ID);
            return kgrup.KISA_ADI;
        }

        public static void IlceGetirIleGore(RepositoryItemLookUpEdit lue, int ilId)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "�l�e") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetByIL_ID(ilId);//AvukatProLib.Facade.TDI_KOD_ILCE.TDI_KOD_ILCEIlineGoreGetir(ilId);
            lue.DisplayMember = "ILCE";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        public static void IlceGetirIleGore(LookUpEdit lue, int ilId)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "�l�e") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetByIL_ID(ilId);
            lue.Properties.DisplayMember = "ILCE";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
        }

        public static void IlceGetirOzetli(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "�l"), new LookUpColumnInfo("ILCE", 20, "�l�e") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ILCE.IlceGetirOzetli();
            lue.Properties.DisplayMember = "Ozet";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
        }

        public static void IlceGetirOzetli(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "�l"), new LookUpColumnInfo("ILCE", 20, "�l�e") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ILCE.IlceGetirOzetli();
            lue.DisplayMember = "Ozet";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        public static void IlceGetirTumu(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "�l�e") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetAll();
            lue.Properties.DisplayMember = "ILCE";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
        }

        public static void IlceGetirTumu(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ILCE", 10, "�l�e") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILCEProvider.GetAll();
            lue.DisplayMember = "ILCE";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        public static void IletisimaltKategoriGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILETISIM_ALT_KATEGORIProvider.GetAll();
            lue.NullText = "Se�";
            lue.DisplayMember = "ALT_KATEGORI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Ileti�im Alt Kategori", 100));
        }

        public static void IletisimaltKategoriGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILETISIM_ALT_KATEGORIProvider.GetAll();
            lue.Properties.NullText = "Se�";
            lue.Properties.DisplayMember = "ALT_KATEGORI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ALT_KATEGORI", "Ileti�im Alt Kategori", 100));
        }

        /// <summary>
        /// TDI_KOD_ILETISIM_ANA_KATEGORI
        /// </summary>
        /// <param name="lue"></param>
        public static void IletisimAnaKategoriGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILETISIM_ANA_KATEGORIProvider.GetAll();
            lue.NullText = "Se�";
            lue.DisplayMember = "ANA_KATEGORI";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ANA_KATEGORI", "Ileti�im Ana Kategori", 100));
        }

        /// <summary>
        /// TDI_KOD_ILETISIM_ANA_KATEGORI
        /// </summary>
        /// <param name="lue"></param
        public static void IletisimAnaKategoriGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILETISIM_ANA_KATEGORIProvider.GetAll();
            lue.Properties.NullText = "Se�";
            lue.Properties.DisplayMember = "ANA_KATEGORI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("ANA_KATEGORI", "Ileti�im Ana Kategori", 100));
        }

        public static void IlGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "�l") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetAll(); //AvukatProLib.Facade.TDI_KOD_IL.UlkeyeGoreIlGetir(ulkeId);
            lue.Properties.DisplayMember = "IL";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
        }

        public static void IlGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 20, "�l") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_IL.UlkeyeGoreIlGetir(ulkeId);
            lue.DisplayMember = "IL";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        public static void IlGetirUlkeyeGore(LookUpEdit lue, int ulkeId)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 10, "�l") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetByULKE_ID(ulkeId);
            lue.Properties.DisplayMember = "IL";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
        }

        public static void IlGetirUlkeyeGore(RepositoryItemLookUpEdit lue, int ulkeId)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("IL", 10, "�l") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ILProvider.GetByULKE_ID(ulkeId);
            lue.DisplayMember = "IL";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        public static void IsSozlesmeGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SOZLESME_KATEGORI", 10, "Kategori"), new LookUpColumnInfo("SOZLESME_KATEGORI_ACIKLAMA", 30, "A��klama") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_SOZLESMEProvider.GetAll();// AvukatProLib.Facade.AV001_TDI_BIL_IS_SOZLESME.AV001_TDI_BIL_IS_SOZLESMEGetir();
            lue.DisplayMember = "SOZLESME_KATEGORI_ACIKLAMA";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        public static void IsSozlesmeGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SOZLESME_KATEGORI", 10, "Kategori"), new LookUpColumnInfo("SOZLESME_KATEGORI_ACIKLAMA", 30, "A��klama") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_IS_SOZLESMEProvider.GetAll();//AvukatProLib.Facade.AV001_TDI_BIL_IS_SOZLESME.AV001_TDI_BIL_IS_SOZLESMEGetir();
            lue.Properties.DisplayMember = "SOZLESME_KATEGORI_ACIKLAMA";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
        }

        public static void ItirazSonucuGetir(RepositoryItemLookUpEdit rLue)
        {
            rLue.DataSource = DataRepository.TI_KOD_ITIRAZ_SONUCProvider.GetAll();
            rLue.DisplayMember = "ITIRAZ_SONUC";
            rLue.ValueMember = "ID";
            rLue.Columns.Clear();
            rLue.Columns.Add(new LookUpColumnInfo("ITIRAZ_SONUC", 30, "�tiraz Sonucu"));
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
            rlue.NullText = "Se�";
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
            rlue.Columns.Add(new LookUpColumnInfo("KIMLIK", "Kimlik T�r", 100));
            rlue.NullText = "Se�";
            rlue.DisplayMember = "KIMLIK";
            rlue.ValueMember = "ID";
        }

        public static void KimlikTurGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_KIMLIKProvider.GetAll();
            lue.Properties.DisplayMember = "KIMLIK";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("KIMLIK", "Kimlik T�r", 40));
        }

        /// <summary>
        /// TDI_KOD_KIMLIK_VERILIS_NEDEN
        /// </summary>
        /// <param name="rlue"></param>
        public static void KimlikVerilisNedenGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_KIMLIK_VERILIS_NEDENProvider.GetAll();

            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("VERILIS_NEDEN", "Kimlik Verili� Neden", 100));
            rlue.NullText = "Se�";
            rlue.DisplayMember = "VERILIS_NEDEN";
            rlue.ValueMember = "ID";
        }

        public static void KimlikVerilisNedenGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_KIMLIK_VERILIS_NEDENProvider.GetAll();
            lue.Properties.DisplayMember = "VERILIS_NEDEN";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("VERILIS_NEDEN", "Kimlik Verili� Neden", 40));
        }

        public static void KullaniciGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = DataRepository.TDI_BIL_KULLANICI_LISTESIProvider.GetAll();
            lue.Properties.DisplayMember = "KULLANICI_ADI";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("KULLANICI_ADI"));
        }

        public static void KullaniciGrupGetir(RepositoryItemLookUpEdit lue)
        {
            lue.DataSource = DataRepository.TDI_KOD_KULLANICI_GRUPProvider.GetAll();
            lue.ValueMember = "ID";
            lue.DisplayMember = "KISA_ADI";
            lue.NullText = "Se�";
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ADI", 50, "Grup Ad�"), new LookUpColumnInfo("KISA_ADI", 50, "K�sa Ad�") });
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
            rlue.NullText = "Se�";
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
            lue.Properties.NullText = "Se�";
        }

        public static void MeslekGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("MESLEK", 10, "Meslek") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_MESLEKProvider.GetAll(); //AvukatProLib.Facade.TDI_KOD_MESLEK.TDI_KOD_MESLEKGetir();
            lue.DisplayMember = "MESLEK";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        /// <summary>
        /// TDIE_KOD_MODUL
        /// </summary>
        /// <param name="rlue"></param>
        public static void ModulKodGetir(RepositoryItemLookUpEdit rlue)
        {
            rlue.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_MODULProvider.GetAll();
            rlue.NullText = "Se�";
            rlue.DisplayMember = "AD";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("AD", "Mod�l Ad", 100));
        }

        public static void ModulKodGetir(LookUpEdit lue)
        {
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDIE_KOD_MODULProvider.GetAll();
            lue.Properties.DisplayMember = "AD";
            lue.Properties.ValueMember = "ID";
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.Add(new LookUpColumnInfo("AD", "Mod�l Ad", 40));
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
            lue.NullText = "Se�";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Oturum A�ma Tipi"));
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
            lue.NullText = "Se�";
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
            lue.Properties.NullText = "Se�";
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
            lue.NullText = "Se�";
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SUBE_KODU", 50, "Kod"), new LookUpColumnInfo("SUBE_ADI", 100, "�ube") });
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
            rlue.NullText = "Se�";
            rlue.DisplayMember = "SIFAT";
            rlue.ValueMember = "ID";
            rlue.Columns.Clear();
            rlue.Columns.Add(new LookUpColumnInfo("SIFAT", "Taraf S�fat", 100));
        }

        public static void UlkeGetir(RepositoryItemLookUpEdit lue)
        {
            lue.Columns.Clear();
            lue.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ULKE", 10, "�lke") });
            lue.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ULKEProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ULKE.TDI_KOD_ULKEGetir();
            lue.DisplayMember = "ULKE";
            lue.ValueMember = "ID";
            lue.NullText = "Se�";
        }

        public static void UlkeGetir(LookUpEdit lue)
        {
            lue.Properties.Columns.Clear();
            lue.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("ULKE", 10, "�lke") });
            lue.Properties.DataSource = AvukatProLib2.Data.DataRepository.TDI_KOD_ULKEProvider.GetAll();//AvukatProLib.Facade.TDI_KOD_ULKE.TDI_KOD_ULKEGetir();
            lue.Properties.DisplayMember = "ULKE";
            lue.Properties.ValueMember = "ID";
            lue.Properties.NullText = "Se�";
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
            rlue.NullText = "Se�";
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