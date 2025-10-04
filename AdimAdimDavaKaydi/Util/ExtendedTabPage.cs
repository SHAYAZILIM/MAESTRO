using System.Drawing;
using DevExpress.XtraTab;

namespace AdimAdimDavaKaydi.Util
{
    internal class ExtendedTabPage : XtraTabPage
    {
        public Color TabKulakRenk
        {
            set { this.Appearance.Header.BackColor = value; }
        }
    }
}