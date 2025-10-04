//using System;
//using System.Data;
//using System.Drawing.Drawing2D;

//using DevExpress.XtraEditors.Controls;
//using DevExpress.XtraEditors.Repository;
//using DevExpress.XtraEditors;
//using DevExpress.XtraGrid;

//namespace AvukatProRaporlar.Util
//{
//    public partial class Inits
//    {
//        //public static TDIE_KOD_TARAF_SIFAT TarafSifatGetir(int id)
//        //{
//        //    TDIE_KOD_TARAF_SIFAT sifat = AvukatProLib2.Data.DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(id);

// // return sifat; //}

// //public static TDIE_KOD_TARAF_SIFAT TarafSifatGetir(int? id) //{ // if (!id.HasValue) // return
// null; // TDIE_KOD_TARAF_SIFAT sifat =
// AvukatProLib2.Data.DataRepository.TDIE_KOD_TARAF_SIFATProvider.GetByID(id.Value);

// // return sifat; //}

// /// <summary> /// AV001_TDI_BIL_CARI (PERSONEL_MI=TRUE) /// </summary> ///
// <param name="lue"></param> //internal static void CariPersonelGetir(RepositoryItemLookUpEdit lue)
// //{ // TList<AV001_TDI_BIL_CARI> listem
// =AvukatProLib2.Data.DataRepository.AV001_TDI_BIL_CARIProvider.Find("PERSONEL_MI='True'"); //
// listem.Sort("AD ASC"); // lue.DataSource = listem; // lue.NullText = "Seç"; // lue.DisplayMember
// = "AD"; // lue.ValueMember = "ID"; // lue.Columns.Clear(); // lue.Columns.AddRange(new
// LookUpColumnInfo[] { new LookUpColumnInfo("KOD", 10, "Kod"), new LookUpColumnInfo("AD", 30, "Ad")
// });

// //} //public static void AraKararTipGetir(RepositoryItemLookUpEdit lue) //{ // DataTable dt = new
// DataTable("AraKararTip"); // dt.Columns.Add("ID"); // dt.Columns.Add("ACIKLAMA"); // foreach
// (AvukatProLib.Extras.AraKararTip tipi in Enum.GetValues(typeof(AvukatProLib.Extras.AraKararTip)))
// // { // dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " ")); // } // lue.DataSource = dt;
// // lue.DisplayMember = "ACIKLAMA"; // lue.NullText = "Seç"; // lue.ValueMember = "ID"; //
// lue.Columns.Clear(); // lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Ara Karar Tipi"));

// //} //public static void ModulGetir(RepositoryItemLookUpEdit lue) //{ // DataTable dt = new
// DataTable("Modul"); // dt.Columns.Add("ID"); // dt.Columns.Add("ACIKLAMA"); // foreach (Modul
// tipi in Enum.GetValues(typeof(Modul))) // { // dt.Rows.Add((int)tipi,
// tipi.ToString().Replace("_", " ")); // } // lue.DataSource = dt; // lue.DisplayMember =
// "ACIKLAMA"; // lue.NullText = "Seç"; // lue.ValueMember = "ID"; // lue.Columns.Clear(); //
// lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Cari Ýþlem Tipi"));

// //} //public static void MasrafAvansTipGetir(RepositoryItemLookUpEdit lue) //{ // DataTable dt =
// new DataTable("MAvans"); // dt.Columns.Add("ID"); // dt.Columns.Add("ACIKLAMA"); // foreach
// (MasrafAvansTip tipi in Enum.GetValues(typeof(MasrafAvansTip))) // { // dt.Rows.Add((int)tipi,
// tipi.ToString().Replace("_", " ")); // } // lue.DataSource = dt; // lue.DisplayMember =
// "ACIKLAMA"; // lue.NullText = "Seç"; // lue.ValueMember = "ID"; // lue.Columns.Clear(); //
// lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Tipi"));

// //} public static void RenkUygulamaTipiGetir(RepositoryItemLookUpEdit lue) { DataTable dt = new
// DataTable("AraKararTip"); dt.Columns.Add("ID"); dt.Columns.Add("ACIKLAMA"); dt.Rows.Add(true,
// "Tüm Satýra Uygula"); dt.Rows.Add(false, "Sadece Hücreye Uygula");

// lue.DataSource = dt; lue.DisplayMember = "ACIKLAMA"; lue.NullText = "Seç"; lue.ValueMember =
// "ID"; lue.Columns.Clear(); lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Uygulama
// Tipi"));

// } public static void RenkGecisYonuGetir(RepositoryItemLookUpEdit lue) { DataTable dt = new
// DataTable("AraKararTip"); dt.Columns.Add("ID"); dt.Columns.Add("ACIKLAMA");

// foreach (System.Drawing.Drawing2D.LinearGradientMode tipi in
// Enum.GetValues(typeof(System.Drawing.Drawing2D.LinearGradientMode))) { switch (tipi) { case
// LinearGradientMode.Horizontal: dt.Rows.Add(tipi, "Yatay"); break; case
// LinearGradientMode.Vertical: dt.Rows.Add(tipi, "Dikey"); break; case
// LinearGradientMode.ForwardDiagonal: dt.Rows.Add(tipi, "Ýleri Çapraz"); break; case
// LinearGradientMode.BackwardDiagonal: dt.Rows.Add(tipi, "Geri Çapraz"); break;

// } }

// lue.DataSource = dt; lue.DisplayMember = "ACIKLAMA"; lue.NullText = "Seç"; lue.ValueMember =
// "ID"; lue.Columns.Clear(); lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Geçiþ
// Yönü"));

