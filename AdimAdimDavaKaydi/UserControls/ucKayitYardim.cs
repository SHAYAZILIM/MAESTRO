using System;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Properties;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class ucKayitYardim : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucKayitYardim()
        {
            InitializeComponent();
        }

        public string YardimKonusu
        {
            get { return groupControl1.Text; }
            set { groupControl1.Text = value; }
        }

        public string YardimAciklamasi
        {
            get { return txtYardim.Text; }
            set { txtYardim.Text = value; }
        }

        public Bitmap HelpImage
        {
            get { return (Bitmap)image.EditValue; }
            set { image.EditValue = value; }
        }

        private void ucKayitYardim_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            //image.EditValue = Resources.Yardim_40x40;

            HelpImage = Resources.Yardim_40x40;
        }
    }
}