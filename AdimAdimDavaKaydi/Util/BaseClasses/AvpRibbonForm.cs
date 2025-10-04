using System;
using System.Collections;
using System.Windows.Forms;
using AvukatProLib.Util;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;

namespace AdimAdimDavaKaydi.Util.BaseClasses
{
    public class AvpRibbonForm : RibbonForm
    {
        #region Kontrolleri recursive olarak tarar ve PlainControlde diziye atar

        private ArrayList controls;

        private void traverseControl(Control container)
        {
            controls.Add(container);
            foreach (Control con in container.Controls)
                traverseControl(con);
        }

        public Control[] PlainControls
        {
            get
            {
                if (controls == null)
                {
                    controls = new ArrayList();
                    traverseControl(this);
                }
                return (Control[])controls.ToArray(typeof(Control));
            }
        }

        #endregion

        public static int _AcilanFormSayisi;

        public AvpRibbonForm()
        {
            this.Load += AvpRibbonForm_Load;
        }

        private void AvpRibbonForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            _AcilanFormSayisi++;
            foreach (Control ctrl in this.PlainControls)
            {
                //GridView kontrolünü CS_KOD_FORM_LISTESI tablosuna eklemesini saðlayan metodu aktifleþtirir.
                if (ctrl is GridView)
                    AuthHelperBase.ApplyAuthorization(this.GetType().FullName, ctrl.Name, ctrl.Text);
                //RibbonFormlarýn CS_KOD_FORM_LISTESI tablosuna eklenmesi iþlemini saðlayacak olan metod ile iþlemlerini gerçekleþtirir.
                if (ctrl is RibbonForm)
                    AuthHelperBase.ApplyAuthorization(this.GetType().FullName, ctrl.Name, ctrl.Text);
                //Form üzerinde yer alan bütün týklanabilen kontrolleri CS_KOD_FORM_LISTESI tablosuna ekleyen metodu aktifleþtirir.
                if (ctrl is IButtonControl)
                    AuthHelperBase.ApplyAuthorization(this.GetType().FullName, ctrl.Name, ctrl.Text);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            AdimAdimDavaKaydi.Util.BaseClasses.MemoryManagement.ManageMemory.ReduceMemory();
        }

        //public class YetkiEventArgs : EventArgs
        //{
        //    private string _YetkiCumlesi;

        //    public string YetkiCumlesi
        //    {
        //        get { return _YetkiCumlesi;}
        //        set { _YetkiCumlesi = value;}
        //    }
        //}
    }
}