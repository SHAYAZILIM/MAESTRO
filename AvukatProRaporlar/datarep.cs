using AvukatProRaporlar.Lib;
using DevExpress.XtraGrid.Columns;

//using AdimAdimDavaKaydi.Util;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvukatProRaporlar
{
    public class GridControlEx : ExtendedGridControl //:  AdimAdimDavaKaydi.Util.ExtendedGridControl
    {
        public GridControlEx()
        {
            if (this.MainView is GridView)
            {
                ((GridView)this.MainView).OptionsFilter.ShowAllTableValuesInFilterPopup = false;
            }

            this.Load += new EventHandler(ExtendedGridControls_Load);
            this.ColumnVisibleIndexChanged += new OnColumnVisibleIndexChanged(GridControlEx_ColumnVisibleIndexChanged);
            this.ColumCountChanged += new OnColumCountChanged(GridControlEx_ColumCountChanged);
        }

        private int columnCount = 0;

        private List<ViewsColumns> lstColumns = new List<ViewsColumns>();

        public delegate void OnColumCountChanged(ExtendedGridControl senderGrid, BaseView senderView, ViewType Viewstype, GridColumn sender, int count);

        public delegate void OnColumnVisibleIndexChanged(ExtendedGridControl senderGrid, BaseView senderView, ViewType Viewstype, GridColumn sender, int index);

        public event OnColumCountChanged ColumCountChanged;

        public event OnColumnVisibleIndexChanged ColumnVisibleIndexChanged;

        public enum ViewType
        {
            Grid, LayOut, Card
        }

        private void ExtendedGridControlChild_ColumnChanged(object sender, EventArgs e)
        {
        }

        private void ExtendedGridControls_Load(object sender, EventArgs e)
        {
            columnCount = ((GridView)this.MainView).Columns.Count;
            for (int i = 0; i < this.Views.Count; i++)
            {
                if (this.Views[i] is GridView)
                {
                    ((GridView)this.Views[i]).CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(GridControlEx_MainCustomDrawColumnHeader);

                    // ((GridView)this.Views[i]).ColumnChanged += new
                    // EventHandler(ExtendedGridControlChild_ColumnChanged);

                    for (int y = 0; y < ((GridView)this.Views[i]).Columns.Count; y++)
                    {
                        ViewsColumns vc = new ViewsColumns();
                        vc.Column = ((GridView)this.Views[i]).Columns[y];
                        vc.exIndex = ((GridView)this.Views[i]).Columns[y].VisibleIndex;
                        vc.Index = ((GridView)this.Views[i]).Columns[y].VisibleIndex;
                        vc.ParentView = this.Views[i];
                        lstColumns.Add(vc);
                    }
                }

                if (this.Views[i] is LayoutView)
                {
                    ((LayoutView)this.Views[i]).ColumnChanged += new EventHandler(ExtendedGridControlChild_ColumnChanged);
                    for (int y = 0; y < ((LayoutView)this.Views[i]).Columns.Count; y++)
                    {
                        ViewsColumns vc = new ViewsColumns();
                        vc.Column = ((LayoutView)this.Views[i]).Columns[y];
                        vc.exIndex = ((LayoutView)this.Views[i]).Columns[y].AbsoluteIndex;
                        vc.Index = ((LayoutView)this.Views[i]).Columns[y].AbsoluteIndex;
                        vc.ParentView = this.Views[i];
                        lstColumns.Add(vc);
                    }
                }

                if (this.Views[i] is CardView)
                {
                    ((CardView)this.Views[i]).ColumnChanged += new EventHandler(ExtendedGridControlChild_ColumnChanged);
                    for (int y = 0; y < ((CardView)this.Views[i]).Columns.Count; y++)
                    {
                        ViewsColumns vc = new ViewsColumns();
                        vc.Column = ((CardView)this.Views[i]).Columns[y];
                        vc.exIndex = ((CardView)this.Views[i]).Columns[y].VisibleIndex;
                        vc.Index = ((CardView)this.Views[i]).Columns[y].VisibleIndex;
                        vc.ParentView = this.Views[i];
                        lstColumns.Add(vc);
                    }
                }
            }
        }

        private void GridControlEx_ColumCountChanged(ExtendedGridControl senderGrid, BaseView senderView, GridControlEx.ViewType Viewstype, GridColumn sender, int count)
        {
            for (int y = 0; y < ((GridView)senderView).Columns.Count; y++)
            {
                if (!lstColumnsContains(((GridView)senderView).Columns[y]))
                {
                    ViewsColumns vc = new ViewsColumns();
                    vc.Column = ((GridView)senderView).Columns[y];
                    vc.exIndex = ((GridView)senderView).Columns[y].VisibleIndex;
                    vc.Index = ((GridView)senderView).Columns[y].VisibleIndex;
                    vc.ParentView = senderView;
                    lstColumns.Add(vc);
                }
            }
        }

        private void GridControlEx_ColumnVisibleIndexChanged(ExtendedGridControl senderGrid, BaseView senderView, GridControlEx.ViewType Viewstype, GridColumn sender, int index)
        {
            // throw new NotImplementedException();
        }

        private void GridControlEx_MainCustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (this.MainView is GridView)
            {
                if (columnCount != ((GridView)this.MainView).Columns.Count)
                {
                    ColumCountChanged(this, this.MainView, ViewType.Grid, ((GridView)this.MainView).Columns[((GridView)this.MainView).Columns.Count - 1], ((GridView)this.MainView).Columns.Count);
                }
                for (int i = 0; i < lstColumns.Count; i++)
                {
                    //for (int y = 0; y < ((GridView)this.MainView).Columns.Count; y++)
                    //{
                    var sonuc = ((GridView)this.MainView).Columns.OfType<GridColumn>().Where(vi => vi == lstColumns[i].Column && vi.VisibleIndex != lstColumns[i].Index && vi.VisibleIndex != -1);

                    if (sonuc.Dolumu())
                    {
                        foreach (var item in sonuc)
                        {
                            this.ColumnVisibleIndexChanged(this, this.MainView, ViewType.Grid, item, item.VisibleIndex);
                            lstColumns[i].Index = item.VisibleIndex;
                        }

                        //}

                        //if (lstColumns[i].Column == ((GridView)this.MainView).Columns[y] && lstColumns[i].Index != ((GridView)this.MainView).Columns[y].VisibleIndex && ((GridView)this.MainView).Columns[y].VisibleIndex != -1)
                        //{
                        //    this.ColumnVisibleIndexChanged(this, this.MainView, ViewType.Grid, ((GridView)this.MainView).Columns[y], ((GridView)this.MainView).Columns[y].VisibleIndex);
                        //    lstColumns[i].Index = ((GridView)this.MainView).Columns[y].VisibleIndex;
                        //}
                    }
                }
            }

            if (this.MainView is CardView)
            {
                for (int i = 0; i < lstColumns.Count; i++)
                {
                    if (lstColumns[i].Index != ((CardView)this.MainView).FocusedColumn.VisibleIndex)
                    {
                        this.ColumnVisibleIndexChanged(this, this.MainView, ViewType.Card, ((CardView)this.MainView).FocusedColumn, ((CardView)this.MainView).FocusedColumn.VisibleIndex);
                        lstColumns[i].Index = ((CardView)this.MainView).FocusedColumn.VisibleIndex;
                    }
                }
            }

            if (this.MainView is LayoutView)
            {
                for (int i = 0; i < lstColumns.Count; i++)
                {
                    if (lstColumns[i].Index != ((LayoutView)this.MainView).FocusedColumn.VisibleIndex)
                    {
                        this.ColumnVisibleIndexChanged(this, this.MainView, ViewType.LayOut, ((LayoutView)this.MainView).FocusedColumn, ((LayoutView)this.MainView).FocusedColumn.VisibleIndex);
                        lstColumns[i].Index = ((LayoutView)this.MainView).FocusedColumn.VisibleIndex;
                    }
                }
            }
        }

        private bool lstColumnsContains(GridColumn column)
        {
            for (int i = 0; i < lstColumns.Count; i++)
            {
                if (lstColumns[i].Column == column)
                {
                    return true;
                }
            }
            return false;
        }

        public class ViewsColumns
        {
            private GridColumn _column;
            private int _exIndex;
            private int _id;

            private int _index;

            private BaseView _parentView;

            public GridColumn Column
            {
                get { return _column; }
                set { _column = value; }
            }

            public int exIndex
            {
                get { return _exIndex; }
                set { _exIndex = value; }
            }

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public int Index
            {
                get { return _index; }
                set { _index = value; }
            }

            public BaseView ParentView
            {
                get { return _parentView; }
                set { _parentView = value; }
            }
        }
    }

}