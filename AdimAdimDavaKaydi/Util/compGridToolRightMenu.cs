using System;
using System.ComponentModel;
using DevExpress.XtraBars;

namespace AdimAdimDavaKaydi.Util
{
    public partial class compGridToolRightMenu : Component
    {
        public compGridToolRightMenu(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private ExtendedGridControl _myGridControl;

        public ExtendedGridControl MyGridControl
        {
            get { return _myGridControl; }
            set
            {
                if (value != null)
                {
                    value.RightClickPopup.PopupOpening += RightClickPopup_PopupOpening;
                    value.RightClickPopup.PopupButtonClick += RightClickPopup_PopupButtonClick;
                }
                _myGridControl = value;
            }
        }

        public event EventHandler<ItemClickEventArgs> bukaydiduzenle;
        public event EventHandler<ItemClickEventArgs> bukaydisil;
        public event EventHandler<ItemClickEventArgs> bukaydayeniekle;

        private void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag != null)
            {
                if (e.Item.Name == bkDuzenle.Name)
                    bukaydiduzenle(sender, e);
                if (e.Item.Name == bkSil.Name)
                    bukaydisil(sender, e);
                if (e.Item.Name == bkYeni.Name)
                    bukaydayeniekle(sender, e);
            }
        }

        private BarButtonItem bkDuzenle;
        private BarButtonItem bkSil;
        private BarButtonItem bkYeni;

        private void RightClickPopup_PopupOpening(object sender, AdimAdimDavaKaydi.UserControls.PopupOpeningEventArgs e)
        {
            BarSubItem bus = new BarSubItem(e.Manager, "Bu Kaydi");

            bkDuzenle = new BarButtonItem(e.Manager, "Bu Kaydi Düzenle");
            bkSil = new BarButtonItem(e.Manager, "Bu Kaydi Sil");
            bkYeni = new BarButtonItem(e.Manager, "Yeni Kayıt Ekle");
            bkDuzenle.Name = "Düzenle";
            bkSil.Name = "Sil";
            bkYeni.Name = "Yeni";
            bkDuzenle.Tag = e.Rows;
            bkSil.Tag = e.Rows;
            bkYeni.Tag = e.Rows;
            bus.ItemLinks.AddRange(new BarItem[]
                                       {
                                           bkDuzenle,
                                           bkSil,
                                           bkYeni
                                       });
            e.MyPopupMenu.ItemLinks.Insert(0, bus);
        }
    }
}