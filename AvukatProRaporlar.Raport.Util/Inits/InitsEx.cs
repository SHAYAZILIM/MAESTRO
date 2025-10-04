using AvukatProLib;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using RaporDataSource.TableDB;
using RaporDataSource.ViewDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AvukatProRaporlar.Raport.Util.Inits
{
    public class InitsEx
    {
        public static List<CompInfo> comp;
        public static Connection conn;
        public static DBDataContext db;
        public static AvukatProViewDataContext dbV;
        private static RepositoryItemLookUpEdit _arakarartip;
        private static RepositoryItemLookUpEdit _dovizTipGetir;
        private static RepositoryItemLookUpEdit _faturahedeftip;
        private static RepositoryItemLookUpEdit _faturakapsamtip;
        private static RepositoryItemLookUpEdit _kontrolkim;
        private static RepositoryItemLookUpEdit _masrafavanstip;
        private static RepositoryItemLookUpEdit _segmentBolumGetir;
        private static RepositoryItemLookUpEdit _subeKod;
        private static RepositoryItemLookUpEdit _TarafKod;
        private static RepositoryItemSpinEdit rud;

        public static RepositoryItemLookUpEdit AraKararTip
        {
            get
            {
                if (_arakarartip == null)
                {
                    _arakarartip = new RepositoryItemLookUpEdit();
                    if (comp == null)
                    {
                        conn = new Connection();
                        conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
                        db = new DBDataContext(conn.MyConnection);
                    }
                    DataTable dt = new DataTable("AraKararTip");
                    dt.Columns.Add("ID");
                    dt.Columns.Add("ACIKLAMA");
                    foreach (Enums.AraKararTip tipi in Enum.GetValues(typeof(Enums.AraKararTip)))
                    {
                        dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                    }
                    _arakarartip.DataSource = dt;
                    _arakarartip.DisplayMember = "ACIKLAMA";
                    _arakarartip.ValueMember = "ID";
                    _arakarartip.NullText = "Seç";
                    _arakarartip.Columns.Clear();
                    _arakarartip.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 10, "Ara Karar Tipi"));
                }

                return _arakarartip;
            }
            set { _arakarartip = value; }
        }

        public static RepositoryItemLookUpEdit DovizTipGetir
        {
            get
            {
                if (_dovizTipGetir == null)
                {
                    _dovizTipGetir = new RepositoryItemLookUpEdit();
                    if (comp == null)
                    {
                        conn = new Connection();
                        conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
                        db = new DBDataContext(conn.MyConnection);
                    }

                    _dovizTipGetir.DataSource = db.TDI_KOD_DOVIZ_TIPs;
                    _dovizTipGetir.DisplayMember = "DOVIZ_KODU";
                    _dovizTipGetir.ValueMember = "ID";
                    _dovizTipGetir.NullText = "Seç";
                    _dovizTipGetir.Columns.Clear();
                    _dovizTipGetir.Columns.Add(new LookUpColumnInfo("DOVIZ_KODU", 10, "Birim"));
                }

                return _dovizTipGetir;
            }
            set { _dovizTipGetir = value; }
        }

        public static RepositoryItemLookUpEdit FaturaHedefTip
        {
            get
            {
                if (_faturahedeftip == null)
                {
                    _faturahedeftip = new RepositoryItemLookUpEdit();
                    if (comp == null)
                    {
                        conn = new Connection();
                        conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
                        db = new DBDataContext(conn.MyConnection);
                    }
                    DataTable dt = new DataTable("FaturaHedefTip");
                    dt.Columns.Add("ID");
                    dt.Columns.Add("ACIKLAMA");
                    foreach (Enums.FaturaHedefTip tipi in Enum.GetValues(typeof(Enums.FaturaHedefTip)))
                    {
                        dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                    }
                    _faturahedeftip.DataSource = dt;
                    _faturahedeftip.DisplayMember = "ACIKLAMA";
                    _faturahedeftip.ValueMember = "ID";
                    _faturahedeftip.NullText = "Seç";
                    _faturahedeftip.Columns.Clear();
                    _faturahedeftip.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 10, "Fatura Hedef Tipi"));
                }

                return _faturahedeftip;
            }
            set { _faturahedeftip = value; }
        }

        public static RepositoryItemLookUpEdit FaturaKapsamTip
        {
            get
            {
                if (_faturakapsamtip == null)
                {
                    _faturakapsamtip = new RepositoryItemLookUpEdit();
                    if (comp == null)
                    {
                        conn = new Connection();
                        conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
                        db = new DBDataContext(conn.MyConnection);
                    }

                    DataTable dt = new DataTable("FaturaKapsamTip");
                    dt.Columns.Add("ID");
                    dt.Columns.Add("ACIKLAMA");
                    foreach (Enums.FaturaKapsamTip tipi in Enum.GetValues(typeof(Enums.FaturaKapsamTip)))
                    {
                        dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                    }
                    _faturakapsamtip.DataSource = dt;
                    _faturakapsamtip.DisplayMember = "ACIKLAMA";
                    _faturakapsamtip.ValueMember = "ID";
                    _faturakapsamtip.NullText = "Seç";
                    _faturakapsamtip.Columns.Clear();
                    _faturakapsamtip.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 10, "Fatura Kapsam Tipi"));
                }

                return _faturakapsamtip;
            }
            set { _faturakapsamtip = value; }
        }

        public static RepositoryItemLookUpEdit KontrolKim
        {
            get
            {
                if (_kontrolkim == null)
                {
                    _kontrolkim = new RepositoryItemLookUpEdit();
                    if (comp == null)
                    {
                        conn = new Connection();
                        conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
                        db = new DBDataContext(conn.MyConnection);
                    }

                    _kontrolkim.DataSource = db.TDI_BIL_KULLANICI_LISTESIs;
                    _kontrolkim.DisplayMember = "KULLANICI_ADI";
                    _kontrolkim.ValueMember = "ID";
                    _kontrolkim.NullText = "Seç";
                    _kontrolkim.Columns.Clear();
                    _kontrolkim.Columns.Add(new LookUpColumnInfo("KULLANICI_ADI", 10, "Kullanıcı"));
                }

                return _kontrolkim;
            }
            set { _kontrolkim = value; }
        }

        public static RepositoryItemLookUpEdit MasrafAvansTip
        {
            get
            {
                if (_masrafavanstip == null)
                {
                    _masrafavanstip = new RepositoryItemLookUpEdit();
                    if (comp == null)
                    {
                        conn = new Connection();
                        conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
                        db = new DBDataContext(conn.MyConnection);
                    }
                    DataTable dt = new DataTable("MasrafAvansTip");
                    dt.Columns.Add("ID");
                    dt.Columns.Add("ACIKLAMA");
                    foreach (Enums.MasrafAvansTip tipi in Enum.GetValues(typeof(Enums.MasrafAvansTip)))
                    {
                        dt.Rows.Add((int)tipi, tipi.ToString().Replace("_", " "));
                    }
                    _masrafavanstip.DataSource = dt;
                    _masrafavanstip.DisplayMember = "ACIKLAMA";
                    _masrafavanstip.ValueMember = "ID";
                    _masrafavanstip.NullText = "Seç";
                    _masrafavanstip.Columns.Clear();
                    _masrafavanstip.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 10, "Masraf Avans Tipi"));
                }

                return _masrafavanstip;
            }
            set { _masrafavanstip = value; }
        }

        public static RepositoryItemSpinEdit ParaBicimiAyarla
        {
            get
            {
                rud = new RepositoryItemSpinEdit();
                rud.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                rud.DisplayFormat.FormatString = "###,###,###,###,##0.00";
                rud.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                rud.EditFormat.FormatString = "###,###,###,###,##0.00";
                return rud;
            }
            set
            {
                rud = value;
            }
        }

        public static RepositoryItemLookUpEdit SegmnetBolumGetir
        {
            get
            {
                if (_segmentBolumGetir == null)
                {
                    _segmentBolumGetir = new RepositoryItemLookUpEdit();

                    _segmentBolumGetir.DataSource = dbV.TDI_KOD_SEGMENTs;
                    _segmentBolumGetir.DisplayMember = "SEGMENT";
                    _segmentBolumGetir.ValueMember = "ID";
                    _segmentBolumGetir.NullText = "Seç";
                    _segmentBolumGetir.Columns.Clear();
                    _segmentBolumGetir.Columns.Add(new LookUpColumnInfo("SEGMENT", 10, "Birim"));
                }

                return _segmentBolumGetir;
            }
            set { _segmentBolumGetir = value; }
        }

        public static RepositoryItemLookUpEdit SubeKod
        {
            get
            {
                if (_subeKod == null)
                {
                    _subeKod = new RepositoryItemLookUpEdit();

                    if (comp == null)
                    {
                        conn = new Connection();
                        conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
                        db = new DBDataContext(conn.MyConnection);
                    }

                    _subeKod.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("SUBE_ADI", 20, "Kod"), new LookUpColumnInfo("AD", 20, "Ad") });
                    _subeKod.DataSource = db.TDIE_BIL_KULLANICI_SUBELERIs;
                    _subeKod.ValueMember = "ID";
                    _subeKod.DisplayMember = "SUBE_ADI";
                    _subeKod.NullText = "Seç";
                }
                return _subeKod;
            }
            set
            {
                _subeKod = value;
            }
        }

        public static RepositoryItemLookUpEdit TarafKodu
        {
            get
            {
                if (_TarafKod == null)
                {
                    _TarafKod = new RepositoryItemLookUpEdit();
                    if (comp == null)
                    {
                        conn = new Connection();
                        conn.MyConnection = CompInfo.CmpNfoList[0].ConStr;
                        db = new DBDataContext(conn.MyConnection);
                    }
                    DataTable dt = new DataTable("TarafKodu");

                    _TarafKod.DataSource = db.TDI_KOD_TARAFs;
                    _TarafKod.DisplayMember = "TIP";
                    _TarafKod.ValueMember = "ID";
                    _TarafKod.NullText = "Seç";
                    _TarafKod.Columns.Clear();
                    _TarafKod.Columns.Add(new LookUpColumnInfo("TIP", 10, "T.K"));
                }

                return _TarafKod;
            }
            set { _TarafKod = value; }
        }
    }
}