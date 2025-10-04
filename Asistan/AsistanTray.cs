using Asistan.LinqDAL;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Asistan
{
    public partial class AsistanTray : Form
    {
        public AsistanTray()
        {
            InitializeComponent();
        }

        public static Mutex sharedMutex;

        private Ajanda ajanda;

        private Asistan asistan;

        private void acToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acToolStripMenuItem.Text == "Çıkış")
            {
                Security.LogOut();
                Application.Exit();
                acToolStripMenuItem.Text = "Giriş";
                yapilacakIslerimToolStripMenuItem.Visible = false;
            }
            else
            {
                asistan.FadeIn();
            }
        }

        private void AsistanTray_Layout(object sender, LayoutEventArgs e)
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Hide();
                    break;

                case FormWindowState.Minimized:
                    break;

                case FormWindowState.Normal:
                    this.Hide();
                    break;

                default:
                    break;
            }
        }

        private void AsistanTray_Load(object sender, EventArgs e)
        {
            if (Program.girisYapilmis)
            {
                Security.Logon();
                yapilacakIslerimToolStripMenuItem.Visible = true;
                acToolStripMenuItem.Text = "Çıkış";
                if (Security.User != null)
                    Isler.GetAll(Security.User);
                ajanda = new Ajanda();
                ajanda.Show();
            }

            asistan = new Asistan();
            nIcon.Icon = global::Asistan.Properties.Resources.emd;
            nIcon.Visible = true;
            if (!Security.IsLogin)
            {
                
                asistan.FadeIn();
                yapilacakIslerimToolStripMenuItem.Visible = false;
            }
            
            Security.OnLogon += new EventHandler(Security_OnLogon);
        }

        private void nIcon_DoubleClick(object sender, EventArgs e)
        {
            //switch (asistan.FadeType)
            //{
            //    case global::Asistan.LinqDAL.FadeType.In:
            //        asistan.FadeOut();
            //        break;
            //    case global::Asistan.LinqDAL.FadeType.Out:
            //        asistan.FadeIn();
            //        break;
            //    default:
            //        break;
            //}
            ajanda.Show();
        }

        private void Security_OnLogon(object sender, EventArgs e)
        {
            if (Security.User != null)
            {
                yapilacakIslerimToolStripMenuItem.Visible = true;
                acToolStripMenuItem.Text = "Çıkış";
                ajanda = new Ajanda();

                ajanda.Show();
            }
        }

        private void yapilacakIslerimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ajanda.Show();
        }
    }
}