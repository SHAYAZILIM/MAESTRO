using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraLayout;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public static class LayoutControlHelper
    {
        public static int GetPaketControl(this LayoutControl control, int parentId, PaketForm pForm)
        {
            string fullName = control.GetName();

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

        public static int GetPaketControl(this BaseLayoutItem control, int parentId, PaketForm pForm)
        {
            string caption = control.Text;

            if (control is LayoutControlItem)
            {
                var laycontrol = (control as LayoutControlItem);
                if (laycontrol.Control != null && !string.IsNullOrEmpty(laycontrol.Control.Text))
                    caption = laycontrol.Control.Text;
            }

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

        public static int GetPaketControl(this LayoutItemContainer control, int parentId, PaketForm pForm)
        {
            var id = 0;
            if (control is LayoutGroup)
            {
                id = (control as BaseLayoutItem).GetPaketControl(parentId, pForm);
                (control as LayoutGroup).GetControls(id, pForm);
            }
            else if (control is TabbedGroup)
            {
                id = (control as BaseLayoutItem).GetPaketControl(parentId, pForm);

                if (control is TabbedControlGroup)
                    (control as TabbedControlGroup).GetControls(id, pForm);
                else
                    control.GetControls(id, pForm);
            }
            else if (control is LayoutControlItem)
            {
            }
            return id;
        }

        internal static List<string> GetChildNames(this LayoutControl control)
        {
            List<string> controlNames = new List<string>();

            foreach (BaseLayoutItem item in control.Items)
            {
                controlNames.Add(item.Name);
                controlNames.AddRange(item.GetChildNames());
            }

            return controlNames;
        }

        internal static List<string> GetChildNames(this BaseLayoutItem control)
        {
            List<string> controlNames = new List<string>();
            controlNames.Add(control.Name);
            return controlNames;
        }

        internal static int GetControlHasCode(this LayoutControl control, string fullName)
        {
            var list = control.GetChildNames();
            list.Add(fullName);
            return string.Join(";", list.ToArray()).GetHashCode();
        }

        internal static int GetControlHasCode(this BaseLayoutItem control, string fullName)
        {
            var list = control.GetChildNames();
            list.Add(fullName);
            return string.Join(";", list.ToArray()).GetHashCode();
        }

        internal static void GetControls(this LayoutControl control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (BaseLayoutItem item in control.Items)
            {
                if (item == null)
                    continue;
                if (item.Parent == control.Root)
                {
                    var id = item.GetPaketControl(parentId, pForm);

                    if (item is LayoutControlGroup)
                        (item as LayoutControlGroup).GetControls(id, pForm);
                    else if (item is TabbedControlGroup)
                        (item as TabbedControlGroup).GetControls(id, pForm);
                    else
                    {
                        if (item is LayoutControlItem)
                        {
                            var laycontrol = (item as LayoutControlItem);
                            if (laycontrol.Control != null)
                            {
                                laycontrol.Control.GetControl(id, pForm);

                                //id = laycontrol.Control.GetPaketControl(id, pForm);
                                //laycontrol.Control.GetControls(id, pForm);
                            }
                        }
                    }
                }
            }
        }

        internal static void GetControls(this LayoutGroup control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (BaseLayoutItem item in control.Items)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);

                if (item is LayoutControlGroup)
                    (item as LayoutControlGroup).GetControls(id, pForm);
                else if (item is TabbedControlGroup)
                    (item as TabbedControlGroup).GetControls(id, pForm);
                else
                {
                    if (item is LayoutControlItem)
                    {
                        var laycontrol = (item as LayoutControlItem);
                        if (laycontrol.Control != null)
                        {
                            laycontrol.Control.GetControl(id, pForm);
                        }
                    }
                }
            }
        }

        internal static void GetControls(this TabbedControlGroup control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (LayoutGroup item in control.TabPages)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
        }
    }
}