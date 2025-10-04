using Asistan.LinqDAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Asistan
{
    public partial class Asistan : Form
    {
        public Asistan()
        {
            InitializeComponent();

            //bgw = new BackgroundWorker();
            //bgw.DoWork += new DoWorkEventHandler(bgw_DoWork); //SMS E-mail FAX WinService Kurulumu ve Kontrolü
            //if(!bgw.IsBusy)
            //bgw.RunWorkerAsync();
        }

        public FadeType FadeType;

        public Isler Isler;

        private int fadeSpeed = 0;

        private Graphics grphsBtn;

        private System.Windows.Forms.Timer tmr;

        private System.Windows.Forms.Timer tmrWarn;
        //BackgroundWorker bgw;

        public void FadeIn()
        {
            List<string> messages = new List<string>();
            this.Show();
            FadeType = FadeType.In;
            int cntrY = 5;
            foreach (var item in messages)
            {
                pnlContentControls.Controls.Add(new Label() { Text = item, Top = cntrY });
                cntrY += 5;
            }
            tmr.Start();
        }

        public void FadeOut()
        {
            FadeType = FadeType.Out;
            tmr.Start();
        }

        private void Asistan_Load(object sender, EventArgs e)
        {
            this.Width = 320;
            this.Height = 200;
            SetDefaultLocation();
            grphsBtn = btnClose.CreateGraphics();
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 10;
            tmr.Tick += new EventHandler(tmr_Tick);
            FadeType = FadeType.In;
            tmrWarn = new System.Windows.Forms.Timer();
            tmrWarn.Interval = 60000;
            loginControl1.Dock = DockStyle.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Avukatpro Asistanı'nı kapatıyorsunuz.\nBu durumda sistem içerisinde daha önce işaretlediğiniz işlerinde hatırlatması yapılamayacak.", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
                Environment.Exit(1);
            else
                FadeOut();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            grphsBtn.DrawImage(global::Asistan.Properties.Resources.Close_Hl, 0, 0, btnClose.Width, btnClose.Height);
            grphsBtn.DrawString("X", new Font(this.Font, FontStyle.Bold), Brushes.Black, 12, 3);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            grphsBtn.DrawImage(global::Asistan.Properties.Resources.Close, 0, 0, btnClose.Width, btnClose.Height);
            grphsBtn.DrawString("X", new Font(this.Font, FontStyle.Bold), Brushes.Black, 12, 3);
        }

        private void btnClose_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(global::Asistan.Properties.Resources.Close, 0, 0, btnClose.Width, btnClose.Height);
            e.Graphics.DrawString("X", new Font(this.Font, FontStyle.Bold), Brushes.Black, 12, 3);
        }

        private void loginControl1_Load(object sender, EventArgs e)
        {
        }

        private void loginControl1_OnLogon(object sender, EventArgs e)
        {
            FadeOut();
            Isler = new Isler();
            Isler.GetAll(Security.User);
        }

        private void SetDefaultLocation()
        {
            SetLocation(Screen.PrimaryScreen.WorkingArea.Width
                , Screen.PrimaryScreen.WorkingArea.Height - this.Height - 5);
        }

        private void SetLocation(int X, int Y)
        {
            this.SetDesktopLocation(X, Y);
        }

        private void SetLocation(int X)
        {
            this.SetDesktopLocation(X, this.Location.Y);
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            switch (FadeType)
            {
                case FadeType.In:
                    this.TopMost = true;
                    this.Visible = true;
                    this.Refresh();
                    if (this.Location.X <= Screen.PrimaryScreen.WorkingArea.Width - this.Width)
                    {
                        tmr.Stop();
                        break;
                    }
                    SetLocation(this.Location.X - fadeSpeed);
                    fadeSpeed++;
                    break;

                case FadeType.Out:
                    this.TopMost = false;
                    if (this.Location.X >= Screen.PrimaryScreen.WorkingArea.Width)
                    { tmr.Stop(); fadeSpeed = 0; SetDefaultLocation(); break; }
                    SetLocation(this.Location.X + fadeSpeed);
                    fadeSpeed--;
                    break;

                default:
                    break;
            }
        }
    }
}