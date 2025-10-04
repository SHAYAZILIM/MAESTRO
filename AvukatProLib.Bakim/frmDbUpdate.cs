using AvukatProLib.DbUpdate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class frmDbUpdate : Form
    {
        public frmDbUpdate()
        {
            InitializeComponent();
        }

        private string dosya = Application.StartupPath + "\\AvukatproLib.Bakim2.dll";

        public void DosyayaYaz(string Yazilacak)
        {
            if (File.Exists(dosya))
            {
                File.Delete(dosya);
            }
            StreamWriter writer = new StreamWriter(dosya);
            writer.Write(Yazilacak);
            writer.Close();
            this.Dispose(true);
        }

        private void frmDbUpdate_Load(object sender, EventArgs e)
        {
            string StartupPath = Application.StartupPath;
            this.Visible = false;
            List<CompInfo> cmps = CompInfo.CmpNfoList;
            if (cmps.Count > 0)
            {
                foreach (CompInfo ci in cmps)
                {
                    SqlConnection con = new SqlConnection(ci.ConStr);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "select top(1) DB_VERSIYON from TDIE_BIL_DB_VERSION order by KAYIT_TARIHI desc";
                        cmd.CommandTimeout = 10000;
                        cmd.CommandType = System.Data.CommandType.Text;
                        string sonuc = cmd.ExecuteScalar() as string;
                        if (sonuc != null)
                        {
                            //TODO: Her exe güncellemesinde db versionun güncelleneceði yer
                            if (DbUpdate.DbUpdater.UpdateDb(new DbVersion(sonuc), new DbVersion(37, 1, 0), ci.ConStr, StartupPath))
                            {
                                DosyayaYaz("1");
                            }
                            else
                            {
                                DosyayaYaz("0");
                            }
                        }
                    } //Eðer Exception yazarsak InsallException ýda yakalarýz iþimiz bozulur.
                    catch
                    {
                        DosyayaYaz("0");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            Application.Exit();
            Application.ExitThread();
        }
    }
}