using DevExpress.XtraTab;
using System;
using System.ComponentModel;
using System.Drawing;

namespace AdimAdimDavaKaydi
{
    [ToolboxBitmap(typeof(AdimAdimDavaKaydi.ucTrackBar))]
    public partial class ucTrackBar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucTrackBar()
        {
            InitializeComponent();
        }

        private XtraTabControl _myTabControl;

        [Browsable(true)]
        [Description("Görünüm deðiþikliði uygulanacak XtraTabControl")]
        public XtraTabControl MyTabControl
        {
            get { return _myTabControl; }
            set
            {
                _myTabControl = value;
                if (MyTabControl != null)
                    tkBar.EditValueChanged += tkBar_EditValueChanged;
            }
        }

        private void tkBar_EditValueChanged(object sender, EventArgs e)
        {
            int i = (int)tkBar.EditValue;

            switch (i)
            {
                case 0:
                    MyTabControl.HeaderLocation = TabHeaderLocation.Top;
                    break;

                case 1:
                    MyTabControl.HeaderLocation = TabHeaderLocation.Left;
                    break;

                case 2:
                    MyTabControl.HeaderLocation = TabHeaderLocation.Right;
                    break;

                case 3:
                    MyTabControl.HeaderLocation = TabHeaderLocation.Bottom;
                    break;
            }
        }

        private void ucTrackBar_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;
        }
    }
}