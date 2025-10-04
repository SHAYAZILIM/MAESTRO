using AvukatProLib.DbUpdate;
using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AvukatProLib
{
    [RunInstaller(true)]
    public partial class instYeniNesil : Installer
    {
        public instYeniNesil()
        {
            InitializeComponent();
        }

        private DbVersion _CurrentExesDbVersion = new DbVersion(40, 0, 0);

        public override void Commit(System.Collections.IDictionary savedState)
        {
            MessageBox.Show("Committing...");
            Debugger.Break();

            base.Commit(savedState);
            ProcessStartInfo psi = new ProcessStartInfo();
            string StartupPath = Path.GetDirectoryName(Context.Parameters["DP_TargetDir"]);
            psi.FileName = Path.Combine(StartupPath, "SQlServerAndParametersInstaller.exe");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.Arguments = String.Format("\"{0}\" {1}", StartupPath, Context.Parameters["KurulumTipi"]);
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }

        //public override void Install(System.Collections.IDictionary stateSaver)
        //{
        //    MessageBox.Show("Installing...");
        //    System.Diagnostics.Debugger.Break();
        //    base.Install(stateSaver);

        //    string StartupPath = Context.Parameters["DP_TargetDir"].ToString();

        //    List<CompInfo> cmps = new List<CompInfo>(); //CompInfo.CompInfoListGetir(StartupPath);
        //    if (!File.Exists(StartupPath + "//cmpnfo3.gio"))
        //    {
        //        Lisans.frmLisansAktiveEtme frm = new AvukatProLib.Lisans.frmLisansAktiveEtme(StartupPath);
        //        DialogResult dr = frm.ShowDialog();
        //        if (dr == DialogResult.OK)
        //        {
        //            MessageBox.Show("Lisans baþarýlý bir þekilde aktive edildi");
        //        }
        //        else
        //        {
        //            throw new InstallException("Lisans bilgileriniz aktive edilemediðinden kurulum tamamlanamadý");
        //        }
        //    }

        //    if (Context.Parameters["KurulumTipi"].ToString() == "SunucuKurulumu")
        //    {
        //        //System.Diagnostics.Process pro = System.Diagnostics.Process.Start(StartupPath + "\\AvukatProLib.Bakim.exe", "-DbRestore");
        //        //pro.WaitForExit();
        //        AvukatProLib.DbBackup.frmRestore frmRest = new AvukatProLib.DbBackup.frmRestore(StartupPath);
        //        if(frmRest.ShowDialog() != DialogResult.OK)
        //            throw new InstallException("Veritabaný yükseltilemedi.");
        //    }

        //    //else
        //    //{
        //    //    MessageBox.Show("istemci kurulmunu seçtin");
        //    //}

        //    System.Diagnostics.Process prco = System.Diagnostics.Process.Start(StartupPath + "\\AvukatProLib.Bakim.exe", "-DbUpdate");
        //    prco.WaitForExit();

        //    StreamReader rdr = new StreamReader(StartupPath + "\\AvukatproLib.Bakim2.dll");

        //    if (rdr.ReadLine() == "1")
        //    {
        //        MessageBox.Show("Veritabaný yükseltmesi baþarýyla tamamlandý.", "Veritabaný Yükseltmesi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    //else if (sonuc=="2")
        //    //{
        //    //}
        //    //else
        //    //{
        //    //    throw new InstallException("Veritabaný yükseltilemedi.");
        //    //}

        //}
    }
}