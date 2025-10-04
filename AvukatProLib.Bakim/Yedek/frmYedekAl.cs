using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AvukatProLib.Bakim
{
    public partial class frmYedekAl : DevExpress.XtraEditors.XtraForm
    {
        public frmYedekAl()
        {
            InitializeComponent();
        }

        private bool BackUp(string path, string fileName)
        {
            List<AvukatProLib.CompInfo> list = new List<AvukatProLib.CompInfo>();
            list = AvukatProLib.CompInfo.CompInfoListGetir();
            if (list == null || list.Count < 1)
                return false;
            try
            {
                SqlConnection cn = new SqlConnection(list[0].ConStr);
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                SqlCommand cmd = new SqlCommand("backup database " + list[0].HAVeriTabani + " to disk = '" + path + "\\" + fileName + ".bak' with INIT", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                cn.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void beDosyaYolu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            beDosyaYolu.EditValue = folderBrowserDialog1.SelectedPath;
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(beDosyaYolu.EditValue.ToString()) && !string.IsNullOrEmpty(txtDosyaAdý.Text))
            {
                btnBackUp.Enabled = false;
                BackUp(beDosyaYolu.EditValue.ToString(), txtDosyaAdý.Text);
                btnBackUp.Enabled = true;
            }
        }

        private void frmYedekAl_Load(object sender, EventArgs e)
        {
        }
    }
}