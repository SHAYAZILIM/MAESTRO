using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.IcraTakipForms;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using AdimAdimDavaKaydi.DavaTakip;
using DevExpress.XtraBars;
using System.Drawing;

namespace AdimAdimDavaKaydi.UserControls.IcraTakipUserControls
{
    public partial class ucTaahhutler : AvpXUserControl
    {
        private TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> _MyDataSource;

        private BackgroundWorker bckWorker = new BackgroundWorker();

        private bool initsFilled;

        private AV001_TI_BIL_FOY myFoy;

        public ucTaahhutler()
        {
            if (DesignMode) 
                InitializeComponent();
            this.Load += ucTaahhutler_Load;
            
        }

        void RightClickPopup_PopupButtonClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Tag == null)
                return;

            if (e.Item.Tag.ToString() == "Düzenle")
            {
                if (gwBorcluTaahhut.FocusedRowHandle < 0)
                    return;

                rFrmTaahhut frmtah = new rFrmTaahhut();
                frmtah.MyFoy = MyFoy;
                frmtah.TaahhutList = new TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>();
                frmtah.TaahhutList.Add(MyDataSource[gwBorcluTaahhut.FocusedRowHandle]);
                frmtah.TaahhutChild = MyDataSource[gwBorcluTaahhut.FocusedRowHandle].AV001_TI_BIL_BORCLU_TAAHHUT_CHILDCollection;

                frmtah.Show();
            }
        }

        void RightClickPopup_PopupOpening(object sender, PopupOpeningEventArgs e)
        {
            BarButtonItem barAlacakNedeni = new BarButtonItem(e.Manager, "Düzenle");
            Bitmap barAlacakNedeniImage = (Bitmap)AdimAdimDavaKaydi.Properties.Resources.acilis_sozles_22;
            barAlacakNedeniImage.MakeTransparent(Color.Fuchsia);
            barAlacakNedeni.Glyph = barAlacakNedeniImage;
            barAlacakNedeni.Tag = "Düzenle";
            e.MyPopupMenu.AddItem(barAlacakNedeni);
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (IsLoaded)
                    BindData();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AV001_TI_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                {
                    DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(value, false, DeepLoadType.IncludeChildren,
                                                                     typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));

                    ucIcraTarafGelismeleri.GelismeIslemleri(MyFoy);

                    DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(
                        MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection, false, DeepLoadType.IncludeChildren,
                        typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));

                    MyDataSource = value.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection;
                }
            }
        }

        public void BindData()
        {
            if (MyDataSource == null) return;            
            MyDataSource.ListChanged += MyDataSource_ListChanged;
            if (!bckWorker.IsBusy)
            {
                bckWorker.DoWork += bckWorker_DoWork;
                bckWorker.RunWorkerCompleted += bckWorker_RunWorkerCompleted;
                bckWorker.RunWorkerAsync();
            }
        }

        private void bckWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (MyDataSource.Count == 0)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));

                DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(
                    MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection, false,
                    DeepLoadType.IncludeChildren, typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_CHILD>));
                MyDataSource = MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && IsLoaded)
            {
                LoadInitsData(false);                
                gridBorcluTaahhut.Tag = "AV001_TI_BIL_BORCLU_TAAHHUT_MASTER";
                gridBorcluTaahhut.DataSource = MyDataSource;
            }
        }
        
        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MyFoy != null)
            {
                DataRepository.AV001_TI_BIL_FOYProvider.DeepLoad(MyFoy, false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TI_BIL_BORCLU_TAAHHUT_MASTER>));

                foreach (var item in MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection)
                {
                    DataRepository.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERProvider.DeepLoad(item, false,
                                                                                       DeepLoadType.IncludeChildren,
                                                                                       typeof(
                                                                                           TList
                                                                                           <
                                                                                           AV001_TI_BIL_BORCLU_TAAHHUT_CHILD
                                                                                           >));
                }

                gridBorcluTaahhut.DataSource = MyFoy.AV001_TI_BIL_BORCLU_TAAHHUT_MASTERCollection;
            }
        }

        private void gridBorcluTaahhut_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                if (e.Button.Tag.ToString() == "FormdanEkle")
                {
                    rFrmTaahhut frm = new rFrmTaahhut();
                    LoadInitsData(true);

                    //frm.MdiParent = null;
                    frm.StartPosition = FormStartPosition.WindowsDefaultLocation;
                    frm.MyFoy = MyFoy;
                    frm.FormClosing += frm_FormClosing;
                    frm.Show();
                }
            }
        }

        private void LoadInitsData(bool newItem)
        {
            if ((!initsFilled && MyDataSource.Count > 0 || newItem))
            {
                BelgeUtil.Inits.DovizTipGetir(rLueDovizID);
                BelgeUtil.Inits.TaahhutDurumGetir(rLueDurumID);

                if (MyFoy != null)
                {
                    BelgeUtil.Inits.BorcluTarafByFoy(MyFoy, new[] { rLueBorcluCariID });
                    BelgeUtil.Inits.AlacakliTarafByFoy(MyFoy, new[] { rlueAlacakliCari });
                }
                initsFilled = true;
            }
        }

        private void MyDataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            LoadInitsData(false);
        }

        private void ucTaahhutler_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (!IsLoaded) InitializeComponent();

            IsLoaded = true;
            try
            {
                gridBorcluTaahhut.ShowOnlyPredefinedDetails = true;
                BindData();
                //gridBorcluTaahhut
                gridBorcluTaahhut.RightClickPopup.PopupOpening += new EventHandler<PopupOpeningEventArgs>(RightClickPopup_PopupOpening);
                gridBorcluTaahhut.RightClickPopup.PopupButtonClick += new EventHandler<DevExpress.XtraBars.ItemClickEventArgs>(RightClickPopup_PopupButtonClick);
            }
            catch (Exception ex)
            {
                BelgeUtil.ErrorHandler.Catch(this, ex);
            }
        }

        private void gridBorcluTaahhut_DoubleClick(object sender, EventArgs e)
        {
            if (gwBorcluTaahhut.GetFocusedRowCellValue("DAVA_FOY_ID") == null)
                return;

            if (gwBorcluTaahhut.GetFocusedRowCellValue("DAVA_FOY_ID") == DBNull.Value)
                return;

            if (gwBorcluTaahhut.FocusedRowHandle < 0)
                return;

            AV001_TD_BIL_FOY takip = DataRepository.AV001_TD_BIL_FOYProvider.GetByID((int)gwBorcluTaahhut.GetFocusedRowCellValue("DAVA_FOY_ID"));
            frmDavaTakip frmdavaTakip = new frmDavaTakip();
            frmdavaTakip.Show(takip.ID);
        }
    }
}