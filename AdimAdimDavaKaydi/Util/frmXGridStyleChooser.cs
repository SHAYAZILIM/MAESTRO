using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.Util
{
    public partial class frmXGridStyleChooser : XtraForm
    {
        public frmXGridStyleChooser()
        {
            InitializeComponent();
        }

        private void frmXGridStyleChooser_Load(object sender, EventArgs e)
        {
            lsStyles.Items.AddRange(xs.FormatNames);
            lsStyles.SelectedItem = "(Default)";
            lsStyles.SelectedIndexChanged += lsStyles_SelectedIndexChanged;
        }

        private void lsStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsStyles.SelectedItem != null && myVGrid != null)
            {
                xs.LoadScheme(lsStyles.SelectedItem.ToString(), myVGrid.FocusedView);
                myVGrid.FocusedView.Tag = lsStyles.SelectedItem.ToString();
                // myVGrid.FocusedView.FormatConditions.Add((StyleFormatCondition)lsStyles.SelectedItem);
            }
        }

        public static DevExpress.XtraGrid.Design.XAppearances xs =
            new DevExpress.XtraGrid.Design.XAppearances(Application.StartupPath +
                                                        "\\Resources\\DevExpress.XtraGrid.Appearances.xml");

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
    }
}