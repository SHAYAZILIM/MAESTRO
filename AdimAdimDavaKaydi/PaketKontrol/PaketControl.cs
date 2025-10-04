using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    [Serializable]
    public class PaketControl : IChildItem<PaketForm>
    {
        public static int cid = 0;

        [NonSerialized]
        private object _Control;

        private string _CustomCaption;

        [NonSerialized]
        private int _Id = 0;

        [NonSerialized]
        private Point _Location = Point.Empty;

        [NonSerialized]
        private PaketForm _PaketForm;

        [NonSerialized]
        private int _ParentId = 0;

        private ChildItemCollection<PaketControl, PaketControlProperty> _Properties;

        [NonSerialized]
        private Size _Size = Size.Empty;

        private bool? _UseCustomCaption;

        PaketForm IChildItem<PaketForm>.Parent
        {
            get
            {
                return this.PaketForm;
            }
            set
            {
                this.PaketForm = value;
            }
        }

        public object Control
        {
            get
            {
                return _Control;
            }
            set
            {
                _Control = value;
                if (value != null)
                {
                    var property = Properties.Where(q => q.PaketId == PaketHelper.AktifPaket.PaketId).FirstOrDefault();
                    if (property != null)
                        property.SetControlProperty();
                    if (value is XtraTabControl)
                    {
                        (value as XtraTabControl).SelectedPageChanged += new TabPageChangedEventHandler(PaketControl_SelectedPageChanged);
                    }
                    else if (value is TabbedGroup)
                    {
                        (value as TabbedGroup).SelectedPageChanged += new LayoutTabPageChangedEventHandler(PaketControl_SelectedPageChanged);
                    }
                }
            }
        }

        public string ControlCaption { get; set; }

        public string ControlName { get; set; }

        public string ControlType { get; set; }

        public string CustomCaption
        {
            get
            {
                return _CustomCaption;
            }
            set
            {
                _CustomCaption = value;
                if (!UseCustomCaption.HasValue && ControlCaption != value)
                {
                    UseCustomCaption = true;
                }
                if (Control != null && UseCustomCaption.HasValue && UseCustomCaption.Value)
                {
                    var property = Properties.Where(q => q.PaketId == PaketHelper.AktifPaket.PaketId).FirstOrDefault();
                    if (property != null)
                        property.SetControlProperty();
                }
            }
        }

        public string Description { get; set; }

        public string FullName { get; set; }

        public int HashCode { get; set; }

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                cid++;
                _Id = cid;
            }
        }

        [XmlIgnore]
        public Point Location
        {
            get
            {
                if (_Location.IsEmpty)
                {
                    _Location = GetPositionInForm();
                }
                return _Location;
            }
        }

        public PaketForm PaketForm
        {
            get { return _PaketForm; }
            set { _PaketForm = value; }
        }

        public int ParentId
        {
            get
            {
                return _ParentId;
            }
            set
            {
                _ParentId = value;
            }
        }

        public ChildItemCollection<PaketControl, PaketControlProperty> Properties
        {
            get
            {
                if (PaketHelper.IsEdit)
                {
                    if (_Properties == null)
                    {
                        _Properties = new ChildItemCollection<PaketControl, PaketControlProperty>(this);
                        foreach (var item in PaketHelper.Paketler)
                        {
                            var paketProperty = new PaketControlProperty()
                            {
                                PaketId = item.PaketId
                            };
                            _Properties.Add(paketProperty);
                        }
                    }
                    foreach (var item in PaketHelper.Paketler)
                    {
                        if (!_Properties.Any(q => q.PaketId == item.PaketId))
                        {
                            var paketProperty = new PaketControlProperty()
                            {
                                PaketId = item.PaketId
                            };
                            _Properties.Add(paketProperty);
                        }
                    }
                    foreach (var item in _Properties.ToList())
                    {
                        if (!PaketHelper.Paketler.Any(q => q.PaketId == item.PaketId))
                        {
                            _Properties.Remove(item);
                        }
                    }
                }

                if (_Properties == null)
                    _Properties = new ChildItemCollection<PaketControl, PaketControlProperty>(this);

                _Properties.SetParent(this);
                return _Properties;
            }
        }

        [XmlIgnore]
        public Size Size
        {
            get
            {
                if (_Size.IsEmpty)
                {
                    _Size = GetSizeInForm();
                }
                return _Size;
            }
        }

        public bool? UseCustomCaption
        {
            get
            {
                return _UseCustomCaption;
            }
            set
            {
                _UseCustomCaption = value;
            }
        }

        private Point GetPositionInForm()
        {
            if (Control == null)
                return Point.Empty;

            Point p = Point.Empty;
            Control parent = null;

            var form = this.PaketForm;

            if (Control is LayoutControlItem)
            {
                var layitem = (Control as LayoutControlItem);

                if (layitem.Control != null)
                {
                    return form.Form.PointToClient(layitem.Control.PointToScreen(new Point(0, 0)));
                }
                else if (layitem.Owner != null && layitem.Owner is LayoutControl)
                    return form.Form.PointToClient((layitem.Owner as LayoutControl).PointToScreen(new Point(0, 0)));
            }
            else if (Control is LayoutGroup)
            {
                var layitem = (Control as LayoutGroup);
                p = new Point(layitem.Location.X + layitem.Padding.Left, layitem.Location.Y + layitem.Padding.Top);
                if (layitem.Owner != null && layitem.Owner is LayoutControl)
                    parent = layitem.Owner as LayoutControl;
            }
            else if (Control is Control)
            {
                return form.Form.PointToClient((Control as Control).PointToScreen(new Point(0, 0)));
                //p = (Control as Control).Location;
                //parent = (Control as Control).Parent;
            }

            while (!(parent is Form) && parent != null)
            {
                p.Offset(parent.Location.X, parent.Location.Y);
                parent = parent.Parent;
            }

            return p;
        }

        private Size GetSizeInForm()
        {
            if (Control == null)
                return Size.Empty;

            Size p = Size.Empty;

            if (Control is Control)
            {
                p = (Control as Control).Size;
            }
            else if (Control is LayoutControlItem)
            {
                var layitem = (Control as LayoutControlItem);
                p = layitem.Control != null ? layitem.Control.Size : layitem.Size;
            }
            else if (Control is LayoutGroup)
            {
                p = (Control as LayoutGroup).Size;
            }
            return p;
        }

        private void PaketControl_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page != null && (e.Page.Tag == null || ((e.Page.Tag != null) && !(e.Page.Tag is bool)) || ((e.Page.Tag != null) && !(bool)e.Page.Tag)))
            {
                if (e == null || this == null || this.PaketForm == null || e.Page == null)
                    return;
                e.Page.GetControl(this.ParentId, this.PaketForm);
                e.Page.Tag = true;
            }
        }

        private void PaketControl_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e)
        {
            if (e.Page != null && (e.Page.Tag == null || ((e.Page.Tag != null) && !(e.Page.Tag is bool)) || ((e.Page.Tag != null) && !(bool)e.Page.Tag)))
            {
                e.Page.GetControl(this.ParentId, this.PaketForm);
                e.Page.Tag = true;
            }
        }
    }
}