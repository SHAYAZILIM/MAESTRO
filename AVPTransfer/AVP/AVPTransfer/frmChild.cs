using System;
using System.Data;

namespace AVPTransfer
{
    public partial class frmChild : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        private DataTable dt;

        #endregion Fields

        #region Constructors

        public frmChild()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public bool IsSource
        {
            get;
            set;
        }

        public AVPTransfer.Table SelectedTable
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        private void frmChild_Load(object sender, EventArgs e)
        {
            dt = new DataTable();

            dt.Columns.Add("Kaynak Kolon", typeof(string));
            dt.Columns.Add("Kaynak Tipi", typeof(string));
            dt.Columns.Add("Hedef Kolon", typeof(string));
            dt.Columns.Add("Hedef Tipi", typeof(string));
            dt.Columns.Add("Convert", typeof(string));
            dt.Columns.Add("Coalesce", typeof(string));
            DataRow dr;
            if (IsSource)
            {
                foreach (Column clm in SelectedTable.ColumnList)
                {
                    dr = dt.NewRow();
                    dr[0] = clm.Name;
                    dr[1] = clm.DataType;
                    if (clm.RelationWith != null)
                    {
                        dr[2] = string.Format("{0} - {1}", clm.RelationWith.Parent.Name, clm.RelationWith.Name);
                        dr[3] = clm.RelationWith.DataType;
                    }
                    dr[4] = clm.Convert;
                    dr[5] = clm.Coalesce;
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                foreach (Column clm in SelectedTable.ColumnList)
                {
                    dr = dt.NewRow();
                    if (clm.RelationWith != null)
                    {
                        dr[0] = string.Format("{0} - {1}", clm.RelationWith.Parent.Name, clm.RelationWith.Name);
                        dr[1] = clm.RelationWith.DataType;
                    }
                    dr[2] = clm.Name;
                    dr[3] = clm.DataType;
                    dt.Rows.Add(dr);
                }
            }
            gridControl1.DataSource = dt;
        }

        #endregion Methods
    }
}