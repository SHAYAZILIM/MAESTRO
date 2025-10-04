using System;
using System.Windows.Forms;

namespace AvukatProRaporlar.Raport.Util
{
    public partial class frmXGridStyleChooser : DevExpress.XtraEditors.XtraForm
    {
        public frmXGridStyleChooser()
        {
            InitializeComponent();
        }

        public static DevExpress.XtraGrid.Design.XAppearances xs = new DevExpress.XtraGrid.Design.XAppearances(Application.StartupPath + "\\Resources\\DevExpress.XtraGrid.Appearances.xml");

        private ExtendedGridControl myVGrid;

        public void ShowMe(ExtendedGridControl vGrid)
        {
            myVGrid = vGrid;
            this.Show();
            if (myVGrid.FocusedView.Tag != null && myVGrid.FocusedView.Tag is string)
            {
                lsStyles.SelectedItem = myVGrid.FocusedView.Tag.ToString();
            }
        }

        private void frmXGridStyleChooser_Load(object sender, EventArgs e)
        {
            lsStyles.Items.AddRange(xs.FormatNames);
            lsStyles.SelectedItem = "(Default)";
            lsStyles.SelectedIndexChanged += new EventHandler(lsStyles_SelectedIndexChanged);
        }

        private void lsStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsStyles.SelectedItem != null && myVGrid != null)
            {
                xs.LoadScheme(lsStyles.SelectedItem.ToString(), myVGrid.FocusedView);
                myVGrid.FocusedView.Tag = lsStyles.SelectedItem.ToString();

                //
                // myVGrid.FocusedView.FormatConditions.Add((StyleFormatCondition)lsStyles.SelectedItem);
            }
        }

        //public void ShowMe(global::AvukatProRaporlar.Lib.ExtendedGridControl globalAvukatProRaporlarLibExtendedGridControl)
        //{
        //    throw new NotImplementedException();
        //}

        //public void ShowMe(global::AvukatProRaporlar.Lib.ExtendedGridControl globalAvukatProRaporlarLibExtendedGridControl)
        //{
        //    throw new NotImplementedException();
        //}
    }
}