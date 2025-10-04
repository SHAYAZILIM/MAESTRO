using System.Collections.Generic;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraVerticalGrid.Rows;

namespace Util
{
    public static class DevExGridHelper
    {        
        public static BaseRow[] GetMyChildRows(BaseRow row)
        {
            List<BaseRow> resrows = new List<BaseRow>();
            foreach (BaseRow br in row.ChildRows)
            {
                if (br is EditorRow || br is MultiEditorRow)
                {
                    resrows.Add(br);
                    resrows.AddRange(GetMyChildRows(br));
                }
            }
            return resrows.ToArray();
        }

        public static void ConvertToGridControl(DevExpress.XtraVerticalGrid.VGridControl vgridToConvert,
                                                GridControl toBeConverted, bool isreadonly)
        {
            List<BaseRow> vrows = new List<BaseRow>();
            foreach (BaseRow row in vgridToConvert.Rows)
            {
                if (row is EditorRow || row is MultiEditorRow)
                {
                    vrows.Add(row);
                    vrows.AddRange(GetMyChildRows(row));
                }
                else
                {
                    vrows.AddRange(GetMyChildRows(row));
                }
            }
            GridView gv = ((GridView)toBeConverted.Views[0]);
            gv.Columns.Clear();
            gv.OptionsView.ColumnAutoWidth = false;
            gv.OptionsView.ShowDetailButtons = false;
            foreach (BaseRow row in vrows)
            {
                if (row is MultiEditorRow)
                {
                    MultiEditorRow mrow = (MultiEditorRow)row;
                    foreach (MultiEditorRowProperties mprop in mrow.PropertiesCollection)
                    {
                        GridColumn gc = gv.Columns.Add();
                        gc.Visible = true;
                        gc.Caption = mprop.Caption;
                        gc.Tag = mrow.Tag;
                        RepositoryItem ri = mprop.RowEdit;
                        gv.GridControl.RepositoryItems.Add(ri);
                        gc.ColumnEdit = ri;
                        gc.OptionsColumn.ReadOnly = isreadonly;
                        gc.FieldName = mprop.FieldName;
                        gc.BestFit();
                    }
                }
                else if (row is EditorRow)
                {
                    EditorRow er = (EditorRow)row;
                    GridColumn gc = gv.Columns.Add();
                    gc.Visible = true;
                    gc.Tag = row.Tag;
                    gc.OptionsColumn.ReadOnly = isreadonly;
                    gc.Caption = er.Properties.Caption;
                    RepositoryItem ri = er.Properties.RowEdit;
                    gv.GridControl.RepositoryItems.Add(ri);
                    gc.ColumnEdit = ri;
                    gc.FieldName = er.Properties.FieldName;
                    gc.BestFit();
                }
            }
            toBeConverted.DataSource = vgridToConvert.DataSource;
        }
    }
}