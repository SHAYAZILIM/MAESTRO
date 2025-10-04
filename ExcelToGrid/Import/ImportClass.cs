using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using TableConverter;

namespace ImportExportWithSelection.Import
{
    public enum MaskTypes
    {
        Dogru_Yanlis_Verisi,
        Karakter_Verisi,
        Sayýsal_Veri,
        Tarih,
        TabloVerisi,
    }

    public class Columns
    {
        public Columns()
        {
            this.Maskeler = new BindingList<Masks>();
        }

        private string _caption;

        private string _column;

        private Type _dataType;

        private bool _isNull;

        private BindingList<Masks> _maskeler;

        private object _record;

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public string Column
        {
            get { return _column; }
            set { _column = value; }
        }

        public Type DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        public bool IsNull
        {
            get { return _isNull; }
            set { _isNull = value; }
        }

        public BindingList<Masks> Maskeler
        {
            get { return _maskeler; }
            set { _maskeler = value; }
        }

        public object Record
        {
            get { return _record; }
            set { _record = value; }
        }

        public static Columns GetColumnByName(List<Columns> kolonlar, string kolon)
        {
            for (int i = 0; i < kolonlar.Count; i++)
            {
                if (kolonlar[i].Column == kolon)
                {
                    return kolonlar[i];
                }
            }
            return new Columns();
        }

        public static List<Columns> GetExcelColumns(DataTable dt)
        {
            List<Columns> returnValues = new List<Columns>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                Columns clm = new Columns();
                clm.Caption = dt.Columns[i].Caption;
                clm.Column = dt.Columns[i].ColumnName;

                returnValues.Add(clm);
            }
            return returnValues;
        }

        public object GetValue(object data)
        {
            object val = data;
            for (int i = 0; i < Maskeler.Count; i++)
            {
                switch (Maskeler[i].MasksType)
                {
                    case MaskTypes.Dogru_Yanlis_Verisi:
                        if (data == Maskeler[i].Mask)
                        {
                            val = Maskeler[i].Value;
                        }
                        break;

                    case MaskTypes.Karakter_Verisi:
                        if (data == Maskeler[i].Mask)
                        {
                            val = Maskeler[i].Value;
                        }
                        break;

                    case MaskTypes.Sayýsal_Veri:
                        if (data == Maskeler[i].Mask)
                        {
                            val = Maskeler[i].Value;
                        }
                        break;

                    case MaskTypes.Tarih:

                        DateTime tarih = DateTime.Parse(data.ToString());
                        val = tarih.ToString(Maskeler[i].Value.ToString());
                        break;

                    case MaskTypes.TabloVerisi:
                        if (data == Maskeler[i].Mask)
                        {
                            val = Maskeler[i].Value;
                        }
                        break;

                    default:
                        break;
                }
            }

