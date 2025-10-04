using System;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Entities;

namespace AdimAdimDavaKaydi.Util.KullaniciAyar
{
    public partial class frmGenelAyar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmGenelAyar()
        {
            InitializeComponent();
        }

        public static TList<AV001_TI_BIL_FOY> foy = new TList<AV001_TI_BIL_FOY>();

        private void frmGenelAyar_Load(object sender, EventArgs e)
        {
            frmGenel f = new frmGenel();
            f.subelerDoldur();
            GetForm(f, lnkGenel.Caption);
        }

        public enum Panel
        {
            Genel = 0,
            Icra = 1,
            Dava = 2
        }

        /// <summary>
        /// Form'u çaðýrmak için kullanýlýr.
        /// </summary>
        /// <param name="frm">Hedef Form</param>
        /// <param name="header">GroupBox için Baþlýk</param>
        private void GetForm(AvpXtraForm frm, string header)
        {
            groupControl1.Controls.Clear();
            this.groupControl1.Controls.Add(frm.c_pnlContainer);
            frm.c_pnlContainer.Dock = DockStyle.Fill;
        }

        private frmIcraAyar f;
        private frmDavaAyar f2;

        private void lnkIcra_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            f = new frmIcraAyar();
            GetForm(f, lnkIcra.Caption);
        }

        private void lnkGenel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmGenel f = new frmGenel();
            f.subelerDoldur();
            GetForm(f, lnkGenel.Caption);
        }

        private void lnkDava_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            f2 = new frmDavaAyar();
            f2.LookUpDoldur();
            GetForm(f2, lnkDava.Caption);
        }
    }
}