using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Data;
using System.Drawing.Drawing2D;

namespace AvukatProLib.Controls
{
    public class Inits
    {
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
    }
}