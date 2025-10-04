using DevExpress.XtraEditors;
using System.Data;
using System.Windows.Forms;

namespace AvukatPro.Database
{
    public partial class Form2 : Form
    {
        public Form2(DataSet ds)
        {
            InitializeComponent();
            dataset = ds;
            //this.gridControl1.AutoGenerateColumns = true;
            this.gridControl1.DataSource = ds.Tables[0];
        }

        private DataSet dataset;

        private void controlNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Custom && e.Button.Hint == "Excel")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    gridControl1.ExportToXls(saveFileDialog1.FileName);
                }
            }
        }
    }
}