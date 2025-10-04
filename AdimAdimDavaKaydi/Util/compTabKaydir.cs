using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;

namespace AdimAdimDavaKaydi.Util
{
    public partial class compTabKaydir : Component
    {
        public compTabKaydir()
        {
            InitializeComponent();
        }

        public compTabKaydir(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private XtraTabControl _tabKontrol;

        public XtraTabControl TabKontrol
        {
            get { return _tabKontrol; }
            set
            {
                _tabKontrol = value;
                value.MouseDown += xtraTabControl1_MouseDown;
                value.MouseMove += xtraTabControl1_MouseMove;
                value.DragOver += xtraTabControl1_DragOver;
            }
        }

        private Point p = Point.Empty;
        private XtraTabPage page;

        private void xtraTabControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            XtraTabControl c = sender as XtraTabControl;
            p = new Point(e.X, e.Y);
            XtraTabHitInfo hi = c.CalcHitInfo(p);
            page = hi.Page;
            if (hi.Page == null)
                p = Point.Empty;
        }

        private void xtraTabControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if ((p != Point.Empty) &&
                    ((Math.Abs(e.X - p.X) > SystemInformation.DragSize.Width) ||
                     (Math.Abs(e.Y - p.Y) > SystemInformation.DragSize.Height)))
                    _tabKontrol.DoDragDrop(sender, DragDropEffects.Move);
        }

        private void xtraTabControl1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            XtraTabControl c = sender as XtraTabControl;
            if (c == null)
                return;
            XtraTabHitInfo hi = c.CalcHitInfo(c.PointToClient(new Point(e.X, e.Y)));
            if (hi.Page != null)
            {
                if (hi.Page != page)
                {
                    if (c.TabPages.IndexOf(hi.Page) < c.TabPages.IndexOf(page))
                        c.TabPages.Move(c.TabPages.IndexOf(hi.Page), page);
                    else
                        c.TabPages.Move(c.TabPages.IndexOf(hi.Page) + 1, page);
                }
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;
        }
    }
}