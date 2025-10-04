using System;
using System.ComponentModel;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucDavaSMS : AdimAdimDavaKaydi.Util.BaseClasses.AvpXUserControl
    {
        public ucDavaSMS()
        {
            if (DesignMode)
                InitializeComponent();
            this.Load += this.ucDavaSMS_Load;
        }

        [Browsable(false)]
        public TList<TSMS_BIL_MESAJ> MyDataSource
        {
            get
            {
                if (gridDavaSMS.DataSource is TList<TSMS_BIL_MESAJ>)
                    return (TList<TSMS_BIL_MESAJ>)gridDavaSMS.DataSource;
                return null;
            }
            set
            {
                if (value != null && !this.DesignMode)
                {
                    gridDavaSMS.DataSource = value;
                    gridControl1.DataSource = gridDavaSMS.DataSource;
                }
            }
        }

        private void ucDavaSMS_Load(object sender, EventArgs e)
        {
            //LOAD
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();
            IsLoaded = true;
            gridDavaSMS.ButtonCevirClick += gridDavaSMS_ButtonCevirClick;
            gridControl1.ButtonCevirClick += gridDavaSMS_ButtonCevirClick;
        }

        private void gridDavaSMS_ButtonCevirClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (gridDavaSMS.Visible)
            {
                gridControl1.Visible = true;
                gridDavaSMS.Visible = false;
            }
            else
            {
                gridControl1.Visible = false;
                gridDavaSMS.Visible = true;
            }
        }

        private void gridDavaSMS_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;
            else if (e.Button.Tag.ToString() == "FormdanEkle")
            {
                //UNDONE: "gwDavaSMS" kaydetme iþlemi yapýlacak.
            }
            else if (e.Button.Tag.ToString() == "Duzenle")
            {
                //UNDONE: "gwDavaSMS" düzenleme iþlemi yapýlacak.
            }
            else if (e.Button.Tag.ToString() == "Sil")
            {
                //UNDONE: "gwDavaSMS" silme iþlemi yapýlacak.
            }
        }
    }
}