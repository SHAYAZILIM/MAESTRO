using AdimAdimDavaKaydi.UserControls.Sablon_Ajanda_Belge;
using System;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.Forms.Ajanda_Sablon_Belge
{
    public partial class frmEditorFind : AdimAdimDavaKaydi.Util.BaseClasses.AvpXtraForm
    {
        public frmEditorFind()
        {
            InitializeComponent();
        }

        private bool caseSensitive;

        private TextControl document;

        private FindOptions option;

        private string searched;

        public void ShowFindDialog(uctxEditor _document)
        {
            this.document = _document.textControl1;

            //.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog();
        }

        private void btn_Click(object sender, EventArgs e)
        {
        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.caseSensitive = this.checkButton1.Checked;
        }

        private void doubleButton1_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.document.Find(searched, 0, option);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
        }
    }
}