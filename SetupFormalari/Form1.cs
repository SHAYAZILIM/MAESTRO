using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SetupFormalari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public Form1(System.Configuration.Install.InstallContext context, bool DevamMi)
        {
            formContext = context;
            this.DevamMi = DevamMi;
            InitializeComponent();
            this.CenterToScreen();
            CheckForIllegalCrossThreadCalls = false;
        }

        public string ModulNo = "350";
        public string UrunAdi = "";
        private string AppPath = "";
        private string cnn = "";
        private string cnnn = "";
        private string CnString = "data source=94.138.206.50\\SQLEXPRESS;database=AVPYONETIM;uid=avp;pwd=PASSWRD1;";
        private bool DevamMi;
        private System.Configuration.Install.InstallContext formContext;
        private string Surum = "052013.006";
        private string Versiyon = "V1";

        private enum IslemTipi { Başarılı, HataOlustu, IptalEdildi }

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);

        private static void DirectoryCopy(string kaynakKlasör, string hedefKlasör, bool altKlasörlerdeKopyalansınMı)
        {
            DirectoryInfo dir = new DirectoryInfo(kaynakKlasör);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(hedefKlasör))
                Directory.CreateDirectory(hedefKlasör);

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(hedefKlasör, file.Name);
                file.CopyTo(temppath, true);
            }

            if (altKlasörlerdeKopyalansınMı)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string geçiciKlasör = Path.Combine(hedefKlasör, subdir.Name);
                    DirectoryCopy(subdir.FullName, geçiciKlasör, altKlasörlerdeKopyalansınMı);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = cnn.Replace("database=master", "database=" + txtDataBase.Text);

            #region tablo güncelleme

            string[] table = null;
            List<string> listTable = new List<string>();

            lblIslem.Text = "Tablolar oluşturulurken lütfen bekleyin...";
            if (File.Exists(AppPath + "/SQLSCRIPTS/TableUpdater.dbu"))
            {
                //Thread.Sleep(10);
                FileStream fs = new FileStream(AppPath + "/SQLSCRIPTS/TableUpdater.dbu", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                table = sr.ReadToEnd().Split(new string[] { "--@Son" }, StringSplitOptions.None);
                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();
                if (progressBar2.InvokeRequired)
                {
                    progressBar2.Invoke((MethodInvoker)delegate
                    {
                        progressBar2.Maximum = table.Length * 3;
                        progressBar2.Value = 0;
                    });
                }
                else
                {
                    progressBar2.Maximum = table.Length * 3;
                    progressBar2.Value = 0;
                }

                foreach (string item in table)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        //Thread.Sleep(10);
                        if (!item.Contains("ALTER "))
                            cn.ExcuteQuery(item);
                    }
                    catch
                    {
                        listTable.Add(item);
                    }
                }

                foreach (string item in listTable)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        if (!item.Contains("ALTER "))
                        {
                            //Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listTable.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in listTable)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        if (!item.Contains("ALTER "))
                        {
                            //Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listTable.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in listTable)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        if (!item.Contains("ALTER "))
                        {
                            //Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listTable.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }

            progressBar1.Value += 10;
            checkedListBox1.SetItemChecked(3, true);

            #endregion tablo güncelleme

            #region tanım güncelleme

            Thread.Sleep(1000);
            lblIslem.Text = "Tanımlar oluşturulurken lütfen bekleyin...";

            for (int x = 1; x < 200; x++)
            {
                if (File.Exists(AppPath + "/SQLSCRIPTS/TanimlarUpdater" + x + ".dbu"))
                {
                    if (progressBar2.InvokeRequired)
                    {
                        progressBar2.Invoke((MethodInvoker)delegate
                        {
                            progressBar2.Maximum = File.ReadAllLines(AppPath + "/SQLSCRIPTS/TanimlarUpdater" + x + ".dbu").Length;
                            progressBar2.Value = 0;
                        });
                    }

                    else
                    {
                        progressBar2.Maximum = File.ReadAllLines(AppPath + "/SQLSCRIPTS/TanimlarUpdater" + x + ".dbu").Length;
                        progressBar2.Value = 0;
                    }
                    FileStream fs = new FileStream(AppPath + "/SQLSCRIPTS/TanimlarUpdater" + x + ".dbu", FileMode.Open);
                    StreamReader sr = new StreamReader(fs);

                    //Thread.Sleep(1000);
                    for (int i = 0; i < progressBar2.Maximum; i++)
                    {
                        progressBar2.Value++;
                        try
                        {
                            string aa = sr.ReadLine();
                            if (!string.IsNullOrEmpty(aa) & aa != "--@Son")
                            {
                                try
                                {
                                    //Thread.Sleep(10);
                                    cn.ExcuteQuery(aa);
                                }
                                catch { ;}
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    sr.Close();
                    sr.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                else
                    break;
            }

            Thread.Sleep(1000);
            progressBar1.Value += 10;
            checkedListBox1.SetItemChecked(4, true);

            #endregion tanım güncelleme

            #region cetvel güncelleme

            lblIslem.Text = "Cetveller oluşturulurken lütfen bekleyin...";

            for (int x = 1; x < 200; x++)
            {
                if (File.Exists(AppPath + "/SQLSCRIPTS/CetvelUpdater" + x + ".dbu"))
                {
                    if (progressBar2.InvokeRequired)
                    {
                        progressBar2.Invoke((MethodInvoker)delegate
                        {
                            progressBar2.Maximum = File.ReadAllLines(AppPath + "/SQLSCRIPTS/CetvelUpdater" + x + ".dbu").Length;
                            progressBar2.Value = 0;
                        });
                    }

                    else
                    {
                        progressBar2.Maximum = File.ReadAllLines(AppPath + "/SQLSCRIPTS/CetvelUpdater" + x + ".dbu").Length;
                        progressBar2.Value = 0;
                    }

                    FileStream fs = new FileStream(AppPath + "/SQLSCRIPTS/CetvelUpdater" + x + ".dbu", FileMode.Open);
                    StreamReader sr = new StreamReader(fs);

                    //Thread.Sleep(1000);
                    for (int i = 0; i < progressBar2.Maximum; i++)
                    {
                        progressBar2.Value++;
                        try
                        {
                            string aa = sr.ReadLine();
                            if (!string.IsNullOrEmpty(aa) & aa != "--@Son")
                            {
                                try
                                {
                                    //Thread.Sleep(10);
                                    cn.ExcuteQuery(aa);
                                }
                                catch { ;}
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    sr.Close();
                    sr.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                else
                    break;
            }

            progressBar1.Value += 10;
            checkedListBox1.SetItemChecked(5, true);

            #endregion cetvel güncelleme

            #region rapor güncelleme

            //Thread.Sleep(1000);
            lblIslem.Text = "Raporlar oluşturulurken lütfen bekleyin...";
            if (File.Exists(AppPath + "/SQLSCRIPTS/RaporUpdater.dbu"))
            {
                if (progressBar2.InvokeRequired)
                {
                    progressBar2.Invoke((MethodInvoker)delegate
                    {
                        progressBar2.Maximum = File.ReadAllLines(AppPath + "/SQLSCRIPTS/RaporUpdater.dbu").Length;
                        progressBar2.Value = 0;
                    });
                }

                else
                {
                    progressBar2.Maximum = File.ReadAllLines(AppPath + "/SQLSCRIPTS/RaporUpdater.dbu").Length;
                    progressBar2.Value = 0;
                }

                FileStream fs = new FileStream(AppPath + "/SQLSCRIPTS/RaporUpdater.dbu", FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                for (int i = 0; i < progressBar2.Maximum; i++)
                {
                    progressBar2.Value++;
                    try
                    {
                        string aa = sr.ReadLine();
                        if (!string.IsNullOrEmpty(aa) & aa != "--@Son")
                        {
                            try
                            {
                                //Thread.Sleep(10);
                                cn.ExcuteQuery(aa);
                            }
                            catch { ;}
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();
            }

            progressBar1.Value += 10;
            checkedListBox1.SetItemChecked(6, true);

            #endregion rapor güncelleme

            #region şablon güncelleme

            lblIslem.Text = "Şablonlar oluşturulurken lütfen bekleyin...";

            for (int x = 1; x < 200; x++)
            {
                if (File.Exists(AppPath + "/SQLSCRIPTS/SablonUpdater" + x + ".dbu"))
                {
                    if (progressBar2.InvokeRequired)
                    {
                        progressBar2.Invoke((MethodInvoker)delegate
                        {
                            progressBar2.Maximum = File.ReadAllLines(AppPath + "/SQLSCRIPTS/SablonUpdater" + x + ".dbu").Length;
                            progressBar2.Value = 0;
                        });
                    }
                    else
                    {
                        progressBar2.Maximum = File.ReadAllLines(AppPath + "/SQLSCRIPTS/SablonUpdater" + x + ".dbu").Length;
                        progressBar2.Value = 0;
                    }
                    FileStream fs = new FileStream(AppPath + "/SQLSCRIPTS/SablonUpdater" + x + ".dbu", FileMode.Open);
                    StreamReader sr = new StreamReader(fs);

                    for (int i = 0; i < progressBar2.Maximum; i++)
                    {
                        progressBar2.Value++;
                        string aa = sr.ReadLine();
                        if (!string.IsNullOrEmpty(aa) & aa != "--@Son")
                        {
                            try
                            {
                                //Thread.Sleep(10);
                                cn.ExcuteQuery(aa);
                            }
                            catch { ;}
                        }
                    }

                    sr.Close();
                    sr.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                else
                    break;
            }

            progressBar1.Value += 10;
            checkedListBox1.SetItemChecked(7, true);

            #endregion şablon güncelleme

            #region key güncelleme

            lblIslem.Text = "Keyler oluşturulurken lütfen bekleyin...";
            if (File.Exists(AppPath + "/SQLSCRIPTS/TableUpdater.dbu"))
            {
                if (progressBar2.InvokeRequired)
                {
                    progressBar2.Invoke((MethodInvoker)delegate
                    {
                        progressBar2.Maximum = table.Length * 3;
                        progressBar2.Value = 0;
                    });
                }

                else
                {
                    progressBar2.Maximum = table.Length * 3;
                    progressBar2.Value = 0;
                }

                listTable = new List<string>();

                foreach (string item in table)
                {
                    try
                    {
                        progressBar2.Value++;
                        if (item.Contains("ALTER"))
                        {
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                        }
                    }
                    catch
                    {
                        listTable.Add(item);
                    }
                }

                foreach (string item in listTable)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        if (item.Contains("ALTER"))
                        {
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listTable.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in listTable)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        if (item.Contains("ALTER"))
                        {
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listTable.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }

            checkedListBox1.SetItemChecked(8, true);

            #endregion key güncelleme

            #region view güncelleme

            string[] view = null;
            List<string> listView = new List<string>();

            lblIslem.Text = "Viewler oluşturulurken lütfen bekleyin...";
            if (File.Exists(AppPath + "/SQLSCRIPTS/ViewUpdater.dbu"))
            {
                FileStream fs = new FileStream(AppPath + "/SQLSCRIPTS/ViewUpdater.dbu", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                view = sr.ReadToEnd().Split(new string[] { "--@Son" }, StringSplitOptions.None);
                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();

                if (progressBar2.InvokeRequired)
                {
                    progressBar2.Invoke((MethodInvoker)delegate
                    {
                        progressBar2.Maximum = view.Length * 4;
                        progressBar2.Value = 0;
                    });
                }

                else
                {
                    progressBar2.Maximum = view.Length * 4;
                    progressBar2.Value = 0;
                }

                foreach (string item in view)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        Thread.Sleep(10);
                        cn.ExcuteQuery(item);
                    }
                    catch
                    {
                        listView.Add(item);
                    }
                }

                foreach (string item in view)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }

                        if (listView.Contains(item))
                        {
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listView.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in view)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }

                        if (listView.Contains(item))
                        {
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listView.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in view)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }

                        if (listView.Contains(item))
                        {
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listView.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }

            progressBar1.Value += 10;
            checkedListBox1.SetItemChecked(9, true);

            #endregion view güncelleme

            #region procedure güncelleme

            string[] proc = null;
            List<string> listproc = new List<string>();

            lblIslem.Text = "Procedureler oluşturulurken lütfen bekleyin...";

            for (int x = 1; x < 200; x++)
            {
                if (File.Exists(AppPath + "/SQLSCRIPTS/ProcedureUpdater" + x + ".dbu"))
                {
                    FileStream fs = new FileStream(AppPath + "/SQLSCRIPTS/ProcedureUpdater" + x + ".dbu", FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    proc = sr.ReadToEnd().Split(new string[] { "--@Son" }, StringSplitOptions.None);
                    sr.Close();
                    sr.Dispose();
                    fs.Close();
                    fs.Dispose();

                    if (progressBar2.InvokeRequired)
                    {
                        progressBar2.Invoke((MethodInvoker)delegate
                        {
                            progressBar2.Maximum = proc.Length * 2;
                            progressBar2.Value = 0;
                        });
                    }

                    else
                    {
                        progressBar2.Maximum = proc.Length * 2;
                        progressBar2.Value = 0;
                    }

                    foreach (string item in proc)
                    {
                        try
                        {
                            if (progressBar2.InvokeRequired)
                            {
                                progressBar2.Invoke((MethodInvoker)delegate
                                {
                                    progressBar2.Value++;
                                });
                            }
                            else
                            {
                                progressBar2.Value++;
                            }
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                        }
                        catch
                        {
                            listproc.Add(item);
                        }
                    }
                }
                else
                    break;
            }

            progressBar1.Value += 10;
            checkedListBox1.SetItemChecked(10, true);

            #endregion procedure güncelleme

            #region function güncelleme

            lblIslem.Text = "Functionlar oluşturulurken lütfen bekleyin...";
            if (File.Exists(AppPath + "/SQLSCRIPTS/FunctionUpdater.dbu"))
            {
                FileStream fs = new FileStream(AppPath + "/SQLSCRIPTS/FunctionUpdater.dbu", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string[] func = sr.ReadToEnd().Split(new string[] { "--@Son" }, StringSplitOptions.None);
                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();

                if (progressBar2.InvokeRequired)
                {
                    progressBar2.Invoke((MethodInvoker)delegate
                    {
                        progressBar2.Maximum = (func.Length * 3) + view.Length + proc.Length;
                        progressBar2.Value = 0;
                    });
                }

                else
                {
                    progressBar2.Maximum = (func.Length * 3) + view.Length + proc.Length;
                    progressBar2.Value = 0;
                }

                foreach (string item in func)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        Thread.Sleep(10);
                        cn.ExcuteQuery(item);
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in func)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        Thread.Sleep(10);
                        cn.ExcuteQuery(item);
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in func)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        Thread.Sleep(10);
                        cn.ExcuteQuery(item);
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in listView)
                {
                    try
                    {
                        if (listView.Contains(item))
                        {
                            if (progressBar2.InvokeRequired)
                            {
                                progressBar2.Invoke((MethodInvoker)delegate
                                {
                                    progressBar2.Value++;
                                });
                            }
                            else
                            {
                                progressBar2.Value++;
                            }
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listView.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }
                foreach (string item in listproc)
                {
                    try
                    {
                        if (listView.Contains(item))
                        {
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listView.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in listproc)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }

                        if (listproc.Contains(item))
                        {
                            if (progressBar2.InvokeRequired)
                            {
                                progressBar2.Invoke((MethodInvoker)delegate
                                {
                                    progressBar2.Value++;
                                });
                            }
                            else
                            {
                                progressBar2.Value++;
                            }
                            Thread.Sleep(10);
                            cn.ExcuteQuery(item);
                            //listproc.Remove(item);
                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }

            progressBar1.Value += 10;
            checkedListBox1.SetItemChecked(11, true);

            #endregion function güncelleme

            #region trigger güncelleme

            lblIslem.Text = "Triggerlar oluşturulurken lütfen bekleyin...";
            if (File.Exists(AppPath + "/SQLSCRIPTS/TriggerUpdater.dbu"))
            {
                FileStream fs = new FileStream(AppPath + "/SQLSCRIPTS/TriggerUpdater.dbu", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string[] trig = sr.ReadToEnd().Split(new string[] { "--@Son" }, StringSplitOptions.None);
                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();
                if (progressBar2.InvokeRequired)
                {
                    progressBar2.Invoke((MethodInvoker)delegate
                    {
                        progressBar2.Maximum = trig.Length * 3;
                        progressBar2.Value = 0;
                    });
                }

                else
                {
                    progressBar2.Maximum = trig.Length * 3;
                    progressBar2.Value = 0;
                }

                foreach (string item in trig)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        Thread.Sleep(10);
                        cn.ExcuteQuery(item);
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in trig)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        Thread.Sleep(10);
                        cn.ExcuteQuery(item);
                    }
                    catch
                    {
                        ;
                    }
                }

                foreach (string item in trig)
                {
                    try
                    {
                        if (progressBar2.InvokeRequired)
                        {
                            progressBar2.Invoke((MethodInvoker)delegate
                            {
                                progressBar2.Value++;
                            });
                        }
                        else
                        {
                            progressBar2.Value++;
                        }
                        Thread.Sleep(10);
                        cn.ExcuteQuery(item);
                    }
                    catch
                    {
                        ;
                    }
                }
            }

            progressBar1.Value += 10;
            checkedListBox1.SetItemChecked(12, true);

            #endregion trigger güncelleme
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.CancelAsync();
            Bitti();
        }

        private void Bitti()
        {
            checkedListBox1.SetItemChecked(13, true);

            try
            {
                GecmisiGuncelle(IslemTipi.Başarılı);
            }
            catch
            {
                MessageBox.Show("Lisans sunucusuna bağlantı kurulamadı...");
            }

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = cnnn;

            cmbGrup.DataSource = cn.GetDataTable("SELECT ID,ADI FROM dbo.TDI_KOD_KULLANICI_GRUP order by ADI");
            cmbGrup.ValueMember = "ID";
            cmbGrup.DisplayMember = "ADI";

            cmbSube.DataSource = cn.GetDataTable("SELECT ID,SUBE_ADI FROM dbo.TDIE_BIL_KULLANICI_SUBELERI order by SUBE_ADI");
            cmbSube.ValueMember = "ID";
            cmbSube.DisplayMember = "SUBE_ADI";

            tabControl1.TabPages[2].Enabled = false;
            tabControl1.TabPages[3].Enabled = true;

            checkedListBox1.SetItemChecked(3, true);
            checkedListBox1.SetItemChecked(4, true);
            checkedListBox1.SetItemChecked(5, true);
            checkedListBox1.SetItemChecked(6, true);
            checkedListBox1.SetItemChecked(7, true);
            checkedListBox1.SetItemChecked(8, true);
            checkedListBox1.SetItemChecked(9, true);
            checkedListBox1.SetItemChecked(10, true);
            checkedListBox1.SetItemChecked(11, true);
            checkedListBox1.SetItemChecked(12, true);
            checkedListBox1.SetItemChecked(13, true);
            checkedListBox1.SetItemChecked(14, true);
            progressBar1.Value = 100;

            tabControl1.SelectedTab = tabControl1.TabPages[3];
        }

        private void btnAtlaVeritabani_Click(object sender, EventArgs e)
        {
            GecmisiGuncelle(IslemTipi.IptalEdildi);
            DevamMi = true;
            this.Close();
        }

        private void btnCariAtla_Click(object sender, EventArgs e)
        {
            DevamMi = true;
            this.Close();
        }

        private void btnCariEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCariAdi.Text))
            {
                MessageBox.Show("Lütfen şahıs adı giriniz...");
                return;
            }

            if (txtKullaniciAdi.TextLength < 8)
            {
                MessageBox.Show("Kullanıcı adı en az 8 karakterden oluşmalıdır...");
                return;
            }

            if (txtParola.TextLength < 8)
            {
                MessageBox.Show("Parola en az 8 karakterden oluşmalıdır...");
                return;
            }

            if (cmbGrup.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen grup seçiniz...");
                return;
            }

            if (cmbSube.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen şube seçiniz...");
                return;
            }

            try
            {
                ABSqlConnection cn = new ABSqlConnection();
                cnnn = cnn.Replace("database=master", "database=" + txtDataBase.Text);
                cn.CnString = cnnn;

                if (cn.GetDataTable("select KULLANICI_ADI from dbo.TDI_BIL_KULLANICI_LISTESI where KULLANICI_ADI='" + txtKullaniciAdi.Text + "'").Rows.Count > 0)
                {
                    MessageBox.Show("Kullanıcı Adı sistemde kayıtlı...");
                    return;
                }

                int kod = Convert.ToInt32(cn.ExecuteScalar("SELECT MAX(CONVERT(int,KOD)) + 1 FROM dbo.AV001_TDI_BIL_CARI"));

                cn.ExcuteQuery("INSERT [dbo].[AV001_TDI_BIL_CARI] ([KOD], [AD], [UNVAN], [FIRMA_TUR_ID], [FIRMA_TURU], [TICARI_SICIL_YERI_ID], [TICARI_SICIL_YERI], [TICARI_SICIL_TARIHI], [SICIL_NO], [SUBE_CARI_KARTI], [BANKA_ID], [BANKA], [BANKA_SUBE_ID], [BANKA_SUBE], [AKTIF_ADRES_3], [AKTIF_ADRES_2], [AKTIF_ADRES], [ADRES_1], [ADRES_2], [ADRES_3], [ADRES2_1], [ADRES2_2], [ADRES2_3], [ADRES3_1], [ADRES3_2], [ADRES3_3], [ILCE_ID], [ILCE], [IL_ID], [IL], [ULKE_ID], [ULKE], [POSTA_KODU], [ILCE2_ID], [ILCE2], [IL2_ID], [IL2], [ULKE2_ID], [ULKE2], [POSTA_KODU2], [ILCE3_ID], [ILCE3], [IL3_ID], [IL3], [ULKE3_ID], [ULKE3], [POSTA_KODU3], [TEL_1], [TEL_2], [FAX], [CEP_TEL], [CEP_TEL2], [EV_TEL], [EMAIL_1], [EMAIL_2], [WEB], [MESLEK_ID], [MESLEK], [REFERANS_CARI_ID], [REFERANS_CARI], [UNVAN_1_ID], [UNVAN_1], [UNVAN_2_ID], [UNVAN_2], [YETKILI_CARI_1_ID], [YETKILI_CARI_1], [GOREVI_1], [DAHILI_1], [YETKILI_CARI_2_ID], [YETKILI_CARI_2], [GOREVI_2], [DAHILI_2], [OZEL_KOD_1_ID], [OZEL_KOD_1], [OZEL_KOD_2_ID], [OZEL_KOD_2], [OZEL_KOD_3_ID], [OZEL_KOD_3], [OZEL_KOD_4_ID], [OZEL_KOD_4], [IS_SOZLESME_ID], [IS_SOZLESMESI], [VERGI_NO_KULLANIYOR_MU], [VERGI_DAIRESI], [VERGI_NO], [SG_NO_KULLANIYOR_MU], [SG_NO], [MUVEKKIL_MI], [KARSI_TARAF_MI], [FIRMA_MI], [PERSONEL_MI], [AVUKAT_MI], [BILIRKISI_MI], [AVUKAT_ORTAKLIGI_MI], [ADLI_BIRIM_MI], [ADLI_PERSONEL_MI], [HARCDAN_MUAF_MI], [KAMU_CARI_MI], [HASIMSIZ_CARISI_MI], [RESIM_AD], [BARO_AVUKATLIK_ORTAKLIGI_SICIL_NO], [KAYITLI_OLDUGU_BARO], [BARO_SICIL_NO], [BARO_BIRLIK_SICIL_NO], [KARA_LISTEDE_MI], [BEYAZ_LISTEDE_MI], [RESIM], [OZEL_NOT], [KAYIT_TARIHI], [KLASOR_KODU], [SUBE_KODU], [ADMIN_KAYIT_MI], [KONTROL_NE_ZAMAN], [KONTROL_KIM], [KONTROL_VERSIYON], [STAMP], [ADRES_TUR_ID], [ADRES_TUR], [ADRES2_TUR_ID], [ADRES2_TUR], [ADRES3_TUR_ID], [ADRES3_TUR], [KURUM_AVUKATI_MI], [TEL_1_DAHILI], [TEL_2_DAHILI], [EV_FAX], [YETKILI_MI], [ADRES_SEMT_ID], [ADRES2_SEMT_ID], [ADRES3_SEMT_ID], [ADRES_SEMT], [ADRES2_SEMT], [ADRES3_SEMT], [ADRES_TARIF], [ADRES2_TARIF], [ADRES3_TARIF], [RENK], [ISE_GIRIS_TARIHI], [ISTEN_CIKIS_TARIHI], [RUHSAT_TARIHI], [BAGLI_OLDUGU_YETKILI_CARI_ID], [DIL_ID], [SON_MEZUN_OLDUGU_OKUL_ID], [HAKEM_MI], [KURULUS_TARIHI], [MUSTERI_NO], [CALISMAYA_BASLAMA_TARIHI], [SAHIS_DURUM_ID], [ADRES_1_DURUM_ID], [ADRES_2_DURUM_ID], [ADRES_3_DURUM_ID], [BAGLI_OLDUGU_GRUP_ID], [KONTROL_KIM_ID], [SUBE_KOD_ID], [AJANDADA_GORUNSUN_MU], [AJANDA_GORUNEN_AD], [TEMSIL_TIPI], [UNVAN_3_ID], [YETKILI_CARI_3_ID], [GOREVI_3], [DAHILI_3], [IBAN_NO], [IFLASA_TABI_MI], [ESKI_UNVANI_ADI]) VALUES (N'" + kod + "', N'" + txtCariAdi.Text + "', N'', NULL, N'', NULL, N'', NULL, N'', 0, NULL, N'', NULL, N'', 0, 0, 1, N'', N'', N'', N'', N'', N'', N'', N'', N'', NULL, N'', NULL, N'', NULL, N'', N'', NULL, N'', NULL, N'', NULL, N'', N'', NULL, N'', NULL, N'', NULL, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', NULL, N'', NULL, N'', NULL, N'', NULL, N'', NULL, N'', N'', N'1011', NULL, N'', N'', N'1012', NULL, N'', NULL, N'', NULL, N'', NULL, N'', NULL, N'', 0, N'', N'', 0, N'', 0, 0, " + (rbGercek.Checked ? 0 : 1) + ", 1, " + (chkAvukat.Checked ? 1 : 0) + ", 0, 0, 0, 0, 0, 0, 0, N'', N'', N'', N'', N'', 0, 0, NULL, N'', getdate(), N'GENEL', 1, 0, getdate(), N'AVUKATPRO', 1, 1, NULL, N'', NULL, N'', NULL, N'', 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, N'', N'', NULL, NULL, NULL)");

                string sonuc = cn.ExecuteScalar("select ID from dbo.AV001_TDI_BIL_CARI where KOD='" + kod + "'").ToString();

                cn.ExcuteQuery("INSERT [dbo].[TDI_BIL_KULLANICI_LISTESI] ([KULLANICI_ADI], [KULLANICI_SIFRESI], [KULLANICI_GRUP_ID], [GRUP_KISA_ADI], [PROGRAM_MODUL], [KULLANICI_YETKI_SEVIYESI], [KULLANICI_AKTIF], [SIFRE_GUNCELLEME_PERYODU], [SIFRE_GUNCELLEME_ZAMANI], [KAYIT_TARIHI], [SUBE_ID], [KONTROL_NE_ZAMAN], [KONTROL_KIM], [KONTROL_VERSIYON], [STAMP], [KULLANICI_SUBE_ID], [HASHED_CODE], [CARI_ID], [STYLE], [EMAIL], [HATALI_GIRIS]) VALUES ('" + txtKullaniciAdi.Text + "', '" + txtParola.Text + "', " + cmbGrup.SelectedValue + ", N'N', 127, 999, 1, 0, NULL, getdate(), " + cmbSube.SelectedValue + ", getdate(), N'AVUKATPRO', 1, 1, " + cmbSube.SelectedValue + ", N'z', " + sonuc + ", N'VS2010', N'noemail@avukatpro.com', 0)");

                txtCariAdi.Text = "";
                txtKullaniciAdi.Text = "";
                txtParola.Text = "";
                //cmbGrup.SelectedIndex = -1;
                //cmbSube.SelectedIndex = -1;
                chkAvukat.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("İşlem sırasında hata oluştu.\n" + ex.Message);
            }
        }

        private void btnDevamLisans_Click(object sender, EventArgs e)
        {
            string ComputerInfo = "";
            ManagementClass islemci;
            islemci = new ManagementClass("Win32_ComputerSystemProduct");
            foreach (ManagementObject cpu in islemci.GetInstances())
            {
                ComputerInfo = Convert.ToString(cpu["UUID"]);
            }

            if (rbtnOnlineKurulum.Checked)
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = CnString;

                cn.Clear();
                cn.AddParams("@KullaniciAdi", txtEmail.Text);
                cn.AddParams("@BilgisayarBilgisi", ComputerInfo);
                cn.AddParams("@LisansNo", txtLisansNo.Text);
                //cn.AddParams("@UrunID", ModulNo);
                DataTable dt = cn.GetDataTable("select a.*,c.UrunAdi from dbo.Lisanslar(nolock) a inner join dbo.Kullanicilar(nolock) b on b.MusteriID=a.MusteriID inner join dbo.Urunler(nolock) c on c.ModulNo=a.UrunID where b.KullaniciAdi=@KullaniciAdi and a.Durumu=1 and (BilgisayarBilgisi='' or BilgisayarBilgisi is null or BilgisayarBilgisi=@BilgisayarBilgisi) and a.LisansNo=@LisansNo and a.BitisTarihi>GETDATE()");

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Lisans bilgileri doğrulanamadı.\nLütfen bilgilerinizi kontrol edin.\n\n* Mail adresi hatalı olabilir.\n* Lisans anahtarı hatalı olabilir.\n* Lisans bitiş tarihiniz geçmiş olabilir.\n\nEğer bilgilerinizde eksiklik yoksa lütfen Avukat Market'deki müşteri temsilcinizle iletişime geçin.");
                    return;
                }
                else
                {
                    ModulNo = dt.Rows[0]["UrunID"].ToString();
                    UrunAdi = dt.Rows[0]["UrunAdi"].ToString();
                    cn.Clear();
                    cn.AddParams("@BilgisayarBilgisi", ComputerInfo);
                    cn.AddParams("@LisansNo", txtLisansNo.Text);
                    cn.AddParams("@UrunID", ModulNo);
                    cn.ExcuteQuery("update dbo.Lisanslar set BilgisayarBilgisi=@BilgisayarBilgisi where LisansNo=@LisansNo and UrunID=@UrunID");

                    FileStream fs = new FileStream(AppPath + "temp.ab", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(ComputerInfo);
                    sw.WriteLine(txtLisansNo.Text);
                    sw.WriteLine(Convert.ToDateTime(dt.Rows[0]["BaslangicTarihi"].ToString()).ToShortDateString());
                    sw.WriteLine(Convert.ToDateTime(dt.Rows[0]["BitisTarihi"].ToString()).ToShortDateString());
                    sw.WriteLine(ModulNo);
                    sw.WriteLine(dt.Rows[0]["UrunAdi"].ToString());
                    sw.WriteLine(Versiyon);
                    sw.WriteLine(Surum);
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();

                    cn.Clear();
                    cn.AddParams("@LisansNo", txtLisansNo.Text);
                    cn.AddParams("@BaslamaSaati", DateTime.Now);
                    cn.ExcuteQuery("insert into dbo.GuncellemeGecmisi (Tarih, LisansNo, BaslamaSaati, IslemSonucu, IslemTipi) values (getdate(), @LisansNo, @BaslamaSaati, '', 'Kurulum')");
                }
            }
            else
            {
                if (File.Exists(AppPath + "\\LicencingFile.lic"))
                {
                    try
                    {
                        FileStream fs2 = new FileStream(AppPath + "\\LicencingFile.lic", FileMode.Open);
                        StreamReader sr = new StreamReader(fs2);

                        FileStream fs = new FileStream(AppPath + "temp.ab", FileMode.Create);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(ComputerInfo);
                        sr.ReadLine();
                        sw.WriteLine(sr.ReadLine());
                        sw.WriteLine(Convert.ToDateTime(sr.ReadLine()).ToShortDateString());
                        sw.WriteLine(Convert.ToDateTime(sr.ReadLine()).ToShortDateString());
                        sw.WriteLine(sr.ReadLine());
                        sw.WriteLine(sr.ReadLine());
                        sw.WriteLine(sr.ReadLine());
                        sw.WriteLine(sr.ReadLine());
                        sw.Close();
                        sw.Dispose();
                        fs.Close();
                        fs.Dispose();

                        sr.Close();
                        sr.Dispose();
                        fs2.Close();
                        fs2.Dispose();

                        File.Delete(AppPath + "\\LicencingFile.lic");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lisans dosyası hatalı...");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Lisans dosyası seçmediniz...");
                    return;
                }
            }

            checkedListBox1.SetItemChecked(1, true);
            tabControl1.TabPages[1].Enabled = false;
            tabControl1.TabPages[2].Enabled = true;
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        private void btnDevamServerCli_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages[0].Enabled = false;
            tabControl1.TabPages[1].Enabled = true;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void btnDevamVeritabani_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSirketAdi.Text))
            {
                MessageBox.Show("Şirket adı girmediniz...");
                return;
            }

            ABSqlConnection cn = new ABSqlConnection();
            cn.CnString = string.Format("data source={0};uid={1};pwd={2};", txtServerName.Text, txtUserName.Text, txtPassword.Text);

            if (cmbAuthentication.SelectedIndex == 1)
                cn.CnString = string.Format("data source={0};database={3};uid={1};pwd={2};", txtServerName.Text, txtUserName.Text, txtPassword.Text, (radioButton1.Checked ? "master" : txtDataBase.Text));
            else
                cn.CnString = string.Format("data source={0};database={1};trusted_connection=true;", txtServerName.Text, (radioButton1.Checked ? "master" : txtDataBase.Text));

            cnn = cn.CnString;
            cnnn = cnn.Replace("database=master", "database=" + txtDataBase.Text);
            if (cn.Test())
            {
                if (checkBox1.Checked)
                {
                    try
                    {
                        FileStream fs = new FileStream(AppPath + "temp.ab", FileMode.Append);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(txtDataBase.Text);
                        sw.WriteLine(txtServerName.Text);
                        sw.WriteLine(txtUserName.Text);
                        sw.WriteLine(txtPassword.Text);
                        sw.WriteLine(txtSirketAdi.Text);
                        sw.WriteLine(radioButton1.Checked ? "Server" : "Client");
                        sw.WriteLine("Yeni Kurulum");
                        sw.Close();
                        sw.Dispose();
                        fs.Close();
                        fs.Dispose();

                        if (radioButton1.Checked)
                        {
                            lblIslem.Text = "Veritabanı oluşturulurken lütfen bekleyin...";
                            checkedListBox1.SetItemChecked(2, true);

                            try
                            {
                                cn.ExcuteQuery("create database " + txtDataBase.Text);
                            }
                            catch { ;}
                        }
                        else
                        {
                            backgroundWorker1.CancelAsync();
                            Bitti();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Veritabanı oluşturulamadı.\nLütfen bilgilerinizi kontrol edin.");
                        return;
                    }
                }
                else
                {
                    FileStream fs = new FileStream(AppPath + "temp.ab", FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(txtDataBase.Text);
                    sw.WriteLine(txtServerName.Text);
                    sw.WriteLine(txtUserName.Text);
                    sw.WriteLine(txtPassword.Text);
                    sw.WriteLine(txtSirketAdi.Text);
                    sw.WriteLine(radioButton1.Checked ? "Server" : "Client");
                    sw.WriteLine("Eski Kurulum");
                    sw.Close();
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();

                    backgroundWorker1.CancelAsync();
                    Bitti();
                    DevamMi = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Veritabanı bağlantısı kurulamadı.\nLütfen bilgilerinizi kontrol edin.");
                return;
            }

            pnlDurum.Visible = true;
            pnlVeritabaniBilg.Enabled = false;
            btnDevamVeritabani.Enabled = false;
            btnAtlaVeritabani.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnIptalLisans_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kurulumu iptal etmek istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                GecmisiGuncelle(IslemTipi.IptalEdildi);
                DevamMi = false;
                this.Close();
                return;
            }
        }

        private void btnIptalServerCli_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kurulumu iptal etmek istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                GecmisiGuncelle(IslemTipi.IptalEdildi);
                DevamMi = false;
                this.Close();
                return;
            }
        }

        private void btnIptalVeritabani_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kurulumu iptal etmek istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                GecmisiGuncelle(IslemTipi.IptalEdildi);
                DevamMi = false;
                this.Close();
                return;
            }
        }

        private void btnSon_Click(object sender, EventArgs e)
        {
            DevamMi = true;
            this.Close();
        }

        private void btnSQLDevam_Click(object sender, EventArgs e)
        {
            string[] yuklusqller = (string[])Registry.LocalMachine.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Microsoft SQL Server").GetValue("InstalledInstances");

            //Eğer kullanıcının bilgisayarında SQLExpress yüklü değilse
            var yukluozellikler = "";
            try
            {
                yukluozellikler = (from s in yuklusqller
                                   where s.Contains("SQLEXPRESS")
                                   select s).FirstOrDefault();
            }
            catch { ;}

            if (string.IsNullOrEmpty(yukluozellikler))
            {
                MessageBox.Show("SQL Server Express Edition Kurulumunu Yapmadan Devam Edemezsiniz...");
                return;
            }

            checkedListBox1.SetItemChecked(1, true);
            tabControl1.TabPages[1].Enabled = false;
            tabControl1.TabPages[2].Enabled = true;
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        private void cmbAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = false;
            txtUserName.Enabled = false;

            if (cmbAuthentication.SelectedIndex == 1)
            {
                txtPassword.Enabled = true;
                txtUserName.Enabled = true;
            }
        }

        //string CnString = "data source=192.9.0.19;database=AVPYONETIM;uid=sa;pwd=PASSWRD1;";
        private void Form1_Load(object sender, EventArgs e)
        {
            AppPath = formContext.Parameters["KurulumYolu"].ToString();
            //AppPath = Application.StartupPath + "\\";

            DevamMi = false;

            if (Is64Bit())
                DirectoryCopy(AppPath + @"\SistemTuru\64Bit", AppPath, true);
            else
                DirectoryCopy(AppPath + @"\SistemTuru\32Bit", AppPath, true);

            cmbAuthentication.SelectedIndex = 0;
            checkedListBox1.SetItemChecked(0, true);

            tabControl1.TabPages[1].Enabled = false;
            tabControl1.TabPages[2].Enabled = false;
            tabControl1.TabPages[3].Enabled = false;

            if (File.Exists(Application.StartupPath + "\\temp.ab"))
                File.Delete(Application.StartupPath + "\\temp.ab");

            try
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "ServerSideServices.exe", AppPath + "\\ServerSideServices.exe", Microsoft.Win32.RegistryValueKind.String);
            }
            catch { ;}

            try
            {
                Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run", "Asistan.exe", AppPath + "\\Asistan.exe", Microsoft.Win32.RegistryValueKind.String);
            }
            catch { ;}
        }

        private void GecmisiGuncelle(IslemTipi islemTipi)
        {
            if (rbtnOnlineKurulum.Checked)
            {
                string sonuc = "";
                if (islemTipi == IslemTipi.Başarılı)
                    sonuc = "Kurulum Başarılı";
                else if (islemTipi == IslemTipi.HataOlustu)
                    sonuc = "Kurulum Sırasında Hata Oluştu";
                else if (islemTipi == IslemTipi.IptalEdildi)
                    sonuc = "Kurulum İşlemi İptal Edildi";

                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = CnString;
                cn.AddParams("@LisansNo", txtLisansNo.Text);
                cn.AddParams("@BitisSaati", DateTime.Now);
                cn.AddParams("@IslemSonucu", sonuc);
                cn.ExcuteQuery("update dbo.GuncellemeGecmisi set BitisSaati=@BitisSaati,IslemSonucu=@IslemSonucu where LisansNo=@LisansNo and IslemTipi='Kurulum'");
            }
        }

        private bool Is32BitProcessOn64BitProcessor()
        {
            bool retVal;

            IsWow64Process(

            Process.GetCurrentProcess().Handle, out retVal);

            return retVal;
        }

        private bool Is64Bit()
        {
            if (IntPtr.Size == 8 || (IntPtr.Size == 4 && Is32BitProcessOn64BitProcessor()))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (Is64Bit())
            //    System.Diagnostics.Process.Start("http://www.microsoft.com/sqlserver/en/us/editions/2012-editions/express.aspx");
            //else
            //System.Diagnostics.Process.Start("http://www.microsoft.com/sqlserver/en/us/editions/2012-editions/express.aspx");

            SaveFileDialog sd = new SaveFileDialog();

            if (sd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            try
            {
                string uri = "";

                if (Is64Bit())
                    uri = "ftp://94.138.206.50/Download/SQL08_64Bit.exe";
                else
                    uri = "ftp://94.138.206.50/Download/SQL08_32Bit.exe";
                Uri serverUri = new Uri(uri);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return;
                }
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverUri);
                reqFTP.Credentials = new NetworkCredential("aykutbastug", "PASSWRD1");
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream writeStream = new FileStream(sd.FileName, FileMode.Create);
                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                writeStream.Close();
                response.Close();
            }
            catch 
            {
                //MessageBox.Show(wEx.Message, "Download Error");
                
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                lblBilgi.Text = "Server Kurulumu\n\nVeritabanı kurulumu yapılacaktır.";
                tabControl1.TabPages[2].Text = "Veritabanı Kurulumu";
            }
            else
            {
                lblBilgi.Text = "Client Kurulumu\n\nVeritabanı kurulumu yapılmayacaktır.";
                tabControl1.TabPages[2].Text = "Veritabanı Bağlantı Bilgileri";
            }
        }

        private void rbtnOnlineKurulum_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = rbtnOnlineKurulum.Checked;
            txtLisansNo.Enabled = rbtnOnlineKurulum.Checked;
            label7.Enabled = rbtnOnlineKurulum.Checked;
            txtEmail.Enabled = rbtnOnlineKurulum.Checked;
        }

        private void txtDataBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'Ğ' || e.KeyChar == 'Ü' || e.KeyChar == 'Ş' || e.KeyChar == 'İ' || e.KeyChar == 'Ö' || e.KeyChar == 'Ç' || e.KeyChar == 'ğ' || e.KeyChar == 'ü' || e.KeyChar == 'ş' || e.KeyChar == 'ö' || e.KeyChar == 'ç')
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtLisansNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}