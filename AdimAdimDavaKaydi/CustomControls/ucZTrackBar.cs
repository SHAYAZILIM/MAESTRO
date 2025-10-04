using DevExpress.XtraTab;
using System;
using System.ComponentModel;

namespace AdimAdimDavaKaydi
{
    public partial class ucZTrackBar : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl// UserControl
    {
        public ucZTrackBar()
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
                    zoomTrackBarControl1.EditValueChanged += zoomTrackBarControl1_EditValueChanged;
            }
        }

        private void ucZTrackBar_Load(object sender, EventArgs e)
        {
        }

        private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            int i = (int)zoomTrackBarControl1.EditValue;

            switch (i)
            {
                case 0:
                    MyTabControl.MultiLine = DevExpress.Utils.DefaultBoolean.True;
                    break;

                case 1:
                    MyTabControl.MultiLine = DevExpress.Utils.DefaultBoolean.False;
                    break;
            }
        }
    }
}