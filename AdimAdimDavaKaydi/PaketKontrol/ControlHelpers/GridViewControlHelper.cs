using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public static class GridViewControlHelper
    {
        /// <summary>
        /// Get Control to PaketControl
        /// </summary>
        /// <param name="form"></param>
        /// <returns>PaketControl</returns>
        public static int GetPaketControl(this ColumnView control, int parentId, PaketForm pForm)
        {
            string fullName = control.GridControl.GetName() + "." + control.Name;

            var controls = pForm.Controls.Where(q => q.FullName == fullName);

            PaketControl pControl;

            if (controls.Count() == 0)
            {
                if (!control.IsVisible)
                    return 0;
                pControl = new PaketControl();
                pControl.ControlCaption = control.ViewCaption;
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

        public static int GetPaketControl(this VGridControl control, int parentId, PaketForm pForm)
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

        public static int GetPaketControl(this GridControl control, int parentId, PaketForm pForm)
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

        public static int GetPaketControl(this GridColumn control, int parentId, PaketForm pForm)
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

        public static int GetPaketControl(this BaseRow control, int parentId, PaketForm pForm)
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
                //pControl.ControlCaption = control.Properties.Caption;
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

        public static int GetPaketControl(this MultiEditorRowProperties control, int parentId, PaketForm pForm)
        {
            var parent = pForm.Controls.Where(q => q.Id == parentId).FirstOrDefault();
            string parentFullName = "";

            if (parent != null)
                parentFullName = parent.GetFullName();

            string fullName = parentFullName + "." + control.FieldName;

            var controls = pForm.Controls.Where(q => q.FullName == fullName);

            PaketControl pControl;

            if (controls.Count() == 0)
            {
                pControl = new PaketControl();
                pControl.ControlCaption = control.Caption;
                pControl.ControlName = control.FieldName;
                pControl.ControlType = control.GetType().Name;
                pControl.FullName = fullName;
                pControl.HashCode = (fullName + "." + control.FieldName).GetHashCode();

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
                pControl = controls.Where(q => q.HashCode == (fullName + "." + control.FieldName).GetHashCode()).FirstOrDefault();

                if (pControl == null)
                    pControl = new PaketControl();
            }

            pControl.Control = control;
            pControl.Id = control.GetHashCode();
            pControl.ParentId = parentId;

            return pControl.Id;
        }

        public static int GetPaketControl(this NavigatorButtonBase control, int parentId, PaketForm pForm)
        {
            var parent = pForm.Controls.Where(q => q.Id == parentId).FirstOrDefault();
            string parentFullName = "";

            if (parent != null)
                parentFullName = parent.GetFullName();

            string fullName = parentFullName + "." + control.Hint;

            var controls = pForm.Controls.Where(q => q.FullName == fullName);

            PaketControl pControl;

            if (controls.Count() == 0)
            {
                if (!control.Visible)
                    return 0;
                pControl = new PaketControl();
                pControl.ControlCaption = control.Hint;
                pControl.ControlName = control.Hint;
                pControl.ControlType = control.GetType().Name;
                pControl.FullName = fullName;
                pControl.HashCode = (fullName + "." + control.GetHashCode().ToString()).GetHashCode();

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
                pControl = controls.Where(q => q.HashCode == (fullName + "." + control.GetHashCode().ToString()).GetHashCode()).FirstOrDefault();

                if (pControl == null)
                    pControl = new PaketControl();
            }

            pControl.Control = control;
            pControl.Id = control.GetHashCode();
            pControl.ParentId = parentId;

            return pControl.Id;
        }

        public static int GetPaketControl(this NavigatorBase control, int parentId, PaketForm pForm)
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

        internal static List<string> GetChildNames(this ColumnView control)
        {
            List<string> controlNames = new List<string>();

            foreach (GridColumn item in control.Columns)
            {
                controlNames.Add(item.Name);
            }

            return controlNames;
        }

        internal static int GetControlHasCode(this ColumnView control, string fullName)
        {
            var list = control.GetChildNames();
            list.Add(fullName);
            return string.Join(";", list.ToArray()).GetHashCode();
        }

        internal static void GetControls(this ColumnView control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (GridColumn item in control.Columns)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
            }
        }

        internal static void GetControls(this ControlNavigator control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (Control item in control.Controls)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
            foreach (NavigatorButtonBase item in control.Buttons.ButtonCollection)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
            }
            foreach (NavigatorButtonBase item in control.Buttons.CustomButtons)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
            }
        }

        internal static void GetControls(this DataNavigator control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (Control item in control.Controls)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
            foreach (NavigatorButtonBase item in control.Buttons.ButtonCollection)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
            }
            foreach (NavigatorButtonBase item in control.Buttons.CustomButtons)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
            }
        }

        internal static void GetControls(this NavigatorBase control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            if (control == null)
                return;
            if (control is DataNavigator)
                (control as DataNavigator).GetControls(parentId, pForm);
            else if (control is ControlNavigator)
                (control as ControlNavigator).GetControls(parentId, pForm);
        }

        internal static void GetControls(this VGridControl control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (BaseRow item in control.Rows)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);

                if (item is MultiEditorRow)
                    (item as MultiEditorRow).GetControls(id, pForm);
                else
                    item.GetControls(id, pForm);
            }
        }

        internal static void GetControls(this BaseRow control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (BaseRow item in control.ChildRows)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);

                if (item is MultiEditorRow)
                    (item as MultiEditorRow).GetControls(id, pForm);
                else
                    item.GetControls(id, pForm);
            }
        }

        internal static void GetControls(this MultiEditorRow control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (MultiEditorRowProperties item in control.PropertiesCollection.Cast<MultiEditorRowProperties>().ToList())
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }

            foreach (BaseRow item in control.ChildRows)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
        }

        internal static void GetControls(this GridControl control, int parentId, PaketForm pForm)
        {
            if (control == null)
                return;
            foreach (ColumnView item in control.Views)
            {
                if (item == null)
                    continue;
                var id = item.GetPaketControl(parentId, pForm);
                item.GetControls(id, pForm);
            }
            if (control.EmbeddedNavigator != null)
            {
                var id = control.EmbeddedNavigator.GetPaketControl(parentId, pForm);
                control.EmbeddedNavigator.GetControls(id, pForm);
            }
        }
    }
}