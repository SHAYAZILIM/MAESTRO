using AvProExportImport.Import;
using AvukatProLib2.Entities;
using Datas.TablesColumn;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ImportExportWithSelection.Import
{
    public partial class frmImportFromExcel<T> : DevExpress.XtraEditors.XtraForm where T : IEntity, new()
    {
        public frmImportFromExcel()
        {
            InitializeComponent();
        }

        private TList<T> _data = new TList<T>();

        private List<Columns> _excelColumns = new List<Columns>();

        private string _file;

        private GridControl _resultGridControl;

        private List<ImportedClolumn> _SelectedColumns = new List<ImportedClolumn>();

        private DataSet ExcelData = new DataSet();

        public TList<T> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public List<Columns> ExcelColumns
        {
            get { return _excelColumns; }
            set { _excelColumns = value; }
        }

        public string File
        {
            get { return _file; }
            set { _file = value; }
        }

        public GridControl ResultGridControl
        {
            get { return _resultGridControl; }
            set { _resultGridControl = value; }
        }

        public List<ImportedClolumn> SelectedColumns
        {
            get { return _SelectedColumns; }
            set { _SelectedColumns = value; }
        }

        public object ConvertToType(object data, Type tip)
        {
            object returnValue = null;

            try
            {
                if (tip.Name == typeof(string).Name)
                {
                    return Convert.ToString(data);
                }
                if (tip.Name == typeof(int).Name)
                {
                    return Convert.ToInt32(data);
                }
                if (tip.Name == typeof(short).Name)
                {
                    return Convert.ToInt16(data);
                }
                if (tip.Name == typeof(byte).Name)
                {
                    return Convert.ToByte(data);
                }
                if (tip.Name == typeof(byte[]).Name)
                {
                    return System.Text.Encoding.UTF8.GetBytes(data.ToString());
                }
                if (tip.Name == typeof(decimal).Name)
                {
                    return Convert.ToDecimal(data);
                }
                if (tip.Name == typeof(DateTime).Name)
                {
                    return Convert.ToDateTime(data);
                }

                if (tip.Name == typeof(bool).Name)
                {
                    return Convert.ToBoolean(data);
                }

                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return returnValue;
        }

        public void FillfillColumns(RepositoryItemLookUpEdit rlueColumns, List<Columns> columns)
        {
            rlueColumns.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Caption"));
            rlueColumns.DisplayMember = "Caption";
            rlueColumns.ValueMember = "Column";
            rlueColumns.DataSource = columns;
        }

        public object GetValueByColumn()
        {
            return new object();
        }

        public void Show(GridControl grid)
        {
            List<ImportedClolumn> lstColumns = new List<ImportedClolumn>();
            for (int i = 0; i < ((GridView)grid.MainView).Columns.Count; i++)
            {
                ImportedClolumn clm = new ImportedClolumn();
                clm.Caption = ((GridView)grid.MainView).Columns[i].Caption;
                clm.Column = ((GridView)grid.MainView).Columns[i].FieldName;
                clm.DataType = ((GridView)grid.MainView).Columns[i].ColumnType;
                clm.SelectedColumn = string.Empty;
                clm.IsNull = !((GridView)grid.MainView).Columns[i].Visible;
                lstColumns.Add(clm);
            }
            this.SelectedColumns = lstColumns;

            this.grdSonuc = grid;

            this.Show();
        }

        public void ShowDialog(GridControl grid)
        {
            List<ImportedClolumn> lstColumns = new List<ImportedClolumn>();
            for (int i = 0; i < ((GridView)grid.MainView).Columns.Count; i++)
            {
                ImportedClolumn clm = new ImportedClolumn();
                clm.Caption = ((GridView)grid.MainView).Columns[i].Caption;
                clm.Column = ((GridView)grid.MainView).Columns[i].FieldName;
                clm.DataType = ((GridView)grid.MainView).Columns[i].ColumnType;
                clm.SelectedColumn = string.Empty;
                clm.IsNull = !((GridView)grid.MainView).Columns[i].Visible;
                lstColumns.Add(clm);
            }
            this.SelectedColumns = lstColumns;

            this.grdSonuc = grid;

            this.ShowDialog();
        }

        private void btnDevam1_Click(object sender, EventArgs e)
        {
            this.ExcelColumns = (List<Columns>)grdColumns.DataSource;
            this.grdSecim.DataSource = SelectedColumns;
            FillfillColumns(rlueExcelAlan, ExcelColumns);
            pnlSecim.Enabled = true;
            pnlIlk.Enabled = false;
        }

        private void btnSonuc_Click(object sender, EventArgs e)
        {
            pnlSecim.Enabled = false;
            grdSonuc.Enabled = true;
            SetFromExcel();
            this.grdSonuc.DataSource = Data;
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.ResultGridControl = this.grdSonuc;
        }

        private void frmImportFromExcel_Load(object sender, EventArgs e)
        {
            grdColumns.DataSource = new List<Columns>();
            MyInits.SetLookupByEnum(rlueMaskeTipi, typeof(MaskTypes));

            //     rlueMaskeTipi.EditValueChanged += new EventHandler(rlueMaskeTipi_EditValueChanged);
            //gridView5.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridView5_FocusedRowChanged);
            //gridView5.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(gridView5_CellValueChanged);

            rbtnMaskeEkle.Click += new EventHandler(rbtnMaskeEkle_Click);
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //object data = gridView5.GetFocusedRow();
            //if (data != null && data is Masks)
            //{
            //    colMask.ColumnEdit = ((Masks)data).GetComboLookUp();
            //}
        }

        private void gridView5_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //object data = gridView5.GetFocusedRow();
            //if (data != null && data is Masks)
            //{
            //    colMask.ColumnEdit = ((Masks)data).GetComboLookUp();
            //}
        }

        private void opfDosyaSec_FileOk(object sender, CancelEventArgs e)
        {
            this.txtDosya.Text = opfDosyaSec.FileName;
            this.File = opfDosyaSec.FileName;
            ExcelData = Excel.ImportFromExcel(File);
            this.grdColumns.DataSource = Columns.GetExcelColumns(ExcelData.Tables[0]);
        }

        private void rbtnMaskeEkle_Click(object sender, EventArgs e)
        {
            object row = gridView4.GetFocusedRow();
            if (row is Columns)
            {
                Columns clm = (Columns)row;
                frmMaskeler maskeleri = new frmMaskeler();
                maskeleri.Show(clm, ExcelData.Tables[0]);
            }
        }

        private void rlueMaskeTipi_EditValueChanged(object sender, EventArgs e)
        {
            //object data = gridView5.GetFocusedRow();
            //if (data != null && data is Masks)
            //{
            //    colMask.ColumnEdit = ((Masks)data).GetComboLookUp();
            //}
        }

        private void SetFromExcel()
        {
            DataSet ds = AvProExportImport.Import.Excel.ImportFromExcel(File);

            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                T itm = Activator.CreateInstance<T>();
                for (int i = 0; i < SelectedColumns.Count; i++)
                {
                    if (string.IsNullOrEmpty(SelectedColumns[i].SelectedColumn))
                    {
                        continue;
                    }

                    if (ds.Tables[0].Rows[r][SelectedColumns[i].SelectedColumn] != DBNull.Value)
                    {
                        object data = null;
                        if (SelectedColumns[i].RepItem != null)
                        {
                            data = ConvertToType(ds.Tables[0].Rows[r][SelectedColumns[i].SelectedColumn], SelectedColumns[i].DataType);
                        }
                        else
                        {
                            data = SelectedColumns[i].GetValueByRepItem(ds.Tables[0].Rows[r][SelectedColumns[i].SelectedColumn]);
                        }
                        if (data != null)
                        {
                            TablesColumnData.SetColumnValueByNameFromRecord(itm, SelectedColumns[i].Column, data);
                        }
                    }
                }
                this.Data.Add(itm);
            }
        }

        private void txtDosya_Click(object sender, EventArgs e)
        {
            opfDosyaSec.ShowDialog();
        }

        private void txtDosya_EditValueChanged(object sender, EventArgs e)
        {
        }
    }
}