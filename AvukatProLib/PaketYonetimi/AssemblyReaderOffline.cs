using AvukatProLib.AVPLicence;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraNavBar;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace AvukatProLib.PaketYonetimi
{
    public static class FormReaderHelper
    {
        private static Crc32 _Crc32Item;
        private static string _CrcCode = "";

        private static List<PaketBilgisi> _Packets = null;

        public static Crc32 Crc32Item
        {
            get
            {
                if (_Crc32Item == null)
                    _Crc32Item = new Crc32();
                return _Crc32Item;
            }
        }

        public static string FileName
        {
            get
            {
                return Path.Combine(Application.StartupPath, "packet.bin");
            }
        }

        public static List<PaketBilgisi> Packets
        {
            get
            {
                try
                {
                    string crc = "";
                    using (FileStream fs = File.Open(FileName, FileMode.Open))
                        foreach (byte b in Crc32Item.ComputeHash(fs)) crc += b.ToString("x2").ToLower();
                    if (_Packets == null || CrcCode != crc)
                    {
                        FileStream stream = File.Open(FileName, FileMode.Open);
                        AES aes = new AES();
                        byte[] b = new byte[stream.Length];
                        stream.Read(b, 0, b.Length);
                        var arry = aes.Decrypt(b);
                        Stream streamm = new MemoryStream(arry);
                        BinaryFormatter bFormatter = new BinaryFormatter();
                        _Packets = (List<PaketBilgisi>)bFormatter.Deserialize(streamm);
                        stream.Close();
                        b = null;
                        arry = null;
                        aes = null;
                        _CrcCode = "";
                    }
                }
                catch { ;}
                return _Packets;
            }
        }

        internal static string CrcCode
        {
            get
            {
                if (string.IsNullOrEmpty(_CrcCode))
                {
                    using (FileStream fs = File.Open(FileName, FileMode.Open))
                        foreach (byte b in Crc32Item.ComputeHash(fs)) _CrcCode += b.ToString("x2").ToLower();
                }
                return _CrcCode;
            }
        }

        public static void SavePackets(List<PaketBilgisi> objectToSerialize)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(ms, objectToSerialize);

            AES aes = new AES();
            var arry = aes.Encrypt(ms.ToArray());

            FileStream stream = File.Open(FileName, FileMode.Create);
            stream.Write(arry, 0, arry.Length);
            stream.Close();
            ms.Close();
            aes = null;
            arry = null;
        }
    }

    public class FormReaderOffline
    {
        public FormReaderOffline()
        {
            Initialize();
        }

        public FormReaderOffline(Form frm)
        {
            Initialize();
        }

        public FormReaderOffline(UserControl control)
        {
            Initialize();
        }

        public FormReaderOffline(bool addToAllPacks)
        {
            this.addToAllPacks = addToAllPacks;
        }

        public Assembly assembly = null;
        public List<ControlItem> cloneList = new List<ControlItem>();
        public Dictionary<string, object> Controls = null;
        public string MainNamespace = String.Empty;
        public Dictionary<string, Dictionary<string, List<ControlItem>>> packItems = null;

        // Form Adı-Paket Id-Kontrol Listesi
        private Form activeForm = null;

        private UserControl activeUserControl = null;
        private bool addToAllPacks = true;
        private List<PaketBilgisi> packList = null;

        public static IComponent GetControlByName(string Name, object ParentControl)
        {
            System.Reflection.FieldInfo info = ParentControl.GetType().GetField(Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.IgnoreCase);
            if (info == null)
            {
                //foreach (var v in ParentControl.GetType().GetFields().Where(v => v.FieldType.BaseType != null && (v.FieldType.BaseType.Name == "AvpXUserControl" || v.FieldType.BaseType.Name == "UserControl" || v.FieldType.BaseType.Name == "XtraTabControl")))
                //    return GetControlByName(Name, v);

                return null;
            }
            else
            {
                return (IComponent)info.GetValue(ParentControl);
            }
        }

        public static IComponent GetControlByPath(string relativePath, object ParentControl)
        {
            if (String.IsNullOrEmpty(relativePath)) return null;
            if (relativePath.StartsWith(".")) relativePath = relativePath.Remove(0, 1);
            string[] pathList = relativePath.Split('.');
            var control = GetControlByName(pathList[0], ParentControl);
            if (control == null) return null;
            if (pathList.Length == 1) return control;
            return GetControlByPath(relativePath.Substring(pathList[0].Length), control);
        }

        public void Analyze()
        {
            Module[] modules = assembly.GetModules();
            Type[] typeList = assembly.GetTypes();
            foreach (Type type in typeList)
            {
                if (IsFormOrControl(type))
                {
                }
            }
        }

        public void AnalyzeAllForms(Form frm)
        {
            if (frm.MdiParent != null)
                AnalyzeSelectedForm(frm.MdiParent);
            AnalyzeSelectedForm(frm);
        }

        public void AnalyzeSelectedForm(Form frm)
        {
            if (cloneList == null) cloneList = new List<ControlItem>();
            cloneList.Clear();
            activeForm = frm;
            if (addToAllPacks && !packItems.ContainsKey(frm.GetType().FullName))
            {
                packItems.Add(frm.GetType().FullName, new Dictionary<string, List<ControlItem>>());

                foreach (PaketBilgisi paket in packList)
                {
                    if (!packItems[frm.GetType().FullName].ContainsKey(paket.PaketAdi))
                        packItems[frm.GetType().FullName].Add(paket.PaketAdi, new List<ControlItem>());
                }
            }

            ControlItem item = AddItemToList(frm, new ControlItem { Parent = new ControlItem { Id = 0 } });
            GetPopupMenus(frm, item);

            foreach (Control ctrl in frm.Controls)
            {
                //if (ctrl is Form) AnalyzeSelectedForm(ctrl as Form);
                //else if (ctrl is MdiClient)
                //{
                //    foreach (Form form in (ctrl as MdiClient).MdiChildren)
                //        AnalyzeSelectedForm(form);
                //}

                if (ctrl is Form || ctrl is MdiClient)
                {
                    continue;
                }
                else if (ctrl.Parent.GetType() == frm.GetType())
                {
                    GetControlItems(ctrl, item, false);
                }
            }
            var listt = (from itm in cloneList where itm.Name == "xtraTabControl2" select item).ToList();

            if (addToAllPacks)
            {
                var list = packItems[frm.GetType().FullName];
                List<string> packIdList = list.Keys.ToList();
                string packName = "";
                foreach (string packId in packIdList)
                {
                    packName = packList.Where(packItem => packItem.PaketAdi == packId).Single().PaketAdi;
                    list[packId] = CloneList(cloneList, packName);
                }
            }
            else
            {
            }
        }

        public void AnalyzeSelectedUserControl(UserControl userControl)
        {
            if (cloneList == null) cloneList = new List<ControlItem>();
            cloneList.Clear();
            activeUserControl = userControl;
            if (addToAllPacks)
            {
                packItems.Add(userControl.Name, new Dictionary<string, List<ControlItem>>());

                foreach (PaketBilgisi paket in packList)
                {
                    packItems[userControl.Name].Add(paket.PaketAdi, new List<ControlItem>());
                }
            }

            ControlItem item = AddItemToList(userControl, new ControlItem { Parent = new ControlItem { Id = 0 } });
            GetPopupMenus(userControl, item);

            foreach (Control ctrl in userControl.Controls)
            {
                //if (ctrl is Form) AnalyzeSelectedForm(ctrl as Form);
                //else if (ctrl is MdiClient)
                //{
                //    foreach (Form form in (ctrl as MdiClient).MdiChildren)
                //        AnalyzeSelectedForm(form);
                //}

                if (ctrl is Form || ctrl is MdiClient)
                {
                    continue;
                }
                else if (ctrl.Parent.GetType() == userControl.GetType())
                {
                    GetControlItems(ctrl, item, false);
                }
            }
            var listt = (from itm in cloneList where itm.Name == "xtraTabControl2" select item).ToList();

            if (addToAllPacks)
            {
                var list = packItems[userControl.Name];
                List<string> packIdList = list.Keys.ToList();
                string packName = "";
                foreach (string packId in packIdList)
                {
                    packName = packList.Where(packItem => packItem.PaketAdi == packId).Single().PaketAdi;
                    list[packId] = CloneList(cloneList, packName);
                }
            }
            else
            {
            }
        }

        public void GetControlItems(IComponent ctrl)
        {
            cloneList.Clear();
            ControlItem ctrlItem = new ControlItem();
            ctrlItem.Control = ctrl;
            ctrlItem.Parent = null;
            ctrlItem.ItemType = ctrl.GetType();
            ctrlItem.ShowInBasket = ctrlItem.ShowInAccessList = true;
            ctrlItem.Show = ctrlItem.Visible;
            ctrlItem.Active = ctrlItem.Enabled;
            ctrlItem.ShowInAccessList = true;
            if (activeForm != null)
            {
                ctrlItem.FormName = activeForm.Name;
                ctrlItem.FormFullName = activeForm.GetType().FullName;
            }
            ctrlItem.FullPath = GetFullPath(ctrl);
            cloneList.Add(ctrlItem);
            if (ctrl is GridControl)
            {
                GetGridViews((ctrl as GridControl), ctrlItem);
            }
            foreach (Control subCtrl in (ctrl as Control).Controls)
            {
                GetControlItems(subCtrl, ctrlItem, true);
            }
        }

        protected List<T> GetAllControls<T>(Control control) where T : Control
        {
            List<T> controls = new List<T>();
            foreach (Control child in control.Controls)
            {
                T specificControl = child as T;
                if (specificControl != null) controls.Add(specificControl);

                if (child.HasChildren) controls.AddRange(GetAllControls<T>(child));
            }
            return controls;
        }

        private ControlItem AddItemToList(object control, ControlItem parentItem)
        {
            ControlItem ctrlItem = new ControlItem();
            ctrlItem.Control = control;
            ctrlItem.Parent = parentItem;
            ctrlItem.ItemType = control.GetType();
            ctrlItem.ShowInBasket = ctrlItem.ShowInAccessList = true;
            ctrlItem.Show = ctrlItem.Visible;
            ctrlItem.Active = ctrlItem.Enabled;
            ctrlItem.ShowInAccessList = true;
            if (control is UserControl)
            {
                if (ctrlItem.Parent == null || String.IsNullOrEmpty(ctrlItem.Parent.RelativePath)) ctrlItem.RelativePath = ctrlItem.Name;
                else ctrlItem.RelativePath = String.Format("{0}.{1}", parentItem.RelativePath, ctrlItem.Name);
            }
            else if (ctrlItem.Parent != null && !String.IsNullOrEmpty(ctrlItem.Parent.RelativePath)) ctrlItem.RelativePath = ctrlItem.Parent.RelativePath;
            if (activeForm != null)
            {
                ctrlItem.FormName = activeForm.Name;
                ctrlItem.FormFullName = activeForm.GetType().FullName;
            }
            cloneList.Add(ctrlItem);
            ctrlItem.Index = cloneList.Count - 1;
            if (ctrlItem.Parent == null || String.IsNullOrEmpty(ctrlItem.Parent.FullPath)) ctrlItem.FullPath = ctrlItem.Name;
            else ctrlItem.FullPath = String.Format("{0}.{1}", parentItem.FullPath, ctrlItem.Name);
            return ctrlItem;
        }

        private List<ControlItem> CloneList(List<ControlItem> list, string packName)
        {
            List<ControlItem> objResult = new List<ControlItem>(from item in list select (ControlItem)item.Clone());
            foreach (ControlItem item in objResult)
            {
                if (String.IsNullOrEmpty(item.Name) || item.Parent == null || (item.Parent != null && String.IsNullOrEmpty(item.Parent.Name))) continue;
                item.Parent = objResult[item.Parent.Index];
                item.PackName = packName;
                if (item.Parent != null) item.Parent.PackName = packName;
            }
            return objResult;
        }

        private ControlItem GetBarItemLinks(object itemLinks, ControlItem parentItem)
        {
            ControlItem item2 = null;
            foreach (var subItem in itemLinks as BarItemLinkCollection)
            {
                if (subItem is BarSubItemLink)
                {
                    BarSubItemLink link = subItem as BarSubItemLink;
                    if (!String.IsNullOrEmpty(link.Item.Name)) item2 = AddItemToList(link.Item, parentItem);
                    GetBarItemLinks(link.Item.ItemLinks, item2 ?? parentItem);
                }
                else if (subItem is BarItemLink)
                {
                    BarItemLink link = subItem as BarItemLink;
                    if (!String.IsNullOrEmpty(link.Item.Name)) item2 = AddItemToList(link.Item, parentItem);
                }
                else
                {
                    BarItem barItem2 = subItem as BarItem;
                    if (!String.IsNullOrEmpty(barItem2.Name)) item2 = AddItemToList(barItem2, parentItem);
                    foreach (BarItem linkSubItem in barItem2.Links)
                    {
                        if (!String.IsNullOrEmpty(linkSubItem.Name))
                            GetBarItemLinks(linkSubItem, item2 ?? parentItem);
                    }
                }
            }
            return item2;
        }

        private void GetBarItemLinks(BarItem barItem, ControlItem parentItem)
        {
            ControlItem item = null;
            ControlItem item2 = null;
            if (!String.IsNullOrEmpty(barItem.Name)) item = AddItemToList(barItem, parentItem);

            foreach (var subItem in barItem.Links)
            {
                if (subItem is BarItemLink)
                {
                    BarItemLink link = subItem as BarItemLink;
                    item2 = AddItemToList(link, item ?? parentItem);

                    //foreach (BarItemLink linkSubItem in link.Links)
                    //{
                    //    GetBarItemLinks(linkSubItem, item2 ?? (item ?? parentItem));
                    //}
                }
                else
                {
                    BarItem barItem2 = subItem as BarItem;
                    item2 = AddItemToList(barItem2, item ?? parentItem);
                    foreach (BarItem linkSubItem in barItem2.Links)
                    {
                        if (!String.IsNullOrEmpty(linkSubItem.Name))
                            GetBarItemLinks(linkSubItem, item2 ?? (item ?? parentItem));
                    }
                }
            }
        }

        private void GetBarItems(Bar bar, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(bar.BarName)) item = AddItemToList(bar, parentItem);

            //GetBarItemLinks(bar.ItemLinks, item ?? parentItem);

            foreach (BarItemLink subItem in bar.ItemLinks as BarItemLinkCollection)
            {
                GetBarItemLinks(subItem.Item.Links, item ?? parentItem);
            }
        }

        private void GetContainerControlItems(ContainerControl containerControl, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(containerControl.Name)) item = AddItemToList(containerControl, parentItem);
            if (containerControl is ToolStripPanel)
            {
                if ((containerControl as ToolStripPanel).ContextMenu != null)
                    GetMenuControls((containerControl as ToolStripPanel).ContextMenu, item ?? parentItem);
                if ((containerControl as ToolStripPanel).ContextMenuStrip != null)
                    GetToolStripControls((containerControl as ToolStripPanel).ContextMenuStrip, item ?? parentItem);
            }
            else
            {
                foreach (Control ctrl in containerControl.Controls)
                    GetControlItems(ctrl, item ?? parentItem, true);
            }
        }

        private void GetContainerGroups(LayoutItemContainer layoutItemContainer, ControlItem parentItem)
        {
            if (layoutItemContainer is LayoutGroup) GetLayoutGroupItems((layoutItemContainer as LayoutGroup), parentItem);
            else if (layoutItemContainer is TabbedGroup) GetTabbedGroupItems((layoutItemContainer as TabbedGroup), parentItem);
        }

        private void GetControlItems(IComponent ctrl, ControlItem parentItem, bool innerControl)
        {
            if (ctrl == null || ((ctrl is LayoutControlGroup || ctrl is LayoutControlItem) && !innerControl)) return;
            if (ctrl is LayoutControl)
            {
                GetLayoutControlItems((ctrl as LayoutControl), parentItem);
            }
            else if (ctrl is LayoutItemContainer)
            {
                GetContainerGroups((ctrl as LayoutItemContainer), parentItem);
            }
            else if (ctrl is GridControl)
            {
                GetGridViews((ctrl as GridControl), parentItem);
            }
            else if (ctrl is VGridControl)
            {
                GetVGridControls((ctrl as VGridControl), parentItem);
            }
            else if (ctrl is NavigatorBase)
            {
                GetNavigatorControls((ctrl as NavigatorBase), parentItem);
            }
            else if (ctrl is ToolStripPanel)
            {
                GetToolStripPanelControls((ctrl as ToolStripPanel), parentItem);
            }
            else if (ctrl is ToolStrip)
            {
                GetToolStripControls((ctrl as ToolStrip), parentItem);
            }
            else if (ctrl is NavBarControl)
            {
                GetNavBarControlItems((ctrl as NavBarControl), parentItem);
            }
            else if (ctrl is PopupMenu)
            {
                GetPopupMenuItems((ctrl as PopupMenu), parentItem);
            }
            else if (ctrl is ContainerControl)
            {
                GetContainerControlItems((ctrl as ContainerControl), parentItem);
            }
            else if (ctrl is PopupContainerEdit)
            {
                GetPopupContainerEditControls((ctrl as PopupContainerEdit), parentItem);
            }
            else if (ctrl is TreeList)
            {
                GetTreeListItems((ctrl as TreeList), parentItem);
            }
            else if (ctrl is SchedulerControl)
            {
                GetSchedulerControlItems((ctrl as SchedulerControl), parentItem);
            }
            else if (ctrl is ViewSelectorBar)
            {
                GetViewSelectorBarControls((ctrl as ViewSelectorBar), parentItem);
            }
            else if (ctrl is ViewNavigatorBar)
            {
                GetViewNavigatorBarControls((ctrl as ViewNavigatorBar), parentItem);
            }
            else if (ctrl is Bar)
            {
                GetBarItems((ctrl as Bar), parentItem);
            }
            else if (ctrl is DockedBarControl)
            {
                GetDockedBarControlItems((ctrl as DockedBarControl), parentItem);
            }
            else
            {
                Control mainControl = ctrl as Control;

                ControlItem ctrlItem = null;
                if (!String.IsNullOrEmpty(mainControl.Name.Trim()))
                {
                    ctrlItem = AddItemToList(mainControl, parentItem);
                }
                foreach (Control child in mainControl.Controls)
                {
                    if (ctrlItem != null)
                        GetControlItems(child, ctrlItem, true);
                    else GetControlItems(child, parentItem, true);
                }
            }
        }

        private void GetDockedBarControlItems(DockedBarControl dockedBarControl, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(dockedBarControl.Name)) item = AddItemToList(dockedBarControl, parentItem);
            if (dockedBarControl.Bar != null)
            {
                GetBarItems(dockedBarControl.Bar, item ?? parentItem);
            }
        }

        private string GetFullPath(IComponent ctrl)
        {
            if (ctrl is Form) return (ctrl as Form).Name;
            if (ctrl is Control)
            {
                if ((ctrl as Control).Parent != null)
                {
                    if ((ctrl as Control).Name == "" || ctrl is DevExpress.XtraBars.Docking.AutoHideContainer) return GetFullPath((ctrl as Control).Parent);

                    //   object name = GetPropertyValue(ctrl, "PackControlName");
                    return String.Format("{0}.{1}", GetFullPath((ctrl as Control).Parent), /*name != null ? name.ToString() : */(ctrl as Control).Name);
                }
            }
            return "";
        }

        private void GetGridColumns(ColumnView view, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(view.Name)) item = AddItemToList(view, parentItem);
            foreach (GridColumn column in view.Columns)
            {
                if (!String.IsNullOrEmpty(column.Name)) AddItemToList(column, item ?? parentItem);
            }
        }

        private void GetGridViews(GridControl gridControl, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(gridControl.Name)) item = AddItemToList(gridControl, parentItem);
            if (gridControl.EmbeddedNavigator != null)
            {
                GetNavigatorButtons(gridControl.EmbeddedNavigator.Buttons.ButtonCollection, item ?? parentItem);
                GetNavigatorCustomButtons(gridControl.EmbeddedNavigator.Buttons.CustomButtons, item ?? parentItem);
            }
            foreach (ColumnView view in gridControl.Views)
            {
                GetGridColumns(view, item ?? parentItem);
            }
        }

        private void GetLayoutControlGroupItems(LayoutControlGroup group, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(group.Name)) item = AddItemToList(group, parentItem);
            foreach (BaseLayoutItem groupItem in group.Items)
            {
                if (groupItem is LayoutControlGroup)
                    GetLayoutControlGroupItems(groupItem as LayoutControlGroup, item ?? parentItem);
                else if (groupItem is TabbedControlGroup)
                    GetTabbedControlGroupItems(groupItem as TabbedControlGroup, item ?? parentItem);
                else if (groupItem is LayoutControlItem)
                    GetLayoutControlItems((groupItem as LayoutControlItem), item ?? parentItem);
                else GetControlItems(groupItem, item ?? parentItem, true);
            }
        }

        private void GetLayoutControlItems(LayoutControl control, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(control.Name)) item = AddItemToList(control, parentItem);
            if (control.HasChildren)
            {
                object rootItem = control.Items.FindByName("Root");
                if (rootItem != null && rootItem is LayoutControlGroup)
                {
                    GetLayoutControlGroupItems((rootItem as LayoutControlGroup), item ?? parentItem);
                    return;
                }
                if (control.Root != null)
                {
                    GetLayoutControlGroupItems((control.Root as LayoutControlGroup), item ?? parentItem);
                }
            }
        }

        private void GetLayoutControlItems(LayoutControlItem layoutControlItem, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(layoutControlItem.Name)) item = AddItemToList(layoutControlItem, parentItem);
            GetControlItems(layoutControlItem.Control, item ?? parentItem, true);
        }

        private void GetLayoutGroupItems(LayoutGroup group, ControlItem parentItem)
        {
            if (group is LayoutControlGroup) GetLayoutControlGroupItems((group as LayoutControlGroup), parentItem);
            else GetControlItems(group, parentItem, true);
        }

        private void GetMenuControls(Menu contextMenuStrip, ControlItem parentItem)
        {
            ControlItem item = null;
            ControlItem item2 = null;
            if (!String.IsNullOrEmpty(contextMenuStrip.Name)) item = AddItemToList(contextMenuStrip, parentItem);
            foreach (MenuItem menuItem in contextMenuStrip.MenuItems)
            {
                item2 = AddItemToList(menuItem, item ?? parentItem);
                GetSubMenuItems(menuItem, item2 ?? (item ?? parentItem));
            }
        }

        private void GetNavBarControlItems(NavBarControl navBarControl, ControlItem parentItem)
        {
            ControlItem item = null;
            ControlItem item2 = null;

            if (!String.IsNullOrEmpty(navBarControl.Name)) item = AddItemToList(navBarControl, parentItem);
            foreach (NavBarGroup group in navBarControl.Groups)
            {
                if (group.ControlContainer != null)
                {
                    GetControlItems(group.ControlContainer, item ?? parentItem, true);
                    continue;
                }
                item2 = AddItemToList(group, item ?? parentItem);
                foreach (NavBarItemLink barItem in group.ItemLinks)
                {
                    if (barItem.Item != null)
                        AddItemToList(barItem.Item, item2 ?? (item ?? parentItem));
                }
            }
        }

        private void GetNavigatorButtons(NavigatorButtonCollectionBase buttonCollection, ControlItem parentItem)
        {
            foreach (NavigatorButton button in buttonCollection)
            {
                if (!String.IsNullOrEmpty((string)GetPropertyValue(button, "Name"))) AddItemToList(button, parentItem);
            }
        }

        private void GetNavigatorControls(NavigatorBase navigator, ControlItem parentItem)
        {
            if (navigator is DataNavigator)
            {
                DataNavigator dataNavigator = navigator as DataNavigator;
                GetNavigatorButtons(dataNavigator.Buttons.ButtonCollection, parentItem);
                GetNavigatorCustomButtons(dataNavigator.Buttons.CustomButtons, parentItem);
            }
            else if (navigator is ControlNavigator)
            {
                ControlNavigator controlNavigator = navigator as ControlNavigator;
                GetNavigatorButtons(controlNavigator.Buttons.ButtonCollection, parentItem);
                GetNavigatorCustomButtons(controlNavigator.Buttons.CustomButtons, parentItem);
            }
        }

        private void GetNavigatorCustomButtons(NavigatorCustomButtons buttonCollection, ControlItem parentItem)
        {
            foreach (NavigatorCustomButton button in buttonCollection)
            {
                if (!String.IsNullOrEmpty((string)GetPropertyValue(button, "Name"))) AddItemToList(button, parentItem);
            }
        }

        private void GetPopupContainerControlItems(PopupContainerControl popupContainerControl, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(popupContainerControl.Name)) item = AddItemToList(popupContainerControl, parentItem);
            foreach (Control ctrl in popupContainerControl.Controls)
            {
                GetControlItems(ctrl, item ?? parentItem, true);
            }
        }

        private void GetPopupContainerEditControls(PopupContainerEdit popupContainerEdit, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(popupContainerEdit.Name)) item = AddItemToList(popupContainerEdit, parentItem);
            if (popupContainerEdit.Properties.PopupControl != null)
            {
                GetPopupContainerControlItems(popupContainerEdit.Properties.PopupControl, item ?? parentItem);
            }
        }

        private void GetPopupMenuItems(PopupMenu popupMenu, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(popupMenu.Name)) item = AddItemToList(popupMenu, parentItem);
            if (popupMenu.Manager != null)
            {
                foreach (BarItem barItem in popupMenu.Manager.Items)
                {
                    GetBarItemLinks(barItem, item ?? parentItem);
                }
            }
            foreach (BarItem barItem in popupMenu.ItemLinks)
            {
                GetBarItemLinks(barItem, item ?? parentItem);
            }
        }

        private void GetPopupMenus(Form frm, ControlItem parentItem)
        {
            FieldInfo[] fields = frm.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo info in fields)
            {
                if (info.FieldType == typeof(PopupMenu))
                {
                    GetPopupMenuItems(info.GetValue(frm) as PopupMenu, parentItem);
                }
                else if (info.FieldType.Name.Contains("ExtendedGridControl"))
                {
                    object value = info.GetValue(frm);
                    if (value == null) continue;
                    object prop = value.GetType().GetProperty("RightClickPopup", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(value, null);
                    PopupMenu menu = prop.GetType().GetProperty("MyPopup", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(prop, null) as PopupMenu;
                    GetPopupMenuItems(menu, parentItem);
                }
            }
        }

        private void GetPopupMenus(UserControl userControl, ControlItem parentItem)
        {
            FieldInfo[] fields = userControl.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo info in fields)
            {
                if (info.FieldType == typeof(PopupMenu))
                {
                    GetPopupMenuItems(info.GetValue(userControl) as PopupMenu, parentItem);
                }
                else if (info.FieldType.Name.Contains("ExtendedGridControl"))
                {
                    object value = info.GetValue(userControl);
                    if (value == null) continue;
                    object prop = value.GetType().GetProperty("RightClickPopup", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(value, null);
                    PopupMenu menu = prop.GetType().GetProperty("MyPopup", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(prop, null) as PopupMenu;
                    GetPopupMenuItems(menu, parentItem);
                }
            }
        }

        private object GetPropertyValue(object item, string propertyName)
        {
            try
            {
                return item.GetType().GetProperty(propertyName).GetValue(item, null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void GetSchedulerControlItems(SchedulerControl schedulerControl, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(schedulerControl.Name)) item = AddItemToList(schedulerControl, parentItem);
            foreach (Control ctrl in schedulerControl.Controls)
            {
                GetControlItems(ctrl, item ?? parentItem, true);
            }

            //for (int i = 0; i < schedulerControl.Views.Count; i++ )
            //{
            //    GetSchedulerViewItems(schedulerControl.Views[i], item ?? parentItem);
            //}
        }

        private void GetSubMenuItems(MenuItem menuItem, ControlItem parentItem)
        {
            ControlItem item = null;
            foreach (MenuItem childItem in menuItem.MenuItems)
            {
                if (!String.IsNullOrEmpty(childItem.Name)) item = AddItemToList(childItem, parentItem);
                GetSubMenuItems(childItem, item ?? parentItem);
            }
        }

        private void GetTabbedControlGroupItems(TabbedControlGroup group, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(group.Name)) item = AddItemToList(group, parentItem);
            foreach (LayoutGroup tabPage in group.TabPages)
            {
                GetLayoutGroupItems(tabPage, item ?? parentItem);
            }
        }

        private void GetTabbedGroupItems(TabbedGroup group, ControlItem parentItem)
        {
            if (group is TabbedControlGroup) GetTabbedControlGroupItems((group as TabbedControlGroup), parentItem);
            else GetControlItems(group, parentItem, true);
        }

        private void GetToolStripControls(ToolStrip toolStrip, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(toolStrip.Name)) item = AddItemToList(toolStrip, parentItem);
            foreach (ToolStripItem toolStripItem in toolStrip.Items)
            {
                GetToolStripMenuItems(toolStripItem, item ?? parentItem);
            }
        }

        private void GetToolStripMenuItems(ToolStripItem toolStripItem, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(toolStripItem.Name)) item = AddItemToList(toolStripItem, parentItem);
            if (toolStripItem is ToolStripMenuItem)
            {
                foreach (ToolStripItem child in (toolStripItem as ToolStripMenuItem).DropDownItems)
                {
                    GetToolStripMenuItems(child, item ?? parentItem);
                }
            }
        }

        private void GetToolStripPanelControls(ToolStripPanel toolStripPanel, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(toolStripPanel.Name)) item = AddItemToList(toolStripPanel, parentItem);
            foreach (Control ctrl in toolStripPanel.Controls)
            {
                GetControlItems(ctrl, item ?? parentItem, true);
            }
        }

        private void GetTreeListItems(TreeList treeList, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(treeList.Name)) item = AddItemToList(treeList, parentItem);
            foreach (TreeListColumn column in treeList.Columns)
            {
                AddItemToList(column, item ?? parentItem);
            }
        }

        private void GetVGridControls(VGridControl gridControl, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(gridControl.Name)) item = AddItemToList(gridControl, parentItem);
            foreach (BaseRow row in gridControl.Rows)
            {
                GetVGridRows(row, item ?? parentItem);
            }
        }

        private void GetVGridRows(BaseRow editorRow, ControlItem parentItem)
        {
            ControlItem item = null;
            if (!String.IsNullOrEmpty(editorRow.Name)) item = AddItemToList(editorRow, parentItem);
            if (editorRow.HasChildren)
                foreach (BaseRow child in editorRow.ChildRows)
                    GetVGridRows(child, item ?? parentItem);
        }

        private void GetViewNavigatorBarControls(ViewNavigatorBar viewNavigatorBar, ControlItem parentItem)
        {
        }

        private void GetViewSelectorBarControls(ViewSelectorBar viewSelectorBar, ControlItem parentItem)
        {
        }

        private void Initialize()
        {
            packList = FormReaderHelper.Packets;
            packItems = new Dictionary<string, Dictionary<string, List<ControlItem>>>();
        }

        private bool IsFormOrControl(Type type)
        {
            if (type.BaseType == typeof(Control) || type.BaseType == typeof(Form))
                return true;
            else if (type.BaseType != null)
                return IsFormOrControl(type.BaseType);
            return false;
        }
    }
}