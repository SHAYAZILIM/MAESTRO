using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AVPTransfer
{
    public partial class frmConnect : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        public int Company;
        public string DestConStr = "";
        public string SourceConStr = "";

        #endregion Fields

        #region Constructors

        public frmConnect()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string conStr = CreateConStr();
            if (String.IsNullOrEmpty(conStr)) return;
            if (TestConnection(conStr))
            {
                SourceConStr = conStr;
                btnTransfer.Enabled = true;
                MessageBox.Show("Veritabanı bağlantısı başarılı.");
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Company = (int)numCompany.Value;
            DialogResult = DialogResult.OK;
        }

        private string CreateConStr()
        {
            if ((cmbServerAddress.SelectedItem == null && String.IsNullOrEmpty(cmbServerAddress.Text)) || txtDbName.Text == "")
            {
                MessageBox.Show("Lütfen eksik alanları doldurun.");
                return "";
            }
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            if (cmbServerAddress.SelectedItem == null && String.IsNullOrEmpty(cmbServerAddress.Text))
            {
                MessageBox.Show("Lütfen server seçiniz.");
                return "";
            }
            builder.DataSource = cmbServerAddress.SelectedItem == null ? cmbServerAddress.Text : cmbServerAddress.SelectedItem.ToString();
            builder.InitialCatalog = txtDbName.Text;
            if (txtUser.Text.Trim() == "" || txtPass.Text.Trim() == "") builder.IntegratedSecurity = true;
            else
            {
                builder.UserID = txtUser.Text.Trim();
                builder.Password = txtPass.Text.Trim();
            }
            return builder.ConnectionString;
        }

        private void frmConnect_Load(object sender, EventArgs e)
        {
            DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow row in table.Rows)
            {
                cmbServerAddress.Properties.Items.Add(row["ServerName"].ToString());
            }
        }

        private bool TestConnection(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    con.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(String.Format("Veritabanı bağlantısı oluşturulamadı.\nHata: {0}", ex.Message));
                    return false;
                }
            }
        }

        #endregion Methods
    }
}