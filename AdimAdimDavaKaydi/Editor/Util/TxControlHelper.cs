using System.Collections.Generic;
using TXTextControl;

namespace AdimAdimDavaKaydi.Editor.Util
{
    public static class TxTextControlHelper
    {
        public static void AddTable(TextControl txControl, TextField field, int id, List<string[]> dizi)
        {
            field.Text = " ";
            txControl.Select(field.Start, 0);
            Table table = null;
            if (txControl.Tables.Add(dizi.Count, dizi[0].Length, id))
            {
                table = txControl.Tables.GetItem(id);
                for (int i = 1; i <= dizi.Count; i++)
                {
                    for (int y = 1; y <= dizi[i - 1].Length; y++)
                    {
                        table.Cells.GetItem(i, y).Text = dizi[i - 1][y - 1];
                    }
                }
            }
            if (table != null) ResizeTable(CheckCellWidth(txControl, table.ID), table);
        }

        public static int[] CheckCellWidth(TextControl txControl, int tableId)
        {
            int[] colWidths = new int[txControl.Tables.GetItem(tableId).Columns.Count];

            foreach (TableCell tc in txControl.Tables.GetItem(tableId).Cells)
            {
                int textBounds = 0;
                for (int i = tc.Start; i <= tc.Start + tc.Length - 1; i++)
                {
                    if (txControl.Lines.GetItem(i).TextBounds.Width > textBounds)
                    {
                        textBounds = txControl.Lines.GetItem(i).TextBounds.Width;
                    }
                }
                if (textBounds > colWidths[tc.Column - 1])
                {
                    colWidths[tc.Column - 1] = textBounds;
                }
            }
            return colWidths;
        }

        public static void ResizeTable(int[] colSize, Table table)
        {
            int i = 0;
            for (int j = 1; j <= table.Columns.Count; j++)
            {
                if (colSize[i] != 0)
                {
                    table.Columns.GetItem(j).Width = colSize[i] + 200;
                }
                i++;
            }
        }
    }
}