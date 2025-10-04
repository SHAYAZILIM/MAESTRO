using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace AvukatProLib.Bakim
{
    public partial class frmSurumGuncelleme : Form
    {
        public frmSurumGuncelleme()
        {
            InitializeComponent();
        }

        private CompInfo cmpNfo = new CompInfo();
        private List<CompInfo> cmpNfoList;

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Avukatpro'ya bağlı bütün açık programlar kapatılacak.\nDevam etmek istiyor musunuz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;

            cmpNfo.Surum = comboBox1.Text;
            CompInfo.Kaydet(cmpNfoList, Application.StartupPath);

            foreach (Process pr in Process.GetProcesses())
            {
                if (pr.ProcessName == "avpng" || pr.ProcessName.Contains("Avukatpro") || pr.ProcessName == "Asistan" || pr.ProcessName == "AVPUpdater" || pr.ProcessName == "ServerSideServices")
                {
                    if (!pr.ProcessName.Contains("Bakim"))
                        pr.Kill();
                }
            }

            Process.Start(Application.StartupPath + "\\AVPUpdater.exe");
            Application.Exit();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSurumGuncelleme_Load(object sender, EventArgs e)
        {
            cmpNfoList = CompInfo.CmpNfoList;
            cmpNfo = cmpNfoList[0];
            lblYukluSurum.Text = cmpNfo.Surum;

            try
            {
                ABSqlConnection cn = new ABSqlConnection();
                cn.CnString = AVPLicenceControl.cn();
                comboBox1.DataSource = cn.GetDataTable("select Surum from dbo.Versiyon(nolock) order by RowID desc");
                comboBox1.ValueMember = "Surum";
                comboBox1.DisplayMember = "Surum";
            }
            catch { ;}
        }
    }
}