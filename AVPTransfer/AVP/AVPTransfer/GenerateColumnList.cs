using System;
using System.Data;
using System.Data.SqlClient;

namespace AVPTransfer
{
    public partial class GenerateColumnList : DevExpress.XtraEditors.XtraForm
    {
        #region Constructors

        public GenerateColumnList()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public SqlConnection SourceConnection
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                SqlCommand cmd = SourceConnection.CreateCommand();
                cmd.CommandText = txtCommand.Text;
                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                txtFieldList.Text = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    txtFieldList.Text += dc.ColumnName + ",";
                }
            }
        }

        #endregion Methods
    }
}