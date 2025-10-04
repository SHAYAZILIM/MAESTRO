using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.Forms
{
    public partial class frmUyapIslemSecimi : Form
    {
        public frmUyapIslemSecimi()
        {
            InitializeComponent();
        }

        public AvukatProLib.Extras.UYAPIslemSecimi UYAPSecimi = AvukatProLib.Extras.UYAPIslemSecimi.Kayit;

        private void sbtnKayit_Click(object sender, EventArgs e)
        {
            UYAPSecimi = AvukatProLib.Extras.UYAPIslemSecimi.Kayit;
            this.Close();
        }

        private void sbtnMail_Click(object sender, EventArgs e)
        {
            UYAPSecimi = AvukatProLib.Extras.UYAPIslemSecimi.Mail;
            this.Close();
        }
    }
}