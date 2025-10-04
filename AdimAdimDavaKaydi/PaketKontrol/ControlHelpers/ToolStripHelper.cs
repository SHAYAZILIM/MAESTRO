using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public static class ToolStripHelper
    {
        public static int GetPaketControl(this ToolStripItem control, int parentId, PaketForm pForm)
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
                pControl.ControlCaption = control.Text;
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

        internal static void GetControls(this ToolStrip control, int parentId, PaketForm pForm)
        {
            foreach (ToolStripItem item in control.Items)
            {
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
        }

        internal static void GetControls(this MenuStrip control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (ToolStripMenuItem item in control.Items)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
        }

        internal static void GetControls(this ToolStripMenuItem control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (ToolStripMenuItem item in control.DropDownItems.Cast<object>().Where(q => q is ToolStripMenuItem))
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
        }
    }
}