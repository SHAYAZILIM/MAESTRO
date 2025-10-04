using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using DevExpress.XtraVerticalGrid.Rows;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    public static class PaketControlPropertyHelper
    {
        public static void SetControlProperty(this PaketControlProperty property)
        {
            if (property.PaketId != PaketHelper.AktifPaket.PaketId)
                return;

            if (property.PaketControl == null || property.PaketControl.Control == null)
                return;
            var control = property.PaketControl.Control;

            if (control is Form)
                return;

            var groupProperty = property.GroupProperties.Where(q => q.GroupId == PaketHelper.AktifGroup.Id).FirstOrDefault();

            var aktif = property.Aktif;
            var gorunur = property.Gorunur;
            var text = string.Empty;
            var usetext = false;
            if (property.PaketControl.UseCustomCaption.HasValue && property.PaketControl.UseCustomCaption.Value)
            {
                text = property.PaketControl.CustomCaption;
                usetext = true;
            }

            if (groupProperty != null)
            {
                if (groupProperty.Aktif.HasValue && aktif.HasValue && aktif.Value)
                    aktif = groupProperty.Aktif;
                if (groupProperty.Gorunur.HasValue && gorunur.HasValue && gorunur.Value)
                    gorunur = groupProperty.Gorunur;
            }

            if (control is Form)
                return;

            if (control is LayoutControlItem)
            {
                var c = control as LayoutControlItem;
                if (c == null)
                    return;
                if (c.Control != null)
                {
                    if (aktif.HasValue)
                        c.Control.Enabled = aktif.Value;
                    if (usetext)
                        c.Text = text;
                }
                if (gorunur.HasValue)
                    c.Visibility = gorunur.Value ? LayoutVisibility.Always : LayoutVisibility.Never;
            }
            else if (control is LayoutGroup)
            {
                var c = control as LayoutGroup;
                if (c == null)
                    return;
                if (usetext)
                    c.Text = text;
                if (aktif.HasValue)
                    c.Enabled = aktif.Value;
                if (gorunur.HasValue)
                    c.Visibility = gorunur.Value ? LayoutVisibility.Always : LayoutVisibility.Never;
            }
            else if (control is BaseLayoutItem)
            {
                var c = control as BaseLayoutItem;
                if (c == null)
                    return;
                if (usetext)
                    c.Text = text;
                if (gorunur.HasValue)
                    c.Visibility = gorunur.Value ? LayoutVisibility.Always : LayoutVisibility.Never;
            }
            else if (control is GridColumn)
            {
                var c = control as GridColumn;
                if (c == null)
                    return;
                if (usetext)
                    c.Caption = text;
                if (aktif.HasValue)
                {
                    c.OptionsColumn.ReadOnly = !aktif.Value;
                    c.OptionsColumn.AllowEdit = aktif.Value;
                }
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is NavigatorButtonBase)
            {
                var c = control as NavigatorButtonBase;
                if (c == null)
                    return;
                if (usetext)
                    c.Hint = text;
                if (aktif.HasValue)
                    c.Enabled = aktif.Value;
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is NavigatorBase)
            {
                var c = control as NavigatorBase;
                if (c == null)
                    return;
                if (usetext)
                    c.Text = text;
                if (aktif.HasValue)
                    c.Enabled = aktif.Value;
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is BaseRow)
            {
                var c = control as BaseRow;
                if (c == null)
                    return;
                if (usetext)
                    c.Properties.Caption = text;
                if (aktif.HasValue)
                    c.Properties.ReadOnly = !aktif.Value;
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is MultiEditorRowProperties)
            {
                var c = control as MultiEditorRowProperties;
                if (c == null)
                    return;
                if (usetext)
                    c.Caption = text;
                if (aktif.HasValue)
                    c.ReadOnly = !aktif.Value;
                if (gorunur.HasValue && !gorunur.Value)
                {
                    (c.Row as MultiEditorRow).PropertiesCollection.Remove(c);
                }
                else if (gorunur.HasValue && gorunur.Value && !(c.Row as MultiEditorRow).PropertiesCollection.Contains(c))
                {
                    (c.Row as MultiEditorRow).PropertiesCollection.Add(c);
                }
            }
            else if (control is NavigatorButtonBase)
            {
                var c = control as NavigatorButtonBase;
                if (c == null)
                    return;
                if (usetext)
                    c.Hint = text;
                if (aktif.HasValue)
                    c.Enabled = aktif.Value;
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is ToolStrip)
            {
                var c = control as ToolStrip;
                if (c == null)
                    return;
                if (usetext)
                    c.Text = text;
                if (aktif.HasValue)
                    c.Enabled = aktif.Value;
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is ToolStripMenuItem)
            {
                var c = control as ToolStripMenuItem;
                if (c == null)
                    return;
                if (usetext)
                    c.Text = text;
                if (aktif.HasValue)
                    c.Enabled = aktif.Value;
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is ToolStripItem)
            {
                var c = control as ToolStripItem;
                if (c == null)
                    return;
                if (usetext)
                    c.Text = text;
                if (aktif.HasValue)
                    c.Enabled = aktif.Value;
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is XtraTabPage)
            {
                var c = control as XtraTabPage;
                if (c == null)
                    return;
                if (usetext)
                    c.Text = text;
                if (aktif.HasValue)
                    c.PageEnabled = aktif.Value;
                if (gorunur.HasValue)
                    c.PageVisible = gorunur.Value;
            }
            else if (control is NavBarItemLink)
            {
                var c = control as NavBarItemLink;
                if (c == null)
                    return;
                if (c.Item == null)
                    return;
                if (usetext)
                    c.Item.Caption = text;
                if (aktif.HasValue)
                    c.Item.Enabled = aktif.Value;
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is NavBarGroup)
            {
                var c = control as NavBarGroup;
                if (c == null)
                    return;
                if (usetext)
                    c.Caption = text;

                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is NavBarItem)
            {
                var c = control as NavBarItem;
                if (c == null)
                    return;
                if (usetext)
                    c.Caption = text;
                if (aktif.HasValue)
                    c.Enabled = aktif.Value;
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is PanelControl)
            {
                var c = control as PanelControl;
                if (c == null)
                    return;

                if (c.Parent != null && !c.Parent.Visible)
                    return;

                if (usetext)
                    c.Text = text;

                if (aktif.HasValue)
                {
                    if (c.Parent != null && c.Parent is BaseLayoutItem && !c.Parent.Enabled)
                        return;
                    c.Enabled = aktif.Value;
                }
                if (!(c.Parent is LayoutControl) && gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
            else if (control is Control)
            {
                var c = control as Control;
                if (c == null)
                    return;
                if (c.Parent != null && !c.Parent.Visible)
                    return;
                if (usetext)
                    c.Text = text;
                if (aktif.HasValue)
                {
                    if (c.Parent != null && c.Parent is BaseLayoutItem && !c.Parent.Enabled)
                        return;
                    c.Enabled = aktif.Value;
                }
                if (gorunur.HasValue)
                    c.Visible = gorunur.Value;
            }
        }
    }
}