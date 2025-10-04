using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using DevExpress.XtraVerticalGrid;
using System.Collections;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public static class PaketFormHelper
    {
        private static List<PaketForm> _Forms;

        /// <summary>
        /// Forms source
        /// </summary>
        public static List<PaketForm> Forms
        {
            get
            {
                if (_Forms == null)
                {
                    if (File.Exists(FormFileName))
                    {
                        FileStream stream = File.Open(FormFileName, FileMode.Open);
                        AES aes = new AES();
                        byte[] b = new byte[stream.Length];
                        stream.Read(b, 0, b.Length);
                        var arry = aes.Decrypt(b);
                        Stream streamm = new MemoryStream(arry);
                        BinaryFormatter bFormatter = new BinaryFormatter();
                        _Forms = (List<PaketForm>)bFormatter.Deserialize(streamm);
                        stream.Close();
                        streamm.Close();
                        stream = null;
                        streamm = null;
                        b = null;
                        arry = null;
                        aes = null;
                        bFormatter = null;
                        AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
                    }
                    else
                        _Forms = new List<PaketForm>();
                }
                return _Forms;
            }
            set
            {
                _Forms = value;
            }
        }

        /// <summary>
        /// Form list saved file name
        /// </summary>
        internal static string FormFileName
        {
            get
            {
                return Path.Combine(Application.StartupPath, "dataf.bin");
            }
        }

        public static void GetPaketForm(this Form form)
        {
            PaketForm pForm = Forms.Where(q => q.FullName == form.GetName()).FirstOrDefault();
            form.FormClosed += new FormClosedEventHandler(form_FormClosed);
            if (pForm == null)
            {
                if (!PaketHelper.IsEdit)
                    return;
                pForm = new PaketForm();
                pForm.FormCaption = form.Text;
                pForm.FormName = form.Name;
                pForm.FormType = form.GetType().Name;
                pForm.FullName = form.GetName();
                Forms.Add(pForm);
            }

            if (pForm.Controls == null)
                pForm.Controls = new ChildItemCollection<PaketForm, PaketControl>(pForm);
            else
                pForm.Controls.SetParent(pForm, true);

            pForm.Id = form.Handle.ToInt32();
            pForm.Form = form;
            form.GetControls(pForm.Id, pForm, true);
        }

        public static void GetPaketForm(this Control form)
        {
            PaketForm pForm = Forms.Where(q => q.FullName == form.FindForm().GetName()).FirstOrDefault();
            if (pForm != null)
            {
                string fullName = "";
                PaketControl controls = null;
                int id = 0;
                if (form.Parent != null)
                {
                    fullName = form.Parent.GetName();
                    controls = pForm.Controls.Where(q => q.FullName == fullName).FirstOrDefault();
                }
                if (controls != null)
                    id = form.GetPaketControl(controls.Id, pForm);
                else
                    id = form.GetPaketControl(pForm.Id, pForm);
                form.GetControl(id, pForm);
            }

        }

        /// <summary>
        /// Get Form control to PaketForm
        /// </summary>
        /// <param name="form"></param>
        /// <returns>PaketForm</returns>
        public static PaketForm GetPaketFormForPacket(this Form form)
        {
            PaketForm pForm = Forms.Where(q => q.FullName == form.GetName()).FirstOrDefault();

            if (pForm == null)
            {
                pForm = new PaketForm();
                pForm.FormCaption = form.Text;
                pForm.FormName = form.Name;
                pForm.FormType = form.GetType().Name;
                pForm.FullName = form.GetName();
                Forms.Add(pForm);
            }

            if (pForm.Controls == null)
                pForm.Controls = new ChildItemCollection<PaketForm, PaketControl>(pForm);
            else
                pForm.Controls.SetParent(pForm, true);

            pForm.Id = form.Handle.ToInt32();
            pForm.Form = form;
            form.GetControls(pForm.Id, pForm, true);

            return pForm;
        }

        /// <summary>
        /// Save form list to a binary file
        /// </summary>
        /// <param name="formList"></param>
        public static void Save(this List<PaketForm> formList)
        {
            SaveForms(formList);
        }

        internal static void GetControl(this IComponent control, int parentId, PaketForm pForm)
        {
            control.GetControls(parentId, pForm);
        }

        /// <summary>
        /// Get control child controls
        /// </summary>
        /// <param name="form"></param>
        internal static void GetControls(this Control control, int parentId, PaketForm pForm, bool isform = false)
        {
            foreach (IComponent item in control.Controls.Cast<object>().Where(q => !(q is Form) && !(q is AvpXtraForm)))
            {
                item.GetControls(parentId, pForm, isform);
            }
        }

        /// <summary>
        /// Get control child controls
        /// </summary>
        /// <param name="form"></param>
        internal static void GetControls(this IComponent control, int parentId, PaketForm pForm, bool isform = false)
        {
            if (control == null)
            {
                return;
            }
            if (control is Form && !isform)
            {
                return;
            }
            if (control is LayoutControl)
            {
                var id = (control as LayoutControl).GetPaketControl(parentId, pForm);
                (control as LayoutControl).GetControls(id, pForm);
            }
            else if (control is LayoutItemContainer)
            {
                var id = (control as LayoutItemContainer).GetPaketControl(parentId, pForm);
            }
            else if (control is GridControl)
            {
                var id = (control as GridControl).GetPaketControl(parentId, pForm);
                (control as GridControl).GetControls(id, pForm);
            }
            else if (control is VGridControl)
            {
                var id = (control as VGridControl).GetPaketControl(parentId, pForm);
                (control as VGridControl).GetControls(id, pForm);
            }
            else if (control is NavigatorBase)
            {
                var id = (control as NavigatorBase).GetPaketControl(parentId, pForm);
                (control as NavigatorBase).GetControls(id, pForm);
            }
            else if (control is MenuStrip)
            {
                var id = (control as MenuStrip).GetPaketControl(parentId, pForm);
                (control as MenuStrip).GetControls(id, pForm);
            }
            else if (control is ToolStrip)
            {
                var id = (control as ToolStrip).GetPaketControl(parentId, pForm);
                (control as ToolStrip).GetControls(id, pForm);
            }
            else if (control is XtraTabControl)
            {
                var id = (control as XtraTabControl).GetPaketControl(parentId, pForm);
                (control as XtraTabControl).GetControls(id, pForm);
            }
            else if (control is NavBarControl)
            {
                var id = (control as NavBarControl).GetPaketControl(parentId, pForm);
                (control as NavBarControl).GetControls(id, pForm);
            }
            else if (control is Control)
            {
                var id = (control as Control).GetPaketControl(parentId, pForm);
                (control as Control).GetControls(id, pForm);
            }
        }

        /// <summary>
        /// Get Control Full name with parents
        /// </summary>
        /// <param name="form"></param>
        /// <returns>string</returns>
        internal static string GetName(this Control form)
        {
            if (form.Parent == null)
                return form.Name;
            else
                return form.Parent.GetName() + "." + form.Name;
        }

        /// <summary>
        /// Serialize form list and save to file
        /// </summary>
        /// <param name="formList"></param>
        internal static void SaveForms(List<PaketForm> formList)
        {
            SaveForms(formList, FormFileName);
        }

        internal static void SaveForms(List<PaketForm> formList, string filename)
        {
            var isedit = PaketHelper.IsEdit;
            PaketHelper.IsEdit = false;
            foreach (var form in formList)
            {
                foreach (var control in form.Controls.Where(q => q.Properties != null))
                {
                    var removed = control.Properties.Where(q => !q.Aktif.HasValue && !q.Gorunur.HasValue).ToList();
                    foreach (var rmv in removed)
                    {
                        if (rmv.PaketControl != null && !string.IsNullOrEmpty(rmv.PaketControl.CustomCaption))
                            continue;
                        control.Properties.Remove(rmv);
                    }

                    foreach (var prp in control.Properties.Where(q => q.GroupProperties != null))
                    {
                        var cremoved = prp.GroupProperties.Where(q => !PaketHelper.UserGroups.Any(w => w.Id == q.GroupId)).ToList();
                        foreach (var rmv in cremoved)
                        {
                            prp.GroupProperties.Remove(rmv);
                        }

                        cremoved = prp.GroupProperties.Where(q => !q.Aktif.HasValue && !q.Gorunur.HasValue).ToList();
                        foreach (var rmv in cremoved)
                        {
                            prp.GroupProperties.Remove(rmv);
                        }
                    }
                }
                var rmvd = form.Controls.Where(q => q.Properties == null || q.Properties.Count() == 0).ToList();
                foreach (var rmv in rmvd)
                {
                    if (!string.IsNullOrEmpty(rmv.CustomCaption))
                        continue;
                    form.Controls.Remove(rmv);
                }
            }
            PaketHelper.IsEdit = isedit;

            MemoryStream ms = new MemoryStream();
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(ms, formList);

            AES aes = new AES();
            var arry = aes.Encrypt(ms.ToArray());

            FileStream stream = File.Open(filename, FileMode.Create);
            stream.Write(arry, 0, arry.Length);
            stream.Close();
            ms.Close();
            aes = null;
            arry = null;
        }

        private static void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form f = sender as Form;

            if (f != null)
            {
                PaketForm pForm = Forms.Where(q => q.FullName == f.GetName()).FirstOrDefault();
                if (pForm != null)
                {
                    foreach (var item in pForm.Controls.ToList())
                    {
                        if (item.Control != null && item.Control is IDisposable)
                        {
                            try
                            {
                                (item.Control as IDisposable).Dispose();
                            }
                            catch { ;}
                        }
                    }
                }
                else
                {
                    foreach (var item in f.Controls)
                    {
                        if (item != null && item is IDisposable)
                        {
                            (item as IDisposable).Dispose();
                        }
                    }
                }
            }

            System.GC.SuppressFinalize(sender);
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }
    }
}