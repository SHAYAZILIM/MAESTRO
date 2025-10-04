using System;

namespace AvukatProImageEditor
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        #region Constructors

        public XtraForm1()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.textControl1.Images.Add();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            textControl1.Tables.Add(3, 1);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            textControl1.TableFormatDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            textControl1.ImageAttributesDialog();
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}