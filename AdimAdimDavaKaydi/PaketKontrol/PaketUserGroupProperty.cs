using System;
using System.Linq;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    [Serializable]
    public class PaketUserGroupProperty : IChildItem<PaketControlProperty>
    {
        private bool? _Aktif;

        private bool? _Gorunur;

        [NonSerialized]
        private string _GroupName;

        [NonSerialized]
        private PaketControlProperty _PaketControlProperty;

        PaketControlProperty IChildItem<PaketControlProperty>.Parent
        {
            get
            {
                return this.PaketControlProperty;
            }
            set
            {
                this.PaketControlProperty = value;
            }
        }

        public bool? Aktif
        {
            get { return _Aktif; }
            set
            {
                _Aktif = value;
            }
        }

        public bool? Gorunur
        {
            get { return _Gorunur; }
            set
            {
                _Gorunur = value;
            }
        }

        public int GroupId { get; set; }

        public string GroupName
        {
            get
            {
                if (string.IsNullOrEmpty(_GroupName))
                {
                    _GroupName = PaketHelper.UserGroups.Where(q => q.Id == GroupId).Select(q => q.Adi).FirstOrDefault();
                }
                return _GroupName;
            }
            set { _GroupName = value; }
        }

        public PaketControlProperty PaketControlProperty
        {
            get { return _PaketControlProperty; }
            set { _PaketControlProperty = value; }
        }

        public bool? Sepet { get; set; }

        public bool? Yetkilendirme { get; set; }
    }
}