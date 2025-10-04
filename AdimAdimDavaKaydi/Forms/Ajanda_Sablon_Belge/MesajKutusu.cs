using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi
{
    public partial class MesajKutusu : XtraMessageBoxForm
    {
        public MesajKutusu()
        {
            InitializeComponent();
        }

        public MesajKutusu(string Caption, string Message, string Description, MessageBoxButtons buttons,
                           string HelpAddress, MessageBoxIcon icon)
        {
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            this.ShowDialog(Caption, Message, Description, buttons, HelpAddress, icon);
        }

        private string HelpAdress = "";

        public DialogResult ShowDialog(string Caption, string Message, string Description, MessageBoxButtons buttons,
                                       string HelpAddress, MessageBoxIcon icon)
        {
            switch (buttons)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    btn1.Text = "Abort";
                    btn1.Click += Abort;
                    btn2.Text = "Retry";
                    btn2.Click += Retry;
                    btn3.Text = "Ignore";
                    btn3.Click += Ignore;
                    break;

                case MessageBoxButtons.OK:
                    btn1.Text = "Ok";
                    btn1.Click += Ok;
                    btn2.Visible = false;
                    btn3.Visible = false;

                    break;

                case MessageBoxButtons.OKCancel:
                    btn1.Text = "Ok";
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn1.Click += OkCancelsOk;
                    btn2.Text = "Cancel";
                    btn2.Click += Cancel;
                    btn3.Visible = false;
                    break;

                case MessageBoxButtons.RetryCancel:
                    btn1.Text = "Retry";
                    btn1.Click += RetryCancelsRetry;
                    btn2.Text = "Cancel";
                    btn2.Click += RetryCancelsCancel;
                    btn3.Visible = false;
                    break;

                case MessageBoxButtons.YesNo:
                    btn1.Text = "Yes";
                    btn1.Click += Yes;
                    btn2.Text = "No";
                    btn2.Click += No;
                    btn3.Visible = false;
                    break;

                case MessageBoxButtons.YesNoCancel:
                    btn1.Text = "Yes";
                    btn1.Click += Yes;
                    btn1.Visible = true;
                    btn2.Text = "No";
                    btn2.Click += No;
                    btn2.Visible = true;
                    btn3.Text = "Cancel";
                    btn3.Click += Cancel;
                    btn3.Visible = true;
                    break;

                default:
                    btn1.Text = "Ok";
                    btn1.Click += Ok;
                    btn2.Visible = false;
                    btn3.Visible = false;
                    break;
            }
            this.Text = Caption;
            this.labelControl2.Text = Message;
            this.labelControl1.Text = Description;
            this.HelpAdress = HelpAddress;
            switch (icon)
            {
                case MessageBoxIcon.Asterisk:
                    pictureBox1.Image = PrintRibbonControllerResources.RibbonPrintPreview_ClosePreview;
                    break;

                case MessageBoxIcon.Error:
                    pictureBox1.Image = XRDesignRibbonControllerResources.RibbonUserDesigner_CutLarge;
                    break;

                case MessageBoxIcon.Exclamation:
                    pictureBox1.Image = PrintRibbonControllerResources.RibbonPrintPreview_Magnifier;
                    break;

                //case MessageBoxIcon.Hand:
                //    pictureBox1.Image = PrintRibbonControllerResources.RibbonPrintPreview_HandTool;
                //    break;
                //case MessageBoxIcon.Information:
                //    pictureBox1.Image = PrintRibbonControllerResources.RibbonPrintPreview_SendGraphic;
                //    break;
                case MessageBoxIcon.None:
                    break;

                case MessageBoxIcon.Question:
                    pictureBox1.Image = PrintRibbonControllerResources.RibbonPrintPreview_CustomizeLarge;
                    break;

                //case MessageBoxIcon.Stop:
                //    pictureBox1.Image = PrintRibbonControllerResources.RibbonPrintPreview_Pointer;
                //    break;
                //case MessageBoxIcon.Warning:
                //    pictureBox1.Image = PrintRibbonControllerResources.RibbonPrintPreview_WatermarkLarge;
                //    break;
                default:
                    break;
            }

            //this.MdiParent = null;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
            return this.ShowDialog();
        }

        private void Abort(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Ignore(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
        }

        private void No(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void Ok(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void OkCancelsOk(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Retry(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        private void RetryCancelsCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void RetryCancelsRetry(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        private void Yes(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }

    public static class MesajCi
    {
        private static MesajKutusu mk = new MesajKutusu();

        public static DialogResult Goster(string Caption, string Message, string Description, MessageBoxButtons buttons,
                                          string HelpAddress, MessageBoxIcon icon)
        {
            return mk.ShowDialog(Caption, Message, Description, buttons, HelpAddress, icon);
        }
    }
}