using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.FilterEditor;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using System;
using System.Collections.Generic;

//using AvukatProLib2.Entities;

namespace AvukatProLib.Controls.Grid.CustomFiltering
{
    public class GridsFilterSettings
    {
        private ExtendedGridControl _grid;

        private List<CustomFilterColumns> lstColumns = new List<CustomFilterColumns>();

        private DXPopupMenu menu = new DXPopupMenu();

        public ExtendedGridControl Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }

        public static void SetViewFilter(GridControl grid)
        {
            GridsFilterSettings filterSettings = new GridsFilterSettings();
            filterSettings.SetViewFilter(grid.MainView);

            foreach (GridLevelNode vii in grid.LevelTree.Nodes)
            {
                filterSettings.SetViewFilter(vii.LevelTemplate);
            }
        }

        public void SetGridControlsFilterEvents(ExtendedGridControl gridCnt)
        {
            if (gridCnt.MainView is GridView)
            {
                ((GridView)gridCnt.MainView).CustomFilterDisplayText += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(GridsFilterSettings_CustomFilterDisplayText);
                ((GridView)gridCnt.MainView).FilterEditorCreated += new FilterControlEventHandler(GridsFilterSettings_FilterEditorCreated);
                ((GridView)gridCnt.MainView).ActiveFilter.Changed += new EventHandler(ActiveFilter_Changed);
                _grid = gridCnt;
                CustomFilterColumns cfc = new CustomFilterColumns();
                lstColumns = cfc.GetSystemColumns();
                ((GridView)gridCnt.MainView).OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            }
        }

        private void ActiveFilter_Changed(object sender, EventArgs e)
        {
        }

        private void FilterControl_FilterChanged(object sender, DevExpress.XtraEditors.FilterChangedEventArgs e)
        {
            if (e.CurrentNode == null)
                return;
            FilterColumn col = _grid.GridsFilterControl.FilterColumns[((DevExpress.XtraEditors.Filtering.ClauseNode)e.CurrentNode).FirstOperand.PropertyName];
            if (col != null)
            {
                for (int i = 0; i < lstColumns.Count; i++)
                {
                    for (int y = 0; y < lstColumns[i].OperatorsTypes.Length; y++)
                    {
                        if (lstColumns[i].OperatorsTypes[y] == ((DevExpress.XtraEditors.Filtering.ClauseNode)e.CurrentNode).Operation)
                        {
                            if (lstColumns[i].IllegalColumns.Length == 1)
                            {
                                if (col.ColumnType == lstColumns[i].DataType)
                                {
                                    lstColumns[i].Visible = true;
                                }
                            }
                            for (int l = 0; l < lstColumns[i].IllegalColumns.Length; l++)
                            {
                                if (col.ColumnType == lstColumns[i].DataType && col.FieldName == lstColumns[i].IllegalColumns[l])
                                {
                                    lstColumns[i].Visible = true;
                                }
                            }

                            menu.Items[lstColumns[i].MenuIndex].Visible = lstColumns[i].Visible;
                        }
                    }
                }
            }
        }

        private void GridsFilterControl_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateValues();
        }

        private void GridsFilterSettings_CustomFilterDisplayText(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (sender is GridView)
            {
                e.Handled = true;
                e.Value = ((ExtendedGridControl)((GridView)sender).GridControl).FilterText;
            }
            else if (sender is CardView)
            {
                e.Handled = true;
                e.Value = ((ExtendedGridControl)((CardView)sender).GridControl).FilterText;
            }
            else if (sender is LayoutView)
            {
                e.Handled = true;
                e.Value = ((ExtendedGridControl)((LayoutView)sender).GridControl).FilterText;
            }
        }

        private void GridsFilterSettings_FilterEditorCreated(object sender, FilterControlEventArgs e)
        {
            _grid.GridsFilterControl = (GridFilterControl)e.FilterControl;

            _grid.GridsFilterControl.FilterString = _grid.FilterValue;
            for (int i = 0; i < lstColumns.Count; i++)
            {
                if (e.FilterControl.FilterColumns[lstColumns[i].Column] == null)
                {
                    ExtendedFilterColumn efc = new ExtendedFilterColumn();

                    efc.FillFields(lstColumns[i].Text, lstColumns[i].Column, lstColumns[i].ColumnEdit, lstColumns[i].DataType);

                    lstColumns[i].MenuIndex = e.FilterControl.FilterColumns.Add(efc);
                }
            }
            _grid.GridsFilterControl.Validating += new System.ComponentModel.CancelEventHandler(GridsFilterControl_Validating);
            e.FilterControl.FilterChanged += new DevExpress.XtraEditors.FilterChangedEventHandler(FilterControl_FilterChanged);
            _grid.GridsFilterControl.FilterString = _grid.FilterValue;
            menu = e.FilterControl.FilterViewInfo.GetColumnMenu();
        }

        private void SetViewFilter(BaseView view)
        {
            if (view is GridView)
            {
                GridView levelVi = (GridView)view;
                levelVi.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Default;
                levelVi.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.SmartTag;

                //TODO : Filtre Satýrý
                //levelVi.OptionsView.ShowAutoFilterRow = false;
                levelVi.OptionsFilter.UseNewCustomFilterDialog = true;
                levelVi.OptionsFilter.AllowColumnMRUFilterList = true;
                levelVi.OptionsFilter.AllowFilterEditor = true;
                levelVi.OptionsFilter.AllowMRUFilterList = true;
            }
            else if (view is LayoutView)
            {
                LayoutView levelVi = (LayoutView)view;
                levelVi.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Default;
                levelVi.OptionsFilter.UseNewCustomFilterDialog = true;
                levelVi.OptionsFilter.AllowColumnMRUFilterList = true;
                levelVi.OptionsFilter.AllowFilterEditor = true;
                levelVi.OptionsFilter.AllowMRUFilterList = true;
            }
            else if (view is CardView)
            {
                CardView levelVi = (CardView)view;
                levelVi.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Default;
                levelVi.OptionsFilter.UseNewCustomFilterDialog = true;
                levelVi.OptionsFilter.AllowColumnMRUFilterList = true;
                levelVi.OptionsFilter.AllowFilterEditor = true;
                levelVi.OptionsFilter.AllowMRUFilterList = true;
            }
            else
            {
            }
        }

        private void ValidateValues()
        {
            for (int i = 0; i < lstColumns.Count; i++)
            {
                _grid.FilterText = _grid.GridsFilterControl.FilterString.Replace(lstColumns[i].Column, lstColumns[i].Text);
                _grid.FilterValue = _grid.GridsFilterControl.FilterString;
                _grid.GridsFilterControl.FilterString = _grid.GridsFilterControl.FilterString.Replace("[" + lstColumns[i].Column + "]", lstColumns[i].Value);
            }
        }
    }
}