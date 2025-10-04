using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avukatpro.UserImport
{
    public partial class frmImport : Form
    {

        public frmImport()
        {
            InitializeComponent();
        }

        private void btnUserOpenFile_Click(object sender, EventArgs e)
        {
            if (opfUser.ShowDialog() == DialogResult.OK)
            {
                txtUserFile.Text = opfUser.FileName;
            }
        }

        private void btnSubeOpenFile_Click(object sender, EventArgs e)
        {
            if (opfSube.ShowDialog() == DialogResult.OK)
            {
                txtSubeFile.Text = opfSube.FileName;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            bckImport.RunWorkerAsync();
        }

        private void bckImport_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!string.IsNullOrEmpty(opfUser.FileName))
            {

                string connStr = Helper.GetConnectionString(opfUser.FileName);
                string sheetName = "";
                string query = @"Select * From [Sheet1$]";
                string runquery = "";
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connStr);
                DataTable rowDatas = new DataTable();
                conn.Open();


                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, conn);

                System.Data.OleDb.OleDbDataReader dr = cmd.ExecuteReader();
                string Ad = "";
                string Il = "";
                string Ilce = "";
                string Buro = "";
                string Gorev = "";
                string Tel = "";
                string CepTel = "";
                string Email = "";
                SqlCommand cmdcontol;
                int? ilceid = null;
                int? ilid = null;
                int? subeid = null;
                int? kullaniciid = null;
                int? cariid = null;
                SqlTransaction tran = null;
                Helper.Connection.Open();
                tran = Helper.Connection.BeginTransaction();
                while (dr.Read())
                {
                    Ad = dr[5].ToString();
                    kullaniciid = null;
                    cariid = null;

                    if (!string.IsNullOrEmpty(Ad))
                    {
                        Il = dr[1].ToString();
                        Ilce = dr[2].ToString();
                        if (!string.IsNullOrEmpty(dr[3].ToString()))
                        {
                            Buro = dr[3].ToString();
                            subeid = null;
                        }
                        Gorev = dr[4].ToString();
                        Tel = dr[6].ToString();
                        CepTel = dr[7].ToString();
                        Email = dr[8].ToString();


                        try
                        {
                            if (!string.IsNullOrEmpty(Ilce))
                            {
                                cmdcontol = new SqlCommand(Scripts.IlceSelect, Helper.Connection, tran);
                                cmdcontol.Parameters.Clear();
                                SqlParameter prmilce = new SqlParameter("@ILCE", Ilce);
                                cmdcontol.Parameters.Add(prmilce);
                                var ilcereader = cmdcontol.ExecuteReader();

                                while (ilcereader.Read())
                                {
                                    if (ilcereader[0] != null)
                                    {
                                        ilceid = ilcereader.GetInt32(0);
                                        break;
                                    }
                                }
                                ilcereader.Close();
                            }

                            if (!string.IsNullOrEmpty(Il))
                            {
                                cmdcontol = new SqlCommand(Scripts.IlSelect, Helper.Connection, tran);
                                cmdcontol.Parameters.Clear();
                                SqlParameter prmil = new SqlParameter("@IL", Il);
                                cmdcontol.Parameters.Add(prmil);
                                var ilreader = cmdcontol.ExecuteReader();

                                while (ilreader.Read())
                                {
                                    if (ilreader[0] != null)
                                    {
                                        ilid = ilreader.GetInt32(0);
                                        break;
                                    }
                                }
                                ilreader.Close();
                            }

                            if (!string.IsNullOrEmpty(Buro))
                            {
                                cmdcontol = new SqlCommand(Scripts.SubeSelect, Helper.Connection, tran);
                                cmdcontol.Parameters.Clear();
                                SqlParameter prmsube = new SqlParameter("@SUBE_ADI", Buro);
                                cmdcontol.Parameters.Add(prmsube);
                                var subereader = cmdcontol.ExecuteReader();

                                while (subereader.Read())
                                {
                                    if (subereader[0] != null)
                                    {
                                        subeid = subereader.GetInt32(0);
                                        break;
                                    }
                                }
                                subereader.Close();

                                if (!subeid.HasValue)
                                {
                                    cmdcontol = new SqlCommand(Scripts.SubeInsert, Helper.Connection, tran);
                                    cmdcontol.Parameters.Clear();
                                    SqlParameter prmsubeinsert = new SqlParameter("@SUBE_ADI", Buro);
                                    cmdcontol.Parameters.Add(prmsubeinsert);
                                    var d = cmdcontol.ExecuteScalar();
                                    subeid = int.Parse(d.ToString());
                                }
                            }

                            if (!string.IsNullOrEmpty(Ad))
                            {
                                cmdcontol = new SqlCommand(Scripts.CariSelect, Helper.Connection, tran);
                                cmdcontol.Parameters.Clear();
                                SqlParameter prmcariad = new SqlParameter("@AD", Ad);
                                cmdcontol.Parameters.Add(prmcariad);
                                var carikontrolreader = cmdcontol.ExecuteReader();

                                while (carikontrolreader.Read())
                                {
                                    if (carikontrolreader[0] != null)
                                    {
                                        cariid = carikontrolreader.GetInt32(0);
                                        break;
                                    }
                                }
                                carikontrolreader.Close();

                                if (!cariid.HasValue)
                                {
                                    cmdcontol = new SqlCommand(Scripts.CariInsert, Helper.Connection, tran);
                                    cmdcontol.Parameters.Clear();
                                    SqlParameter prmAd = new SqlParameter("@AD", Ad);
                                    cmdcontol.Parameters.Add(prmAd);
                                    SqlParameter prmIlceId = new SqlParameter("@ILCE_ID", ilceid);
                                    cmdcontol.Parameters.Add(prmIlceId);
                                    SqlParameter prmIlId = new SqlParameter("@IL_ID", ilid);
                                    cmdcontol.Parameters.Add(prmIlId);
                                    SqlParameter prmTel = new SqlParameter("@TEL_1", Tel);
                                    cmdcontol.Parameters.Add(prmTel);
                                    SqlParameter prmCepTel = new SqlParameter("@CEP_TEL", CepTel);
                                    cmdcontol.Parameters.Add(prmCepTel);
                                    SqlParameter prmEmail = new SqlParameter("@EMAIL_1", Email);
                                    cmdcontol.Parameters.Add(prmEmail);

                                    SqlParameter prmSubeid = new SqlParameter("@SUBE_KOD_ID", subeid);
                                    cmdcontol.Parameters.Add(prmSubeid);
                                    cariid = int.Parse(cmdcontol.ExecuteScalar().ToString());
                                }
                                cmdcontol = new SqlCommand(Scripts.KullaniciSelect, Helper.Connection, tran);
                                cmdcontol.Parameters.Clear();
                                SqlParameter prmkullaniciad = new SqlParameter("@KULLANICI_ADI", Ad.Replace(" ", "").Trim().ToLower());
                                cmdcontol.Parameters.Add(prmkullaniciad);
                                var kullanicikontrolreader = cmdcontol.ExecuteReader();

                                while (kullanicikontrolreader.Read())
                                {
                                    if (kullanicikontrolreader[0] != null)
                                    {
                                        kullaniciid = kullanicikontrolreader.GetInt32(0);
                                        break;
                                    }
                                }
                                kullanicikontrolreader.Close();

                                if (!kullaniciid.HasValue)
                                {
                                    cmdcontol = new SqlCommand(Scripts.KullaniciInsert, Helper.Connection, tran);
                                    cmdcontol.Parameters.Clear();
                                    SqlParameter prmKullaniciAd = new SqlParameter("@KULLANICI_ADI", Ad.Replace(" ", "").Trim().ToLower());
                                    cmdcontol.Parameters.Add(prmKullaniciAd);
                                    SqlParameter prmSifre = new SqlParameter("@KULLANICI_SIFRESI", Ad.Replace(" ", "").Trim().ToLower() + "123456");
                                    cmdcontol.Parameters.Add(prmSifre);
                                    SqlParameter prmKSubeid = new SqlParameter("@SUBE_ID", subeid);
                                    cmdcontol.Parameters.Add(prmKSubeid);
                                    SqlParameter prmkkSubeid = new SqlParameter("@KULLANICI_SUBE_ID", subeid);
                                    cmdcontol.Parameters.Add(prmkkSubeid);
                                    SqlParameter prmCariid = new SqlParameter("@CARI_ID", cariid);
                                    cmdcontol.Parameters.Add(prmCariid);
                                    cmdcontol.ExecuteNonQuery();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Helper.Logger.ErrorException("hata", ex);
                        }
                        finally
                        {

                        }
                    }
                }
                try
                {
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    Helper.Logger.ErrorException("hata", ex);
                }
                finally
                {
                    Helper.Connection.Close();
                }

                MessageBox.Show("İşlem Bitmiştir.");
                //rowDatas.Load(dr);
                dr.Close();


                conn.Close();
            }
        }

        private void bckImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel1.Enabled = true;
        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            Helper.List = AvukatProLib.CompInfo.CompInfoListGetir();

        }
    }
}
