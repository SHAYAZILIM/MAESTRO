using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl;

namespace AdimAdimDavaKaydi.Editor.Forms
{
    public partial class frmAlanEkle : XtraMessageBoxForm
    {
        public frmAlanEkle()
        {
            InitializeComponent();
        }

        public DialogResult ShowMe(TextControl tcnt)
        {
            TextFrame tfrm =
                new TextFrame(new Size(Convert.ToInt32(this.c_spnGenislik.Value), Convert.ToInt32(this.c_spnBoy.Value)));
            tfrm.BackColor = this.c_clrArka.Color;
            tcnt.TextFrames.Add(tfrm, tcnt.Selection.Start);
            this.ShowDialog();
            return this.DialogResult;
        }

        private void c_btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void c_btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}