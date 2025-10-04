using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class frmYedegiSistemeGeriDon : DevExpress.XtraEditors.XtraForm
    {
        public frmYedegiSistemeGeriDon()
        {
            InitializeComponent();
        }

        private void beDosya_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            openFileDialog1.ShowDialog();
            beDosya.EditValue = openFileDialog1.FileName;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ýþlem tamamlanana kadar bütün kullanýcýlar durdurulacaktýr.\nÝþleme devam etmek istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            if (!string.IsNullOrEmpty(beDosya.EditValue.ToString()))
            {
                btnRestore.Enabled = false;
                Restore(beDosya.EditValue.ToString());
                btnRestore.Enabled = true;
            }
        }

        private void frmYedegiSistemeGeriDon_Load(object sender, EventArgs e)
        {
            //txtYedekYer.Text = Application.StartupPath + "\\YedekBak";
            //DirectoryInfo di = new DirectoryInfo(txtYedekYer.Text);
            //List<string> sonuc = new List<string>();
            //FileInfo[] fi = di.GetFiles();
            //foreach (FileInfo var in fi)
            //{
            //    sonuc.Add(var.Name.ToString());
            //}
            //lueYedeklenecekVeriTabani.Properties.DataSource = sonuc;

            //TODO:SMO ILE ILGILI OLARAK COMMENT EDILDI bir altta tek satýr

            //            lueRestoreEdilecekVeriTabani.Properties.DataSource = VeriTabaniKullancilariMetotlar.MevcutVeriTabani("");
        }

        private void Restore(string dosya)
        {
            List<AvukatProLib.CompInfo> list = new List<AvukatProLib.CompInfo>();
            list = AvukatProLib.CompInfo.CompInfoListGetir();
            if (list == null || list.Count < 1)
                return;
            try
            {
                SqlConnection cn = new SqlConnection(list[0].ConStrMK);
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();

                SqlCommand cmd = new SqlCommand("Alter Database " + list[0].HAVeriTabani + " SET SINGLE_USER With ROLLBACK IMMEDIATE ", cn);
                cmd.CommandTimeout = 999999999;
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("restore database " + list[0].HAVeriTabani + " from disk = '" + dosya + "' with recovery ", cn);
                cmd.CommandTimeout = 999999999;
                cmd.ExecuteNonQuery();

                cn.Close();
                cn.Dispose();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Restore iþlemi tamanlanamadý!\n" + ex.Message, "AVP BackUp");
            }
        }
    }
}