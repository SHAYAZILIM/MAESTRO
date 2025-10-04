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
                        dt.Rows.Add(tipi, "E�it");
                        break;

                    case FormatConditionEnum.NotEqual:
                        dt.Rows.Add(tipi, "E�it de�il");
                        break;

                    case FormatConditionEnum.Between:
                        dt.Rows.Add(tipi, "Aras�nda");
                        break;

                    case FormatConditionEnum.NotBetween:
                        dt.Rows.Add(tipi, "Aras�nda de�il");
                        break;

                    case FormatConditionEnum.Less:
                        dt.Rows.Add(tipi, "K���kt�r");
                        break;

                    case FormatConditionEnum.Greater:
                        dt.Rows.Add(tipi, "B�y�kt�r");
                        break;

                    case FormatConditionEnum.GreaterOrEqual:
                        dt.Rows.Add(tipi, "B�y�k yada e�ittir");
                        break;

                    case FormatConditionEnum.LessOrEqual:
                        dt.Rows.Add(tipi, "K���k yada e�ittir");

                        break;
                }
            }

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Se�";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Ge�i� Y�n�"));
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
                        dt.Rows.Add(tipi, "�leri �apraz");
                        break;

                    case LinearGradientMode.BackwardDiagonal:
                        dt.Rows.Add(tipi, "Geri �apraz");
                        break;
                }
            }

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Se�";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Ge�i� Y�n�"));
        }

        public static void RenkUygulamaTipiGetir(RepositoryItemLookUpEdit lue)
        {
            DataTable dt = new DataTable("AraKararTip");
            dt.Columns.Add("ID");
            dt.Columns.Add("ACIKLAMA");
            dt.Rows.Add(true, "T�m Sat�ra Uygula");
            dt.Rows.Add(false, "Sadece H�creye Uygula");

            lue.DataSource = dt;
            lue.DisplayMember = "ACIKLAMA";
            lue.NullText = "Se�";
            lue.ValueMember = "ID";
            lue.Columns.Clear();
            lue.Columns.Add(new LookUpColumnInfo("ACIKLAMA", 30, "Renk Uygulama Tipi"));
        }
    }
}