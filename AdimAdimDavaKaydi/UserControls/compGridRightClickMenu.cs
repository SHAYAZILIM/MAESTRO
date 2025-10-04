using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Util;
using AvukatProLib2.Entities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace AdimAdimDavaKaydi.UserControls
{
    public partial class compGridRightClickMenu : Component
    {
        public BarManager MyBarManager = new BarManager();

        protected BarItemLinkCollection _barItemCollections;

        protected ExtendedGridControl _myGridControl;

        private PopupMenu _MyPopup = new PopupMenu();

        public compGridRightClickMenu()
        {
            InitializeComponent();
        }

        public compGridRightClickMenu(IContainer container)
        {
            container.Add(this);
            MyPopup.Manager = MyBarManager;
            MyBarManager.ItemClick += MyBarManager_ItemClick;
            InitializeComponent();
        }

        public event EventHandler<ItemClickEventArgs> PopupButtonClick;

        public event EventHandler<PopupOpeningEventArgs> PopupOpened;

        public event EventHandler<PopupOpeningEventArgs> PopupOpening;

        public BarItemLinkCollection BarItemCollections
        {
            get
            {
                if (_barItemCollections != null)
                {
                    return _barItemCollections;
                }
                else if (_barItemCollections == null)
                {
                    _barItemCollections = new BarItemLinkCollection();
                    return _barItemCollections;
                }
                return new BarItemLinkCollection();
            }
            set { _barItemCollections = value; }
        }

        //public BarManager MyBarManager = new BarManager();
        public LinksInfo LinkPersist { get; set; }

        public ExtendedGridControl MyGridControl
        {
            get { return _myGridControl; }
            set
            {
                if (value != null)
                {
                    _myGridControl = value;

                    value.MouseDown += value_MouseDown;

                    MyBarManager.ItemClick += MyBarManager_ItemClick;
                    return;
                }
                _myGridControl = null;
            }
        }

        [Browsable(true)]
        public PopupMenu MyPopup
        {
            get { return _MyPopup; }
            set { _MyPopup = value; }
        }

        public void DoShowMenu(GridHitInfo hi)
        {
            MyPopup.Manager = MyBarManager;
            if (hi.HitTest == GridHitTest.RowCell)
            {
                GridView view = MyGridControl.FocusedView as GridView;

                MyPopup.ItemLinks.Clear();

                if (view != null)
                {
                    object secilenKayit = view.GetRow(hi.RowHandle);
                    object secilenCell = view.GetSelectedCells(hi.RowHandle);

                    if (secilenKayit != null)
                    {
                        if (secilenKayit is AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE)
                        {
                            var proje = new AV001_TDIE_BIL_PROJE();
                            proje.ID = ((AvukatProLib.Arama.per_AV001_TDIE_BIL_PROJE)secilenKayit).ID;
                            secilenKayit = proje;
                        }

                        //BarButtonItem item = new BarButtonItem(MyBarManager, secilenKayit.GetType().FullName);
                        //item.Tag = secilenKayit;
                        //MyPopup.ItemLinks.Add(item);

                        PopupOpeningEventArgs args = new PopupOpeningEventArgs();
                        args.Rows = secilenKayit;
                        args.IsCancel = false;
                        args.Manager = MyBarManager;
                        args.MyPopupMenu = MyPopup;
                        args.Column = hi.Column;

                        if (args.IsCancel)
                            return;
                        if (secilenKayit is IEntity)
                        {
                            BarButtonItem btnEntitySil = new BarButtonItem(MyBarManager, "Sil");
                            btnEntitySil.ItemClick += btnEntitySil_ItemClick;
                            btnEntitySil.Tag = secilenKayit;
                            btnEntitySil.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.dnext_12x12_delete;
                            MyPopup.ItemLinks.Add(btnEntitySil);
                        }

                        switch (secilenKayit.GetType().Name)
                        {
                            case "R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU":
                                BarButtonItem R_birlesikBtn = new BarButtonItem(MyBarManager, "Takip Ekranı");
                                R_birlesikBtn.Tag = secilenKayit;
                                MyPopup.ItemLinks.Add(R_birlesikBtn);
                                break;

                            case "R_BIRLESIK_TAKIPLER_TUMU_TEXT":
                                BarButtonItem R_birlesikTumuBtn = new BarButtonItem(MyBarManager, "Takip Ekranı");
                                R_birlesikTumuBtn.Tag = secilenKayit;
                                MyPopup.ItemLinks.Add(R_birlesikTumuBtn);
                                BarButtonItem R_birlesikTumuOdemePlani = new BarButtonItem(MyBarManager,
                                                                                           "Ödeme Planı Ekranı");
                                R_birlesikTumuOdemePlani.Tag = secilenKayit;
                                MyPopup.ItemLinks.Add(R_birlesikTumuOdemePlani);
                                break;

                            case "ICRA_PRATIK_ARAMA":
                                BarButtonItem IcraPratikBtn = new BarButtonItem(MyBarManager, "Takip Ekranı");
                                IcraPratikBtn.Tag = secilenKayit;
                                MyPopup.ItemLinks.Add(IcraPratikBtn);
                                break;
                            default:
                                break;
                        }

                        //if (MyGridControl.EmbeddedNavigator.Buttons.Append.Enabled)
                        //{
                        //    BarButtonItem barBtnYeniEkle = new BarButtonItem(MyBarManager, "Yeni Ekle");
                        //    NavigatorCustomButton nbe = new NavigatorCustomButton(); nbe.Tag = "YeniEkle";
                        //    barBtnYeniEkle.Tag = nbe;
                        //    MyPopup.ItemLinks.Add(barBtnYeniEkle);
                        //}
                        if (MyGridControl.EmbeddedNavigator.Buttons.Remove.Enabled)
                        {
                            BarButtonItem barBtnSecimiKaldir = new BarButtonItem(MyBarManager, "Seçimi Kaldır");
                            barBtnSecimiKaldir.Glyph =
                                global::AdimAdimDavaKaydi.Properties.Resources.application_remove_22x22;
                            NavigatorCustomButton nbs = new NavigatorCustomButton();
                            nbs.Tag = "SecimiSil";
                            barBtnSecimiKaldir.Tag = nbs;
                            MyPopup.ItemLinks.Add(barBtnSecimiKaldir);
                        }
                        //if (true)
                        //{
                        //    BarButtonItem barBtnOtoYukseklik = new BarButtonItem(MyBarManager, "Otomatik Yükseklik");
                        //    NavigatorCustomButton nby = new NavigatorCustomButton();
                        //    nby.Tag = "OtoYukseklik";
                        //    barBtnOtoYukseklik.Glyph = global::AdimAdimDavaKaydi.Properties.Resources.database_up_22x22;
                        //    barBtnOtoYukseklik.Tag = nby;
                        //    MyPopup.ItemLinks.Add(barBtnOtoYukseklik);
                        //}

                        for (int i = 0; i < MyGridControl.EmbeddedNavigator.Buttons.CustomButtons.Count; i++)
                        {
                            NavigatorCustomButton btn = MyGridControl.EmbeddedNavigator.Buttons.CustomButtons[i];

                            if (btn.Tag == "Biçimlendirme")
                            {
                                BarSubItem bsi = new BarSubItem(MyBarManager, btn.Hint);
                                bsi.Glyph = ((ImageList)btn.ImageList).Images[btn.ImageIndex];

                                bsi.ItemLinks.Assign(MyGridControl.popupMenu1.ItemLinks);

                                MyPopup.LinksPersistInfo.Add(new LinkPersistInfo(bsi));
                                MyPopup.ItemLinks.Add(bsi);
                            }
                            else if (btn.Tag == "Editor")
                            {
                                //BarSubItem bsi = new BarSubItem(MyBarManager, btn.Hint);
                                //bsi.Glyph = ((ImageList)btn.ImageList).Images[btn.ImageIndex];

                                //bsi.ItemLinks.Assign(MyGridControl.popupMenu2.ItemLinks);

                                //MyPopup.LinksPersistInfo.Add(new LinkPersistInfo(bsi));
                                //MyPopup.ItemLinks.Add(bsi);
                            }
                            else if (btn.Tag != "Yazdir")
                            {
                                BarButtonItem barBtn = new BarButtonItem(MyBarManager, btn.Hint);
                                barBtn.Tag = btn;
                                if (btn.ImageIndex > -1 && btn.ImageList != null)
                                    barBtn.Glyph = (btn.ImageList as ImageList).Images[btn.ImageIndex];
                                if (btn.Hint != "Geçerli Kaydı Sil")
                                    MyPopup.ItemLinks.Add(barBtn);
                            }
                        }

                        if (BarItemCollections != null)
                        {
                            //MyPopup.LinksPersistInfo.Add(new LinkPersistInfo(BarItemCollections));

                            foreach (object barItem in BarItemCollections)
                            {
                                if (barItem is BarSubItemLink)
                                {
                                    MyPopup.LinksPersistInfo.Add(new LinkPersistInfo((barItem as BarSubItemLink).Item));
                                }

                                // MyPopup.ItemLinks.Add(barItem);
                            }
                        }
                        if (LinkPersist != null)
                        {
                            int sayi = 0;
                            foreach (LinkPersistInfo info in LinkPersist)
                            {
                                sayi++;

                                if (sayi ==  1)
                                {
                                    info.Item.Manager = MyBarManager;

                                    BarSubItem bsa = new BarSubItem(MyBarManager, info.Item.Caption);
                                    bsa.Glyph = info.Item.Glyph;
                                    bsa.LargeGlyph = info.Item.LargeGlyph;
                                    if (info.Item is BarSubItem)
                                    {
                                        for (int i = 0; i < (info.Item as BarSubItem).ItemLinks.Count; i++)
                                        {
                                            if ((info.Item as BarSubItem).ItemLinks[i].Item.Caption != "Hatırlatma" & (info.Item as BarSubItem).ItemLinks[i].Item.Caption != "Not")
                                            {
                                                //bsa.ItemLinks.Assign((info.Item as BarSubItem).ItemLinks);
                                                BarButtonItem bbi = new BarButtonItem(MyBarManager,
                                                                                      (info.Item as BarSubItem).ItemLinks[i].Item.Caption);
                                                bbi.Tag = secilenKayit;
                                                bbi.Name = (info.Item as BarSubItem).ItemLinks[i].Item.Name;
                                                bbi.LargeGlyph = (info.Item as BarSubItem).ItemLinks[i].Item.LargeGlyph;
                                                bbi.Glyph = (info.Item as BarSubItem).ItemLinks[i].Item.Glyph;

                                                //(info.Item as BarSubItem).ItemLinks[i].Item.Manager = MyBarManager;
                                                bsa.ItemLinks.Add(bbi); 
                                            }
                                        }
                                    }
                                    MyPopup.ItemLinks.Add(bsa); 
                                }
                            }
                            MyPopup.MenuDrawMode = MenuDrawMode.SmallImagesText;
                        }
                        if (PopupOpening != null)
                            PopupOpening(this, args);
                    }
                }

                PopupOpeningEventArgs args2 = new PopupOpeningEventArgs();
                args2.IsCancel = false;
                args2.Manager = MyBarManager;
                args2.MyPopupMenu = MyPopup;
                args2.Column = hi.Column;

                if (PopupOpened != null)
                    PopupOpened(this, args2);
                object o = MyGridControl.PointToScreen(hi.HitPoint);

                MyPopup.ShowPopup(MyGridControl.PointToScreen(hi.HitPoint));
            }
        }

        private void btnEntitySil_ItemClick(object sender, ItemClickEventArgs e)
        {
            AdimAdimDavaKaydi.Util.frmKayitSil kayitSil = new frmKayitSil(e.Item.Tag.GetType().Name, "ID = " + e.Item.Tag.GetType().GetProperty("ID").GetValue(e.Item.Tag, null));
            if (kayitSil.ShowDialog() == DialogResult.OK && kayitSil.SilmeOnayi != DialogResult.Cancel)
            {
                //MyGridControl.DataSource.GetType().GetMethod("Remove").Invoke(MyGridControl.DataSource,
                //
                try
                {
                    if (e.Item.Tag.GetType().Name == "AV001_TI_BIL_FOY_TARAF")
                    {
                        try
                        {
                            ABSqlConnection cn = new ABSqlConnection();
                            cn.CnString = AvukatProLib.Kimlikci.Kimlik.SirketBilgisi.ConStr;
                            cn.AddParams("@ICRA_FOY_ID", e.Item.Tag.GetType().GetProperty("ICRA_FOY_ID").GetValue(e.Item.Tag, null));
                            cn.AddParams("@TARAF_CARI_ID", e.Item.Tag.GetType().GetProperty("CARI_ID").GetValue(e.Item.Tag, null));

                            cn.ExcuteQuery("delete FROM dbo.AV001_TI_BIL_ALACAK_NEDEN_TARAF WHERE ICRA_ALACAK_NEDEN_ID IN (SELECT ID FROM dbo.AV001_TI_BIL_ALACAK_NEDEN WHERE ICRA_FOY_ID=@ICRA_FOY_ID AND TARAF_CARI_ID=@TARAF_CARI_ID)");
                        }
                        catch { ;}
                    }
                    MyGridControl.DataSource.GetType().GetMethod("Remove").Invoke(MyGridControl.DataSource,
                                                                                  new[] { ((GridView)MyGridControl.FocusedView).GetFocusedRow() });
                }
                catch
                { }
                finally { MyGridControl.RefreshDataSource(); MyGridControl.Refresh(); }
            }
        }

        private void MyBarManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Tag is NavigatorButtonBase)
            {
                MyGridControl.ClickEmbededNavigatorButton(e.Item.Tag as NavigatorButtonBase);
            }
            else if (e.Item.Tag is R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU)
            {
                MyGridControl.ClickEmbededNavigatorButton(e.Item.Tag as R_BIRLESIK_TAKIPLER_TARAFLI_SORUMLULU);
            }
            else if (e.Item.Tag is R_BIRLESIK_TAKIPLER_TUMU_TEXT && e.Item.Caption == "Takip Ekranı")
            {
                MyGridControl.ClickEmbededNavigatorButton(e.Item.Tag as R_BIRLESIK_TAKIPLER_TUMU_TEXT);
            }
            else if (e.Item.Tag is R_BIRLESIK_TAKIPLER_TUMU_TEXT && e.Item.Caption == "Ödeme Planı Ekranı")
            {
                OdemePlaninaGonder(e.Item.Tag as R_BIRLESIK_TAKIPLER_TUMU_TEXT);
            }
            else if (e.Item.Tag is ICRA_PRATIK_ARAMA)
            {
                MyGridControl.ClickEmbededNavigatorButton(e.Item.Tag as ICRA_PRATIK_ARAMA);
            }

            if (PopupButtonClick != null)
                PopupButtonClick(sender, e);
            MyPopup.HidePopup();
        }

        private void OdemePlaninaGonder(R_BIRLESIK_TAKIPLER_TUMU_TEXT takip)
        {
            if (takip.Tipi == "Icra")
            {
                if (takip.ID.HasValue)
                {
                    AdimAdimDavaKaydi.UserControls.frmOdemePlani plan = new frmOdemePlani();
                    plan.Show(takip.ID.Value, takip);
                }
            }

            //ToDo : Burası Geçici Olarak Böyle devam Edecek (gkn)
        }

        private void value_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridView view = MyGridControl.FocusedView as GridView;
                if (view != null) DoShowMenu(view.CalcHitInfo(new Point(e.X, e.Y)));

                //popupMenu1.ShowPopup(gridControl1.PointToScreen(view.CalcHitInfo(e.X,e.Y).HitPoint));
            }
            else
            {
                if (MyPopup.CanShowPopup)
                {
                    MyPopup.HidePopup();
                }
            }
        }
    }

    public class PopupOpeningEventArgs : EventArgs
    {
        public GridColumn Column { get; set; }

        public bool IsCancel { get; set; }

        public BarManager Manager { get; set; }

        public PopupMenu MyPopupMenu { get; set; }

        public object Rows { get; set; }
    }
}