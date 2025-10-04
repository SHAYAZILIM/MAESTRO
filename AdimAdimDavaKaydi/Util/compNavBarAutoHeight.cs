using System.ComponentModel;
using System.Reflection;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;

namespace AdimAdimDavaKaydi.Util
{
    public partial class compNavBarAutoHeight : Component
    {
        #region Global Constraction

        public compNavBarAutoHeight()
        {
            InitializeComponent();
        }

        public compNavBarAutoHeight(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Events

        private void navBarGroup_CalcGroupClientHeight(object sender,
                                                       DevExpress.XtraNavBar.NavBarCalcGroupClientHeightEventArgs e)
        {
            if (DesignMode)
                return;

            NavBarViewInfo vi = GetViewInfo(MyNavBarControl);
            ExplorerBarNavGroupPainter groupPainter = GetGroupPainter(MyNavBarControl);
            e.Height = vi.Client.Height;
            foreach (NavBarGroup group in MyNavBarControl.Groups)
            {
                if (group.Expanded && group != e.Group)
                {
                    if (group.ControlContainer != null)
                        e.Height -= group.ControlContainer.Height;
                }

                NavGroupInfoArgs gi = vi.GetGroupInfo(e.Group);
                if (gi != null)
                {
                    groupPainter.CalcFooterBounds(gi, gi.Bounds);
                    e.Height -= gi.Bounds.Height + gi.FooterBounds.Height + 5;
                }
            }
        }

        #endregion

        #region Methots

        private ExplorerBarNavGroupPainter GetGroupPainter(NavBarControl navBar)
        {
            FieldInfo fi = typeof(NavBarControl).GetField("groupPainter",
                                                           BindingFlags.NonPublic | BindingFlags.Instance);
            return fi.GetValue(navBar) as ExplorerBarNavGroupPainter;
        }

        private NavBarViewInfo GetViewInfo(NavBarControl navBar)
        {
            FieldInfo fi = typeof(NavBarControl).GetField("viewInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            return fi.GetValue(navBar) as NavBarViewInfo;
        }

        #endregion

        #region Properties

        public NavBarControl MyNavBarControl { get; set; }

        private NavBarGroup _dockingGroup;

        public NavBarGroup DockingGroup
        {
            get { return _dockingGroup; }
            set
            {
                _dockingGroup = value;
                if (value != null)
                    _dockingGroup.CalcGroupClientHeight += navBarGroup_CalcGroupClientHeight;
            }
        }

        #endregion
    }
}