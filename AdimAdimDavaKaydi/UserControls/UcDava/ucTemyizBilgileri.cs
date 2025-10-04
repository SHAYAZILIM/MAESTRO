using System;
using System.ComponentModel;
using System.Windows.Forms;
using AdimAdimDavaKaydi.Forms.Dava;
using AdimAdimDavaKaydi.Util.BaseClasses;
using AvukatProLib.Extras;
using AvukatProLib2.Data;
using AvukatProLib2.Entities;
using DevExpress.XtraEditors;

namespace AdimAdimDavaKaydi.UserControls.UcDava
{
    public partial class ucTemyizBilgileri : AvpXUserControl
    {
        public ucTemyizBilgileri()
        {
            this.Load += ucTemyizBilgileri_Load;
        }

        private TList<AV001_TD_BIL_TEMYIZ> _MyDataSource;

        [Browsable(false)]
        public TList<AV001_TD_BIL_TEMYIZ> MyDataSource
        {
            get { return _MyDataSource; }
            set
            {
                _MyDataSource = value;
                if (!IsLoaded)
                    BindData();
            }
        }

        private int? _MyKanunYolu;

        public int? MyKanunYolu
        {
            get
            {
                return _MyKanunYolu;
            }
            set
            {
                if (value != null)
                {
                    _MyKanunYolu = value;
                    if (MyDataSource != null && MyDataSource.Count > 0)
                        MyDataSource[0].TEMYIZ_TIP_ID = _MyKanunYolu;
                }
            }
        }

        private BackgroundWorker bckWorker = new BackgroundWorker();

        public void BindData()
        {
            if (MyDataSource == null) return;
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
                DataRepository.AV001_TD_BIL_FOYProvider.DeepLoad(MyFoy
                                                                 , false, DeepLoadType.IncludeChildren,
                                                                 typeof(TList<AV001_TD_BIL_TEMYIZ>));

                DataRepository.AV001_TD_BIL_TEMYIZProvider.DeepLoad(MyFoy.AV001_TD_BIL_TEMYIZCollection, false,
                                                                            DeepLoadType.IncludeChildren,
                                                                            typeof(TList<AV001_TD_BIL_TEMYIZ_TARAF>));

                MyDataSource = MyFoy.AV001_TD_BIL_TEMYIZCollection;
            }
        }

        private void bckWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MyDataSource != null && !this.DesignMode && IsLoaded)
            {
                dataNavigatorExtended1.DataSource = MyDataSource;
                vgTemyizBilgileri.DataSource = MyDataSource;
                gridTemyizBilgileri.DataSource = MyDataSource;
            }
        }

        private AV001_TD_BIL_FOY myFoy;

        public AV001_TD_BIL_FOY MyFoy
        {
            get { return myFoy; }
            set
            {
                myFoy = value;
                if (value != null)
                    MyDataSource = value.AV001_TD_BIL_TEMYIZCollection;
            }
        }

        private void ucTemyizBilgileri_Load(object sender, EventArgs e)
        {
            //LOAD
            InitializeComponent();
            IsLoaded = true;
            if (MyType == ViewType.GridView)
            {
                //panelControl1.Visible = false;
                gridTemyizBilgileri.Visible = true;
            }
            if (MyType == ViewType.LayoutView)
            {
                //panelControl1.Visible = false;
                gridTemyizBilgileri.Visible = false;
            }
            if (MyType == ViewType.VGrid)
            {
                //panelControl1.Visible = true;
                gridTemyizBilgileri.Visible = false;
            }
            if (!this.DesignMode)
            {
                try
                {
                    gridTemyizBilgileri.ButtonClick += gridTemyizBilgileri_ButtonClick;

                    if (MyFoy != null)
                        BelgeUtil.Inits.MahkemeHukumGetir(rlueHukum, MyFoy.ID);
                    else if (DavaFoyID != null && DavaFoyID != 0)
                        BelgeUtil.Inits.MahkemeHukumGetir(rlueHukum, DavaFoyID);
                    BelgeUtil.Inits.perCariGetir(rlueCari);
                    BelgeUtil.Inits.AdliBirimAdliyeGetir(rlueAdliye);
                    BelgeUtil.Inits.AdliBirimNoGetir(rlueAdliBirimNo);
                    BelgeUtil.Inits.AdliBirimGorevGetir(rlueAdliGorev);
                    BelgeUtil.Inits.KararTipGetir(rlueKararTip);
                    BelgeUtil.Inits.TemyizTipGetir(rlueTemyizTip);
                    BindData();
                }
                catch (Exception ex)
                {
                    BelgeUtil.ErrorHandler.Catch(this, ex);
                }
            }
        }

        //Temyiz kayýt formunda MyFoy deðer almadýðýndan dosyaya ait hüküm bilgisi getirilemiyordu. Bu nedenle aþaðýdaki property eklendi ve kayýt formu açýlýrken bu property'e deðer verildi.
        public int DavaFoyID { get; set; }

        private void gridTemyizBilgileri_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == null) return;

            if (e.Button.Tag.ToString() == "FormAc")
            {
                frmTemyizEkle frm = new frmTemyizEkle();

                if (MyFoy == null) return;

                TList<AV001_TD_BIL_MAHKEME_HUKUM> hukumler = DataRepository.AV001_TD_BIL_MAHKEME_HUKUMProvider.GetByDAVA_FOY_ID(MyFoy.ID);
                if (hukumler != null && hukumler.Count != 0)
                    frm.Show(MyFoy);
                else
                    XtraMessageBox.Show(
                        "Temyiz kaydý yapabilmek için önce " + Environment.NewLine + " Hüküm kaydý yapmanýz gerekiyor.",
                        "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if (e.Button.Tag.ToString() == "KaydýDuzenle")
            {
                DataRepository.AV001_TD_BIL_TEMYIZProvider.DeepLoad(MyDataSource[gwTemyizBilgileri.FocusedRowHandle],
                                                                    false, DeepLoadType.IncludeChildren,
                                                                    typeof(TList<AV001_TD_BIL_TEMYIZ>));
                TList<AV001_TD_BIL_TEMYIZ> DvList = new TList<AV001_TD_BIL_TEMYIZ>();
                DvList.Add(MyDataSource[gwTemyizBilgileri.FocusedRowHandle]);
                frmTemyizEkle frm = new frmTemyizEkle();
                frm.AddNewList = DvList;
                frm.Show(MyFoy);
            }
        }

        [Description("Görünümü Deðiþtirir.")]
        [Browsable(true)]
        public ViewType MyType { get; set; }

        [Browsable(false)]
        public int vgRecordIndex
        {
            get
            {
                if (vgTemyizBilgileri.FocusedRecord < 0)
                    return 0;

                return vgTemyizBilgileri.FocusedRecord;
            }
        }
    }
}