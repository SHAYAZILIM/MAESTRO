using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraNavBar;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public static class NavBarControlHelper
    {
        public static int GetPaketControl(this NavBarItem control, int parentId, PaketForm pForm)
        {
            var parent = pForm.Controls.Where(q => q.Id == parentId).FirstOrDefault();
            string parentFullName = "";

            if (parent != null)
                parentFullName = parent.GetFullName();

            string fullName = parentFullName + "." + control.Name;

            var controls = pForm.Controls.Where(q => q.FullName == fullName);

            PaketControl pControl;

            if (controls.Count() == 0)
            {
                if (!control.Visible)
                    return 0;
                pControl = new PaketControl();
                pControl.ControlCaption = control.Caption;
                pControl.ControlName = control.Name;
                pControl.ControlType = control.GetType().Name;
                pControl.FullName = fullName;
                pControl.HashCode = (fullName + "." + control.Name).GetHashCode();

                if (string.IsNullOrEmpty(pControl.ControlName))
                    pControl.ControlName = pControl.ControlType;

                pForm.Controls.Add(pControl);
            }
            else if (controls.Count() == 1)
            {
                pControl = controls.FirstOrDefault();
            }
            else
            {
                pControl = controls.Where(q => q.HashCode == (fullName + "." + control.Name).GetHashCode()).FirstOrDefault();

                if (pControl == null)
                    pControl = new PaketControl();
            }

            pControl.Control = control;
            pControl.Id = control.GetHashCode();
            pControl.ParentId = parentId;

            return pControl.Id;
        }

        public static int GetPaketControl(this NavBarGroup control, int parentId, PaketForm pForm)
        {
            var parent = pForm.Controls.Where(q => q.Id == parentId).FirstOrDefault();
            string parentFullName = "";

            if (parent != null)
                parentFullName = parent.GetFullName();

            string fullName = parentFullName + "." + control.Name;

            var controls = pForm.Controls.Where(q => q.FullName == fullName);

            PaketControl pControl;

            if (controls.Count() == 0)
            {
                if (!control.Visible)
                    return 0;
                pControl = new PaketControl();
                pControl.ControlCaption = control.Caption;
                pControl.ControlName = control.Name;
                pControl.ControlType = control.GetType().Name;
                pControl.FullName = fullName;
                pControl.HashCode = (fullName + "." + control.Name).GetHashCode();

                if (string.IsNullOrEmpty(pControl.ControlName))
                    pControl.ControlName = pControl.ControlType;

                pForm.Controls.Add(pControl);
            }
            else if (controls.Count() == 1)
            {
                pControl = controls.FirstOrDefault();
            }
            else
            {
                pControl = controls.Where(q => q.HashCode == (fullName + "." + control.Name).GetHashCode()).FirstOrDefault();

                if (pControl == null)
                    pControl = new PaketControl();
            }

            pControl.Control = control;
            pControl.Id = control.GetHashCode();
            pControl.ParentId = parentId;

            return pControl.Id;
        }

        public static int GetPaketControl(this NavBarItemLink control, int parentId, PaketForm pForm)
        {
            var parent = pForm.Controls.Where(q => q.Id == parentId).FirstOrDefault();
            string parentFullName = "";

            if (parent != null)
                parentFullName = parent.GetFullName();

            string fullName = parentFullName + "." + control.ItemName;

            var controls = pForm.Controls.Where(q => q.FullName == fullName);

            PaketControl pControl;

            if (controls.Count() == 0)
            {
                if (!control.Visible)
                    return 0;
                pControl = new PaketControl();
                pControl.ControlCaption = control.Caption;
                pControl.ControlName = control.ItemName;
                pControl.ControlType = control.GetType().Name;
                pControl.FullName = fullName;
                pControl.HashCode = (fullName + "." + control.ItemName).GetHashCode();

                if (string.IsNullOrEmpty(pControl.ControlName))
                    pControl.ControlName = pControl.ControlType;

                pForm.Controls.Add(pControl);
            }
            else if (controls.Count() == 1)
            {
                pControl = controls.FirstOrDefault();
            }
            else
            {
                pControl = controls.Where(q => q.HashCode == (fullName + "." + control.ItemName).GetHashCode()).FirstOrDefault();

                if (pControl == null)
                    pControl = new PaketControl();
            }

            pControl.Control = control;
            pControl.Id = control.GetHashCode();
            pControl.ParentId = parentId;

            return pControl.Id;
        }

        internal static void GetControls(this NavBarControl control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (NavBarGroup item in control.Groups)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
        }

        internal static void GetControls(this NavBarGroup control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (NavBarItemLink item in control.ItemLinks)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
            }
            if (control.ControlContainer != null)
                foreach (Control item in control.ControlContainer.Controls)
                {
                    var id = item.GetPaketControl(parentId, pForm);
                    item.GetControls(id, pForm);
                }
        }
    }
}