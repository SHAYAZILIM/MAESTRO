using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AvukatProImageEditor
{
    public class Resizer : Component
    {
        #region Fields

        private Control _myControl;
        private Control cnt = new Control();
        private Control cnt2 = new Control();
        private Control cnt3 = new Control();
        private List<Control> lstControls = new List<Control>();

        #endregion Fields

        #region Properties

        public Control MyControl
        {
            get { return _myControl; }
            set
            {
                _myControl = value;
                if (value != null)
                {
                    cnt.Left = _myControl.Left - 10;
                    cnt.Top = _myControl.Top - 10;
                    cnt.Move += new EventHandler(cnt_Move);
                    cnt.Height = 10;
                    cnt.Width = 10;
                    cnt.BackColor = Color.Black;

                    cnt2.Left = _myControl.Left + _myControl.Width;
                    cnt2.Top = _myControl.Top;
                    cnt2.Move += new EventHandler(cnt2_Move);
                    cnt2.Height = 10;
                    cnt2.Width = 10;
                    cnt2.BackColor = Color.Black;

                    cnt3.Left = _myControl.Left + _myControl.Width;
                    cnt3.Top = _myControl.Top + _myControl.Height;
                    cnt3.Move += new EventHandler(cnt3_Move);
                    cnt3.Height = 10;
                    cnt3.Width = 10;
                    cnt3.BackColor = Color.Black;

                    MyControl.Parent.Controls.Add(cnt);
                    MyControl.Parent.Controls.Add(cnt2);
                    MyControl.Parent.Controls.Add(cnt3);
                    MyControl.Move += new EventHandler(MyControl_Move);
                    MyControl.GotFocus += new EventHandler(MyControl_GotFocus);
                    MyControl.LostFocus += new EventHandler(MyControl_LostFocus);
                    MyControl.Resize += new EventHandler(MyControl_Resize);
                }
            }
        }

        #endregion Properties

        #region Methods

        private void cnt_Move(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            if (cnt.Focused)
            {
                _myControl.Left = cnt.Left + 10;
                _myControl.Top = cnt.Top + 10;
            }
        }

        private void cnt2_Move(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            if (cnt.Focused)
            {
                _myControl.Width = cnt.Left - _myControl.Left;
                _myControl.Top = cnt.Top;
            }
        }

        private void cnt3_Move(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;

            _myControl.Width = cnt.Left - _myControl.Left;
            _myControl.Height = cnt.Top - _myControl.Top;
        }

        private void MyControl_GotFocus(object sender, EventArgs e)
        {
            for (int i = 0; i < lstControls.Count; i++)
            {
                lstControls[i].Visible = true;
            }
        }

        private void MyControl_LostFocus(object sender, EventArgs e)
        {
            for (int i = 0; i < lstControls.Count; i++)
            {
                lstControls[i].Visible = false;
            }
        }

        private void MyControl_Move(object sender, EventArgs e)
        {
            SetLocations();
        }

        private void MyControl_Resize(object sender, EventArgs e)
        {
            SetLocations();
        }

        private void SetLocations()
        {
            cnt.Left = _myControl.Left;
            cnt.Top = _myControl.Top;

            cnt2.Left = _myControl.Left + _myControl.Width;
            cnt2.Top = _myControl.Top;

            cnt3.Left = _myControl.Left + _myControl.Width;
            cnt3.Top = _myControl.Top + _myControl.Height;
        }

        #endregion Methods
    }

    public partial class rfrmEditor : DevExpress.XtraEditors.XtraForm
    {
        #region Constructors

        public rfrmEditor()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void at_GotFocus(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            resizer1.MyControl = cnt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //at.Text= "dadad";

            //at.BorderStyle = BorderStyle.None;
            //at.Multiline = true;
            //at.GotFocus += new EventHandler(at_GotFocus);
            //mover1.MoveAll = true;
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void rfrmEditor_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods
    }
}