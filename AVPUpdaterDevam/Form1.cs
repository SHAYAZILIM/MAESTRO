using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AVPUpdaterDevam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            while (Process.GetProcesses().Any(pr => pr.ProcessName == "avpng" || pr.ProcessName == "AVPUpdater" || pr.ProcessName.Contains("Avukatpro") || pr.ProcessName == "Asistan" || pr.ProcessName == "ServerSideServices"))
            {
                foreach (var item in Process.GetProcesses().Where(pr => pr.ProcessName == "avpng" || pr.ProcessName == "AVPUpdater" || pr.ProcessName.Contains("Avukatpro") || pr.ProcessName == "Asistan" || pr.ProcessName == "ServerSideServices"))
                {
                    try
                    {
                        item.Kill();
                    }
                    catch { }
                }
            }
            //Thread.Sleep(10000);
            try
            {
                File.Copy(Application.StartupPath + "\\Download\\AvukatProLib.dll", Application.StartupPath + "\\AvukatProLib.dll", true);
            }
            catch { ;}

            try
            {
                File.Copy(Application.StartupPath + "\\Download\\AVPUpdater.exe", Application.StartupPath + "\\AVPUpdater.exe", true);
            }
            catch { ;}
        }
    }
}