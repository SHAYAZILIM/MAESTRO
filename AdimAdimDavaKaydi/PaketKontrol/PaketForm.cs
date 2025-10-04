using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdimAdimDavaKaydi.PaketKontrol
{
    [Serializable]
    public class PaketForm
    {
        private ChildItemCollection<PaketForm, PaketControl> _Controls;

        [NonSerialized]
        private Form _Form;

        [NonSerialized]
        private int _Id = 0;

        public List<PaketControl> BindControls
        {
            get
            {
                return _Controls.Where(q => q.Id != 0 && q.PaketForm != null && q.Control != null && q.Id != q.ParentId).ToList();
            }
        }

        public ChildItemCollection<PaketForm, PaketControl> Controls
        {
            get
            {
                return _Controls;
            }
            set
            {
                _Controls = value;
            }
        }

        public string Description { get; set; }

        public Form Form
        {
            get
            {
                return _Form;
            }
            set
            {
                _Form = value;
            }
        }

        public string FormCaption { get; set; }

        public string FormName { get; set; }

        public string FormType { get; set; }

        public string FullName { get; set; }

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
    }
}