// } public static void BicimKosuluGetir(RepositoryItemLookUpEdit lue) { DataTable dt = new
// DataTable("AraKararTip"); dt.Columns.Add("ID"); dt.Columns.Add("ACIKLAMA");

// foreach (DevExpress.XtraGrid.FormatConditionEnum tipi in
// Enum.GetValues(typeof(DevExpress.XtraGrid.FormatConditionEnum))) { switch (tipi) { case
// FormatConditionEnum.None: dt.Rows.Add(tipi, "Yok"); break; case FormatConditionEnum.Equal:
// dt.Rows.Add(tipi, "Eþit"); break; case FormatConditionEnum.NotEqual: dt.Rows.Add(tipi, "Eþit
// deðil"); break; case FormatConditionEnum.Between: dt.Rows.Add(tipi, "Arasýnda"); break; case
// FormatConditionEnum.NotBetween: dt.Rows.Add(tipi, "Arasýnda deðil"); break; case
// FormatConditionEnum.Less: dt.Rows.Add(tipi, "Küçüktür"); break; case FormatConditionEnum.Greater:
// dt.Rows.Add(tipi, "Büyüktür"); break; case FormatConditionEnum.GreaterOrEqual: dt.Rows.Add(tipi,
// "Büyük yada eþittir"); break; case FormatConditionEnum.LessOrEqual: dt.Rows.Add(tipi, "Küçük yada
// eþittir");

// break; } }

// lue.DataSource = dt; lue.DisplayMember = "ACIKLAMA"; lue.NullText = "Seç"; lue.ValueMember =
// "ID"; lue.Columns.Clear(); lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Geçiþ
// Yönü"));

// }

// ///<summary> ///TI_KOD_ALACAK_NEDEN ///</summary> ///<param name="lue"></param> //public static
// void AlacakNedenKodGetir(RepositoryItemLookUpEdit lue) //{ // lue.DataSource =
// AvukatProLib2.Data.DataRepository.TI_KOD_ALACAK_NEDENProvider.GetAll(); // lue.NullText = "Seç";
// // lue.DisplayMember = "ALACAK_NEDENI"; // lue.ValueMember = "ID"; // lue.Columns.Clear(); //
// lue.Columns.Add(new LookUpColumnInfo("ALACAK_NEDENI", "Alacak Neden", 100));

// //} ///<summary> ///TDIE_KOD_PROJE_TIP ///</summary> ///<param name="lue"></param> public static
// void ProjeTipGetir(RepositoryItemLookUpEdit lue) { lue.DataSource =
// AvukatProLib2.Data.DataRepository.TDIE_KOD_PROJE_TIPProvider.GetAll(); lue.NullText =
// "<Proje Tipi>"; lue.DisplayMember = "TIP"; lue.ValueMember = "ID"; lue.Columns.Clear();
// lue.Columns.Add(new LookUpColumnInfo("TIP", "Proje Tipi", 100));

// } ///<summary> ///TDIE_KOD_PROJE_DURUM ///</summary> ///<param name="lue"></param> public static
// void ProjeDurumGetir(RepositoryItemLookUpEdit lue) { lue.DataSource =
// AvukatProLib2.Data.DataRepository.TDIE_KOD_PROJE_DURUMProvider.GetAll(); lue.NullText =
// "<Durum>"; lue.DisplayMember = "DURUM"; lue.ValueMember = "ID"; lue.Columns.Clear();
// lue.Columns.Add(new LookUpColumnInfo("DURUM", "Durum", 100));

// } ///<summary> ///TDIE_KOD_PROJE_OZEL_KOD ///</summary> ///<param name="lue"></param> public
// static void ProjeOzelKodGetir(RepositoryItemLookUpEdit lue) { lue.DataSource =
// AvukatProLib2.Data.DataRepository.TDIE_KOD_PROJE_OZEL_KODProvider.GetAll(); lue.NullText =
// "<Özel Kod>"; lue.DisplayMember = "OZEL_KOD"; lue.ValueMember = "ID";

// lue.Columns.Clear(); lue.Columns.Add(new LookUpColumnInfo("OZEL_KOD", "Durum", 100));

// } ///<summary> /// ///</summary> ///<param name="lue"></param>
// ///<typeparam name="T"></typeparam> /////<returns></returns> //public static TList<T>
// DataSo<T>(RepositoryItemLookUpEdit lue) where T:IEntity,new () //{ // return (TList<T>)
// lue.DataSource; //}

// public static void DavaTalepGetir(LookUpEdit lue) { lue.Properties.DataSource =
// AvukatProLib2.Data.DataRepository.TD_KOD_DAVA_TALEPProvider.GetAll();
// lue.Properties.DisplayMember = "DAVA_TALEP"; lue.Properties.ValueMember = "ADLI_BIRIM_BOLUM_ID";
// lue.Properties.Columns.Clear(); lue.Properties.Columns.Add(new LookUpColumnInfo("DAVA_TALEP",
// "Talep", 40));

// }

// public static void DavaTalepGetir(RepositoryItemLookUpEdit lue) { lue.DataSource =
// AvukatProLib2.Data.DataRepository.TD_KOD_DAVA_TALEPProvider.GetAll();

// lue.Columns.Clear(); lue.Columns.Add(new LookUpColumnInfo("DAVA_TALEP", "Talep", 40));
// lue.DisplayMember = "DAVA_TALEP"; lue.ValueMember = "ID";

// }

// internal static void BankaSubeGetir(LookUpEdit lkBankaSubead, int p) { throw new
// NotImplementedException(); }

// internal static void CariAvukatGetir(LookUpEdit lkSorumluA1) { throw new
// NotImplementedException(); } }
//}