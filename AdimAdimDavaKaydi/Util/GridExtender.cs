using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using Util;

namespace AdimAdimDavaKaydi
{
    [DesignTimeVisible(true)]
    public class GridExtender : Control
    {
        public bool MakeSomeThing
        {
            get { return false; }
            set
            {
                if (value)
                {
                }
            }
        }

        public bool MakeSomeThingForVgrid
        {
            get { return false; }
            set
            {
                if (value)
                {
                    MakeSomeThingY();
                }
            }
        }

        public bool MakeSomeThingForVgridTUTAR
        {
            get { return false; }
            set
            {
                if (value)
                {
                    MakeSomeThingZ();
                }
            }
        }

        public bool MakeSomeThingForVgridDOVIZ
        {
            get { return false; }
            set
            {
                if (value)
                {
                    MakeSomeThingDOVIZ();
                }
            }
        }

        private void MakeSomeThingDOVIZ()
        {
            foreach (BaseRow row in _MyVGrid.Rows)
            {
                DovizIsle(row);
            }
        }

        private void DovizIsle(BaseRow br)
        {
            #region f11

            try
            {
                foreach (BaseRow row in br.ChildRows)
                {
                    if (row is MultiEditorRow)
                    {
                        MultiEditorRow mrow = (MultiEditorRow)row;
                        foreach (MultiEditorRowProperties props in mrow.PropertiesCollection)
                        {
                            if (props.FieldName.Contains("DOVIZ_ID"))
                            {
                                props.CellWidth = CellWidth;
                                props.RowEdit = DovizLookUp;
                                mrow.PropertiesCollection[mrow.PropertiesCollection.IndexOf(props) - 1].RowEdit =
                                    ParaSpin;
                                mrow.PropertiesCollection[mrow.PropertiesCollection.IndexOf(props) - 1].CellWidth =
                                    CellWidth2;
                            }
                        }
                    }
                    DovizIsle(row);
                }
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }

            #endregion
        }

        public bool ConvertVGridToXtraGridControl
        {
            get { return false; }
            set
            {
                if (value)
                {
                    MakeSomeThingQ();
                }
            }
        }

        public bool ConvertVGridToXtraGridControlReadOnly
        {
            get { return false; }
            set
            {
                if (value)
                {
                    MakeSomeThingQReadOnly();
                }
            }
        }

        private void MakeSomeThingQReadOnly()
        {
            if (_MyVGrid != null && _MyGrid != null)
            {
                DevExGridHelper.ConvertToGridControl(_MyVGrid, _MyGrid, true);
            }
        }

        private void MakeSomeThingQ()
        {
            if (_MyVGrid != null && _MyGrid != null)
            {
                DevExGridHelper.ConvertToGridControl(_MyVGrid, _MyGrid, false);
            }
        }

        private void MakeSomeThingY()
        {
            if (_MyVGrid != null)
            {
                foreach (BaseRow row in _MyVGrid.Rows)
                {
                    foreach (BaseRow chrow in row.ChildRows)
                    {
                        if (chrow.Properties.FieldName.Contains("TARIH"))
                        {
                            RepositoryItemDateEdit rdt = new RepositoryItemDateEdit();
                            rdt.Name = "rdt" + chrow.Properties.FieldName;
                            rdt.Tag = "rdt" + chrow.Properties.FieldName;
                            _MyVGrid.RepositoryItems.Add(rdt);
                            chrow.Properties.RowEdit = rdt;
                        }
                        if (chrow.Properties.FieldName.EndsWith("ID"))
                        {
                            RepositoryItemLookUpEdit rlk = new RepositoryItemLookUpEdit();
                            rlk.Name = "rlk" + chrow.Properties.FieldName;
                            rlk.Tag = "rlk" + chrow.Properties.FieldName;
                            _MyVGrid.RepositoryItems.Add(rlk);
                            chrow.Properties.RowEdit = rlk;
                        }
                    }
                    if (row.Properties.FieldName.Contains("TARIH"))
                    {
                        RepositoryItemDateEdit rdt = new RepositoryItemDateEdit();
                        rdt.Name = "rdt" + row.Properties.FieldName;
                        rdt.Tag = "rdt" + row.Properties.FieldName;
                        _MyVGrid.RepositoryItems.Add(rdt);
                        row.Properties.RowEdit = rdt;
                    }
                    if (row.Properties.FieldName.EndsWith("ID"))
                    {
                        RepositoryItemLookUpEdit rlk = new RepositoryItemLookUpEdit();
                        rlk.Name = "rlk" + row.Properties.FieldName;
                        rlk.Tag = "rlk" + row.Properties.FieldName;
                        _MyVGrid.RepositoryItems.Add(rlk);
                        row.Properties.RowEdit = rlk;
                    }
                }
            }
        }

        public ExtendedGridControl MyGrid
        {
            get { return _MyGrid; }
            set { _MyGrid = value; }
        }

        private VGridControl _MyVGrid;

        public DataSet DataSource { get; set; }

        public VGridControl MyVGrid
        {
            get { return _MyVGrid; }
            set { _MyVGrid = value; }
        }

        public string[] NameChanged
        {
            get { return _NameChanged.ToArray(); }
        }

        public int CellWidth { get; set; }

        public int CellWidth2 { get; set; }

        public RepositoryItemLookUpEdit DovizLookUp { get; set; }

        public RepositoryItemSpinEdit ParaSpin { get; set; }

        private ExtendedGridControl _MyGrid;

        private void MakeSomeThingZ()
        {
            foreach (RepositoryItem ri in _MyVGrid.RepositoryItems)
            {
                if (ri is RepositoryItemSpinEdit)
                {
                    RepositoryItemSpinEdit rise = (RepositoryItemSpinEdit)ri;
                    //FormatInfo fi = new FormatInfo();
                    if (rise.Name.ToLower().Contains("gider") || rise.Name.ToLower().Contains("tutar"))
                    {
                        rise.DisplayFormat.FormatType = FormatType.Numeric;
                        rise.DisplayFormat.FormatString = "###,###,###,###,###.00";
                        rise.EditFormat.FormatType = FormatType.Numeric;
                        rise.EditFormat.FormatString = "###,###,###,###,###.00";
                        rise.Mask.EditMask = "###,###,###,###,###.00";
                        _NameChanged.Add("Para : " + rise.Name);
                    }
                    if (rise.Name.ToLower().Contains("oran"))
                    {
                        rise.Mask.EditMask = "%%###.##";
                        _NameChanged.Add("Oran : " + rise.Name);
                    }
                }
                if (ri is RepositoryItemDateEdit)
                {
                    RepositoryItemDateEdit ride = (RepositoryItemDateEdit)ri;
                    ride.DisplayFormat.FormatType = FormatType.DateTime;
                    ride.DisplayFormat.FormatString = "d";
                    ride.EditMask = "d";
                    _NameChanged.Add("Tarih : " + ride.Name);
                }
            }
        }

        private List<string> _NameChanged = new List<string>();
    }
}