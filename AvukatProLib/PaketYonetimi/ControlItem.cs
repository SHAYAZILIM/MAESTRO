using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace AvukatProLib.PaketYonetimi
{
    [Serializable]
    public class ControlItem : ICloneable, IEquatable<CS_KOD_KONTROL_LISTESI>
    {
        private static int id = 1;

        private bool parentVisible = true;

        public string AccessModifier { get; set; }

        public object Control { get; set; }

        public CS_KOD_KONTROL_LISTESI csControl { get; set; }

        public CS_KOD_KONTROL_OZELLIKLERI csControlProperties { get; set; }

        public CS_KOD_FORM_LISTESI csForm { get; set; }

        public bool Enabled
        {
            get
            {
                if (Control is LayoutControlItem) return true;
                else if (Control is LayoutControlGroup) return (Control as LayoutControlGroup).Enabled;
                else if (Control is ColumnView) return true;
                else if (Control is GridColumn) return true;
                else if (Control is BaseRow) return true;
                else if (Control is NavigatorButtonBase) return (Control as NavigatorButtonBase).Enabled;
                else if (Control is ToolStripItem) return (Control as ToolStripItem).Enabled;
                else if (Control is NavBarGroup) return true;
                else if (Control is NavBarItem) return (Control as NavBarItem).Enabled;
                else if (Control is NavBarItemLink) return (Control as NavBarItemLink).Enabled;
                else if (Control is PopupMenu) return true;
                else if (Control is BarItem) return (Control as BarItem).Enabled;
                else if (Control is Menu) return true;
                else if (Control is MenuItem) return (Control as MenuItem).Enabled;
                else if (Control is TreeListColumn) return true;
                else if (Control is XtraTabPage) return (Control as XtraTabPage).PageEnabled;
                else if (Control is Control) return (Control as Control).Enabled;
                else
                {
                    object retval = GetPropertyValue(Control, "Enabled");
                    if (retval == null) return false;
                    return Convert.ToBoolean(retval);
                }
            }
            set
            {
                if (Control != null)
                {
                    SetProperty(Control, "PageEnabled,Enabled", value);
                }
            }
        }

        public Explanation expl
        {
            get;
            set;
        }

        public string Explanation
        {
            get
            {
                if (String.IsNullOrEmpty(expl.ExplanationText))
                {
                    Explanation = Text;
                }
                return expl.ExplanationText;
            }
            set
            {
                expl.ExplanationText = value;
                if (csControl != null) csControl.KONTROL_ACIKLAMA = value;
            }
        }

        public string FormFullName { get; set; }

        public string FormName { get; set; }

        public string FullPath { get; set; }

        public int Id { get; set; }

        public int ImageIndex { get; set; }

        public Type ItemType { get; set; }

        public string Name
        {
            get
            {
                if (Control != null)
                {
                    object name = GetPropertyValue(Control, "Name,DisplayName,BarName,GalleryBarItemName");
                    return name == null ? "" : name.ToString();
                }
                return "";
            }
            set
            {
                if (Control != null)
                    SetProperty(Control, "Name,DisplayName,BarName,GalleryBarItemName", value);
                if (csControl != null && csControl.KONTROL_ADI != value) csControl.KONTROL_ADI = value;
            }
        }

        public string PackName { get; set; }

        public ControlItem Parent { get; set; }

        public int ParentId
        {
            get
            {
                return Parent == null ? -1 : Parent.Id;
            }
        }

        #region Constructor

        public ControlItem()
        {
            expl = new Explanation();
            Id = id++;
            ImageIndex = 0;
            Explanation = "";
        }

        public ControlItem(ControlItem parent, string displayText, int imageIndex, Type itemType, string accessModifier, string text, string aciklama, bool selected, bool enabled, bool showInCustomizationForm, object control)
        {
            expl = new Explanation();
            csControl = new CS_KOD_KONTROL_LISTESI();
            csControlProperties = new CS_KOD_KONTROL_OZELLIKLERI();
            Id = id++;
            Parent = parent;
            Name = displayText;
            ImageIndex = imageIndex;
            ItemType = itemType;
            AccessModifier = accessModifier;
            Text = text;
            Visible = selected;
            Enabled = enabled;
            ShowInCustomizationForm = showInCustomizationForm;
            Explanation = aciklama;
            Control = control;
            PackName = "";
        }

        public int Index { get; set; }

        #endregion Constructor

        public bool ParentVisible
        {
            get
            {
                if (this.Parent != null) parentVisible = this.Parent.Visible;
                if (csControlProperties != null) csControlProperties.PARENT_GORUNUR_MU = parentVisible;
                return parentVisible;
            }
            set
            {
                parentVisible = value;
                if (csControlProperties != null) csControlProperties.PARENT_GORUNUR_MU = parentVisible;
            }
        }

        public string RelativePath { get; set; }

        public bool ShowInCustomizationForm
        {
            get
            {
                if (Control is GridColumn) return (Control as GridColumn).OptionsColumn.ShowInCustomizationForm;
                else if (Control is BaseRow) return (Control as BaseRow).OptionsRow.ShowInCustomizationForm;
                else return true;
            }
            set
            {
                if (Control is GridColumn) (Control as GridColumn).OptionsColumn.ShowInCustomizationForm = value;
                else if (Control is BaseRow) (Control as BaseRow).OptionsRow.ShowInCustomizationForm = value;
                else SetProperty(Control, "ShowInCustomizationForm", value);
            }
        }

        public string Text
        {
            get
            {
                if (Control != null)
                {
                    object text = GetPropertyValue(Control, "Text,Caption,MenuCaption,ViewCaption");
                    return text == null ? "" : text.ToString();
                }
                return "";
            }
            set
            {
                if (Control != null)
                    SetProperty(Control, "Text,Caption,MenuCaption,ViewCaption", value);
                if (csControl != null && csControl.KONTROL_TEXT != value) csControl.KONTROL_TEXT = value;
            }
        }

        #region CS_KOD_KONTROL_OZELLIKLERI Properties

        [DefaultValue(true)]
        public bool Active
        {
            get
            {
                if (csControlProperties != null) return Convert.ToBoolean(csControlProperties.AKTIF_MI);
                return true;
            }
            set
            {
                if (csControlProperties != null)
                {
                    if (csControlProperties.AKTIF_MI != value) csControlProperties.AKTIF_MI = value;
                }
            }
        }

        [DefaultValue(true)]
        public bool Show
        {
            get
            {
                if (csControlProperties != null) return Convert.ToBoolean(csControlProperties.GORUNUR_MU);
                return true;
            }
            set
            {
                if (csControlProperties != null)
                {
                    if (csControlProperties.GORUNUR_MU != value) csControlProperties.GORUNUR_MU = value;
                }
            }
        }

        [DefaultValue(true)]
        public bool ShowInAccessList
        {
            get
            {
                if (csControlProperties != null) return Convert.ToBoolean(csControlProperties.YETKILENDIRMEDE_KULLANILSIN_MI);
                return true;
            }
            set
            {
                if (csControlProperties != null && csControlProperties.YETKILENDIRMEDE_KULLANILSIN_MI != value) csControlProperties.YETKILENDIRMEDE_KULLANILSIN_MI = value;
            }
        }

        [DefaultValue(true)]
        public bool ShowInBasket
        {
            get
            {
                if (csControlProperties != null) return Convert.ToBoolean(csControlProperties.SEPETTE_GOSTERILSIN_MI);
                return true;
            }
            set
            {
                if (csControlProperties != null)
                {
                    if (csControlProperties.SEPETTE_GOSTERILSIN_MI != value) csControlProperties.SEPETTE_GOSTERILSIN_MI = value;
                }
            }
        }

        #endregion CS_KOD_KONTROL_OZELLIKLERI Properties

        public bool Visible
        {
            get
            {
                if (Control is BarItem) return (Control as BarItem).Visibility == BarItemVisibility.Never ? false : true;
                else if (Control is LayoutItemContainer) return (Control as LayoutItemContainer).Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never ? false : true;
                else if (Control is LayoutControlItem) return (Control as LayoutControlItem).Visible;
                else if (Control is LayoutControlGroup) return (Control as LayoutControlGroup).Visible;
                else if (Control is ColumnView) return (Control as ColumnView).IsVisible;
                else if (Control is GridColumn) return (Control as GridColumn).Visible;
                else if (Control is BaseRow) return (Control as BaseRow).Visible;
                else if (Control is NavigatorButtonBase) return (Control as NavigatorButtonBase).Visible;
                else if (Control is ToolStripItem) return (Control as ToolStripItem).Visible;
                else if (Control is NavBarGroup) return (Control as NavBarGroup).Visible;
                else if (Control is NavBarItem) return (Control as NavBarItem).Visible;
                else if (Control is NavBarItemLink) return (Control as NavBarItemLink).Visible;
                else if (Control is PopupMenu) return (Control as PopupMenu).Visible;
                else if (Control is Menu) return true;
                else if (Control is MenuItem) return (Control as MenuItem).Visible;
                else if (Control is TreeListColumn) return (Control as TreeListColumn).Visible;
                else if (Control is XtraTabPage) return (Control as XtraTabPage).PageVisible;
                else if (Control is Control) return (Control as Control).Visible;

                //if (Control is BarItem) return (Control as BarItem).Visibility == BarItemVisibility.Never ? false : true;
                //else if (Control is LayoutItemContainer) return (Control as LayoutItemContainer).Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never ? false : true;
                else
                {
                    object retval = GetPropertyValue(Control, "Visible,IsVisible,PageVisible");
                    if (retval == null) return false;
                    return Convert.ToBoolean(retval);
                }
            }
            set
            {
                if (Control != null)
                {
                    if (Control is LayoutItemContainer) (Control as LayoutItemContainer).Visibility = value == true ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    else if (Control is LayoutControlItem) (Control as LayoutControlItem).Visibility = value == true ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    else if (Control is BarItem) (Control as BarItem).Visibility = value == false ? BarItemVisibility.Never : BarItemVisibility.Always;
                    else if (Control is ColumnView) return;
                    else if (Control is GridColumn) (Control as GridColumn).Visible = value;
                    else if (Control is BaseRow) (Control as BaseRow).Visible = value;
                    else if (Control is NavigatorButtonBase) (Control as NavigatorButtonBase).Visible = value;
                    else if (Control is ToolStripItem) (Control as ToolStripItem).Visible = value;
                    else if (Control is NavBarGroup) (Control as NavBarGroup).Visible = value;
                    else if (Control is NavBarItem) (Control as NavBarItem).Visible = value;
                    else if (Control is NavBarItemLink) (Control as NavBarItemLink).Visible = value;
                    else if (Control is PopupMenu) return;
                    else if (Control is Menu) return;
                    else if (Control is MenuItem) (Control as MenuItem).Visible = value;
                    else if (Control is TreeListColumn) (Control as TreeListColumn).Visible = value;
                    else if (Control is XtraTabPage) (Control as XtraTabPage).PageVisible = value;
                    else if (Control is Control) (Control as Control).Visible = value;

                    //if (Control is LayoutItemContainer) (Control as LayoutItemContainer).Visibility = value == true ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //else if (Control is LayoutControlItem) (Control as LayoutControlItem).Visibility = value == true ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //else if (Control is BarItem) (Control as BarItem).Visibility = value == false ? BarItemVisibility.Never : BarItemVisibility.Always;
                    else
                    {
                        SetProperty(Control, "Visible,PageVisible", value);
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            return this.Name.Equals((obj as ControlItem).Name);
        }

        private object GetPropertyValue(object item, string propertyName)
        {
            try
            {
                PropertyInfo propInfo = null;
                foreach (string prop in propertyName.Split(','))
                {
                    propInfo = item.GetType().GetProperty(prop);
                    if (propInfo != null) break;
                }
                return propInfo.GetValue(item, null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void SetProperty(object item, string propertyName, object value)
        {
            try
            {
                PropertyInfo propInfo = null;
                foreach (string prop in propertyName.Split(','))
                {
                    propInfo = item.GetType().GetProperty(prop);
                    if (propInfo != null) break;
                }
                if (propInfo != null) propInfo.SetValue(item, value, null);
            }
            catch (Exception)
            {
            }
        }

        #region ICloneable Members

        public object Clone()
        {
            var item = this.MemberwiseClone() as ControlItem;

            //if (item.Parent != null) item.Parent = this.Parent.MemberwiseClone() as ControlItem;
            return item;
        }

        #endregion ICloneable Members

        #region IEquatable<ControlItem> Members

        public bool Equals(CS_KOD_KONTROL_LISTESI other)
        {
            return this.Name == other.KONTROL_ADI;
        }

        #endregion IEquatable<ControlItem> Members
    }

    [Serializable]
    public class Explanation
    {
        public string ExplanationText { get; set; }
    }
}