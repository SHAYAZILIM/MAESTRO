using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmYedek : DevExpress.XtraEditors.XtraForm
    {
        public frmYedek()
        {
            InitializeComponent();
        }

        private bool IsServer = false;
        private List<AvukatProLib.CompInfo> list = new List<AvukatProLib.CompInfo>();

        private static void Backup_Completed(object sender, ServerMessageEventArgs args)
        {
            Console.WriteLine("Backup işlemi tamamlandı.");
            Console.WriteLine(args.Error.Message);
        }

        private static void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
        {
            Console.Clear();
            Console.WriteLine("Tamamlanan: {0}%.", args.Percent);
        }

        private static void Restore_Completed(object sender, ServerMessageEventArgs args)
        {
            Console.WriteLine("Restore işlemi tamamlandı.");
            Console.WriteLine(args.Error.Message);
        }

        private bool BackUp(string path, string fileName)
        {
            if (list == null || list.Count < 1)
                return false;
            try
            {
                Backup bkpDBFull = new Backup();

                bkpDBFull.Action = BackupActionType.Database;
                bkpDBFull.Database = list[0].HAVeriTabani;

                bkpDBFull.Devices.AddDevice(path + fileName, DeviceType.File);
                bkpDBFull.BackupSetName = list[0].HAVeriTabani + " database Backup";
                bkpDBFull.BackupSetDescription = list[0].HAVeriTabani + " database - Full Backup";
                /* You can specify the expiration date for your backup data
                 * after that date backup data would not be relevant */
                bkpDBFull.ExpirationDate = DateTime.Today.AddMonths(10);

                /* You can specify Initialize = false (default) to create a new
                 * backup set which will be appended as last backup set on the media. You
                 * can specify Initialize = true to make the backup as first set on the
                 * medium and to overwrite any other existing backup sets if the all the
                 * backup sets have expired and specified backup set name matches with
                 * the name on the medium */
                bkpDBFull.Initialize = false;

                /* Wiring up events for progress monitoring */
                bkpDBFull.PercentComplete += CompletionStatusInPercent;
                bkpDBFull.Complete += Backup_Completed;

                ServerConnection cnn = new ServerConnection(new SqlConnection() { ConnectionString = list[0].ConStr });
                Server myServer = new Server(cnn);
                /* SqlBackup method starts to take back up
                 * You can also use SqlBackupAsync method to perform the backup
                 * operation asynchronously */
                bkpDBFull.SqlBackup(myServer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void beDosya_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            openFileDialog1.ShowDialog();
            beDosya.EditValue = openFileDialog1.FileName;
        }

        private void beDosyaYolu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            beDosyaYolu.EditValue = folderBrowserDialog1.SelectedPath;
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if (!IsServer)
            {
                XtraMessageBox.Show("BackUp işlemi sadece server üzerinden yapılabilmektedir!", "AVP BackUp");
                return;
            }
            if (!string.IsNullOrEmpty(beDosyaYolu.EditValue.ToString()) && !string.IsNullOrEmpty(txtDosyaAdı.Text))
            {
                btnBackUp.Enabled = false;
                BackUp(beDosyaYolu.EditValue.ToString(), txtDosyaAdı.Text);
                btnBackUp.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (!IsServer)
            {
                XtraMessageBox.Show("Restore işlemi sadece server üzerinden yapılabilmektedir!", "AVP BackUp");
                return;
            }
            if (!string.IsNullOrEmpty(beDosya.EditValue.ToString()))
            {
                btnRestore.Enabled = false;
                Restore(beDosya.EditValue.ToString());
                btnRestore.Enabled = true;
            }
        }

        private void frmYedek_Load(object sender, EventArgs e)
        {
            list = AvukatProLib.CompInfo.CompInfoListGetir();
            string myHost = System.Net.Dns.GetHostName();
            System.Net.IPHostEntry myIPs = System.Net.Dns.GetHostEntry(myHost);
            foreach (System.Net.IPAddress myIP in myIPs.AddressList)
            {
                if (myIP.ToString() == list[0].VeriTabaniSunucu)
                    IsServer = true;
            }
            folderBrowserDialog1.SelectedPath = Application.StartupPath + "\\BackUp";
            beDosyaYolu.EditValue = folderBrowserDialog1.SelectedPath;
            list = AvukatProLib.CompInfo.CompInfoListGetir();
            if (!IsServer)
            {
                DialogResult dr = XtraMessageBox.Show("Yedek işlemi sadece server üzerinden yapılabilmektedir!", "AVP BackUp", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void Restore(string dosya)
        {
            if (list == null || list.Count < 1)
                return;
            try
            {
                Restore restore = new Restore();
                restore.Complete += Restore_Completed;
                restore.PercentComplete += CompletionStatusInPercent;
                //Set type of backup to be performed to database
                restore.Database = list[0].HAVeriTabani;
                restore.Action = RestoreActionType.Database;
                //Set up the backup device to use filesystem.
                restore.Devices.AddDevice(dosya, DeviceType.File);
                //set ReplaceDatabase = true to create new database
                //regardless of the existence of specified database
                restore.ReplaceDatabase = true;
                //If you have a differential or log restore to be followed,
                //you would specify NoRecovery = true
                restore.NoRecovery = false;
                //if you want to restore to a different location, specify
                //the logical and physical file names
                //            restore.RelocateFiles.Add(new RelocateFile("Test",
                //@"C:\Temp\Test.mdf"));
                //            restore.RelocateFiles.Add(new RelocateFile("Test_Log",
                //@"C:\Temp\Test_Log.ldf"));
                ServerConnection cnn = new ServerConnection(new SqlConnection() { ConnectionString = list[0].ConStr });
                Server myServer = new Server(cnn);

                //SqlRestore method starts to restore database
                restore.SqlRestore(myServer);
                XtraMessageBox.Show("Restore işlemi tamanlandı!", "AVP BackUp");
            }
            catch 
            {
                XtraMessageBox.Show("Restore işlemi tamanlanamadı!", "AVP BackUp");
            }
        }

        //private bool GetFileFromSqlServer()
        //{
        //    AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
        //    WindowsIdentity identity = new WindowsIdentity("administrator", "P@ssw0rd");
        //    WindowsImpersonationContext context = identity.Impersonate();

        //    try
        //    {
        //        File.Copy(@"\\192.9.0.200\folder\" + txtDosyaAdı.Text, beDosyaYolu.EditValue.ToString(), true);
        //        File.Delete(@"\\192.9.0.200\folder\" + txtDosyaAdı.Text);
        //        return true;
        //    }
        //    catch
        //    {
        //        context.Undo();
        //        return false;
        //    }
        //}

        //private bool CreateGZipFromFile(string path)
        //{
        //    string file = path + txtDosyaAdı.EditValue.ToString();
        //    FileStream sourceFile = File.OpenRead(file);
        //    FileStream destFile = File.Create(beDosyaYolu + @"\" + txtDosyaAdı.EditValue.ToString().Split('.')[0] + ".zip");

        //    GZipStream compStream = new GZipStream(destFile, CompressionMode.Compress);

        //    try
        //    {
        //        int theByte = sourceFile.ReadByte();
        //        while (theByte != -1)
        //        {
        //            compStream.WriteByte((byte)theByte);
        //            theByte = sourceFile.ReadByte();
        //        }
        //        File.Delete(file);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        compStream.Dispose();
        //    }
        //}
    }
}