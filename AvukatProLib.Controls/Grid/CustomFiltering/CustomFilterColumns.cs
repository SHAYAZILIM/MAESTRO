using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;

namespace AvukatProLib.Controls.Grid.CustomFiltering
{
    public class CustomFilterColumns
    {
        public CustomFilterColumns()
        {
        }

        public CustomFilterColumns(string text, string value, ClauseType[] operatorType, Type datatype)
            : this(text, value, operatorType, datatype, "FieldColumn" + counter.ToString(), "")
        {
        }

        public CustomFilterColumns(string text, string value, ClauseType[] operatorType, Type datatype, string column)
            : this(text, value, operatorType, datatype, column, "")
        {
        }

        public CustomFilterColumns(string text, string value, ClauseType[] operatorType, Type datatype, string column, params string[] illegalColumn)
        {
            _text = text;
            _value = value;
            _operatorTypes = operatorType;
            _dataType = datatype;
            _illegalColumns = illegalColumn;
            _column = column;
            counter++;
        }

        private static int counter = 0;

        private RepositoryItem _colEdit;

        private string _column;

        private Type _dataType;

        private string[] _illegalColumns;

        private int _index;

        private ClauseType[] _operatorTypes;

        private string _text;

        private string _value;

        private bool _visible;

        public string Column
        {
            get { return _column; }
            set { _column = value; }
        }

        public RepositoryItem ColumnEdit
        {
            get { return _colEdit; }
            set { _colEdit = value; }
        }

        public Type DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        public string[] IllegalColumns
        {
            get { return _illegalColumns; }
            set { _illegalColumns = value; }
        }

        public int MenuIndex
        {
            get { return _index; }
            set { _index = value; }
        }

        public ClauseType[] OperatorsTypes
        {
            get { return _operatorTypes; }
            set { _operatorTypes = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public List<CustomFilterColumns> GetSystemColumns()
        {
            List<CustomFilterColumns> returnValues = new List<CustomFilterColumns>();
            CustomFilterColumns filterColumn = new CustomFilterColumns("Bu Gün", tarihAyarla(DateTime.Now),
                new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
                typeof(DateTime));

            CustomFilterColumns filterColumn2 = new CustomFilterColumns("Dün", tarihAyarla(DateTime.Now - TimeSpan.FromDays(1)),
                new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
                typeof(DateTime));

            CustomFilterColumns filterColumn3 = new CustomFilterColumns("Yarin", tarihAyarla(DateTime.Now + TimeSpan.FromDays(1)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn4 = new CustomFilterColumns("Bu Günden 15 Gün Geriye", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn5 = new CustomFilterColumns("Bu Günden 15 Gün Ýleriye", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));
            CustomFilterColumns filterColumn6 = new CustomFilterColumns("Bu Günden 1 Hafta Ýleriye", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn7 = new CustomFilterColumns("Bu Günden 1 Hafta Geriye", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn8 = new CustomFilterColumns("Bu Günden 1 Ay Ýleriye", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn9 = new CustomFilterColumns("Bu Günden 1 Ay Geriye", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn10 = new CustomFilterColumns("Geçen Yýl Bu Gün", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn11 = new CustomFilterColumns("Gelecek Yýl Bu Gün", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn12 = new CustomFilterColumns("Geçen Yýl Bu Gün", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn13 = new CustomFilterColumns("Bu Günden 6 Ay Önce", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn14 = new CustomFilterColumns("Bu Günden 6 Ay Sonra", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Greater, ClauseType.GreaterOrEqual, ClauseType.DoesNotEqual, ClauseType.Between, ClauseType.BeginsWith, ClauseType.Less, ClauseType.LessOrEqual, ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn15 = new CustomFilterColumns("Bu Günden 6 Ay Önce", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Equals },
typeof(DateTime));

            CustomFilterColumns filterColumn16 = new CustomFilterColumns("Bu Hafta", tarihAyarla(DateTime.Now - TimeSpan.FromDays(15)),
new ClauseType[] { ClauseType.Equals },
typeof(DateTime));

            returnValues.Add(filterColumn);
            returnValues.Add(filterColumn2);
            returnValues.Add(filterColumn3);
            returnValues.Add(filterColumn4);
            returnValues.Add(filterColumn5);
            returnValues.Add(filterColumn6);
            returnValues.Add(filterColumn7);
            returnValues.Add(filterColumn8);
            returnValues.Add(filterColumn9);
            returnValues.Add(filterColumn10);
            returnValues.Add(filterColumn11);
            returnValues.Add(filterColumn12);
            returnValues.Add(filterColumn13);
            returnValues.Add(filterColumn14);
            returnValues.Add(filterColumn15);
            returnValues.Add(filterColumn16);

            return returnValues;
        }

        private string tarihAyarla(DateTime d)
        {
            string yil = d.Year.ToString();
            string ay = d.Month.ToString();
            string gun = d.Day.ToString();
            return "#" + yil + "-" + (ay.Length == 1 ? "0" + ay : ay) + "-" + (gun.Length == 1 ? "0" + gun : gun) + "#";
        }
    }
}