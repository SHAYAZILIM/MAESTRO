using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AvukatproUpdater.Common.Controls
{
    [ProvideProperty("Text", typeof(ProgressControl))]
    [ProvideProperty("DownloadMode", typeof(ProgressControl))]
    [ProvideProperty("ProgressValue", typeof(ProgressControl))]
    [ProvideProperty("ProgressBarStyle", typeof(ProgressControl))]
    [ProvideProperty("ProcessCompleted", typeof(ProgressControl))]
    [ProvideProperty("IconVisible", typeof(ProgressControl))]
    public partial class ProgressControl : UserControl, IExtenderProvider
    {
        #region Constructors

        public ProgressControl()
        {
            InitializeComponent();
            ProcessCompleted = false;
        }

        #endregion Constructors

        #region Properties

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        public bool DownloadMode
        {
            get { return pnlDownload.Visible; }
            set { pnlDownload.Visible = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        public bool IconVisible
        {
            get
            {
                return pictureBox.Visible || progressDisk1.Visible;
            }
            set
            {
                pictureBox.Visible = progressDisk1.Visible = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        public bool ProcessCompleted
        {
            get
            {
                return pictureBox.Visible;
            }
            set
            {
                pictureBox.Visible = value;
                if (value == true)
                {
                    pictureBox.BringToFront();
                    progressDisk1.Visible = false;
                }
                else
                {
                    pictureBox.SendToBack();
                    progressDisk1.Visible = true;
                }
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        public ProgressBarStyle ProgressBarStyle
        {
            get { return pbarStatus.Style; }
            set { pbarStatus.Style = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        public int ProgressValue
        {
            get { return pbarStatus.Value; }
            set
            {
                pbarStatus.Value = value;
                lblPercent.Text = String.Format("{0} %", value);
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        public new string Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public string TextDownloadRate
        {
            get { return lblKb.Text; }
            set
            {
                lblKb.Visible = true;
                lblKb.Text = value;
            }
        }

        public string TextRemainingTime
        {
            get { return lblRemainingTime.Text; }
            set { lblRemainingTime.Text = value; }
        }

        #endregion Properties

        #region Methods

        public bool CanExtend(object extendee)
        {
            return extendee is ProgressControl;
        }

        private void pnlDownload_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlDownload.Visible) this.Height = 115;
            else this.Height = 35;
        }

        #endregion Methods
    }
}