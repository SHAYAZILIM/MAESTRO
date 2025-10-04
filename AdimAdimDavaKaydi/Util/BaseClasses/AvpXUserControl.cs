using System;
using System.ComponentModel;
using AdimAdimDavaKaydi.PaketKontrol;

namespace AdimAdimDavaKaydi.Util.BaseClasses
{
    public class AvpXUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        //private string packControlName;
        //public string PackControlName
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(packControlName)) return this.Name;
        //        return packControlName;
        //    }
        //    set
        //    {
        //        packControlName = value;
        //    }
        //}

        private bool _IsLoaded;

        [Browsable(false)]
        [DefaultValue(false)]
        public bool IsLoaded
        {
            get { return _IsLoaded; }
            set
            {
                if (this.DesignMode) return;
                _IsLoaded = value;
                if (!IsPackControlDone && value)
                {
                    //AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm);
                    IsPackControlDone = true;
                }
            }
        }

        private bool _IsPackControlDone;

        [Browsable(false)]
        [DefaultValue(false)]
        public bool IsPackControlDone
        {
            get { return _IsPackControlDone; }
            set
            {
                if (this.DesignMode) return;
                _IsPackControlDone = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            IsLoaded = false;
            IsPackControlDone = false;
            //  if (AvukatProLib.Util.AuthHelperBase.loadedControlList.Contains(this.Name)) AvukatProLib.Util.AuthHelperBase.loadedControlList.Remove(this.Name);
            base.Dispose(disposing);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //aykut hızlandırma 25.01.2013
            if (!DesignMode)
                this.GetPaketForm();
        }
        //protected override void OnVisibleChanged(EventArgs e)
        //{
        //    base.OnVisibleChanged(e);
        //    if (IsLoaded)
        //    {
        //        AvukatProLib.Util.AuthHelperBase.PaketKontrol(this.ParentForm, this);
        //    }
        //}
    }
}