using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public static class PaketControlHelper
    {
        /// <summary>
        /// Get Control to PaketControl
        /// </summary>
        /// <param name="form"></param>
        /// <returns>PaketControl</returns>
        public static int GetPaketControl(this Control control, int parentId, PaketForm pForm)
        {
            string fullName = control.GetName();

            var controls = pForm.Controls.Where(q => q.FullName == fullName);

            PaketControl pControl;

            if (controls.Count() == 0)
            {                
                pControl = new PaketControl();
                pControl.ControlCaption = control.Text;
                pControl.ControlName = control.Name;
                pControl.ControlType = control.GetType().Name;
                pControl.FullName = fullName;
                pControl.HashCode = control.GetControlHasCode(fullName);

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
                pControl = controls.Where(q => q.HashCode == control.GetControlHasCode(fullName)).FirstOrDefault();

                if (pControl == null)
                    pControl = new PaketControl();
            }

            pControl.Control = control;
            pControl.Id = control.GetHashCode();
            pControl.ParentId = parentId;

            return pControl.Id;
        }

        internal static List<string> GetChildNames(this Control control)
        {
            List<string> controlNames = new List<string>();

            foreach (Control item in control.Controls)
            {
                controlNames.Add(item.Name);
                controlNames.AddRange(item.GetChildNames());
            }

            return controlNames;
        }

        internal static int GetControlHasCode(this Control control, string fullName)
        {
            var list = control.GetChildNames();
            list.Add(fullName);
            return string.Join(";", list.ToArray()).GetHashCode();
        }

        internal static string GetFullName(this PaketControl source)
        {
            if (source.PaketForm == null || source.ParentId == null || source.ParentId == 0)
                return source.ControlName;

            var parent = source.PaketForm.Controls.Where(q => q.Id == source.ParentId).FirstOrDefault();

            if (parent == null)
                return source.ControlName;
            else
                return parent.FullName + "." + source.ControlName;
        }
    }
}