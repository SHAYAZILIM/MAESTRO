using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AvukatProImageEditor
{
    public class Mover : Component
    {
        #region Fields

        private bool _moveAll;
        private Control _mycontrol;
        private Control _parent;
        private Point Current = new Point();
        private bool IsSelected = false;
        private List<Control> lstControls = new List<Control>();

        #endregion Fields

        #region Properties

        public bool MoveAll
        {
            get { return _moveAll; }
            set
            {
                _moveAll = value;

                if (value)
                {
                    if (Parent != null)
                    {
                        for (int i = 0; i < Parent.Controls.Count; i++)
                        {
                            this.MyControl = Parent.Controls[i];
                        }
                    }
                }
            }
        }

        public Control MyControl
        {
            get { return _mycontrol; }
            set
            {
                _mycontrol = value;
                if (value != null)
                {
                    if (!IsInList(value))
                    {
                        lstControls.Add(value);
                        value.MouseDown += new MouseEventHandler(value_MouseDown);
                        value.MouseMove += new MouseEventHandler(value_MouseMove);
                        value.MouseUp += new MouseEventHandler(value_MouseUp);
                    }
                }
            }
        }

        public Control Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;

                if (value != null)
                {
                }
            }
        }

        #endregion Properties

        #region Methods

        private bool IsInList(Control value)
        {
            for (int i = 0; i < lstControls.Count; i++)
            {
                if (lstControls[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        private void value_MouseDown(object sender, MouseEventArgs e)
        {
            Current = e.Location;
            IsSelected = true;
        }

        private void value_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsSelected)
            {
                Control cnt = (Control)sender;
                cnt.Left += (e.X - Current.X);
                cnt.Top += (e.Y - Current.Y);
            }
        }

        private void value_MouseUp(object sender, MouseEventArgs e)
        {
            IsSelected = false;
        }

        #endregion Methods
    }
}