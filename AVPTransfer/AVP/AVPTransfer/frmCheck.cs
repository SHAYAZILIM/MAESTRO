using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AVPTransfer
{
    public partial class frmCheck : XtraForm
    {
        #region Constructors

        public frmCheck()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public SqlConnection DestinationConnection
        {
            get;
            set;
        }

        public SqlConnection SourceConnection
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        private void cmbExistTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbExistTables.SelectedIndex == -1)
                return;
            DataTable dt = new DataTable();
            dt.Columns.Add("Default", typeof(object));
            dt.Columns.Add("DBDefault", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Datatype", typeof(string));

            Table tbl = Utility.tblSource[Utility.tblSource.IndexOf(new Table(cmbExistTables.SelectedItem.ToString()))];
            DataRow dr = null;
            foreach (Column col in tbl.ColumnList)
            {
                if (col.RelationWith != null && col.AllowNull && !col.RelationWith.AllowNull && col.RelationWith.DBDefault.ToUpper().IndexOf("NULL") > -1)
                {
                    dr = dt.NewRow();
                    dr["DBDefault"] = col.DBDefault;
                    dr["Name"] = col.Name;
                    dr["Datatype"] = col.DataType;
                    dt.Rows.Add(dr);
                }
            }

            gridControl1.DataSource = dt;
        }

        private void cmbNotExistTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNotExistTables.SelectedIndex == -1)
                return;
            DataTable dt = new DataTable();
            dt.Columns.Add("Default", typeof(object));
            dt.Columns.Add("DBDefault", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Datatype", typeof(string));

            Table tbl = Utility.tblDestination[Utility.tblDestination.IndexOf(new Table(cmbNotExistTables.SelectedItem.ToString()))];
            DataRow dr = null;
            foreach (Column col in tbl.ColumnList)
            {
                if (col.RelationWith == null && !col.AllowNull && (string.IsNullOrEmpty(col.DBDefault) || col.DBDefault.ToUpper().IndexOf("NULL") > -1))
                {
                    dr = dt.NewRow();
                    dr["DBDefault"] = col.DBDefault;
                    dr["Name"] = col.Name;
                    dr["Datatype"] = col.DataType;
                    dt.Rows.Add(dr);
                }
            }

            gridControl1.DataSource = dt;
        }

        private void frmCheck_Load(object sender, EventArgs e)
        {
            foreach (Table tbl in Utility.tblDestination)
            {
                if (tbl.Relationtype == RelationType.Esit || tbl.Relationtype == RelationType.Bulunmuyor || tbl.Exporttype == ExportType.Aktarılmayacak)
                    continue;

                foreach (Column col in tbl.ColumnList)
                {
                    if (col.RelationWith == null && !col.AllowNull && (string.IsNullOrEmpty(col.DBDefault) || col.DBDefault.ToUpper().IndexOf("NULL") > -1))
                    {
                        cmbNotExistTables.Properties.Items.Add(tbl.Name);
                        break;
                    }
                }
            }
            foreach (Table tbl in Utility.tblSource)
            {
                if (tbl.Relationtype == RelationType.Esit || tbl.Relationtype == RelationType.Bulunmuyor || tbl.Exporttype == ExportType.Aktarılmayacak)
                    continue;

                foreach (Column col in tbl.ColumnList)
                {
                    if (col.RelationWith != null && col.AllowNull && !col.RelationWith.AllowNull && col.RelationWith.DBDefault.ToUpper().IndexOf("NULL") > -1)
                    {
                        cmbExistTables.Properties.Items.Add(tbl.Name);
                        break;
                    }
                }
            }
        }

        #endregion Methods
    }
}