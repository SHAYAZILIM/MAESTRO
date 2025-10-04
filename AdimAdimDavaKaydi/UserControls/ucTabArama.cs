using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using DevExpress.XtraTab;

namespace AdimAdimDavaKaydi.UserControls
{
    /// <summary>
    /// Uygulanacak olan TabControl ün TabPage lerini ExtendedTabPage ten örneklememiz gerekmektedir.
    /// </summary>
    public partial class ucTabArama : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucTabArama()
        {
            if (DesignMode)
                InitializeComponent();
            this.Load += ucTabArama_Load;
        }

        private void ucTabArama_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();

            if (TabKontrol.LookAndFeel.Style == DevExpress.LookAndFeel.LookAndFeelStyle.Skin)
            {
                checkEdit1.Checked = false;
            }
            else
            {
                checkEdit1.Checked = true;
            }

            List<ExtendedTabPage> lstTps = new List<ExtendedTabPage>();

            for (int i = 0; i < TabKontrol.TabPages.Count; i++)
            {
                lstTps.Add((ExtendedTabPage)TabKontrol.TabPages[i]);
            }

            treeList1.DataSource = lstTps;
        }

        /// <summary>
        /// Uygulamanın Hakim Olacağı XtraTabControl ü Belirtiniz.
        ///
        /// </summary>
        public XtraTabControl TabKontrol { get; set; }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            if (textEdit1.Text.Length > 0)
            {
                for (int i = 0; i < TabKontrol.TabPages.Count; i++)
                {
                    if (!TabKontrol.TabPages[i].Text.ToLower().Contains(textEdit1.Text.ToLower()))
                    {
                        TabKontrol.TabPages[i].PageVisible = false;
                    }
                }
            }
            else if (textEdit1.Text.Length < 1)
            {
                for (int i = 0; i < TabKontrol.TabPages.Count; i++)
                {
                    TabKontrol.TabPages[i].PageVisible = true;
                }
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                if (TabKontrol != null)
                {
                    TabKontrol.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
                    TabKontrol.LookAndFeel.SetStyle3D();
                    object o = TabKontrol.LookAndFeel.ActiveStyle;
                }
            }
            else
            {
                if (TabKontrol != null)
                {
                    TabKontrol.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
                    TabKontrol.LookAndFeel.SetDefaultStyle();
                }
            }
        }

        public static string GetParentsName(Control con, string name)
        {
            if (con.Parent != null)
            {
                name = GetParentsName(con.Parent, name);
            }

            name += "\\" + con.Name;

            return name;
        }
    }
}