            return val;
        }
    }

    public class ImportedClolumn : Columns
    {
        private RepositoryItem _RepItem;
        private string _selectedColumn;

        public RepositoryItem RepItem
        {
            get { return _RepItem; }
            set { _RepItem = value; }
        }

        public string SelectedColumn
        {
            get { return _selectedColumn; }
            set { _selectedColumn = value; }
        }

        // Kolona ait bir repository Item varsa onun icerisine display member da gorunen datauý
        // verip geriye value degerini donduruyoruz.
        public object GetValueByRepItem(object value)
        {
            if (RepItem == null)
            {
                return value;
            }
            if (RepItem is RepositoryItemLookUpEdit)
            {
                object val = ((RepositoryItemLookUpEdit)RepItem).GetKeyValueByDisplayText(value.ToString());

                if (val == null)
                {
                    val = ((RepositoryItemLookUpEdit)RepItem).GetKeyValueByDisplayText(value.ToString().ToLower().Trim());
                }

                if (val == null)
                {
                    val = ((RepositoryItemLookUpEdit)RepItem).GetKeyValueByDisplayText(value.ToString().Trim());
                }

                if (val == null)
                {
                    val = ((RepositoryItemLookUpEdit)RepItem).GetKeyValueByDisplayText(value.ToString().ToUpper().Trim());
                }
                if (val != null)
                {
                    return val;
                }
            }

            return value;

            //if (RepItem is RepositoryItemComboBox)
            //{
            //    for (int i = 0; i < ((RepositoryItemComboBox)RepItem).Items.Count; i++)
            //    {
            //        ((RepositoryItemComboBox)RepItem).Items[i]
            //    }
            //}
        }
    }

    public class Masks
    {
        private string _kolon;
        private object _mask;
        private MaskTypes _masksType = MaskTypes.Karakter_Verisi;
        private string _tablo;
        private object _value;

        /// <summary>
        /// Hangi Kolona ait veri gorunecek onu belirliyoruz
        /// </summary>
        public string Kolon
        {
            get { return _kolon; }
            set { _kolon = value; }
        }

        public object Mask
        {
            get { return _mask; }
            set { _mask = value; }
        }

        public MaskTypes MasksType
        {
            get { return _masksType; }
            set { _masksType = value; }
        }

        public int MaskType
        {
            get { return (int)_masksType; }
            set { _masksType = (MaskTypes)Enum.ToObject(typeof(MaskTypes), value); }
        }

        /// <summary>
        /// Hangi tablonun verilerinin tutulduðudur.
        /// </summary>
        public string Tablo
        {
            get { return _tablo; }
            set
            {
                _tablo = value;
                if (!string.IsNullOrEmpty(value))
                {
                    this._masksType = MaskTypes.TabloVerisi;
                }
            }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public RepositoryItem GetComboLookUp()
        {
            List<MaskValue> lstMaskValue = new List<MaskValue>();

            switch (MasksType)
            {
                case MaskTypes.Dogru_Yanlis_Verisi:

                    RepositoryItemLookUpEdit rlue = new RepositoryItemLookUpEdit();
                    rlue.DisplayMember = "Text";
                    rlue.ValueMember = "Value";
                    MaskValue mval = new MaskValue();
                    mval.Text = "Doðru";
                    mval.Value = true;
                    lstMaskValue.Add(mval);
                    MaskValue mval2 = new MaskValue();
                    mval2.Text = "Yanlýþ";
                    mval2.Value = false;
                    lstMaskValue.Add(mval2);
                    rlue.DataSource = lstMaskValue;

                    return rlue;
                    

                case MaskTypes.Karakter_Verisi:
                    RepositoryItemTextEdit rlue1 = new RepositoryItemTextEdit();
                    return rlue1;
                    

                case MaskTypes.Sayýsal_Veri:
                    RepositoryItemSpinEdit rlue2 = new RepositoryItemSpinEdit();
                    return rlue2;
                    

                case MaskTypes.Tarih:
                    RepositoryItemLookUpEdit rlue3 = GetTarihLookUp();
                    return rlue3;
                    

                case MaskTypes.TabloVerisi:
                    RepositoryItemLookUpEdit rlue4 = new RepositoryItemLookUpEdit();
                    IList Kayitlar = TableStringConverter.GetAllRecordByTableName(_tablo);
                    rlue4.DataSource = Kayitlar;
                    rlue4.ValueMember = "ID";
                    rlue4.DisplayMember = _kolon;
                    return rlue4;
                    

                default:
                    break;
            }

            return new RepositoryItem();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Control GetLookUp()
        {
            List<MaskValue> lstMaskValue = new List<MaskValue>();

            switch (MasksType)
            {
                case MaskTypes.Dogru_Yanlis_Verisi:

                    LookUpEdit rlue = new LookUpEdit();
                    rlue.Properties.DisplayMember = "Text";
                    rlue.Properties.ValueMember = "Value";
                    MaskValue mval = new MaskValue();
                    mval.Text = "Doðru";
                    mval.Value = true;
                    lstMaskValue.Add(mval);
                    MaskValue mval2 = new MaskValue();
                    mval2.Text = "Yanlýþ";
                    mval2.Value = false;
                    lstMaskValue.Add(mval2);
                    rlue.Properties.DataSource = lstMaskValue;

                    return rlue;

                case MaskTypes.Karakter_Verisi:
                    TextEdit rlue1 = new TextEdit();
                    return rlue1;

                case MaskTypes.Sayýsal_Veri:
                    SpinEdit rlue2 = new SpinEdit();
                    return rlue2;

                case MaskTypes.Tarih:
                    LookUpEdit rlue3 = new LookUpEdit();
                    rlue3.Properties.Assign(GetTarihLookUp());
                    return rlue3;

                case MaskTypes.TabloVerisi:
                    LookUpEdit rlue4 = new LookUpEdit();
                    IList Kayitlar = TableStringConverter.GetAllRecordByTableName(_tablo);
                    rlue4.Properties.DataSource = Kayitlar;
                    rlue4.Properties.ValueMember = "ID";
                    rlue4.Properties.DisplayMember = _kolon;
                    return rlue4;

                default:
                    break;
            }

            return new Control();
        }

        private RepositoryItemLookUpEdit GetTarihLookUp()
        {
            List<MaskValue> lstMaskValue = new List<MaskValue>();

            RepositoryItemLookUpEdit rlue3 = new RepositoryItemLookUpEdit();
            rlue3.DisplayMember = "Text";
            rlue3.ValueMember = "Value";

            MaskValue mval = new MaskValue();
            mval.Text = "aa.gg.yyyy";
            mval.Value = "mm.dd.yyyy";
            lstMaskValue.Add(mval);

            MaskValue mval2 = new MaskValue();
            mval2.Text = "gg.aa.yyyy";
            mval2.Value = "dd.mm.yyyy";
            lstMaskValue.Add(mval2);

            MaskValue mval3 = new MaskValue();
            mval3.Text = "gg/aa/yyyy";
            mval3.Value = "dd/mm/yyyy";
            lstMaskValue.Add(mval3);

            MaskValue mval4 = new MaskValue();
            mval4.Text = "aa/gg/yyyy";
            mval4.Value = "mm/dd/yyyy";
            lstMaskValue.Add(mval4);

            MaskValue mval5 = new MaskValue();
            mval5.Text = "aa-gg-yyyy";
            mval5.Value = "mm-dd-yyyy";
            lstMaskValue.Add(mval5);

            MaskValue mval6 = new MaskValue();
            mval6.Text = "gg-aa-yyyy";
            mval6.Value = "dd-mm-yyyy";
            lstMaskValue.Add(mval6);

            MaskValue mval7 = new MaskValue();
            mval7.Text = "gg.Ay.yyyy";
            mval7.Value = "dd.MM.yyyy";
            lstMaskValue.Add(mval7);
            rlue3.DataSource = lstMaskValue;

            MaskValue mval8 = new MaskValue();
            mval8.Text = "Gun.Ay.yyyy";
            mval8.Value = "DD.MM.yyyy";
            lstMaskValue.Add(mval8);
            rlue3.DataSource = lstMaskValue;

            MaskValue mval9 = new MaskValue();
            mval9.Text = "g.a.yy";
            mval9.Value = "d.m.yy";
            lstMaskValue.Add(mval9);
            rlue3.DataSource = lstMaskValue;

            MaskValue mval10 = new MaskValue();
            mval10.Text = "d/m/yy";
            mval10.Value = false;
            lstMaskValue.Add(mval10);

            rlue3.DataSource = lstMaskValue;

            return rlue3;
        }
    }

    public class MaskValue : ValueText
    {
    }

    public class MyInits
    {
        public static void SetLookupByEnum(RepositoryItemLookUpEdit rlue, Type enumType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ad", typeof(string));
            dt.Columns.Add("Deger", typeof(int));

            string[] enums = Enum.GetNames(enumType);
            for (int i = 0; i < enums.Length; i++)
            {
                string deger = "";
                if (enums[i].Contains("_"))
                {
                    deger = enums[i].Replace("_", "");
                }
                else
                {
                    deger = enums[i];
                }

                dt.Rows.Add(deger, (int)Enum.Parse(enumType, enums[i]));
            }
            rlue.Columns.Add(new LookUpColumnInfo("Ad"));
            rlue.DataSource = dt;
            rlue.DisplayMember = "Ad";
            rlue.ValueMember = "Deger";
        }
    }

    public class ValueText
    {
        private string _text;
        private object _value;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}