using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace AvukatproUpdater.Common.Parameters
{
    public partial class frmParam : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        public Param Prm = new Param();

        private string ParamFile = "UpdaterParam.xml";

        #endregion Fields

        #region Constructors

        public frmParam(bool loadParam)
        {
            InitializeComponent();
            if (loadParam) LoadParam(ref Prm, ParamFile, false);
            FileToForm();
        }

        public frmParam(bool loadParam, string paramFile)
        {
            InitializeComponent();
            ParamFile = paramFile;
            if (loadParam) LoadParam(ref Prm, ParamFile, false);
            FileToForm();
        }

        #endregion Constructors

        #region Methods

        public static bool LoadParam(ref Param Prm, string ParamFile, bool isServer)
        {
            if (File.Exists(ParamFile))
            {
                Prm.AppBackupFolder = String.Empty;
                Prm.DownloadsFolder = String.Empty;
                Prm.AppFolder = String.Empty;
                Prm.DbBackupFolder = String.Empty;
                Prm.LogsFolder = String.Empty;
                Prm.UpdateServerUri = String.Empty;

                using (XmlTextReader xmlRdr = new XmlTextReader(ParamFile))
                {
                    while (xmlRdr.Read())
                    {
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "AppBackupFolder")
                            Prm.AppBackupFolder = xmlRdr.ReadString();
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "DbBackupFolder")
                            Prm.DbBackupFolder = xmlRdr.ReadString();
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "DownloadsFolder")
                            Prm.DownloadsFolder = xmlRdr.ReadString();
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "AppFolder")
                            Prm.AppFolder = xmlRdr.ReadString();
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "LogsFolder")
                            Prm.LogsFolder = xmlRdr.ReadString();
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "TimeSchedule")
                        {
                            string[] time = xmlRdr.ReadString().Split(':');
                            Prm.TimeSchedule = new DateTime(1, 1, 1, Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 0);
                        }
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "IsBothClientAndServer")
                            Prm.IsBothClientAndServer = xmlRdr.ReadString().ToUpper() == "TRUE" ? true : false;
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "UpdateServerUri")
                            Prm.UpdateServerUri = xmlRdr.ReadString();
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "WorkOnline")
                            Prm.WorkOnline = xmlRdr.ReadString().ToUpper() == "TRUE" ? true : false;
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "ServerExeVersion")
                            Prm.ServerExeVersion = xmlRdr.ReadString();
                        if (xmlRdr.NodeType == XmlNodeType.Element && xmlRdr.Name == "ServerDbVersion")
                            Prm.ServerDbVersion = xmlRdr.ReadString();
                    }
                }
                return true;
            }
            else
            {
                if (!isServer)
                {
                    if (MessageBox.Show("Parametre dosyası bulunamadı. Oluşturulsun mu?", "Parametreler", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        using (frmParam formParam = new frmParam(false))
                        {
                            if (formParam.ShowDialog() == DialogResult.OK)
                            {
                                LoadParam(ref Prm, ParamFile, isServer);
                                return true;
                            }
                        }
                        return false;
                    }
                }
                return false;
            }
        }

        public static bool LoadParameters(ref Param Prm, List<AvukatProLib.CompInfo> infolar)
        {
            #region Updater Parametreleri

            Prm.AppBackupFolder = infolar[0].UpdaterBackupFolder + "\\App";
            Prm.DbBackupFolder = infolar[0].UpdaterBackupFolder + "\\Db";
            Prm.DownloadsFolder = infolar[0].DownloadsFolder;
            Prm.IsBothClientAndServer = (infolar[0].UygulamaTipi == 0);
            Prm.LogsFolder = infolar[0].LogsFolder;
            Prm.TimeSchedule = infolar[0].TimeSchedule;
            Prm.UpdateServerUri = infolar[0].GuncelSunucuAdresi + "/LicenceControl.asmx";

            #endregion Updater Parametreleri

            return !String.IsNullOrEmpty(Prm.AppBackupFolder) && !String.IsNullOrEmpty(Prm.DbBackupFolder) && !String.IsNullOrEmpty(Prm.DownloadsFolder)
                && !String.IsNullOrEmpty(Prm.LogsFolder);
        }

        public static void SaveParam(ref Param Prm, string ParamFile)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(ParamFile))) Directory.CreateDirectory(Path.GetDirectoryName(ParamFile));
                if (File.Exists(ParamFile))
                {
                    File.Delete(ParamFile);
                }
                using (XmlTextWriter xmlWrt = new XmlTextWriter(ParamFile, Encoding.UTF8) { Formatting = Formatting.Indented })
                {
                    xmlWrt.WriteStartDocument();
                    xmlWrt.WriteStartElement("Parameters");
                    xmlWrt.WriteElementString("AppFolder", Prm.AppFolder);
                    xmlWrt.WriteElementString("AppBackupFolder", Prm.AppBackupFolder);
                    xmlWrt.WriteElementString("DbBackupFolder", Prm.DbBackupFolder);
                    xmlWrt.WriteElementString("DownloadsFolder", Prm.DownloadsFolder);
                    xmlWrt.WriteElementString("LogsFolder", Prm.LogsFolder);
                    xmlWrt.WriteElementString("TimeSchedule", String.Format("{0}:{1}", Prm.TimeSchedule.Hour, Prm.TimeSchedule.Minute));
                    xmlWrt.WriteElementString("IsBothClientAndServer", Prm.IsBothClientAndServer.ToString());
                    xmlWrt.WriteElementString("UpdateServerUri", Prm.UpdateServerUri);
                    xmlWrt.WriteElementString("WorkOnline", Prm.WorkOnline.ToString());
                    xmlWrt.WriteElementString("ServerExeVersion", Prm.ServerExeVersion ?? string.Empty);
                    xmlWrt.WriteElementString("ServerDbVersion", Prm.ServerDbVersion ?? string.Empty);
                    xmlWrt.WriteEndElement();
                    xmlWrt.WriteEndDocument();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Parametreler kaydedilemedi.\n{0}", ex.Message));
            }
        }

        private void cbxIsClient_CheckedChanged(object sender, EventArgs e)
        {
            CheckClientServer();
        }

        private void CheckClientServer()
        {
            if (cbxIsClient.Checked)
            {
                groupBoxUpdateTime.Enabled = false;
                groupBoxUpdateTime.Enabled = true;
                groupBoxUpdateType.Enabled = false;
            }
            else
            {
                groupBoxUpdateTime.Enabled = true;
                groupBoxUpdateTime.Enabled = false;
                groupBoxUpdateType.Enabled = true;
            }
        }

        private void farklıKaydetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog { ShowNewFolderButton = true })
            {
                FormToFile();
                SaveParam(ref Prm, Path.Combine(dialog.SelectedPath, "UpdaterParam.xml"));
                DialogResult = DialogResult.OK;
            }
        }

        private void FileToForm()
        {
            txtAppFolder.Text = Prm.AppFolder.Trim();
            txtAppBackupFolder.Text = Prm.AppBackupFolder.Trim();
            txtDbBackupFolder.Text = Prm.DbBackupFolder.Trim();
            txtDownloadFolder.Text = Prm.DownloadsFolder.Trim();
            txtLogFolder.Text = Prm.LogsFolder.Trim();
            cbxIsClient.Checked = Prm.IsBothClientAndServer;
            txtTimeSchedule.Text = String.Format("{0}:{1}", Prm.TimeSchedule.Hour, Prm.TimeSchedule.Minute);
            txtUpdateServerUri.Text = Prm.UpdateServerUri;
            rbUpdateOnline.Checked = Prm.WorkOnline;
        }

        private void FormToFile()
        {
            string[] time = txtTimeSchedule.Text.Split(':');
            Prm.AppFolder = txtAppFolder.Text.Trim();
            Prm.AppBackupFolder = txtAppBackupFolder.Text.Trim();
            Prm.DbBackupFolder = txtDbBackupFolder.Text.Trim();
            Prm.DownloadsFolder = txtDownloadFolder.Text.Trim();
            Prm.LogsFolder = txtLogFolder.Text.Trim();
            Prm.IsBothClientAndServer = cbxIsClient.Checked;
            Prm.TimeSchedule = new DateTime(1, 1, 1, Convert.ToInt32(time[0]), Convert.ToInt32(time[1]), 0);
            Prm.UpdateServerUri = txtUpdateServerUri.Text;
            Prm.WorkOnline = rbUpdateOnline.Checked;
        }

        private void frmParam_Load(object sender, EventArgs e)
        {
            CheckClientServer();
        }

        private void kaydetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormToFile();
            SaveParam(ref Prm, ParamFile);
            DialogResult = DialogResult.OK;
        }

        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (LoadParam(ref Prm, dialog.FileName, false))
                        FileToForm();
                }
            }
        }

        private void SelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog { ShowNewFolderButton = true })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    switch (Int16.Parse((sender as Button).Tag.ToString()))
                    {
                        case 1: txtAppFolder.Text = dialog.SelectedPath; break;
                        case 2: txtAppBackupFolder.Text = dialog.SelectedPath; break;
                        case 3: txtDbBackupFolder.Text = dialog.SelectedPath; break;
                        case 4: txtDownloadFolder.Text = dialog.SelectedPath; break;
                        case 5: txtLogFolder.Text = dialog.SelectedPath; break;
                    }
                }
            }
        }

        #endregion Methods
    }
}