using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using aOffice = Microsoft.Office.Core;
using aOutlook = Microsoft.Office.Interop.Outlook;

namespace AvukatPro.Outlook
{
    sealed public class ConvertImage : System.Windows.Forms.AxHost
    {
        private ConvertImage()
            : base(null)
        {
        }

        public static stdole.IPictureDisp Convert
            (System.Drawing.Image image)
        {
            return (stdole.IPictureDisp)System.
                Windows.Forms.AxHost
                .GetIPictureDispFromPicture(image);
        }
    }

    public class Settings
    {
        public string ProgramPath { get; set; }

        public static Settings GetXml()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                TextReader reader = new StreamReader("AvukatPro.Outlook.xml");
                var c = (Settings)serializer.Deserialize(reader);
                reader.Close();
                return c;
            }
            catch
            {
                return new Settings();
            }
        }

        public static void SaveXml(Settings item)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                TextWriter writer = new StreamWriter("AvukatPro.Outlook.xml");
                serializer.Serialize(writer, item);
                writer.Close();
            }
            catch { }
        }
    }

    public partial class ThisAddIn
    {
        public static Microsoft.Office.Interop.Outlook.Inspector InsMail;
        private const int SW_RESTORE = 9;
        private aOutlook.Application aApp;
        private aOffice.CommandBarButton buttonOne;
        private aOffice.CommandBarButton buttonTwo;
        private aOffice.CommandBarButton firstButton;
        private aOutlook.Inspectors Inspectors;
        private aOutlook.Inspectors inspectors;
        private aOffice.CommandBar newToolBar;
        private aOffice.CommandBarButton secondButton;
        private aOutlook.Explorers selectExplorers;
        private Settings settings;
        private aOutlook.MailItem tmpMailItem2;

        public static void bringToFront(Process proc)
        {
            IntPtr handle = proc.MainWindowHandle;
            if (IsIconic(handle))
            {
                ShowWindow(handle, SW_RESTORE);
            }

            SetForegroundWindow(handle);
        }

        public void AvpOpen(List<string> filename)
        {
            if (filename.Count > 0)
            {
                string programPath = settings.ProgramPath;
                Process[] prs = Process.GetProcesses();
                bool varmi = false;
                foreach (Process pr in prs)
                {
                    if (pr.ProcessName.Contains("avpng"))
                    {
                        varmi = true;
                        bringToFront(pr);
                        break;
                    }
                }
                var file = System.IO.File.CreateText(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(programPath), "belgekayit.avpis"));
                foreach (var item in filename)
                {
                    if (!string.IsNullOrEmpty(item))
                        file.WriteLine(item);
                }
                file.Close();
                if (!varmi)
                {
                    System.Diagnostics.Process.Start(programPath);
                }
                MessageBox.Show("Mesaj Uygulama ekranına gönderilmiştir.");
            }
            else
            {
                MessageBox.Show("Lütfen bir mail seçiniz.");
            }
        }

        public void selectFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "avpng.exe | avpng.exe";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                settings.ProgramPath = dialog.FileName;
                Settings.SaveXml(settings);
            }
        }

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        private void AddToolbar()
        {
            if (newToolBar == null)
            {
                aOffice.CommandBars cmdBars =
                    this.Application.ActiveExplorer().CommandBars;
                newToolBar = cmdBars.Add("Maestro",
                    aOffice.MsoBarPosition.msoBarTop, false, true);
            }
            try
            {
                aOffice.CommandBarButton button_1 =
                    (aOffice.CommandBarButton)newToolBar.Controls
                    .Add(1, missing, missing, missing, true);
                button_1.Style = aOffice
                    .MsoButtonStyle.msoButtonCaption;
                button_1.Caption = "Maestro Belge olarak Kaydet";
                button_1.Style = aOffice.MsoButtonStyle.msoButtonIconAndCaption;
                button_1.FaceId = 65;
                button_1.Picture = getImage();

                if (this.firstButton == null)
                {
                    this.firstButton = button_1;
                    firstButton.Click += new aOffice.
                        _CommandBarButtonEvents_ClickEventHandler
                        (buttonOne_Click);
                }
                aOffice.CommandBarButton button_2 =
                    (aOffice.CommandBarButton)newToolBar.Controls
                    .Add(1, missing, missing, missing, true);
                button_2.Style = aOffice
                    .MsoButtonStyle.msoButtonCaption;
                button_2.Caption = "Program Klasörü Seç";
                button_2.Style = aOffice.MsoButtonStyle.msoButtonIconAndCaption;
                button_2.FaceId = 65;
                button_2.Picture = getImage();

                if (this.secondButton == null)
                {
                    this.secondButton = button_2;
                    secondButton.Click += new aOffice.
                        _CommandBarButtonEvents_ClickEventHandler
                        (secondButton_Click);
                }
                newToolBar.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOne_Click(aOffice.CommandBarButton ctrl, ref bool cancel)
        {
            string filename = "";
            aOutlook._Application oApp = new aOutlook.Application();
            List<string> filelist = new List<string>();
            if (tmpMailItem2 == null)
            {
                if (oApp.ActiveExplorer().Selection.Count > 0)
                {
                    aOutlook.Selection sel = oApp.ActiveExplorer().Selection;
                    for (int i = 0; i < sel.Count; i++)
                    {
                        Object selObject = oApp.ActiveExplorer().Selection[i + 1];

                        if (selObject is aOutlook.MailItem)
                        {
                            filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Guid.NewGuid().ToString() + ".msg");
                            aOutlook.MailItem mailItem = (selObject as aOutlook.MailItem);
                            mailItem.SaveAs(filename);
                            filelist.Add(filename);
                        }
                    }
                }
            }
            else
            {
                filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Guid.NewGuid().ToString() + ".msg");
                frmMailSettings settings = new frmMailSettings();
                settings.MailItem = tmpMailItem2;

                if (settings.ShowDialog() == DialogResult.OK)
                {
                    filelist = settings.FileList;
                }
            }
            AvpOpen(filelist);
        }

        private void buttonTwo_Click(aOffice.CommandBarButton ctrl, ref bool cancel)
        {
            string filename = "";
            aOutlook._Application oApp = new aOutlook.Application();
            List<string> filelist = new List<string>();
            if (tmpMailItem2 == null)
            {
                if (oApp.ActiveExplorer().Selection.Count > 0)
                {
                    aOutlook.Selection sel = oApp.ActiveExplorer().Selection;
                    for (int i = 0; i < sel.Count; i++)
                    {
                        Object selObject = oApp.ActiveExplorer().Selection[i + 1];

                        if (selObject is aOutlook.MailItem)
                        {
                            filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Guid.NewGuid().ToString() + ".msg");
                            aOutlook.MailItem mailItem = (selObject as aOutlook.MailItem);
                            mailItem.SaveAs(filename);
                            filelist.Add(filename);
                        }
                    }
                }
            }
            else
            {
                filename = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Guid.NewGuid().ToString() + ".msg");
                frmMailSettings settings = new frmMailSettings();
                settings.MailItem = tmpMailItem2;

                if (settings.ShowDialog() == DialogResult.OK)
                {
                    filelist = settings.FileList;
                }
            }
            AvpOpen(filelist);
        }

        private stdole.IPictureDisp getImage()
        {
            stdole.IPictureDisp tempImage = null;
            try
            {
                var newIcon =
                    Properties.Resources.avukatpro8_64x64;

                System.Windows.Forms.ImageList newImageList =
                    new System.Windows.Forms.ImageList();
                newImageList.Images.Add(newIcon);
                tempImage = ConvertImage.Convert(newImageList.Images[0]);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return tempImage;
        }

        private void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            aOutlook.MailItem tmpMailItem = (aOutlook.MailItem)Inspector.CurrentItem;

            if (Inspector.CurrentItem is aOutlook.MailItem)
            {
                tmpMailItem = (aOutlook.MailItem)Inspector.CurrentItem;
                tmpMailItem2 = tmpMailItem;
                bool exists = buttonOne != null;
                foreach (aOffice.CommandBar cmd in Inspector.CommandBars)
                {
                    if (cmd.Name == "EAD")
                    {
                        //exists = true;
                        cmd.Delete();
                    }
                }

                aOffice.CommandBar newMenuBar = Inspector.CommandBars.Add("Maestro", aOffice.MsoBarPosition.msoBarTop, false, true);
                buttonOne = (aOffice.CommandBarButton)newMenuBar.Controls.Add(aOffice.MsoControlType.msoControlButton, 1, missing, missing, true);
                buttonTwo= (aOffice.CommandBarButton)newMenuBar.Controls.Add(aOffice.MsoControlType.msoControlButton, 1, missing, missing, true);

                if (!exists)
                {
                    buttonOne.Caption = "Maestro Belge olarak Kaydet";
                    buttonOne.Style = aOffice.MsoButtonStyle.msoButtonIconAndWrapCaptionBelow;
                    buttonOne.FaceId = 65;
                    buttonOne.Picture = getImage();
                    //Register send event handler
                    buttonOne.Click += new aOffice._CommandBarButtonEvents_ClickEventHandler(buttonOne_Click);
                    newMenuBar.Visible = true;
                }
                if (!exists)
                {
                    buttonOne.Caption = "Maestro Evrak olarak Kaydet";
                    buttonOne.Style = aOffice.MsoButtonStyle.msoButtonIconAndWrapCaptionBelow;
                    buttonOne.FaceId = 65;
                    buttonOne.Picture = getImage();
                    //Register send event handler
                    buttonOne.Click += new aOffice._CommandBarButtonEvents_ClickEventHandler(buttonTwo_Click);
                    newMenuBar.Visible = true;
                }
            }
        }

        private void newExplorer_Event(aOutlook.Explorer new_Explorer)
        {
            ((aOutlook._Explorer)new_Explorer).Activate();
            newToolBar = null;
            AddToolbar();
        }

        private void secondButton_Click(aOffice.CommandBarButton ctrl, ref bool cancel)
        {
            selectFile();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            settings = Settings.GetXml();
            if (string.IsNullOrEmpty(settings.ProgramPath))
            {
                MessageBox.Show("Lütfen Maestro Programının yüklü olduğu dizini ve program dosyasını seçiniz.");
                selectFile();
            }

            inspectors = this.Application.Inspectors;
            inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
            selectExplorers = this.Application.Explorers;
            selectExplorers.NewExplorer += new aOutlook.ExplorersEvents_NewExplorerEventHandler(newExplorer_Event);
            AddToolbar();
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion VSTO generated code
    }
}