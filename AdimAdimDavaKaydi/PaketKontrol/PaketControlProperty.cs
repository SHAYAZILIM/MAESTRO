using System;
using System.Linq;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    [Serializable]
    public class PaketControlProperty : IChildItem<PaketControl>
    {
        private bool? _Aktif;
        private bool? _Gorunur;
        private ChildItemCollection<PaketControlProperty, PaketUserGroupProperty> _GroupProperties;

        [NonSerialized]
        private PaketControl _PaketControl;

        [NonSerialized]
        private string _PaketName;

        private bool? _Sepet;
        private bool? _Yetkilendirme;

        PaketControl IChildItem<PaketControl>.Parent
        {
            get
            {
                return this.PaketControl;
            }
            set
            {
                this.PaketControl = value;
            }
        }

        public bool? Aktif
        {
            get
            {
                return _Aktif;
            }
            set
            {
                _Aktif = value;
                SetGroupProperty();
                this.SetControlProperty();
            }
        }

        public bool? Gorunur
        {
            get { return _Gorunur; }
            set
            {
                _Gorunur = value;
                SetGroupProperty();
                this.SetControlProperty();
            }
        }

        public ChildItemCollection<PaketControlProperty, PaketUserGroupProperty> GroupProperties
        {
            get
            {
                if (PaketHelper.IsEdit)
                {
                    if (_GroupProperties == null)
                    {
                        _GroupProperties = new ChildItemCollection<PaketControlProperty, PaketUserGroupProperty>(this);
                        foreach (var item in PaketHelper.UserGroups)
                        {
                            var groupProperty = new PaketUserGroupProperty()
                            {
                                GroupId = item.Id
                            };
                            _GroupProperties.Add(groupProperty);
                        }
                    }
                    foreach (var item in PaketHelper.UserGroups)
                    {
                        if (!_GroupProperties.Any(q => q.GroupId == item.Id))
                        {
                            var groupProperty = new PaketUserGroupProperty()
                            {
                                GroupId = item.Id
                            };
                            _GroupProperties.Add(groupProperty);
                        }
                    }
                    foreach (var item in _GroupProperties.ToList())
                    {
                        if (!PaketHelper.UserGroups.Any(q => q.Id == item.GroupId))
                        {
                            _GroupProperties.Remove(item);
                        }
                    }
                }
                if (_GroupProperties == null)
                    _GroupProperties = new ChildItemCollection<PaketControlProperty, PaketUserGroupProperty>(this);
                _GroupProperties.SetParent(this);
                return _GroupProperties;
            }
        }

        public PaketControl PaketControl
        {
            get { return _PaketControl; }
            set { _PaketControl = value; }
        }

        public int PaketId { get; set; }

        public string PaketName
        {
            get
            {
                if (string.IsNullOrEmpty(_PaketName))
                {
                    _PaketName = PaketHelper.Paketler.Where(q => q.PaketId == PaketId).Select(q => q.PaketAdi).FirstOrDefault();
                }
                return _PaketName;
            }
            set { _PaketName = value; }
        }

        public bool? Sepet
        {
            get
            {
                return _Sepet;
            }
            set
            {
                _Sepet = value;
                SetGroupProperty();
            }
        }

        public bool? Yetkilendirme
        {
            get
            {
                return _Yetkilendirme;
            }
            set
            {
                _Yetkilendirme = value;
                SetGroupProperty();
            }
        }

        private void SetGroupProperty()
        {
            PaketControlProperty pcontrol = this;
            if (pcontrol != null)
            {
                foreach (var pgroup in pcontrol.GroupProperties)
                {
                    if (pcontrol.Aktif.HasValue)
                        pgroup.Aktif = pcontrol.Aktif;
                    if (pcontrol.Gorunur.HasValue)
                        pgroup.Gorunur = pcontrol.Gorunur;
                    if (pcontrol.Sepet.HasValue)
                        pgroup.Sepet = pcontrol.Sepet;
                    if (pcontrol.Yetkilendirme.HasValue)
                        pgroup.Yetkilendirme = pcontrol.Yetkilendirme;
                }
            }
        }
    }
}