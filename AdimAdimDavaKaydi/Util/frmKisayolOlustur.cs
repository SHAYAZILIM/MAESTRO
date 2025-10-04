using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace AdimAdimDavaKaydi
{
    public partial class frmKisayolOlustur : Form
    {
        public frmKisayolOlustur()
        {
            InitializeComponent();
        }

        private void frmKisayolOlustur_Load(object sender, EventArgs e)
        {
        }

        private void btnKisayolOlustur_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                KisayolOlustur(folderBrowserDialog1.SelectedPath, "Maestro İcra",
                               "Avukatpro Maestro İcra Yönetimi", "KISAYOLICRA");
                KisayolOlustur(folderBrowserDialog1.SelectedPath, "Maestro Dava",
                               "Avukatpro Maestro Dava Yönetimi", "KISAYOLDAVA");
                KisayolOlustur(folderBrowserDialog1.SelectedPath, "Maestro Soruşturma",
                               "Avukatpro Maestro Soruşturma Yönetimi", "KISAYOLSORUSTURMA");
                KisayolOlustur(folderBrowserDialog1.SelectedPath, "Maestro Klasör",
                               "Avukatpro Maestro Servis Dosya Yönetimi", "KLASOR");
            }
        }

        private void KisayolOlustur(string kisayolYolu, string dosyaAdi, string aciklama, string parametre)
        {
            // Create a new instance of WshShellClass
            WshShellClass WshShell;
            WshShell = new WshShellClass();

            // Create the shortcut

            IWshRuntimeLibrary.IWshShortcut MyShortcut;

            // Choose the path for the shortcut

            MyShortcut =
                (IWshRuntimeLibrary.IWshShortcut)
                WshShell.CreateShortcut(String.Format("{0}\\{1}.lnk", kisayolYolu, dosyaAdi));

            // Where the shortcut should point to

            MyShortcut.TargetPath = Application.ExecutablePath;
            MyShortcut.Arguments = parametre;
            // Description for the shortcut

            MyShortcut.Description = aciklama;

            // Location for the shortcut's icon

            MyShortcut.IconLocation = Application.ExecutablePath + ",0";

            // Create the shortcut at the given path

            MyShortcut.Save();
        }

        private void btnStartMenuEkle_Click(object sender, EventArgs e)
        {
            string startmenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);

            KisayolOlustur(startmenu, "Avukatpro Maestro - İcra", "Avukatpro Maestro İcra Yönetimi", "KISAYOLICRA");
            KisayolOlustur(startmenu, "Avukatpro Maestro - Dava", "Avukatpro Maestro Dava Yönetimi", "KISAYOLDAVA");
            KisayolOlustur(startmenu, "Avukatpro Maestro - Soruşturma", "Avukatpro Maestro Soruşturma Yönetimi",
                           "KISAYOLSORUSTURMA");
            KisayolOlustur(startmenu, "Avukatpro Maestro - Klasör", "Avukatpro Maestro Servis Dosya Yönetimi",
                           "KLASOR");
        }
    }
}