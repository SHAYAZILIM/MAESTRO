using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraVerticalGrid;

namespace AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement
{
    public static class ManageMemory
    {
        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

        public static void ReduceMemory()
        {
            GC.Collect();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }
    }

    public static class ObjectDisposing
    {
        public static void DisposeAllChild(Control parent)
        {
            for (int i = 0; i < parent.Controls.Count; i++)
            {
                // if (parent.Controls[i].Controls.Count > 0)
                //  {
                DisposeAllChild(parent.Controls[i]);
                // }
                //  else
                //  {
                //DisposeAllChild(parent.Controls[i]);
                //  }
                //  DisposeDataSources(parent.Controls[i]);
                // parent.Controls[i].Dispose();
                //   parent.Controls.Clear();
            }

            if (parent is GridControl)
            {
                GridControl gc = (parent as GridControl);
                for (int gv = 0; gv < gc.Views.Count; gv++)
                {
                    if (gc.Views[gv] is DevExpress.XtraGrid.Views.Grid.GridView)
                    {
                        DevExpress.XtraGrid.Columns.GridColumnCollection columns =
                            (gc.Views[gv] as DevExpress.XtraGrid.Views.Grid.GridView).Columns;

                        for (int c = 0; c < columns.Count; c++)
                        {
                            if (columns[c].ColumnEdit != null)
                            {
                                if (columns[c].ColumnEdit is RepositoryItemLookUpEdit)
                                {
                                    //RepositoryItemLookUpEdit rlue = (columns[c].ColumnEdit as RepositoryItemLookUpEdit);
                                    //if (rlue.DataSource is IBindingList)
                                    //{
                                    //    IBindingList list = (rlue.DataSource as IBindingList);
                                    //    list.Clear();
                                    //    list = null;
                                    //}
                                }
                            }

                            columns[c].Dispose();
                        }
                    }
                }
            }

            //System.Reflection.PropertyInfo[] props = parent.GetType().GetProperties();

            //for (int i = 0; i < props.Length; i++)
            //{
            //    try
            //    {
            //    object PropValue = props[i].GetValue(parent, null);
            //    if (PropValue != null)
            //    {
            //        if (PropValue is IDisposable)
            //        {
            //            (PropValue as IDisposable).Dispose();
            //        }
            //    }
            //    }
            //    catch (Exception)
            //    {
            //    }

            //}

            //DisposeDataSources(parent);

            if ((parent is IDisposable) && !(parent is ToolStripContentPanel) && !(parent is ToolStripPanel) &&
                !(parent is ToolStripMenuItem) && !(parent is MenuStrip) &&
                !(parent is DevExpress.XtraVerticalGrid.VGridControl))
            {
                try
                {
                    if (!parent.IsDisposed)
                        parent.Dispose();
                }
                catch
                {
                }
            }
        }

        public static void DisposeDataSources(Control Cont)
        {
            if (Cont is VGridControl)
            {
                if ((Cont as VGridControl).DataSource is IBindingList)
                {
                    ((Cont as VGridControl).DataSource as IBindingList).Clear();
                }
                (Cont as VGridControl).DataSource = null;
            }

            if (Cont is GridControl)
            {
                if ((Cont as GridControl).DataSource is IBindingList)
                {
                    ((Cont as GridControl).DataSource as IBindingList).Clear();
                }

                #region <CC-20090707>

                //hata mesajý veriyordu null kontrolü yapýldý
                if ((Cont as GridControl).DataSource != null)
                {
                    try
                    {
                        (Cont as GridControl).DataSource = null;
                    }
                    catch
                    {
                    }
                }

                #endregion </CC-20090707>
            }

            if (Cont is DevExpress.XtraEditors.LookUpEdit)
            {
                //if ((Cont as DevExpress.XtraEditors.LookUpEdit).Properties.DataSource is IBindingList)
                //{
                //    ((Cont as DevExpress.XtraEditors.LookUpEdit).Properties.DataSource as IBindingList).Clear();
                //}
                //(Cont as DevExpress.XtraEditors.LookUpEdit).Properties.DataSource = null;
            }
        }

        public static void DisposeObject(object obj)
        {
            obj = null;
            ManageMemory.ReduceMemory();
        }
    }
}